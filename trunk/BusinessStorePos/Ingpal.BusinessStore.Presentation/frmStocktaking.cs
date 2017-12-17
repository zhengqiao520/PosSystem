using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmStocktaking : BaseForm
    {
        StockBusiness stock = new StockBusiness();
        Guid? masterID;
        bool canEdit = false;

        int diffCount = 0;
        double diffAmount =0;

        public frmStocktaking()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.SetControls();
            this.InitStockTaking();
            this.BindStockTaking();
            this.BindStockLookUp();
            this.Load += FrmStocktaking_Load;

        }

        private void FrmStocktaking_Load(object sender, EventArgs e)
        {
         
        }

        /// <summary>
        /// 设置控件
        /// </summary>
        private void SetControls()
        {
            btnStockTakingEnd.Enabled = false;
            btnStockTakingStart.Enabled = true;
        
            txtNameAbbr.ReadOnly = true;
            txtProductCode.ReadOnly = true;
            txtProductName.ReadOnly = true;
        }

        private void BindStockLookUp()
        {
            if (masterID.HasValue)
            {
                var result = stock.StockTakingQuery(new StockTakingQueryAgrs() { MasterID = masterID.Value });
                if (result != null)
                {
                    txtProductName.Properties.DataSource = result;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 数据绑定

        /// <summary>
        /// 初始化盘点数据
        /// </summary>
        private void InitStockTaking()
        {
            var userID = Guid.NewGuid();
            masterID = stock.InitStockTaking(new StockTakingAgrs() { UserID = UserInfo.Instance.ID, UserName = UserInfo.Instance.Account,StoreID= (int)UserInfo.Instance.StoreID,StoreName=UserInfo.Instance.StoreName });
        }

        /// <summary>
        /// 盘点绑定
        /// </summary>
        private void BindStockTaking()
        {
            if (masterID.HasValue)
            {
                var result = stock.StockTakingQuery(new StockTakingQueryAgrs() { MasterID = masterID.Value });
                if (result != null)
                {
                    gridStockTaking.DataSource = result;
                }
            }
        }

        #endregion

        private void btnStockTakingEnd_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("您确定要结束盘点吗?","盘点提醒",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //    UserInfo.Instance.StoreName;
                if (masterID.HasValue)
                {
                    var result = stock.EndStockTaking(new StockTakingAgrs() { ID = masterID.Value });
                    if (result)
                    {
                        btnStockTakingEnd.Enabled = false;
                        btnStockTakingStart.Enabled = true;
                        canEdit = false;
                        gridViewStockTaking.RefreshData();
                       // InitStockTaking();
                       // BindStockTaking();
                       // BindStockLookUp();
                    }
                }

            }
        }

        private void btnStockTakingStart_Click(object sender, EventArgs e)
        {
            if (masterID.HasValue)
            {

                var result = stock.StartStockTaking(new StockTakingAgrs { ID = masterID.Value });
                if (result)
                {
                    canEdit = true;

                    btnStockTakingEnd.Enabled = true;
              
                    btnStockTakingStart.Enabled = false;

                    txtNameAbbr.ReadOnly = false;
                    txtProductCode.ReadOnly = false;
                    txtProductName.ReadOnly = false;
                    gridViewStockTaking.RefreshData();
                }
            }
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.errorInfo.ClearErrors();
            if (e.KeyChar == (char)Keys.Enter && canEdit)
            {
                var dt = gridViewStockTaking.DataSource as DataView;
                if (dt != null)
                {
                    var rows = dt.Table.Select("BarID = '" + txtProductCode.EditValue.ToString() + "'");
                    if (rows != null && rows.Length == 1)
                    {
                        var retailPrice = double.Parse(rows[0]["RetailPrice"].ToString());
                        var inventCount = int.Parse(rows[0]["InventoryQty"].ToString()) + 1;
                        var stockCount = int.Parse(rows[0]["StockQuantity"].ToString());
                        var diffCount = inventCount - stockCount;
                        var diffMoney = retailPrice * diffCount;
                        rows[0]["InventoryQty"] = inventCount;
                        rows[0]["DifferenceQty"] = diffCount;
                        rows[0]["DiffAmount"] = diffMoney;
                        this.SaveStockTaking(rows[0]);
                        txtProductCode.Text = string.Empty;


                    }
                    else
                    {
                        this.errorInfo.SetError(this.txtProductCode, "您输入的条码不正确!");
                        this.errorInfo.SetErrorType(this.txtProductCode, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                        this.errorInfo.SetIconAlignment(this.txtProductCode, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
                    }
                }
            }
        }

        private void gridViewStockTaking_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "InventoryQty")
            {
                if (canEdit)
                {
                    e.Column.OptionsColumn.ReadOnly = false;
                    e.Column.OptionsColumn.AllowEdit = true;
                    e.Column.OptionsColumn.AllowFocus = true;
                }
                else
                {
                    e.Column.OptionsColumn.ReadOnly = true;
                    e.Column.OptionsColumn.AllowEdit = false;
                    e.Column.OptionsColumn.AllowFocus = false;
                }

            }

        }

        private void gridViewStockTaking_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var focus_row = e.Row as DataRowView;
                if (focus_row != null)
                {
                    var retailPrice = double.Parse(focus_row.Row["RetailPrice"].ToString());
                    var inventCount = int.Parse(focus_row.Row["InventoryQty"].ToString());
                    var stockCount = int.Parse(focus_row.Row["StockQuantity"].ToString());
                    var diffCount = inventCount - stockCount;
                    var diffMoney = retailPrice * diffCount;
                    focus_row.Row["DifferenceQty"] = diffCount;
                    focus_row.Row["DiffAmount"] = diffMoney;
                    this.SaveStockTaking(focus_row.Row);
                }
            }
        }

        /// <summary>
        /// 保存盘点数据
        /// </summary>
        private void SaveStockTaking(DataRow datarow)
        {
            if (datarow != null)
            {
                UpdateStockTakingAgrs agrs = new UpdateStockTakingAgrs();
                agrs.StockTakingID = new Guid(datarow["ID"].ToString());
                agrs.InventoryQty = int.Parse(datarow["InventoryQty"].ToString());
                agrs.DifferenceQty = int.Parse(datarow["DifferenceQty"].ToString());
                agrs.DiffAmount = int.Parse(datarow["DiffAmount"].ToString());


                if (stock.UpdateStockTaking(agrs))
                {
                    this.BindStockTaking();
                }
            }
        }

        private void txtProductName_EditValueChanged(object sender, EventArgs e)
        {
            var dt = gridViewStockTaking.DataSource as DataView;
            if (dt != null && canEdit)
            {
                var rows = dt.Table.Select("ID = '" + txtProductName.EditValue.ToString() + "'");
                if (rows != null && rows.Length == 1)
                {
                    var retailPrice = double.Parse(rows[0]["RetailPrice"].ToString());
                    var inventCount = int.Parse(rows[0]["InventoryQty"].ToString()) + 1;
                    var stockCount = int.Parse(rows[0]["StockQuantity"].ToString());
                    var diffCount = inventCount - stockCount;
                    var diffMoney = retailPrice * diffCount;
                    rows[0]["InventoryQty"] = inventCount;
                    rows[0]["DifferenceQty"] = diffCount;
                    rows[0]["DiffAmount"] = diffMoney;
                    this.SaveStockTaking(rows[0]);
                    txtProductCode.Text = string.Empty;
                }
            }
        }

        private void txtProductName_Properties_FormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            txtProductName.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
        }

        private void txtNameAbbr_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.errorInfo.ClearErrors();
            if (e.KeyChar == (char)Keys.Enter && canEdit)
            {
                var dt = gridViewStockTaking.DataSource as DataView;
                if (dt != null)
                {
                    var rows = dt.Table.Select("NameAbbr Like '" + txtNameAbbr.EditValue.ToString() + "%'");
                    if (rows != null && rows.Length == 1)
                    {

                        var retailPrice = double.Parse(rows[0]["RetailPrice"].ToString());
                        var inventCount = int.Parse(rows[0]["InventoryQty"].ToString()) + 1;
                        var stockCount = int.Parse(rows[0]["StockQuantity"].ToString());
                        var diffCount = inventCount - stockCount; 
                        var diffMoney = retailPrice * diffCount;
                        rows[0]["InventoryQty"] = inventCount;
                        rows[0]["DifferenceQty"] = diffCount;
                        rows[0]["DiffAmount"] = diffMoney;
                        this.SaveStockTaking(rows[0]);
                        txtNameAbbr.Text = string.Empty;
                    }
                    else
                    {
                        this.errorInfo.SetError(this.txtNameAbbr, "您输入的简码不存在!");
                        this.errorInfo.SetErrorType(this.txtNameAbbr, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                        this.errorInfo.SetIconAlignment(this.txtNameAbbr, System.Windows.Forms.ErrorIconAlignment.MiddleRight);

                    }
                }
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmStocktakingMaster().Show();
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var dt = gridViewStockTaking.DataSource as DataView;
            if (dt != null)
            {
                DataRow[] rows;

                if (txtProductCode.EditValue == null)
                {
                    rows = dt.Table.Select("NameAbbr Like '" + txtNameAbbr.EditValue.ToString() + "%'");
                }
                else
                {
                    rows = dt.Table.Select("BarID = '" + txtProductCode.EditValue.ToString() + "'");
                }

                if (rows != null && rows.Length == 1)
                {
                    var retailPrice = double.Parse(rows[0]["RetailPrice"].ToString());
                    var inventCount = int.Parse(rows[0]["InventoryQty"].ToString()) + 1;
                    var stockCount = int.Parse(rows[0]["StockQuantity"].ToString());
                    var diffCount = inventCount-stockCount;
                    var diffMoney = retailPrice * diffCount;
                    rows[0]["InventoryQty"] = inventCount;
                    rows[0]["DifferenceQty"] = diffCount;
                    rows[0]["DiffAmount"] = diffMoney;
                    this.SaveStockTaking(rows[0]);
                    txtNameAbbr.Text = string.Empty;
                }
                else
                {
                    this.errorInfo.SetError(this.txtNameAbbr, "您输入的简码或条码不存在!");
                    this.errorInfo.SetErrorType(this.txtNameAbbr, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
                    this.errorInfo.SetIconAlignment(this.txtNameAbbr, System.Windows.Forms.ErrorIconAlignment.MiddleRight);

                }
            }
        }
        
        private void gridViewStockTaking_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {

            var item = e.Item as GridColumnSummaryItem;

            if (item.FieldName == "DifferenceQty")
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    diffCount = 0;
                }

                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        diffCount += Math.Abs(int.Parse(e.FieldValue.ToString()));
                    }
                }

                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = diffCount;
                }
            }

            if (item.FieldName == "DiffAmount")
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    diffAmount = 0;
                }

                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        diffAmount += Math.Abs(double.Parse(e.FieldValue.ToString()));
                    }
                }

                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = diffAmount;
                }
            }
        }
    }
}
