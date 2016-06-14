<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="PRCReport.aspx.cs" Inherits="PRCReport" Title="PRC REPORT" %>

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
                            <asp:Label ID="lbl_Heading" runat="server" CssClass="lblHeading" Font-Size="Large"
                                SkinID="FormViewHeading" Width="100%" Text="PRC Report"></asp:Label>
                            <asp:Button ID="btn_OK" OnClick="btn_OK_Click" runat="server" Width="78px" Text="Generate"
                                Font-Bold="True" ValidationGroup="GP"></asp:Button>
                            <hr style="color: darkgray" />
                            <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                <tbody>
                                    <tr align="right">
                                        <td style="font-weight: bold; color: red; text-align: center" class="TableColumns"
                                            colspan="4">
                                            <asp:Label ID="lblmessage" runat="server" CssClass="lblMessage"></asp:Label>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                <ProgressTemplate>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td style="font-weight: bold; width: 20%; text-align: right" class="TableColumns"
                                            colspan="2">
                                            Transaction Ref. No. :</td>
                                        <td style="font-weight: bold; width: 30%; color: red; text-align: left" class="TableColumns"
                                            colspan="1">
                                            &nbsp;<asp:TextBox ID="TXT_REF_NO" runat="server" Width="183px" MaxLength="50"></asp:TextBox></td>
                                        <td style="font-weight: bold; width: 30%; color: black; text-align: left" class="TableColumns"
                                            colspan="1">
                                            &nbsp;</td>
                                    </tr>
                                    <tr align="right">
                                        <td class="TableColumns" colspan="2" style="font-weight: bold; width: 20%; text-align: right">
                                            Account No. :
                                        </td>
                                        <td class="TableColumns" colspan="1" style="font-weight: bold; width: 30%; color: red;
                                            text-align: left">
                                            &nbsp;<asp:TextBox ID="TXT_ACC_NO" runat="server" Width="183px" MaxLength="50"></asp:TextBox></td>
                                        <td class="TableColumns" colspan="1" style="font-weight: bold; width: 30%; color: black;
                                            text-align: left">
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td class="TableColumns" colspan="2" style="font-weight: bold; width: 20%; text-align: right">
                                            From Date :</td>
                                        <td class="TableColumns" colspan="1" style="font-weight: bold; width: 30%; color: red;
                                            text-align: left">
                                            &nbsp;<asp:TextBox ID="txt_from_date" runat="server" MaxLength="50" Width="133px"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" PopupButtonID="txt_from_date"
                                                TargetControlID="txt_from_date">
                                            </cc1:CalendarExtender>
                                        </td>
                                        <td style="font-weight: lighter; width: 30%; color: Blue; text-align: left" class="TableColumns"
                                            colspan="1">
                                            &nbsp; DD-MM-YYYY
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td class="TableColumns" colspan="2" style="font-weight: bold; width: 20%; text-align: right">
                                            To Date :</td>
                                        <td class="TableColumns" colspan="1" style="font-weight: bold; width: 30%; color: red;
                                            text-align: left">
                                            &nbsp;<asp:TextBox ID="txt_to_date" runat="server" MaxLength="50" Width="133px"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" PopupButtonID="txt_to_date"
                                                TargetControlID="txt_to_date">
                                            </cc1:CalendarExtender>
                                        </td>
                                         <td style="font-weight: lighter; width: 30%; color: Blue; text-align: left" class="TableColumns"
                                            colspan="1">
                                            &nbsp; DD-MM-YYYY
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td style="font-weight: bold; width: 20%; text-align: right" class="TableColumns"
                                            colspan="2">
                                            Purpose of Remittance :</td>
                                        <td style="font-weight: bold; width: 30%; color: red; text-align: left" class="TableColumns"
                                            colspan="1">
                                            &nbsp;<asp:TextBox ID="TXT_PURP_REMET" runat="server" Width="350px"></asp:TextBox></td>
                                        <td style="font-weight: lighter; width: 30%; color: Blue; text-align: left" class="TableColumns"
                                            colspan="1">
                                            &nbsp; Purpose of Remittance;Schedule
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td class="TableColumns" colspan="2" style="font-weight: bold; width: 20%; text-align: right">
                                            Bank \ Branch Name :&nbsp;
                                        </td>
                                        <td class="TableColumns" colspan="1" style="font-weight: bold; width: 30%; color: red;
                                            text-align: left">
                                            &nbsp;<asp:TextBox ID="txt_bank_name" runat="server" Height="53px" TextMode="MultiLine"
                                                Width="350px"></asp:TextBox></td>
                                        <td class="TableColumns" colspan="1" style="font-weight: lighter; width: 30%; color: blue;
                                            text-align: left">
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
