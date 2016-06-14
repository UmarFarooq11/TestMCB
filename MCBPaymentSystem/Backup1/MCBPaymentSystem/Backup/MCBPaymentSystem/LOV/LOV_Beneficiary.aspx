<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true" CodeFile="LOV_Beneficiary.aspx.cs" Inherits="MasterBeneficiaryInfo_LOV_Beneficiary" Title = "Master Beneficiary Info - LOV" %>
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
Text="Master Beneficiary Info" Width="100%" SkinID="Heading"></asp:Label>
<asp:UpdatePanel id="UpdatePanel1" runat="server">
<contenttemplate>
<ajaxToolkit:TabContainer style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" id="TabContainer1" runat="server" Font-Size="8pt" Font-Names="Verdana" ActiveTabIndex="0" CssClass="ajax__tab_xp1" BackColor="#FFFFEE"><ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="TabPanel1"><ContentTemplate>
<table style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" width="100%">
    <tbody>
        <tr align="right">
            <td style="WIDTH: 25%; TEXT-ALIGN: right">Remitter No :</td>
            <td style="WIDTH: 25%; TEXT-ALIGN: left"><asp:TextBox id="TXT_RemitterID" runat="server" SkinID="TXT" Width="200px" MaxLength="10"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="TXT_RemitterID" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender> </td><td style="WIDTH: 25%; TEXT-ALIGN: right">Branch Name :</td>
            <td style="WIDTH: 25%; TEXT-ALIGN: left"><asp:TextBox id="TXT_BranchID" runat="server" SkinID="TXT" Width="200px" MaxLength="50"></asp:TextBox></td>
         </tr>
        <tr align="right">
            <td style="WIDTH: 25%; TEXT-ALIGN: right">Beneficiary No :</td>
            <td style="WIDTH: 25%; TEXT-ALIGN: left"><asp:TextBox id="TXT_BeneficiaryNo" runat="server" SkinID="TXT" Width="200px" MaxLength="2"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" Enabled="True" TargetControlID="TXT_BeneficiaryNo" FilterType="Numbers"></ajaxToolkit:FilteredTextBoxExtender> </td><td style="WIDTH: 25%; TEXT-ALIGN: right">First Name :</td>
            <td style="WIDTH: 25%; TEXT-ALIGN: left"><asp:TextBox id="TXT_FirstName" runat="server" SkinID="TXT" Width="200px" MaxLength="20"></asp:TextBox> </td>
        </tr>
        <tr align="right">
            <td style="WIDTH: 25%; TEXT-ALIGN: right">Corresponding Bank Name :</td>
            <td style="WIDTH: 25%; TEXT-ALIGN: left"><asp:TextBox id="TXT_CorrespondingBankID" runat="server" SkinID="TXT" Width="200px" MaxLength="50"></asp:TextBox> </td>
            <td style="WIDTH: 25%; TEXT-ALIGN: right">Middle Name :</td>
            <td style="WIDTH: 25%; TEXT-ALIGN: left"><asp:TextBox id="TXT_MiddleName" runat="server" SkinID="TXT" Width="200px" MaxLength="20"></asp:TextBox></td>
         </tr>
       </tbody>
   </table>
