<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="LOV_UserCMPY.aspx.cs"
    Inherits="LOV_LOV_UserCMPY" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../WebControls/AlphaSelection.ascx" TagName="alphaselection" TagPrefix="uc1" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="Server">
    <link href="../CENTER_ARROW.CSS" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
</head>

<script language="javascript" type="text/javascript">
// <!CDATA[
    function TABLE1_onclick() { }
    function CloseWindow() {
        window.close();
    }
// ]]>
</script>

<body style="background-repeat: repeat; text-align: left; vertical-align: middle;
    background-position-x: center; background-attachment: scroll; background-color: #f6f6f6;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="Label1" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
            SkinID="Heading" Text="Company User" Width="100%"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <ajaxToolkit:TabContainer Style="font-size: 8pt; font-family: Verdana" ID="TabContainer1"
                    runat="server" ActiveTabIndex="0" BackColor="#FFFFEE" Font-Names="Verdana" Font-Size="8pt"
                    CssClass="ajax__tab_xp1">
                    <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="TabPanel1">
                        <HeaderTemplate>
                            Basic Search
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table style="font-size: 8pt; font-family: Verdana" width="100%">
                                <tbody>
                                    <tr align="right">
                                        <td style="width: 25%; text-align: right">
                                            Company User:
                                        </td>
                                        <td style="width: 25%; text-align: left">
                                            <asp:TextBox ID="TXT_USER_NAME" runat="server" Width="200px" SkinID="TXT"></asp:TextBox>
                                            <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            Enabled="True" FilterType="Numbers" TargetControlID="TXT_USER_NAME">
                                        </ajaxToolkit:FilteredTextBoxExtender>--%>
                                        </td>
                                        <td style="width: 25%; text-align: left">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="TabPanel2">
                        <ContentTemplate>
                            <table style="font-size: 8pt; font-family: Verdana" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="width: 25%; text-align: center">
                                            <asp:RadioButton ID="RD_ProductName" runat="server" Text="Company User " GroupName="A">
                                            </asp:RadioButton>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <uc1:alphaselection ID="AlphaSelection1" runat="server"></uc1:alphaselection>
                        </ContentTemplate>
                        <HeaderTemplate>
                            Alpha Search
                        </HeaderTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer><eo:ToolBar ID="ToolBar1" runat="server" AutoPostBack="True"
                    OnItemClick="ToolBar1_ItemClick">
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
                                    ID="LBL_GridStatus" runat="server" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label Style="font-weight: bold; font-size: 10pt; font-family: Arial, Tahoma"
                                    ID="LBL_RowStatus" runat="server" Width="200px"></asp:Label>
                            </td>
                            <td width="100%">
                            </td>
                            <td>
                                <asp:ImageButton ID="CMD_MoveFirst" OnClick="CMD_MoveFirst_Click" runat="server"
                                    ImageUrl="~/Images/MoveTop.gif"></asp:ImageButton>
                            </td>
                            <td>
                                <asp:ImageButton ID="CMD_MoveBack" OnClick="CMD_MoveBack_Click" runat="server" ImageUrl="~/Images/MovePrevious.gif">
                                </asp:ImageButton>
                            </td>
                            <td>
                                <asp:DropDownList ID="DRP_LIST" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DRP_LIST_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:ImageButton ID="CMD_MoveNext" OnClick="CMD_MoveNext_Click" runat="server" ImageUrl="~/Images/MoveNext.gif">
                                </asp:ImageButton>
                            </td>
                            <td>
                                <asp:ImageButton ID="CMD_MoveLast" OnClick="CMD_MoveLast_Click" runat="server" ImageUrl="~/Images/MoveLast.gif">
                                </asp:ImageButton>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table style="background-color: gainsboro" class="login" cellspacing="0" width="100%">
                    <tbody>
                        <tr>
                            <td style="font-size: 9pt; color: #444444; font-family: Arial, Tahoma; text-align: left">
                                &nbsp;
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataSourceID="Get_SP_CompUser_LOV" Font-Names="Verdana"
                    Font-Size="8pt" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                    PageSize="20" ShowFooter="True" Style="width: 100%" Width="100%" DataKeyNames="ID">
                    <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
                        LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
                        NextPageText="Move Next" PageButtonCount="100" Position="TopAndBottom" PreviousPageImageUrl="~/Images/MovePrevious.gif"
                        PreviousPageText="Move Previous" Visible="False" />
                    <Columns>
                        <asp:BoundField DataField="ID" SortExpression="ID" HeaderText="ID" Visible="False"></asp:BoundField>
                        <asp:BoundField DataField="USER_CODE" HeaderText="User Code" SortExpression="USER_CODE"
                            HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="USR_NAME" HeaderText="User Name" SortExpression="USR_NAME"
                            HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="REAL_NAME" HeaderText="Real Name" SortExpression="REAL_NAME"
                            HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Authorization" HeaderText="Authorization" SortExpression="Authorization" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Select" ImageUrl="~/Images/edit1.gif"
                                    OnClientClick="CloseWindow();" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BorderStyle="Solid" BorderWidth="1px" />
                    <HeaderStyle HorizontalAlign="Left" />
                    <PagerStyle BorderColor="#404040" BorderStyle="Solid" />
                </asp:GridView>
                <asp:ObjectDataSource ID="Get_SP_CompUser_LOV" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="LOV_Company_USERS" TypeName="LOV_COLLECTION">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="%" Name="USER_CODE" SessionField="U_NAME" Type="String" />
                        <asp:SessionParameter DefaultValue="%" Name="P_USER_SEARCH" SessionField="USER_SEARCH"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
