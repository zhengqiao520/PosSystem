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
using DevExpress.XtraGrid;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Model.Entity;

namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmSaleList : BaseForm
    {
        SaleBusiness sale = new SaleBusiness();

        public frmSaleList()
        {
            InitializeComponent();
            base.BaseInit();
            AddSummaryItems();
            this.WindowState = FormWindowState.Maximized;
            this.Load += FrmSaleList_Load;
        }

        private void FrmSaleList_Load(object sender, EventArgs e)
        {
            dateStartTime.EditValue = DateTime.Now.AddDays(-3);
            dateEndTime.EditValue = DateTime.Now;
            BindDataSource();
        }

        /// <summary>
        /// 汇总
        /// </summary>
        private void AddSummaryItems()
        {
            //this.gridView2.BestFitColumns();
            //GridColumnSummaryItem item = gridView2.Columns["小计"].Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            //item.FieldName = "小计";
            //item.DisplayFormat = "{0}";


            //GridColumnSummaryItem item1 = gridView2.Columns["原价"].Summary.Add();
            //item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //item1.FieldName = "原价";
            //item1.DisplayFormat = "{0:c2}";

            //GridColumnSummaryItem item2 = gridView2.Columns["现价"].Summary.Add();
            //item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //item2.FieldName = "现价";
            //item2.DisplayFormat = "{0:c2}";


            //GridColumnSummaryItem item3 = gridView2.Columns["折扣"].Summary.Add();
            //item3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //item3.FieldName = "折扣";
            //item3.DisplayFormat = "{0:c2}";

            //GridColumnSummaryItem item4 = gridView2.Columns["数量"].Summary.Add();
            //item4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //item4.FieldName = "数量";
            //item4.DisplayFormat = "{0}";
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnQuerySale_Click(object sender, EventArgs e)
        {
            this.BindDataSource();
        }

        private void gridViewPos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var id = gridViewPos.GetFocusedDataRow()["ID"].ToString();
            this.BindDetail(id);
        }

        /// <summary>
        /// 绑定销售列表
        /// </summary>
        private void BindDataSource()
        {
            var agrs = new SaleQueryAgrs();
            agrs.TicketCode = txtTickno.Text;
            agrs.SaleStartTime = dateStartTime.DateTime <= DateTime.MinValue ? null : (DateTime?)dateStartTime.DateTime;
            agrs.SaleEndTime = dateEndTime.DateTime <= DateTime.MinValue ? null : (DateTime?)dateEndTime.DateTime;
            agrs.StoreID = UserInfo.Instance.StoreID;

            var result = sale.SaleListQuery(agrs);

            gridControlPos.DataSource = result;

            if (result != null && result.Rows.Count > 0)
            {
                var rowid = gridViewPos.GetFocusedDataRow()["ID"].ToString();
                this.BindDetail(rowid);
            }
            else
            {
                gridControlPosDetail.DataSource = null;
            }
        }

        /// <summary>
        /// 绑定销售明细
        /// </summary>
        /// <param name="id">ID</param>
        private void BindDetail(string id)
        {
            var result = sale.SaleDetailQuery(new Model.SaleQueryAgrs { PosID = new Guid(id) });
            if (result != null)
            {
                gridControlPosDetail.DataSource = result;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridControlPos_Click(object sender, EventArgs e)
        {

        }

        private void gridViewPos_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.ListSourceRowIndex >= 0 && e.Column.FieldName == "RecordStatus")
            {
                var data_row = gridViewPos.GetDataRow(e.ListSourceRowIndex);
                if (data_row != null)
                {
                    var status = (int)data_row["RecordStatus"];
                    switch (status)
                    {
                        case 0:
                            e.DisplayText = "正常";
                            break;

                        case 1:
                            e.DisplayText = "挂单";
                            break;
                        case -1:
                            e.DisplayText = "退货";
                            break;

                    }
                }
            }
        }

        private void txtTickno_EditValueChanged(object sender, EventArgs e)
        {
            this.BindDataSource();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            Close();
        }

        static readonly Color defaultStyle= Color.FromArgb(255, 255, 255);
        private void gridViewPos_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            Color color1 = defaultStyle;
            Color color2 = defaultStyle;
            if (e.RowHandle >= 0)
            {
                var row_data = gridViewPos.GetDataRow(e.RowHandle);
                if (row_data != null)
                {
                    var isReturnGoods = (int)row_data["RecordStatus"];
                    if (isReturnGoods == -1)
                    {
                        e.Appearance.BackColor = Color.FromArgb(242, 222, 222);
                        e.Appearance.BackColor2 = Color.FromArgb(242, 222, 222);
                        e.Appearance.ForeColor = Color.FromArgb(169, 68, 66);

                        if (gridViewPos.Appearance.FocusedRow.BackColor != Color.Transparent)
                        {
                            color1 = gridViewPos.Appearance.FocusedRow.BackColor;
                            color2 = gridViewPos.Appearance.FocusedRow.BackColor2;
                        }
                        gridViewPos.Appearance.FocusedRow.BackColor = Color.Transparent;
                        gridViewPos.Appearance.FocusedRow.BackColor2 = Color.Transparent;
                    }
                    else if(isReturnGoods == 1)
                    {
                        e.Appearance.BackColor = Color.FromArgb(252, 248, 227);
                        e.Appearance.BackColor2 = Color.FromArgb(252, 248, 227);
                        e.Appearance.ForeColor = Color.FromArgb(138, 109, 59);

                        if (gridViewPos.Appearance.FocusedRow.BackColor != Color.Transparent)
                        {
                            color1 = gridViewPos.Appearance.FocusedRow.BackColor;
                            color2 = gridViewPos.Appearance.FocusedRow.BackColor2;
                        }
                        gridViewPos.Appearance.FocusedRow.BackColor = Color.Transparent;
                        gridViewPos.Appearance.FocusedRow.BackColor2 = Color.Transparent;
                    }
                    else
                    {
                        gridViewPos.Appearance.FocusedRow.BackColor = color1;
                        gridViewPos.Appearance.FocusedRow.BackColor2 = color2;
                    }
                }
            }
        }

        private void gridViewPosDetail_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            Color color1 = defaultStyle;
            Color color2 = defaultStyle;
            if (e.RowHandle >= 0)
            {
                var row_data = gridViewPosDetail.GetDataRow(e.RowHandle);
                if (row_data != null)
                {
                    var returnCount = (int)row_data["ReturnCount"];
                    if (returnCount >0)
                    {
                        e.Appearance.BackColor = Color.FromArgb(242, 222, 222);
                        e.Appearance.BackColor2 = Color.FromArgb(242, 222, 222);
                        e.Appearance.ForeColor = Color.FromArgb(169, 68, 66);

                        if (gridViewPosDetail.Appearance.FocusedRow.BackColor != Color.Transparent)
                        {
                            color1 = gridViewPosDetail.Appearance.FocusedRow.BackColor;
                            color2 = gridViewPosDetail.Appearance.FocusedRow.BackColor2;
                        }
                        gridViewPosDetail.Appearance.FocusedRow.BackColor = Color.Transparent;
                        gridViewPosDetail.Appearance.FocusedRow.BackColor2 = Color.Transparent;
                    }
                    else
                    {
                        gridViewPosDetail.Appearance.FocusedRow.BackColor = color1;
                        gridViewPosDetail.Appearance.FocusedRow.BackColor2 = color2;
                    }
                }
            }
        }
    }
}