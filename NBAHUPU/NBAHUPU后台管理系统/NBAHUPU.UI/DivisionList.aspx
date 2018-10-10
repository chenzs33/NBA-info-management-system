<%@ Page Title="赛区信息管理" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DivisionList.aspx.cs" Inherits="NBAHUPU.UI.DivisionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="titlebar">
        <div>赛区信息管理</div>
    </div>
    <div class="toolbox">
        <div>联盟：<asp:DropDownList ID="ddlAssociation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAssociation_SelectedIndexChanged"></asp:DropDownList></div>
    </div>
    <div class="newbt">
        <div>
            <a href="/DivisionAdd.aspx">
                <input type="button" id="add" value="创建赛区" />
            </a>
        </div>
    </div>
    <div class="list">
        <table class="listtb">
            <asp:Repeater ID="rpData" runat="server">
                <HeaderTemplate>
                    <%--标题头模板--%>
                    <tr>
                        <th>赛区</th>
                        <th>操作</th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <%--内容项模板--%>
                    <tr>
                        <td><%#Eval("DivisionName") %></td>
                        <td><a href="DivisionEdit.aspx?DivisionId=<%#Eval("DivisionId") %>">修改</a> | <a href="DivisionDelete.ashx?DivisionId=<%#Eval("DivisionId") %>" onclick="return confirm('确定删除?');">删除</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
