<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DraftTransactionReportOld.aspx.cs" Inherits="DraftTransactionReportOld" MasterPageFile="~/MasterPage/RoutinePage.master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
  <ContentTemplate>
<DIV style="TEXT-ALIGN: left"><TABLE style="MARGIN: 0px; VERTICAL-ALIGN: top" class="air1" cellSpacing=0 width="100%"><TBODY><TR><TD colSpan=4>
<asp:Label id="Label1" runat="server" Font-Size="Large" SkinID="FormViewHeading" Text="Draft Printing" __designer:wfdid="w1" Width="100%"></asp:Label></TD></TR><TR>

<TD style="TEXT-ALIGN: center" colSpan=4>
<HR style="COLOR: darkgray" />
<asp:Label id="lblError" runat="server" CssClass="lblMessage"></asp:Label> </TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=4><asp:UpdateProgress id="UpdateProgress1" runat="server">
            <ProgressTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns" width="20%">Company Name :&nbsp; </TD><TD class="ColLines1" width="40%"><asp:DropDownList id="ddlCompanyCode" runat="server" __designer:wfdid="w3" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged"><asp:ListItem>All</asp:ListItem>
</asp:DropDownList></TD><TD class="ColLines1" width="5%">&nbsp;</TD><TD class="ColLines1">&nbsp;</TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">File Name :&nbsp; </TD><TD class="ColLines1"><asp:DropDownList id="ddlFile" runat="server" __designer:wfdid="w4" Width="355px" AutoPostBack="True"></asp:DropDownList></TD><TD class="ColLines1">&nbsp;</TD><TD class="ColLines1">&nbsp;</TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">Authorized Signature 1 :&nbsp;</TD><TD class="ColLines1"><asp:TextBox id="txtAuthorize1" runat="server" SkinID="TXT" __designer:wfdid="w5" Width="150px"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" __designer:wfdid="w32" ValidationGroup="DraftPrint" ToolTip="Proper value required" ControlToValidate="txtAuthorize1" ErrorMessage="*"></asp:RequiredFieldValidator></TD><TD style="TEXT-ALIGN: right" class="TableColumns">IBC : </TD><TD class="ColLines1"><asp:TextBox id="txtIBC1" runat="server" SkinID="TXT" __designer:wfdid="w7" Width="75px"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" __designer:wfdid="w34" ValidationGroup="DraftPrint" ToolTip="Proper value required" ControlToValidate="txtIBC1" ErrorMessage="*"></asp:RequiredFieldValidator></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">Authorized&nbsp;Signature 2 :&nbsp; </TD><TD class="ColLines1"><asp:TextBox id="txtAuthorize2" runat="server" SkinID="TXT" __designer:wfdid="w6" Width="150px"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" __designer:wfdid="w33" ValidationGroup="DraftPrint" ToolTip="Proper value required" ControlToValidate="txtAuthorize2" ErrorMessage="*"></asp:RequiredFieldValidator></TD><TD style="TEXT-ALIGN: right" class="TableColumns">IBC :</TD><TD class="ColLines1"><asp:TextBox id="txtIBC2" runat="server" SkinID="TXT" __designer:wfdid="w8" Width="75px"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" __designer:wfdid="w35" ValidationGroup="DraftPrint" ToolTip="Proper value required" ControlToValidate="txtIBC2" ErrorMessage="*"></asp:RequiredFieldValidator></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">Payees Account :&nbsp; </TD><TD class="ColLines1"><asp:TextBox id="txtPayeesAccount" runat="server" SkinID="TXT" __designer:wfdid="w120" Width="194px"></asp:TextBox></TD><TD class="ColLines1">&nbsp;</TD><TD class="ColLines1">&nbsp;</TD></TR><TR><TD style="TEXT-ALIGN: right" class="ColLines1">&nbsp;</TD><TD class="ColLines1"><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" __designer:wfdid="w9" Width="75px" ValidationGroup="DraftPrint"></asp:Button>&nbsp;<asp:Button id="btnFilePrintMark" onclick="btnFilePrintMark_Click" runat="server" Text="File Print Mark" __designer:wfdid="w1"></asp:Button></TD><TD class="ColLines1">&nbsp;</TD><TD class="ColLines1">&nbsp;</TD></TR></TBODY></TABLE></DIV>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

