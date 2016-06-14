<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true" CodeFile="frmSPDS_UniversalUploadCofigurationSPC.aspx.cs" Inherits="UniversalUploadProcess_frmSPDS_UniversalUploadCofigurationSPC" Title = "Universal Upload ProcessDetail" %>
<%@ Register
Assembly="AjaxControlToolkit"
Namespace="AjaxControlToolkit"
TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {}

function UniversalUploadLOV()
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_UniversalUploadCofiguration.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
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
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

    <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" DataSourceID="ObjSP_SPDS_UniversalUploadCofiguration_SPC"
        Font-Names="Verdana" Font-Size="10pt" OnPageIndexChanging="FormView1_PageIndexChanging"
        Width="100%">
        <EditItemTemplate>
            <table cellspacing="0" class="login" width="100%">
                <tr>
                    <td>
    <eo:ToolBar ID="EditToolbar" runat="server" AutoPostBack="True" OnItemClick="EditToolbar_ItemClick">
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
            </eo:ToolBar>
                    </td>
                </tr>
            </table>
            <table style="font-size: 8pt; font-family: Verdana" width="100%">
        <tr align="right">
            <td style="width: 15%; text-align: right">
ID :</td>
            <td style="width: 35%; text-align: left">
                &nbsp;<asp:TextBox ID="TXT_ID_EDIT" runat="server" Width="50px" Text='<%# Bind("ID") %>'  MaxLength= "4"  ></asp:TextBox>
            </td>
            <td style="width: 15%; text-align: right">
Channel :</td>
            <td style="width: 35%; text-align: left">
                <asp:TextBox ID="TXT_Channel_EDIT" runat="server" Width="200px" Text='<%# Bind("Channel") %>'  MaxLength= "4" SkinID="TXT"  ></asp:TextBox>
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
SourceID :</td>
            <td style="width: 35%; text-align: left">
                &nbsp;<asp:TextBox ID="TXT_SourceID_EDIT" runat="server" Width="50px" Text='<%# Bind("SourceID") %>'  MaxLength= "4" SkinID="TXT"  ></asp:TextBox>
            </td>
            <td style="width: 15%; text-align: right">
Configuration Name :</td>
            <td style="width: 35%; text-align: left">
                <asp:TextBox ID="TXT_ConfigurationName_EDIT" runat="server" Width="200px" Text='<%# Bind("ConfigurationName") %>'  MaxLength= "1" SkinID="TXT"  ></asp:TextBox>
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
File Format :</td>
            <td style="width: 35%; text-align: left">
                <asp:TextBox ID="TXT_FileFormat_EDIT" runat="server" Width="200px" Text='<%# Bind("FileFormat") %>'  MaxLength= "4"  ></asp:TextBox>
            </td>
            <td style="width: 15%; text-align: right">
FilePath :</td>
            <td style="width: 35%; text-align: left">
                <asp:TextBox ID="TXT_FilePath_EDIT" runat="server" Width="200px" Text='<%# Bind("FilePath") %>'  MaxLength= "200" SkinID="TXT"  ></asp:TextBox>
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
ArchivePath :</td>
            <td style="width: 35%; text-align: left">
                <asp:TextBox ID="TXT_ArchivePath_EDIT" runat="server" Width="200px" Text='<%# Bind("ArchivePath") %>'  MaxLength= "200"  ></asp:TextBox>
            </td>
            <td style="width: 15%; text-align: right">
ObjectType :</td>
            <td style="width: 35%; text-align: left">
                <asp:TextBox ID="TXT_ObjectType_EDIT" runat="server" Width="200px" Text='<%# Bind("ObjectType") %>'  MaxLength= "4" SkinID="TXT"  ></asp:TextBox>
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
ObjectName :</td>
            <td style="width: 35%; text-align: left">
                <asp:TextBox ID="TXT_ObjectName_EDIT" runat="server" Width="200px" Text='<%# Bind("ObjectName") %>'  MaxLength= "200" SkinID="TXT"  ></asp:TextBox>
            </td>
            <td style="width: 15%; text-align: right">
