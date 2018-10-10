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
    public partial class UsersList : System.Web.UI.Page
    {
        private UsersManager bll = new UsersManager();
        protected StringBuilder sb = new StringBuilder(200);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //调用业务逻辑层方法获取所有的用户列表
                List<Users> list = bll.GetList();

                //遍历列表中的元素
                foreach (Users model in list)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + model.UserName + "</td>");
                    sb.Append("<td>" + model.CreateTime + "</td>");
                    sb.Append("<td>" + (model.Status == 1 ? "正常" : "禁用") + "</td>");
                    sb.Append("<td><a href=\"UsersEdit.aspx?UserId=" + model.UserId + "\">修改</a> | <a href=\"UsersDelete.ashx?UserId=" + model.UserId + "\" onClick=\"return confirm('确定删除?');\">删除</a></td>");
                    sb.Append("</tr>");
                }
            }
        }
    }
}