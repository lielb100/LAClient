<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserFullPageProfile.ascx.cs" Inherits="UserFullPageProfile" %>
<asp:Image ID="ProImage" runat="server" />
<br />
<asp:Label ID="InfoLabel" runat="server"></asp:Label>
<br />
<asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
<asp:Label ID="NameLabel" runat="server"></asp:Label>
<br />
<asp:Label ID="Label3" runat="server" Text="Age: " /></asp:Label>
<asp:Label ID="AgeLabel" runat="server"></asp:Label>
<br />
<asp:Label ID="Label7" runat="server" Text="Sex: "></asp:Label>
<asp:Label ID="SexLable" runat="server"></asp:Label>
<br />
<asp:Label ID="Label13" runat="server" Text="intersted in:"></asp:Label>
<asp:Label ID="InteLabel" runat="server"></asp:Label>
<br />
<asp:Label ID="Label11" runat="server" Text="Top values: "></asp:Label>
<asp:Label ID="ValLabel" runat="server"></asp:Label>
<br />
<asp:Button ID="Button1" runat="server" Text="<%forunf %>" OnClick="Button1_Click" />