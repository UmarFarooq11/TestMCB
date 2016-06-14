<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChequePrintingReport.aspx.cs"
    Inherits="ChequePrintingReport" MasterPageFile="~/MasterPage/RoutinePage.master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <contenttemplate>
<TABLE class="air1" cellSpacing=0 width="100%"><TBODY><TR><TD style="WIDTH: 1%"></TD><TD><asp:Label id="Label_HEAD" runat="server" SkinID="FormViewHeading" Width="100%" Text="Cheque Printing" Font-Size="20pt" Font-Names="Trebuchet MS"></asp:Label></TD><TD style="WIDTH: 1%"></TD></TR><TR><TD colSpan=3><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="75px" Text="Search" ValidationGroup="DraftPrint"></asp:Button> 
<HR style="COLOR: darkgray" />
<TABLE style="MARGIN: 0px; VERTICAL-ALIGN: top" class="air" cellSpacing=0 width="100%"><TBODY><TR><TD colSpan=4><asp:Label id="lblError" runat="server" CssClass="lblMessage"></asp:Label> </TD></TR><TR><TD colSpan=4><asp:UpdateProgress id="UpdateProgress1" runat="server">
            <ProgressTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress> </TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns" width="20%">Company Name :&nbsp; </TD><TD class="ColLines" width="40%"><asp:DropDownList id="ddlCompanyCode" runat="server" Width="355px" __designer:wfdid="w3" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem>All</asp:ListItem>
</asp:DropDownList></TD><TD width="5%"></TD><TD class="ColLines"></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">File Name :&nbsp; </TD><TD class="ColLines"><asp:DropDownList id="ddlFile" runat="server" Width="355px" __designer:wfdid="w4" AutoPostBack="True">
</asp:DropDownList></TD><TD></TD><TD class="ColLines"></TD></TR><TR><TD style="COLOR: red; TEXT-ALIGN: right" class="TableColumns">Authorized Signature 1 :&nbsp;</TD><TD class="ColLines"><asp:TextBox id="txtAuthorize1" runat="server" SkinID="TXT" Width="150px" __designer:wfdid="w5">
</asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="DraftPrint" __designer:wfdid="w28" ToolTip="Proper value required" ControlToValidate="txtAuthorize1" ErrorMessage="*"></asp:RequiredFieldValidator></TD><TD style="COLOR: red; TEXT-ALIGN: right" class="TableColumns">IBC : </TD><TD class="ColLines"><asp:TextBox id="txtIBC1" runat="server" SkinID="TXT" Width="75px" __designer:wfdid="w7">
</asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ValidationGroup="DraftPrint" __designer:wfdid="w30" ToolTip="Proper value required" ControlToValidate="txtIBC1" ErrorMessage="*"></asp:RequiredFieldValidator></TD></TR><TR><TD style="COLOR: red; TEXT-ALIGN: right" class="TableColumns">Authorized&nbsp;Signature 2 :&nbsp; </TD><TD class="ColLines"><asp:TextBox id="txtAuthorize2" runat="server" SkinID="TXT" Width="150px" __designer:wfdid="w6"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="DraftPrint" __designer:wfdid="w29" ToolTip="Proper value required" ControlToValidate="txtAuthorize2" ErrorMessage="*"></asp:RequiredFieldValidator></TD><TD style="COLOR: red; TEXT-ALIGN: right" class="TableColumns">IBC :</TD><TD class="ColLines"><asp:TextBox id="txtIBC2" runat="server" SkinID="TXT" Width="75px" __designer:wfdid="w8"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ValidationGroup="DraftPrint" __designer:wfdid="w31" ToolTip="Proper value required" ControlToValidate="txtIBC2" ErrorMessage="*"></asp:RequiredFieldValidator></TD></TR><TR><TD style="TEXT-ALIGN: right"></TD><TD></TD><TD></TD><TD></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
