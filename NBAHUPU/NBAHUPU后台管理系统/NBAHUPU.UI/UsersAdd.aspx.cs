using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Data;
//using System.Data.SqlClient;
using NBAHUPU.BLL;
using NBAHUPU.Model;

namespace NBAHUPU.UI
{
    public partial class UsersAdd : System.Web.UI.Page
    {
        private UsersManager bll = new UsersManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //获取用户输入的数据
            string userName = txtUserName.Text.Trim();
            string userPwd = txtUserPwd.Text.Trim();
            int status = Convert.ToInt32(ddlStatus.SelectedValue);

            //添加用户
            //1、构造用户实体对象
            Users model = new Users();
            model.UserName = userName;
            model.UserPwd = userPwd;
            model.Status = status;

            //2、调用业务逻辑层添加用户
            int result = bll.Add(model);

            if (result >0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加用户成功！');window.location.href='UsersList.aspx'</script>");
            }
            else
            {
                if (result == -1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('用户名已存在！')</script>");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加用户失败！')</script>");
                }
            }
        }
    }
}