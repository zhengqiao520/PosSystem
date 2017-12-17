using System.Text;
using System.Threading.Tasks;
using Ingpal.BusinessStore.Infrastructure;
using Ingpal.BusinessStore.Model;
using System.Collections.Generic;
using System;

namespace Ingpal.BusinessStore.DataAccess
{
   public class SysDAL:BaseDAL
    {
        /// <summary>
        /// 获取系统菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<SysModule> GetSysModule(string userId="")
        {
            return utity.ExecuteListSp<SysModule>("usp_GetSysModule", new object[] { userId });
        }
        /// <summary>
        /// 获取所有用户角色
        /// </summary>
        /// <returns></returns>
        public static List<BaseRoleEntity> GetBaseRole()
        {
            return utity.GetAll<BaseRoleEntity>();
        }

        /// <summary>
        /// 查询系统时间
        /// </summary>
        /// <returns></returns>
        public static string GetSysTime()
        {
            return (utity.ExecuteScalarSp("usp_GetSysTime", null)??"").ToString();
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="password">新密码</param>
        /// <returns></returns>
        public static bool UpdatePassword(Guid userID, string password)
        {
            try
            {
                utity.ExecuteNonQuerySp("usp_UpdatePassword", new object[] { userID, password });
                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新建用户角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool InsertBaseRole(BaseRoleEntity entity) {
            return utity.ExecuteNonQuerySp("usp_InsertBaseRole",new object[] {
                  entity.ID,
                  entity.RoleCode,
                  entity.RoleName,
                  entity.StoreID,
                  entity.IsBackstage,
                  entity.SortCode,
                  entity.Description,
                  entity.RecordStatus
            }) > 0;
        }
        /// <summary>
        /// 插入用户角色关联信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int CheckInsertUserRoleRelation(UserRoleRelationEntity entity)
        {
          return   utity.ExecuteNonQuerySp("usp_InsertUserRoleRelation", new object[] {
                entity.ID,
                entity.UserID,
                entity.RoleType,
                entity.BaseRoleID,
                entity.RecordStatus
            });
        }

        public static int UpDateUserRoleRelation(UserRoleRelationEntity entity) {
            return utity.ExecuteNonQuerySp("usp_UpDateUserRoleRelation", new object[] {
                  entity.ID,
                entity.UserID,
                entity.RoleType,
                entity.BaseRoleID,
                entity.RecordStatus
            });
        }
        public static List<UserRoleRealationView> GetUserRoles(Guid userID)
        {
            return utity.ExecuteListSp<UserRoleRealationView>("usp_GetUserRoles", new object[] { userID });
        }
        public static bool UpSertSysRoleAuthorize(string sysModuleIDs,string baseRoleID)
        {
            return utity.ExecuteNonQuerySp("usp_UpSertSysRoleAuthorize", new object[] { sysModuleIDs, baseRoleID }) > 0;
        }
        public static List<SysRoleAuthorizeEntity> GetRoleAuthorizeModules(string roleID)
        {
            return utity.ExecuteListSp<SysRoleAuthorizeEntity>("usp_GetSysRoleAuthorize", new object[] { roleID });
        }
        public static bool WriteLog(PartialLog partialLog)
        {
            SysLog log = new SysLog();
            log.Account = UserInfo.Instance.Account;
            log.LogDate = DateTime.Now;
            log.IPAddress = Net.Ip;
            log.RealName = UserInfo.Instance.RealName;
            log.Type = partialLog.Type;
            log.Result = partialLog.Result;
            log.Description = partialLog.Description;
            log.IPAddressName = Net.GetLocation(log.IPAddress);
            log.ModuleName = partialLog.ModuleName;
            log.ModuleId = partialLog.ModuleId;
            log.StoreID = UserInfo.Instance.StoreID.ToString();
            return Insert(log);
        }
        /// <summary>
        /// 同步商品清单
        /// </summary>
        /// <returns></returns>
        public static int SyncGoodsInfoFromERP()
        {
            return utity.ExecuteNonQuerySp("SyncGoodsInfoFromERP", new object[] { });
        }

    }
}