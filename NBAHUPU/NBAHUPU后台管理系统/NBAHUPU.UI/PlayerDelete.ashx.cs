using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NBAHUPU.Model;
using NBAHUPU.BLL;

namespace NBAHUPU.UI
{
    public class PlayerDelete : IHttpHandler
    {
        private PlayerManager bll = new PlayerManager();

        public void ProcessRequest(HttpContext context)
        {
            //获取要删除的球员编号
            string PlayerNo = context.Request.QueryString["PlayerNo"];
            //删除球员
            //1、对参数：球员编号做数据类型合法性的验证           
            int no = 0;
            if (string.IsNullOrEmpty(PlayerNo) || !int.TryParse(PlayerNo, out no))
            {
                context.Response.Write("<script>alert('参数错误!');window.location.href='PlayerList.aspx'</script>");
                return;
            }
            else
            {
                //2、调用业务逻辑层的方法实现删除球员功能
                int result = bll.Delete(no);

                if (result > 0)
                {
                    context.Response.Write("<script>alert('删除球员成功!');window.location.href='PlayerList.aspx'</script>");
                }
                else
                {
                    context.Response.Write("<script>alert('删除球员失败!');window.location.href='PlayerList.aspx'</script>");
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