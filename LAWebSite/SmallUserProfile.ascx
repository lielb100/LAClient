<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SmallUserProfile.ascx.cs" Inherits="SmallUserProfile" %>
<asp:Image ID="Image1" runat="server" CssClass="avatar" />
<asp:Label ID="namelabel" runat="server"></asp:Label>
<asp:Label ID="agelabel" runat="server"></asp:Label>
<asp:Label ID="infolabel" runat="server"></asp:Label>
<asp:Button ID="FollowButton" runat="server" OnClick="Button1_Click" />