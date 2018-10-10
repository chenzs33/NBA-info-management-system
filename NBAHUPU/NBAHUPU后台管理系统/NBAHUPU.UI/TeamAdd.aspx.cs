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

    public partial class TeamAdd : System.Web.UI.Page
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

                //立即调用一次ddlAssociation_SelectedIndexChanged，用于绑定分区列表框中的数据并显示出来
                ddlAssociation_SelectedIndexChanged(sender, e);
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

        protected void btnOK_Click(object sender, EventArgs e)
        {
                // 2、在数据库表中添加球员数据
                Team model = new Team();
                model.TeamName = txtTeamName.Text;
                model.DivisionId = Convert.ToInt32(ddlDivision.SelectedValue);

                //调用方法
                int result = tm.Add(model);
                //判断返回结果
                if (result > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加球队成功！');window.location.href='TeamList.aspx'</script>");
                }
                else
                {
                    if (result == -1)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('球队已存在！')</script>");
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加球队失败！')</script>");
                    }
                }
            }
        }
    }