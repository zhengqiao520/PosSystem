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
using Ingpal.BusinessStore.Infrastructure;
using AutoMapper;
using System.Data.Common;
using Ingpal.BusinessStore.Infrastructure.DB;
using DevExpress.XtraEditors.Repository;

namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmGoodsOut :BaseForm
    {
        internal static DBUtility utity = new DBUtility();
        private List<GoodsOutDetailEntity> listGoods = new List<GoodsOutDetailEntity>();

        public Action AfterCreated;
        public frmGoodsOut()
        {
            InitializeComponent();
            Load += FrmGoodsOut_Load;
            groupControl1.CustomButtonClick += (s, e) => Close();
        }

        private void FrmGoodsOut_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void btn_Click(object sender, EventArgs e) {
            SimpleButton btn = sender as SimpleButton;
            switch (btn.Name)
            {
                case "btnSave":
                    GoodsOut();
                    break;
                case "btnRemoveRow":
                    if (ShowMessage("您确认要删除选中行吗?", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var selectedRow = gvGoodsOutList.GetRow(gvGoodsOutList.FocusedRowHandle) as GoodsOutDetailEntity;
                        listGoods.Remove(selectedRow);
                        gvGoodsOutList.DeleteRow(gvGoodsOutList.FocusedRowHandle);
                    }
                    break;
            }
        }
        /// <summary>
        /// 搜索栏按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchGoods_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var btn = e.Button;
            switch (btn.Caption)
            {
                case "search":
                    txtSearchGoods_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
                    break;
                case "combo":
                    txtSearchGoods.ShowPopup();
                    break;
                default:
                    txtSearchGoods.Text = string.Empty;
                    break;
            }
        }
        private void txtSearchGoods_KeyPress(object sender, KeyPressEventArgs e)
        {
            //回车
            if (e.KeyChar == (char)Keys.Enter)
            {
                FindAddGoods(txtSearchGoods.Text, () =>
                {
                    grdGoodsOutList.DataSource = listGoods;
                    grdGoodsOutList.DataSource = listGoods;
                    grdGoodsOutList.RefreshDataSource();
                    grdGoodsOutList.RefreshDataSource();
                    txtSearchGoods.ClosePopup();
                    txtSearchGoods.Text = "";
                });
            }
        }
        private void InitData()
        {
            txtOperator.Text = UserInfo.Instance.UserCode;
            var listMdm = MdmBLL.Instance.MDMSubList.Where(item => item.MDMTypeName == "出库类型").ToList();
            BindUtil.BindComboBoxEdit(cboGoosOutType, listMdm, "SubName", "SubValue");

            var storeList = StoreBLL.Instance.GetAllStore().Where(s => s.ID != UserInfo.Instance.StoreID).ToList();
            BindUtil.BindComboBoxEdit(cboReciveStore, storeList, "StoreName", "ID");
            gvGoodsOutList.Columns.ToList().ForEach(column =>
            {
                column.OptionsColumn.AllowEdit = true;
                //column.OptionsColumn.ReadOnly = true;
            });
        }
        /// <summary>
        /// 根据条码或商品名查找并添加合并到商品列表
        /// </summary>
        /// <param name="goodsCodeOrName"></param>
        /// <param name="act"></param>
        private void FindAddGoods(string goodsCodeOrName = "", Action act = null)
        {
            if (string.IsNullOrEmpty(goodsCodeOrName)) return;
            //库存充足
            var entity = GoodsBLL.instance.GetGoodsListByCodeOrName(goodsCodeOrName, UserInfo.Instance.StoreID.ToString());
            if (entity != null)
            {
                if (entity.Count > 1)
                {
                    txtSearchGoods.Properties.Items.Clear();
                    txtSearchGoods.Properties.Items.AddRange(entity.Select(item => item.Name).ToArray());
                    txtSearchGoods.ShowPopup();
                }
                else
                {
                    if (entity[0].StockQuantity <= 0)
                    {
                        XtraMessageBox.Show("商品库存不足!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var goodsOutEntity = entity[0];
                    if (listGoods.Count > 0)
                    {
                        var fitGoods = listGoods.Find(item => item.GoodsId == goodsOutEntity.ID);
                        if (fitGoods != null)
                        {
                            fitGoods.OutQuantityStock += 1;
                           
                        }
                        else
                        {
                            var detail = new GoodsOutDetailEntity
                            {
                                GoodsId = goodsOutEntity.ID,
                                OutQuantityStock = 1,
                                Unit = goodsOutEntity.Unit,
                                Name = goodsOutEntity.Name,
                                StockQuantity = goodsOutEntity.StockQuantity
                            };
                            
                            listGoods.Add(detail);
                        }
                    }
                    else
                    {
                        var detail = new GoodsOutDetailEntity
                        {
                            GoodsId = goodsOutEntity.ID,
                            OutQuantityStock = 1,
                            Unit = goodsOutEntity.Unit,
                            Name = goodsOutEntity.Name,
                            StockQuantity = goodsOutEntity.StockQuantity
                        };

                        listGoods.Add(detail);
                    }
                }
            }
            act?.Invoke();
        }
        private void ReloadGrid() {
            grdGoodsOutList.DataSource = listGoods;
            gvGoodsOutList.RefreshData();
        }
        private void GoodsOut()
        {
            var msg = string.Empty;
            bool result = false;
            if (!(gvGoodsOutList.RowCount > 0))
            {
                ShowMessage("没有可出库商品，请先添加到到出库列表！");
                return;
            }
            if (cboGoosOutType.EditValue == null)
            {
                ShowMessage("请选择出库类型！");
                cboGoosOutType.Focus();
                return;
            }
            if (cboReciveStore.EditValue == null)
            {
                ShowMessage("请选择接收门店！");
                cboReciveStore.Focus();
                return;
            }
            using (DbTransaction trans = utity.Transation)
            {
                var listGoodsEntity = gvGoodsOutList.DataSource as List<GoodsOutDetailEntity>;
                try
                {
                    int success = 0;
                    var goodsOutCode = PosBLL.instance.GetBatchNumber("OT");
                    listGoodsEntity.ForEach(item =>
                    {
                        var mapGoodsOutDetail =item;
                        mapGoodsOutDetail.ID = Guid.NewGuid();
                        mapGoodsOutDetail.GoodsOutCode = goodsOutCode;
                        var receiver = (cboReciveStore.EditValue as BindUtil.ComboBoxItem);
                        mapGoodsOutDetail.ReceiverStoreId = receiver.Value.ToInt32();
                       
                        success += StockBLL.Instance.InsertGoodsOutDetail(mapGoodsOutDetail, trans);
                        if (success <= 0)
                        {
                            throw new Exception(string.Format("商品({0})调拨失败，请确认接收方是否已授权并入库后重试", item.Name));
                        }
                    });
                    if (success > 0)
                    {
                        var outType = (cboGoosOutType.EditValue as BindUtil.ComboBoxItem);
                        var receiver = (cboReciveStore.EditValue as BindUtil.ComboBoxItem);
                        var goodsOutEntiy = new GoodsOutEntity()
                        {
                            GoodsOutCode = goodsOutCode,
                            GoodsOutDate = DateTime.Now,
                            GoodsOutHumanID = UserInfo.Instance.ID,
                            GoodsOutHumanName = UserInfo.Instance.RealName,
                            GoodsOutQuantity = listGoodsEntity.Sum(item => item.OutQuantityStock),
                            
                            StoreID = (int)UserInfo.Instance.StoreID,
                            ReceiverStoreID = receiver.Value.ToInt32(),
                            GoodsOutType = outType.Value.ToInt32(),
                            GoodsOutTypeName = outType.Text.Trim(),
                            Remrks=txtRemark.EditValue.ToString()
                        };
                        result = StockBLL.Instance.InsertGoodsOut(goodsOutEntiy, trans) > 0;
                    }
                    if (result)
                    {
                        trans.Commit();
                        msg = $"商品出库成功！共出库{listGoodsEntity.Count()}类商品,{listGoodsEntity.Sum(item => item.OutQuantityStock)}件";
                        ShowMessage(msg);
                        //listGoods.Clear();
                        //ReloadGrid();
                        AfterCreated?.Invoke();
                        this.Close();

                    }
                    else
                    {
                        trans.Rollback();
                        msg = "商品出库失败";
                        ShowMessage("商品出库失败");
                    }
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    msg = $"商品出库失败。失败原因：{e.Message}";
                    ShowMessage(msg);
                }
                WriteLog(new PartialLog
                {
                    Description = msg,
                    ModuleName = "商品出库",
                    Result = result ? ResultType.success.ToString() : ResultType.error.ToString(),
                    Type = LogType.CS.ToString()
                });
            }
        }

        private void gvGoodsOutList_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (e.Column.FieldName == "OutQuantityStock")
                {
                    string maxOutNumber = gv.GetRowCellValue(e.RowHandle, gv.Columns["StockQuantity"]).ToString();
                    var repositionItem = e.RepositoryItem as RepositoryItemSpinEdit;
                    repositionItem.MaxValue = maxOutNumber.ToInt32();
                }
            }
            catch { }
        }
    }
}