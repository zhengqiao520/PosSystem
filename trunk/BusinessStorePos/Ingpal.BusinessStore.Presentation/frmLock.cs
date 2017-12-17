using DevExpress.XtraEditors;
using Ingpal.BusinessStore.Infrastructure;
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
using System.IO;
namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmLock : BaseForm
    {
        public frmLock()
        {
            InitializeComponent();
            this.Load += FrmLock_Load;
            TopMost = true;
        }

        private void FrmLock_Load(object sender, EventArgs e)
        {

        }

        private void frmLock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UserInfo.Instance.Password == Encodetool.Md5(txtPassword.Text.Trim()))
            {
                e.Cancel = false;
            }
            else
            {
                if (XtraMessageBox.Show("您确定要退出收银系统吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    Application.ExitThread();
                }
                else
                {
                    e.Cancel = true;
                }
                   
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword_ButtonClick(null, null);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLock_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bitmap = global::Ingpal.BusinessStore.Presentation.Properties.Resources.bg;
            Graphics g = Graphics.FromImage(bitmap);
            Font ft = new Font("微软雅黑", 36, FontStyle.Bold);
            SizeF sizf = g.MeasureString(UserInfo.Instance.RealName, ft);
            var latterWidth = sizf.Width / 2;
            PointF fp = new PointF(Width / 2- latterWidth, Height / 2 - 100);
            g.DrawString(UserInfo.Instance.RealName, ft, Brushes.White, fp);
            pictureBox1.Image = bitmap;
            txtPassword.Location = new Point((Width / 2-txtPassword.Width/2), Height / 2);
        }

        private void txtPassword_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (UserInfo.Instance.Password == Encodetool.Md5(txtPassword.Text.Trim()))
            {
                this.Close();
            }
            else
            {
                ShowMessage("用户密码错误！");
            }
        }
    }
}
