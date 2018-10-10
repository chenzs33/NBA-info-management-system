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
    public partial class DivisionList : System.Web.UI.Page
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

                //立即调用一次ddlAssociation_SelectedIndexChanged，用于绑定赛区列表框中的数据并显示出来
                ddlAssociation_SelectedIndexChanged(sender, e);
            }
        }

        //当ddlAssociation列表框控件所选中的项发生变化的时候触发
        protected void ddlAssociation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //1、调用业务逻辑层方法获取赛区数据
            if (!string.IsNullOrEmpty(ddlAssociation.SelectedValue))
            {
                int TeamId = Convert.ToInt32(ddlAssociation.SelectedValue);
                List<Division> list = dm.GetList(TeamId);
                //2、设置Repeater控件的数据源
                rpData.DataSource = list;
                //3、调用数据绑定方法
                rpData.DataBind();
            }
        }
    }
}