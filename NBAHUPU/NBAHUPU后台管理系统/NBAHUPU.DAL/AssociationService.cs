using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBAHUPU.Model;

namespace NBAHUPU.DAL
{
    public class AssociationService
    {
        #region  BasicMethod

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Association model)
        {
            string sql = "insert into Association(AssociationName) values(@AssociationName)";

            SqlParameter[] parameters = {
                    new SqlParameter("@AssociationName", model.AssociationName),
            };

            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Association model)
        {
            string sql = "update Association set AssociationName=@AssociationName where AssociationId=@AssociationId ";

            SqlParameter[] parameters = {
                    new SqlParameter("@AssociationName", model.AssociationName),
                    new SqlParameter("@AssociationId", model.AssociationId)
            };

            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int AssociationId)
        {
            string sql = "delete Association where AssociationId=@AssociationId";
            SqlParameter[] parameters = {
                    new SqlParameter("@AssociationId", AssociationId)
            };

            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Association GetModel(int AssociationId)
        {
            string sql = "select * from Association where AssociationId=@AssociationId";

            SqlParameter[] parameters = {
                    new SqlParameter("@AssociationId", AssociationId)
            };

            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 将数据集表中的行转换为对象
        /// <summary>
        /// 将数据集表中的行转换为对象
        /// </summary>
        public Association DataRowToModel(DataRow row)
        {
            Association model = new Association();
            if (row != null)
            {
                if (row["AssociationId"] != null && row["AssociationId"].ToString() != "")
                {
                    model.AssociationId = Convert.ToInt32(row["AssociationId"]);
                }
                if (row["AssociationName"] != null)
                {
                    model.AssociationName = row["AssociationName"].ToString();
                }
            }
            return model;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Association> GetList()
        {
            string sql = "select * from Association";
            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, null);
            DataTable dt = ds.Tables[0];
            List<Association> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Association>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(DataRowToModel(dr));
                }
            }
            return list;
        }
        #endregion

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}