<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true" CodeFile="LOV_ZipCodes.aspx.cs" Inherits="LOV_LOV_ZipCodes" Title = "Master ZipCode Setup - LOV" %>
<%@ Register
Assembly="AjaxControlToolkit"
Namespace="AjaxControlToolkit"
TagPrefix="ajaxToolkit" %>
<%@ Register src="../WebControls/AlphaSelection.ascx" tagname="AlphaSelection" tagprefix="uc1" %> 
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %> 


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:Label ID="Label1" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
Text="Master ZipCode Setup" Width="100%" SkinID="Heading"></asp:Label>
<asp:UpdatePanel id="UpdatePanel1" runat="server">
<contenttemplate>
<ajaxToolkit:TabContainer style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" id="TabContainer1" runat="server" Font-Size="8pt" Font-Names="Verdana" ActiveTabIndex="0" BackColor="#FFFFEE" CssClass="ajax__tab_xp1"><ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="TabPanel1"><ContentTemplate>
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" width="100%"><TBODY><TR align=right><TD style="WIDTH: 25%; TEXT-ALIGN: right">Courier&nbsp;:&nbsp; </TD><TD style="WIDTH: 25%; TEXT-ALIGN: left">&nbsp;<asp:TextBox id="TXT_CourierID" runat="server" SkinID="TXT" Width="200px"></asp:TextBox> </TD><TD style="WIDTH: 25%; TEXT-ALIGN: right">Bank&nbsp;:&nbsp; </TD><TD style="WIDTH: 25%; TEXT-ALIGN: left">&nbsp;<asp:TextBox id="TXT_BankID" runat="server" SkinID="TXT" Width="200px"></asp:TextBox> </TD></TR><TR align=right><TD style="WIDTH: 25%; TEXT-ALIGN: right">Station&nbsp;:&nbsp; </TD><TD style="WIDTH: 25%; TEXT-ALIGN: left">&nbsp;<asp:TextBox id="TXT_StationID" runat="server" SkinID="TXT" Width="200px"></asp:TextBox> </TD><TD style="WIDTH: 25%; TEXT-ALIGN: right">Branch&nbsp;:&nbsp; </TD><TD style="WIDTH: 25%; TEXT-ALIGN: left">&nbsp;<asp:TextBox id="TXT_BranchID" runat="server" SkinID="TXT" Width="200px"></asp:TextBox> </TD></TR><TR align=right><TD style="WIDTH: 25%; TEXT-ALIGN: right">Service&nbsp;:&nbsp; </TD><TD style="WIDTH: 25%; TEXT-ALIGN: left">&nbsp;<asp:TextBox id="TXT_ServiceID" runat="server" SkinID="TXT" Width="200px"></asp:TextBox> </TD><TD style="WIDTH: 25%; TEXT-ALIGN: right">Zip Code :&nbsp; </TD><TD style="WIDTH: 25%; TEXT-ALIGN: left">&nbsp;<asp:TextBox id="TXT_ZipCode" runat="server" SkinID="TXT" Width="200px"></asp:TextBox> </TD></TR></TBODY></TABLE>
</ContentTemplate>
<HeaderTemplate>
Basic Search
</HeaderTemplate>
</ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="TabPanel2"><ContentTemplate>
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" width="100%"><TBODY><TR><TD style="WIDTH: 25%; TEXT-ALIGN: center"><asp:RadioButton id="RD_CourierID" runat="server" Text="Courier " GroupName="A"></asp:RadioButton> </TD><TD style="WIDTH: 25%; TEXT-ALIGN: center"><asp:RadioButton id="RD_StationID" runat="server" Text="Station " GroupName="A"></asp:RadioButton> </TD></TR><TR><TD style="WIDTH: 25%; TEXT-ALIGN: center"><asp:RadioButton id="RD_BranchID" runat="server" Text="Branch " GroupName="A"></asp:RadioButton> </TD><TD style="WIDTH: 25%; TEXT-ALIGN: center">&nbsp;<asp:RadioButton id="RD_BankID" runat="server" Text="Bank " GroupName="A"></asp:RadioButton></TD></TR><TR></TR></TBODY></TABLE><uc1:AlphaSelection id="AlphaSelection1" runat="server"></uc1:AlphaSelection> 
</ContentTemplate>
<HeaderTemplate>
Alpha Search
</HeaderTemplate>
</ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer> <eo:ToolBar id="ToolBar1" runat="server" AutoPostBack="True" OnItemClick="ToolBar1_ItemClick"><Items>
<eo:ToolBarItem ImageUrl="00101001" CommandName="Cancel" ToolTip="Add New" Disabled="True"></eo:ToolBarItem>
<eo:ToolBarItem ImageUrl="00101032" CommandName="Cancel" ToolTip="Search" Disabled="True"></eo:ToolBarItem>
<eo:ToolBarItem ImageUrl="~/images/Refresh copy.gif" CommandName="Cancel" ToolTip="Refresh" Disabled="True"></eo:ToolBarItem>
<eo:ToolBarItem CommandName="Cancel" ToolTip="Close" Disabled="True"></eo:ToolBarItem>
</Items>

<DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac"></DownStyle>

<HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac"></HoverStyle>
<ItemTemplates>
<eo:ToolBarItem Type="Custom">
<HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></HoverStyle>

<NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></NormalStyle>

<DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></DownStyle>
</eo:ToolBarItem>
<eo:ToolBarItem Type="DropDownMenu">
<HoverStyle CssText="background-color:#ffe1ac;background-image:url('00100206');background-position-x:right;border-bottom-color:#335ea8;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#335ea8;border-left-style:solid;border-left-width:1px;border-right-color:#335ea8;border-right-style:solid;border-right-width:1px;border-top-color:#335ea8;border-top-style:solid;border-top-width:1px;cursor:hand;padding-bottom:2px;padding-left:3px;padding-right:3px;padding-top:2px;"></HoverStyle>

<NormalStyle CssText="background-image:url('00100205');background-position-x:right;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;cursor:hand;padding-bottom:3px;padding-left:4px;padding-right:4px;padding-top:3px;"></NormalStyle>

<DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; BACKGROUND-POSITION-X: right; BACKGROUND-IMAGE: url(00100206); PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; BACKGROUND-COLOR: #ffe1ac"></DownStyle>
</eo:ToolBarItem>
</ItemTemplates>

<NormalStyle CssText="PADDING-RIGHT: 4px; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 3px; CURSOR: hand; BORDER-TOP-STYLE: none; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"></NormalStyle>
</eo:ToolBar> <TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; FONT-FAMILY: Arial, Tahoma" id="LBL_RowStatus" runat="server" Width="200px"></asp:Label></TD><TD width="100%"><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 9pt; FONT-FAMILY: Arial, Tahoma" id="LBL_GridStatus" runat="server" Width="100px"></asp:Label></TD><TD><asp:ImageButton id="CMD_MoveFirst" onclick="CMD_MoveFirst_Click" runat="server" ImageUrl="~/Images/MoveTop.gif"></asp:ImageButton></TD><TD><asp:ImageButton id="CMD_MoveBack" onclick="CMD_MoveBack_Click" runat="server" ImageUrl="~/Images/MovePrevious.gif"></asp:ImageButton></TD><TD><asp:DropDownList id="DRP_LIST" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DRP_LIST_SelectedIndexChanged">
</asp:DropDownList></TD><TD><asp:ImageButton id="CMD_MoveNext" onclick="CMD_MoveNext_Click" runat="server" ImageUrl="~/Images/MoveNext.gif"></asp:ImageButton></TD><TD><asp:ImageButton id="CMD_MoveLast" onclick="CMD_MoveLast_Click" runat="server" ImageUrl="~/Images/MoveLast.gif"></asp:ImageButton></TD></TR></TBODY></TABLE><TABLE style="BACKGROUND-COLOR: gainsboro" class="login" cellSpacing=0 width="98%"><TBODY><TR><TD style="FONT-SIZE: 9pt; COLOR: #444444; FONT-FAMILY: Arial, Tahoma; TEXT-ALIGN: left" colSpan=4><asp:GridView style="WIDTH: 100%" id="GridView1" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" OnRowDataBound="GridView1_RowDataBound" PageSize="20" ShowFooter="True" DataSourceID="SP_RPS_MasterZipCode_ALL">
<PagerSettings PreviousPageText="Move Previous" LastPageImageUrl="~/Images/MoveLast.gif" PreviousPageImageUrl="~/Images/MovePrevious.gif" FirstPageImageUrl="~/Images/MoveTop.gif" Position="TopAndBottom" Visible="False" NextPageImageUrl="~/Images/MoveNext.gif" PageButtonCount="100" LastPageText="Move Last" FirstPageText="Move First" NextPageText="Move Next"></PagerSettings>

<FooterStyle BorderStyle="Solid" BorderWidth="1px"></FooterStyle>
<Columns>
<asp:BoundField DataField="ID" Visible="False" SortExpression="ID" HeaderText="ID"></asp:BoundField>
<asp:BoundField DataField="ZipCode" SortExpression="ZipCode" HeaderText="Zip Code"></asp:BoundField>
<asp:BoundField DataField="Station" SortExpression="Station" HeaderText="Station"></asp:BoundField>
<asp:BoundField DataField="Service" SortExpression="Service" HeaderText="Service"></asp:BoundField>
<asp:BoundField DataField="Courier" SortExpression="Courier" HeaderText="Courier"></asp:BoundField>
<asp:BoundField DataField="Bank" SortExpression="Bank" HeaderText="Bank"></asp:BoundField>
<asp:BoundField DataField="Branch" SortExpression="Branch" HeaderText="Branch"></asp:BoundField>
<asp:BoundField DataField="Address" SortExpression="Address" HeaderText="Address"></asp:BoundField>
    <asp:BoundField DataField="Authorization" HeaderText="Authorization" SortExpression="Authorization" />
<asp:TemplateField ShowHeader="False">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
<ItemTemplate>
&nbsp;<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle BorderStyle="Solid" BorderColor="#404040"></PagerStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>
    <asp:ObjectDataSource ID="SP_RPS_MasterZipCode_ALL" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Get_RPS_MasterZipCodeLOV_ALL" TypeName="LOV_COLLECTION">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="%" Name="CourierID" SessionField="RPS_MasterZipCode_CourierID"
                Type="String" />
            <asp:SessionParameter DefaultValue="%" Name="StationID" SessionField="RPS_MasterZipCode_StationID"
                Type="String" />
            <asp:SessionParameter DefaultValue="%" Name="ServiceID" SessionField="RPS_MasterZipCode_ServiceID"
                Type="String" />
            <asp:SessionParameter DefaultValue="%" Name="BankID" SessionField="RPS_MasterZipCode_BankID"
                Type="String" />
            <asp:SessionParameter DefaultValue="%" Name="BranchID" SessionField="RPS_MasterZipCode_BranchID"
                Type="String" />
            <asp:SessionParameter DefaultValue="%" Name="ZipCode" SessionField="RPS_MasterZipCode_ZipCode"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
