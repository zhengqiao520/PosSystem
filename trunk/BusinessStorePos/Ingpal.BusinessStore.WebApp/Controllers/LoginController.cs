using Ingpal.BusinessStore.Infrastructure.Common;
using System;
using System.Web.Mvc;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.WebApp;
using Ingpal.BusinessStore.Infrastructure;

namespace NFine.Web.Controllers
{
    public class LoginController : Controller
    {
       private static SysBLL SysInstance = SysBLL.Instance;
       private Func<string, string, bool> WriteLog = (result, description) =>
        {
            var logEntity = new PartialLog { ModuleName = "系统登录", Type = LogType.BS.ToString() };
            logEntity.Result = result;
            logEntity.Description = description;
            return SysInstance.WriteLog(logEntity);
        };
        [HttpGet]
        public  ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        [HttpGet]
        public ActionResult OutLogin()
        {
            Session.Clear();
            Session.Abandon();
            WebHelper.RemoveCookie("loginTag");
            WriteLog(ResultType.success.ToString(), "安全退出系统");
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        [Ingpal.BusinessStore.WebApp.HandlerAjaxOnly]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    return Content(new AjaxResult { state = ResultType.error, message = "请输入用户名和密码！" }.ToJson());
                }

                if (Session["session_verifycode"] == null || VerifyCode.md5(code.ToLower(), 16) != Session["session_verifycode"].ToString())
                {
                    WriteLog(ResultType.error.ToString(), $"验证码错误");
                    return Content(new AjaxResult { state = ResultType.error, message = "验证码错误，请重新输入！" }.ToJson());
                }
                UserInfo.Instance.Account = username.Trim();
                var resultEntity = UserBLL.Instance.GetUserByLogin(UserInfo.Instance);
                if (resultEntity != null)
                {
                    var encrytPass = Encodetool.Md5(password.Trim());
                    if (encrytPass != resultEntity.Password)
                    {
                        WriteLog(ResultType.error.ToString(), "用户密码错误");
                        return Content(new AjaxResult { state = ResultType.error, message = "用户密码错误！" }.ToJson());
                    }
                    UserInfo.Instance = resultEntity;
                    UserInfo.Instance.UserRoles = SysBLL.Instance.GetUserRoles(resultEntity.ID);
                    WebHelper.WriteCookie("loginTag", Encodetool.Encrypt(UserInfo.Instance.ToJson()));
                    WriteLog(ResultType.success.ToString(), "登录成功");
                }
                else
                    return Content(new AjaxResult { state = ResultType.error.ToString(), message = "用户名或密码不正确！" }.ToJson());
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功！" }.ToJson());
            }
            catch (Exception ex)
            {
                WriteLog(ResultType.success.ToString(), $"登录失败！失败原因:{ex.Message}");
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}
