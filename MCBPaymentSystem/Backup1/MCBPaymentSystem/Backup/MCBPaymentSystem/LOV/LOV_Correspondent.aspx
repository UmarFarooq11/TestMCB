<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="LOV_Correspondent.aspx.cs" Inherits="CorrespondentSetup_LOV_Correspondent"
    Title="Correspondent Bank - LOV" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../WebControls/AlphaSelection.ascx" TagName="AlphaSelection" TagPrefix="uc1" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function TABLE1_onclick() {}
        function CloseWindow() 
        {
        window.close(); 
    }
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="Label1" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
        SkinID="Heading" Text="Correspondent Bank" Width="100%"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<ajaxToolkit:TabContainer style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" id="TabContainer1" runat="server" Font-Size="8pt" Font-Names="Verdana" CssClass="ajax__tab_xp1" BackColor="#FFFFEE" ActiveTabIndex="0"><ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>
                        Basic Search
                    
</HeaderTemplate>
<ContentTemplate>
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" width="100%"><TBODY><TR align=right><TD style="WIDTH: 25%; TEXT-ALIGN: right">Correspondent Code :&nbsp; </TD><TD style="WIDTH: 25%; TEXT-ALIGN: left">&nbsp;<asp:TextBox id="TXT_BankCode" runat="server" Width="200px" SkinID="TXT" MaxLength="4"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="TXT_BankCode" Enabled="True" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender> </TD><TD style="WIDTH: 25%; TEXT-ALIGN: right">Correspondent Name :&nbsp; </TD><TD style="WIDTH: 25%; TEXT-ALIGN: left">&nbsp;<asp:TextBox id="TXT_BankName" runat="server" Width="200px" SkinID="TXT" MaxLength="50"></asp:TextBox> </TD></TR></TBODY></TABLE>
</ContentTemplate>
</ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2"><HeaderTemplate>
                        Alpha Search
                    
</HeaderTemplate>
<ContentTemplate>
                        <table style="font-size: 8pt; font-family: Verdana" width="100%">
                            <tbody>
                                <tr>
                                    <td style="width: 25%; text-align: center">
                                        <asp:RadioButton ID="RD_BankName" runat="server" Text="Correspondent Name" GroupName="A">
                                        </asp:RadioButton>
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                            </tbody>
                        </table>
                        <uc1:AlphaSelection ID="AlphaSelection1" runat="server"></uc1:AlphaSelection>
                    
</ContentTemplate>
</ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer><eo:ToolBar id="ToolBar1" runat="server" OnItemClick="ToolBar1_ItemClick" AutoPostBack="True">
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
            </eo:ToolBar> <TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 9pt; FONT-FAMILY: Arial, Tahoma" id="LBL_GridStatus" runat="server" Width="100px"></asp:Label></TD><TD><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; FONT-FAMILY: Arial, Tahoma" id="LBL_RowStatus" runat="server" Width="200px"></asp:Label></TD><TD width="100%"></TD><TD><asp:ImageButton id="CMD_MoveFirst" onclick="CMD_MoveFirst_Click" runat="server" ImageUrl="~/Images/MoveTop.gif"></asp:ImageButton></TD><TD><asp:ImageButton id="CMD_MoveBack" onclick="CMD_MoveBack_Click" runat="server" ImageUrl="~/Images/MovePrevious.gif">
                            </asp:ImageButton></TD><TD><asp:DropDownList id="DRP_LIST" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DRP_LIST_SelectedIndexChanged">
                            </asp:DropDownList></TD><TD><asp:ImageButton id="CMD_MoveNext" onclick="CMD_MoveNext_Click" runat="server" ImageUrl="~/Images/MoveNext.gif">
                            </asp:ImageButton></TD><TD><asp:ImageButton id="CMD_MoveLast" onclick="CMD_MoveLast_Click" runat="server" ImageUrl="~/Images/MoveLast.gif">
                            </asp:ImageButton></TD></TR></TBODY></TABLE><TABLE style="BACKGROUND-COLOR: gainsboro" class="login" cellSpacing=0 width="100%"><TBODY><TR><TD style="FONT-SIZE: 9pt; COLOR: #444444; FONT-FAMILY: Arial, Tahoma; HEIGHT: 17px; TEXT-ALIGN: left" colSpan=4><asp:GridView style="WIDTH: 100%" id="GridView1" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataSourceID="SP_RPS_Bank_ALL" ShowFooter="True" PageSize="20" OnRowDataBound="GridView1_RowDataBound" DataKeyNames="ID" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
                                <PagerSettings PreviousPageText="Move Previous" LastPageImageUrl="~/Images/MoveLast.gif"
                                    PreviousPageImageUrl="~/Images/MovePrevious.gif" FirstPageImageUrl="~/Images/MoveTop.gif"
                                    Position="TopAndBottom" Visible="False" NextPageImageUrl="~/Images/MoveNext.gif"
                                    PageButtonCount="100" LastPageText="Move Last" FirstPageText="Move First" NextPageText="Move Next">
                                </PagerSettings>
                                <FooterStyle BorderStyle="Solid" BorderWidth="1px"></FooterStyle>
                                <Columns>
                                    <asp:BoundField DataField="ID" Visible="False" SortExpression="ID" HeaderText="ID"></asp:BoundField>
                                    <asp:BoundField DataField="BankCode" SortExpression="BankCode" HeaderText="Correspondent Code">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BankName" SortExpression="BankName" HeaderText="Correspondent Name">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Abbreviation" SortExpression="Abbreviation" HeaderText="Abbreviation">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Authorization" HeaderText="Authorization" SortExpression="Authorization" />
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Select" ImageUrl="~/Images/edit1.gif"
                                                OnClick="ImageButton1_Click" OnClientClick="CloseWindow();" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BorderStyle="Solid" BorderColor="#404040"></PagerStyle>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:GridView> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="SP_RPS_Bank_ALL" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="Get_RPS_CorrespondentSetup_LOV" TypeName="LOV_COLLECTION">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="%" Name="BankCode" SessionField="RPS_Bank_BankCode"
                Type="String" />
            <asp:SessionParameter DefaultValue="%" Name="BankName" SessionField="RPS_Bank_BankName"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
<%--</form>
</body>
</html>--%>
