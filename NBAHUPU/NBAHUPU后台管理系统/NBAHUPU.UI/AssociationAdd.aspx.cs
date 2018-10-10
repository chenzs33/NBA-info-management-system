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
    public partial class AssociationAdd : System.Web.UI.Page
    {
        private AssociationManager bll = new AssociationManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //获取联盟输入的数据
            string AssociationName = txtAssociationName.Text.Trim();

            //添加联盟
            //1、构造联盟实体对象
            Association model = new Association();
            model.AssociationName = AssociationName;

            //2、调用业务逻辑层添加联盟
            int result = bll.Add(model);

            if (result > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加联盟成功！');window.location.href='AssociationList.aspx'</script>");
            }
            else
            {
                if (result == -1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('联盟名已存在！')</script>");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加联盟失败！')</script>");
                }
            }

        }
    }
}