<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="frmSPDS_AuthorizationMatrixSPC.aspx.cs" Inherits="AuthorizationMatrix_frmSPDS_AuthorizationMatrixSPC"
    Title="Authorization MatrixDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
function CustomerLOV()
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_Customer.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function InstrumnetLOV()
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_CustomerInstrumentSetup.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function MakerSignatoryLOV()
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_SignatorySetup.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function CheckerSignatoryLOV()
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_SignatorySetup.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function CategoryLOV()
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_Category1.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function SearchCustomerIDINSERT()
{ 
    document.getElementById("ctl00_ContentPlaceHolder1_BTN_CustomerIDSerach_INSERT").click();
   
    return false;
}
function SearchCustomerIDEDIT()
{
    document.getElementById("ctl00_ContentPlaceHolder1_BTN_CustomerIDSerach_EDIT").click();
    return false;
}
function SearchInstrumentID_INSERT()
{
    document.getElementById("ctl00_ContentPlaceHolder1_BTN_InstrumentIDSearch_INSERT").click();
    return false;
}
function SearchInstrumentID_EDIT()
{
    document.getElementById("ctl00_ContentPlaceHolder1_BTN_InstrumentIDSearch_EDIT").click();
    return false;
}
function SearchMakerID_INSERT()
{
    document.getElementById("ctl00_ContentPlaceHolder1_BTN_MakerSignatoryIDSearch_INSERT").click();
    return false;
}
function SearchMakerID_EDIT()
{
    document.getElementById("ctl00_ContentPlaceHolder1_BTN_MakerSignatoryIDSearch_EDIT").click();
    return false;
}
function SearchCheckerID_INSERT()
{
    document.getElementById("ctl00_ContentPlaceHolder1_BTN_CheckerSignatoryIDSearch_INSERT").click();
    return false;
}
function SearchCheckerID_EDIT()
{
    document.getElementById("ctl00_ContentPlaceHolder1_BTN_CheckerSignatoryIDSearch_EDIT").click();
    return false;
}
function SearchCategoryID_INSERT()
{
    document.getElementById("ctl00_ContentPlaceHolder1_BTN_CategoryIDSearch_INSERT").click();
    return false;
}
function SearchCategoryID_EDIT()
{
    document.getElementById("ctl00_ContentPlaceHolder1_BTN_CategoryIDSearch_EDIT").click();
    return false;
}
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
<asp:FormView id="FormView1" runat="server" Width="100%" OnPageIndexChanging="FormView1_PageIndexChanging" Font-Size="10pt" Font-Names="Verdana" DataSourceID="ObjSP_SPDS_AuthorizationMatrix_SPC" DataKeyNames="ID" OnDataBound="FormView1_DataBound"><EditItemTemplate>
<TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD><eo:ToolBar id="EditToolbar" runat="server" SeparatorImage OnItemClick="EditToolbar_ItemClick" AutoPostBack="True">
                                                <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac">
                                                </DownStyle>
                                                <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac">
                                                </HoverStyle>
                                                <Items>
                                                    <eo:ToolBarItem ImageUrl="00101054" ToolTip="Update" AutoCheck="True" CommandName="Cancel" CommandArgument=""></eo:ToolBarItem>
                                                    <eo:ToolBarItem ImageUrl="~/images/Refresh copy.gif" ToolTip="Cancel" AutoCheck="True" CommandName="Cancel" CommandArgument=""></eo:ToolBarItem>
                                                </Items>
                                                <ItemTemplates>
                                                    <eo:ToolBarItem Type="Custom">
                                                        <NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                                                        </NormalStyle>
                                                        <HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                                                        </HoverStyle>
                                                        <DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                                                        </DownStyle>
                                                    </eo:ToolBarItem>
                                                    <eo:ToolBarItem Type="DropDownMenu">
                                                        <NormalStyle CssText="background-image:url('00100205');background-position-x:right;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;cursor:hand;padding-bottom:3px;padding-left:4px;padding-right:4px;padding-top:3px;">
                                                        </NormalStyle>
                                                        <HoverStyle CssText="background-color:#ffe1ac;background-image:url('00100206');background-position-x:right;border-bottom-color:#335ea8;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#335ea8;border-left-style:solid;border-left-width:1px;border-right-color:#335ea8;border-right-style:solid;border-right-width:1px;border-top-color:#335ea8;border-top-style:solid;border-top-width:1px;cursor:hand;padding-bottom:2px;padding-left:3px;padding-right:3px;padding-top:2px;">
                                                        </HoverStyle>
                                                        <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; BACKGROUND-POSITION-X: right; BACKGROUND-IMAGE: url(00100206); PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; BACKGROUND-COLOR: #ffe1ac">
                                                        </DownStyle>
                                                    </eo:ToolBarItem>
                                                </ItemTemplates>
                                                <NormalStyle CssText="PADDING-RIGHT: 4px; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 3px; CURSOR: hand; BORDER-TOP-STYLE: none; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
                                                </NormalStyle>
                                            </eo:ToolBar> </TD></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2><asp:Label id="lblDuplicate_EDIT" runat="server" Font-Size="Smaller" ForeColor="Red" Font-Bold="True"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server"><ProgressTemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif"></asp:Image> 
