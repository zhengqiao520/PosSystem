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
using Ingpal.BusinessStore.Model;
namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmCoupon :BaseForm
    {
        public delegate void SelectEventHander(Couponcs couponcs);
        public event SelectEventHander SelectCouponEvent;
        public frmCoupon(CouponcsResult couponResult)
        {
            InitializeComponent();
            if (couponResult!=null&&couponResult.http_code == 200 && couponResult.data.coupon.Count > 0) {
                List<Couponcs> coupon = couponResult.data.coupon;
                grdConpou.DataSource = coupon;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (gvConpou.RowCount == 0) {
                ShowMessage("没有可用的优惠券!");
                return;
            }
           var selected=gvConpou.GetFocusedRow() as Couponcs;
            if (selected.enable == 0)
            {
                ShowMessage("该优惠券不可用！");
                return;
            }
            else {
                SelectCouponEvent(selected);
                Close();
            }
        }

        private void gvConpou_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "enable") {
                e.DisplayText = ((int)e.Value == 1) ? "可用" : "不可用";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}