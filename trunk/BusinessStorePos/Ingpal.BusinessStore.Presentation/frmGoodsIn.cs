using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using System.Data.Common;
using Ingpal.BusinessStore.Infrastructure.DB;
using AutoMapper;
using System.Reflection;
using Ingpal.BusinessStore.Infrastructure;
using Ingpal.BusinessStore.Infrastructure.Extensions;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmGoodsIn : BaseForm
    {
        internal static DBUtility utity = new DBUtility();
        private List<GoodsEntity> listGoods = new List<GoodsEntity>();
        private List<GoodsOutEntity> pendingGoodsOutList = new List<GoodsOutEntity>();
        private List<GoodsOutEntity> goodsOutHistory = new List<GoodsOutEntity>();
        private List<GoodsOutDetailEntity> goodsOutDetailList = new List<GoodsOutDetailEntity>();
        private List<GoodsOutDetailEntity> goodsOutHistoryDetailList = new List<GoodsOutDetailEntity>();

        private GoodsOutEntity selectedGoodsOutEntity;
        private GoodsOutEntity selectedHistoryGoodsOutEntity;
        public frmGoodsIn()
        {
            InitializeComponent();
            InitData();
            LoadGoodsOut();
            LoadGoodsOutHistory();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            switch (btn.Name)
            {
                case "btnAddGoodsIn":
                    AddToGrid();
                    break;
                case "btnSave":
                    GoodsIn();
                    break;
                case "btnRemoveRow":
                    if (ShowMessage("您确认要删除选中行吗?", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var selectedRow = gvGoodsInList.GetRow(gvGoodsInList.FocusedRowHandle) as GoodsEntity;
                        gvGoodsInList.DeleteRow(gvGoodsInList.FocusedRowHandle);
                        listGoods.Remove(selectedRow);
                        RefreshLoadGrid();
                    }
                    break;
            }
        }
        private void InitData()
        {
            txtOperator.Text = UserInfo.Instance.UserCode;
            var category = SysBLL.Instance.GetALL<CategoryEntity>().Where(item => item.ParentCategoryID == 0||item.ParentCategoryID==null);
            //var listMdm=MdmBLL.Instance.GetMDMByNameOrCode(new MDMEntity { MDMName = "InStockType" });
            var listMdm = MdmBLL.Instance.MDMSubList.Where(item => item.MDMTypeName == "入库类型" && item.SubValue != "1").ToList();
            BindUtil.BindComboBoxEdit(cboGoodsInType, listMdm, "SubName", "SubValue");
            BindUtil.BindComboBoxEdit(cboCategory, category.ToList(), "Category", "ID");
            BindUtil.BindComboBoxEdit(cboBarID, FindGoods("",UserInfo.Instance.StoreID.ToString()), "Name", "BarID", showKeyValueMode: false);
            gvGoodsInList.Columns.ToList().ForEach(column =>
            {
                column.OptionsColumn.AllowEdit = true;
                column.OptionsColumn.ReadOnly = true;
            });
            groupControl1.CustomButtonClick += (s, e) => Close();
        }
        private void GoodsIn()
        {
            var msg = string.Empty;
            bool result = false;
            if (!(gvGoodsInList.RowCount > 0)) {
                ShowMessage("没有可入库商品，请先添加到到入库列表！");
                return;
            }
            if (cboGoodsInType.EditValue == null) {
                ShowMessage("请选择入库类型！");
                return;
            }
            var listGoodsEntity = gvGoodsInList.DataSource as List<GoodsEntity>;
            using (DbTransaction trans = utity.Transation)
            {
                try
                {
                    int success = 0;
                    var goodsInCode = PosBLL.instance.GetBatchNumber("IN");
                    var goodsInEntiy = new GoodsInEntity();
                    listGoodsEntity.ForEach(item =>
                    {
                        Mapper.Initialize(m => m.CreateMap<GoodsEntity, GoodsInDetailEntity>());
                        var mapGoodsInDetail = Mapper.Map<GoodsInDetailEntity>(item);
                        mapGoodsInDetail.ID = Guid.NewGuid();
                        mapGoodsInDetail.GoodsInCode = goodsInCode;
                        mapGoodsInDetail.StoreID = UserInfo.Instance.StoreID;
                        if (mapGoodsInDetail.ProductionDate <= DateTime.MinValue)
                        {
                            mapGoodsInDetail.ProductionDate = null;
                        }
                        success += StockBLL.Instance.InsertGoodsInDetail(mapGoodsInDetail, trans);
                    });
                    if (success > 0)
                    {
                        var comboxItem = cboGoodsInType.EditValue as BindUtil.ComboBoxItem;
                        goodsInEntiy.GoodsInCode = goodsInCode;
                        goodsInEntiy.GoodsInDate = DateTime.Now;
                        goodsInEntiy.GoodsInHumanID = UserInfo.Instance.ID;
                        goodsInEntiy.GoodsInHumanName = UserInfo.Instance.RealName;
                        goodsInEntiy.GoodsInQuantity = listGoodsEntity.Sum(item => item.InQuantityStock);
                        goodsInEntiy.GoodsInAmount = listGoodsEntity.Sum(item => item.InstockAmount);
                        goodsInEntiy.StoreID = UserInfo.Instance.StoreID;
                        goodsInEntiy.GoodsInType = comboxItem.Value.ToInt32();
                        goodsInEntiy.GoodsInTypeName = comboxItem.Text;
                        goodsInEntiy.Remrks = txtMemo.Text;
                        int res = StockBLL.Instance.InsertGoodsIn(goodsInEntiy, trans);
                        result = res > 0;
                    }
                    if (result)
                    {
                        trans.Commit();
                        msg = $"商品入库成功！共入库{listGoodsEntity.Count()}类商品,{listGoodsEntity.Sum(item => item.InQuantityStock)}件";
                        ShowMessage(msg);
                        listGoods.Clear();
                        RefreshLoadGrid();
                    }
                    else
                    {
                        trans.Rollback();
                        msg = "商品入库失败";
                        ShowMessage(msg);
                    }
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    msg = $"商品入库失败。失败原因：{e.Message}";
                    ShowMessage(msg);
                }
                WriteLog(new PartialLog
                {
                    Description = msg,
                    ModuleName = "商品入库",
                    Result = result?ResultType.success.ToString() : ResultType.error.ToString(),
                    Type = LogType.CS.ToString()
                });
            }
        }
        private List<GoodsBaseEntity> FindGoods(string barId = "-1",string storeID="")
        {
            return GoodsBLL.instance.GetGoodsBaseListByCodeOrName(barId,storeID);
        }
        private void SetForm(GoodsBaseEntity entity)
        {
            if (entity == null)
            {
                txtBuyingPrice.Text = "";
                txtCodeNumber.Text = "";
                txtModelNumber.Text = "";
                txtName.Text = "";
                txtRetailPrice.Text = "";
                txtSPEC.Text = "";
                dteProductionDate.EditValue = null;
                cboCategory.EditValue = null;

            }
            else
            {
                txtBuyingPrice.Text = entity.BuyingPrice.ToString();
                txtCodeNumber.Text = entity.CodeNumber ?? "";
                txtModelNumber.Text = entity.ModelNumber ?? "";
                txtName.Text = entity.Name.ToString();
                txtRetailPrice.Text = entity.RetailPrice.ToString();
                txtSPEC.Text = entity.SPEC ?? "";
                if (entity.ProductionDate > DateTime.MinValue)
                {
                    dteProductionDate.EditValue = entity.ProductionDate;
                }
                else
                {
                    dteProductionDate.EditValue = null;
                }
                cboCategory.SelectedText = entity.Category;
                cboCategory.EditValue = new BindUtil.ComboBoxItem(entity.Category, entity.CategoryID.ToString());
            }
        }

        private void txtBarID_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(cboBarID.Text))
                {
                    SetForm(null);
                }
                else
                {
                    var goodsList = FindGoods(cboBarID.Text,UserInfo.Instance.StoreID.ToString());
                    SetForm(goodsList != null ? goodsList.FirstOrDefault() : null);
                }
            }
            //if (e.KeyCode == Keys.Enter&& cboBarID.EditValue!=null)
            //{
            //    var selectItem = cboBarID.SelectedItem as BindUtil.ComboBoxItem;
            //    if (selectItem != null)
            //    {
            //        var goodsList = FindGoods(selectItem.Value);
            //        if (null != goodsList)
            //        {
            //            SetForm(goodsList.FirstOrDefault());
            //        }
            //    }
            //}
        }

        private void btn_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "btnSearch")
            {
                txtBarID_Properties_KeyDown(null, new KeyEventArgs(Keys.Enter));
            }
        }

        private void cboBarID_EditValueChanged(object sender, EventArgs e)
        {
            //txtBarID_Properties_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }
        private void AddToGrid()
        {
            if (string.IsNullOrEmpty(txtRetailPrice.Text)) {
                ShowMessage("零售价不可为空！", ico: MessageBoxIcon.Warning);
                txtRetailPrice.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtInQuantityStock.Text)) {
                txtInQuantityStock.Focus();
                ShowMessage("入库数量不可为空！");
                return;
            }
            if (cboCategory.EditValue == null)
            {
                cboCategory.Focus();
                ShowMessage("商品类别不可为空！");
                return;
            }
            var barItem = cboBarID.SelectedItem as BindUtil.ComboBoxItem;
            var index=cboCategory.SelectedIndex;
            var categoryItem = cboCategory.EditValue as BindUtil.ComboBoxItem;
            GoodsEntity entity = new GoodsEntity();
            entity.BarID = barItem == null ? cboBarID.Text : barItem.Value;
            entity.Name = barItem==null?txtName.Text:barItem.OrginText;
            entity.SPEC = txtSPEC.Text;
            entity.ModelNumber = txtModelNumber.Text;
            entity.Category = categoryItem.Text;
            entity.CategoryID = categoryItem.Value.ToInt32();
            entity.CodeNumber = txtCodeNumber.Text;
            entity.BatchNo =txtBatchNo.Text;
            entity.Supplier =txtSupplier.Text;
            entity.ProductionDate =dteProductionDate.EditValue.ToDateTime();
            entity.ProductionPlace =txtProductionPlace.Text;
            entity.BuyingPrice =txtBuyingPrice.Text.ToDecimal();
            entity.RetailPrice =txtRetailPrice.Text.ToDecimal();
            entity.InQuantityStock =txtInQuantityStock.Text.ToInt32();
            entity.Remark =txtRemark.Text;
            entity.InstockAmount = entity.RetailPrice * entity.InQuantityStock;
            var existsGoods=listGoods.Find(item => item.BarID == entity.BarID);
            if (existsGoods != null)
            {
                existsGoods.InstockAmount += entity.InstockAmount;
                existsGoods.InQuantityStock += entity.InQuantityStock;
            }
            else {
                listGoods.Add(entity);
            }
            txtInQuantityStock.Text = "";
            txtInStockAmount.Text = "";
            RefreshLoadGrid();
        }
        private void RefreshLoadGrid()
        {
            grdGoodsInList.DataSource = listGoods;
            gvGoodsInList.RefreshData();
        }
        private void txtInQuantityStock_EditValueChanged(object sender, EventArgs e)
        {
            bool isNotNull = !string.IsNullOrEmpty(txtInQuantityStock.Text) && !string.IsNullOrEmpty(txtRetailPrice.Text);
            txtInStockAmount.Text = isNotNull ? (txtInQuantityStock.Text.ToDecimal() * txtRetailPrice.Text.ToDecimal()).ToString() : null; 
        }

        private void cboBarID_TextChanged(object sender, EventArgs e)
        {
            txtBarID_Properties_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }

        private void gvGoodsOutList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var handler = gvGoodsOutList.FocusedRowHandle;
            if (handler < 0)
            {
                return;
            }
            var entityId = gvGoodsOutList.GetRowCellValue(handler, "ID");
            if (entityId == null)
            {
                return;
            }

            int goodsOutID = int.Parse(entityId.ToString());
            var entity = this.pendingGoodsOutList.FirstOrDefault(g => g.ID == goodsOutID);
            if (entity == null || entity == selectedGoodsOutEntity)
            {
                return;
            }
            else
            {
                selectedGoodsOutEntity = entity;
                simpleButton1.Enabled = selectedGoodsOutEntity.Status == 1;
                simpleButton2.Enabled = selectedGoodsOutEntity.Status == 1;
                LoadDetailGrid();
            }
        }

        private void LoadGoodsOut()
        {
            this.pendingGoodsOutList.Clear();
            ClearGoodsOutDetail();
            var data = StockBLL.Instance.GetPendingGoodsOutListByReceiver(UserInfo.Instance.StoreID ?? 0);
            if(data != null)
            {
                pendingGoodsOutList = data;
            }
            this.grdGoodsOutList.DataSource = pendingGoodsOutList;
            this.gvGoodsOutList.RefreshData();
        }

        private void ClearGoodsOutDetail()
        {
            this.goodsOutDetailList.Clear();
            this.gvGoodsOutDetail.RefreshData();
        }

        private void ClearGoodsOutHistoryDetail()
        {
            this.goodsOutHistoryDetailList.Clear();
            this.gridDetailView.RefreshData();
        }


        private void LoadGoodsOutHistory()
        {
            this.goodsOutHistory.Clear();
            ClearGoodsOutHistoryDetail();
            var data = StockBLL.Instance.GetGoodsOutHistoryByReceiver(UserInfo.Instance.StoreID ?? 0);
            if (data != null)
            {
                goodsOutHistory = data;
            }
            this.gridHistory.DataSource = goodsOutHistory;
            this.gridView2.RefreshData();
        }
        private void LoadDetailGrid()
        {
            if (goodsOutDetailList != null)
            {
                goodsOutDetailList.Clear();
            }

            var data = StockBLL.Instance.GetGoodsOutDetailList(selectedGoodsOutEntity.GoodsOutCode);
            if (data != null)
            {
                goodsOutDetailList = data;
            }
            grdGoodsOutDetail.DataSource = goodsOutDetailList;
            grdGoodsOutDetail.RefreshDataSource();
        }

        private void LoadHistoryDetailGrid()
        {
            if (goodsOutHistoryDetailList != null)
            {
                goodsOutHistoryDetailList.Clear();
            }

            var data = StockBLL.Instance.GetGoodsOutDetailList(selectedHistoryGoodsOutEntity.GoodsOutCode);
            if (data != null)
            {
                goodsOutHistoryDetailList = data;
            }

            
            gridHistoryDetail.DataSource = goodsOutHistoryDetailList;
            gridHistoryDetail.RefreshDataSource();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认接收该商品", "提示信息", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            if (selectedGoodsOutEntity == null)
            {
                MessageBox.Show("选中出库记录不存在");
                return;
            }
            var effectedRows = StockBLL.Instance.MaintainGoodsOutStatus(selectedGoodsOutEntity, 2, UserInfo.Instance.ID);
            if (effectedRows > 0)
            {
                MessageBox.Show("接收成功", "提示");
                this.simpleButton1.Enabled = false;
                this.simpleButton2.Enabled = false;
                LoadGoodsOut();
                LoadGoodsOutHistory();
            }
            else
            {
                MessageBox.Show("接收失败", "提示");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认拒绝接收该商品", "提示信息", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            if (selectedGoodsOutEntity == null)
            {
                MessageBox.Show("选中出库记录不存在");
                return;
            }
            var effectedRows = StockBLL.Instance.MaintainGoodsOutStatus(selectedGoodsOutEntity, 3, UserInfo.Instance.ID);
            if (effectedRows > 0)
            {
                MessageBox.Show("拒绝成功");
                this.simpleButton1.Enabled = false;
                this.simpleButton2.Enabled = false;
                LoadGoodsOut();
                LoadGoodsOutHistory();
            }
            else
            {
                MessageBox.Show("拒绝失败");
            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var handler = gridView2.FocusedRowHandle;
            if (handler < 0)
            {
                return;
            }
            var entityId = gridView2.GetRowCellValue(handler, "ID");
            if (entityId == null)
            {
                return;
            }

            int goodsOutID = int.Parse(entityId.ToString());
            var entity = this.goodsOutHistory.FirstOrDefault(g => g.ID == goodsOutID);
            if (entity == null || entity == selectedHistoryGoodsOutEntity)
            {
                return;
            }
            else
            {
                selectedHistoryGoodsOutEntity = entity;
                LoadHistoryDetailGrid();
            }
        }
    }
}