</ProgressTemplate>
</asp:UpdateProgress> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Customer Code&nbsp;:&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel1" runat="server"><ContentTemplate>
&nbsp;<asp:TextBox id="TXT_CUSTOMER_CODE_EDIT" runat="server" Width="50px" Text='<%# Bind("CustomerCode") %>' MaxLength="4" SkinID="TXT"></asp:TextBox> <asp:ImageButton id="BTN_Customer_ID_EDIT" onclick="BTN_Customer_ID_EDIT_Click" runat="server" CausesValidation="False" ImageUrl="~/images/search_16x16.png" OnClientClick="CustomerLOV();">
                                                        </asp:ImageButton> <asp:TextBox id="TXT_CustomerName_EDIT" runat="server" Width="200px" Text='<%# Bind("CustomerName") %>' MaxLength="4" Enabled="False" SkinID="TXT"></asp:TextBox> <asp:RequiredFieldValidator id="REQ_CUSTOMER_ID_EDIT" runat="server" ControlToValidate="TXT_CUSTOMER_ID_EDIT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator>&nbsp; <asp:TextBox id="TXT_CUSTOMER_ID_EDIT" runat="server" Width="50px" Text='<%# Bind("Customer_ID") %>' MaxLength="4" SkinID="TXT"></asp:TextBox> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Maker Signatory ID :&nbsp;</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel3" runat="server"><ContentTemplate>
&nbsp;<asp:TextBox id="TXT_MAKE_SIGNATORY_ID_EDIT" runat="server" Width="50px" Text='<%# Bind("MAKE_SIGNATORY_ID") %>' MaxLength="4" SkinID="TXT"></asp:TextBox> <asp:ImageButton id="BTN_MakerSignatory_ID_EDIT" onclick="BTN_MakerSignatory_ID_EDIT_Click" runat="server" ImageUrl="~/images/search_16x16.png" OnClientClick="MakerSignatoryLOV();">
                                                        </asp:ImageButton> <asp:TextBox id="TXT_MakerSignatoryName_EDIT" runat="server" Width="200px" Text='<%# Session["SPDS_AuthorizationMatrix_MAKE_SIGNATORY_NAME"] %>' MaxLength="4" Enabled="False" SkinID="TXT"></asp:TextBox> <asp:RequiredFieldValidator id="REQ_MAKE_SIGNATORY_ID_EDIT" runat="server" ControlToValidate="TXT_MAKE_SIGNATORY_ID_EDIT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator>&nbsp;<ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender10" runat="server" TargetControlID="TXT_MAKE_SIGNATORY_ID_EDIT" FilterType="Numbers" ValidChars="0123456789">
                                                            </ajaxToolkit:FilteredTextBoxExtender> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Checker Signatory ID :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel4" runat="server"><ContentTemplate>
&nbsp;<asp:TextBox id="TXT_CHECKER_SIGNATORY_ID_EDIT" runat="server" Width="50px" Text='<%# Bind("CHECKER_SIGNATORY_ID") %>' MaxLength="4" SkinID="TXT"></asp:TextBox> <asp:ImageButton id="BTN_CheckerSignatory_ID_EDIT" onclick="BTN_CheckerSignatory_ID_EDIT_Click" runat="server" ImageUrl="~/images/search_16x16.png" OnClientClick="CheckerSignatoryLOV();">
                                                        </asp:ImageButton> <asp:TextBox id="TXT_CheckerSignatoryName_EDIT" runat="server" Width="200px" Text='<%# Session["SPDS_AuthorizationMatrix_CHECKER_SIGNATORY_NAME"] %>' MaxLength="4" Enabled="False" SkinID="TXT"></asp:TextBox> <asp:RequiredFieldValidator id="REQ_CHECKER_SIGNATORY_ID_EDIT" runat="server" ControlToValidate="TXT_CHECKER_SIGNATORY_ID_EDIT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator>&nbsp;<ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender11" runat="server" TargetControlID="TXT_CHECKER_SIGNATORY_ID_EDIT" FilterType="Numbers" ValidChars="0123456789">
                                                            </ajaxToolkit:FilteredTextBoxExtender> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Category ID :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel5" runat="server"><ContentTemplate>
