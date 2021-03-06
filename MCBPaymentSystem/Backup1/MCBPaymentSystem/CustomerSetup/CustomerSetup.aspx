<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="CustomerSetup.aspx.cs" Inherits="CustomerSetup_CustomerSetup" Title="Customer Setup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../WebControls/AlphaSelection.ascx" TagName="AlphaSelection" TagPrefix="uc1" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="Label1" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
        Text="Customer Setup" Width="100%" SkinID="Heading"></asp:Label>
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
                                        Customer Code :&nbsp;
                                    </td>
                                    <td style="width: 25%; text-align: left">
                                        &nbsp;<asp:TextBox ID="TXT_BankCode" runat="server" SkinID="TXT" Width="200px" MaxLength="1"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTE_BankCode" runat="server" Enabled="True"
                                            TargetControlID="TXT_BankCode" FilterType="Numbers">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 25%; text-align: right">
                                        Customer Name :&nbsp;
                                    </td>
                                    <td style="width: 25%; text-align: left">
                                        &nbsp;<asp:TextBox ID="TXT_BankName" runat="server" SkinID="TXT" Width="200px" MaxLength="50"></asp:TextBox>
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
                        <table style="font-size: 8pt; font-family: Verdana" width="100%">
                            <tbody>
                                <tr>
                                    <td style="width: 25%; text-align: center">
                                        <asp:RadioButton ID="RD_BankName" runat="server" Text="Customer Name" GroupName="A">
                                        </asp:RadioButton>
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
            </ajaxToolkit:TabContainer><eo:ToolBar ID="ToolBar1" runat="server" OnItemClick="ToolBar1_ItemClick"
                AutoPostBack="True">
                <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                <Items>
                    <eo:ToolBarItem CommandName="Cancel" Disabled="True" ImageUrl="00101001" ToolTip="Add New">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem CommandName="Cancel" Disabled="True" ImageUrl="00101032" ToolTip="Search">
                    </eo:ToolBarItem>
                    <eo:ToolBarItem CommandName="Cancel" Disabled="True" ImageUrl="~/images/Refresh copy.gif"
                        ToolTip="Refresh">
                    </eo:ToolBarItem>
                </Items>
                <ItemTemplates>
                    <eo:ToolBarItem Type="Custom">
                        <NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;" />
                        <HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;" />
                        <DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;" />
                    </eo:ToolBarItem>
                    <eo:ToolBarItem Type="DropDownMenu">
                        <NormalStyle CssText="background-image:url('00100205');background-position-x:right;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;cursor:hand;padding-bottom:3px;padding-left:4px;padding-right:4px;padding-top:3px;" />
                        <HoverStyle CssText="background-color:#ffe1ac;background-image:url('00100206');background-position-x:right;border-bottom-color:#335ea8;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#335ea8;border-left-style:solid;border-left-width:1px;border-right-color:#335ea8;border-right-style:solid;border-right-width:1px;border-top-color:#335ea8;border-top-style:solid;border-top-width:1px;cursor:hand;padding-bottom:2px;padding-left:3px;padding-right:3px;padding-top:2px;" />
                        <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; BACKGROUND-POSITION-X: right; BACKGROUND-IMAGE: url(00100206); PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; BACKGROUND-COLOR: #ffe1ac" />
                    </eo:ToolBarItem>
                </ItemTemplates>
                <NormalStyle CssText="PADDING-RIGHT: 4px; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 3px; CURSOR: hand; BORDER-TOP-STYLE: none; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" />
            </eo:ToolBar>
            <table class="login" cellspacing="0" width="100%">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label Style="font-weight: bold; font-size: 9pt; font-family: Arial, Tahoma"
                                ID="LBL_GridStatus" runat="server" Width="100px"></asp:Label></td>
                        <td>
                            <asp:Label Style="font-weight: bold; font-size: 10pt; font-family: Arial, Tahoma"
                                ID="LBL_RowStatus" runat="server" Width="200px"></asp:Label></td>
                        <td width="100%" style="text-align: center">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                        <td>
                            <asp:ImageButton ID="CMD_MoveFirst" OnClick="CMD_MoveFirst_Click" runat="server"
                                ImageUrl="~/Images/MoveTop.gif"></asp:ImageButton></td>
                        <td>
                            <asp:ImageButton ID="CMD_MoveBack" OnClick="CMD_MoveBack_Click" runat="server" ImageUrl="~/Images/MovePrevious.gif">
                            </asp:ImageButton></td>
                        <td>
                            <asp:DropDownList ID="DRP_LIST" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DRP_LIST_SelectedIndexChanged">
                            </asp:DropDownList></td>
                        <td>
                            <asp:ImageButton ID="CMD_MoveNext" OnClick="CMD_MoveNext_Click" runat="server" ImageUrl="~/Images/MoveNext.gif">
                            </asp:ImageButton></td>
                        <td>
                            <asp:ImageButton ID="CMD_MoveLast" OnClick="CMD_MoveLast_Click" runat="server" ImageUrl="~/Images/MoveLast.gif">
                            </asp:ImageButton></td>
                    </tr>
                </tbody>
            </table>
            <table style="background-color: gainsboro" class="login" cellspacing="0" width="100%">
                <tbody>
                    <tr>
                        <td style="font-size: 9pt; color: #444444; font-family: Arial, Tahoma; text-align: left"
                            colspan="4">
                            <asp:GridView Style="width: 100%" ID="GridView1" runat="server" Width="100%" Font-Size="8pt"
                                Font-Names="Verdana" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                DataSourceID="SP_RPS_Bank_ALL" ShowFooter="True" PageSize="20" OnRowDataBound="GridView1_RowDataBound"
                                DataKeyNames="ID" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
                                <PagerSettings PreviousPageText="Move Previous" LastPageImageUrl="~/Images/MoveLast.gif"
                                    PreviousPageImageUrl="~/Images/MovePrevious.gif" FirstPageImageUrl="~/Images/MoveTop.gif"
                                    Position="TopAndBottom" Visible="False" NextPageImageUrl="~/Images/MoveNext.gif"
                                    PageButtonCount="100" LastPageText="Move Last" FirstPageText="Move First" NextPageText="Move Next">
                                </PagerSettings>
                                <FooterStyle BorderStyle="Solid" BorderWidth="1px"></FooterStyle>
                                <Columns>
                                    <asp:BoundField DataField="ID" SortExpression="ID" HeaderText="ID" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="BankCode" SortExpression="BankCode" HeaderText="Customer Code">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BankName" SortExpression="BankName" HeaderText="Customer Name">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AccountNo" SortExpression="AccountNo" HeaderText="Account No">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Authorization" HeaderText="Authorization" SortExpression="Authorization" />
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Select" ImageUrl="~/Images/edit1.gif"
                                                OnClick="ImageButton1_Click" />
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
    <asp:ObjectDataSource ID="SP_RPS_Bank_ALL" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="Get_RPS_CustomerSetup_ALL" TypeName="LOV_COLLECTION">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="%" Name="BankCode" SessionField="RPS_Bank_BankCode"
                Type="String" />
            <asp:SessionParameter DefaultValue="%" Name="BankName" SessionField="RPS_Bank_BankName"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
