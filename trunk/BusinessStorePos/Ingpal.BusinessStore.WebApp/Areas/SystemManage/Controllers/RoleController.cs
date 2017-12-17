using Ingpal.BusinessStore.WebApp.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingpal.BusinessStore.Business;
using Ingpal.BusinessStore.Model;
namespace Ingpal.BusinessStore.WebApp.Areas.SystemManage.Controllers
{
    public class RoleController : BaseController
    {
        public List<Model.BaseRoleEntity> RoleList {
            get
            {
                return Business.SysBLL.Instance.GetBaseRole();
            }
        }
        public override ActionResult Index()
        {
            ViewBag.Roles = GetRoles();
            return base.Index();
        }
        public ActionResult GetRoles()
        {
            return Json(RoleList);
        }
        public ActionResult GetRoleFormJson(string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                var json = RoleList.Where(item => item.ID == keyValue).First().ToJson();
                return Content(json);
            }
            return Content(RoleList.ToJson());
        }
        /// <summary>
        /// 新增或修改角色
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult SubmitForm(Model.BaseRoleEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                var existsRole = RoleList.Where(item => item.RoleCode == entity.RoleCode || item.RoleName == entity.RoleName);
                if (existsRole.Count() > 0)
                {
                    return Error("角色名称或编码已存在，请修改后再试！");
                }
                else
                {
                    entity.ID = Guid.NewGuid().ToString();
                    var res = Business.SysBLL.Instance.InsertBaseRole(entity);
                    if (!string.IsNullOrEmpty(entity.PermissionIds))
                    {
                        SysBLL.Instance.UpSertSysRoleAuthorize(entity.PermissionIds, entity.ID);
                    }
                    return res ? Success("新建角色成功！") : Error("新建角色失败！");
                }
            }
            else
            {
                entity.ID = keyValue;
                var res=Business.SysBLL.Instance.UpdateByKey(entity);
                if (!string.IsNullOrEmpty(entity.PermissionIds))
                {
                  var result= SysBLL.Instance.UpSertSysRoleAuthorize(entity.PermissionIds, keyValue);
                }
                return res ? Success("更新成功！") : Error("更新失败！");
            }
        }

        public ActionResult DeleteForm(string keyValue)
        {
            SysBLL.Instance.DeleteByWhere<SysModuleEntity>($"BaseRoleID='{keyValue}'");
            var res = SysBLL.Instance.DeteleByKey<BaseRoleEntity>(keyValue);
            return res ? Success("删除成功！") : Error("删除失败！");
        }

        public ActionResult GetPermissionTree(string roleId)
        {
            var sysModules = SysBLL.Instance.GetALL<SysModuleEntity>();

            var authorizedata = new List<SysRoleAuthorizeEntity>();
            if (!string.IsNullOrEmpty(roleId))
            {
                authorizedata = SysBLL.Instance.GetRoleAuthorizeModules(roleId);
            }
            var treeList = new List<TreeViewModel>();
            foreach (var item in sysModules)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = sysModules.Count(t => t.ParentId == item.ID) == 0 ? false : true;
                tree.id = item.ID;
                tree.text = item.FullName;
                tree.value = item.EnCode;
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = authorizedata.Count(t => t.SysModuleID == item.ID);
                tree.hasChildren = hasChildren;
                tree.img = item.Icon == "" ? "" : item.Icon;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }
    }
}