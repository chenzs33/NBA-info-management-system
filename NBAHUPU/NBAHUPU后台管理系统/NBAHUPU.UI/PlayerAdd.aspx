<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PlayerAdd.aspx.cs" Inherits="NBAHUPU.UI.PlayerAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>球员添加页面</title>
    <!--引用css样式-->
    <link href="css/Validform.css" rel="stylesheet" />
    <!--引用js脚本-->
    <script src="scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="scripts/My97DatePicker/WdatePicker.js"></script>    
    <script src="scripts/Validform_v5.3.2.js"></script>
    <script type="text/javascript">
        $(function () {
            //验证
            $("#form1").Validform({
                tiptype: 2,
                showAllError: true
            });

            $("#cphMain_fuFile").change(function () {
                //1、获取FileUpload上传的图片文件
                var file = document.getElementById("cphMain_fuFile").files[0];
                //2、将图片文件转换为URL字符串
                var src = window.URL.createObjectURL(file);
                //3、设置image标签的src属性，即可显示图片
                $("#photo").attr("src", src);              
            });
        });   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="titlebar">
        <div>增加球员</div>
    </div>
    <div class="toolbox">
        <div>联盟：<asp:DropDownList ID="ddlAssociation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAssociation_SelectedIndexChanged"></asp:DropDownList></div>
        <div>赛区：<asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList></div>
        <div>球队：<asp:DropDownList ID="ddlTeam" runat="server"></asp:DropDownList></div>
    </div>
    <div class="list">
        <table class="listtb" style="width: 80%">
            <tr>
                <th>号码</th>
                <td style="width: 50%">
                    <asp:TextBox ID="txtPlayerNo" runat="server" datatype="s" nullmsg="请输入号码" ></asp:TextBox>                 
                </td>
                <td style="width: 30%">
                    <div class="Validform_checktip">*球员的号码</div>
                </td>
            </tr>
            <tr>
                <th>姓名</th>
                <td style="width: 50%">
                    <asp:TextBox ID="txtPlayerName" runat="server" datatype="s" nullmsg="请输入姓名" ></asp:TextBox>
              
                </td>
                <td style="width: 30%">
                    <div class="Validform_checktip">*球员的姓名</div>
                </td>
            </tr>
            <tr>
                <th>英文名</th>
                <td style="width: 50%">
                    <asp:TextBox ID="txtPlayerEngName" runat="server" datatype="s" nullmsg="请输入英文名" ></asp:TextBox>
              
                </td>
                <td style="width: 30%">
                    <div class="Validform_checktip">*球员的英文名</div>
                </td>
            </tr>
            <tr>
                <th>年龄</th>
                <td style="width: 50%">
                    <asp:TextBox ID="txtAge" runat="server" datatype="*" nullmsg="请输入年龄"></asp:TextBox>                
                </td>
                <td style="width: 30%">
                    <div class="Validform_checktip">*球员的年龄</div>
                </td>
            </tr>
            <tr>
                <th>出生日期</th>
                <td style="width: 50%">
                    <asp:TextBox ID="txtBirthday" runat="server" cssclass="Wdate"
                        onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td style="width: 30%">
                    <div class="Validform_checktip">*球员的出生日期</div>
                </td>
            </tr>
            <tr>
                <th>身高(cm)</th>
                <td style="width: 50%">
                    <asp:TextBox ID="txtHeight" runat="server" datatype="*" nullmsg="请输入身高"></asp:TextBox>                
                </td>
                <td style="width: 30%">
                    <div class="Validform_checktip">*球员的身高</div>
                </td>
            </tr>
            <tr>
                <th>体重(kg)</th>
                <td style="width: 50%">
                    <asp:TextBox ID="txtWeight" runat="server" datatype="*" nullmsg="请输入体重"></asp:TextBox>                
                </td>
                <td style="width: 30%">
                    <div class="Validform_checktip">*球员的体重</div>
                </td>
            </tr>
            <tr>
                <th>球场位置</th>
                <td style="width: 50%">
                    <asp:DropDownList ID="ddlLocation" runat="server" datatype="*" nullmsg="请选择球场位置">
                        <asp:ListItem>中锋</asp:ListItem>
                        <asp:ListItem>大前锋</asp:ListItem>
                        <asp:ListItem>小前锋</asp:ListItem>
                        <asp:ListItem>得分后卫</asp:ListItem>
                        <asp:ListItem>控球后卫</asp:ListItem>
                    </asp:DropDownList>           
                </td>
                <td style="width: 30%">
                    <div class="Validform_checktip">*球员的球场位置</div>
                </td>
            </tr>
            <tr>
                <th>照片</th>
                <td style="width: 50%">
                    <asp:FileUpload ID="fuFile" runat="server" datatype="*" nullmsg="请选择球员照片" />     
                </td>
                <td style="width: 30%">
                    <img alt="球员照片" id="photo" style="width:100px;height:100px" /><br />
                    <div class="Validform_checktip">*球员的照片</div>
                </td>
            </tr>
            <tr>
                <th></th>
                <td>
                    &nbsp;<asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="提交" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <input type="button" value="取消" onclick="window.location = '/PlayerList.aspx'" />
                </td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>

