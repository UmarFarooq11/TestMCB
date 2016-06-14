<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="CustomerConfigurationLinkSPC.aspx.cs" Inherits="CustomerConfigurationLinkSPC"
    Title="Customer Configuration Link" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[
function CompanyLOV() 
{
 var a;
 var c='<%= Session["HEIGHT"] %>';
var b='<%= Session["WIDTH"] %>';
  a=window.showModalDialog('../LOV/LOV_Company.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function ConfigdescLOV() 
{
 var a;
 var c='<%= Session["HEIGHT"] %>';
var b='<%= Session["WIDTH"] %>';
  a=window.showModalDialog('../LOV/LOV_CustomerConfigLink.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function TABLE1_onclick() {

}

// ]]>
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:FormView id="FormView1" runat="server" DataKeyNames="COMPANY_CODE" DataSourceID="SP_CUST_CONF_LINK_GetByCode" Font-Names="Verdana" Font-Size="10pt" OnPageIndexChanging="FormView1_PageIndexChanging" Width="100%"><EditItemTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD><eo:ToolBar id="EditToolbar" runat="server" Width="458px" OnItemClick="EditToolbar_ItemClick" AutoPostBack="True" __designer:wfdid="w36">
<DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac"></DownStyle>

<HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac"></HoverStyle>
<Items>
<eo:ToolBarItem ImageUrl="00101054" ToolTip="Update" AutoCheck="True" CommandName="Cancel" CommandArgument=""></eo:ToolBarItem>
<eo:ToolBarItem ImageUrl="~/images/Refresh copy.gif" ToolTip="Cancel" AutoCheck="True" CommandName="Cancel" CommandArgument=""></eo:ToolBarItem>
</Items>
<ItemTemplates>
<eo:ToolBarItem Type="Custom">
<NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></NormalStyle>

<HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></HoverStyle>

<DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></DownStyle>
</eo:ToolBarItem>
<eo:ToolBarItem Type="DropDownMenu">
<NormalStyle CssText="background-image:url('00100205');background-position-x:right;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;cursor:hand;padding-bottom:3px;padding-left:4px;padding-right:4px;padding-top:3px;"></NormalStyle>

<HoverStyle CssText="background-color:#ffe1ac;background-image:url('00100206');background-position-x:right;border-bottom-color:#335ea8;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#335ea8;border-left-style:solid;border-left-width:1px;border-right-color:#335ea8;border-right-style:solid;border-right-width:1px;border-top-color:#335ea8;border-top-style:solid;border-top-width:1px;cursor:hand;padding-bottom:2px;padding-left:3px;padding-right:3px;padding-top:2px;"></HoverStyle>

<DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; BACKGROUND-POSITION-X: right; BACKGROUND-IMAGE: url(00100206); PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; BACKGROUND-COLOR: #ffe1ac"></DownStyle>
</eo:ToolBarItem>
</ItemTemplates>

<NormalStyle CssText="PADDING-RIGHT: 4px; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 3px; CURSOR: hand; BORDER-TOP-STYLE: none; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"></NormalStyle>
</eo:ToolBar></TD></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR><TD style="COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2><asp:Label id="lblDuplicate_INSERT" runat="server" Font-Size="Smaller" __designer:wfdid="w37" Font-Bold="True" ForeColor="Red"></asp:Label>&nbsp; <asp:UpdateProgress id="UpdateProgress1" runat="server" __designer:wfdid="w38"><ProgressTemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" __designer:wfdid="w39"></asp:Image> 
</ProgressTemplate>
</asp:UpdateProgress></TD></TR><TR><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Customer&nbsp;Code&nbsp;:&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel2" runat="server" __designer:wfdid="w40"><ContentTemplate>
<asp:TextBox id="TXT_CustomerCode_EDIT" runat="server" Width="50px" Text='<%# Bind("company_code") %>' __designer:wfdid="w41" MaxLength="4" SkinID="TXT"></asp:TextBox><asp:ImageButton id="BTN_CustomerCode_EDIT" onclick="BTN_CustomerCode_EDIT_Click" runat="server" ImageUrl="~/images/search_16x16.png" __designer:wfdid="w42" CausesValidation="False" OnClientClick="CompanyLOV();"></asp:ImageButton><asp:TextBox id="TXT_CustomerName_EDIT" runat="server" Width="200px" Text='<%# Bind("company_name") %>' __designer:wfdid="w43" MaxLength="50" SkinID="TXT"></asp:TextBox><asp:RequiredFieldValidator id="REQ_BankCode_EDIT" runat="server" __designer:wfdid="w44" ControlToValidate="TXT_CustomerCode_EDIT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator> 
</ContentTemplate>
</asp:UpdatePanel></TD></TR><TR><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Configuration&nbsp;Defination&nbsp;ID :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel3" runat="server" __designer:wfdid="w45"><ContentTemplate>
<asp:TextBox id="TXT_ConfigDefID_EDIT" runat="server" Width="50px" Text='<%# bind("conf_def_id") %>' __designer:wfdid="w46" MaxLength="4" SkinID="TXT"></asp:TextBox><asp:ImageButton id="BTN_ConfigDefID_EDIT" onclick="BTN_ConfigDefID_EDIT_Click" runat="server" ImageUrl="~/images/search_16x16.png" __designer:wfdid="w47" CausesValidation="False" OnClientClick="ConfigdescLOV();"></asp:ImageButton><asp:TextBox id="TXT_ConfigDefName_EDIT" runat="server" Width="200px" Text='<%# bind("conf_def_desc") %>' __designer:wfdid="w48" MaxLength="50" SkinID="TXT"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator9" runat="server" __designer:wfdid="w49" ControlToValidate="TXT_ConfigDefID_EDIT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator> 
</ContentTemplate>
</asp:UpdatePanel></TD></TR><TR><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">FTP&nbsp;File Upload Path :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Upload_Path_EDIT" runat="server" Width="350px" __designer:wfdid="w50" MaxLength="200" SkinID="TXT"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">FTP File Upload User ID :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Upload_UserID_EDIT" runat="server" Width="120px" __designer:wfdid="w51" MaxLength="10" SkinID="TXT"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">FTP File Upload&nbsp;Password :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Upload_Password_EDIT" runat="server" Width="120px" __designer:wfdid="w52" MaxLength="10" SkinID="TXT"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">FTP File&nbsp;Move&nbsp;Path :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Move_Path_EDIT" runat="server" Width="350px" __designer:wfdid="w53" MaxLength="200" SkinID="TXT"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">FTP File&nbsp;Move&nbsp;User ID&nbsp;:&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Move_UserID_EDIT" runat="server" Width="120px" __designer:wfdid="w54" MaxLength="10" SkinID="TXT"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">FTP File&nbsp;Move&nbsp;Password :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Move_Password_EDIT" runat="server" Width="120px" __designer:wfdid="w55" MaxLength="10" SkinID="TXT"></asp:TextBox></TD></TR></TBODY></TABLE><BR />
</EditItemTemplate>
<InsertItemTemplate>
<TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD><eo:ToolBar id="InsertToolbar" runat="server" OnItemClick="InsertToolbar_ItemClick" AutoPostBack="True" __designer:wfdid="w56" Enabled='<%# bind("company_code") %>'>
<DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac"></DownStyle>

<HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac"></HoverStyle>
<Items>
<eo:ToolBarItem ImageUrl="00101001" ToolTip="Insert" AutoCheck="True" CommandName="Cancel" CommandArgument=""></eo:ToolBarItem>
<eo:ToolBarItem ImageUrl="~/images/Refresh copy.gif" ToolTip="Cancel" AutoCheck="True" CommandName="Cancel" CommandArgument=""></eo:ToolBarItem>
</Items>
<ItemTemplates>
<eo:ToolBarItem Type="Custom">
<NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></NormalStyle>

<HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></HoverStyle>

<DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></DownStyle>
</eo:ToolBarItem>
<eo:ToolBarItem Type="DropDownMenu">
<NormalStyle CssText="background-image:url('00100205');background-position-x:right;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;cursor:hand;padding-bottom:3px;padding-left:4px;padding-right:4px;padding-top:3px;"></NormalStyle>

<HoverStyle CssText="background-color:#ffe1ac;background-image:url('00100206');background-position-x:right;border-bottom-color:#335ea8;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#335ea8;border-left-style:solid;border-left-width:1px;border-right-color:#335ea8;border-right-style:solid;border-right-width:1px;border-top-color:#335ea8;border-top-style:solid;border-top-width:1px;cursor:hand;padding-bottom:2px;padding-left:3px;padding-right:3px;padding-top:2px;"></HoverStyle>

<DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; BACKGROUND-POSITION-X: right; BACKGROUND-IMAGE: url(00100206); PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; BACKGROUND-COLOR: #ffe1ac"></DownStyle>
</eo:ToolBarItem>
</ItemTemplates>

<NormalStyle CssText="PADDING-RIGHT: 4px; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 3px; CURSOR: hand; BORDER-TOP-STYLE: none; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"></NormalStyle>
</eo:ToolBar> </TD></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2><asp:Label id="lblDuplicate_INSERT" runat="server" Font-Size="Smaller" __designer:wfdid="w57" Font-Bold="True" ForeColor="Red"></asp:Label>&nbsp; </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Customer&nbsp;Code&nbsp;:&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel2" runat="server" __designer:wfdid="w58"><ContentTemplate>
&nbsp;<asp:TextBox id="TXT_CustomerCode_INSERT" runat="server" Width="50px" Text='<%# bind("company_code") %>' __designer:wfdid="w59" MaxLength="4" SkinID="TXT"></asp:TextBox>&nbsp;<asp:ImageButton id="BTN_CustomerCode_INSERT" onclick="BTN_CustomerCode_INSERT_Click" runat="server" ImageUrl="~/images/search_16x16.png" __designer:wfdid="w60" CausesValidation="False" OnClientClick="CompanyLOV();"></asp:ImageButton>&nbsp;<asp:TextBox id="TXT_CustomerName_INSERT" runat="server" Width="200px" Text='<%# bind("COMPANY_NAME") %>' __designer:wfdid="w61" MaxLength="50" SkinID="TXT"></asp:TextBox><asp:RequiredFieldValidator id="REQ_BankCode_INSERT" runat="server" __designer:wfdid="w62" ControlToValidate="TXT_CustomerCode_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator> 
</ContentTemplate>
</asp:UpdatePanel></TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Conf.&nbsp;Defination&nbsp;ID :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel3" runat="server" __designer:wfdid="w63"><ContentTemplate>
&nbsp;<asp:TextBox id="TXT_ConfigDefID_INSERT" runat="server" Width="50px" Text='<%# bind("conf_def_id") %>' __designer:wfdid="w64" MaxLength="4" SkinID="TXT"></asp:TextBox>&nbsp;<asp:ImageButton id="BTN_ConfigDefID_INSERT" onclick="BTN_ConfigDefID_INSERT_Click" runat="server" ImageUrl="~/images/search_16x16.png" __designer:wfdid="w65" CausesValidation="False" OnClientClick="ConfigdescLOV();"></asp:ImageButton>&nbsp;<asp:TextBox id="TXT_ConfigDefName_INSERT" runat="server" Width="200px" Text='<%# bind("conf_def_desc") %>' __designer:wfdid="w66" MaxLength="50" SkinID="TXT"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" __designer:wfdid="w67" ControlToValidate="TXT_ConfigDefID_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator> 
</ContentTemplate>
</asp:UpdatePanel></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">FTP&nbsp;File Upload Path :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Upload_Path_INSERT" runat="server" Width="350px" __designer:wfdid="w68" MaxLength="200" SkinID="TXT"></asp:TextBox></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">FTP File Upload User ID :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Upload_UserID_INSERT" runat="server" Width="120px" __designer:wfdid="w69" MaxLength="10" SkinID="TXT"></asp:TextBox></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">FTP File Upload&nbsp;Password :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Upload_Password_INSERT" runat="server" Width="120px" __designer:wfdid="w70" MaxLength="10" SkinID="TXT"></asp:TextBox></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">FTP File&nbsp;Move&nbsp;Path :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Move_Path_INSERT" runat="server" Width="350px" __designer:wfdid="w71" MaxLength="200" SkinID="TXT"></asp:TextBox></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">FTP File&nbsp;Move&nbsp;User ID&nbsp;:&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Move_UserID_INSERT" runat="server" Width="120px" __designer:wfdid="w72" MaxLength="10" SkinID="TXT"></asp:TextBox></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">FTP File&nbsp;Move&nbsp;Password :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Move_Password_INSERT" runat="server" Width="120px" __designer:wfdid="w73" MaxLength="10" SkinID="TXT"></asp:TextBox></TD></TR><TR align=right></TR></TBODY></TABLE> 
</InsertItemTemplate>
<ItemTemplate>
<TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD><eo:ToolBar id="DisplayToolBar" runat="server" OnItemClick="DisplayToolBar_ItemClick" AutoPostBack="True" __designer:wfdid="w313">
<DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac"></DownStyle>

<HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac"></HoverStyle>
<Items>
<eo:ToolBarItem ImageUrl="00101054" ToolTip="Edit" Disabled="True" AutoCheck="True" CommandName="Edit" CommandArgument="Edit"></eo:ToolBarItem>
<eo:ToolBarItem ImageUrl="00101060" ToolTip="Delete" CommandName="Cancel"></eo:ToolBarItem>
<eo:ToolBarItem ImageUrl="~/images/Refresh copy.gif" ToolTip="Cancel" Disabled="True" CommandName="Cancel"></eo:ToolBarItem>
<eo:ToolBarItem Type="Separator" CommandName="Cancel"></eo:ToolBarItem>
<eo:ToolBarItem ImageUrl="00000508" ToolTip="Authorize / Unauthorize" Disabled="True" CommandName="Cancel"></eo:ToolBarItem>
</Items>
<ItemTemplates>
<eo:ToolBarItem Type="Custom">
<NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></NormalStyle>

<HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></HoverStyle>

<DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></DownStyle>
</eo:ToolBarItem>
<eo:ToolBarItem Type="DropDownMenu">
<NormalStyle CssText="background-image:url('00100205');background-position-x:right;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;cursor:hand;padding-bottom:3px;padding-left:4px;padding-right:4px;padding-top:3px;"></NormalStyle>

<HoverStyle CssText="background-color:#ffe1ac;background-image:url('00100206');background-position-x:right;border-bottom-color:#335ea8;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#335ea8;border-left-style:solid;border-left-width:1px;border-right-color:#335ea8;border-right-style:solid;border-right-width:1px;border-top-color:#335ea8;border-top-style:solid;border-top-width:1px;cursor:hand;padding-bottom:2px;padding-left:3px;padding-right:3px;padding-top:2px;"></HoverStyle>

<DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; BACKGROUND-POSITION-X: right; BACKGROUND-IMAGE: url(00100206); PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; BACKGROUND-COLOR: #ffe1ac"></DownStyle>
</eo:ToolBarItem>
</ItemTemplates>

<NormalStyle CssText="PADDING-RIGHT: 4px; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 3px; CURSOR: hand; BORDER-TOP-STYLE: none; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"></NormalStyle>
</eo:ToolBar></TD></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 10pt; FONT-FAMILY: Verdana" class="air" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">Customer&nbsp;Code&nbsp;:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:Label id="TXT_CurrencyCode_DISPLAY" runat="server" Width="95%" Text='<%# Bind("COMPANY_CODE") %>' __designer:wfdid="w314"></asp:Label></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">Customer&nbsp;Name :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:Label id="TXT_CurrencyName_DISPLAY" runat="server" Width="95%" Text='<%# BIND("COMPANY_NAME") %>' __designer:wfdid="w315"></asp:Label> </TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1"><SPAN style="FONT-SIZE: 11pt; FONT-FAMILY: Calibri">Configuration&nbsp;defination link ID</SPAN> :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:Label id="TXT_TXT_ConfigdeflinkID_DISPLAY" runat="server" Width="95%" Text='<%# Bind("CONF_DEF_ID") %>' __designer:wfdid="w316"></asp:Label></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1"><SPAN style="FONT-SIZE: 11pt; FONT-FAMILY: Calibri">Configuration&nbsp;defination&nbsp;link&nbsp;Name :</SPAN></TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="TXT_ConfigdeflinkName_DISPLAY" runat="server" Width="95%" Text='<%# Bind("conf_def_desc") %>' __designer:wfdid="w317"></asp:Label></TD></TR><TR align=right><TD style="TEXT-ALIGN: left" class="ColLines1" colSpan=2></TD></TR><TR align=right></TR></TBODY></TABLE>
</ItemTemplate>
<HeaderTemplate>
<asp:Label id="Label_HEAD" runat="server" Width="100%" Font-Size="20pt" Font-Names="Trebuchet MS" Text="Customer Configuration Link" __designer:wfdid="w241" SkinID="FormViewHeading"></asp:Label> 
</HeaderTemplate>
</asp:FormView> <TABLE class="loginDown" cellSpacing=0 width="100%"><TBODY><TR><TD></TD></TR></TBODY></TABLE><asp:ObjectDataSource id="SP_CUST_CONF_LINK_GetByCode" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Get_CUST_CONF_LINK_GetByCode" TypeName="LOV_COLLECTION"><SelectParameters>
<asp:SessionParameter SessionField="COMPANY_CODE" DefaultValue="%" Name="COMPANY_CODE" Type="String"></asp:SessionParameter>
<asp:SessionParameter SessionField="CONF_DEF_ID" DefaultValue="%" Name="CONF_DEF_ID" Type="String"></asp:SessionParameter>
</SelectParameters>
</asp:ObjectDataSource> 
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