</ContentTemplate>
<HeaderTemplate>
Basic Search
</HeaderTemplate>
</ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="TabPanel2"><ContentTemplate>
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" width="100%"><TBODY><TR><TD style="WIDTH: 25%; TEXT-ALIGN: center"><asp:RadioButton id="RD_FirstName" runat="server" Text="First Name" GroupName="A"></asp:RadioButton> &nbsp; </TD><TD style="WIDTH: 25%; TEXT-ALIGN: center"><asp:RadioButton id="RD_MiddleName" runat="server" Text="Middle Name" GroupName="A"></asp:RadioButton> &nbsp;&nbsp; </TD></TR><TR></TR></TBODY></TABLE><uc1:AlphaSelection id="AlphaSelection1" runat="server"></uc1:AlphaSelection> 
</ContentTemplate>
<HeaderTemplate>
Alpha Search
</HeaderTemplate>
</ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer><eo:ToolBar id="ToolBar1" runat="server" AutoPostBack="True" OnItemClick="ToolBar1_ItemClick"><Items>
<eo:ToolBarItem ImageUrl="00101001" CommandName="Cancel" ToolTip="Add New" Visible="False" Disabled="True"></eo:ToolBarItem>
<eo:ToolBarItem ImageUrl="00101032" CommandName="Cancel" ToolTip="Search" Disabled="True"></eo:ToolBarItem>
<eo:ToolBarItem ImageUrl="~/images/Refresh copy.gif" CommandName="Cancel" ToolTip="Refresh" Disabled="True"></eo:ToolBarItem>
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
</eo:ToolBar><TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 9pt; FONT-FAMILY: Arial, Tahoma" id="LBL_GridStatus" runat="server" Width="100px"></asp:Label></TD><TD><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; FONT-FAMILY: Arial, Tahoma" id="LBL_RowStatus" runat="server" Width="200px"></asp:Label></TD><TD width="100%"></TD><TD><asp:ImageButton id="CMD_MoveFirst" onclick="CMD_MoveFirst_Click" runat="server" ImageUrl="~/Images/MoveTop.gif"></asp:ImageButton></TD><TD><asp:ImageButton id="CMD_MoveBack" onclick="CMD_MoveBack_Click" runat="server" ImageUrl="~/Images/MovePrevious.gif"></asp:ImageButton></TD><TD><asp:DropDownList id="DRP_LIST" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DRP_LIST_SelectedIndexChanged">
</asp:DropDownList></TD><TD><asp:ImageButton id="CMD_MoveNext" onclick="CMD_MoveNext_Click" runat="server" ImageUrl="~/Images/MoveNext.gif"></asp:ImageButton></TD><TD><asp:ImageButton id="CMD_MoveLast" onclick="CMD_MoveLast_Click" runat="server" ImageUrl="~/Images/MoveLast.gif"></asp:ImageButton></TD></TR></TBODY></TABLE><TABLE style="BACKGROUND-COLOR: gainsboro" class="login" cellSpacing=0 width="100%"><TBODY><TR><TD style="FONT-SIZE: 9pt; COLOR: #444444; FONT-FAMILY: Arial, Tahoma; TEXT-ALIGN: left" colSpan=4><asp:GridView style="WIDTH: 100%" id="GridView1" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" OnRowDataBound="GridView1_RowDataBound" PageSize="20" ShowFooter="True" DataSourceID="SP_RPS_Beneficiary_ALL">
<PagerSettings PreviousPageText="Move Previous" LastPageImageUrl="~/Images/MoveLast.gif" PreviousPageImageUrl="~/Images/MovePrevious.gif" FirstPageImageUrl="~/Images/MoveTop.gif" Position="TopAndBottom" Visible="False" NextPageImageUrl="~/Images/MoveNext.gif" PageButtonCount="100" LastPageText="Move Last" FirstPageText="Move First" NextPageText="Move Next"></PagerSettings>

<FooterStyle BorderStyle="Solid" BorderWidth="1px"></FooterStyle>
<Columns>
<asp:BoundField DataField="ID" SortExpression="ID" HeaderText="ID" Visible="False"></asp:BoundField>
<asp:BoundField DataField="RemitterNo" SortExpression="RemitterNo" HeaderText="Remitter No"></asp:BoundField>
<asp:BoundField DataField="BeneficiaryNo" SortExpression="BeneficiaryNo" HeaderText="Beneficiary No"></asp:BoundField>
<asp:BoundField DataField="CorrespondingBankName" SortExpression="CorrespondingBankName" HeaderText="Corresponding Bank Name"></asp:BoundField>
<asp:BoundField DataField="BranchName" SortExpression="BranchName" HeaderText="Branch Name"></asp:BoundField>
<asp:BoundField DataField="FirstName" SortExpression="FirstName" HeaderText="First Name"></asp:BoundField>
<asp:BoundField DataField="MiddleName" SortExpression="MiddleName" HeaderText="Middle Name"></asp:BoundField>
<asp:BoundField DataField="LastName" SortExpression="LastName" HeaderText="Last Name"></asp:BoundField>
<asp:BoundField DataField="ZipCode" SortExpression="ZipCode" HeaderText="Zip Code"></asp:BoundField>
<asp:BoundField DataField="AccountNo" SortExpression="AccountNo" HeaderText="Account No"></asp:BoundField>
    <asp:BoundField DataField="Authorization" HeaderText="Authorization" SortExpression="Authorization" />
<asp:TemplateField ShowHeader="False">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
<ItemTemplate>
<asp:ImageButton id="ImageButton1" onclick="ImageButton1_Click" runat="server" ImageUrl="~/Images/edit1.gif" CommandName="Select" OnClientClick="CloseWindow();"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle BorderStyle="Solid" BorderColor="#404040"></PagerStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
</contenttemplate>
</asp:UpdatePanel>
    <asp:ObjectDataSource ID="SP_RPS_Beneficiary_ALL" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Get_RPS_Beneficiary_ALL" TypeName="LOV_COLLECTION">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="RemitterNo" SessionField="RPS_Beneficiary_RemitterNo"
                Type="String" />
            <asp:SessionParameter DefaultValue="0" Name="BeneficiaryNo" SessionField="RPS_Beneficiary_BeneficiaryNo"
                Type="String" />
            <asp:SessionParameter DefaultValue="0" Name="CorrespondingBankName" SessionField="RPS_Beneficiary_CorrespondingBankName"
                Type="String" />
            <asp:SessionParameter DefaultValue="0" Name="BranchName" SessionField="RPS_Beneficiary_BranchName"
                Type="String" />
            <asp:SessionParameter DefaultValue="0" Name="FirstName" SessionField="RPS_Beneficiary_FirstName"
                Type="String" />
            <asp:SessionParameter DefaultValue="0" Name="MiddleName" SessionField="RPS_Beneficiary_MiddleName"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
