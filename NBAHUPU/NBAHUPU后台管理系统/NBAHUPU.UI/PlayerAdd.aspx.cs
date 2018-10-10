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

    public partial class PlayerAdd : System.Web.UI.Page
    {
        //创建各管理类的对象
        private AssociationManager am = new AssociationManager();
        private DivisionManager dm = new DivisionManager();
        private TeamManager tm = new TeamManager();
        private PlayerManager pm = new PlayerManager();

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

                //5、调用分区列表框选中项发生变化的事件
                ddlDivision_SelectedIndexChanged(sender, e);
            }
        }

        //当分区列表框控件所选中的项发生变化的时候触发
        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            //0、清空列表框控件的项
            ddlTeam.Items.Clear();
            //1、调用业务逻辑层方法获取球队数据
            if (!string.IsNullOrEmpty(ddlDivision.SelectedValue))
            {
                int DivisionId = Convert.ToInt32(ddlDivision.SelectedValue);
                List<Team> list = tm.GetList(DivisionId);
                //2、设置列表控件的数据源
                ddlTeam.DataSource = list;
                //3、设置列表控件的文本显示和值的字段
                ddlTeam.DataTextField = "TeamName";
                ddlTeam.DataValueField = "TeamId";
                //4、列表控件调用数据绑定方法
                ddlTeam.DataBind();

            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //判断FileUpload控件是否已选择了要上传的文件
            if (fuFile.HasFile)
            {
                #region 1、保存图片到项目目录下的photos文件夹中
                //获取要上传的文件
                HttpPostedFile file = fuFile.PostedFile;
                //获取文件的名称
                string fileName = file.FileName;   
                //获取文件的类型
                string type = file.ContentType;  

                //将图片保存到photos文件夹中
                //获取photos文件夹的服务器端路径
                string path = Server.MapPath("/photos/"); 

                //获取文件的扩展名
                string ext = Path.GetExtension(fileName);
                //获取唯一的不重复的文件名 
                //(1)文件名与系统当前日期时间相关 20171227103721001.rar
                //(2)使用Guid生成唯一的值
                string newName = Guid.NewGuid() + ext;

                //判断文件的类型是否是图片类型
                if (file.ContentType.StartsWith("image"))
                {
                    if (file.ContentLength < 200 * 1024)   //以字节为单位的  200KB = 200 * 1024 Bytes
                    {

                        //读取文件流
                        using (Image img = Image.FromStream(file.InputStream))
                        {
                            //保存
                            img.Save(path + newName);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('图片大小超过200KB');'</script>");
                        return;
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('图片类型错误！');'</script>");
                    return;
                }

                #endregion

                #region 2、在数据库表中添加球员数据
                Player model = new Player();
                model.PlayerNo = txtPlayerNo.Text;
                model.PlayerName = txtPlayerName.Text;
                model.PlayerEngName = txtPlayerEngName.Text;
                model.TeamId = Convert.ToInt32(ddlTeam.SelectedValue);
                model.Age = txtAge.Text;
                model.Birthday = Convert.ToDateTime(txtBirthday.Text);
                model.Height = txtHeight.Text;
                model.Weight = txtWeight.Text;
                model.Location = ddlLocation.Text;
                model.Photo = newName;
                //调用方法
                int result = pm.Add(model);
                //判断返回结果
                if (result > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加球员成功！');window.location.href='PlayerList.aspx'</script>");
                }
                else
                {
                    if (result == -1)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('球员已存在！')</script>");
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加球员失败！')</script>");
                    }
                }
            #endregion
            }
        }
    }
}