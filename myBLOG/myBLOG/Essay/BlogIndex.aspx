<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlogIndex.aspx.cs" Inherits="myBLOG.BlogIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="NewsList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="5">
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        <asp:Calendar ID="BlogCalendar" runat="server" DayNameFormat="Shortest"></asp:Calendar>
        <asp:DataList ID="ClassList" runat="server">
        </asp:DataList>
        <asp:DataList ID="cmdList" runat="server">
        </asp:DataList>
    </form>
</body>
</html>
