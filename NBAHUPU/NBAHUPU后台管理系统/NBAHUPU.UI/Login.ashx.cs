using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NBAHUPU.BLL;
using NBAHUPU.Model;


namespace NBAHUPU.UI
{
    /// <summary>
    /// 验证用户输入的登录信息是否正确，包括用户名、密码、验证码
    /// </summary>
    public class Login : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        private UsersManager bll = new UsersManager();

        public void ProcessRequest(HttpContext context)
        {
            //1、获取用户输入的信息，包括用户名、密码、验证码、是否记住登录信息
            string userName = context.Request.Form["username"];
            string pwd = context.Request.Form["userpwd"];
            string vcode = context.Request.Form["vcode"];
            string isremember = context.Request.Form["isremember"];
            //如果勾选了是否记住登录信息的复选框，此时isremember变量的值是on，否则是null

            //2、检查验证码输入的有效性
            //判断验证码文本框是否为空
            if (string.IsNullOrEmpty(vcode))
            {
                //提示用户输入验证码，单击确定按钮后，重定向回Login.html登录页面
                context.Response.Write("<script>alert('请输入验证码!');window.location.href='Login.html'</script>");
                //跳出方法的执行
                return;
            }
            //判断会话是否已超时
            if (context.Session["ValidateCode"]==null)
            {
                context.Response.Write("<script>alert('验证码已过期!');window.location.href='Login.html'</script>");
                //跳出方法的执行
                return;
            }
            //3、比较用户输入的验证码 是否与 产生的验证码 一致
            string validateCode = context.Session["ValidateCode"].ToString();  //存放在Session中的验证码 
            //验证码比较一致后，再检查用户名和密码的正确性
            if (validateCode.Equals(vcode,StringComparison.OrdinalIgnoreCase)) //不区分大小写
            {
                
                //验证用户名和密码正确性
                //调用业务逻辑层的方法实现
                Users model = bll.Login(userName, pwd);

                if (model != null)
                {
                    //将用户登录信息保存到Cookie中，以实现免登录功能
                    //判断用户是否勾选了免登录复选框
                    if (!string.IsNullOrEmpty(isremember))  //勾选了复选框的情况
                    {
                        //将登录信息保存到Cookie中
                        //方法1：
                        HttpCookie cookie = new HttpCookie("isremember", userName);
                        cookie.Expires = DateTime.Now.AddDays(7);
                        context.Response.Cookies.Add(cookie);

                        //方法2：
                        //context.Response.Cookies["isremember"].Value = userName;
                        //context.Response.Cookies["isremember"].Expires = DateTime.Now.AddDays(7);
                    }

                    //将登录用户名保存到Session中，以便在首页中使用
                    context.Session["LoginUser"] = userName;
                    //跳转
                    context.Response.Write("<script>alert('登录成功!');window.location.href='Index.aspx'</script>");
                } 
                else
                {
                    context.Response.Write("<script>alert('用户名或密码错误!');window.location.href='Login.html'</script>");
                }
            }
            else
            {
                context.Response.Write("<script>alert('验证码错误!');window.location.href='Login.html'</script>");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}