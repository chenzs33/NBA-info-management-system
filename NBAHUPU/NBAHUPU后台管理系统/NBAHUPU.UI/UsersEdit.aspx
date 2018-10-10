<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UsersEdit.aspx.cs" Inherits="NBAHUPU.UI.UsersEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>用户编辑页面</title>
    <!--引用css样式-->
    <link href="css/Validform.css" rel="stylesheet" />
    <!--引用js脚本-->
    <script src="scripts/jquery-1.9.1.js"></script>
    <script src="scripts/Validform_v5.3.2.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").Validform({
                tiptype: 2,
                showAllError: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="titlebar">
        <div>编辑用户</div>
    </div>
    <div class="list">
        <table class="listtb" style="width: 80%">
            <tr>
                <th>用户名</th>
                <td style="width: 50%">
                    <asp:TextBox ID="txtUserName" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="width: 30%">
                    <div class="Validform_checktip">*登录的用户名</div>
                </td>
            </tr>
            <tr>
                <th>用户密码</th>
                <td>
                    <asp:TextBox ID="txtUserPwd" runat="server" TextMode="Password" datatype="*" nullmsg="请设置密码"></asp:TextBox>
                </td>
                <td>
                    <div class="Validform_checktip">*登录的密码</div>
                </td>
            </tr>
            <tr>
                <th>确认密码</th>
                <td>
                    <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password" datatype="*" recheck="ctl00$cphMain$txtUserPwd" nullmsg="请再输入一次密码" errormsg="两次输入的密码不一致"></asp:TextBox>
                </td>
                <td>
                    <div class="Validform_checktip">*再次输入密码</div>
                </td>
            </tr>
            <tr>
                <th>状态</th>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem Value="0">禁用</asp:ListItem>
                        <asp:ListItem Value="1">正常</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <span class="Validform_checktip">*禁用账户无法登录</span>
                </td>
            </tr>
            <tr>
                <th></th>
                <td>
                    <asp:Button ID="btnOK" runat="server" Text="确定" OnClick="btnOK_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" value="取消" onclick="window.location = '/UsersList.aspx'" />
                </td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
