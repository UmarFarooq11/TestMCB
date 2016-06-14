<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="SPDS_InstrumentFileSetup.aspx.cs" Inherits="SPDS_InstrumentFileSetup_SPDS_InstrumentFileSetup"
    Title="Instrument File Setup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
function SearchCustomerCode()
    {
        document.getElementById("ctl00_ContentPlaceHolder1_btnCustomerCodeSearch").click();
        return false;
    } 
    function SearchCorrespondentBankCode()
    {
       document.getElementById("ctl00_ContentPlaceHolder1_btnCorrespondentBankCodeSearch").click();
       return false;
    }
    
    
    function CustomerLOV() 
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_Customer.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}

    function CorrespondingLOV() 
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_Correspondent.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
    
    </script>

    <div style="text-align: left">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table cellspacing="0" class="air1" width="100%">
            <tr>
                <td colspan="3" style="height: 1px">
                    <asp:Label ID="Label1" runat="server" Font-Size="Large" SkinID="FormViewHeading"
                        Text="Instrument File Setup" Width="100%"></asp:Label><br />
                    <eo:ToolBar ID="EditToolbar" runat="server" AutoPostBack="True" OnItemClick="EditToolbar_ItemClick">
                        <DownStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 3px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                        <HoverStyle CssText="BORDER-RIGHT: #335ea8 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #335ea8 1px solid; PADDING-LEFT: 3px; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; BORDER-LEFT: #335ea8 1px solid; CURSOR: hand; PADDING-TOP: 2px; BORDER-BOTTOM: #335ea8 1px solid; FONT-FAMILY: Tahoma; BACKGROUND-COLOR: #ffe1ac" />
                        <Items>
                            <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" ImageUrl="00101054"
                                ToolTip="Update">
                            </eo:ToolBarItem>
                            <eo:ToolBarItem AutoCheck="True" CommandArgument="" CommandName="Cancel" ImageUrl="00000508"
                                ToolTip="Authorize">
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
                    <table cellspacing="0" class="air" style="font-size: 8pt; font-family: Verdana" width="100%">
                        <tr align="right">
                            <td class="ColLines1" colspan="8" style="text-align: center; font-weight: bold; color: red;">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:Label ID="lblMessage" runat="server"></asp:Label></td>
                        </tr>
                        <tr align="right">
                            <td class="ColLines1" colspan="2" style="font-weight: bold; color: red; width: 15%;">
                                File Path :</td>
                            <td class="ColLines" colspan="6" style="width: 35%; text-align: left">
                                &nbsp;<asp:TextBox ID="TXT_FILE" runat="server" CssClass="txt" MaxLength="50" SkinID="TXT"
                                    Width="300px"></asp:TextBox></td>
                        </tr>
                        <tr align="right">
                        </tr>
                        <tr align="right">
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
