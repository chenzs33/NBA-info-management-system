using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBAHUPU.Model;

namespace NBAHUPU.DAL
{
    public class DivisionService
    {
        #region  BasicMethod

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Division model)
        {
            string sql = "insert into Division(DivisionName,AssociationId) values(@DivisionName,@AssociationId)";

            SqlParameter[] parameters = {
                    new SqlParameter("@DivisionName", model.DivisionName),
                    new SqlParameter("@AssociationId",model.AssociationId)
            };

            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Division model)
        {
            string sql = "update Division set DivisionName=@DivisionName,AssociationId=@AssociationId where DivisionId=@DivisionId ";

            SqlParameter[] parameters = {
                    new SqlParameter("@DivisionName", model.DivisionName),
                    new SqlParameter("@AssociationId", model.AssociationId),
                    new SqlParameter("@DivisionId",model.DivisionId)
            };

            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int DivisionId)
        {
            string sql = "delete Division where DivisionId=@DivisionId";
            SqlParameter[] parameters = {
                    new SqlParameter("@DivisionId", DivisionId)
            };

            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Division GetModel(int DivisionId)
        {
            string sql = "select * from Division where DivisionId=@DivisionId";

            SqlParameter[] parameters = {
                    new SqlParameter("@DivisionId", DivisionId)
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
        public Division DataRowToModel(DataRow row)
        {
            Division model = new Division();
            if (row != null)
            {
                if (row["DivisionId"] != null && row["DivisionId"].ToString() != "")
                {
                    model.DivisionId = Convert.ToInt32(row["DivisionId"]);
                }
                if (row["DivisionName"] != null)
                {
                    model.DivisionName = row["DivisionName"].ToString();
                }
                if (row["AssociationId"] != null && row["AssociationId"].ToString() != "")
                {
                    model.AssociationId = Convert.ToInt32(row["AssociationId"]);
                }
            }
            return model;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Division> GetList()
        {
            string sql = "select * from Division";
            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, null);
            DataTable dt = ds.Tables[0];
            List<Division> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Division>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(DataRowToModel(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 根据联盟Id获取赛区列表
        /// </summary>
        /// <param name="AssociationId">联盟Id</param>
        /// <returns></returns>
        public List<Division> GetList(int AssociationId)
        {
            string sql = "select * from Division where AssociationId = @AssociationId";
            SqlParameter[] parameters = {
                    new SqlParameter("@AssociationId", AssociationId)
            };
            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, parameters);
            DataTable dt = ds.Tables[0];
            List<Division> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Division>();
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