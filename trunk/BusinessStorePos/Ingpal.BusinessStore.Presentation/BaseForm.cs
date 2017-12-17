using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraGrid;
using Ingpal.BusinessStore.Infrastructure.Win32;
using Ingpal.BusinessStore.Infrastructure;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Business;
namespace Ingpal.BusinessStore.Presentation
{
    public class BaseForm:XtraForm
    {

        //private static frmCustomer _frmCustomer = new Presentation.frmCustomer();
        public BaseForm()
        {
            this.Load += LoadForm;
            this.FormClosed += FormClose;
        }
        /// <summary>
        /// 关闭系统
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="postBack">回调函数</param>
        protected void AskExit(string msg="",Action postBack=null) {
            if (XtraMessageBox.Show(string.IsNullOrEmpty(msg)? "您确认要退出系统吗":msg,"系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
                if (postBack != null)
                {
                    postBack.Invoke();
                }
                WriteLog(new PartialLog
                {
                    Description = "安全退出系统",
                    ModuleName = "系统登录",
                    Result = ResultType.success.ToString(),
                    Type = LogType.CS.ToString()
                });
            }
        }
        protected virtual void BaseInit() {
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
        }
        protected virtual void OnCloseAnimat(XtraForm fm=null)
        {
            WinAPI.AnimateWindow(fm==null?Handle:fm.Handle, 500, WinAPI.AW_CENTER | WinAPI.AW_HIDE);
        }
        protected virtual void OnStartAnimat(XtraForm fm = null)
        {
            WinAPI.AnimateWindow(fm == null ? Handle : fm.Handle, 500, WinAPI.AW_HOR_POSITIVE);
        }
        protected virtual void LoadForm(object sender, EventArgs e)
        {
            OnStartAnimat();
        }
        protected virtual void FormClose(object sender, EventArgs e) {
            OnCloseAnimat();
        }
        protected virtual DialogResult ShowMessage(string msg,string tile="系统提示",MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon ico = MessageBoxIcon.Information) {
           return   XtraMessageBox.Show(msg, tile, buttons, ico);
        }
        /// <summary>
        /// 重写WndProc方法,实现窗体移动和禁止双击最大化
        /// </summary>
        /// <param name="m">Windows 消息</param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x4e:
                case 0xd:
                case 0xe:
                case 0x14:
                    base.WndProc(ref m);
                    break;
                case 0x84://鼠标点任意位置后可以拖动窗体
                    this.DefWndProc(ref m);
                    if (m.Result.ToInt32() == 0x01)
                    {
                        m.Result = new IntPtr(0x02);
                    }
                    break;
                case 0xA3://禁止双击最大化
                    break;
                default:
      base.WndProc(ref m);
                    break;
            }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(391, 332);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }

        public bool IsShopManager {
           get
            {
                return Model.UserInfo.Instance.IsShopManager;
            }
        }

        public bool WriteLog(PartialLog partialLog)
        {
            var logEntity = new PartialLog { ModuleName = "前台登录", Type = LogType.CS.ToString() };
            logEntity.ModuleName = partialLog.ModuleName;
            logEntity.Result = partialLog.Result;
            logEntity.Description = partialLog.Description;
            return SysBLL.Instance.WriteLog(logEntity);
        }
        public bool ShowCustomerDispaly {
            get
            {
                return bool.Parse(ConfigHelper.GetAppConfig("ShowCustomerDispay"));
            }
        }
        public void CustomerDispalyControl(bool showForm=true)
        {
            frmCustomer _frmCustomer = new frmCustomer();
            if (_frmCustomer.IsDisposed)
            {
                _frmCustomer = new frmCustomer();
                _frmCustomer.Show();
            }
            else
            {
                _frmCustomer.WindowState = FormWindowState.Maximized;
                if (showForm)
                {
                    _frmCustomer.Show();
                }
                else
                {
                    if (!_frmCustomer.IsDisposed|| _frmCustomer != null)
                    {
                        _frmCustomer.Hide();
                    }
                }
            }
        }
    }
}