A_userID :</td>
            <td style="width: 35%; text-align: left">
                <asp:TextBox ID="TXT_A_userID_EDIT" runat="server" Width="50px" Text='<%# Bind("A_userID") %>'  MaxLength= "10" SkinID="TXT"  ></asp:TextBox>
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
A_DateTime :</td>
            <td style="width: 35%; text-align: left">
                <asp:TextBox ID="TXT_A_DateTime_EDIT" runat="server" Width="100px" Text='<%# Bind("A_DateTime") %>'  MaxLength= "8" SkinID="TXT"  ></asp:TextBox>
            </td>
            <td style="width: 15%; text-align: right">
E_UserID :</td>
            <td style="width: 35%; text-align: left">
                <asp:TextBox ID="TXT_E_UserID_EDIT" runat="server" Width="50px" Text='<%# Bind("E_UserID") %>'  MaxLength= "10" SkinID="TXT"  ></asp:TextBox>
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
E_DateTime :</td>
            <td style="width: 35%; text-align: left">
                <asp:TextBox ID="TXT_E_DateTime_EDIT" runat="server" Width="100px" Text='<%# Bind("E_DateTime") %>'  MaxLength= "8" SkinID="TXT"  ></asp:TextBox>
            </td>
        </tr>
        <tr align="right">
        </tr>
    </table>
        </EditItemTemplate>
        <InsertItemTemplate>
            <table cellspacing="0" class="login" width="100%">
                <tr>
                    <td>
<eo:ToolBar ID="InsertToolbar" runat="server" AutoPostBack="True" OnItemClick="InsertToolbar_ItemClick">
            <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
            <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
            <Items>
                <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" ImageUrl="00101001"
                    ToolTip="Start Process">
                </eo:ToolBarItem>
                <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" ImageUrl="~/images/Refresh copy.gif"
                    ToolTip="Clear All">
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
        </eo:ToolBar>
                    </td>
                </tr>
            </table>
    <table style="font-size: 8pt; font-family: Verdana" width="100%" cellspacing="0" id="Table2" onclick="return TABLE1_onclick()">
        <tr align="right">
            <td style="width: 15%; text-align: right" class="ColLines1">
                Configuration Name :</td>
            <td style="width: 35%; text-align: left" class="ColLines">
                &nbsp;<asp:TextBox ID="TXT_ConfigurationName_INSERT" runat="server" Width="200px" Text='<%# Bind("ConfigurationName") %>'  MaxLength= "1" SkinID="TXT"  ></asp:TextBox>
                <asp:ImageButton ID="BTN_Configuration_INSERT" runat="server" CausesValidation="False"
                    ImageUrl="~/images/search_16x16.png" OnClick="BTN_Configuration_INSERT_Click"
                    OnClientClick="UniversalUploadLOV();" /><br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        &nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right" class="ColLines1">
                Select File :</td>
            <td style="width: 35%; text-align: left" class="ColLines">
                &nbsp;<asp:ListBox ID="ListBox1" runat="server" SkinID="TXT" Width="200px"></asp:ListBox>
                <asp:TextBox ID="TextBox1" runat="server" SkinID="TXT" Width="200px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr align="right">
        </tr>
    </table>
        </InsertItemTemplate>
        <ItemTemplate>
            <table cellspacing="0" class="login" width="100%">
                <tr>
                    <td>
<eo:ToolBar ID="DisplayToolBar" runat="server" AutoPostBack="True" OnItemClick="DisplayToolBar_ItemClick">
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
            </eo:ToolBar>
                    </td>
                </tr>
            </table>
    <table cellspacing="0" class="air" style="font-size: 10pt; font-family: Verdana" width="100%">
        <tr align="right">
            <td style="width: 15%; text-align: right">
ID:</td>
            <td style="width: 35%; text-align: left">
                <asp:Label ID="TXT_ID_DISPLAY" runat="server" Width="95%" Text='<%# Bind("ID") %>'></asp:Label>
            </td>
            <td style="width: 15%; text-align: right">
Channel:</td>
            <td style="width: 35%; text-align: left">
                &nbsp;</td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
            </td>
            <td style="width: 35%; text-align: left">
                &nbsp;<asp:Label ID="TXT_Channel_DISPLAY" runat="server" Width="95%" Text='<%# Bind("Channel") %>'></asp:Label></td>
            <td style="width: 15%; text-align: right">
            </td>
            <td style="width: 35%; text-align: left">
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
SourceID:</td>
            <td style="width: 35%; text-align: left">
                <asp:Label ID="TXT_SourceID_DISPLAY" runat="server" Width="95%" Text='<%# Bind("SourceID") %>'></asp:Label>
            </td>
            <td style="width: 15%; text-align: right">
