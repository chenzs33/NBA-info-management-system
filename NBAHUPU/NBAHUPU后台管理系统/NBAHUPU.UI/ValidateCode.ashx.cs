using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;  

namespace NBAHUPU.UI
{
    public class ValidateCode : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        private string GetVcode(int count)
        {
            //实例化
            Random r = new Random();
            //定义随机字符串
            string code = string.Empty;
            //定义备选的字符库
            string str = "0123456789abcdefghijkmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ";
            //循环遍历
            for(int i = 0; i<count;i++)
            {
                //获取随机的索引 0 ~ str.Length - 1 
                int index = r.Next(str.Length);
                //获取随机索引位置上的字符，添加到code变量中
                code += str[index];
            }
            //返回随机字符串
            return code;
        }


        public void ProcessRequest(HttpContext context)
        {
            //调用方法，获取随机字符串
            string vcode = GetVcode(4);
            //将验证码保存到Session中
            context.Session["ValidateCode"] = vcode;
            //获取画布的宽度
            int width = (int)(vcode.Length * 15);
            //创建画布对象
            //using块的好处：保证创建的对象，能够在执行using块中的代码后，自动释放所占用的资源
            using(Image img = new Bitmap(width, 25))
            {
                //创建画家对象
                using (Graphics g = Graphics.FromImage(img))
                {
                    //开始绘画
                    //将画布清空为白色
                    g.Clear(Color.White);
                    //绘制矩形边框
                    g.DrawRectangle(Pens.White, 0, 0, width, 25);
                    //定义字体
                    Font f = new Font("黑体",18,FontStyle.Bold);
                    //绘制字符串
                    g.DrawString(vcode, f, Brushes.Blue, 0, 0);
                }
                //调用Image对象的Save方法将图像数据发送至浏览器
                img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}