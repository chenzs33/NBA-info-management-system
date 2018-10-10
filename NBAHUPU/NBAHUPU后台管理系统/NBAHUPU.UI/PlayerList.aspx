<%@ Page Title="球员信息管理" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PlayerList.aspx.cs" Inherits="NBAHUPU.UI.PlayerList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="titlebar">
        <div>球员信息管理</div>
    </div>
    <div class="toolbox">
        <div>联盟：<asp:DropDownList ID="ddlAssociation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAssociation_SelectedIndexChanged"></asp:DropDownList></div>
        <div>赛区：<asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList></div>
        <div>球队：<asp:DropDownList ID="ddlTeam" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTeam_SelectedIndexChanged"></asp:DropDownList></div>
    </div>
    <div class="newbt">
        <div>
            <a href="/PlayerAdd.aspx">
                <input type="button" id="add" value="创建球员" />
            </a>
        </div>
    </div>
    <div class="list">
        <table class="listtb">
            <asp:Repeater ID="rpData" runat="server">
                <HeaderTemplate>
                    <%--标题头模板--%>
                    <tr>
                        <th>号码</th>
                        <th>姓名</th>
                        <th>英文名</th>
                        <th>年龄</th>
                        <th>出生日期</th>
                        <th>身高(cm)</th>
                        <th>体重(kg)</th>
                        <th>位置</th>
                        <th>操作</th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <%--内容项模板--%>
                    <tr>
                        <td><%#Eval("PlayerNo") %></td>
                        <td><%#Eval("PlayerName") %></td>
                        <td><%#Eval("PlayerEngName") %></td>
                        <td><%#Eval("Age") %></td>
                        <td><%#Eval("Birthday") %></td>
                        <td><%#Eval("Height") %></td>
                        <td><%#Eval("Weight") %></td>
                        <td><%#Eval("Location") %></td>
                        <td><a href="PlayerEdit.aspx?PlayerNo=<%#Eval("PlayerNo") %>">修改</a> | <a href="PlayerDelete.ashx?PlayerNo=<%#Eval("PlayerNo") %>" onclick="return confirm('确定删除?');">删除</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <br />
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页" PrevPageText="上一页" NextPageText="下一页" AlwaysShow="True" LayoutType="Table" OnPageChanging="AspNetPager1_PageChanging" PageSize="5"></webdiyer:AspNetPager>
    </div>
</asp:Content>
