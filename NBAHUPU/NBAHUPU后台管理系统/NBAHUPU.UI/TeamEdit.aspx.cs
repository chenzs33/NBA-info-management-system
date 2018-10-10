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
    public partial class TeamEdit : System.Web.UI.Page
    {
        //创建各管理类的对象
        private AssociationManager am = new AssociationManager();
        private DivisionManager dm = new DivisionManager();

        private TeamManager bll = new TeamManager();
        
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

                //立即调用一次ddlAssociation_SelectedIndexChanged，用于绑定分区列表框中的数据并显示出来
                ddlAssociation_SelectedIndexChanged(sender, e);
            
                //获取当前球队的编号
                string TeamId = Request.QueryString["TeamId"];
                //对球队编号有效性作检查
                int id = 0;
                if (string.IsNullOrEmpty(TeamId) || !int.TryParse(TeamId, out id))
                {
                    Response.Write("<script>alert('参数不合法!');window.location.href='TeamList.aspx'</script>");
                    return;
                }

                //去数据库中查询此球队编号的球队数据
                Team model = bll.GetModel(id);
                if (model != null)
                {
                    //读取实体对象的各个属性值，并赋值给控件
                    txtTeamName.Text = model.TeamName;  //球队
                }
            }
        }
        //当ddlAssociation列表框控件所选中的项发生变化的时候触发
        protected void ddlAssociation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //0、清空列表框控件的项
            ddlDivision.Items.Clear();
            //1、调用业务逻辑层方法获取分区数据
            if (!string.IsNullOrEmpty(ddlAssociation.SelectedValue))
            {
                int AssociationId = Convert.ToInt32(ddlAssociation.SelectedValue);
                List<Division> list = dm.GetList(AssociationId);
                //2、设置列表控件的数据源
                ddlDivision.DataSource = list;
                //3、设置列表控件的文本显示和值的字段
                ddlDivision.DataTextField = "DivisionName";
                ddlDivision.DataValueField = "DivisionId";
                //4、列表控件调用数据绑定方法
                ddlDivision.DataBind();
            }
        }

        //单击确定按钮后触发
        protected void btnOK_Click(object sender, EventArgs e)
        {
            //获取当前球队的编号
            string TeamId = Request.QueryString["TeamId"];
            //对球队编号有效性作检查
            int id = 0;
            if (string.IsNullOrEmpty(TeamId) || !int.TryParse(TeamId, out id))
            {
                Response.Write("<script>alert('参数不合法!');window.location.href='TeamList.aspx'</script>");
                return;
            }

            //1、构造球队实体对象
            Team model = new Team();
            model.TeamId = id;
            model.TeamName = txtTeamName.Text;
            model.DivisionId = Convert.ToInt32(ddlDivision.SelectedValue);
           

            //2、调用业务逻辑层的方法实现更新球队信息的功能
            int result = bll.Update(model);
            if (result > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('球队修改成功');window.location.href='TeamList.aspx'</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('球队修改失败')</script>");
            }

        }
    }
}