<%@ Page Language="C#" Culture = "zh-HK" MasterPageFile="~/MasterPage/BoldMove.master" AutoEventWireup="true" CodeFile="StartupPage.aspx.cs" Inherits="MasterPage_StartupPage" Title="Main Page" %>
<%@ MasterType VirtualPath="~/MasterPage/BoldMove.master" %> 
<%@ Register Src="../WebControls/SSO_Control.ascx" TagName="SSO_Control" TagPrefix="uc1" %>
<%@ Register
Assembly="AjaxControlToolkit"
Namespace="AjaxControlToolkit"
TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<TABLE style="BACKGROUND-REPEAT: repeat-x; HEIGHT: 100%; BACKGROUND-COLOR: #f6f6f6" cellSpacing=0 width="100%"><TBODY><TR><TD style="BACKGROUND-IMAGE: url(../images/blue/bgBlueForm.gif); VERTICAL-ALIGN: top; WIDTH: 20%; BACKGROUND-REPEAT: repeat-x" vAlign=top><asp:Panel style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; VERTICAL-ALIGN: top; BORDER-TOP-STYLE: none; PADDING-TOP: 0px; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" id="Panel1" runat="server" BackColor="Transparent" BorderStyle="None" Width="100%" ScrollBars="Vertical" Height="600px"><uc1:SSO_Control id="SSO_Control1" runat="server" __designer:wfdid="w25"></uc1:SSO_Control></asp:Panel> </TD><TD style="VERTICAL-ALIGN: top; WIDTH: 70%"><IFRAME id="I1" src="" frameBorder="1" width="100%" scrolling=yes height=600 runat="server">
              </IFRAME></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
</asp:Content>


