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
    public partial class TeamList : System.Web.UI.Page
    {
        //创建各管理类的对象
        private AssociationManager am = new AssociationManager();
        private DivisionManager dm = new DivisionManager();
        private TeamManager tm = new TeamManager();

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

                //立即调用一次ddlAssociation_SelectedIndexChanged，用于绑定赛区列表框中的数据并显示出来
                ddlAssociation_SelectedIndexChanged(sender, e);
            }
        }

        //当ddlAssociation列表框控件所选中的项发生变化的时候触发
        protected void ddlAssociation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //0、清空列表框控件的项
            ddlDivision.Items.Clear();
            //1、调用业务逻辑层方法获取赛区数据
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

                //5、调用赛区列表框选中项发生变化的事件
                ddlDivision_SelectedIndexChanged(sender, e);
            }
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            //1、调用业务逻辑层方法获取球队数据
            if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
            {
                int TeamId = Convert.ToInt32(ddlDivision.SelectedValue);
                List<Team> list = tm.GetList(TeamId);
                //2、设置Repeater控件的数据源
                rpData.DataSource = list;
                //3、调用数据绑定方法
                rpData.DataBind();
            }

        }
    }
}