<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="AccountStatementNRReport.aspx.cs" Inherits="AccountStatementNRReport"
    Title="NR Account Statement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
    <div style="text-align: left">
        <table cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lbl_Heading" runat="server" Text="NR Account Statement" Width="100%"
                                SkinID="FormViewHeading" Font-Size="Large" CssClass="lblHeading"></asp:Label>
                            <asp:Button ID="btn_OK" OnClick="btn_OK_Click" runat="server" Text="Generate" Width="78px"
                                ValidationGroup="GP" Font-Bold="True"></asp:Button>
                            <hr style="color: darkgray" />
                            <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                <tbody>
                                    <tr align="right">
                                        <td style="font-weight: bold; color: red; text-align: center" class="TableColumns"
                                            colspan="5">
                                            <asp:Label ID="lblmessage" runat="server" CssClass="lblMessage"></asp:Label>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                <ProgressTemplate>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td style="font-weight: bold; text-align: right" class="TableColumns" colspan="2">
                                            Company Name&nbsp; :&nbsp;
                                        </td>
                                        <td style="text-align: left" class="ColLines" colspan="1">
                                            &nbsp;<asp:DropDownList ID="ddlCompanyCode" runat="server" Width="300px">
                                            </asp:DropDownList></td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr align="right">
                                        <td class="TableColumns" colspan="2" style="font-weight: bold; text-align: right">
                                            From Date :
                                        </td>
                                        <td class="ColLines" colspan="1" style="text-align: left">
                                            &nbsp;<asp:TextBox ID="txtDate" runat="server" MaxLength="12" Width="100px"></asp:TextBox><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" Enabled="False"
                                                ErrorMessage="*" ValidationGroup="GP"></asp:RequiredFieldValidator>&nbsp; (DD-MON-YYYY)
                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate"
                                                PopupButtonID="txtDate" Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td class="TableColumns" colspan="2" style="font-weight: bold; text-align: right">
                                            To Date :</td>
                                        <td class="ColLines" colspan="1" style="text-align: left">
                                            &nbsp;<asp:TextBox ID="txtToDate" runat="server" MaxLength="12" Width="100px"></asp:TextBox><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate" Enabled="False"
                                                ErrorMessage="*" ValidationGroup="GP"></asp:RequiredFieldValidator>&nbsp;
                                            (DD-MON-YYYY)
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                                PopupButtonID="txtToDate" Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                        </td>
                                        <td >
                                        </td>
                                        <td class="ColLines" colspan="1" style="font-weight: bold; color: black; text-align: left"
                                            width="50%">
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td style="font-weight: bold; color: red; height: 26px; text-align: center" colspan="5">
                                        </td>
                                    </tr>
                                    <tr align="right">
                                    </tr>
                                    <tr align="right">
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
