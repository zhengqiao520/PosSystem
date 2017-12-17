using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
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
    public partial class frmGoodsOutList : BaseForm
    {
        public frmGoodsOutList()
        {
            InitializeComponent();
            groupControl1.CustomButtonClick += (s, e) => Close();
        }

        private List<GoodsOutEntity> listGoods = new List<GoodsOutEntity>();
        private List<GoodsOutDetailEntity> goodsOutDetailList = new List<GoodsOutDetailEntity>();
        private BackgroundWorker loadDataWorker;
        private GoodsOutEntity selectedEntity;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new frmGoodsOut();
            editForm.AfterCreated = this.GetHistory;
            editForm.Show(this);
        }

        private void GetHistory()
        {
            listGoods.Clear();
            StartLoad();
        }

        private void RefreshGrid()
        {
            grdGoodsOutList.DataSource = listGoods;
            gvGoodsOutList.RefreshData();
        }

        private void StartLoad()
        {
            if (loadDataWorker == null)
            {
                loadDataWorker = new BackgroundWorker();
                loadDataWorker.DoWork += LoadDataWorker_DoWork;
                loadDataWorker.RunWorkerCompleted += LoadDataWorker_RunWorkerCompleted;
            }

            loadDataWorker.RunWorkerAsync();
        }

        private void LoadDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                return;
            }

            var history = e.Result as List<GoodsOutEntity>;
            if (history != null && history.Count > 0)
            {
                listGoods.AddRange(history);
                RefreshGrid();
            }
        }

        private void LoadDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var history = StockBLL.Instance.GetGoodsOutList(UserInfo.Instance.StoreID ?? 0);
            e.Result = history;
        }

        private void frmGoodsOutList_Load(object sender, EventArgs e)
        {
            GetHistory();
        }

        private void LoadDetailGrid()
        {
            if (goodsOutDetailList != null)
            {
                goodsOutDetailList.Clear();
            }

            goodsOutDetailList = StockBLL.Instance.GetGoodsOutDetailList(selectedEntity.GoodsOutCode);
            grdGoodsOutDetail.DataSource = goodsOutDetailList;
            grdGoodsOutDetail.RefreshDataSource();

        }

        private void grdGoodsOutList_Click(object sender, EventArgs e)
        {
        }

        private void gvGoodsOutList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
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
            var entity = this.listGoods.FirstOrDefault(g => g.ID == goodsOutID);
            if (entity == null || entity == selectedEntity)
            {
                return;
            }
            else
            {
                selectedEntity = entity;
                simpleButton1.Enabled = selectedEntity.Status == 1;
                LoadDetailGrid();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (selectedEntity == null)
            {
                MessageBox.Show("选中出库记录不存在", "提示");
                return;
            }
            var effectedRows = StockBLL.Instance.MaintainGoodsOutStatus(selectedEntity, 4);
            if (effectedRows > 0)
            {
                MessageBox.Show("取消成功", "提示");
                this.simpleButton1.Enabled = false;
                GetHistory();
            }
            else
            {
                MessageBox.Show("取消失败", "提示");
            }
        }

        private void frmGoodsOutList_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void gvGoodsOutList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
