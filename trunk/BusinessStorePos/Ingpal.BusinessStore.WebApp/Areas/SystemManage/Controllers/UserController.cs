using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Infrastructure;
namespace Ingpal.BusinessStore.WebApp.Areas.SystemManage.Controllers
{
    public class UserController : BaseController
    {
        private SysBLL Sys = SysBLL.Instance;
        public override ActionResult Form()
        {
            ViewBag.Roles = Sys.GetBaseRole().Select(item => new { ID = item.ID, Name = item.RoleName }).ToJson();
            ViewBag.Stores = Sys.GetALL<StoreInfoEntity>().Select(item => new { ID = item.ID, Name = item.StoreName }).ToJson();
            return base.Form();
        }
        public ActionResult GetUserFormJson(string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                var json = Sys.GetALL<UserEntity>().Where(item => item.ID.ToString() == keyValue).FirstOrDefault();
                json.Birthday = json.Birthday <= DateTime.MinValue ? null : json.Birthday;
                if (null != json)
                {
                    return Content(json.ToJson());
                }
            }
            return Content(null);
        }
        public ActionResult SubmitForm(UserEntity entity, string keyValue)
        {
            PartialLog log = new PartialLog();
            if (string.IsNullOrEmpty(keyValue))
            {
                var existsRole = Sys.GetALL<UserEntity>().Where(item => item.Account == entity.Account || item.UserCode == entity.UserCode);
                if (existsRole.Count() > 0)
                {
                    return Error("用户账户已存在请修改后再试！");
                }
                else
                {
                    entity.ID = Guid.NewGuid();
                    entity.CreateDate = DateTime.Now;
                    if (entity.Password.Length < 6) {
                        return Error("用户密码长度不能低于6位！");
                    }
                    entity.Password = Infrastructure.Encodetool.Md5(entity.Password);
                    var res = UserBLL.Instance.InsertUsersAndRoleRelation(entity) > 0;
                    var description = res ? "新建用户成功" : "新建用户失败";
                    log.Description = $"新建：{entity.Account}信息.{description}";
                    log.ModuleName = "员工管理";
                    log.Result = res ? ResultType.success.ToString() : ResultType.error.ToString();
                    WriteLog(log);
                    if (res)
                    {
                        UpdateStoreEmpCount(entity.StoreID);
                    }
                    return res ? Success(description) : Error(description);
                }
            }
            else
            {
                var roleName = new List<string>();
                if (!string.IsNullOrEmpty(entity.RoleId))
                {
                    var roleids = entity.RoleId.Split(',');
                    var baseRoles = SysBLL.Instance.GetALL<BaseRoleEntity>();
                    roleids.ToList().ForEach(item =>
                    {
                        string name = baseRoles.Where(role => role.ID == item).Select(role => role.RoleName).FirstOrDefault();
                        roleName.Add(name);
                    });
                }
                entity.RoleName = string.Join(",", roleName);
                entity.ID = Guid.Parse(keyValue);
                var user = Sys.GetALL<UserEntity>().FirstOrDefault(k => k.ID == entity.ID);
                var storeID = user == null ? null : user.StoreID;
                if (entity.StoreID == null)
                {
                    entity.StoreID = -99999;
                }
                var pwdExist = Sys.GetALL<UserEntity>().Any(item => item.ID == entity.ID && item.Password == entity.Password);
                if (!pwdExist)
                {
                    entity.Password = Encodetool.Md5(entity.Password);
                }
                var res = Business.UserBLL.Instance.UpdateUser(entity) > 0;
                var description = res ? "更新用户信息成功" : "更新用户信息失败";
                log.Description = $"更新：{entity.Account}信息.{description}";
                log.ModuleName = "员工管理";
                log.Result = res ? ResultType.success.ToString() : ResultType.error.ToString();
                WriteLog(log);
                if (res)
                {
                    if (storeID != entity.StoreID)
                    {
                        UpdateStoreEmpCount(storeID);
                        UpdateStoreEmpCount(entity.StoreID);
                    }
                }
                return res ? Success(description) : Error(description);
            }
        }

        private void UpdateStoreEmpCount(int? storeID)
        {
            if (storeID.HasValue)
            {
                var store = Sys.GetBy<StoreInfoEntity>(q => q.ID == storeID);
                if (store.Any())
                {
                    var chkStore = store.FirstOrDefault();
                    var num = Sys.GetALL<UserEntity>().Count(s => s.StoreID == storeID);
                    chkStore.EmployCount = num;
                    Sys.UpdateByKey(chkStore);
                }
            }
        }

        public ActionResult DeleteForm(string keyValue)
        {
            PartialLog log = new PartialLog();
            var user = Sys.GetALL<UserEntity>().FirstOrDefault(k => k.ID.ToString() == keyValue);
            var storeID = user == null ? null : user.StoreID;
            var res = UserBLL.Instance.DeleteUserAndRoleRelation(keyValue) > 0;
            var description = res ? "删除成功" : "删除失败";
            log.Description = $"删除：{keyValue}.{description}";
            log.ModuleName = "员工管理";
            log.Result = res ? ResultType.success.ToString() : ResultType.error.ToString();
            WriteLog(log);
            if (res)
            {
                UpdateStoreEmpCount(storeID);
            }
            return res ? Success(description) : Error(description);
        }
        [HttpGet]
        public ActionResult RevisePassword()
        {
            return View();
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult SubmitRevisePassword(string userPassword, string keyValue)
        {
            var encryptPws = Infrastructure.Encodetool.Md5(userPassword);
            var res = SysBLL.Instance.UpdatePassword(Guid.Parse(keyValue), encryptPws);
            var description = res ? "重置密码成功" : "重置密码失败";
            WriteLog(new PartialLog
            {
                Description = UserInfo.Instance.Account + "修改密码",
                Result = res ? ResultType.success.ToString() : ResultType.error.ToString(),
                ModuleName = "系统设置"
            });
            return res ? Success(description) : Error(description);
        }
    }
}