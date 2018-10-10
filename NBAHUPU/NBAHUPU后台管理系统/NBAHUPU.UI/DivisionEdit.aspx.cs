using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBAHUPU.BLL;
using NBAHUPU.Model;

namespace NBAHUPU.UI
{
    public partial class DivisionEdit : System.Web.UI.Page
    {
        //创建各管理类的对象
        private AssociationManager am = new AssociationManager();

        private DivisionManager bll = new DivisionManager();
        
        //页面加载完成后触发
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

                //获取当前赛区的编号
                string DivisionId = Request.QueryString["DivisionId"];
                //对赛区编号有效性作检查
                int id = 0;
                if (string.IsNullOrEmpty(DivisionId) || !int.TryParse(DivisionId, out id))
                {
                    Response.Write("<script>alert('参数不合法!');window.location.href='DivisionList.aspx'</script>");
                    return;
                }

                //去数据库中查询此赛区编号的赛区数据
                Division model = bll.GetModel(id);
                if (model != null)
                {
                    //读取实体对象的各个属性值，并赋值给控件
                    txtDivisionName.Text = model.DivisionName;  //赛区

                    
                }
            }
        }

        //单击确定按钮后触发
        protected void btnOK_Click(object sender, EventArgs e)
        {
            //获取当前赛区的编号
            string DivisionId = Request.QueryString["DivisionId"];
            //对赛区编号有效性作检查
            int id = 0;
            if (string.IsNullOrEmpty(DivisionId) || !int.TryParse(DivisionId, out id))
            {
                Response.Write("<script>alert('参数不合法!');window.location.href='DivisionList.aspx'</script>");
                return;
            }

            //1、构造赛区实体对象
            Division model = new Division();
            model.DivisionId = id;
            model.DivisionName = txtDivisionName.Text;
            model.AssociationId = Convert.ToInt32(ddlAssociation.SelectedValue);


            //2、调用业务逻辑层的方法实现更新赛区信息的功能
            int result = bll.Update(model);
            if (result > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('赛区修改成功');window.location.href='DivisionList.aspx'</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('赛区修改失败')</script>");
            }

        }
    }
}