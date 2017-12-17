namespace Ingpal.BusinessStore.Business
{
    using Ingpal.BusinessStore.Model;
    using Ingpal.BusinessStore.DataAccess;
    using System.Collections.Generic;

    public class UserBLL:BaseBLL
    {
        private UserBLL() { }
        public static readonly UserBLL Instance = new UserBLL();
        public UserInfo GetUserByLogin(UserInfo userInfo) {
            return UserDAL.GetUserByLogin(userInfo);
        }
        /// <summary>
        /// 获取门店用户信息
        /// </summary>
        /// <param name="storeID"></param>
        /// <returns></returns>
        public List<UserInfo> GetUsers(string storeID="")
        {
            return UserDAL.GetUsers(storeID);
        }

        /// <summary>
        /// UpdateUser
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpdateUser(UserEntity entity)
        {
            return UserDAL.UpdateUser(entity);
        }

        /// <summary>
        /// 查询非店长、系统管理员角色的用户
        /// </summary>
        /// <param name="storeID"></param>
        /// <returns></returns>
        public List<string> GetStoreUsers(string storeID = "")
        {
            return UserDAL.GetStoreUsers(storeID);
        }

        /// <summary>
        /// 删除用户及角色关联
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int DeleteUserAndRoleRelation(string userID)
        {
            return UserDAL.DeleteUserAndRoleRelation(userID);
        }
        public  int InsertUsersAndRoleRelation(UserEntity entity)
        {
            return UserDAL.InsertUsersAndRoleRelation(entity);

        }
    }
}
