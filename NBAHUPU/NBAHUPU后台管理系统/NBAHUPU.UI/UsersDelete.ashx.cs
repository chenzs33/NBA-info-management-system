using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NBAHUPU.Model;
using NBAHUPU.BLL;

namespace NBAHUPU.UI
{
    public class UsersDelete : IHttpHandler
    {
        private UsersManager bll = new UsersManager();

        public void ProcessRequest(HttpContext context)
        {
            //获取要删除的用户编号
            string userId = context.Request.QueryString["UserId"];  
            //删除用户
            //1、对参数：用户编号做数据类型合法性的验证           
            int id = 0;
            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out id))
            {
                context.Response.Write("<script>alert('参数错误!');window.location.href='UsersList.aspx'</script>");
                return;
            }
            else
            {
                //2、调用业务逻辑层的方法实现删除用户功能
                int result = bll.Delete(id);
                if (result > 0)
                {
                    context.Response.Write("<script>alert('删除用户成功!');window.location.href='UsersList.aspx'</script>");
                }
                else
                {
                    context.Response.Write("<script>alert('删除用户失败!');window.location.href='UsersList.aspx'</script>");
                }
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