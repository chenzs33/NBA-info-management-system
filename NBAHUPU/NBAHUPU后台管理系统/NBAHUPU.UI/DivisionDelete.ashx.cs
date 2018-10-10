using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NBAHUPU.Model;
using NBAHUPU.BLL;

namespace NBAHUPU.UI
{
    /// <summary>
    /// DivisionDelete 的摘要说明
    /// </summary>
    public class DivisionDelete : IHttpHandler
    {
        private DivisionManager bll = new DivisionManager();

        public void ProcessRequest(HttpContext context)
        {
            //获取要删除的赛区编号
            string DivisionId = context.Request.QueryString["DivisionId"];
            //删除赛区
            //1、对参数：赛区编号做数据类型合法性的验证           
            int id = 0;
            if (string.IsNullOrEmpty(DivisionId) || !int.TryParse(DivisionId, out id))
            {
                context.Response.Write("<script>alert('参数错误!');window.location.href='DivisionList.aspx'</script>");
                return;
            }
            else
            {
                //2、调用业务逻辑层的方法实现删除赛区功能
                int result = bll.Delete(id);
                if (result > 0)
                {
                    context.Response.Write("<script>alert('删除赛区成功!');window.location.href='DivisionList.aspx'</script>");
                }
                else
                {
                    context.Response.Write("<script>alert('删除赛区失败!');window.location.href='DivisionList.aspx'</script>");
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