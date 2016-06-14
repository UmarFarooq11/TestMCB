<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="DataLoadCofigurationSPC.aspx.cs" Inherits="DataLoadCofigurationSPC"
    Title="Data Load Configuration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

        function onConfirm1(rdbcash,txtFrom,txtTo)
        {
            if(rdbcash.checked == true)
            {
                alert(txtFrom + " " + txtTo);
                 //var sysdate = document.getElementById("ctl00_ContentPlaceHolder1_txtsysdate").value; 
                 //var expdate = document.getElementById("ctl00_ContentPlaceHolder1_txtExpiryDate").value; 
                 if(txtFrom.value == "" || txtTo.value == "")
                 {
                    alert("Proper Information Required.");
                    return false;
                 }
                 else
                 {
                    return true;
                 }
            } 
            else
            {
                return true;
            }
        }    
function DataConfigurationLOV() 
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_DataLoadConfiguration.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function DataConfigurationDetailLOV() 
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_DataLoadConfigurationDetail.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function StarLOV() 
{
//    var a;
//    var c='<%= Session["HEIGHT"] %>';
//    var b='<%= Session["WIDTH"] %>';
//    a=window.showModalDialog('../LOV/LOV_Correspondent.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function CourierLOV() 
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_Courier.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function BeneficiaryLOV() 
{
//    var a;
//    var c='<%= Session["HEIGHT"] %>';
//    var b='<%= Session["WIDTH"] %>';
//    a=window.showModalDialog('../LOV/LOV_Courier.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}



function SearchSourceIDINSERT()
{
    document.getElementById("ctl00_ContentPlaceHolder1_BTN_SourceIDSearch_INSERT").click();
    return false;
}
function SearchSourceIDEDIT()
{
    document.getElementById("ctl00_ContentPlaceHolder1_BTN_SourceIDSearch_EDIT").click();
    return false;
}
// ]]>
    </script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <contenttemplate>
<asp:FormView id="FormView1" runat="server" Width="100%" Font-Size="10pt" Font-Names="Verdana" OnDataBound="FormView1_DataBound" DataKeyNames="conf_def_id" DataSourceID="ObjSP_SPDS_DataLoadCofiguration_SPC" OnPageIndexChanging="FormView1_PageIndexChanging"><EditItemTemplate>
<asp:Button id="UpdateButton" onclick="UpdateButton_Click" runat="server" Text="Update" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" CausesValidation="True">
                                                </asp:Button> <asp:Button id="BTN_CANCEL" onclick="BTN_CANCEL_Click" runat="server" Text="Cancel" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" ForeColor="White" CommandName="Cancel" CausesValidation="False"></asp:Button> <%--<eo:ToolBar id="EditToolbar" runat="server" OnItemClick="EditToolbar_ItemClick" AutoPostBack="True" __designer:wfdid="w96">
                <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                <Items>
                    <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" ImageUrl="00101054"
                        ToolTip="Update">
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
            </eo:ToolBar>--%><HR style="COLOR: darkgray" />
            <TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="TEXT-ALIGN: center" class="ColLines" colSpan=2><asp:Label id="lblDuplicate_EDIT" runat="server" Font-Size="Smaller" Font-Bold="True" ForeColor="Red"></asp:Label><asp:UpdateProgress id="UpdateProgress1" runat="server"><ProgressTemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif"></asp:Image> 
</ProgressTemplate>
</asp:UpdateProgress></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">Description :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:TextBox id="TXT_ConfigurationDef_Desc_EDIT" runat="server" Width="200px" Text='<%# Bind("CONF_DEF_DESC") %>' MaxLength="30"></asp:TextBox> <asp:RequiredFieldValidator id="REQ_ConfigurationName_INSERT" runat="server" ControlToValidate="TXT_ConfigurationDef_Desc_EDIT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">File Format :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:RadioButton id="RB_XLS_EDIT" runat="server" Text="XLS" GroupName="file" Checked='<%# Convert.ToBoolean(Eval("FileXLS")) %>'></asp:RadioButton><asp:RadioButton id="RB_CSV_EDIT" runat="server" Text="CSV" GroupName="file" Checked='<%# Convert.ToBoolean(Eval("FileCSV")) %>'></asp:RadioButton><asp:RadioButton id="RB_TXT_EDIT" runat="server" Text="TXT" GroupName="file" Checked='<%# Convert.ToBoolean(Eval("FileTXT")) %>'></asp:RadioButton>
    <asp:RadioButton ID="RB_MT100_EDIT" runat="server" Checked='<%# Convert.ToBoolean(Eval("FileMT100")) %>'
        GroupName="file" Text="MT100" /></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">File Separate :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:TextBox id="TXT_FlieSeparate_Edit" runat="server" Width="50px" Text='<%# BIND("FILESEPARATE") %>' Font-Bold="True"></asp:TextBox></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">Record(s) Skip :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:TextBox id="TXT_RECORD_SKIP_EDIT" runat="server" Width="50px" Text='<%# BIND("RECORD_SKIP") %>'></asp:TextBox></TD></TR><TR align=right></TR></TBODY></TABLE><asp:TextBox id="TXT_ConfigurationDef_ID_EDIT" runat="server" Width="85px" Text='<%# bind("CONF_DEF_ID") %>'></asp:TextBox> <asp:TextBox id="TXT_Configuration_ID_EDIT" runat="server" Width="85px" Text='<%# Bind("CONF_ID") %>'></asp:TextBox><asp:TextBox id="TXT_Configuration_Desc_EDIT" runat="server" Width="200px" Text='<%# Bind("CONF_DEF_DESC") %>' MaxLength="100"></asp:TextBox> 
</EditItemTemplate>
<InsertItemTemplate>
<asp:Button id="BTN_INSERT" onclick="BTN_INSERT_Click" runat="server" Text="Insert" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" ForeColor="White" CommandName="Insert" CausesValidation="True"></asp:Button> <asp:Button id="BTN_RESET" onclick="BTN_RESET_Click" runat="server" Text="Reset" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" ForeColor="White" CausesValidation="False"></asp:Button> <asp:Button id="BTN_CANCEL" onclick="BTN_CANCEL_Click" runat="server" Text="Cancel" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" ForeColor="White" CommandName="Cancel" CausesValidation="False"></asp:Button> <%--<eo:ToolBar id="InsertToolbar" runat="server" OnItemClick="InsertToolbar_ItemClick" AutoPostBack="True" __designer:wfdid="w78">
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
        </eo:ToolBar>--%>
        <HR style="COLOR: darkgray" />
        <TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="TEXT-ALIGN: center" class="ColLines" colSpan=2><asp:Label id="lblDuplicate_INSERT" runat="server" Font-Size="Smaller" Font-Bold="True" ForeColor="Red"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server"><ProgressTemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif"></asp:Image> 
</ProgressTemplate>
</asp:UpdateProgress> </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="TableColumns">Configuration&nbsp;ID :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:DropDownList id="ddlConfigurationID_Insert" runat="server" Width="193px"></asp:DropDownList></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">File Format :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:RadioButton id="RB_XLS_INSERT" runat="server" Text="XLS" GroupName="File"></asp:RadioButton><asp:RadioButton id="RB_CSV_INSERT" runat="server" Text="CSV" GroupName="File"></asp:RadioButton><asp:RadioButton id="RB_TXT_INSERT" runat="server" Text="TXT" GroupName="File" Checked="True"></asp:RadioButton>
    <asp:RadioButton ID="RB_MT100_INSERT" runat="server" GroupName="File" Text="MT100" /></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">File Separate : </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:TextBox id="TXT_FileSeparate_Insert" runat="server" Width="50px" Font-Bold="True"></asp:TextBox></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">Record(s) Skip : </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:TextBox id="TXT_RECORD_SKIP_INSERT" runat="server" Width="50px"></asp:TextBox></TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="TableColumns">Configuration Defination&nbsp;ID :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:TextBox id="TXT_ConfigurationDef_ID_INSERT" runat="server" Width="85px" Text='<%# bind("CONF_DEF_ID") %>' MaxLength="10"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_ConfigurationDef_ID_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator></TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red" class="TableColumns">Description&nbsp;:</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:TextBox id="TXT_ConfigurationDef_Desc_INSERT" runat="server" Width="200px" Text='<%# Bind("CONF_DEF_DESC") %>' MaxLength="30"></asp:TextBox> <asp:RequiredFieldValidator id="REQ_ConfigurationName_INSERT" runat="server" ControlToValidate="TXT_ConfigurationDef_Desc_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="ColLines1"></TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"></TD></TR><TR align=right></TR></TBODY></TABLE><asp:TextBox id="TXT_Configuration_ID_INSERT" runat="server" Width="85px" Text='<%# bind("CONF_ID") %>' Visible="False" MaxLength="10"></asp:TextBox><asp:ImageButton id="BTN_Configuration_ID_INSERT" onclick="BTN_Configuration_ID_INSERT_Click" runat="server" CausesValidation="False" Visible="False" ImageUrl="~/images/search_16x16.png" OnClientClick="DataConfigurationLOV() ;"></asp:ImageButton><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Visible="False" ControlToValidate="TXT_Configuration_ID_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator><asp:TextBox id="TXT_Configuration_Desc_INSERT" runat="server" Width="200px" Text='<%# bind("conf_desc") %>' Visible="False" MaxLength="30"></asp:TextBox> 
</InsertItemTemplate>
<ItemTemplate>
<asp:Button id="BTN_EDIT" onclick="BTN_EDIT_Click" runat="server" Width="60px" Text="Edit" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True"></asp:Button> <asp:Button id="BTN_DELETE" runat="server" Width="60px" Text="Delete" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" Enabled="false"></asp:Button> <asp:Button id="BTN_CANCEL" onclick="BTN_CANCEL_Click" runat="server" Text="Cancel" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" ForeColor="White" CommandName="Cancel" CausesValidation="False"></asp:Button> <%--<eo:ToolBar id="DisplayToolBar" runat="server" OnItemClick="DisplayToolBar_ItemClick" AutoPostBack="True" __designer:wfdid="w110">
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
            </eo:ToolBar>--%><HR style="COLOR: darkgray" /><TABLE style="FONT-SIZE: 10pt; FONT-FAMILY: Verdana" class="air" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">Configuration ID :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="TXT_Configuration_ID_DISPLAY" runat="server" Width="95%" Text='<%# Bind("CONF_ID") %>'></asp:Label></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">Description :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="TXT_Configuration_Desc_DISPLAY" runat="server" Width="95%" Text='<%# Bind("conf_desc") %>'></asp:Label></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">File Format :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:RadioButton id="RB_XLS_DISPLAY" runat="server" Text="XLS" Enabled="False" GroupName="file" Checked='<%# Convert.ToBoolean(Eval("FileXLS")) %>'></asp:RadioButton><asp:RadioButton id="RB_CSV_DISPLAY" runat="server" Text="CSV" Enabled="False" GroupName="file" Checked='<%# Convert.ToBoolean(Eval("FileCSV")) %>'></asp:RadioButton><asp:RadioButton id="RB_TXT_DISPLAY" runat="server" Text="TXT" Enabled="False" GroupName="file" Checked='<%# Convert.ToBoolean(Eval("FileTXT")) %>'></asp:RadioButton>
                <asp:RadioButton ID="RB_MT100_DISPLAY" runat="server" Checked='<%# Convert.ToBoolean(Eval("FileMT100")) %>'
                    Enabled="False" GroupName="file" Text="MT100" /></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">File Separate : </TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp;<asp:Label id="TXT_FILESEPARATE_DISPLAY" runat="server" Text='<%# BIND("FILESEPARATE") %>' Font-Bold="True"></asp:Label></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">Record(s) Skip :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="TXT_RECORD_SKIP_DISPLAY" runat="server" Width="95%" Text='<%# BIND("RECORD_SKIP") %>'></asp:Label></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">Configuration Defination ID :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="TXT_ConfigurationDef_ID_DISPLAY" runat="server" Width="95%" Text='<%# bind("CONF_DEF_ID") %>'></asp:Label></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">Description :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="TXT_ConfigurationDef_Desc_DISPLAY" runat="server" Width="95%" Text='<%# Bind("CONF_DEF_DESC") %>'></asp:Label></TD></TR><TR align=right></TR></TBODY></TABLE>
</ItemTemplate>
<HeaderTemplate>

            <asp:Label ID="Label_HEAD" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
                Text="Data Load Configuration" Width="100%" SkinID="FormViewHeading"></asp:Label>
        
</HeaderTemplate>
</asp:FormView> <asp:ObjectDataSource id="ObjSP_SPDS_DataLoadCofiguration_SPC" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Get_SPDS_DataLoadCofiguration_SPC" TypeName="LOV_COLLECTION"><SelectParameters>
<asp:SessionParameter SessionField="SPDS_DataLoadCofiguration_ID" DefaultValue="%" Name="p_CONF_ID" Type="String"></asp:SessionParameter>
<asp:SessionParameter SessionField="SPDS_DataLoadDefinationCofiguration_ID" DefaultValue="%" Name="p_CONF_DEF_ID" Type="String"></asp:SessionParameter>
</SelectParameters>
</asp:ObjectDataSource> 
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="air" style="height: 1px">
                <asp:Label ID="Label1" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
                    SkinID="FormViewHeading" Text="Data Load Configuration Detail" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 1px">
                <table cellspacing="0" class="air1" width="100%">
                    <tr>
                        <td colspan="3" style="height: 1px">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <contenttemplate>
<asp:Button id="BTN_NEW" onclick="BTN_NEW_Click" runat="server" Text="New" Font-Size="10pt" Font-Names="Verdana" ToolTip="Add New" Font-Bold="True"></asp:Button> <asp:Button id="BTN_CANCEL" onclick="BTN_CANCEL_Click" runat="server" Text="Cancel" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" ForeColor="White" CommandName="Cancel" CausesValidation="False"></asp:Button> <%--<eo:ToolBar id="ToolBar1" runat="server" SeparatorImage="00100204" OnItemClick="ToolBar1_ItemClick" AutoPostBack="True">
<DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac"></DownStyle>

<HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac"></HoverStyle>
<Items>
<eo:ToolBarItem ImageUrl="00101001" ToolTip="Add New" CommandName="Cancel"></eo:ToolBarItem>
<eo:ToolBarItem ImageUrl="00101032" ToolTip="Search" Visible="False" CommandName="Cancel"></eo:ToolBarItem>
<eo:ToolBarItem ImageUrl="~/images/Refresh copy.gif" ToolTip="Cancel" CommandName="Cancel"></eo:ToolBarItem>
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
</eo:ToolBar>--%><TABLE style="BACKGROUND-COLOR: gainsboro" class="login" cellSpacing=0 width="100%"><TBODY><TR><TD style="FONT-SIZE: 9pt; COLOR: #444444; FONT-FAMILY: Arial, Tahoma; TEXT-ALIGN: left" colSpan=4><asp:GridView style="WIDTH: 100%" id="GridView1" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana" DataKeyNames="CONF_ID" DataSourceID="SP_SPDS_DataLoadCofigurationDetail_ALL" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="50" ShowFooter="True">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PageButtonCount="100" Position="TopAndBottom" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous" Visible="False"></PagerSettings>
<Columns>
<asp:BoundField DataField="CONF_DEF_ID" HeaderText="CONF_DEF_ID" SortExpression="CONF_DEF_ID">
<HeaderStyle HorizontalAlign="Left" CssClass="hidden"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CONF_ID" HeaderText="Configuration ID" SortExpression="CONF_ID">
<HeaderStyle HorizontalAlign="Left" CssClass="hidden"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="COLUMN_ORDER" HeaderText="Column Order" SortExpression="COLUMN_ORDER">
<HeaderStyle HorizontalAlign="Left" CssClass="hidden"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="column_name" HeaderText="Column Name" SortExpression="column_name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="COLUMN_SEQ" HeaderText="Column Sequence" SortExpression="COLUMN_SEQ">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="FROM_POS" HeaderText="From Position" SortExpression="FROM_POS">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TO_POS" HeaderText="To Position" SortExpression="TO_POS">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField ShowHeader="False"><ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Select" ImageUrl="~/Images/edit1.gif"
                                                                        OnClick="ImageButton1_Click" />
                                                                
</ItemTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>

<PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:GridView> </TD></TR></TBODY></TABLE><asp:FormView id="FormView2" runat="server" Width="100%" Font-Size="10pt" Font-Names="Verdana" OnDataBound="FormView2_DataBound" DataKeyNames="CONF_DEF_ID" DataSourceID="ObjSP_SPDS_DataLoadCofigurationDetail_SPC" OnPageIndexChanging="FormView1_PageIndexChanging"><EditItemTemplate>
<TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD><asp:Button id="UpdateButton_DETAIL" onclick="UpdateButton_DETAIL_Click" runat="server" Text="Update" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" CausesValidation="True">
                                                            </asp:Button> <asp:Button id="TXT_Cancel_Detail" onclick="TXT_Cancel_Detail_Click" runat="server" Width="60px" Text="Cancel" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True"></asp:Button> <%--<eo:ToolBar id="EditToolbar2" runat="server" OnItemClick="EditToolbar2_ItemClick" AutoPostBack="True" __designer:wfdid="w260">
                                                                <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                                <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                                <Items>
                                                                    <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" ImageUrl="00101054"
                                                                        ToolTip="Update">
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
                                                            </eo:ToolBar> --%></TD></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="WIDTH: 15%; COLOR: black; TEXT-ALIGN: right" class="TableColumns">Column Order :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_COLUMN_ORDER_DETAIL_EDIT" runat="server" Width="50px" Text='<%# Bind("COLUMN_ORDER") %>' MaxLength="10"></asp:TextBox> <asp:DropDownList id="ddlColumnOrder_Edit" runat="server" Width="91px" Visible="False"></asp:DropDownList>&nbsp; </TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: black; TEXT-ALIGN: right" class="TableColumns">Column Name :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_COLUMN_NAME_DETAIL_EDIT" runat="server" Width="200px" Text='<%# Bind("column_name") %>' MaxLength="30"></asp:TextBox></TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="TableColumns">Column Sequence :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_COLUMN_SEQ_DETAIL_EDIT" runat="server" Width="100px" Text='<%# Bind("COLUMN_SEQ") %>' MaxLength="10"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ControlToValidate="TXT_COLUMN_SEQ_DETAIL_EDIT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender4" runat="server" TargetControlID="TXT_COLUMN_SEQ_DETAIL_EDIT" ValidChars="0123456789"></ajaxToolkit:FilteredTextBoxExtender></TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: black; TEXT-ALIGN: right" class="TableColumns">From Position :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_FROM_POS_DETAIL_EDIT" runat="server" Width="100px" Text='<%# Bind("FROM_POS") %>' MaxLength="10"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender5" runat="server" TargetControlID="TXT_FROM_POS_DETAIL_EDIT" ValidChars="0123456789"></ajaxToolkit:FilteredTextBoxExtender></TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: black; TEXT-ALIGN: right" class="TableColumns">To Position :</TD><TD style="WIDTH: 35%; HEIGHT: 15px; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_TO_POS_DETAIL_EDIT" runat="server" Width="100px" Text='<%# Bind("TO_POS") %>' MaxLength="10"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender6" runat="server" TargetControlID="TXT_TO_POS_DETAIL_EDIT" ValidChars="0123456789"></ajaxToolkit:FilteredTextBoxExtender></TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE><asp:TextBox id="TXT_CONF_ID_DETAIL_EDIT" runat="server" Width="62px" Text='<%# bind("CONF_ID") %>'></asp:TextBox> <asp:ImageButton id="BTN_Configuration_Detail_ID_EDIT" onclick="BTN_Configuration_Detail_ID_EDIT_Click" runat="server" CausesValidation="False" ImageUrl="~/images/search_16x16.png" OnClientClick="DataConfigurationDetailLOV();"></asp:ImageButton><asp:RequiredFieldValidator id="REQ_ConfigurationName_INSERT1" runat="server" ControlToValidate="TXT_COLUMN_ORDER_DETAIL_EDIT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator> <asp:TextBox id="TextBox1" runat="server" Width="50px" Text='<%# Bind("COLUMN_ORDER") %>' Visible="False" MaxLength="10"></asp:TextBox> 
</EditItemTemplate>
<InsertItemTemplate>
<TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD style="TEXT-ALIGN: center">&nbsp; </TD></TR><TR><TD style="TEXT-ALIGN: center"><asp:Button id="BTN_INSERT_Detail" onclick="BTN_INSERT_Detail_Click" runat="server" Text="Insert" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" ForeColor="White" CommandName="Insert" CausesValidation="True"></asp:Button> <asp:Button id="BTN_CANCEL_Detail" onclick="BTN_CANCEL_Detail_Click" runat="server" Text="Cancel" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" ForeColor="White" CommandName="Cancel" CausesValidation="False"></asp:Button> <%--<eo:ToolBar id="InsertToolbar2" runat="server" OnItemClick="InsertToolbar2_ItemClick" AutoPostBack="True" __designer:wfdid="w4">
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
                                                            </eo:ToolBar> --%><asp:Label id="lblDuplicate_INSERT" runat="server" Font-Size="Smaller" Font-Bold="True" ForeColor="Red"></asp:Label><asp:UpdateProgress id="UpdateProgress1" runat="server"><ProgressTemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif"></asp:Image> 
</ProgressTemplate>
</asp:UpdateProgress></TD></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="TableColumns">Column Order :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:DropDownList id="ddlColumnOrder_Insert" runat="server" Width="250px"></asp:DropDownList></TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="TableColumns">Column Sequence :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_COLUMN_SEQ_DETAIL_INSERT" runat="server" Width="100px" Text='<%# Bind("COLUMN_SEQ") %>' MaxLength="10"></asp:TextBox> <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="TXT_COLUMN_SEQ_DETAIL_INSERT" ValidChars="0123456789"></ajaxToolkit:FilteredTextBoxExtender> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="TXT_COLUMN_SEQ_DETAIL_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator></TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: black; TEXT-ALIGN: right" class="TableColumns">From Position :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_FROM_POS_DETAIL_INSERT" runat="server" Width="100px" Text='<%# Bind("FROM_POS") %>' MaxLength="10"></asp:TextBox>&nbsp; <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" TargetControlID="TXT_FROM_POS_DETAIL_INSERT" ValidChars="0123456789"></ajaxToolkit:FilteredTextBoxExtender></TD></TR><TR align=right><TD style="WIDTH: 15%; COLOR: black; TEXT-ALIGN: right" class="TableColumns">To Position :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:TextBox id="TXT_TO_POS_DETAIL_INSERT" runat="server" Width="100px" Text='<%# Bind("TO_POS") %>' MaxLength="10"></asp:TextBox>&nbsp; <ajaxToolkit:FilteredTextBoxExtender id="FilteredTextBoxExtender3" runat="server" TargetControlID="TXT_TO_POS_DETAIL_INSERT" ValidChars="0123456789"></ajaxToolkit:FilteredTextBoxExtender></TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE><asp:TextBox id="TXT_CONF_ID_DETAIL_INSERT" runat="server" Width="62px" Text='<%# bind("CONF_ID") %>'></asp:TextBox> <asp:TextBox id="TXT_COLUMN_ORDER_DETAIL_INSERT" runat="server" Width="50px" Text='<%# Bind("COLUMN_ORDER") %>' Visible="False" MaxLength="10"></asp:TextBox><asp:ImageButton id="BTN_Configuration_Detail_ID_INSERT" onclick="BTN_Configuration_Detail_ID_INSERT_Click" runat="server" CausesValidation="False" Visible="False" ImageUrl="~/images/search_16x16.png" OnClientClick="DataConfigurationDetailLOV();"></asp:ImageButton><asp:RequiredFieldValidator id="REQ_ConfigurationName_INSERT" runat="server" Enabled="False" ControlToValidate="TXT_COLUMN_ORDER_DETAIL_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator><BR /><asp:TextBox id="TXT_COLUMN_NAME_DETAIL_INSERT" runat="server" Width="250px" Text='<%# Bind("COLUMN_ORDER") %>' Visible="False" MaxLength="30"></asp:TextBox> 
</InsertItemTemplate>
<ItemTemplate>
<TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD><asp:Button id="TXT_EDIT_Detail" onclick="TXT_EDIT_Detail_Click" runat="server" Width="60px" Text="Edit" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" CommandName="Edit"></asp:Button> <asp:Button id="TXT_DELETE_Detail" onclick="TXT_DELETE_Detail_Click1" runat="server" Width="60px" Text="Delete" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" OnClientClick="return confirm('Are you sure you want to delete this record?');"></asp:Button> <asp:Button id="TXT_Cancel_Detail" onclick="TXT_Cancel_Detail_Click" runat="server" Width="60px" Text="Cancel" Font-Size="10pt" Font-Names="Verdana" Font-Bold="True"></asp:Button> <%--<eo:ToolBar id="DisplayToolBar2" runat="server" AutoPostBack="True" OnItemClick="DisplayToolBar2_ItemClick" __designer:wfdid="w93">
                                                            <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                            <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                            <Items>
                                                                <eo:ToolBarItem AutoCheck="True" CommandArgument="Edit" CommandName="Edit" ImageUrl="00101054"
                                                                    ToolTip="Edit">
                                                                </eo:ToolBarItem>
                                                                <eo:ToolBarItem CommandName="Cancel" Disabled="FALSE" ImageUrl="00101060" ToolTip="Delete">
                                                                </eo:ToolBarItem>
                                                                <eo:ToolBarItem CommandName="Cancel" ImageUrl="~/images/Refresh copy.gif" ToolTip="Cancel">
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
                                                        </eo:ToolBar>--%></TD></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 10pt; FONT-FAMILY: Verdana" class="air" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">Configuration ID :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="TXT_CONF_ID_DETAIL_DISPLAY" runat="server" Width="95%" Text='<%# bind("CONF_ID") %>'></asp:Label></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">Column Order :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="TXT_COLUMN_ORDER_DETAIL_DISPLAY" runat="server" Width="95%" Text='<%# Bind("COLUMN_ORDER") %>'></asp:Label></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">Column&nbsp;Name :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="TXT_COLUMN_ORDER_DETAIL_NAME_DISPLAY" runat="server" Width="95%" Text='<%# Bind("column_name") %>'></asp:Label></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">Column Sequence :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="TXT_COLUMN_SEQ_DETAIL_DISPLAY" runat="server" Width="95%" Text='<%# Bind("COLUMN_SEQ") %>'></asp:Label></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">From Position :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="TXT_FROM_POS_DETAIL_DISPLAY" runat="server" Width="95%" Text='<%# Bind("FROM_POS") %>'></asp:Label></TD></TR><TR align=right><TD style="WIDTH: 15%; TEXT-ALIGN: right" class="TableColumns">To Position :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:Label id="TXT_TO_POS_DETAIL_DISPLAY" runat="server" Width="95%" Text='<%# Bind("TO_POS") %>'></asp:Label></TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE>
</ItemTemplate>
</asp:FormView> <TABLE class="loginDown" cellSpacing=0 width="100%"><TBODY><TR><TD><SPAN style="BACKGROUND-COLOR: #cccc00"></SPAN></TD></TR></TBODY></TABLE><asp:ObjectDataSource id="SP_SPDS_DataLoadCofigurationDetail_ALL" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Get_SPDS_DataLoadCofigurationDetail_ALL" TypeName="LOV_COLLECTION"><SelectParameters>
<asp:SessionParameter SessionField="SPDS_DataLoadDefinationCofiguration_ID" DefaultValue="%" Name="p_CONF_DEF_ID" Type="String"></asp:SessionParameter>
</SelectParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="ObjSP_SPDS_DataLoadCofigurationDetail_SPC" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Get_SPDS_DataLoadCofigurationDetail_SPC" TypeName="LOV_COLLECTION"><SelectParameters>
<asp:SessionParameter SessionField="SPDS_CONF_ID" DefaultValue="-0" Name="p_CONF_ID" Type="String"></asp:SessionParameter>
<asp:SessionParameter SessionField="SPDS_CONF_DEF_ID" DefaultValue="-0" Name="p_CONF_DEF_ID" Type="String"></asp:SessionParameter>
<asp:SessionParameter SessionField="SPDS_COLUMN_ORDER" DefaultValue="-0" Name="P_COLUMN_ORDER" Type="String"></asp:SessionParameter>
<asp:SessionParameter SessionField="SPDS_COLUMN_SEQ" DefaultValue="-0" Name="P_COLUMN_SEQ" Type="String"></asp:SessionParameter>
</SelectParameters>
</asp:ObjectDataSource> 
</contenttemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
