<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="frmPRIFileSetupSPC.aspx.cs" Inherits="PRIFileSetup_frmPRIFileSetupSPC"
    Title="PRI File SetupDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <contenttemplate>
                        <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" DataSourceID="ObjSP_PRIFileSetup_SPC"
                            Font-Names="Verdana" Font-Size="10pt" OnPageIndexChanging="FormView1_PageIndexChanging"
                            Width="100%">
                            <EditItemTemplate>
                                <table cellspacing="0" class="login" width="100%">
                                    <tr>
                                        <td>
                                            <eo:ToolBar ID="EditToolbar" runat="server" AutoPostBack="True" OnItemClick="EditToolbar_ItemClick">
                                                <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 0px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 0px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 0px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 0px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                <Items>
                                                    <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" ImageUrl="~/images/UPDATE.PNG"
                                                        ToolTip="Update">
                                                    </eo:ToolBarItem>
                                                    <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" ImageUrl="~/images/CANCLE.PNG"
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
                                                <NormalStyle CssText="PADDING-RIGHT: 0px; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 3px; CURSOR: hand; BORDER-TOP-STYLE: none; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" />
                                            </eo:ToolBar>
                                        </td>
                                    </tr>
                                </table>
                                <table style="font-size: 8pt; font-family: Verdana" width="100%" cellspacing="0"
                                    class="air">
                                    <tr align="right">
                                        <td class="ColLines1" colspan="2" style="text-align: center">
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                <ProgressTemplate>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td style="width: 15%; text-align: right" class="ColLines1">
                                            FileUpload :</td>
                                        <td style="width: 35%; text-align: left" class="ColLines">
                                            &nbsp;<asp:TextBox ID="TXT_FileUpload_EDIT" runat="server" Width="80%" Text='<%# Bind("FileUpload") %>'
                                                MaxLength="300" SkinID="TXT"></asp:TextBox></td>
                                    </tr>
                                    <tr align="right">
                                        <td style="width: 15%; text-align: right" class="ColLines1">
                                            FileDownload :</td>
                                        <td style="width: 35%; text-align: left" class="ColLines">
                                            &nbsp;<asp:TextBox ID="TXT_FileDownload_EDIT" runat="server" Width="80%" Text='<%# Bind("FileDownload") %>'
                                                MaxLength="300" SkinID="TXT"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="right">
                                    </tr>
                                </table>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <table cellspacing="0" class="login" width="100%">
                                    <tr>
                                        <td>
                                            <eo:ToolBar ID="DisplayToolBar" runat="server" AutoPostBack="True" OnItemClick="DisplayToolBar_ItemClick">
                                                <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 0px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 0px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 0px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 0px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                                                <Items>
                                                    <eo:ToolBarItem AutoCheck="True" CommandArgument="Edit" CommandName="Edit" Disabled="True"
                                                        ImageUrl="~/images/EDIT.PNG" ToolTip="Edit">
                                                    </eo:ToolBarItem>
                                                    <eo:ToolBarItem CommandName="Cancel" Disabled="True" ImageUrl="~/images/DELETE.PNG" ToolTip="Delete">
                                                    </eo:ToolBarItem>
                                                    <eo:ToolBarItem CommandName="Cancel" Disabled="True" ImageUrl="~/images/CANCLE.PNG"
                                                        ToolTip="Cancel">
                                                    </eo:ToolBarItem>
                                                   <%-- <eo:ToolBarItem CommandName="Cancel" Type="Separator">
                                                    </eo:ToolBarItem>--%>
                                                    <eo:ToolBarItem CommandName="Cancel" Disabled="True" ImageUrl="~/images/AUTHO.GIF" ToolTip="Authorize / Unauthorize">
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
                                                <NormalStyle CssText="PADDING-RIGHT: 4px; PADDING-LEFT: 0px; FONT-SIZE: 12px; PADDING-BOTTOM: 3px; CURSOR: hand; BORDER-TOP-STYLE: none; PADDING-TOP: 3px; FONT-FAMILY: Tahoma; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" />
                                            </eo:ToolBar>
                                        </td>
                                    </tr>
                                </table>
                                <table cellspacing="0" class="air" style="font-size: 10pt; font-family: Verdana"
                                    width="100%">
                                    <tr align="right">
                                        <td style="width: 15%; text-align: right" class="ColLines1">
                                            FileUpload :&nbsp;
                                        </td>
                                        <td style="width: 35%; text-align: left" class="ColLines">
                                            &nbsp;<asp:Label ID="TXT_FileUpload_DISPLAY" runat="server" Width="95%" Text='<%# Bind("FileUpload") %>'></asp:Label></td>
                                    </tr>
                                    <tr align="right">
                                        <td style="width: 15%; text-align: right" class="ColLines1">
                                            FileDownload :&nbsp;
                                        </td>
                                        <td style="width: 35%; text-align: left" class="ColLines">
                                            &nbsp;<asp:Label ID="TXT_FileDownload_DISPLAY" runat="server" Width="95%" Text='<%# Bind("FileDownload") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr align="right">
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="Label_HEAD" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
                                    Text="PRI File Setup" Width="100%" SkinID="FormViewHeading"></asp:Label>
                            </HeaderTemplate>
                        </asp:FormView>
                        <table cellspacing="0" class="loginDown" width="100%">
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <asp:ObjectDataSource ID="ObjSP_PRIFileSetup_SPC" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="SP_PRIFileSetup" TypeName="LOV_COLLECTION"></asp:ObjectDataSource>
                    </contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
