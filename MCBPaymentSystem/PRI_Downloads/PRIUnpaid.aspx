<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeFile="PRIUnpaid.aspx.cs" Inherits="PRIUnpaid"
    Title="MCB - Bank Identification" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
      function funConfirm()
      {
        var a = confirm('Are you sure to Execute?');
        if (a == true)
        {
         return true;
        }
        else
        {
         return false;
        }
      }
    </script>

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
                                    <asp:Label ID="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="PRI Transaction for Unpaid"
                                        Font-Size="Large"></asp:Label>
                                    <hr style="color: darkgray" />
                                    <table>
                                        
                                        <tr>
                                            <td colspan="2" style="font-weight: bold; width: 25%; text-align: right">
                                            </td>
                                            <td width="60%">
                                                &nbsp;&nbsp;<asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                    <ProgressTemplate>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="font-weight: bold; width: 25%; text-align: right">
                                            </td>
                                            <td width="60%">
                                                <asp:Label ID="lbl_msg" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="TableColumns" style="font-weight: bold; width: 25%; text-align: right"
                                                colspan="2">
                                                Customer Ref No. :&nbsp;
                                            </td>
                                            <td class="ColLines1" width="60%">
                                                &nbsp;<asp:TextBox ID="txtCustRefno" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="TableColumns" style="font-weight: bold; width: 25%; text-align: right"
                                                colspan="2">
                                                XPIN :&nbsp;
                                            </td>
                                            <td class="ColLines1" width="60%">
                                                &nbsp;<asp:TextBox ID="txtDraftno" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="font-weight: bold; width: 25%; text-align: right">
                                            </td>
                                            <td class="ColLines1" width="60%">
                                                <asp:Button ID="btnFetch" OnClick="btnFetch_Click" runat="server" Width="100px" Text="Fetch"
                                                    Font-Bold="True"></asp:Button>
                                                <asp:Button ID="btnUnpaid" OnClick="btnUnpaid_Click" runat="server" Width="100px"
                                                    Text="Unpaid" Font-Bold="True" Visible="False"></asp:Button>&nbsp;<asp:Button ID="btnAuthorized"
                                                        runat="server" Font-Bold="True" OnClick="btnAuthorized_Click" Text="Authorize"
                                                        Visible="False" Width="100px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="font-size: 8pt; font-family: Verdana" class="air" cellspacing="0" width="100%">
                                        <tr>
                                            <td colspan="5">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                                                    OnSorting="GridView1_Sorting" EmptyDataText="Data not found">
                                                    <Columns>
                                                        <asp:BoundField DataField="rowid" HeaderText="rowid">
                                                            <ControlStyle CssClass="hidden" />
                                                            <FooterStyle CssClass="hidden" />
                                                            <HeaderStyle CssClass="hidden" />
                                                            <ItemStyle CssClass="hidden" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="company_code" HeaderText="Company" />
                                                        <asp:BoundField DataField="correspondingbankid" HeaderText="Bank" />
                                                        <asp:BoundField DataField="draftamount" HeaderText="Amount" />
                                                        <asp:BoundField DataField="draftno" HeaderText="XPIN / Draft no" />
                                                        <asp:BoundField DataField="custrefnumber" HeaderText="Customer Ref No" />
                                                        <asp:BoundField DataField="draftdate" HeaderText="Draft Date" />
                                                        <asp:BoundField DataField="trans_type" HeaderText="Transaction Type" />
                                                        <asp:BoundField DataField="paid_date" HeaderText="Paid Date" />
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblstatus" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle Font-Size="30pt" ForeColor="LightSteelBlue" HorizontalAlign="Center"
                                                        VerticalAlign="Middle" />
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
