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
using Ingpal.BusinessStore.Business;

namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmExchangePrice : DevExpress.XtraEditors.XtraForm
    {
        public delegate void ExchangePriceHander(GoodsGrantExt goodsGrantExt);
        public event ExchangePriceHander ExchangeEvent;
        public frmExchangePrice()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<GoodsGrantExt> GetExchangePriceList()
        {
            return  GoodsBLL.instance.GetValidExchangePrice((int)UserInfo.Instance.StoreID);
        }

        private void frmExchangePrice_Load(object sender, EventArgs e)
        {
            grdExchangeGoods.DataSource = GetExchangePriceList();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (gvExchangeGoods.GetFocusedRow()==null) {

                MessageBox.Show("没有可选择的商品", "系统提示");
                return;
            }
            if (XtraMessageBox.Show("您确认要选择该换购商品吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var selectRow = gvExchangeGoods.GetFocusedRow() as GoodsGrantExt;
                ExchangeEvent(selectRow);
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}