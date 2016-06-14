<%@ Page Language="C#" Theme="ColorSchemeBlue" MasterPageFile="~/MasterPage/RoutinePage.master"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="DraftCancellation.aspx.cs"
    Inherits="DraftCancellaion_DraftCancellation" Title="Draft Cancellaion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../WebControls/AlphaSelection.ascx" TagName="AlphaSelection" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="Label1" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
        Text="Draft Cancellation" Width="100%" SkinID="Heading"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <ajaxToolkit:TabContainer Style="font-size: 8pt; font-family: Verdana" ID="TabContainer1"
                runat="server" Font-Size="8pt" Font-Names="Verdana" CssClass="ajax__tab_xp1"
                BackColor="#FFFFEE" ActiveTabIndex="0">
                <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="TabPanel1">
                    <ContentTemplate>
                        <table style="font-size: 8pt; font-family: Verdana" width="100%">
                            <tbody>
                                <tr align="right">
                                    <td style="width: 25%; text-align: right">
                                        Draft No:</td>
                                    <td style="width: 25%; text-align: left">
                                        <asp:TextBox ID="TXT_DraftNo" runat="server" MaxLength="15" SkinID="TXT" 
                                            Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="width: 25%; text-align: right">
                                        Customer Ref No. :</td>
                                    <td style="width: 25%; text-align: left">
                                        &nbsp;<asp:TextBox ID="TXT_CustRefNo" runat="server" SkinID="TXT" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="width: 25%; text-align: right">
                                        Company Code :</td>
                                    <td style="width: 25%; text-align: left">
                                        <asp:TextBox ID="txt_company_code" runat="server" SkinID="TXT" Width="200px"></asp:TextBox>
                                    </td>
                                    <td style="width: 25%; text-align: right">
                                    </td>
                                    <td style="width: 25%; text-align: left">
                                        &nbsp;</td>
                                </tr>
                                <tr align="right">
                                    <td style="text-align: right" colspan="4">
                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <HeaderTemplate>
                        Basic Search
                    </HeaderTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
            <table cellspacing="0" width="100%">
                <tbody>
                    <tr>
                        <td style="width: 240px">
                            <asp:Button ID="BTN_SEARCH" OnClick="BTN_SEARCH_Click" runat="server" Text="Search"
                                Font-Size="10pt" Font-Names="Verdana" Font-Bold="True"></asp:Button>
                            <asp:Button ID="BTN_CLEAR" OnClick="BTN_CLEAR_Click" runat="server" Text="Clear"
                                Font-Size="10pt" Font-Names="Verdana" Font-Bold="True"></asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="Data not found">
                            <Columns>
                                <asp:BoundField DataField="rowid" HeaderText="rowid">
                                    <ControlStyle CssClass="hidden" />
                                    <FooterStyle CssClass="hidden" />
                                    <HeaderStyle CssClass="hidden" />
                                    <ItemStyle CssClass="hidden" />
                                </asp:BoundField>
                                <asp:BoundField DataField="draftno" HeaderText="Draft No" />
                                <asp:BoundField DataField="draftdate" HeaderText="Draft Date" />
                                <asp:BoundField DataField="draftamount" HeaderText="Amount" />
                                <asp:BoundField DataField="company_code" HeaderText="Company Code" />
                                <asp:BoundField DataField="company_name" HeaderText="Company Name" />
                                <asp:BoundField DataField="rem_name" HeaderText="Remitter Name" />
                                <asp:BoundField DataField="ben_name" HeaderText="Bene Name" />
                                <asp:BoundField DataField="customerref" HeaderText="Customer Ref No." />
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Select" ImageUrl="~/Images/edit1.gif"
                                            OnClick="ImageButton1_Click" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle Font-Size="30pt" ForeColor="LightSteelBlue" HorizontalAlign="Center"
                                VerticalAlign="Middle" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
