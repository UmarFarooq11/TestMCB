<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="frmSPDS_InstrumentSetupSPC.aspx.cs" Inherits="InstrumentSetup_frmSPDS_InstrumentSetupSPC"
    Title="Instrument SetupDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[


    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" DataSourceID="ObjSP_SPDS_InstrumentSetup_SPC"
                    Font-Names="Verdana" Font-Size="10pt" Width="100%" OnDataBound="FormView1_DataBound">
                    <EditItemTemplate>
                        <table cellspacing="0" class="login" width="100%">
                            <tr>
                                <td>
                                    <asp:Button ID="BTN_UPDATE" OnClick="UpdateButton_Click" runat="server" Text="Update"
                                        Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" CausesValidation="True">
                                    </asp:Button>
                                  <asp:Button ID="BTN_CANCEL" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" OnClick="BTN_CANCEL_Click"
                                        Text="Cancel" />
                                    <%--   <asp:Button ID="BtnEEdit" runat="server" Height="22px" 
                                        onclick="BtnEEdit_Click1" Text="Edit" Width="63px" />
                                   
                                    <asp:Button ID="BtnECancel" runat="server" Height="22px" 
                                        onclick="BtnECancel_Click" Text="Cancel" Width="63px" />--%>
                                    <%-- <eo:ToolBar ID="EditToolbar" runat="server" AutoPostBack="True" 
                                        OnItemClick="EditToolbar_ItemClick" Visible="False">
                                        <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                        <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                        <Items>
                                            <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" 
                                                ImageUrl="00101054" ToolTip="Update">
                                            </eo:ToolBarItem>
                                            <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" 
                                                ImageUrl="~/images/Refresh copy.gif" ToolTip="Cancel">
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
                                </td>
                            </tr>
                        </table>
                        <table cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%">
                            <tr align="right">
                                <td class="ColLines1" colspan="2" style="color: red; text-align: center">
                                    <asp:Label ID="lblDuplicate_EDIT" runat="server" Font-Bold="True"></asp:Label>
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="ColLines1" style="width: 15%; color: red; text-align: right">
                                    Instrument Name :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:TextBox ID="TXT_INSTRUMENT_NAME_EDIT" runat="server" MaxLength="200" SkinID="TXT"
                                        Text='<%# Bind("INSTRUMENT_NAME") %>' Width="216px" Height="24px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="REQ_INSTRUMENT_NAME_EDIT" runat="server" ControlToValidate="TXT_INSTRUMENT_NAME_EDIT"
                                        ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="ColLines1" style="width: 15%; color: red; text-align: right">
                                    RDLC Upload Path :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:FileUpload ID="TXT_RDLC_UPLOAD_PATH_EDIT" runat="server" SkinID="TXT"
                                        Width="215px" Height="22px" />
                                    <asp:RequiredFieldValidator ID="rfv_rdlc_upload_path_edit" runat="server" ControlToValidate="TXT_RDLC_UPLOAD_PATH_EDIT"
                                        ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator><asp:TextBox
                                            ID="TXT_RDLC_UPLOAD_EDIT" runat="server" MaxLength="200" SkinID="TXT" Text='<%# Bind("RDLC_UPLOAD") %>'
                                            Width="200px" Visible="False"></asp:TextBox><asp:TextBox ID="TXT_INSTRUMENT_ID_EDIT"
                                                runat="server" MaxLength="5" SkinID="TXT" Text='<%# Bind("ID") %>' Visible="False"
                                                Width="50px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table cellspacing="0" class="login" width="100%">
                            <tr>
                                <td>
                                    <asp:Button ID="BTN_INSERT" runat="server" CausesValidation="True" CommandName="Insert"
                                        Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" Text="Insert"
                                        OnClick="BTN_INSERT_Click" />
                                    <asp:Button ID="BTN_RESET" runat="server" CausesValidation="False" Font-Bold="True"
                                        Font-Names="Verdana" Font-Size="10pt" ForeColor="White" OnClick="BTN_RESET_Click"
                                        Text="Reset" />
                                         <asp:Button ID="BTN_CANCEL" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" OnClick="BTN_CANCEL_Click"
                                        Text="Cancel" />
                               
                                    <%--<eo:ToolBar ID="InsertToolbar" runat="server" AutoPostBack="True" 
                                        OnItemClick="InsertToolbar_ItemClick" Visible="False">
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
                                </td>
                            </tr>
                        </table>
                        <table cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%">
                            <tr align="right">
                                <td class="ColLines1" colspan="2" style="color: red; text-align: center">
                                    <asp:Label ID="lblDuplicate_INSERT" runat="server" Font-Bold="True"></asp:Label>
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="ColLines1" style="width: 15%; color: red; text-align: right">
                                    Instrument Name :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:TextBox ID="TXT_INSTRUMENT_NAME_INSERT" runat="server" MaxLength="200"
                                        SkinID="TXT" Text='<%# Bind("INSTRUMENT_NAME") %>' Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="REQ_INSTRUMENT_NAME_INSERT" runat="server" ControlToValidate="TXT_INSTRUMENT_NAME_INSERT"
                                        ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="ColLines1" style="width: 15%; color: red; text-align: right">
                                    RDLC Upload Path :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:FileUpload ID="TXT_RDLC_UPLOAD_PATH_INSERT" runat="server" SkinID="TXT"
                                        Width="300px" />
                                    <asp:RequiredFieldValidator ID="rfv_rdlc_upload_path_insert" runat="server" ControlToValidate="TXT_RDLC_UPLOAD_PATH_INSERT"
                                        ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator><asp:TextBox
                                            ID="TXT_RDLC_UPLOAD_INSERT" runat="server" MaxLength="200" SkinID="TXT" Text='<%# Bind("RDLC_UPLOAD") %>'
                                            Width="200px" Visible="False"></asp:TextBox><asp:TextBox ID="TXT_INSTRUMENT_ID" runat="server"
                                                Enabled="False" MaxLength="200" SkinID="TXT" Text='<%# Bind("INSTRUMENT_NAME") %>'
                                                Width="50px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <table cellspacing="0" class="login" width="100%">
                            <tr>
                                <td>
                                    <%--<eo:ToolBar ID="DisplayToolBar" runat="server" AutoPostBack="True" 
                                        OnItemClick="DisplayToolBar_ItemClick" Visible="False">
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
                                    </eo:ToolBar>--%><asp:Button ID="BTN_EDIT" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt"
                                        OnClick="BTN_EDIT_Click" Text="Edit" Width="60px" />
                                    <asp:Button ID="BTN_DELETE" runat="server" Font-Bold="True" Font-Names="Verdana"
                                        Enabled="false" Font-Size="10pt"  Text="Delete" Width="60px" />
                                                                            <asp:Button ID="BTN_CANCEL" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" OnClick="BTN_CANCEL_Click"
                                        Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                        <table cellspacing="0" class="air" style="font-size: 10pt; font-family: Verdana"
                            width="100%">
                            <tr align="right">
                                <td class="ColLines1" style="width: 15%; text-align: right">
                                    ID :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_ID_DISPLAY" runat="server" Text='<%# Bind("ID") %>' Width="95%"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="ColLines1" style="width: 15%; text-align: right">
                                    Instrument Name :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_INSTRUMENT_NAME_DISPLAY" runat="server" Text='<%# Bind("INSTRUMENT_NAME") %>'
                                        Width="95%"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="ColLines1" style="width: 15%; text-align: right">
                                    RDLC Upload :
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_RDLC_UPLOAD_DISPLAY" runat="server" Text='<%# Bind("RDLC_UPLOAD") %>'
                                        Width="95%"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="ColLines1" style="width: 15%; text-align: right">
                                    RDLC Upload Path :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_RDLC_UPLOAD_PATH_DISPLAY" runat="server" Text='<%# Bind("RDLC_UPLOAD_PATH") %>'
                                        Width="95%"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="ColLines1" colspan="2" style="text-align: left">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Trebuchet MS"
                                        Font-Size="20pt" SkinID="FormViewHeading" Text="Administration"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="ColLines1" style="width: 15%; text-align: right">
                                    Edited By :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_E_UserID_DISPLAY" runat="server" Text='<%# Bind("E_UserID") %>'
                                        Width="95%"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="ColLines1" style="width: 15%; text-align: right">
                                    Authorized By :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_A_UserID_DISPLAY" runat="server" Text='<%# Bind("A_UserID") %>'
                                        Width="95%"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="ColLines1" style="width: 15%; text-align: right">
                                    Edited At :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_E_DateTime_DISPLAY" runat="server" Text='<%# Bind("E_DateTime") %>'
                                        Width="95%"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="ColLines1" style="width: 15%; text-align: right">
                                    Authorized At :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_A_DateTime_DISPLAY" runat="server" Text='<%# Bind("A_DateTime") %>'
                                        Width="95%"></asp:Label>
                                </td>
                            </tr>
                        </table>
                          <asp:Button ID="CMD_AUTHORIZE" runat="server" Text="Authorize / UnAuthorize" Visible="TRUE" OnClick="CMD_AUTHORIZE_Click" TabIndex="-1" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="Label_HEAD" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
                            SkinID="FormViewHeading" Text="Instrument Setup" Width="100%"></asp:Label>
                    </HeaderTemplate>
                </asp:FormView>
                <table cellspacing="0" class="loginDown" width="100%">
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
                <asp:ObjectDataSource ID="ObjSP_SPDS_InstrumentSetup_SPC" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="Get_SPDS_InstrumentSetup_SPC" TypeName="LOV_COLLECTION">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="ID" SessionField="SPDS_InstrumentSetup_ID"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