Configuration Name:</td>
            <td style="width: 35%; text-align: left">
                &nbsp;</td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
            </td>
            <td style="width: 35%; text-align: left">
                <asp:Label ID="TXT_ConfigurationName_DISPLAY" runat="server" Width="95%" Text='<%# Bind("ConfigurationName") %>'></asp:Label></td>
            <td style="width: 15%; text-align: right">
            </td>
            <td style="width: 35%; text-align: left">
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
File Format:</td>
            <td style="width: 35%; text-align: left">
                <asp:Label ID="TXT_FileFormat_DISPLAY" runat="server" Width="95%" Text='<%# Bind("FileFormat") %>'></asp:Label>
            </td>
            <td style="width: 15%; text-align: right">
FilePath:</td>
            <td style="width: 35%; text-align: left">
                &nbsp;</td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
            </td>
            <td style="width: 35%; text-align: left">
                <asp:Label ID="TXT_FilePath_DISPLAY" runat="server" Width="95%" Text='<%# Bind("FilePath") %>'></asp:Label></td>
            <td style="width: 15%; text-align: right">
            </td>
            <td style="width: 35%; text-align: left">
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
ArchivePath:</td>
            <td style="width: 35%; text-align: left">
                <asp:Label ID="TXT_ArchivePath_DISPLAY" runat="server" Width="95%" Text='<%# Bind("ArchivePath") %>'></asp:Label>
            </td>
            <td style="width: 15%; text-align: right">
</td>
            <td style="width: 35%; text-align: left">
                &nbsp;</td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
ObjectType:</td>
            <td style="width: 35%; text-align: left">
                <asp:Label ID="TXT_ObjectType_DISPLAY" runat="server" Width="95%" Text='<%# Bind("ObjectType") %>'></asp:Label></td>
            <td style="width: 15%; text-align: right">
            </td>
            <td style="width: 35%; text-align: left">
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
ObjectName:</td>
            <td style="width: 35%; text-align: left">
                <asp:Label ID="TXT_ObjectName_DISPLAY" runat="server" Width="95%" Text='<%# Bind("ObjectName") %>'></asp:Label></td>
            <td style="width: 15%; text-align: right">
            </td>
            <td style="width: 35%; text-align: left">
            </td>
        </tr>
        <tr align="right">
            <td colspan="4" style="text-align: left">
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
</td>
            <td style="width: 35%; text-align: left">
                &nbsp;</td>
            <td style="width: 15%; text-align: right">
A_userID:</td>
            <td style="width: 35%; text-align: left">
                <asp:Label ID="TXT_A_userID_DISPLAY" runat="server" Width="95%" Text='<%# Bind("A_userID") %>'></asp:Label>
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
A_DateTime:</td>
            <td style="width: 35%; text-align: left">
                <asp:Label ID="TXT_A_DateTime_DISPLAY" runat="server" Width="95%" Text='<%# Bind("A_DateTime") %>'></asp:Label>
            </td>
            <td style="width: 15%; text-align: right">
E_UserID:</td>
            <td style="width: 35%; text-align: left">
                <asp:Label ID="TXT_E_UserID_DISPLAY" runat="server" Width="95%" Text='<%# Bind("E_UserID") %>'></asp:Label>
            </td>
        </tr>
        <tr align="right">
            <td style="width: 15%; text-align: right">
E_DateTime:</td>
            <td style="width: 35%; text-align: left">
                <asp:Label ID="TXT_E_DateTime_DISPLAY" runat="server" Width="95%" Text='<%# Bind("E_DateTime") %>'></asp:Label>
            </td>
        </tr>
        <tr align="right">
        </tr>
    </table>
        </ItemTemplate>
        <HeaderTemplate>

            <asp:Label ID="Label_HEAD" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
                Text="Universal Upload Process" Width="100%" SkinID="FormViewHeading"></asp:Label>
        </HeaderTemplate>
    </asp:FormView>
                        <table cellspacing="0" class="loginDown" width="100%">
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjSP_SPDS_UniversalUploadCofiguration_SPC" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetData" TypeName="InformationCollectionTableAdapters.SP_SPDS_UniversalUploadCofiguration_SPCTableAdapter">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="ID" SessionField="SPDS_UniversalUploadCofiguration_ID" Type="Decimal" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
