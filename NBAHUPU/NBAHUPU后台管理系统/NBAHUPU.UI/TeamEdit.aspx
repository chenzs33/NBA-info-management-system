<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TeamEdit.aspx.cs" Inherits="NBAHUPU.UI.TeamEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>球队编辑页面</title>
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
        <div>编辑球队</div>
    </div>
    <div class="toolbox">
        <div>联盟：<asp:DropDownList ID="ddlAssociation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAssociation_SelectedIndexChanged"></asp:DropDownList></div>
        <div>赛区：<asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True"></asp:DropDownList></div>
    </div>
    <div class="list">
        <table class="listtb" style="width: 80%">
            <tr>
                <th>球队</th>
                <td style="width: 50%">
                    <asp:TextBox ID="txtTeamName" runat="server"></asp:TextBox>
                </td>
                <td style="width: 30%">
                    <div class="Validform_checktip">*请输入更改后的球队名称</div>
                </td>
            </tr>
            <tr>
                <th></th>
                <td>
                    <asp:Button ID="btnOK" runat="server" Text="确定" OnClick="btnOK_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" value="取消" onclick="window.location = '/TeamList.aspx'" />
                </td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
