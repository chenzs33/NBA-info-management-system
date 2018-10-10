<%@ Page Title="用户列表" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="NBAHUPU.UI.UsersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="titlebar">
        <div>用户管理</div>
    </div>
    <div class="newbt">
        <div>
            <a href="UsersAdd.aspx">
                <input type="button" id="add" value="创建用户" />
            </a>
        </div>
    </div>    
    <div class="list">
        <table class="listtb">
            <tr>
                <th>用户名</th>
                <th>创建时间</th>
                <th>状态</th>
                <th>操作</th>
            </tr>
            <%=sb.ToString() %>
        </table>
    </div>
</asp:Content>
