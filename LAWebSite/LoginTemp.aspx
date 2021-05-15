<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginTemp.aspx.cs" Inherits="LoginTemp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Email: "></asp:Label><asp:TextBox ID="UserName" TextMode="Email" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
    <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Text="Rememeber me: "></asp:Label>
    <asp:CheckBox ID="rememberme" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>