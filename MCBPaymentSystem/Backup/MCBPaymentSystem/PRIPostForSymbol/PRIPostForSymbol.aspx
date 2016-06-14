<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeFile="PRIPostForSymbol.aspx.cs" Inherits="PRIPostForSymbol"
    Title="MCB - Bank Identification" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td style="width: 1%">
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="PRI Transaction Post on Core Banking"
                                        Font-Size="Large"></asp:Label>
                                    <hr style="color: darkgray" />
                                    <asp:Label ID="lbl_msg" runat="server"></asp:Label>
                                    <table>
                                        <tr>
                                            <td class="TableColumns" style="font-weight: bold; width: 25%; text-align: right"
                                                colspan="2">
                                                Company :&nbsp;
                                            </td>
                                            <td class="ColLines1" width="60%">
                                                <asp:DropDownList ID="ddlCompanyCode" runat="server" Width="250px" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td class="TableColumns" style="font-weight: bold; width: 25%; text-align: right"
                                                colspan="2">
                                                Bank :&nbsp;
                                            </td>
                                            <td class="ColLines1" width="60%">
                                                <asp:DropDownList ID="ddlBank" runat="server" Width="250px" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td  colspan="2" style="font-weight: bold; width: 25%; text-align: right">
                                            </td>
                                            <td class="ColLines1" width="60%">
                                                <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Width="100px"
                                                    Text="Search" Font-Bold="True" ValidationGroup="search" CssClass="btnSearch"></asp:Button>
                                                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Width="100px"
                                                    Text="Submit" Font-Bold="True" CssClass="btnSearch"></asp:Button></td>
                                        </tr>
                                     
                                    </table>
                                    <table style="font-size: 8pt; font-family: Verdana" class="air" cellspacing="0" width="100%">
                                        <tr>
                                            <td colspan="5">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnSorting="GridView1_Sorting">
                                                    <Columns>
                                                        <asp:BoundField DataField="company_code" HeaderText="Company" />
                                                        <asp:BoundField DataField="XPIN" HeaderText="XPIN" />
                                                        <asp:BoundField DataField="custrefnumber" HeaderText="Customer Ref. No." />
                                                        <asp:BoundField DataField="bank_code" HeaderText="Bank" SortExpression="bank_code" />
                                                        <asp:BoundField DataField="amount" HeaderText="Amount" />
                                                        <asp:BoundField DataField="paid_date" HeaderText="Paid Date" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <hr style="color: gainsboro" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
