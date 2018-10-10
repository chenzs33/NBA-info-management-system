using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NBAHUPU.Model;
using NBAHUPU.BLL;

namespace NBAHUPU.UI
{
    /// <summary>
    /// AssociationDelete 的摘要说明
    /// </summary>
    public class AssociationDelete : IHttpHandler
    {
        private AssociationManager bll = new AssociationManager();

        public void ProcessRequest(HttpContext context)
        {
            //获取要删除的联盟编号
            string AssociationId = context.Request.QueryString["AssociationId"];
            //删除联盟
            //1、对参数：联盟编号做数据类型合法性的验证           
            int id = 0;
            if (string.IsNullOrEmpty(AssociationId) || !int.TryParse(AssociationId, out id))
            {
                context.Response.Write("<script>alert('参数错误!');window.location.href='AssociationList.aspx'</script>");
                return;
            }
            else
            {
                //2、调用业务逻辑层的方法实现删除联盟功能
                int result = bll.Delete(id);
                if (result > 0)
                {
                    context.Response.Write("<script>alert('删除联盟成功!');window.location.href='AssociationList.aspx'</script>");
                }
                else
                {
                    context.Response.Write("<script>alert('删除联盟失败!');window.location.href='AssociationList.aspx'</script>");
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