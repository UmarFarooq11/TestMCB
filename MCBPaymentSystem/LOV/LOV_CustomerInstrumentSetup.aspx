<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true" CodeFile="LOV_CustomerInstrumentSetup.aspx.cs" Inherits="LOV_LOV_CustomerInstrumentSetup" Title = "Customer Instrument Setup - LOV" %>
<%@ Register
Assembly="AjaxControlToolkit"
Namespace="AjaxControlToolkit"
TagPrefix="ajaxToolkit" %>
<%@ Register src="../WebControls/AlphaSelection.ascx" tagname="AlphaSelection" tagprefix="uc1" %> 
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
// <!CDATA[
function TABLE1_onclick() {}
function CloseWindow() 
{
    window.close(); 
}
// ]]>
</script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:Label ID="Label1" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
        SkinID="Heading" Text="Customer Instrument Setup" Width="100%"></asp:Label>
<asp:UpdatePanel id="UpdatePanel1" runat="server">
<contenttemplate>
<ajaxToolkit:TabContainer style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" id="TabContainer1" runat="server" CssClass="ajax__tab_xp1" Font-Size="8pt" Font-Names="Verdana" BackColor="#FFFFEE" ActiveTabIndex="0"><ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>
Basic Search
</HeaderTemplate>
<ContentTemplate>
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" width="100%"><TBODY><TR align=right><TD style="WIDTH: 25%; TEXT-ALIGN: right">Instrument Name :&nbsp;
</TD><TD style="WIDTH: 25%; TEXT-ALIGN: left">&nbsp;<asp:TextBox id="TXT_INSTRUMENT_NAME" runat="server" Width="200px"></asp:TextBox> </TD></TR></TBODY></TABLE>
</ContentTemplate>
</ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2"><HeaderTemplate>
Alpha Search
</HeaderTemplate>
<ContentTemplate>
<table style="font-size: 8pt; font-family: Verdana" width="100%">
                        <tr>
                            <td style="width: 25%; text-align: center">
                                <asp:RadioButton ID="RD_INSTRUMENT_NAME" runat="server" GroupName="A" Text="Instrument Name" /></td>
                        </tr>
                   </table>
                    <uc1:AlphaSelection ID="AlphaSelection1" runat="server" />
                
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
        </eo:ToolBar> <TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 9pt; FONT-FAMILY: Arial, Tahoma" id="LBL_GridStatus" runat="server" Width="100px"></asp:Label></TD><TD><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; FONT-FAMILY: Arial, Tahoma" id="LBL_RowStatus" runat="server" Width="200px"></asp:Label></TD><TD width="100%"></TD><TD><asp:ImageButton id="CMD_MoveFirst" onclick="CMD_MoveFirst_Click" runat="server" ImageUrl="~/Images/MoveTop.gif"></asp:ImageButton></TD><TD><asp:ImageButton id="CMD_MoveBack" onclick="CMD_MoveBack_Click" runat="server" ImageUrl="~/Images/MovePrevious.gif"></asp:ImageButton></TD><TD><asp:DropDownList id="DRP_LIST" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DRP_LIST_SelectedIndexChanged">
</asp:DropDownList></TD><TD><asp:ImageButton id="CMD_MoveNext" onclick="CMD_MoveNext_Click" runat="server" ImageUrl="~/Images/MoveNext.gif"></asp:ImageButton></TD><TD><asp:ImageButton id="CMD_MoveLast" onclick="CMD_MoveLast_Click" runat="server" ImageUrl="~/Images/MoveLast.gif"></asp:ImageButton></TD></TR></TBODY></TABLE><TABLE style="BACKGROUND-COLOR: gainsboro" class="login" cellSpacing=0 width="100%"><TBODY><TR><TD style="FONT-SIZE: 9pt; COLOR: #444444; FONT-FAMILY: Arial, Tahoma; TEXT-ALIGN: left" colSpan=4><asp:GridView style="WIDTH: 100%" id="GridView1" runat="server" Font-Size="8pt" Font-Names="Verdana" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataSourceID="SP_SPDS_InstrumentSetup_ALL" ShowFooter="True" PageSize="20" OnRowDataBound="GridView1_RowDataBound" DataKeyNames="ID" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PageButtonCount="100" Position="TopAndBottom" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous" Visible="False"></PagerSettings>
<Columns>
<asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="False">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="INSTRUMENT_NAME" HeaderText="Instrument Name" SortExpression="INSTRUMENT_NAME">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
    <asp:BoundField DataField="Authorization" HeaderText="Authorization" SortExpression="Authorization" />
<asp:TemplateField ShowHeader="False"><ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Select" ImageUrl="~/Images/edit1.gif"
                        OnClick="ImageButton1_Click" OnClientClick="CloseWindow();" />
                
</ItemTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>

<PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>
    <asp:ObjectDataSource ID="SP_SPDS_InstrumentSetup_ALL" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Get_SPDS_CustomerInstrumentSetup_LOV" TypeName="LOV_COLLECTION">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="%" Name="INSTRUMENT_NAME" SessionField="SPDS_InstrumentSetup_INSTRUMENT_NAME"
                Type="String" />
            <asp:SessionParameter DefaultValue="0" Name="ID" SessionField="SPDS_ProductArrangement_CustomerID"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