&nbsp;<asp:TextBox id="TXT_CATEGORY_ID_EDIT" runat="server" Width="50px" Text='<%# Bind("CATEGORY_ID") %>' MaxLength="4" SkinID="TXT"></asp:TextBox> <asp:ImageButton id="BTN_Category_ID_EDIT" onclick="BTN_Category_ID_EDIT_Click" runat="server" ImageUrl="~/images/search_16x16.png" OnClientClick="CategoryLOV();"></asp:ImageButton> <asp:TextBox id="TXT_CATEGORY_Name_EDIT" runat="server" Width="200px" Text='<%# Session["SPDS_AuthorizationMatrix_CATEGORYNAME"] %>' MaxLength="4" Enabled="False" SkinID="TXT"></asp:TextBox> <asp:RequiredFieldValidator id="REQ_CATEGORY_ID_EDIT" runat="server" ControlToValidate="TXT_CATEGORY_ID_EDIT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator><ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender12" runat="server" TargetControlID="TXT_CATEGORY_ID_EDIT" FilterType="Numbers" ValidChars="0123456789">
                                                            </ajaxToolkit:FilteredTextBoxExtender> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">From Limit :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:TextBox id="TXT_FromLimit_EDIT" runat="server" Width="100px" Text='<%# Bind("FROM_LIMIT") %>' MaxLength="8" Enabled="False" SkinID="TXT"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender13" runat="server" TargetControlID="TXT_FromLimit_EDIT" FilterType="Numbers" ValidChars="0123456789">
                                                </ajaxToolkit:FilteredTextBoxExtender> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">To Limit :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:TextBox id="TXT_ToLimit_EDIT" runat="server" Width="100px" Text='<%# Bind("TO_LIMIT") %>' MaxLength="10" Enabled="False" SkinID="TXT"></asp:TextBox> <asp:CompareValidator id="CompareValidator2" runat="server" ControlToValidate="TXT_ToLimit_EDIT" ErrorMessage="Proper Information Required" Type="Integer" Operator="GreaterThan" ControlToCompare="TXT_FromLimit_EDIT"></asp:CompareValidator> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender14" runat="server" TargetControlID="TXT_ToLimit_EDIT" FilterType="Numbers" ValidChars="0123456789">
                                                </ajaxToolkit:FilteredTextBoxExtender> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1"></TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel2" runat="server" Visible="False"><ContentTemplate>
&nbsp;<asp:TextBox id="TXT_INSTRUMENT_ID_EDIT" runat="server" Width="50px" MaxLength="4" SkinID="TXT"></asp:TextBox> <asp:ImageButton id="BTN_Instrument_ID_EDIT" onclick="BTN_Instrument_ID_EDIT_Click" runat="server" CausesValidation="False" ImageUrl="~/images/search_16x16.png" OnClientClick="InstrumnetLOV();"></asp:ImageButton> <asp:TextBox id="TXT_InstrumentName_EDIT" runat="server" Width="200px" MaxLength="4" Enabled="False" SkinID="TXT"></asp:TextBox> <asp:RequiredFieldValidator id="REQ_INSTRUMENT_ID_EDIT" runat="server" ControlToValidate="TXT_INSTRUMENT_ID_EDIT" ErrorMessage="Proper Information Required" Visible="False"></asp:RequiredFieldValidator> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender9" runat="server" TargetControlID="TXT_INSTRUMENT_ID_EDIT" FilterType="Numbers" ValidChars="0123456789">
                                                        </ajaxToolkit:FilteredTextBoxExtender> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE>
