using Ingpal.BusinessStore.DataAccess;
using Ingpal.BusinessStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingpal.BusinessStore.Business
{
    public class SysBLL : BaseBLL
    {
        public static readonly SysBLL Instance = new SysBLL();
        private SysBLL()
        {

        }
        /// <summary>
        /// 获取用户菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<SysModule> GetSysModule(string userId = "")
        {
            return SysDAL.GetSysModule(userId);
        }
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public List<BaseRoleEntity> GetBaseRole()
        {
            return SysDAL.GetBaseRole();
        }

        /// <summary>
        /// 查询系统时间
        /// </summary>
        /// <returns></returns>
        public string GetSysTime()
        {
            return SysDAL.GetSysTime();
        }

        /// <summary>
        /// 新建用户角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertBaseRole(BaseRoleEntity entity)
        {
            return SysDAL.InsertBaseRole(entity);
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="password">新密码</param>
        /// <returns></returns>
        public bool UpdatePassword(Guid userID, string password)
        {
            return SysDAL.UpdatePassword(userID, password);
        }

        public int CheckInsertUserRoleRelation(UserRoleRelationEntity entity)
        {
            return SysDAL.CheckInsertUserRoleRelation(entity);
        }

        public int UpDateUserRoleRelation(UserRoleRelationEntity entity)
        {
            return SysDAL.UpDateUserRoleRelation(entity);

        }
        /// <summary>
        /// 根据编号获取用户角色信息列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public  List<UserRoleRealationView> GetUserRoles(Guid userID)
        {
            return SysDAL.GetUserRoles(userID);
        }

        public  bool UpSertSysRoleAuthorize(string sysModuleIDs, string baseRoleID)
        {
            return SysDAL.UpSertSysRoleAuthorize(sysModuleIDs, baseRoleID);
        }

        public List<SysRoleAuthorizeEntity> GetRoleAuthorizeModules(string roleID)
        {
            return SysDAL.GetRoleAuthorizeModules(roleID);
        }
        /// <summary>
        /// 写入日志记录
        /// </summary>
        /// <param name="partialLog"></param>
        /// <returns></returns>
        public bool WriteLog(PartialLog partialLog)
        {
            return SysDAL.WriteLog(partialLog);
        }
        /// <summary>
        /// 同步商品清单
        /// </summary>
        /// <returns></returns>
        public  int SyncGoodsInfoFromERP()
        {
            return SysDAL.SyncGoodsInfoFromERP();
        }
    }
}
