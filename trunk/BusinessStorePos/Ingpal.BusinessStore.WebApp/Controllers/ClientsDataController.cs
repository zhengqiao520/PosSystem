using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Business;
using System.Text;
using Ingpal.BusinessStore.WebApp.App_Start;

namespace Ingpal.BusinessStore.WebApp.Controllers
{
    [HandlerLogin]
    public class ClientsDataController : BaseController
    {
        public ActionResult GetClientsDataJson() {
            var data = new
            {
                sysModule ="",
                storeInfo = GetStoreList(),
                role = GetRoleInfo(),
                duty = "",
                userList = GetUserInfo(),
                authorizeMenu = GetSysModule(UserInfo.Instance.ID.ToString()),
                authorizeButton = "",
            };
            return Content(data.ToJson());
        }
        public List<StoreInfoEntity> GetStoreList()
        {
            return StoreBLL.Instance.GetAllStore();
        }
        private object GetSysModule(string uid)
        {
            return ToMenuJson(SysBLL.Instance.GetSysModule(uid), "0");
        }
        private string ToMenuJson(List<SysModule> data, string parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            List<SysModule> entitys = data.FindAll(t => t.ParentId == parentId);
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson = item.ToJson();
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.ID) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }
        public List<BaseRoleEntity> GetRoleInfo()
        {
            return SysBLL.Instance.GetALL<BaseRoleEntity>();
        }
        public List<UserInfo> GetUserInfo()
        {
            return UserBLL.Instance.GetUsers();
        }
        public ActionResult GetUsers(Pagination pagination)
        {
            var userList = GetUserInfo().OrderBy(item => item.StoreName).ToList();
            if (!string.IsNullOrEmpty(pagination.keyword))
            {
                var searchKey = pagination.keyword;
                userList = userList.Where(item => item.RealName.Contains(searchKey) || item.Account.Contains(searchKey) || item.UserCode.Contains(searchKey)).ToList();
            }

            var list = userList.OrderBy(item => item.StoreID).ToList();
            return Content(GetPagingJson(list,pagination));
        }

       
    }
}