</EditItemTemplate>
<InsertItemTemplate>
<TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD><eo:ToolBar id="InsertToolbar" runat="server" AutoPostBack="True" OnItemClick="InsertToolbar_ItemClick">
                                                <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                <Items>
                                                    <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" ImageUrl="00101001"
                                                        ToolTip="Insert">
                                                    </eo:ToolBarItem>
                                                    <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" ImageUrl="~/images/Refresh copy.gif"
                                                        ToolTip="Cancel">
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
                                            </eo:ToolBar> </TD></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" class="air" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2><asp:Label id="lblDuplicate_INSERT" runat="server" Font-Size="Smaller" Font-Bold="True" ForeColor="Red"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server"><ProgressTemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif"></asp:Image> 
</ProgressTemplate>
</asp:UpdateProgress> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Customer Code :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel6" runat="server"><ContentTemplate>
&nbsp;<asp:TextBox id="TXT_CUSTOMER_ID_INSERT" runat="server" Width="50px" Text='<%# Bind("Bank_code") %>' SkinID="TXT" MaxLength="5"></asp:TextBox>&nbsp;<asp:ImageButton id="BTN_Customer_ID_INSERT" onclick="BTN_Customer_ID_INSERT_Click" runat="server" CausesValidation="False" ImageUrl="~/images/search_16x16.png" OnClientClick="CustomerLOV();"></asp:ImageButton>&nbsp; <asp:TextBox id="TXT_CustomerName_INSERT" runat="server" Width="200px" Text='<%# Bind("MAKE_SIGNATORY_ID") %>' SkinID="TXT" Enabled="False"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator id="REQ_CUSTOMER_ID_INSERT" runat="server" ControlToValidate="TXT_CUSTOMER_ID_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator>&nbsp; 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Maker Signatory ID :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel8" runat="server"><ContentTemplate>
&nbsp;<asp:TextBox id="TXT_MAKE_SIGNATORY_ID_INSERT" runat="server" Width="50px" Text='<%# Bind("MAKE_SIGNATORY_ID") %>' SkinID="TXT" MaxLength="4"></asp:TextBox> <asp:ImageButton id="BTN_MakerSignatory_ID_INSERT" onclick="BTN_MakerSignatory_ID_INSERT_Click" runat="server" CausesValidation="False" ImageUrl="~/images/search_16x16.png" OnClientClick="MakerSignatoryLOV();"></asp:ImageButton>&nbsp;<asp:TextBox id="TXT_MakerSignatoryName_INSERT" runat="server" Width="200px" Text='<%# Bind("MAKE_SIGNATORY_ID") %>' SkinID="TXT" MaxLength="4" Enabled="False"></asp:TextBox> <asp:RequiredFieldValidator id="REQ_MAKE_SIGNATORY_ID_INSERT" runat="server" ControlToValidate="TXT_MAKE_SIGNATORY_ID_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender3" runat="server" TargetControlID="TXT_MAKE_SIGNATORY_ID_INSERT" FilterType="Numbers" ValidChars="0123456789">
                                                        </ajaxToolkit:FilteredTextBoxExtender> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Checker Signatory ID :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel10" runat="server"><ContentTemplate>
&nbsp;<asp:TextBox id="TXT_CHECKER_SIGNATORY_ID_INSERT" runat="server" Width="50px" Text='<%# Bind("CHECKER_SIGNATORY_ID") %>' SkinID="TXT" MaxLength="4"></asp:TextBox> <asp:ImageButton id="BTN_CheckerSignatory_ID_INSERT" onclick="BTN_CheckerSignatory_ID_INSERT_Click" runat="server" CausesValidation="False" ImageUrl="~/images/search_16x16.png" OnClientClick="CheckerSignatoryLOV();"></asp:ImageButton>&nbsp;<asp:TextBox id="TXT_CheckerSignatoryName_INSERT" runat="server" Width="200px" Text='<%# Bind("MAKE_SIGNATORY_ID") %>' SkinID="TXT" Enabled="False"></asp:TextBox> <asp:RequiredFieldValidator id="REQ_CHECKER_SIGNATORY_ID_INSERT" runat="server" ControlToValidate="TXT_CHECKER_SIGNATORY_ID_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator>&nbsp;<ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender4" runat="server" TargetControlID="TXT_CHECKER_SIGNATORY_ID_INSERT" FilterType="Numbers" ValidChars="0123456789">
                                                            </ajaxToolkit:FilteredTextBoxExtender> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Category ID :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel9" runat="server"><ContentTemplate>
