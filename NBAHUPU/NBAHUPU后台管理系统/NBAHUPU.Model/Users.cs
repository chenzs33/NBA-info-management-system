using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAHUPU.Model
{
    //描述数据库中用户表的实体类
    [Serializable]
    public class Users
    {
        //用户编号
        public int UserId { get; set; }
        //用户名称
        public string UserName { get; set; }
        //密码
        public string UserPwd { get; set; }
        //创建时间
        public DateTime CreateTime { get; set; }
        //状态
        public int Status { get; set; }

    }
}
