using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using NBAHUPU.Model;
using NBAHUPU.BLL;

namespace NBAHUPU.UI
{
    public partial class AssociationList : System.Web.UI.Page
    {
        private AssociationManager bll = new AssociationManager();
        protected StringBuilder sb = new StringBuilder(200);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //调用业务逻辑层方法获取所有的联盟列表
                List<Association> list = bll.GetList();

                //遍历列表中的元素
                foreach (Association model in list)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + model.AssociationName + "</td>");
                    sb.Append("<td><a href=\"AssociationEdit.aspx?AssociationId=" + model.AssociationId + "\">修改</a> | <a href=\"AssociationDelete.ashx?AssociationId=" + model.AssociationId + "\" onClick=\"return confirm('确定删除?');\">删除</a></td>");
                    sb.Append("</tr>");
                }
            }
        }
    }
}