&nbsp;<asp:TextBox id="TXT_CATEGORY_ID_INSERT" runat="server" Width="50px" Text='<%# Bind("CATEGORY_ID") %>' SkinID="TXT" MaxLength="4"></asp:TextBox>&nbsp;<asp:ImageButton id="BTN_Category_ID_INSERT" onclick="BTN_Category_ID_INSERT_Click" runat="server" CausesValidation="False" ImageUrl="~/images/search_16x16.png" OnClientClick="CategoryLOV();"></asp:ImageButton> <asp:TextBox id="TXT_CATEGORY_Name_INSERT" runat="server" Width="200px" SkinID="TXT" Enabled="False"></asp:TextBox> <asp:RequiredFieldValidator id="REQ_CATEGORY_ID_INSERT" runat="server" ControlToValidate="TXT_CATEGORY_ID_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator>&nbsp;<ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender5" runat="server" TargetControlID="TXT_CATEGORY_ID_INSERT" FilterType="Numbers" ValidChars="0123456789">
                                                            </ajaxToolkit:FilteredTextBoxExtender> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">From Limit&nbsp; :&nbsp;</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:TextBox id="TXT_FromLimit_INSERT" runat="server" Width="100px" Text='<%# Bind("A_DateTime") %>' SkinID="TXT" MaxLength="8" Enabled="False"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender6" runat="server" TargetControlID="TXT_FromLimit_INSERT" FilterType="Numbers" ValidChars="0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">To Limit :&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:TextBox id="TXT_ToLimit_INSERT" runat="server" Width="100px" Text='<%# Bind("A_UserID") %>' SkinID="TXT" MaxLength="10" Enabled="False"></asp:TextBox> <asp:CompareValidator id="CompareValidator1" runat="server" ControlToValidate="TXT_ToLimit_INSERT" ErrorMessage="Proper Information Required" Type="Integer" Operator="GreaterThan" ControlToCompare="TXT_FromLimit_INSERT"></asp:CompareValidator> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender7" runat="server" TargetControlID="TXT_ToLimit_INSERT" FilterType="Numbers" ValidChars="0123456789">
                                                </ajaxToolkit:FilteredTextBoxExtender> &nbsp; </TD></TR>
                                                <tr align="right">
                                                    <td class="ColLines1" style="width: 15%; color: red; text-align: right">
                                                    </td>
                                                    <td class="ColLines" style="width: 35%; text-align: left">
                                                        <asp:UpdatePanel id="UpdatePanel7" runat="server" Visible="False"><ContentTemplate>
&nbsp;<asp:TextBox id="TXT_INSTRUMENT_ID_INSERT" runat="server" Width="50px" Text='<%# Bind("INSTRUMENT_ID") %>' SkinID="TXT" MaxLength="4"></asp:TextBox> <asp:ImageButton id="BTN_Instrument_ID_INSERT" onclick="BTN_Instrument_ID_INSERT_Click" runat="server" CausesValidation="False" ImageUrl="~/images/search_16x16.png" OnClientClick="InstrumnetLOV();"></asp:ImageButton>&nbsp;<asp:TextBox id="TXT_InstrumentName_INSERT" runat="server" Width="200px" Text='<%# Bind("MAKE_SIGNATORY_ID") %>' SkinID="TXT" Enabled="False"></asp:TextBox> <asp:RequiredFieldValidator id="REQ_INSTRUMENT_ID_INSERT" runat="server" ControlToValidate="TXT_INSTRUMENT_ID_INSERT" ErrorMessage="Proper Information Required" Visible="False"></asp:RequiredFieldValidator><ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="TXT_INSTRUMENT_ID_INSERT" FilterType="Numbers" ValidChars="0123456789">
                                                            </ajaxToolkit:FilteredTextBoxExtender> 
</ContentTemplate>
</asp:UpdatePanel> 
                                                    </td>
                                                </tr>
                                                <TR align=right></TR><TR align=right></TR></TBODY></TABLE>
