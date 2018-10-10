using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using NBAHUPU.Model;

namespace NBAHUPU.DAL
{
    public class PlayerService
    {

        #region  BasicMethod

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Player model)
        {
            string sql = "Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location,Photo) values(@PlayerName,@PlayerEngName,@PlayerNo,@TeamId,@Age,@Birthday,@Height,@Weight,@Location,@Photo)";

            SqlParameter[] parameters = {
                    new SqlParameter("@PlayerName", model.PlayerName),
                    new SqlParameter("@PlayerEngName", model.PlayerEngName),
                    new SqlParameter("@PlayerNo", model.PlayerNo),
                    new SqlParameter("@TeamId", model.TeamId),
                    new SqlParameter("@Age", model.Age),
                    new SqlParameter("@Birthday", model.Birthday),
                    new SqlParameter("@Height",model.Height),
                    new SqlParameter("@Weight", model.Weight),
                    new SqlParameter("@Location", model.Location),
                    new SqlParameter("@Photo", model.Photo)
            };

            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Player model)
        {
            string sql = "update Player set PlayerName=@PlayerName,PlayerEngName=@PlayerEngName,TeamId=@TeamId,Age=@Age,Birthday=@Birthday,Height=@Height,Weight=@Weight,Location=@Location,Photos=@Photo where PlayerNo=@PlayerNo ";

            SqlParameter[] parameters = {
                    new SqlParameter("@PlayerName", model.PlayerName),
                    new SqlParameter("@PlayerEngName", model.PlayerEngName),
                    new SqlParameter("@TeamID", model.TeamId),
                    new SqlParameter("@Age", model.Age),
                    new SqlParameter("@Birthday", model.Birthday),
                    new SqlParameter("@Height",model.Height),
                    new SqlParameter("@Weight", model.Weight),
                    new SqlParameter("@Location", model.Location),
                    new SqlParameter("@PlayerNo", model.PlayerNo),
                    new SqlParameter("@Photo", model.Photo)
            };

            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int PlayerNo)
        {
            string sql = "delete Player where PlayerNo=@PlayerNo";
            SqlParameter[] parameters = {
                    new SqlParameter("@PlayerNo", PlayerNo)
            };

            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Player GetModel(string PlayerNo)
        {
            string sql = "select * from Player where PlayerNo=@PlayerNo";

            SqlParameter[] parameters = {
                    new SqlParameter("@PlayerNo", PlayerNo)
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
        public Player DataRowToModel(DataRow row)
        {
            Player model = new Player();
            if (row != null)
            {
                if (row["PlayerName"] != null)
                {
                    model.PlayerName = row["PlayerName"].ToString();
                }
                if (row["PlayerEngName"] != null)
                {
                    model.PlayerEngName = row["PlayerEngName"].ToString();
                }
                if (row["PlayerNo"] != null)
                {
                    model.PlayerNo = row["PlayerNo"].ToString();
                }
                if (row["TeamId"] != null && row["TeamId"].ToString() != "")
                {
                    model.TeamId = Convert.ToInt32(row["TeamId"]);
                }
                if (row["Age"] != null)
                {
                    model.Age = row["Age"].ToString();
                }

                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = Convert.ToDateTime(row["Birthday"]);
                }
                if (row["Height"] != null)
                {
                    model.Height = row["Height"].ToString();
                }
                if (row["Weight"] != null)
                {
                    model.Weight = row["Weight"].ToString();
                }
                if (row["Location"] != null)
                {
                    model.Location = row["Location"].ToString();
                }
                if (row["Photo"] != null)
                {
                    model.Photo = row["Photo"].ToString();
                }
            }
            return model;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Player> GetList()
        {
            string sql = "select * from Player";
            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, null);
            DataTable dt = ds.Tables[0];
            List<Player> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Player>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(DataRowToModel(dr));
                }
            }
            return list;
        }

        public List<Player> GetList(int TeamID)
        {
            string sql = "select * from Player where TeamID = @TeamID";
            SqlParameter[] parameters = {
                    new SqlParameter("@TeamID", TeamID)
            };
            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, parameters);
            DataTable dt = ds.Tables[0];
            List<Player> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Player>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(DataRowToModel(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 根据条件模糊查询球员信息
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public List<Player> GetList(string key, string value)
        {
            string sql = "select * from Player";
            SqlParameter[] parameters = null;
            if (key == "号码")
            {
                sql += " where PlayerNo like + '%' + @PlayerNo+ '%'";
                parameters = new SqlParameter[]{
                    new SqlParameter("@PlayerNo", value)
                };
            };
            if (key == "姓名")
            {
                sql += " where PlayerName like + '%' + @PlayerName+ '%'";
                parameters = new SqlParameter[]{
                    new SqlParameter("@PlayerName", value)
                };
            };
            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, parameters);
            DataTable dt = ds.Tables[0];
            List<Player> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Player>();
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
            totalCount = 0;

            string sql = "USP_GetPlayerListByPage";
            SqlParameter[] parameters ={
                new SqlParameter("@pageIndex",SqlDbType.Int),
                new SqlParameter("@pageSize",SqlDbType.Int),
                new SqlParameter("@totalCount",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int)
            };
            parameters[0].Value = pageIndex;
            parameters[1].Value = pageSize;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Value = TeamID;

            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.StoredProcedure, parameters);
            DataTable dt = ds.Tables[0];

            //给输出参数赋值
            if (parameters[2].Value != null)
                totalCount = Convert.ToInt32(parameters[2].Value);

            List<Player> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Player>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(DataRowToModel(dr));
                }
            }
            return list;
        }


        #endregion  ExtensionMethod
    }
}
