using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBAHUPU.UI
{
    /// <summary>
    /// Logout 的摘要说明
    /// </summary>
    public class Logout : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //实现当前登录用户的注销功能
            //结束Session，取消当前会话
            context.Session.Abandon();
            //跳转到登录页Login.html
            context.Response.Write("<script>alert('注销成功!');window.location.href='Login.html'</script>");
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