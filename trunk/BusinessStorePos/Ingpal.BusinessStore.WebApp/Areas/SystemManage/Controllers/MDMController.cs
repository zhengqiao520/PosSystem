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
    public class MDMController : BaseController
    {
        public ActionResult GetTreeJson()
        {
            var data = SysBLL.Instance.GetALL<MDMTypeEntity>();
            var treeList = new List<TreeViewModel>();
            foreach (var item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.ParentID == item.ID) == 0 ? false : true;
                tree.id = item.ID.ToString();
                tree.text = item.TypeName;
                tree.value = item.TypeValue;
                tree.parentId = item.ParentID.ToString();
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }
        public ActionResult GetFormJson(string keyValue)
        {
            var res = SysBLL.Instance.GetBy<MDMTypeSubEntity>(item => item.ID == int.Parse(keyValue));
            if (res != null)
            {
                return Content(res.FirstOrDefault().ToJson());
            }
            return null;
        }
        public ActionResult GetGridJson(string MDMTypeID)
        {
            var res=SysBLL.Instance.GetBy<MDMTypeSubEntity>(item => item.MDMTypeID == int.Parse(MDMTypeID));
            return Content(res.ToJson());
        }
        public ActionResult DeleteForm(string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                return Error("删除失败，未获取到主键！");
            }
            var res=SysBLL.Instance.DeteleByKey<MDMTypeSubEntity>(keyValue);
            return res ? Success("删除成功！") : Error("删除失败!");
        }
        public ActionResult SubmitForm(MDMTypeSubEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                var chekList=SysBLL.Instance.GetBy<MDMTypeSubEntity>(item => item.SubValue == entity.SubValue && item.SubName == entity.SubName);
                if (chekList.Count() > 0) {
                    return Error("主数据名称或内容已存在，请修改后试！");
                }
                var res = Business.SysBLL.Instance.Insert(entity);
                return res ? Success("新建主数据成功！") : Error("新建主数据失败！");
            }
            else
            {
                entity.ID = int.Parse(keyValue);
                var res = Business.SysBLL.Instance.UpdateByKey(entity);
                return res ? Success("更新成功！") : Error("更新失败！");
            }
        }
    }
}