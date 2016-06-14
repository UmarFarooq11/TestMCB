<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="PRIDownloadIBAN.aspx.cs" Inherits="PRIDownloadIBAN" Title="MCB - PRI-Download IBAN" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
function funConfirm()
{
    var a = confirm('Are you sure to you want to excute?');
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
            <td colspan="2">
                &nbsp;<asp:Label ID="Label1" runat="server" Font-Size="Large" SkinID="FormViewHeading"
                    Text="PRI Download" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Label ID="lblMessage" runat="server" CssClass="lblMessage"></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Button ID="btnFetch" OnClick="btnFetch_Click" runat="server" Text="Fetch PRI Data"
                    Width="200px" Font-Bold="True"></asp:Button></td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="height: 200px; overflow: auto">
                    <asp:GridView ID="GridView1" runat="server" Font-Size="8pt" Width="100%" EmptyDataText="Data not found"
                        AutoGenerateColumns="False" Font-Names="Verdana">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Ref. Bank Code" SortExpression="ID"></asp:BoundField>
                            <asp:BoundField DataField="BankCode" HeaderText="Bank Code" SortExpression="BankCode">
                            </asp:BoundField>
                            <asp:BoundField DataField="BankName" HeaderText="Bank Name" SortExpression="BankName">
                            </asp:BoundField>
                            <asp:BoundField DataField="Total_Amount" HeaderText="Total Amount" SortExpression="Total_Amount">
                            </asp:BoundField>
                            <asp:BoundField DataField="No_of_Transactions" HeaderText="No. of Transactions" SortExpression="No_of_Transactions">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    &nbsp;<asp:LinkButton ID="btnPaid" runat="server" OnClick="btnPaid_Click" OnClientClick="return funConfirm();">Paid</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText = "Status">
                                <ItemTemplate>
                                    <asp:Label ID = "lblstatus" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle Font-Size="30pt" ForeColor="LightSteelBlue" HorizontalAlign="Center"
                            VerticalAlign="Middle" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <progresstemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting17.gif"></asp:Image>
        </progresstemplate>
    </asp:UpdateProgress>--%>
    <table cellspacing="0" class="air1" width="100%" style="font-size: 8pt; font-family: Verdana;
        margin-top: 100px;">
        <tr>
            <td colspan="2">
                <strong>&nbsp;Download File </strong>
            </td>
        </tr>
        <tr>
            <td class="TableColumns" style="text-align: right">
                PRI File :</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlFile" runat="server" Width="254px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Button ID="btnDownload" OnClick="btnDownload_Click" runat="server" Text="Download"
                    Width="126px" Font-Bold="True"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
