<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SSO_Control.ascx.cs" Inherits="MasterPage_SSO_Control" %>
<asp:TreeView ID="TV1" runat="server" NodeWrap="True"
    OnSelectedNodeChanged="TV1_SelectedNodeChanged" Style="font-size: 10pt; color: blue;
    font-family: Arial, Tahoma; height: 100%; vertical-align: top;" Width="100%" ExpandDepth="1" Font-Bold="True" Font-Names="Arial,Tahoma" Font-Size="8pt" BackColor="Transparent" ShowLines="True" BorderColor="Black" BorderStyle="None" BorderWidth="1px">
    <HoverNodeStyle BackColor="Yellow" />
</asp:TreeView>

