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
using Ingpal.BusinessStore.Model.Entity;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Infrastructure;
namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmDiscount : DevExpress.XtraEditors.XtraForm
    {
        public List<PosExt> ListPosExt { get; set; }
        private PosExt FocusePostExt { get; set; }
        public DiscountType discountType { get; set; }
        public frmDiscount()
        {
            InitializeComponent();
        }
        public frmDiscount(List<PosExt> posPosExtList, PosExt focusePos)
        {
            ListPosExt = posPosExtList;
            FocusePostExt = focusePos;
            discountType = DiscountType.SingleDiscount;
            InitializeComponent();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            var discountRate = txtDiscountRate.Text.ToDecimal();
            var discountMoney = txtDiscoutMoney.Text.ToDecimal();
            var discountPrice = txtDiscountPrice.Text.ToDecimal();
            var btn = sender as SimpleButton;
            switch (btn.Name) {
                case "btnConfirm":
                    if (!toggleSwitch.IsOn)
                    {
                        var selectedItem = ListPosExt.Where(item => item.BarID == FocusePostExt.BarID).First();
                        selectedItem.PosDiscountPrice = (discountRate/100) * FocusePostExt.RetailPrice;
                        selectedItem.PosSalesAmount = selectedItem.PosDiscountPrice * selectedItem.PosSalesCount;
                    }
                    else {
                        ListPosExt.ForEach(item =>
                        {
                            item.PosDiscountPrice = discountRate/100 * item.RetailPrice;
                            item.PosSalesAmount = item.PosDiscountPrice * item.PosSalesCount;
                        });
                    }
                    break;
                case "btnCancel":
                    break;
            }
            Close();
        }

        private void txtDiscountRate_EditValueChanged(object sender, EventArgs e)
        {
            //折扣率
            var discountRate = txtDiscountRate.EditValue.ToString().ToDecimal();
            //折扣价格
            var discountPrice = txtDiscountPrice.Text.ToDecimal();
            //折扣金额
            var discountMoney = txtDiscoutMoney.Text.ToDecimal();
            if (discountType == DiscountType.SingleDiscount)
            {
                var updatedPosExtList = ListPosExt.Where(item => item.ID == FocusePostExt.ID).First();
                updatedPosExtList.PosDiscountPrice = (discountRate/100) * FocusePostExt.RetailPrice;
                txtDiscoutMoney.EditValue = FocusePostExt.RetailPrice - updatedPosExtList.PosDiscountPrice;
                txtDiscountPrice.EditValue = FocusePostExt.RetailPrice - txtDiscoutMoney.EditValue.ToString().ToDecimal();
            }
        }

        private void txtDiscoutMoney_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDiscountPrice_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void CalcDiscount(DiscountType discountType, List<PosExt> listPosExt, PosExt focusePostExt)
        {

        }

        private void toggleSwitch_Toggled(object sender, EventArgs e)
        {
            discountType = toggleSwitch.IsOn ? DiscountType.SingleDiscount : DiscountType.WholeDiscount;
        }
    }
}