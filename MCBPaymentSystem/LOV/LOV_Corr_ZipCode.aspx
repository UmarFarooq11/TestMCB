<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true" CodeFile="LOV_Corr_ZipCode.aspx.cs" Inherits="MasterZipCodeSetup_frmRPS_MasterZipCode" Title = "Master ZipCode Setup - LOV" %>
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
Text="Master ZipCode Setup" Width="100%" SkinID="Heading"></asp:Label>
<asp:UpdatePanel id="UpdatePanel1" runat="server">
<contenttemplate>
<ajaxToolkit:TabContainer style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" id="TabContainer1" runat="server" Font-Size="8pt" Font-Names="Verdana" ActiveTabIndex="0" BackColor="#FFFFEE" CssClass="ajax__tab_xp1"><ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="TabPanel1"><ContentTemplate>
    <table style="font-size: 8pt; font-family: Verdana" width="100%">
        <tbody>
            <tr align="right">
                <td style="width: 25%; text-align: right">
                    Courier Name :&nbsp;
                </td>
                <td style="width: 25%; text-align: left">
                    &nbsp;<asp:TextBox ID="TXT_COURIER_NAME" runat="server" SkinID="TXT" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 25%; text-align: right">
                    Station Name :&nbsp;
                </td>
                <td style="width: 25%; text-align: left">
                    &nbsp;<asp:TextBox ID="TXT_STATION_NAME" runat="server" SkinID="TXT" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr align="right">
                <td style="width: 25%; text-align: right">
                    Bank Name :&nbsp;
                </td>
                <td style="width: 25%; text-align: left">
                    &nbsp;<asp:TextBox ID="TXT_BANK_NAME" runat="server" SkinID="TXT" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 25%; text-align: right">
                    Branch Name :&nbsp;
                </td>
                <td style="width: 25%; text-align: left">
                    &nbsp;<asp:TextBox ID="TXT_BRANCH_NAME" runat="server" MaxLength="200" SkinID="TXT"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr align="right">
                <td style="width: 25%; text-align: right">
                    Zip Code :&nbsp; 
                </td>
                <td style="width: 25%; text-align: left">
                    &nbsp;<asp:TextBox ID="TXT_ZipCode" runat="server" SkinID="TXT" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 25%; text-align: right">
                </td>
                <td style="width: 25%; text-align: left">
                    &nbsp;</td>
            </tr>
        </tbody>
    </table>
</ContentTemplate>
<HeaderTemplate>
Basic Search
</HeaderTemplate>
</ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
        <ContentTemplate>
            <table style="font-size: 8pt; font-family: Verdana" width="100%">
                <tbody>
                    <tr align="right">
                        <td style="width: 25%; text-align: center">
                            <asp:RadioButton ID="RD_CourierID" runat="server" Checked="True" GroupName="gp" Text="Courier Name"
                                ValidationGroup="gp" />
                            &nbsp;
                        </td>
                        <td style="width: 25%; text-align: center">
                            <asp:RadioButton ID="RD_StationID" runat="server" GroupName="gp" Text="Station Name"
                                ValidationGroup="gp" />
                        </td>
                        <td style="width: 25%; text-align: center">
                            <asp:RadioButton ID="RD_BankID" runat="server" GroupName="gp" Text="Bank Name" ValidationGroup="gp" />
                        </td>
                        <td style="width: 25%; text-align: center">
                            <asp:RadioButton ID="RD_BranchID" runat="server" GroupName="gp" Text="Branch Name"
                                ValidationGroup="gp" />
                        </td>
                    </tr>
                    <tr align="right">
                        <td colspan="4" style="text-align: center">
                            <uc1:AlphaSelection ID="AlphaSelection1" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
        <HeaderTemplate>
            Alpha Search
        </HeaderTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer><eo:ToolBar id="ToolBar1" runat="server" AutoPostBack="True" OnItemClick="ToolBar1_ItemClick">
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
</asp:DropDownList></TD><TD><asp:ImageButton id="CMD_MoveNext" onclick="CMD_MoveNext_Click" runat="server" ImageUrl="~/Images/MoveNext.gif"></asp:ImageButton></TD><TD><asp:ImageButton id="CMD_MoveLast" onclick="CMD_MoveLast_Click" runat="server" ImageUrl="~/Images/MoveLast.gif"></asp:ImageButton></TD></TR></TBODY></TABLE><TABLE style="BACKGROUND-COLOR: gainsboro" class="login" cellSpacing=0 width="98%"><TBODY><TR><TD style="FONT-SIZE: 9pt; COLOR: #444444; FONT-FAMILY: Arial, Tahoma; HEIGHT: 6px; TEXT-ALIGN: left" colSpan=4><asp:GridView style="WIDTH: 100%" id="GridView1" runat="server" Width="95%" Font-Size="8pt" Font-Names="Verdana" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" OnRowDataBound="GridView1_RowDataBound" PageSize="20" ShowFooter="True" DataSourceID="SP_RPS_MasterZipCode_ALL">
<PagerSettings PreviousPageText="Move Previous" LastPageImageUrl="~/Images/MoveLast.gif" PreviousPageImageUrl="~/Images/MovePrevious.gif" FirstPageImageUrl="~/Images/MoveTop.gif" Position="TopAndBottom" Visible="False" NextPageImageUrl="~/Images/MoveNext.gif" PageButtonCount="100" LastPageText="Move Last" FirstPageText="Move First" NextPageText="Move Next"></PagerSettings>

