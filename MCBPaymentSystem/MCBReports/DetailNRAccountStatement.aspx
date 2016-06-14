<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="DetailNRAccountStatement.aspx.cs" Inherits="DetailNRAccountStatement"
    Title="Base Location Setup" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager id="SC1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="Label1" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
        Text="Detail NR Account Statement" Width="100%" SkinID="Heading"></asp:Label>
    <hr style="color: darkgray" />
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:Label ID="lblMessage" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align: right" class="TableColumns">
                From Date :&nbsp;
            </td>
            <td class="ColLines1">
                <asp:TextBox ID="txtFormDate" runat="server" Width="100px" MaxLength="12"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtFormDate"></asp:RequiredFieldValidator>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFormDate"
                    Enabled="True" PopupButtonID="txtDate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
            </td>
            <td style="text-align: right" class="TableColumns">
                To Date :</td>
            <td class="ColLines1">
                <asp:TextBox ID="txtToDate" runat="server" Width="100px" MaxLength="12"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtToDate"></asp:RequiredFieldValidator>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                    Enabled="True" PopupButtonID="txtDate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Search" Font-Size="10pt"
                    Font-Names="Verdana" Font-Bold="True"></asp:Button>
                <asp:Button ID="BtnExport" OnClick="BtnExport_Click" runat="server" Text="Export To Excel"
                    Font-Size="10pt" Font-Names="Verdana" Font-Bold="True"></asp:Button>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView Style="width: 100%" ID="GridView1" runat="server" Width="100%" Font-Size="8pt"
                    Font-Names="Verdana" AllowPaging="True" AllowSorting="False" AutoGenerateColumns="False"
                    PageSize="20" ShowFooter="True" EmptyDataText="No data found.">
                    <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
                        LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
                        NextPageText="Move Next" PageButtonCount="100" Position="TopAndBottom" PreviousPageImageUrl="~/Images/MovePrevious.gif"
                        PreviousPageText="Move Previous" Visible="False"></PagerSettings>
                    <Columns>
                        <asp:BoundField DataField="tdate" HeaderText="Date"></asp:BoundField>
                        <asp:BoundField DataField="account_no" HeaderText="Account No"></asp:BoundField>
                        <asp:BoundField DataField="company_code" HeaderText="Company Code"></asp:BoundField>
                        <asp:BoundField DataField="company_name" HeaderText="Company Name"></asp:BoundField>
                        <asp:BoundField DataField="description" HeaderText="Description"></asp:BoundField>
                        <asp:BoundField DataField="debit" HeaderText="Debit"></asp:BoundField>
                        <asp:BoundField DataField="credit" HeaderText="Credit"></asp:BoundField>
                        <asp:BoundField DataField="OpeningBalance" HeaderText="Opening Balance"></asp:BoundField>
                    </Columns>
                    <FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>
                    <PagerStyle BorderColor="#404040" HorizontalAlign="Left" BorderStyle="Solid"></PagerStyle>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