</InsertItemTemplate>
<ItemTemplate>
                                <table class="login" cellspacing="0" width="100%">
                                    <tbody>
                                        <tr>
                                            <td style="font-size: 1px">
                                                <eo:ToolBar ID="DisplayToolBar" runat="server" SeparatorImage OnItemClick="DisplayToolBar_ItemClick"
                                                    BackgroundImageRight BackgroundImageLeft BackgroundImage AutoPostBack="True">
                                                    <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac">
                                                    </DownStyle>
                                                    <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac">
                                                    </HoverStyle>
                                                    <Items>
                                                        <eo:ToolBarItem ImageUrl="00101054" ToolTip="Edit" Disabled="True" AutoCheck="True"
                                                            CommandName="Edit" CommandArgument="Edit">
                                                        </eo:ToolBarItem>
                                                        <eo:ToolBarItem ImageUrl="00101060" ToolTip="Delete" Disabled="True" CommandName="Cancel">
                                                        </eo:ToolBarItem>
                                                        <eo:ToolBarItem ImageUrl="~/images/Refresh copy.gif" ToolTip="Cancel" Disabled="True"
                                                            CommandName="Cancel">
                                                        </eo:ToolBarItem>
                                                        <eo:ToolBarItem Type="Separator" CommandName="Cancel">
                                                        </eo:ToolBarItem>
                                                        <eo:ToolBarItem ImageUrl="00000508" ToolTip="Authorize / Unauthorize" Disabled="True"
                                                            CommandName="Cancel">
                                                        </eo:ToolBarItem>
                                                    </Items>
                                                    <ItemTemplates>
                                                        <eo:ToolBarItem Type="Custom">
                                                            <NormalStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                                                            </NormalStyle>
                                                            <HoverStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                                                            </HoverStyle>
                                                            <DownStyle CssText="background-color:transparent;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;">
                                                            </DownStyle>
                                                        </eo:ToolBarItem>
                                                        <eo:ToolBarItem Type="DropDownMenu">
                                                            <NormalStyle CssText="background-image:url('00100205');background-position-x:right;border-bottom-style:none;border-left-style:none;border-right-style:none;border-top-style:none;cursor:hand;padding-bottom:3px;padding-left:4px;padding-right:4px;padding-top:3px;">
                                                            </NormalStyle>
                                                            <HoverStyle CssText="background-color:#ffe1ac;background-image:url('00100206');background-position-x:right;border-bottom-color:#335ea8;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#335ea8;border-left-style:solid;border-left-width:1px;border-right-color:#335ea8;border-right-style:solid;border-right-width:1px;border-top-color:#335ea8;border-top-style:solid;border-top-width:1px;cursor:hand;padding-bottom:2px;padding-left:3px;padding-right:3px;padding-top:2px;">
                                                            </HoverStyle>
                                                            <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; BACKGROUND-POSITION-X: right; BACKGROUND-IMAGE: url(00100206); PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; BACKGROUND-COLOR: #ffe1ac">
                                                            </DownStyle>
                                                        </eo:ToolBarItem>
                                                    </ItemTemplates>
                                                    <NormalStyle CssText="PADDING-RIGHT: 4px; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 3px; CURSOR: hand; BORDER-TOP-STYLE: none; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">
                                                    </NormalStyle>
                                                </eo:ToolBar>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table style="font-size: 10pt; font-family: Verdana" class="air" cellspacing="0"
                                    width="100%">
                                    <tbody>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="ColLines1">
                                                Customer Code :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                &nbsp;<asp:Label ID="TXT_CUSTOMER_ID_DISPLAY" runat="server" Width="95%" Text='<%# Bind("CustomerDetail") %>'
                                                    Font-Bold="False"></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="ColLines1">
                                                Maker Signatory ID :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                &nbsp;<asp:Label ID="TXT_MAKE_SIGNATORY_ID_DISPLAY" runat="server" Width="95%" Text='<%# Bind("MAKER_SIGNATORY_Detail") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="ColLines1">
                                                Checker&nbsp;Signatory&nbsp;ID :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                &nbsp;<asp:Label ID="TXT_CHECKER_SIGNATORY_ID_DISPLAY" runat="server" Width="95%"
                                                    Text='<%# Bind("CHECKER_SIGNATORY_Detail") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="ColLines1">
                                                Category ID :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                &nbsp;<asp:Label ID="TXT_CATEGORY_ID_DISPLAY" runat="server" Width="95%" Text='<%# Bind("CATEGORY_DETAIL") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="ColLines1">
                                                From Limit :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                &nbsp;<asp:Label ID="TXT_FORM_LIMIT_DISPLAY" runat="server" Width="95%" Text='<%# Bind("FROM_LIMIT") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="ColLines1">
                                                To&nbsp;Limit :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                &nbsp;<asp:Label ID="TXT_TO_LIMIT_DISPLAY" runat="server" Width="95%" Text='<%# Bind("TO_LIMIT") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td class="ColLines1" style="width: 15%; text-align: right">
                                            </td>
                                            <td class="ColLines" style="width: 35%; text-align: left">
                                                <asp:Label ID="TXT_INSTRUMENT_ID_DISPLAY" runat="server" Width="95%" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: left" class="ColLines1" colspan="2">
                                                <asp:Label ID="Label1" runat="server" Font-Size="20pt" Font-Names="Trebuchet MS"
                                                    Text="Administration" Font-Bold="False" SkinID="FormViewHeading"></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="ColLines1">
                                                Edited By :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                &nbsp;<asp:Label ID="TXT_E_UserID_DISPLAY" runat="server" Width="95%" Text='<%# Bind("E_UserID") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="ColLines1">
                                                Authorized By :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                &nbsp;<asp:Label ID="TXT_A_UserID_DISPLAY" runat="server" Width="95%" Text='<%# Bind("A_UserID") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="ColLines1">
                                                Edited At :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                &nbsp;<asp:Label ID="TXT_E_DateTime_DISPLAY" runat="server" Width="95%" Text='<%# Bind("E_DateTime") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="ColLines1">
                                                Authorized At :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                &nbsp;<asp:Label ID="TXT_A_DateTime_DISPLAY" runat="server" Width="95%" Text='<%# Bind("A_DateTime") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                        </tr>
                                        <tr align="right">
                                        </tr>
                                    </tbody>
                                </table>
                            
