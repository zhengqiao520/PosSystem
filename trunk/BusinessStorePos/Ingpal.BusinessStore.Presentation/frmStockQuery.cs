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
using Ingpal.BusinessStore.Infrastructure.Win32;
using System.Collections.Concurrent;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.Utils;
using Ingpal.BusinessStore.Model.Entity;

namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmStockQuery : BaseForm
    {
        StockBusiness biz = new StockBusiness();
        Color color1;
        Color color2;
        public frmStockQuery()
        {
            InitializeComponent();
            base.BaseInit();
            this.WindowState = FormWindowState.Maximized;
            this.Load += FrmStockQuery_Load;
        }

        private void FrmStockQuery_Load(object sender, EventArgs e)
        {
            //ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();
            //ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();
            ConcurrentDictionary<int, int> concurrentDictionary = new ConcurrentDictionary<int, int>();
            //ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();         
            gridStock.DataSource = biz.StockQuery(new StockQueryAgrs() { StoreID = UserInfo.Instance.StoreID });
            InitCategories();
        }

        /// <summary>
        /// 初始化产品分类
        /// </summary>
        private void InitCategories()
        {        
            //BaseBLL baseBll = new BaseBLL();
            var categories = SysBLL.Instance.GetALL<CategoryEntity>().Where(q => q.ParentCategoryID == 0|| q.ParentCategoryID==null).ToList();
            categories.Insert(0, new CategoryEntity() { Category = "全部商品", ID = 0 });
            lookUpCategories.Properties.DisplayMember = "Category";
            lookUpCategories.Properties.ValueMember = "ID";
            lookUpCategories.Properties.DataSource = categories;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnQueryStock_Click(object sender, EventArgs e)
        {
            StockQueryAgrs queryAgrs = new StockQueryAgrs();
            queryAgrs.Barcode = txtProductCode.Text;
            queryAgrs.ProductName = txtProductName.Text;
            queryAgrs.StoreID = UserInfo.Instance.StoreID;
            gridStock.DataSource = biz.StockQuery(queryAgrs);
        }

        private void gridViewStock_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (chkStoreWaring.Checked)
                {
                    var row_data = gridViewStock.GetDataRow(e.RowHandle);
                    if (row_data != null)
                    {
                        var stockQuantity = (int)row_data["StockQuantity"];
                        var alarmAmount = (int)row_data["AlarmAmount"];
                        if (stockQuantity == alarmAmount)
                        {
                            e.Appearance.BackColor = Color.FromArgb(252, 248, 227);
                            e.Appearance.BackColor2 = Color.FromArgb(252, 248, 227);
                            e.Appearance.ForeColor = Color.FromArgb(138, 109, 59);

                            if (gridViewStock.Appearance.FocusedRow.BackColor != Color.Transparent)
                            {
                                color1 = gridViewStock.Appearance.FocusedRow.BackColor;
                                color2 = gridViewStock.Appearance.FocusedRow.BackColor2;
                            }
                            gridViewStock.Appearance.FocusedRow.BackColor = Color.Transparent;
                            gridViewStock.Appearance.FocusedRow.BackColor2 = Color.Transparent;

                        }
                        else if (stockQuantity < alarmAmount)
                        {
                            e.Appearance.BackColor = Color.FromArgb(242, 222, 222);
                            e.Appearance.BackColor2 = Color.FromArgb(242, 222, 222);
                            e.Appearance.ForeColor = Color.FromArgb(169, 68, 66);

                            if (gridViewStock.Appearance.FocusedRow.BackColor != Color.Transparent)
                            {
                                color1 = gridViewStock.Appearance.FocusedRow.BackColor;
                                color2 = gridViewStock.Appearance.FocusedRow.BackColor2;
                            }
                            gridViewStock.Appearance.FocusedRow.BackColor = Color.Transparent;
                            gridViewStock.Appearance.FocusedRow.BackColor2 = Color.Transparent;

                        }
                        else if (stockQuantity > (alarmAmount * 2))
                        {
                            gridViewStock.Appearance.FocusedRow.BackColor = color1;
                            gridViewStock.Appearance.FocusedRow.BackColor2 = color1;

                        }
                    }
                }
                else
                {
                    gridViewStock.Appearance.FocusedRow.BackColor = color1;
                    gridViewStock.Appearance.FocusedRow.BackColor2 = color1;
                }
            }
        }

        private void chkStoreWaring_CheckedChanged(object sender, EventArgs e)
        {
            gridStock.RefreshDataSource();
        }

        private void gridViewStock_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Image" && e.IsGetData)
            {
                try
                {
                    if (e.Row != null)
                    {
                        Image image;
                        e.Column.Caption = "";
                        DataRowView datarow = e.Row as DataRowView;
                        var stockQuantity = (int)datarow["StockQuantity"];
                        var alarmAmount = (int)datarow["AlarmAmount"];
                        if (stockQuantity == alarmAmount)
                        {
                            image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Attention_32.png");
                        }
                        else if (stockQuantity < alarmAmount)
                        {
                            image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\High_Priority_32.png");
                        }
                        else
                        {
                            image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Ok_32.png");
                        }
                        e.Value = image;

                    }
                }
                catch 
                {

                }
            }

        }

        private void txtProductCode_EditValueChanged(object sender, EventArgs e)
        {
            StockQueryAgrs queryAgrs = new StockQueryAgrs();
            queryAgrs.Barcode = txtProductCode.Text;
            queryAgrs.ProductName = txtProductName.Text;
            queryAgrs.StoreID = UserInfo.Instance.StoreID;
            queryAgrs.Category = lookUpCategories.EditValue.ToString() == "0" ? "" : lookUpCategories.EditValue.ToString();
            gridStock.DataSource = biz.StockQuery(queryAgrs);
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            Close();
        }
    }
}