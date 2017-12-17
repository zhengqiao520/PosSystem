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
using AutoMapper;
namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmGetHanding : BaseForm
    {
        public delegate void GetHandingOrderDelegate(RestPosEntity restpos, List<Model.Entity.PosExt> listPosExt, string posID);
        public event GetHandingOrderDelegate GetHandingEvent;
        private string _guider = string.Empty;
        private RestPosEntity restPos;
        private List<Model.Entity.PosExt> handingList;
        public frmGetHanding()
        {
            InitializeComponent();
            gvRestPos.RowHeight = 35;
        }
        public frmGetHanding(string guider = null)
            : this()
        {
            _guider = guider;
            InitGrid();
        }
        private void InitGrid()
        {
            var listRestPos = PosBLL.instance.GetRestPos(_guider, Model.UserInfo.Instance.StoreID.ToString());
            gridRestPos.DataSource = listRestPos;
        }


        private void gvRestPos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void gvRestPos_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (gvRestPos.GetFocusedRow() == null) return;
            var btn = sender as SimpleButton;
            var posID = (gvRestPos.GetFocusedRow() as RestPosEntity).Id;
            if (btn.Name == "btnFakeOrder")
            {
                if (XtraMessageBox.Show("您确认要作废该笔挂单吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int res = PosBLL.instance.RemoveRestPos(posID.ToString());
                    if (res > 0) InitGrid();
                }
            }
            else if (btn.Name == "btnGetOrder")
            {
                if (XtraMessageBox.Show("您确认要取回选中挂单记录？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetHandingEvent(restPos, handingList, posID.ToString());
                    Close();
                }
            }
        }

        private void gvRestPos_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var focusRow = gvRestPos.GetFocusedRow() as RestPosEntity;
            if (focusRow == null)
            {
                grdGoods.DataSource = null;
                gridRestPos.DataSource = null;
            }
            else
            {
                restPos = focusRow;
                handingList = PosBLL.instance.GetRestPosExt(focusRow.Id.ToString());
                handingList.ForEach(s =>
                {
                    s.RetailPrice = s.PosSalesAmount / s.PosSalesCount * 1.0m;
                });
                grdGoods.DataSource = handingList;
            }
        }
    }
}