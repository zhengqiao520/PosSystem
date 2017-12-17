using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using Ingpal.BusinessStore.Business;
namespace Ingpal.BusinessStore.Presentation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                SkinManager.EnableFormSkins();
                UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmLogon());
            }
            catch (Exception ee)
            {
                SysBLL.Instance.WriteLog(new Model.PartialLog() { Description= ee.Message, ModuleName="系统全局", Result=Model.ResultType.error.ToString(), Type=Model.LogType.CS.ToString() });
                MessageBox.Show("系统异常："+ee.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }       
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exceptionMsg = (e.ExceptionObject as Exception).Message;
            SysBLL.Instance.WriteLog(new Model.PartialLog() { Description = exceptionMsg, ModuleName = "非窗体线程", Result = Model.ResultType.error.ToString(), Type = Model.LogType.CS.ToString() });
            MessageBox.Show(exceptionMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            SysBLL.Instance.WriteLog(new Model.PartialLog() { Description = e.Exception.Message, ModuleName = "窗体线程", Result = Model.ResultType.error.ToString(), Type = Model.LogType.CS.ToString() });
            MessageBox.Show(e.Exception.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
