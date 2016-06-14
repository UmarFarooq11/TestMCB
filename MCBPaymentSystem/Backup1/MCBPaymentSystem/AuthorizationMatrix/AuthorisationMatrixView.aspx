<%@ Page Title="" Language="C#" Theme="ColorSchemeBlue" MasterPageFile="~/MasterPage/RoutinePage.master"
    AutoEventWireup="true" CodeFile="AuthorisationMatrixView.aspx.cs" Inherits="AuthorizationMatrix_AuthorisationMatrixView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../WebControls/AlphaSelection.ascx" TagName="AlphaSelection" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
                Text="Authorization Matrix" Width="100%" SkinID="FormViewHeading"></asp:Label>
            <ajaxToolkit:TabContainer Style="font-size: 8pt; font-family: Verdana" ID="TabContainer1"
                runat="server" Font-Size="8pt" Font-Names="Verdana" ActiveTabIndex="0" BackColor="#FFFFEE"
                CssClass="ajax__tab_xp1">
                <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="TabPanel1">
                    <ContentTemplate>
                        <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                            <tbody>
                                <tr align="right">
                                    <td style="width: 25%; text-align: right">
                                        Company Name :
                                    </td>
                                    <td style="width: 25%; text-align: left">
                                        &nbsp;<asp:TextBox ID="txtcompanycode" runat="server" SkinID="TXT" Width="100px"
                                            MaxLength="5"></asp:TextBox>
                                    </td>
                                    <td style="width: 25%; text-align: right">
                                        Product Name :
                                    </td>
                                    <td style="width: 25%; text-align: left">
                                        &nbsp;<asp:TextBox ID="txtProductcode" runat="server" SkinID="TXT" Width="200px"
                                            MaxLength="30"></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <HeaderTemplate>
                        Basic Search
                    </HeaderTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="TabPanel2">
                    <ContentTemplate>
                        <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                            <tbody>
                                <tr>
                                    <td style="width: 25%; text-align: center">
                                        <asp:RadioButton ID="rbtcompcode" runat="server" Text="Company Code" GroupName="A">
                                        </asp:RadioButton>
                                    </td>
                                    <td style="width: 25%; text-align: center">
                                        <asp:RadioButton ID="rbtusrcode" runat="server" Text="User Code" GroupName="A"></asp:RadioButton>
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                            </tbody>
                        </table>
                        <uc1:AlphaSelection ID="AlphaSelection1" runat="server"></uc1:AlphaSelection>
                    </ContentTemplate>
                    <HeaderTemplate>
                        Alpha Search
                    </HeaderTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
            <table cellspacing="0" width="100%">
                <tbody>
                    <tr>
                        <td style="width: 240px">
                            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Search" Font-Size="10pt"
                                Font-Names="Verdana" Font-Bold="True"></asp:Button>
                            <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Text="Clear" Font-Size="10pt"
                                Font-Names="Verdana" Font-Bold="True"></asp:Button>
                            <asp:Button ID="TXT_NEW_USER" OnClick="TXT_NEW_USER_Click" runat="server" Text="New"
                                Font-Size="10pt" Font-Names="Verdana" Font-Bold="True"></asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table style="font-size: 10pt" cellspacing="0" width="100%">
                <tbody>
                    <tr>
                        <td style="font-size: 1pt; width: 98%" class="GridBarTop">
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
            <table style="font-size: 10pt; background-color: #f6f6f6" cellspacing="0" width="100%">
                <tbody>
                    <tr>
                        <td style="width: 98%" class="GridBar">
                            <table cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="width: 0%">
                                            <asp:Label ID="LBL_GridStatus" runat="server" SkinID="LBL_STATUS" Width="120px"></asp:Label>
                                        </td>
                                        <td style="width: 0%">
                                            <asp:Label ID="LBL_RowStatus" runat="server" SkinID="LBL_STATUS" Width="200px"></asp:Label>
                                        </td>
                                        <td style="width: 100%">
                                        </td>
                                        <td style="width: 0%">
                                            <asp:ImageButton ID="CMD_MoveFirst" OnClick="CMD_MoveFirst_Click" runat="server"
                                                ImageUrl="~/Images/MoveTop.gif"></asp:ImageButton>
                                        </td>
                                        <td style="width: 0%">
                                            <asp:ImageButton ID="CMD_MoveBack" OnClick="CMD_MoveBack_Click" runat="server" ImageUrl="~/Images/MovePrevious.gif">
                                            </asp:ImageButton>
                                        </td>
                                        <td style="width: 0%">
                                            <asp:DropDownList Style="font-size: 8pt; font-family: Arial, Tahoma" ID="DRP_LIST"
                                                runat="server" Width="50px" OnSelectedIndexChanged="DRP_LIST_SelectedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 0%">
                                            <asp:ImageButton ID="CMD_MoveNext" OnClick="CMD_MoveNext_Click" runat="server" ImageUrl="~/Images/MoveNext.gif">
                                            </asp:ImageButton>
                                        </td>
                                        <td style="width: 0%">
                                            <asp:ImageButton ID="CMD_MoveLast" OnClick="CMD_MoveLast_Click" runat="server" ImageUrl="~/Images/MoveLast.gif">
                                            </asp:ImageButton>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:GridView Style="width: 100%" ID="GridView1" runat="server" Width="100%" Font-Size="8pt"
                                Font-Names="Verdana" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                DataSourceID="SP_SETUP_AREA_ALL" ShowFooter="True" PageSize="20" AutoGenerateColumns="False"
                                AllowSorting="True" AllowPaging="True">
                                <PagerSettings PreviousPageText="Move Previous" LastPageImageUrl="~/Images/MoveLast.gif"
                                    PreviousPageImageUrl="~/Images/MovePrevious.gif" FirstPageImageUrl="~/Images/MoveTop.gif"
                                    Position="TopAndBottom" Visible="False" NextPageImageUrl="~/Images/MoveNext.gif"
                                    PageButtonCount="100" LastPageText="Move Last" FirstPageText="Move First" NextPageText="Move Next">
                                </PagerSettings>
                                <FooterStyle BorderStyle="Solid" BorderWidth="1px"></FooterStyle>
                                <Columns>
                                    <asp:BoundField DataField="company_code" SortExpression="company_code" HeaderText="Company Code"
                                        HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                    <asp:BoundField DataField="COMPANY_NAME" SortExpression="company_code" HeaderText="Company Name"
                                        HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                    <asp:BoundField DataField="product_code" SortExpression="product_code" HeaderText="Product Code"
                                        HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                    <asp:BoundField DataField="product_name" SortExpression="product_name" HeaderText="Product Name"
                                        HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                    <asp:BoundField DataField="Active" SortExpression="Active" HeaderText="Active" HeaderStyle-HorizontalAlign="Left">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="status" SortExpression="status" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" />
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Select" ImageUrl="~/Images/edit1.gif" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BorderStyle="Solid" BorderColor="#404040"></PagerStyle>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="SP_SETUP_AREA_ALL" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="Get_AuthorizationMatrix" TypeName="LOV_COLLECTION">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="%" Name="CompanyCode" SessionField="COMCode"
                Type="String" />
            <asp:SessionParameter DefaultValue="%" Name="ProductCode" SessionField="ProductCode"
                Type="String" />
            <asp:SessionParameter DefaultValue="V" Name="Mode" SessionField="Mode" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
