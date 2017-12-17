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
using Ingpal.BusinessStore.Model.Entity;
using Ingpal.BusinessStore.Infrastructure;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace Ingpal.BusinessStore.Presentation
{
    public partial class frmLogon : BaseForm
    {
        #region 构造函数
        public frmLogon()
        {
            InitializeComponent();
        }
        #endregion

        #region 登录登出方法
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            var msg = string.Empty;
            UserInfo.Instance.Account = txtUserCode.Text.Trim();
            if (string.IsNullOrEmpty(txtUserCode.Text.Trim())) {
                msg = "请输入用户名和密码";
                ShowMessage(msg);
                return;
            }
            var resultEntity = UserBLL.Instance.GetUserByLogin(UserInfo.Instance);
            if (resultEntity == null)
            {
                msg = "该用户不存在，请重新输入！";
                ShowMessage(msg);
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(resultEntity.StoreName ?? ""))
                {
                    msg = "用户未指定所属门店，无法登录系统！";
                    WriteLog(new PartialLog { Description = msg, Result = ResultType.error.ToString(), ModuleName = "前台登录", Type = LogType.CS.ToString() });
                    ShowMessage(msg);
                    return;
                }
                var checkStore = SysBLL.Instance.GetBy<StoreInfoEntity>(item => item.ID == resultEntity.StoreID);
                if (checkStore == null)
                {
                    msg = $"用户所属门店编号：{resultEntity.StoreID}不存在！";
                    ShowMessage(msg);
                    return;
                }
                var encrytPass = Encodetool.Md5(txtPassword.Text.Trim());
                if (resultEntity.Password.Equals(encrytPass))
                {
                    UserInfo.Instance = resultEntity;
                    UserInfo.Instance.UserRoles = SysBLL.Instance.GetUserRoles(resultEntity.ID);
                    new frmMain().Show();
                    if (ShowCustomerDispaly)
                    {
                        CustomerDispalyControl();
                    }
                    OnCloseAnimat();
                    WriteLog(new PartialLog { Description="登录成功", Result=ResultType.success.ToString(), ModuleName="前台登录", Type= LogType.CS.ToString() });
                    return;
                }
                WriteLog(new PartialLog { Description = msg, Result = ResultType.error.ToString(), ModuleName = "前台登录", Type = LogType.CS.ToString() });
                msg = "用户密码错误，请重新输入!";
                ShowMessage(msg);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                lblLogin_Click(sender, new EventArgs());
            }
        }
        #endregion
    }
}