</ItemTemplate>
<HeaderTemplate>
                                <asp:Label ID="Label_HEAD" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
                                    Width="100%" Text="Authorization Matrix" SkinID="FormViewHeading"></asp:Label>
                            
</HeaderTemplate>
</asp:FormView> <TABLE class="loginDown" cellSpacing=0 width="100%"><TBODY><TR><TD></TD></TR></TBODY></TABLE><asp:Button id="BTN_CustomerIDSerach_EDIT" onclick="BTN_CustomerIDSerach_EDIT_Click" runat="server" Text="..." CausesValidation="False"></asp:Button><asp:Button id="BTN_CustomerIDSerach_INSERT" onclick="BTN_CustomerIDSerach_INSERT_Click" runat="server" Text="..." CausesValidation="False">
                            </asp:Button> &nbsp; <asp:Button id="BTN_InstrumentIDSearch_INSERT" onclick="BTN_InstrumentIDSearch_INSERT_Click" runat="server" Text="..." CausesValidation="False"></asp:Button><asp:Button id="BTN_InstrumentIDSearch_EDIT" onclick="BTN_InstrumentIDSearch_EDIT_Click" runat="server" Text="..." CausesValidation="False">
                            </asp:Button>&nbsp; <asp:Button id="BTN_MakerSignatoryIDSearch_INSERT" onclick="BTN_MakerSignatoryIDSearch_INSERT_Click" runat="server" Text="..." CausesValidation="False"></asp:Button><asp:Button id="BTN_MakerSignatoryIDSearch_EDIT" onclick="BTN_MakerSignatoryIDSearch_EDIT_Click" runat="server" Text="..." CausesValidation="False">
                            </asp:Button> &nbsp; &nbsp;<asp:Button id="BTN_CategoryIDSearch_INSERT" onclick="BTN_CategoryIDSearch_INSERT_Click" runat="server" Text="..." CausesValidation="False"></asp:Button><asp:Button id="BTN_CategoryIDSearch_EDIT" onclick="BTN_CategoryIDSearch_EDIT_Click" runat="server" Text="..." CausesValidation="False">
                            </asp:Button> &nbsp;&nbsp; <asp:Button id="BTN_CheckerSignatoryIDSearch_INSERT" onclick="BTN_CheckerSignatoryIDSearch_INSERT_Click" runat="server" Text="..." CausesValidation="False"></asp:Button><asp:Button id="BTN_CheckerSignatoryIDSearch_EDIT" onclick="BTN_CheckerSignatoryIDSearch_EDIT_Click" runat="server" Text="..." CausesValidation="False">
                            </asp:Button>&nbsp; <asp:ObjectDataSource id="ObjSP_SPDS_AuthorizationMatrix_SPC" runat="server" TypeName="LOV_COLLECTION" SelectMethod="Get_SP_SPDS_AuthorizationMatrix_SPC" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="ID" SessionField="SPDS_AuthorizationMatrix_ID"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource> 
</ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
