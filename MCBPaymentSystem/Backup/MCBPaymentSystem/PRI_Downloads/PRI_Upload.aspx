<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="PRI_Upload.aspx.cs" Inherits="PRI_Upload" Title="SPDS - PRI-Upload" %>

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
                            <tbody>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="PRI Upload Rejection"
                                            Font-Size="Large"></asp:Label>
                                        <table style="font-size: 8pt; font-family: Verdana" class="air" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr>
                                                    <td style="text-align: left" class="ColLines" colspan="2">
                                                        <asp:Button ID="btnGenerate" TabIndex="8" OnClick="btnGenerate_Click" runat="server"
                                                            Width="79px" Text="Upload" Font-Bold="True"></asp:Button>
                                                        <asp:Button ID="btnRefresh" TabIndex="8" OnClick="btnRefresh_Click" runat="server" Width="79px"
                                                            Text="Refresh" Font-Bold="True"></asp:Button>&nbsp;<asp:Button ID="btn_LIST" OnClick="btn_LIST_Click"
                                                                runat="server" Text="List" Font-Bold="True" Visible="False"></asp:Button>&nbsp;</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <hr style="color: darkgray" />
                                        <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr align="right">
                                                    <td style="width: 15%; color: red; text-align: center" colspan="2">
                                                        <asp:Label ID="lbl_Message" runat="server" CssClass="lblMessage"></asp:Label>
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr align="right">
                                                </tr>
                                                <tr align="right">
                                                </tr>
                                            </tbody>
                                        </table>
                                        <table style="font-size: 8pt; font-family: Verdana" class="air" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 15%; color: red; text-align: right" class="ColLines1">
                                                        File Name :</td>
                                                    <td style="width: 35%; text-align: left" class="ColLines">
                                                        &nbsp;
                                                        <asp:DropDownList ID="TXT_Description" runat="server" Width="300px">
                                                        </asp:DropDownList></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <br />
                                        <asp:GridView ID="GridView1" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana"
                                            DataSourceID="ObjRPS_DATA">
                                            <Columns>
                                                <asp:BoundField DataField="Uploaded_File_Name" HeaderText="Uploaded File Name" SortExpression="Uploaded_File_Name">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="No_of_Rejections" HeaderText="No. of Rejections" SortExpression="No_of_Rejections">
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <hr style="color: gainsboro" />
                        <asp:ObjectDataSource ID="ObjRPS_DATA" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="PRIUploadedFileList" TypeName="LOV_COLLECTION"></asp:ObjectDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
