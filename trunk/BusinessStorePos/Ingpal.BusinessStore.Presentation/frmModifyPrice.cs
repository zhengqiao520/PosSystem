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
    public partial class frmModifyPrice : BaseForm
    {
        private PosExt PosExt {
            get;set;
        }
        public delegate void ModifyPriceEventHander(PosExt posExit);
        public event ModifyPriceEventHander ModifyPriceEvent;
        public frmModifyPrice(PosExt posExt)
        {
            InitializeComponent();
            this.PosExt = posExt;
            this.txtRetail.Text = posExt.RetailPrice.ToString();
            this.Text = $"修改[{posExt.Name}]价格";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string txtPrice = txtDiscountPrice.EditValue == null ? "" : txtDiscountPrice.EditValue.ToString();
            if (string.IsNullOrEmpty(txtPrice))
            {
                ShowMessage("现价不能为空！");
                txtDiscountPrice.Focus();
                return;
            }
            else if (decimal.Parse(txtPrice) < 0)
            {
                ShowMessage("现价必须大于等于0");
                return;
            }
            else
            {
                PosExt.RetailPrice = decimal.Parse(txtPrice);
                ModifyPriceEvent(PosExt);

                string outBarID = string.Empty;
                decimal orginalPrice = 0.0m;
                var listGoodsBase=Ingpal.BusinessStore.Business.SysBLL.Instance.GetALL<GoodsBaseEntity>(where: $"barID='{PosExt.BarID}'");
                if (null != listGoodsBase && listGoodsBase.Count > 0) {
                    outBarID = listGoodsBase.FirstOrDefault().OuterBarID;
                    orginalPrice = listGoodsBase.FirstOrDefault().RetailPrice;
                }
                UserInfo userInfo = UserInfo.Instance;
                PriceChangeLog priceChangeLog = new PriceChangeLog();
                priceChangeLog.Account = userInfo.Account;
                priceChangeLog.StoreName = userInfo.StoreName;
                priceChangeLog.BarID = PosExt.BarID;
                priceChangeLog.GoodsName = PosExt.Name;
                priceChangeLog.OrginalPrice = orginalPrice;
                priceChangeLog.StoreID = userInfo.StoreID.ToString();
                priceChangeLog.RealPrice = decimal.Parse(txtPrice);
                priceChangeLog.IPAddress = Net.Ip;
                priceChangeLog.OutBarID = outBarID;
                priceChangeLog.Description = $"【{userInfo.StoreName}】门店用户,【{userInfo.Account}】于【{DateTime.Now.ToString()}】修改商品【{PosExt.Name}】零售价由原价【{priceChangeLog.OrginalPrice}】修改为【{priceChangeLog.RealPrice}】";
                Ingpal.BusinessStore.Business.SysBLL.Instance.Insert(priceChangeLog);
                Close();
            }
        }
    }
}