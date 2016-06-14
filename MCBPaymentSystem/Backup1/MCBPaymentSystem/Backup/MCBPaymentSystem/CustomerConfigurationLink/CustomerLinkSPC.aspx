<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="CustomerLinkSPC.aspx.cs" Inherits="CustomerLinkSPC" Title="CustomerLinkSPC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">


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
// ]]>
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:FormView ID="FormView1" runat="server" Width="100%" OnPageIndexChanging="FormView1_PageIndexChanging"
                            Font-Size="10pt" Font-Names="Verdana" DataSourceID="ObjSP_RPS_DraftCancellation_SPC"
                            DataKeyNames="ID" OnDataBound="FormView1_DataBound">
                            <EditItemTemplate>
                                <asp:Button ID="BTN_Update" OnClick="BTN_Update_Click" runat="server" Font-Size="10pt"
                                    Font-Names="Verdana" Text="Update" CommandName="Cancel" Font-Bold="True" CausesValidation="True">
                                </asp:Button><asp:Button ID="BTN_Update_Cancel" OnClick="BTN_Update_Cancel_Click"
                                    runat="server" Font-Size="10pt" Font-Names="Verdana" Text="Cancel" CommandName="Cancel"
                                    Font-Bold="True" CausesValidation="False"></asp:Button><%--<eo:ToolBar id="EditToolbar" runat="server" __designer:wfdid="w383" AutoPostBack="True" OnItemClick="EditToolbar_ItemClick">
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
            </eo:ToolBar>--%><hr style="color: darkgray" />
                                <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                    <tbody>
                                        <tr align="right">
                                            <td style="text-align: center" class="ColLines1" colspan="2">
                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                    <ProgressTemplate>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif"></asp:Image>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 25%; color: red; text-align: right" class="TableColumns">
                                                Company Code :&nbsp;
                                            </td>
                                            <td style="width: 50%; text-align: left" class="ColLines">
                                                <asp:DropDownList ID="ddlCompanyCode_EDIT" runat="server" Width="355px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 25%; color: red" class="TableColumns">
                                                Conf. Defination ID :&nbsp;
                                            </td>
                                            <td style="width: 50%; text-align: left" class="ColLines">
                                                <asp:DropDownList ID="ddlConfigID_EDIT" runat="server" Width="355px">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr align="right">
                                            <td class="TableColumns" style="width: 15%; text-align: right">
                                                FTP Type :&nbsp;
                                            </td>
                                            <td class="ColLines" style="width: 35%; text-align: left">
                                                <asp:DropDownList ID="DDL_FTP_TYPE_EDIT" runat="server" Width="127px" SelectedValue='<%# BIND("ftp_type") %>'>
                                                    <asp:ListItem>FTP</asp:ListItem>
                                                    <asp:ListItem>FTPS</asp:ListItem>
                                                    <asp:ListItem>SFTP</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr align="right">
                                            <td class="TableColumns" style="width: 15%; text-align: right">
                                                FTP Port :&nbsp;
                                            </td>
                                            <td class="ColLines" style="width: 35%; text-align: left">
                                                <asp:TextBox ID="TXT_FTP_PORT_EDIT" runat="server" MaxLength="6" SkinID="TXT" Text='<%# BIND("ftp_port") %>'
                                                    Width="120px"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers" TargetControlID="TXT_FTP_PORT_EDIT" >
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP&nbsp;File Upload Path :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:TextBox ID="TXT_Upload_Path_EDIT" runat="server" Width="350px" Text='<%# BIND("FTP_LOADPATH") %>'
                                                    MaxLength="200" SkinID="TXT"></asp:TextBox></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File Upload User ID :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:TextBox ID="TXT_Upload_UserID_EDIT" runat="server" Width="120px" Text='<%# BIND("FTP_USERID") %>'
                                                    MaxLength="10" SkinID="TXT"></asp:TextBox></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File Upload&nbsp;Password :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:TextBox ID="TXT_Upload_Password_EDIT" runat="server" Width="120px" Text='<%# BIND("FTP_PASSWORD") %>'
                                                    MaxLength="10" SkinID="TXT"></asp:TextBox></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File&nbsp;Move&nbsp;Path :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:TextBox ID="TXT_Move_Path_EDIT" runat="server" Width="350px" Text='<%# BIND("FTP_MOVEPATH") %>'
                                                    MaxLength="200" SkinID="TXT"></asp:TextBox></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File&nbsp;Move&nbsp;User ID&nbsp;:&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:TextBox ID="TXT_Move_UserID_EDIT" runat="server" Width="120px" Text='<%# BIND("FTP_MOVE_USERID") %>'
                                                    MaxLength="10" SkinID="TXT"></asp:TextBox></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File&nbsp;Move&nbsp;Password :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:TextBox ID="TXT_Move_Password_EDIT" runat="server" Width="120px" Text='<%# BIND("FTP_MOVE_PASSWORD") %>'
                                                    MaxLength="10" SkinID="TXT"></asp:TextBox></td>
                                        </tr>
                                        <tr align="right">
                                        </tr>
                                    </tbody>
                                </table>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:Button ID="BTN_INSERT" OnClick="BTN_INSERT_Click" runat="server" Font-Size="10pt"
                                    Font-Names="Verdana" Text="Insert" CommandName="Insert" Font-Bold="True" CausesValidation="True"
                                    ForeColor="White"></asp:Button>
                                <asp:Button ID="BTN_RESET" OnClick="BTN_RESET_Click" runat="server" Font-Size="10pt"
                                    Font-Names="Verdana" Text="Reset" CommandName="reset" Font-Bold="True" CausesValidation="False"
                                    ForeColor="White"></asp:Button>
                                <asp:Button ID="BTN_INSERT_CANCEL" OnClick="BTN_INSERT_CANCEL_Click" runat="server"
                                    Font-Size="10pt" Font-Names="Verdana" Text="Cancel" CommandName="Cancel" Font-Bold="True"
                                    CausesValidation="False" ForeColor="White"></asp:Button><%--<eo:ToolBar id="InsertToolbar" runat="server" __designer:wfdid="w286" AutoPostBack="True" OnItemClick="InsertToolbar_ItemClick">
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
        </eo:ToolBar>--%><hr style="color: darkgray" />
                                <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                    <tbody>
                                        <tr align="right">
                                            <td style="text-align: center" class="ColLines1" colspan="2">
                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                    <ProgressTemplate>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif"></asp:Image>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 25%; color: red; text-align: right" class="TableColumns">
                                                Company Code :&nbsp;
                                            </td>
                                            <td style="width: 50%; text-align: left" class="ColLines">
                                                <asp:DropDownList ID="ddlCompanyCode" runat="server" Width="355px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 25%; color: red" class="TableColumns">
                                                Conf. Defination ID :&nbsp;
                                            </td>
                                            <td style="width: 50%; text-align: left" class="ColLines">
                                                <asp:DropDownList ID="ddlConfigID" runat="server" Width="355px">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr align="right">
                                            <td class="TableColumns" style="width: 15%; text-align: right">
                                                FTP Type :&nbsp;
                                            </td>
                                            <td class="ColLines" style="width: 35%; text-align: left">
                                                <asp:DropDownList ID="DDL_FTP_TYPE_INSERT" runat="server" Width="127px">
                                                    <asp:ListItem>FTP</asp:ListItem>
                                                    <asp:ListItem>FTPS</asp:ListItem>
                                                    <asp:ListItem>SFTP</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr align="right">
                                            <td class="TableColumns" style="width: 15%; text-align: right">
                                                FTP&nbsp; Port :&nbsp;
                                            </td>
                                            <td class="ColLines" style="width: 35%; text-align: left">
                                                <asp:TextBox ID="TXT_FTP_PORT_INSERT" runat="server" MaxLength="6" SkinID="TXT"
                                                    Width="120px"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    TargetControlID="TXT_FTP_PORT_INSERT" FilterType="Numbers" Enabled="True">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP&nbsp;File Upload Path :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:TextBox ID="TXT_Upload_Path_INSERT" runat="server" Width="350px" MaxLength="200"
                                                    SkinID="TXT"></asp:TextBox></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File Upload User ID :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:TextBox ID="TXT_Upload_UserID_INSERT" runat="server" Width="120px" MaxLength="10"
                                                    SkinID="TXT"></asp:TextBox></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File Upload&nbsp;Password :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:TextBox ID="TXT_Upload_Password_INSERT" runat="server" Width="120px" MaxLength="10"
                                                    SkinID="TXT"></asp:TextBox></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File&nbsp;Move&nbsp;Path :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:TextBox ID="TXT_Move_Path_INSERT" runat="server" Width="350px" MaxLength="200"
                                                    SkinID="TXT"></asp:TextBox></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File&nbsp;Move&nbsp;User ID&nbsp;:&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:TextBox ID="TXT_Move_UserID_INSERT" runat="server" Width="120px" MaxLength="10"
                                                    SkinID="TXT"></asp:TextBox></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File&nbsp;Move&nbsp;Password :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:TextBox ID="TXT_Move_Password_INSERT" runat="server" Width="120px" MaxLength="10"
                                                    SkinID="TXT"></asp:TextBox></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 25%; color: red" class="ColLines1">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        &nbsp;<asp:TextBox ID="TXT_CompanyCode_INSERT" runat="server" Width="80px" Visible="False"
                                                            MaxLength="10" SkinID="TXT"></asp:TextBox>
                                                        <asp:ImageButton ID="BTN_CompanyCode_INSERT" OnClick="BTN_CompanyCode_INSERT_Click"
                                                            runat="server" Visible="False" ImageUrl="~/images/search_16x16.png" CausesValidation="False"
                                                            OnClientClick="CompanyLOV();"></asp:ImageButton>
                                                        <asp:TextBox ID="TXT_CustomerName_INSERT" runat="server" Width="300px" Visible="False"
                                                            MaxLength="50" SkinID="TXT"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="REQ_BankCode_INSERT" runat="server" Enabled="False"
                                                            ControlToValidate="TXT_CompanyCode_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td style="width: 50%; text-align: left" class="ColLines">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        &nbsp;<asp:TextBox ID="TXT_ConfigCode_INSERT" runat="server" Width="80px" Visible="False"
                                                            MaxLength="10" SkinID="TXT"></asp:TextBox>
                                                        <asp:ImageButton ID="BTN_ConfigCode_INSERT" OnClick="BTN_ConfigCode_INSERT_Click"
                                                            runat="server" Visible="False" ImageUrl="~/images/search_16x16.png" CausesValidation="False"
                                                            OnClientClick="ConfigdescLOV();"></asp:ImageButton>
                                                        <asp:TextBox ID="TXT_ConfigDefName_INSERT" runat="server" Width="300px" Visible="False"
                                                            MaxLength="50" SkinID="TXT"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                                runat="server" Enabled="False" ControlToValidate="TXT_ConfigCode_INSERT" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr align="right">
                                        </tr>
                                    </tbody>
                                </table>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Button ID="BTN_EDIT" OnClick="BTN_EDIT_Click" runat="server" Width="60px" Font-Size="10pt"
                                    Font-Names="Verdana" Text="Edit" CommandName="Edit" Font-Bold="True"></asp:Button>
                                <asp:Button ID="BTN_DELETE" runat="server" Width="60px" Font-Size="10pt" Font-Names="Verdana"
                                    Text="DELETE" CommandName="DELETE" Font-Bold="True" Enabled="false"></asp:Button>
                                <asp:Button ID="BTN_Cancel" OnClick="BTN_Cancel_Click" runat="server" Width="60px"
                                    Font-Size="10pt" Font-Names="Verdana" Text="Cancel" CommandName="CANCLE" Font-Bold="True">
                                </asp:Button><%--<eo:ToolBar id="DisplayToolBar" runat="server" __designer:wfdid="w394" AutoPostBack="True" OnItemClick="DisplayToolBar_ItemClick">
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
            </eo:ToolBar>--%><hr style="color: darkgray" />
                                <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                    <tbody>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                Company Code :&nbsp;
                                            </td>
                                            <td style="width: 50%; text-align: left" class="ColLines">
                                                <asp:Label ID="TXT_COMPANY_CODE_DISPLAY" runat="server" Width="207px" Text='<%# BIND("company_code") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                Conf. Defination ID :&nbsp;
                                            </td>
                                            <td style="width: 50%; text-align: left" class="ColLines">
                                                <asp:Label ID="TXT_CONFIG_DEF_DISPLAY" runat="server" Width="179px" Text='<%# BIND("conf_def_id") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td class="TableColumns" style="width: 15%; text-align: right">
                                                FTP Type :&nbsp;
                                            </td>
                                            <td class="ColLines" style="width: 35%; text-align: left">
                                                <asp:Label ID="TXT_FTP_TYPE_DISPLAY" runat="server" Text='<%# BIND("ftp_type") %>'
                                                    Width="197px"></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td class="TableColumns" style="width: 15%; text-align: right">
                                                FTP Port :&nbsp;
                                            </td>
                                            <td class="ColLines" style="width: 35%; text-align: left">
                                                <asp:Label ID="TXT_FTP_PORT_DISPLAY" runat="server" Text='<%# BIND("ftp_port") %>'
                                                    Width="197px"></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP&nbsp;File Upload Path :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:Label ID="TXT_FILE_UPLOAD_DISPLAY" runat="server" Width="197px" Text='<%# BIND("ftp_loadpath") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File Upload User ID :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:Label ID="TXT_UPLOAD_USERID_DISPLAY" runat="server" Width="209px" Text='<%# BIND("ftp_userid") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File Upload&nbsp;Password :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:Label ID="TXT_UPLOAD_PASSWORD_DISPLAY" runat="server" Width="230px" Text='<%# BIND("ftp_password") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File&nbsp;Move&nbsp;Path :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:Label ID="TXT_FILE_MOVE_DISPLAY" runat="server" Width="185px" Text='<%# BIND("ftp_movepath") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File&nbsp;Move&nbsp;User ID&nbsp;:&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:Label ID="TXT_MOVE_USERID_DISPLAY" runat="server" Width="202px" Text='<%# BIND("ftp_move_userid") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 15%; text-align: right" class="TableColumns">
                                                FTP File&nbsp;Move&nbsp;Password :&nbsp;
                                            </td>
                                            <td style="width: 35%; text-align: left" class="ColLines">
                                                <asp:Label ID="TXT_MOVE_PASSWORD_DISPLAY" runat="server" Width="220px" Text='<%# BIND("ftp_move_password") %>'></asp:Label></td>
                                        </tr>
                                        <tr align="right">
                                            <td style="width: 25%; color: red" class="ColLines1">
                                            </td>
                                            <td style="width: 50%; text-align: left" class="ColLines">
                                            </td>
                                        </tr>
                                        <tr align="right">
                                        </tr>
                                    </tbody>
                                </table>
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="Label_HEAD" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
                                    Text="Customer Configuration Link" Width="100%" SkinID="FormViewHeadin"></asp:Label>
                            </HeaderTemplate>
                        </asp:FormView>
                        <table class="loginDown" cellspacing="0" width="100%">
                            <tbody>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:ObjectDataSource ID="ObjSP_RPS_DraftCancellation_SPC" runat="server" TypeName="LOV_COLLECTION"
                            SelectMethod="Get_CUST_CONF_LINK_GetByCode" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:SessionParameter SessionField="ROWID" DefaultValue="%" Name="ID" Type="String">
                                </asp:SessionParameter>
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    &nbsp;
</asp:Content>
