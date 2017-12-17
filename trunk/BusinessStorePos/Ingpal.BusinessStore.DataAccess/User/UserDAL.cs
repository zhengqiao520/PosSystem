using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingpal.BusinessStore.Model;
using Ingpal.BusinessStore.Infrastructure.DB;
using Ingpal.BusinessStore.Infrastructure;
using System.Data.Common;
namespace Ingpal.BusinessStore.DataAccess
{
    public class UserDAL
    {
        private static readonly DBUtility utity = new DBUtility();
        public static UserInfo GetUserByLogin(UserInfo userInfo)
        {
            var result = utity.ExecuteListSp<UserInfo>("usp_UserLogin", new object[] { userInfo.Account });
            return result?.FirstOrDefault();
        }
        /// <summary>
        /// 获取门店用户
        /// </summary>
        /// <param name="storeID"></param>
        /// <returns></returns>
        public static List<UserInfo> GetUsers(string storeID = "")
        {
            return utity.ExecuteListSp<UserInfo>("usp_GetUsers", new object[] { storeID });
        }

        public static int UpdateUser(UserEntity user)
        {
            try
            {
                return utity.ExecuteNonQuerySp("usp_UpdateUser", new object[]
            {
                user.ID,
                user.StoreID,
                user.Password,
                user.RealName,
                user.UserCode,
                user.HeadIcon,
                user.Gender,
                user.Birthday,
                user.Telephone,
                user.Email,
                user.RoleId,
                user.RoleName,
                user.PostId,
                user.PostName,
                user.IsAdmin,
                user.SortCode,
                user.RecordStatus,
                user.Description
            });
            }
            catch (Exception ex)
            {

                return 0;
            }

        }

        /// <summary>
        /// 查询非店长、系统管理员角色的用户
        /// </summary>
        /// <param name="storeID"></param>
        /// <returns></returns>
        public static List<string> GetStoreUsers(string storeID = "")
        {
            return utity.ExecuteListSp<string>("usp_GetStoreUser", new object[] { storeID });
        }
        public static int DeleteUserAndRoleRelation(string userID)
        {
            var res = 0;
            using (DbTransaction tran = utity.Transation)
            {
                res = utity.ExecuteNonQuerySp(tran, "usp_DeleteUserAndRoleRelation", new object[] { Guid.Parse(userID) });
                if (res > 0)
                {
                    tran.Commit();
                }
                else
                {
                    tran.Rollback();
                }
            }
            return res;
        }
        public static int InsertUsersAndRoleRelation(UserEntity entity)
        {
            return utity.ExecuteNonQuerySp("usp_InsertUsersAndRoleRelation", new object[] {
                entity.ID,
                entity.StoreID,
                entity.Account,
                entity.Password,
                entity.RealName,
                entity.UserCode,
                entity.HeadIcon,
                entity.Gender,
                entity.Birthday,
                entity.Telephone,
                entity.Email,
                entity.RoleId,
                entity.RoleName,
                entity.PostId,
                entity.PostName,
                entity.IsAdmin,
                entity.LastVisit,
                entity.LogOnCount,
                entity.SortCode,
                entity.RecordStatus,entity.Description,
                entity.CreateDate
            });
        }
    }
}
