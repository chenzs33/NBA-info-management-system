using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBAHUPU.DAL;
using NBAHUPU.Model;

namespace NBAHUPU.BLL
{
     public class PlayerManager
    {
        private PlayerService dal = new PlayerService();

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Player model)
        {
            //首先判断号码是否已存在
            Player entity = dal.GetModel(model.PlayerNo);
            if (entity != null)
            {
                return -1;    //号码已存在
            }
            else
            {
                return dal.Add(model);
            }

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Player model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int PlayerNo)
        {
            return dal.Delete(PlayerNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Player GetModel(string PlayerNo)
        {
            return dal.GetModel(PlayerNo);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Player> GetList()
        {
            return dal.GetList();
        }

        public List<Player> GetList(int TeamID)
        {
            return dal.GetList(TeamID);
        }

        /// <summary>
        /// 根据条件模糊查询球员信息
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public List<Player> GetList(string key, string value)
        {
            return dal.GetList(key, value);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 根据球队号返回球员的分页数据
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="totalCount">记录总数</param>
        /// <param name="TeamID">球队编号</param>
        /// <returns></returns>
        public List<Player> GetList(int pageIndex, int pageSize, out int totalCount, int TeamID)
        {
            return dal.GetList(pageIndex, pageSize, out totalCount, TeamID);
        }


        #endregion  ExtensionMethod
    }
}
