using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NBAHUPU.BLL;
using NBAHUPU.Model;
using System.IO;


namespace NBAHUPU.UI
{
    using System.Drawing;

    public partial class DivisionAdd : System.Web.UI.Page
    {
        //创建各管理类的对象
        private AssociationManager am = new AssociationManager();
        private DivisionManager dm = new DivisionManager();


        //在页面加载完毕后执行
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //调用业务逻辑层方法获取联盟数据
                List<Association> list = am.GetList();
                //数据绑定
                ddlAssociation.DataSource = list;
                //设置显示的文本列和值列
                ddlAssociation.DataTextField = "AssociationName";
                ddlAssociation.DataValueField = "AssociationId";
                ddlAssociation.DataBind();
            }
        }


        protected void btnOK_Click(object sender, EventArgs e)
        {

            //2、在数据库表中添加赛区数据
            Division model = new Division();
            model.DivisionName = txtDivisionName.Text;
            model.AssociationId = Convert.ToInt32(ddlAssociation.SelectedValue);

            //调用方法
            int result = dm.Add(model);
            //判断返回结果
            if (result > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加赛区成功！');window.location.href='DivisionList.aspx'</script>");
            }
            else
            {
                if (result == -1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('赛区已存在！')</script>");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加赛区失败！')</script>");
                }
            }

        }
    }
}