using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBAHUPU.DAL;
using NBAHUPU.Model;

namespace NBAHUPU.BLL
{
    public class DivisionManager
    {
        private DivisionService dal = new DivisionService();

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Division model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Division model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int DivisionId)
        {
            return dal.Delete(DivisionId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Division GetModel(int DivisionId)
        {
            return dal.GetModel(DivisionId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Division> GetList()
        {
            return dal.GetList();
        }

        public List<Division> GetList(int AssociationId)
        {
            return dal.GetList(AssociationId);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
