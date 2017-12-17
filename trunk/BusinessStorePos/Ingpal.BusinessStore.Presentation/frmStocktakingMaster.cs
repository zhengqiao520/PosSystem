using DevExpress.XtraEditors;
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
    public partial class frmStocktakingMaster : BaseForm
    {
        StockBusiness stock = new StockBusiness();

        public frmStocktakingMaster()
        {
            InitializeComponent();
            dateEditStartTime1.DateTime = DateTime.Now.AddDays(-30);
            dateEditStartTime2.DateTime = DateTime.Now;
            gridViewStockTakingMaster.OptionsDetail.EnableMasterViewMode = true;
            this.WindowState = FormWindowState.Maximized;
            this.Load += FrmStocktakingMaster_Load;
            this.BindStockTakingMaster();
        }

        private void FrmStocktakingMaster_Load(object sender, EventArgs e)
        {
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindStockTakingMaster()
        {
            StockTakingMasterQueryAgrs agrs = new StockTakingMasterQueryAgrs();
            agrs.StartTime = dateEditStartTime1.DateTime;
            agrs.EndTime = dateEditStartTime2.DateTime;
            agrs.UserName = txtUserName.Text;
            agrs.Number = txtNumber.Text;
            agrs.StoreID = UserInfo.Instance.StoreID;

            var result = stock.StockTakingMasterQuery(agrs);
            this.gridStockTaking.DataSource = result;
        }

        private void gridViewStockTakingMaster_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.ListSourceRowIndex >= 0)
            {
                if (e.Column.FieldName == "Status")
                {
                    switch (e.Value.ToString())
                    {
                        case "0":
                            e.DisplayText = "未开始";
                            break;
                        case "1":
                            e.DisplayText = "盘点中";
                            break;
                        case "2":
                            e.DisplayText = "盘点结束";
                            break;
                    }

                }
            }
        }

        private void Control_EditValueChanged(object sender, EventArgs e)
        {
            this.BindStockTakingMaster();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            var row = gridViewStockTakingMaster.GetFocusedDataRow() as DataRow;
            if (row != null)
            {
                var status = int.Parse(row["Status"].ToString());
                var stockRevise = bool.Parse(row["StockRevise"].ToString());
                var number = row["number"].ToString();
                if (status == 2 && (!stockRevise))
                {
                    if (XtraMessageBox.Show(string.Format("确定根据编号[{0}]的盘点记录调整库存吗?", number), "操作提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        var id = new Guid(row["ID"].ToString());
                        var result = stock.UpdateStockByStockTakingMasterID(id);
                        if (result)
                        {
                            this.BindStockTakingMaster();
                            XtraMessageBox.Show("调整库存成功！", "操作成功", MessageBoxButtons.OK);
                        }
                        else
                        {
                            XtraMessageBox.Show("调整库存失败！", "操作未成功", MessageBoxButtons.OK);
                        }
                    }
                }
                else if (stockRevise)
                {
                    XtraMessageBox.Show("您所选盘点记录已经调整库存,不能重新调整", "操作提示", MessageBoxButtons.OK);
                }
                else
                {
                    XtraMessageBox.Show("您所选盘点记录还未结束盘点,不能调整库存", "操作提示", MessageBoxButtons.OK);
                }
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            Close();
        }
    }
}
