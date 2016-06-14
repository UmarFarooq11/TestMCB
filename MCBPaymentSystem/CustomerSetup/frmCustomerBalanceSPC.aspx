<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="frmCustomerBalanceSPC.aspx.cs" Inherits="frmCustomerBalanceSPC" Title="Customer Funding" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
    function CustomerLOV()
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_Company.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
//function validateNegative(xAmount)
//{
//    if (isNan(xAmount))
//    {
//        if (xAmount<0)
//        {
//        document.getElementById('req_BAL_AMOUNT_INSERT').value =  "no";
//        return false;
//        }
//        return true;
//    }
//}
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:FormView id="FormView1" runat="server" DataKeyNames="BANKCODE" DataSourceID="ODSSP_CMN_CUST_PAYMENT_SPC" Font-Names="Verdana" Font-Size="10pt" OnPageIndexChanging="FormView1_PageIndexChanging" OnDataBound="FormView1_DataBound" Width="100%"><EditItemTemplate>
<TABLE class="login" cellSpacing=0 width="100%">
<%--<eo:ToolBar id="EditToolbar" runat="server" __designer:wfdid="w20" OnItemClick="EditToolbar_ItemClick" AutoPostBack="True">
                                                    <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                    <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                    <Items>
                                                        <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" ImageUrl="00101054" ToolTip="Update"></eo:ToolBarItem>
                                                        <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" ImageUrl="~/images/Refresh copy.gif" ToolTip="Cancel"></eo:ToolBarItem>
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
                                                </eo:ToolBar>--%> <HR style="COLOR: darkgray" /><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2><asp:Label id="lblDuplicate_EDIT" runat="server" Font-Size="Smaller" __designer:wfdid="w21" ForeColor="Red" Font-Bold="True"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server" __designer:wfdid="w22"><ProgressTemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" __designer:wfdid="w23"></asp:Image> 
</ProgressTemplate>
</asp:UpdateProgress> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Customer&nbsp;Code:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="txtBANKCODE_EDIT" runat="server" Width="50px" Text='<%# Bind("BANKCODE") %>' __designer:wfdid="w24" SkinID="TXT" MaxLength="3"></asp:TextBox> <asp:Button id="btnPicker" runat="server" Text="..." __designer:wfdid="w25" CausesValidation="False" CssClass="btn1">
                                                </asp:Button><asp:RequiredFieldValidator id="REQ_CurrencyCode_EDIT" runat="server" __designer:wfdid="w26" ControlToValidate="txtBANKCODE_EDIT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator> </TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">Customer&nbsp;Name:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="txtBANKNAME_EDIT" runat="server" Width="200px" Text='<%# Bind("BANKNAME") %>' __designer:wfdid="w27" SkinID="TXT" MaxLength="30" Enabled="False"></asp:TextBox></TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Date:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="txtRATE_DATE_EDIT" runat="server" Width="150px" Text='<%# Bind("RATE_DATE") %>' __designer:wfdid="w28" SkinID="TXT" MaxLength="10"></asp:TextBox><BR /><asp:RequiredFieldValidator id="req_RATE_DATE_EDIT" runat="server" __designer:wfdid="w29" ControlToValidate="txtRATE_DATE_EDIT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Amount:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="txtBAL_AMOUNT_EDIT" runat="server" Width="150px" Text='<%# Bind("BAL_AMOUNT") %>' __designer:wfdid="w30" SkinID="TXT" MaxLength="10"></asp:TextBox> <asp:RequiredFieldValidator id="req_BAL_AMOUNT_EDIT" runat="server" __designer:wfdid="w31" ControlToValidate="txtBAL_AMOUNT_EDIT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator> </TD></TR></TBODY></TABLE><ajaxToolkit:CalendarExtender id="fteRATE_DATE_EDIT" runat="server" __designer:wfdid="w32" TargetControlID="txtRATE_DATE_EDIT" Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender> <ajaxToolkit:FilteredTextBoxExtender id="fteAMOUNT_EDIT" runat="server" __designer:wfdid="w33" TargetControlID="txtBAL_AMOUNT_EDIT" ValidChars="0123456789.">
                                </ajaxToolkit:FilteredTextBoxExtender> <ajaxToolkit:FilteredTextBoxExtender id="fteBANKCODE_EDIT" runat="server" __designer:wfdid="w34" Enabled="True" TargetControlID="txtBANKCODE_EDIT" InvalidChars="~!@#$%^&*()" FilterMode="InvalidChars" FilterType="UppercaseLetters">
                                </ajaxToolkit:FilteredTextBoxExtender> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:Button id="BTN_INSERT" onclick="BTN_INSERT_Click" runat="server" Font-Names="Verdana" Font-Size="10pt" Text="Insert" Font-Bold="True" __designer:wfdid="w100" ForeColor="White" CommandName="Insert" CausesValidation="True"></asp:Button> <asp:Button id="BTN_RESET" onclick="BTN_RESET_Click" runat="server" Font-Names="Verdana" Font-Size="10pt" Text="Reset" Font-Bold="True" __designer:wfdid="w101" ForeColor="White" CommandName="reset" CausesValidation="False">
                                    </asp:Button> <asp:Button id="BTN_INSERT_CANCEL" onclick="BTN_INSERT_CANCEL_Click" runat="server" Font-Names="Verdana" Font-Size="10pt" Text="Cancel" Font-Bold="True" __designer:wfdid="w102" ForeColor="White" CommandName="Cancel" CausesValidation="False"></asp:Button> <%--<eo:ToolBar id="InsertToolbar" runat="server" AutoPostBack="True" OnItemClick="InsertToolbar_ItemClick" __designer:wfdid="w441">
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
                                                </eo:ToolBar>--%><HR style="COLOR: darkgray" /><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2><asp:Label id="lblDuplicate_INSERT" runat="server" Font-Size="Smaller" Font-Bold="True" __designer:wfdid="w103" ForeColor="Red"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server" __designer:wfdid="w104"><ProgressTemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" __designer:wfdid="w105"></asp:Image> 
