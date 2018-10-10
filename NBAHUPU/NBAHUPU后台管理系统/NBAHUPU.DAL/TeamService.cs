using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBAHUPU.Model;

namespace NBAHUPU.DAL
{
    public class TeamService
    {

        #region  BasicMethod


        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Team model)
        {
            string sql = "insert into Team(TeamName,TeamSize,DivisionId) values(@TeamName,@TeamSize,@DivisionId)";

            SqlParameter[] parameters = {
                    new SqlParameter("@TeamName", model.TeamName),
                    new SqlParameter("@TeamSize", model.TeamSize),
                    new SqlParameter("@DivisionId",model.DivisionId)
            };

            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Team model)
        {
            string sql = "update Team set TeamName=@TeamName, TeamSize = @TeamSize,DivisionId=@DivisionId where TeamID=@TeamID ";

            SqlParameter[] parameters = {
                    new SqlParameter("@TeamName", model.TeamName),
                    new SqlParameter("@TeamSize", model.TeamSize),
                    new SqlParameter("@TeamID", model.TeamId),
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
        public int Delete(int TeamID)
        {
            string sql = "delete Team where TeamID=@TeamID";
            SqlParameter[] parameters = {
                    new SqlParameter("@TeamID", TeamID)
            };

            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Team GetModel(int TeamID)
        {
            string sql = "select * from Team where TeamID=@TeamID";

            SqlParameter[] parameters = {
                    new SqlParameter("@TeamID", TeamID)
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
        public Team DataRowToModel(DataRow row)
        {
            Team model = new Team();
            if (row != null)
            {
                if (row["TeamId"] != null && row["TeamID"].ToString() != "")
                {
                    model.TeamId = Convert.ToInt32(row["TeamId"]);
                }
                if (row["TeamName"] != null)
                {
                    model.TeamName = row["TeamName"].ToString();
                }
                if (row["TeamSize"] != null && row["TeamSize"].ToString() != "")
                {
                    model.TeamSize = Convert.ToInt32(row["TeamSize"]);
                }
                if (row["DivisionId"] != null && row["DivisionId"].ToString() != "")
                {
                    model.DivisionId = Convert.ToInt32(row["DivisionId"]);
                }
            }
            return model;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Team> GetList()
        {
            string sql = "select * from Team";
            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, null);
            DataTable dt = ds.Tables[0];
            List<Team> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Team>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(DataRowToModel(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 根据赛区Id获取球队列表
        /// </summary>
        /// <param name="AssociationId">赛区Id</param>
        /// <returns></returns>
        public List<Team> GetList(int DivisionId)
        {
            string sql = "select * from Team where DivisionId = @DivisionId";
            SqlParameter[] parameters = {
                    new SqlParameter("@DivisionId", DivisionId)
            };
            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, parameters);
            DataTable dt = ds.Tables[0];
            List<Team> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Team>();
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
