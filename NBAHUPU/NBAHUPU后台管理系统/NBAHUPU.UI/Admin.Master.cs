using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBAHUPU.UI
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected string loginUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断名称为loginUser的Session是否存在
            if (Session["LoginUser"] != null)
            {
                //将Session值取出来，为成员变量赋值
                loginUser = Session["LoginUser"].ToString();
            }
            else  //Session为null，此时用户没有登录
            {
                //尝试从Cookie中读取登录信息
                if (Request.Cookies["isremember"] != null)
                {
                    //从Cooke中将登录用户名读取出来，赋值给成员变量loginUser
                    loginUser = Request.Cookies["isremember"].Value;
                    //再将用户名赋值给Session
                    Session["LoginUser"] = loginUser;
                }
                else  //没有Session，也没有Cookie的情况
                {
                    //跳回到登录页Login.html
                    Response.Redirect("Login.html");
                }
            }
        }
    }
}