</ProgressTemplate>
</asp:UpdateProgress> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Company&nbsp;Code: </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:DropDownList id="ddlCompanyCode" runat="server" __designer:dtid="1407374883553311" Width="355px" __designer:wfdid="w106" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">Current Balance:&nbsp; </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Current_Bal_Amt_Insert" runat="server" Width="100px" SkinID="TXT" __designer:wfdid="w107"></asp:TextBox></TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Date:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="txtRATE_DATE_INSERT" runat="server" Width="100px" Text='<%# Bind("RATE_DATE") %>' SkinID="TXT" __designer:wfdid="w108" MaxLength="11"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator id="req_RATE_DATE_INSERT" runat="server" __designer:wfdid="w109" ControlToValidate="txtRATE_DATE_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator> <asp:CompareValidator id="CompareValidator1" runat="server" __designer:wfdid="w110" ControlToValidate="txtRATE_DATE_INSERT" ErrorMessage="Date must be equal or greater then system date" Enabled="False" Type="Date" ControlToCompare="txtSysdate" Operator="GreaterThanEqual"></asp:CompareValidator> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Amount:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="txtBAL_AMOUNT_INSERT" runat="server" Width="100px" Text='<%# Bind("BAL_AMOUNT") %>' SkinID="TXT" __designer:wfdid="w111" MaxLength="10"></asp:TextBox> <asp:RequiredFieldValidator id="req_BAL_AMOUNT_INSERT" runat="server" __designer:wfdid="w112" ControlToValidate="txtBAL_AMOUNT_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator> </TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">Reference #: </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_Ref_No_Insert" runat="server" Width="205px" SkinID="TXT" __designer:wfdid="w113" MaxLength="30"></asp:TextBox></TD></TR><TR align=right></TR></TBODY></TABLE><ajaxToolkit:CalendarExtender id="fteRATE_DATE_INSERT" runat="server" __designer:wfdid="w114" PopupButtonID="txtRATE_DATE_INSERT" TargetControlID="txtRATE_DATE_INSERT" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> <asp:TextBox id="txtSysdate" runat="server" Width="175px" __designer:wfdid="w115"></asp:TextBox> <asp:UpdatePanel id="UpdatePanel2" runat="server" __designer:wfdid="w116"><ContentTemplate>
<asp:TextBox id="txtBANKCODE_INSERT" runat="server" Width="50px" Visible="False" Text='<%# Bind("BANKCODE") %>' SkinID="TXT" __designer:wfdid="w117" MaxLength="3"></asp:TextBox> <asp:ImageButton id="btnPicker" onclick="btnPicker_Click" runat="server" Visible="False" ImageUrl="~/images/search_16x16.png" __designer:wfdid="w118" CausesValidation="False" OnClientClick="CustomerLOV();"></asp:ImageButton><asp:TextBox id="txtBANKNAME_INSERT" runat="server" Width="200px" Visible="False" Text='<%# Bind("BANKNAME") %>' SkinID="TXT" __designer:wfdid="w119" MaxLength="30" Enabled="False"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender id="fteBANKCODE_Insert" runat="server" __designer:wfdid="w120" Enabled="True" TargetControlID="txtBANKCODE_INSERT" InvalidChars="~!@#$%^&*()" FilterMode="InvalidChars" FilterType="UppercaseLetters">
                                                </ajaxToolkit:FilteredTextBoxExtender><asp:RequiredFieldValidator id="REQ_CurrencyCode_INSERT" runat="server" Visible="False" __designer:wfdid="w121" ControlToValidate="txtBANKCODE_INSERT" ErrorMessage="Proper Information Required" Enabled="False"></asp:RequiredFieldValidator> 
