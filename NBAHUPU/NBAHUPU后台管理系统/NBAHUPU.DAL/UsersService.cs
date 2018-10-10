using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBAHUPU.Model;
using System.Data;
using System.Data.SqlClient;

namespace NBAHUPU.DAL
{
    public class UsersService
    {
        //增加一条记录 Create
        public int Add(Users model)  //传入模型类对象
        {
            //1、构造SQL语句
            string sql = "insert into Users(UserName,UserPwd,Status) values(@userName, @userPwd, @status)";
            //2、构造SQL参数集合
            SqlParameter[] parameters = {
                                            new SqlParameter("@userName",model.UserName),
                                            new SqlParameter("@userPwd",model.UserPwd),
                                            new SqlParameter("@status",model.Status)
                                        };
            //3、调用SqlHelper类中的方法
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        //删除一条记录 Delete
        public int Delete(int userId)
        {
            //1、构造SQL语句
            string sql = "delete from Users where UserId = @UserId";
            //2、构造SQL参数集合
            SqlParameter[] parameters = {
                                            new SqlParameter("@UserId",userId)
                                        };
            //3、调用SqlHelper类中的方法
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        //查找记录 Retrieve
        public Users GetModel(int userId)  //根据用户编号获取用户对象
        {
            //1、构造SQL语句
            string sql = "select * from Users where UserId = @UserId";
            //2、构造SQL参数集合
            SqlParameter[] parameters = {
                                            new SqlParameter("@UserId",userId)
                                        };
            //3、调用SqlHelper类中的方法
            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, parameters);
            //判断数据集中是否有数据
            if (ds.Tables[0].Rows.Count > 0)  //执行查询语句后有数据返回
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public Users GetModel(string userName)  //根据用户名称获取用户对象
        {
            //1、构造SQL语句
            string sql = "select * from Users where UserName = @UserName";
            //2、构造SQL参数集合
            SqlParameter[] parameters = {
                                            new SqlParameter("@UserName",userName)
                                        };
            //3、调用SqlHelper类中的方法
            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, parameters);
            //判断数据集中是否有数据
            if (ds.Tables[0].Rows.Count > 0)  //执行查询语句后有数据返回
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        public List<Users> GetList()  //获取所有的用户列表
        {
            //1、构造SQL语句
            string sql = "select * from Users";

            //3、调用SqlHelper类中的方法
            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, null);
            DataTable dt = ds.Tables[0];
            //构造集合
            List<Users> list = null;
            //判断数据集中是否有数据
            if (dt.Rows.Count > 0)
            {
                list = new List<Users>();
                //循环遍历表中的所有行
                foreach (DataRow dr in dt.Rows)
                {
                    //数据行转换为类的实例
                    Users model = DataRowToModel(dr); ;
                    //添加到列表中
                    list.Add(model);
                }
            }
            return list;
        }


        //用于将数据行转换为类的实例
        private Users DataRowToModel(DataRow row)
        {
            //再次判断数据行是否为空
            if (row != null)
            {
                //创建实体对象
                Users model = new Users();
                if (row["UserId"] != null)
                {
                    model.UserId = (int)row["UserId"];
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserPwd"] != null)
                {
                    model.UserPwd = row["UserPwd"].ToString();
                }
                if (row["CreateTime"] != null)
                {
                    model.CreateTime = Convert.ToDateTime(row["CreateTime"]);
                }
                if (row["Status"] != null)
                {
                    model.Status = (int)row["Status"];
                }
                //返回对象
                return model;
            }
            else
            {
                return null;
            }
        }
        //修改记录 Update
        public int Update(Users model)
        {
            //1、构造SQL语句
            string sql = "update Users set UserPwd = @UserPwd, Status = @Status where UserId = @UserId";
            //2、构造SQL参数集合
            SqlParameter[] parameters = {
                                            new SqlParameter("@UserPwd",model.UserPwd),
                                            new SqlParameter("@status",model.Status),
                                            new SqlParameter("@UserId",model.UserId)
                                        };
            //3、调用SqlHelper类中的方法
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }

    }
}
