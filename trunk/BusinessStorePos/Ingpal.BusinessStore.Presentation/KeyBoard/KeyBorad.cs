using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ingpal.BusinessStore.Presentation.KeyBoard
{
    

    public partial class KeyBorad : DevExpress.XtraEditors.XtraUserControl
    {
        private bool IsUpper = false;

        /// <summary>
        /// 点击屏幕键盘事件
        /// </summary>
        public event KeyPressHandler PushKeyPress;

        public KeyBorad()
        {
            InitializeComponent();
        }

        private void btnCodes_Click(object sender, EventArgs e)
        {
            var btn = sender as SimpleButton;
            if (btn != null)
            {
                if (PushKeyPress != null)
                {
                    var chars = btn.Text.ToUpper().ToCharArray()[0];
                    var key = (Keys)chars;
                    PushKeyPress(key, btn.Text);
                }
            }

        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            IsUpper = !IsUpper;
            if (IsUpper)
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    var canUpper = bool.Parse(this.Controls[i].Tag==null ? "false": this.Controls[i].Tag.ToString());
                    if (canUpper)
                    {
                        this.Controls[i].Text = this.Controls[i].Text.ToUpper();
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    var canUpper = bool.Parse(this.Controls[i].Tag == null ? "false" : this.Controls[i].Tag.ToString());
                    if (canUpper)
                    {
                        this.Controls[i].Text = this.Controls[i].Text.ToLower();
                    }
                }
            }
        }
    }
}