</ContentTemplate>
</asp:UpdatePanel> 
</InsertItemTemplate>
<ItemTemplate>
<%--<eo:ToolBar ID="DisplayToolBar" runat="server" OnItemClick="DisplayToolBar_ItemClick"
                                                    AutoPostBack="True">
                                                    <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                    <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                    <Items>
                                                        <eo:ToolBarItem AutoCheck="True" CommandArgument="Edit" CommandName="Edit" Disabled="True"
                                                            ImageUrl="00101054" ToolTip="Edit">
                                                        </eo:ToolBarItem>
                                                        <eo:ToolBarItem CommandName="Cancel" Disabled="True" ImageUrl="00101060" ToolTip="Delete">
                                                        </eo:ToolBarItem>
                                                        <eo:ToolBarItem CommandName="Cancel" Disabled="True" ImageUrl="~/images/Refresh copy.gif"
                                                            ToolTip="Cancel">
                                                        </eo:ToolBarItem>
                                                        <eo:ToolBarItem CommandName="Cancel" Type="Separator">
                                                        </eo:ToolBarItem>
                                                        <eo:ToolBarItem CommandName="Cancel" Disabled="True" ImageUrl="00000508" ToolTip="Authorize / Unauthorize">
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
                                                </eo:ToolBar>--%><HR style="COLOR: darkgray" /><TABLE style="FONT-SIZE: 10pt; FONT-FAMILY: Verdana" class="air" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">Customer&nbsp;Code:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblBANKCODE" runat="server" Width="95%" Text='<%# Bind("BANKCODE") %>' __designer:wfdid="w91"></asp:Label> </TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">Customer&nbsp;Name:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblBANKNAME" runat="server" Width="95%" Text='<%# Bind("BANKNAME") %>' __designer:wfdid="w92"></asp:Label> </TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">Date:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblRATE_DATE" runat="server" Width="95%" Text='<%# Bind("RATE_DATE") %>' __designer:wfdid="w93"></asp:Label></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">Amount: </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblBAL_AMOUNT" runat="server" Width="95%" Text='<%# Bind("BAL_AMOUNT") %>' __designer:wfdid="w94"></asp:Label> </TD></TR><TR align=right><TD style="TEXT-ALIGN: left" class="ColLines1" colSpan=2><asp:Label id="Label1" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt" Width="153px" Text="Administration" Font-Bold="False" SkinID="FormViewHeading" __designer:wfdid="w95"></asp:Label> </TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">Edited By:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblE_UserID" runat="server" Width="95%" Text='<%# Bind("E_UserID") %>' __designer:wfdid="w96"></asp:Label> </TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">Authorized By:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblA_UserID" runat="server" Width="95%" Text='<%# Bind("A_UserID") %>' __designer:wfdid="w97"></asp:Label> </TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">Edited At:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblE_DateTime" runat="server" Width="95%" Text='<%# Bind("E_DateTime") %>' __designer:wfdid="w98"></asp:Label> </TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1">Authorized At:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblA_DateTime" runat="server" Width="95%" Text='<%# Bind("A_DateTime") %>' __designer:wfdid="w99"></asp:Label> </TD></TR><TR align=right></TR></TBODY></TABLE>
</ItemTemplate>
<HeaderTemplate>
                                <asp:Label ID="Label_HEAD" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
                                    Width="100%" Text="Customer Funding" SkinID="FormViewHeading"></asp:Label>
                            
</HeaderTemplate>
</asp:FormView> <TABLE class="loginDown" cellSpacing=0 width="100%"><TBODY><TR><TD></TD></TR></TBODY></TABLE><asp:ObjectDataSource id="ODSSP_CMN_CUST_PAYMENT_SPC" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GET_SP_CUST_BAL_BYCODE" TypeName="LOV_COLLECTION">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="v_BankCode" SessionField="CustBalCode"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource> 
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
