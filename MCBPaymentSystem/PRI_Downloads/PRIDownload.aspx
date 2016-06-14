<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="PRIDownload.aspx.cs" Inherits="PRIDownload" Title="SPDS - PRI-Download" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table cellspacing="0" width="100%">
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="PRI Download"
                                        Font-Size="Large"></asp:Label>
                                    <hr style="color: darkgray" />
                                    <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                        <tr align="right">
                                            <td style="font-weight: bold; width: 15%; color: red; height: 19px; text-align: center"
                                                colspan="2">
                                                <asp:Label ID="lbl_Message" runat="server" CssClass="lblMessage"></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                        </tr>
                                        <tr align="right">
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GridView1" runat="server" Width="100%" Font-Size="8pt" DataSourceID="ObjRPS_DATA"
                                        Font-Names="Verdana" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                        DataKeyNames="BankCode" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="ID" HeaderText="Ref. Bank Code" SortExpression="ID"></asp:BoundField>
                                            <asp:BoundField DataField="BankCode" HeaderText="Bank Code" SortExpression="BankCode">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BankName" HeaderText="Bank Name" SortExpression="BankName">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Total_Amount" HeaderText="Total Amount" SortExpression="Total_Amount">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="No_of_Transactions" HeaderText="No. of Transactions"
                                                SortExpression="No_of_Transactions"></asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" runat="server" ImageUrl="~/Images/edit1.gif"
                                                        CommandName="Select"></asp:ImageButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <hr style="color: gainsboro" />
                        <asp:ObjectDataSource ID="ObjRPS_DATA" runat="server" TypeName="LOV_COLLECTION" SelectMethod="GetPRIDataFoDownload"
                            OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <table style="font-size: 8pt; font-family: Verdana" class="air" cellspacing="0" width="100%">
                <tr align="right">
                    <td style="width: 35%; text-align: center" class="ColLines">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting17.gif"></asp:Image></td>
                </tr>
                <tr align="right">
                </tr>
                <tr align="right">
                </tr>
            </table>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
