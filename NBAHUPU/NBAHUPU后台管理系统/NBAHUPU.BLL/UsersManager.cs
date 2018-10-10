using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBAHUPU.DAL;
using NBAHUPU.Model;

namespace NBAHUPU.BLL
{
    public class UsersManager
    {
        private UsersService dal = new UsersService();

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Users model)
        {
            //首先判断用户名是否已存在
            Users entity = dal.GetModel(model.UserName);
            if (entity != null)
            {
                return -1;    //用户名已存在
            }
            else
            {
                return dal.Add(model);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Users model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int userId)
        {
            return dal.Delete(userId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Users GetModel(int userId)
        {
            return dal.GetModel(userId);
        }

        public Users GetModel(string userName)
        {
            return dal.GetModel(userName);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Users> GetList()
        {
            return dal.GetList();
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 用户登录检查
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <returns>实体对象或null</returns>
        public Users Login(string userName, string userPwd)
        {
            Users model = dal.GetModel(userName);
            if (model != null)
            {
                if (userPwd == model.UserPwd)
                {
                    return model;
                }
            }
            return null;
        }


        #endregion  ExtensionMethod
    }
}
