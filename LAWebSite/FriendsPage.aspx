<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FriendsPage.aspx.cs" Inherits="FriendsPage" %>

<%@ Register Src="~/SmallUserProfile.ascx" TagPrefix="uc1" TagName="SmallUserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel2" CssClass="container" runat="server"></asp:Panel>

    <asp:Panel ID="Panel1" CssClass="container" runat="server"></asp:Panel>
</asp:Content>