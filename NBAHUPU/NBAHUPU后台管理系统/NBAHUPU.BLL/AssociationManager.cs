using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBAHUPU.DAL;
using NBAHUPU.Model;

namespace NBAHUPU.BLL
{
    public class AssociationManager
    {
        private AssociationService dal = new AssociationService();

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Association model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Association model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int AssociationId)
        {
            return dal.Delete(AssociationId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Association GetModel(int AssociationId)
        {
            return dal.GetModel(AssociationId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Association> GetList()
        {
            return dal.GetList();
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
