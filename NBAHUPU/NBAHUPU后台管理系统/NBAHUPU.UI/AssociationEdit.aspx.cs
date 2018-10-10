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
    public partial class AssociationEdit : System.Web.UI.Page
    {
        private AssociationManager bll = new AssociationManager();
        
        //页面加载完成后触发
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)  //首次加载
            {
                //获取当前联盟的编号
                string AssociationId = Request.QueryString["AssociationId"];
                //对联盟编号有效性作检查
                int id = 0;
                if (string.IsNullOrEmpty(AssociationId) || !int.TryParse(AssociationId, out id))
                {
                    Response.Write("<script>alert('参数不合法!');window.location.href='AssociationList.aspx'</script>");
                    return;
                }

                //去数据库中查询此联盟编号的联盟数据
                Association model = bll.GetModel(id);
                if (model != null)
                {
                    //读取实体对象的各个属性值，并赋值给控件
                    txtAssociationName.Text = model.AssociationName;  //联盟
                }
            }
        }

        //单击确定按钮后触发
        protected void btnOK_Click(object sender, EventArgs e)
        {
            //获取当前联盟的编号
            string AssociationId = Request.QueryString["AssociationId"];
            //对联盟编号有效性作检查
            int id = 0;
            if (string.IsNullOrEmpty(AssociationId) || !int.TryParse(AssociationId, out id))
            {
                Response.Write("<script>alert('参数不合法!');window.location.href='AssociationList.aspx'</script>");
                return;
            }

            //1、构造联盟实体对象
            Association model = new Association();
            model.AssociationId = id;
            model.AssociationName = txtAssociationName.Text;
            //model.AssociationPwd = txtAssociationPwd.Text;
            //model.CreateTime = DateTime.Now;
            //model.Status = Convert.ToInt32(ddlStatus.SelectedValue);

            //2、调用业务逻辑层的方法实现更新联盟信息的功能
            int result = bll.Update(model);
            if (result > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('联盟修改成功');window.location.href='AssociationList.aspx'</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('联盟修改失败')</script>");
            }

        }
    }
}