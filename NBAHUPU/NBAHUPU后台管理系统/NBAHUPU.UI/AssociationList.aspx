<%@ Page Title="联盟列表" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AssociationList.aspx.cs" Inherits="NBAHUPU.UI.AssociationList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="titlebar">
        <div>联盟信息管理</div>
    </div>
    <div class="newbt">
        <div>
            <a href="AssociationAdd.aspx">
                <input type="button" id="add" value="创建联盟" />
            </a>
        </div>
    </div>    
    <div class="list">
        <table class="listtb">
            <tr>
                <th>联盟</th>
                <th>操作</th>
            </tr>
            <%=sb.ToString() %>
        </table>
    </div>
</asp:Content>
