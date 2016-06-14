<%@ Page Language="C#" AutoEventWireup="true" CodeFile="11CompanyBalanceReport.aspx.cs" Inherits="CompanyBalanceReport"  MasterPageFile="~/MasterPage/RoutinePage.master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<rsweb:reportviewer id="ReportViewer1" runat="server" width="100%" ZoomMode="FullPage" Height="700px"></rsweb:reportviewer>
</asp:Content>

