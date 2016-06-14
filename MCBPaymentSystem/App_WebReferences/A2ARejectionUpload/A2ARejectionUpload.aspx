<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true" CodeFile="A2ARejectionUpload.aspx.cs" Inherits="A2ARejectionUpload" Title="A2A Rejection Upload" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
                <asp:Label ID="Label1" runat="server" Font-Size="Large" SkinID="FormViewHeading"
                    Text="A2A Rejection Upload" Width="100%"></asp:Label>
                <table cellspacing="0" class="login" width="100%">
                    <tbody>
                        <tr>
                            <td>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Process" Font-Bold="True" /></td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%">
                    <tbody>
                        <tr align="right">
                            <td class="ColLines1" colspan="2" style="font-weight: bold; width: 15%; color: red;
                                height: 19px; text-align: center">
                                <asp:Label ID="lbl_Message" runat="server" CssClass="lblMessage"></asp:Label>&nbsp;
                            </td>
                        </tr>
                        <tr align="right">
                        </tr>
                        <tr align="right">
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" class="air" style="font-size: 8pt; font-family: Verdana" width="100%">
                    <tbody>
                        <tr align="right">
                            <td class="ColLines1" style="font-weight: bold; width: 30%; text-align: right">
                                File Name :
                            </td>
                            <td class="ColLines" colspan="2" style="text-align: left; width: 70%;"><asp:DropDownList id="DropDownList1" runat="server" Width="300px"></asp:DropDownList></td>
                        </tr>
                        <tr align="right">
                        </tr>
                        <tr align="right">
                        </tr>
                    </tbody>
                </table></contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

