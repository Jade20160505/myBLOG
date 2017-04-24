<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="myBLOG._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" rel="stylesheet" href="Style/default.css" />
    <div class="u-content">
        <div class="ucenter-column">
            <ul class="ucenter-column-block">
                <li><a href="Essay/BlogIndex.aspx"><i class="icon-essay">推荐文章</i></a></li>
                <li><a href="#"><i class="icon-book">推荐书籍</i></a></li>
                <li><a href="#"><i class="icon-music">推荐音乐</i></a></li>
                <li><a href="#"><i class="icon-myPlace">我的地盘</i></a></li>
            </ul>
        </div>
    </div>

</asp:Content>
