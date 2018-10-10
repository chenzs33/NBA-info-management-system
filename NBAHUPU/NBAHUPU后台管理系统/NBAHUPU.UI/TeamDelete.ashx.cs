using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NBAHUPU.Model;
using NBAHUPU.BLL;

namespace NBAHUPU.UI
{
    public class TeamDelete : IHttpHandler
    {
        private TeamManager bll = new TeamManager();

        public void ProcessRequest(HttpContext context)
        {
            //获取要删除的球队编号
            string TeamId = context.Request.QueryString["TeamId"];
            //删除球队
            //1、对参数：球队编号做数据类型合法性的验证           
            int id = 0;
            if (string.IsNullOrEmpty(TeamId) || !int.TryParse(TeamId, out id))
            {
                context.Response.Write("<script>alert('参数错误!');window.location.href='TeamList.aspx'</script>");
                return;
            }
            else
            {
                //2、调用业务逻辑层的方法实现删除球队功能
                int result = bll.Delete(id);
                if (result > 0)
                {
                    context.Response.Write("<script>alert('删除球队成功!');window.location.href='TeamList.aspx'</script>");
                }
                else
                {
                    context.Response.Write("<script>alert('删除球队失败!');window.location.href='TeamList.aspx'</script>");
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