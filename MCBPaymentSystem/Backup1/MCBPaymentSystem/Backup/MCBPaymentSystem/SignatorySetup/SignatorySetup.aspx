<%@ Page Title="" Language="C#" Theme="ColorSchemeBlue" MasterPageFile="~/MasterPage/RoutinePage.master"
    AutoEventWireup="true" CodeFile="SignatorySetup.aspx.cs" Inherits="SignatorySetup_SignatorySetup" %>

<%@ MasterType VirtualPath="~/MasterPage/RoutinePage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

        function TABLE1_onclick() {

        }

        function TABLE1_onclick() {

        }

        function UsersLOV() {
            var a;
            var c = '<%= Session["HEIGHT"] %>';
            var b = '<%= Session["WIDTH"] %>';
            a = window.showModalDialog('../LOV/LOV_UserCMPY.aspx', null, 'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
        }

// ]]>
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellspacing="0" class="login" width="100%" runat="server" id="tbledit">
        <tr>
            <td>
                <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" Text="Update"
                    Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" OnClick="UpdateButton_Click">
                </asp:Button>
                <asp:Button ID="UpdateCancelButton" runat="server" CausesValidation="False" Text="Cancel"
                    Font-Size="10pt" Font-Names="Verdana" CommandName="Cancel" Font-Bold="True" OnClick="UpdateCancelButton_Click">
                </asp:Button>
            </td>
        </tr>
    </table>
    <table cellspacing="0" class="login" width="100%" runat="server" id="tblinst">
        <tr>
            <td>
                <asp:Button ID="BTN_INSERT" runat="server" CausesValidation="True" Text="Insert"
                    Font-Size="10pt" Font-Names="Verdana" ForeColor="White" CommandName="Insert"
                    Font-Bold="True" OnClick="BTN_INSERT_Click"></asp:Button>&nbsp;<asp:Button ID="BTN_RESET"
                        runat="server" CausesValidation="False" Text="Reset" Font-Size="10pt" Font-Names="Verdana"
                        ForeColor="White" Font-Bold="True" OnClick="BTN_RESET_Click"></asp:Button>
                <asp:Button ID="BTN_INSERT_CANCEL" runat="server" CausesValidation="False" Text="Cancel"
                    Font-Size="10pt" Font-Names="Verdana" ForeColor="White" CommandName="Cancel"
                    Font-Bold="True" OnClick="BTN_INSERT_CANCEL_Click"></asp:Button><br />
            </td>
        </tr>
    </table>
    <table cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%">
        <tr align="right">
            <td class="ColLines1" colspan="2" style="text-align: center">
                <asp:Label ID="lblDuplicate_INSERT" runat="server" Font-Bold="True" Font-Size="Smaller"
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr align="right" style="font-size: 8pt; color: #000000">
            <td class="ColLines1" style="width: 15%; text-align: right; color: red;">
                Signatory User :
            </td>
            <td class="ColLines" style="width: 35%; text-align: left">
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="TXT_SIGNATORY_NAME_INSERT" runat="server" MaxLength="100" SkinID="TXT"
                                Width="80px" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnlov" CausesValidation="false" ImageUrl="~/images/search_16x16.png"
                                runat="server" OnClick="btnlov_Click" OnClientClick="UsersLOV();" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtusername" runat="server" SkinID="TXT" Width="300px" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="REQ_SignatoryName_INSERT" runat="server" ControlToValidate="TXT_SIGNATORY_NAME_INSERT"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="right" style="font-size: 8pt">
            <td style="width: 15%; text-align: right; color: red;" class="ColLines1">
                Signature Image :
            </td>
            <td style="width: 35%; text-align: left" class="ColLines">
                &nbsp;<asp:FileUpload ID="TXT_UPLOAD_IMAGE_PATH_INSERT" runat="server" SkinID="TXT"
                    Width="300px" />
                <asp:RequiredFieldValidator ID="REQ__UPLOAD_IMAGE_PATH_INSERT" runat="server" ControlToValidate="TXT_UPLOAD_IMAGE_PATH_INSERT"
                    ErrorMessage="Proper Information Required" Enabled="False"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr align="right" style="font-size: 8pt">
            <td style="width: 15%; text-align: right" class="ColLines1">
                Status :&nbsp;
            </td>
            <td style="width: 35%; text-align: left" class="ColLines">
                &nbsp;<asp:DropDownList ID="DDL_CURRENT_STATUS_INSERT" runat="server">
                    <asp:ListItem Value="1">Active</asp:ListItem>
                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</asp:Content>
