<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BankDraftReport.aspx.cs" Inherits="MCBReports_BankDraftReport" MasterPageFile="~/MasterPage/RoutinePage.master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
  <ContentTemplate>
<DIV style="TEXT-ALIGN: left"><TABLE style="MARGIN: 0px; VERTICAL-ALIGN: top" cellSpacing=0 width="100%"><TBODY><TR><TD colSpan=4><asp:Label id="lblError" runat="server" CssClass="lblMessage"></asp:Label> </TD></TR><TR><TD colSpan=4><asp:UpdateProgress id="UpdateProgress1" runat="server">
            <ProgressTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress></TD></TR><TR><TD style="TEXT-ALIGN: right" width="20%">Company Name :&nbsp; </TD><TD width="40%"><asp:DropDownList id="ddlCompanyCode" runat="server" Width="355px" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem>All</asp:ListItem>
</asp:DropDownList></TD><TD width="5%"></TD><TD></TD></TR><TR><TD style="TEXT-ALIGN: right">File Name :&nbsp; </TD><TD><asp:DropDownList id="ddlFile" runat="server" Width="355px" AutoPostBack="True"></asp:DropDownList></TD><TD><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="75px" ValidationGroup="DraftPrint" Text="Search"></asp:Button></TD><TD></TD></TR><TR><TD style="TEXT-ALIGN: right; height: 21px;"></TD><TD style="height: 21px"></TD><TD style="height: 21px"></TD><TD style="height: 21px"></TD></TR></TBODY></TABLE></DIV>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>



