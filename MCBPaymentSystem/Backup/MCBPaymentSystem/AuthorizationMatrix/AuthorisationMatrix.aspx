<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master"
    Theme="ColorSchemeBlue" AutoEventWireup="true" CodeFile="AuthorisationMatrix.aspx.cs"
    Inherits="AuthorizationMatrix_AuthorisationMatrix_" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" class="air1" align="right">
                <tr>
                    <td align="left">
                        <asp:Label ID="Label1" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
                            Text="Authorization Matrix" Width="100%" SkinID="FormViewHeading"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <td align="left" colspan="2">
                                    <asp:Button ID="BTN_INSERT" runat="server" Text="Insert" 
                                        OnClick="btnSave_Click" />
                                    <asp:Button ID="btnedit" runat="server" Text="Edit" OnClick="btnedit_Click" Visible="False" />
                                    <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" 
                                        Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" 
                                        OnClick="UpdateButton_Click" Text="Update" />
                                    <asp:Button ID="btnreset" runat="server" Text="Reset" 
                                        onclick="btnreset_Click" />
                                    <asp:Button ID="BTN_DELETE" runat="server" Enabled="false" Font-Bold="True" 
                                        Font-Names="Verdana" Font-Size="10pt" Text="Delete" Width="60px" />
                                    <asp:Button ID="btnreturn" runat="server" Text="Cancel" OnClick="btnreturn_Click" />
                                    <asp:Button ID="btnautho" runat="server" Text="Authorize" ToolTip="Authorize / UnAuthorize"
                                        OnClick="btnautho_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="lblmsg" runat="server" Font-Size="Smaller" Font-Bold="True" ForeColor="Red"
                                        __designer:wfdid="w2"></asp:Label>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Company Name:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlcompany" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged"
                                        Width="300px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Product Name:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlproduct" runat="server" Width="300px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Active:
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkactive" runat="server" />
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Follow Sequence:
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkflowSeq" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="grd_matrix" runat="server" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Left">
                                        <Columns>
                                            <asp:TemplateField HeaderText="From Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtfrmamt" SkinID="TXT" runat="server"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="txtfrmamt_FilteredTextBoxExtender" runat="server"
                                                        Enabled="True" TargetControlID="txtfrmamt" ValidChars="1234567890">
                                                    </cc1:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="To Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txttoamt" SkinID="TXT" runat="server"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="txttoamt_FilteredTextBoxExtender" runat="server"
                                                        Enabled="True" TargetControlID="txttoamt" ValidChars="1234567890">
                                                    </cc1:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Maker">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlMak" Width="60" runat="server">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>A</asp:ListItem>
                                                        <asp:ListItem>B</asp:ListItem>
                                                        <asp:ListItem>C</asp:ListItem>
                                                        <asp:ListItem>D</asp:ListItem>
                                                        <asp:ListItem>F</asp:ListItem>
                                                        <asp:ListItem>G</asp:ListItem>
                                                        <asp:ListItem>H</asp:ListItem>
                                                        <asp:ListItem>I</asp:ListItem>
                                                        <asp:ListItem>J</asp:ListItem>
                                                        <asp:ListItem>K</asp:ListItem>
                                                        <asp:ListItem>L</asp:ListItem>
                                                        <asp:ListItem>M</asp:ListItem>
                                                        <asp:ListItem>N</asp:ListItem>
                                                        <asp:ListItem>O</asp:ListItem>
                                                        <asp:ListItem>P</asp:ListItem>
                                                        <asp:ListItem>Q</asp:ListItem>
                                                        <asp:ListItem>S</asp:ListItem>
                                                        <asp:ListItem>T</asp:ListItem>
                                                        <asp:ListItem>U</asp:ListItem>
                                                        <asp:ListItem>V</asp:ListItem>
                                                        <asp:ListItem>X</asp:ListItem>
                                                        <asp:ListItem>Y</asp:ListItem>
                                                        <asp:ListItem>Z</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Checker">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlChk" Width="60" runat="server">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>A</asp:ListItem>
                                                        <asp:ListItem>B</asp:ListItem>
                                                        <asp:ListItem>C</asp:ListItem>
                                                        <asp:ListItem>D</asp:ListItem>
                                                        <asp:ListItem>F</asp:ListItem>
                                                        <asp:ListItem>G</asp:ListItem>
                                                        <asp:ListItem>H</asp:ListItem>
                                                        <asp:ListItem>I</asp:ListItem>
                                                        <asp:ListItem>J</asp:ListItem>
                                                        <asp:ListItem>K</asp:ListItem>
                                                        <asp:ListItem>L</asp:ListItem>
                                                        <asp:ListItem>M</asp:ListItem>
                                                        <asp:ListItem>N</asp:ListItem>
                                                        <asp:ListItem>O</asp:ListItem>
                                                        <asp:ListItem>P</asp:ListItem>
                                                        <asp:ListItem>Q</asp:ListItem>
                                                        <asp:ListItem>S</asp:ListItem>
                                                        <asp:ListItem>T</asp:ListItem>
                                                        <asp:ListItem>U</asp:ListItem>
                                                        <asp:ListItem>V</asp:ListItem>
                                                        <asp:ListItem>X</asp:ListItem>
                                                        <asp:ListItem>Y</asp:ListItem>
                                                        <asp:ListItem>Z</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No of Signtory">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtnumofSign" runat="server" SkinID="TXT" Width="60px" 
                                                        MaxLength="1"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="txtnumofSign_FilteredTextBoxExtender" 
                                                        runat="server" Enabled="True" TargetControlID="txtnumofSign" 
                                                        ValidChars="1,2,3" InvalidChars="4567890">
                                                    </cc1:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField HeaderText="Single">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlSingle" Width="60" runat="server">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>A</asp:ListItem>
                                                        <asp:ListItem>B</asp:ListItem>
                                                        <asp:ListItem>C</asp:ListItem>
                                                        <asp:ListItem>D</asp:ListItem>
                                                        <asp:ListItem>F</asp:ListItem>
                                                        <asp:ListItem>G</asp:ListItem>
                                                        <asp:ListItem>H</asp:ListItem>
                                                        <asp:ListItem>I</asp:ListItem>
                                                        <asp:ListItem>J</asp:ListItem>
                                                        <asp:ListItem>K</asp:ListItem>
                                                        <asp:ListItem>L</asp:ListItem>
                                                        <asp:ListItem>M</asp:ListItem>
                                                        <asp:ListItem>N</asp:ListItem>
                                                        <asp:ListItem>O</asp:ListItem>
                                                        <asp:ListItem>P</asp:ListItem>
                                                        <asp:ListItem>Q</asp:ListItem>
                                                        <asp:ListItem>S</asp:ListItem>
                                                        <asp:ListItem>T</asp:ListItem>
                                                        <asp:ListItem>U</asp:ListItem>
                                                        <asp:ListItem>V</asp:ListItem>
                                                        <asp:ListItem>X</asp:ListItem>
                                                        <asp:ListItem>Y</asp:ListItem>
                                                        <asp:ListItem>Z</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Dual">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlDual" Width="60" runat="server">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>A</asp:ListItem>
                                                        <asp:ListItem>B</asp:ListItem>
                                                        <asp:ListItem>C</asp:ListItem>
                                                        <asp:ListItem>D</asp:ListItem>
                                                        <asp:ListItem>F</asp:ListItem>
                                                        <asp:ListItem>G</asp:ListItem>
                                                        <asp:ListItem>H</asp:ListItem>
                                                        <asp:ListItem>I</asp:ListItem>
                                                        <asp:ListItem>J</asp:ListItem>
                                                        <asp:ListItem>K</asp:ListItem>
                                                        <asp:ListItem>L</asp:ListItem>
                                                        <asp:ListItem>M</asp:ListItem>
                                                        <asp:ListItem>N</asp:ListItem>
                                                        <asp:ListItem>O</asp:ListItem>
                                                        <asp:ListItem>P</asp:ListItem>
                                                        <asp:ListItem>Q</asp:ListItem>
                                                        <asp:ListItem>S</asp:ListItem>
                                                        <asp:ListItem>T</asp:ListItem>
                                                        <asp:ListItem>U</asp:ListItem>
                                                        <asp:ListItem>V</asp:ListItem>
                                                        <asp:ListItem>X</asp:ListItem>
                                                        <asp:ListItem>Y</asp:ListItem>
                                                        <asp:ListItem>Z</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Triple">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlTriple" Width="60" runat="server">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>A</asp:ListItem>
                                                        <asp:ListItem>B</asp:ListItem>
                                                        <asp:ListItem>C</asp:ListItem>
                                                        <asp:ListItem>D</asp:ListItem>
                                                        <asp:ListItem>F</asp:ListItem>
                                                        <asp:ListItem>G</asp:ListItem>
                                                        <asp:ListItem>H</asp:ListItem>
                                                        <asp:ListItem>I</asp:ListItem>
                                                        <asp:ListItem>J</asp:ListItem>
                                                        <asp:ListItem>K</asp:ListItem>
                                                        <asp:ListItem>L</asp:ListItem>
                                                        <asp:ListItem>M</asp:ListItem>
                                                        <asp:ListItem>N</asp:ListItem>
                                                        <asp:ListItem>O</asp:ListItem>
                                                        <asp:ListItem>P</asp:ListItem>
                                                        <asp:ListItem>Q</asp:ListItem>
                                                        <asp:ListItem>S</asp:ListItem>
                                                        <asp:ListItem>T</asp:ListItem>
                                                        <asp:ListItem>U</asp:ListItem>
                                                        <asp:ListItem>V</asp:ListItem>
                                                        <asp:ListItem>X</asp:ListItem>
                                                        <asp:ListItem>Y</asp:ListItem>
                                                        <asp:ListItem>Z</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Publisher">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlPublish" Width="60" runat="server">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>A</asp:ListItem>
                                                        <asp:ListItem>B</asp:ListItem>
                                                        <asp:ListItem>C</asp:ListItem>
                                                        <asp:ListItem>D</asp:ListItem>
                                                        <asp:ListItem>F</asp:ListItem>
                                                        <asp:ListItem>G</asp:ListItem>
                                                        <asp:ListItem>H</asp:ListItem>
                                                        <asp:ListItem>I</asp:ListItem>
                                                        <asp:ListItem>J</asp:ListItem>
                                                        <asp:ListItem>K</asp:ListItem>
                                                        <asp:ListItem>L</asp:ListItem>
                                                        <asp:ListItem>M</asp:ListItem>
                                                        <asp:ListItem>N</asp:ListItem>
                                                        <asp:ListItem>O</asp:ListItem>
                                                        <asp:ListItem>P</asp:ListItem>
                                                        <asp:ListItem>Q</asp:ListItem>
                                                        <asp:ListItem>S</asp:ListItem>
                                                        <asp:ListItem>T</asp:ListItem>
                                                        <asp:ListItem>U</asp:ListItem>
                                                        <asp:ListItem>V</asp:ListItem>
                                                        <asp:ListItem>X</asp:ListItem>
                                                        <asp:ListItem>Y</asp:ListItem>
                                                        <asp:ListItem>Z</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