<FooterStyle BorderStyle="Solid" BorderWidth="1px"></FooterStyle>
<Columns>
<asp:BoundField DataField="ID" Visible="False" SortExpression="ID" HeaderText="ID">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="ZipCode" SortExpression="ZipCode" HeaderText="Zip Code">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="Courier" SortExpression="Courier" HeaderText="Courier Name"></asp:BoundField>
<asp:BoundField DataField="Station" SortExpression="Station" HeaderText="Station Name"></asp:BoundField>
<asp:BoundField DataField="Bank" SortExpression="Bank" HeaderText="Bank Name"></asp:BoundField>
<asp:BoundField DataField="Branch" SortExpression="Branch" HeaderText="Branch Name"></asp:BoundField>
<asp:BoundField DataField="DistrictName" SortExpression="DistrictName" HeaderText="District Name"></asp:BoundField>
<asp:BoundField DataField="E_DateTime" SortExpression="E_DateTime" HeaderText="Creation Date"></asp:BoundField>
<asp:BoundField DataField="Authorization" SortExpression="Authorization" HeaderText="Authorization"></asp:BoundField>
<asp:TemplateField ShowHeader="False">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
<ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Select" ImageUrl="~/Images/edit1.gif"
                        OnClick="ImageButton1_Click" OnClientClick="CloseWindow();" />
                
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle BorderStyle="Solid" BorderColor="#404040"></PagerStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>
    <asp:ObjectDataSource ID="SP_RPS_MasterZipCode_ALL" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Get_SP_RPS_CorrBank_ZipCodeLOV" TypeName="LOV_COLLECTION">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="%" Name="ZipCode" SessionField="RPS_MasterZipCode_ZipCode"
                Type="String" />
            <asp:SessionParameter DefaultValue="%" Name="BANKNAME" SessionField="RPS_MasterZipCode_BankID"
                Type="String" />
            <asp:SessionParameter DefaultValue="%" Name="BRANCHNAME" SessionField="RPS_MasterZipCode_BranchID"
                Type="String" />
            <asp:SessionParameter DefaultValue="%" Name="COURIERNAME" SessionField="RPS_MasterZipCode_CourierID"
                Type="String" />
            <asp:SessionParameter DefaultValue="%" Name="STATIONNAME" SessionField="RPS_MasterZipCode_StationID"
                Type="String" />
            <asp:SessionParameter DefaultValue="0" Name="CorrBankID" SessionField="CorrBankID"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
