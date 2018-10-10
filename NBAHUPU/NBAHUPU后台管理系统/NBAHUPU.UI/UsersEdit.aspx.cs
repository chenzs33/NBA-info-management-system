using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBAHUPU.BLL;
using NBAHUPU.Model;


namespace NBAHUPU.UI
{
    public partial class UsersEdit : System.Web.UI.Page
    {
        private UsersManager bll = new UsersManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)  //首次加载
            {
                //获取当前用户的编号
                string userId = Request.QueryString["UserId"];
                //对用户编号有效性作检查
                int id = 0;
                if (string.IsNullOrEmpty(userId) || !int.TryParse(userId,out id))
                {
                    Response.Write("<script>alert('参数不合法!');window.location.href='UsersList.aspx'</script>");
                    return;
                }

                //去数据库中查询此用户编号的用户数据
                Users model = bll.GetModel(id);
                if (model != null)
                {
                    //读取实体对象的各个属性值，并赋值给控件
                    txtUserName.Text = model.UserName;  //用户名
                    txtUserPwd.Text = model.UserPwd;   //密码
                    txtConfirmPwd.Text = txtUserPwd.Text;
                    ddlStatus.SelectedValue = model.Status.ToString();

                    //因为页面中密码框是默认不会保存用户的密码信息的，如果要保存并显示用户的密码，必须手动为密码框的value属性设置值
                    txtUserPwd.Attributes["value"] = model.UserPwd;
                    txtConfirmPwd.Attributes["value"] = model.UserPwd;
                }
            }
        }

        //单击确定按钮后触发
        protected void btnOK_Click(object sender, EventArgs e)
        {
            //获取当前用户的编号
            string userId = Request.QueryString["UserId"];
            //对用户编号有效性作检查
            int id = 0;
            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out id))
            {
                Response.Write("<script>alert('参数不合法!');window.location.href='UsersList.aspx'</script>");
                return;
            }

            //1、构造用户实体对象
            Users model = new Users();
            model.UserId = id;
            model.UserName = txtUserName.Text;
            model.UserPwd = txtUserPwd.Text;
            model.CreateTime = DateTime.Now;
            model.Status = Convert.ToInt32(ddlStatus.SelectedValue);

            //2、调用业务逻辑层的方法实现更新用户信息的功能
            int result = bll.Update(model);
            if (result > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('用户修改成功')</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('用户修改失败')</script>");
            }
        }
    }
}