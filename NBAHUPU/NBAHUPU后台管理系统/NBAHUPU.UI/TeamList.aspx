<%@ Page Title="球队信息管理" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TeamList.aspx.cs" Inherits="NBAHUPU.UI.TeamList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="titlebar">
        <div>球队信息管理</div>
    </div>
    <div class="toolbox">
        <div>联盟：<asp:DropDownList ID="ddlAssociation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAssociation_SelectedIndexChanged"></asp:DropDownList></div>
        <div>赛区：<asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList></div>
    </div>
    <div class="newbt">
        <div>
            <a href="/TeamAdd.aspx">
                <input type="button" id="add" value="创建球队" />
            </a>
        </div>
    </div>
    <div class="list">
        <table class="listtb">
            <asp:Repeater ID="rpData" runat="server">
                <HeaderTemplate>
                    <%--标题头模板--%>
                    <tr>
                        <th>球队</th>
                        <th>操作</th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <%--内容项模板--%>
                    <tr>
                        <td><%#Eval("TeamName") %></td>
                        <td><a href="TeamEdit.aspx?TeamId=<%#Eval("TeamId") %>">修改</a> | <a href="TeamDelete.ashx?TeamId=<%#Eval("TeamId") %>" onclick="return confirm('确定删除?');">删除</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
