<%@ Page Language="C#" Theme="ColorSchemeBlue" AutoEventWireup="true" CodeFile="ChecquePrintingReport.aspx.cs"
    Inherits="ChecquePrintingReport" MasterPageFile="~/MasterPage/RoutinePage.master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <contenttemplate>
<DIV style="TEXT-ALIGN: left">
<table cellspacing="0" class="air1" width="100%">
        <tr>
            <td style="width: 1%">
            </td>
            <td>
  <asp:Label ID="Label_HEAD" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
                            Text="Checque Printing Report" Width="100%" SkinID="FormViewHeading"></asp:Label>
                            </td>
            <td style="width: 1%">
            </td>
        </tr>
        <tr>
            <td colspan="3">
<TABLE style="MARGIN: 0px; VERTICAL-ALIGN: top" cellSpacing=0 width="100%"><TBODY><TR><TD colSpan=4><asp:Label id="lblError" runat="server" CssClass="lblMessage"></asp:Label> </TD></TR><TR><TD colSpan=4><asp:UpdateProgress id="UpdateProgress1" runat="server">
            <ProgressTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress> </TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns" width="20%">Company Name :&nbsp; </TD><TD width="40%"><asp:DropDownList id="ddlCompanyCode" runat="server" Width="355px" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem>All</asp:ListItem>
</asp:DropDownList></TD><TD width="5%"></TD><TD></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">File Name :&nbsp; </TD><TD><asp:DropDownList id="ddlFile" runat="server" Width="355px" AutoPostBack="True"></asp:DropDownList></TD><TD></TD><TD></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">Authorized Signature 1 :&nbsp;</TD><TD><asp:TextBox id="txtAuthorize1" runat="server" Width="150px"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ToolTip="Proper value required" ControlToValidate="txtAuthorize1" ErrorMessage="*" ValidationGroup="DraftPrint"></asp:RequiredFieldValidator></TD><TD style="TEXT-ALIGN: right" class="TableColumns">IBC : </TD><TD><asp:TextBox id="txtIBC1" runat="server" Width="75px"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ToolTip="Proper value required" ControlToValidate="txtIBC1" ErrorMessage="*" ValidationGroup="DraftPrint"></asp:RequiredFieldValidator></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">Authorized&nbsp;Signature 2 :&nbsp; </TD><TD><asp:TextBox id="txtAuthorize2" runat="server" Width="150px"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ToolTip="Proper value required" ControlToValidate="txtAuthorize2" ErrorMessage="*" ValidationGroup="DraftPrint"></asp:RequiredFieldValidator></TD><TD style="TEXT-ALIGN: right" class="TableColumns">IBC :</TD>
<TD><asp:TextBox id="txtIBC2" runat="server" Width="75px"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ToolTip="Proper value required" ControlToValidate="txtIBC2" ErrorMessage="*" ValidationGroup="DraftPrint"></asp:RequiredFieldValidator></TD></TR><TR><TD style="TEXT-ALIGN: right"></TD><TD><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="75px" ValidationGroup="DraftPrint" Text="Search"></asp:Button></TD><TD></TD><TD></TD></TR></TBODY></TABLE>
</td>
        </tr>
    </table>
</DIV>

</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
