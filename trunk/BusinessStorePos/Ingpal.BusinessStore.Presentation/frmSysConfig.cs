using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ingpal.BusinessStore.Infrastructure;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Business;
using System.Diagnostics;

namespace Ingpal.BusinessStore.Presentation
{

    public partial class frmSysConfig : BaseForm
    {
        private string showCustomerDispaly = ConfigHelper.GetAppConfig("ShowCustomerDispay");

        public frmSysConfig()
        {

            InitializeComponent();
            this.Load += FrmSysConfig_Load;
            TopMost = true;

        }


        private void FrmSysConfig_Load(object sender, EventArgs e)
        {
            chkShowCustomerPlay.EditValue = (showCustomerDispaly.ToLower() == "true");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChanged_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPasswordNew.Text) || string.IsNullOrEmpty(txtPasswordConfirm.Text))
            {
                XtraMessageBox.Show("新密码不能为空！", "系统提示");
                txtPasswordNew.Focus();
                return;
            }
            if (txtPasswordNew.Text.Length < 6) {
                XtraMessageBox.Show("密码长度不能少于6位！", "系统提示");
                txtPasswordNew.Focus();
                return;
            }
            if (txtPassordOld.Text == txtPasswordNew.Text)
            {
                XtraMessageBox.Show("原密码与新密码不能是同一个密码，请重新输入！", "系统提示");
                txtPasswordNew.Text = string.Empty;
                txtPasswordNew.Focus();
                return;
            }

            if (txtPasswordNew.Text != txtPasswordConfirm.Text)
            {
                XtraMessageBox.Show("两次输入的新密码不一致，请重新输入！", "系统提示");
                txtPasswordNew.Text = string.Empty;
                txtPasswordConfirm.Text = string.Empty;
                txtPasswordNew.Focus();
                return;
            }

            var account = UserInfo.Instance.Account;
            var oldPassorw = UserInfo.Instance.Password;
            if (oldPassorw == Encodetool.Md5(txtPassordOld.Text.Trim()))
            {
               var result= SysBLL.Instance.UpdatePassword(UserInfo.Instance.ID, Encodetool.Md5(txtPasswordNew.Text.Trim()));
                if (result)
                {
                    if (XtraMessageBox.Show("修改密码成功！是否重启系统重新登录？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Application.Exit();
                        Process.Start(Application.ExecutablePath);
                    }
                }
                else
                {
                    XtraMessageBox.Show("修改密码失败！", "系统提示");
                }              
            }
            else
            {
                XtraMessageBox.Show("原密码错误，请重新输入！", "系统提示");
                txtPassordOld.Text = string.Empty;
                txtPassordOld.Focus();
                return;
            }

        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowCustomerPlay_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = chkShowCustomerPlay.Checked;
            CustomerDispalyControl(isChecked);
            ConfigHelper.UpdateAppConfig("ShowCustomerDispay", isChecked.ToString());
        }
    }


   
}