<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="frmSPDS_SignatorySetupSPC.aspx.cs" Inherits="SignatorySetup_frmSPDS_SignatorySetupSPC"
    Title="Signatory SetupDetail" %>

<%@ MasterType VirtualPath="~/MasterPage/RoutinePage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
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
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" Font-Names="Verdana"
                    Font-Size="10pt" Width="100%" onmodechanging="FormView1_ModeChanging">
                    <EditItemTemplate>
                        <table cellspacing="0" class="login" width="100%">
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
                        <table cellspacing="0" class="air" style="font-size: 8pt; font-family: Verdana" width="100%">
                            <tr align="right">
                                <td class="ColLines1" colspan="2" style="text-align: center">
                                    <asp:Label ID="lblDuplicate_EDIT" runat="server" Font-Bold="True" Font-Size="Smaller"
                                        ForeColor="Red"></asp:Label>
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif">
                                            </asp:Image>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr align="right" style="font-size: 8pt; color: #000000">
                                <td class="TableColumns" style="width: 15%; text-align: right; color: red;">
                                    Signatory User :
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="TXT_SIGNATORY_NAME_EDIT" runat="server" MaxLength="100" SkinID="TXT"
                                                    Text='<%# Bind("SIGNATORY_NAME") %>' Width="80px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnlovEdit" ImageUrl="~/images/search_16x16.png" runat="server"
                                                    OnClick="btnlov_Click" OnClientClick="UsersLOV();" CausesValidation="False" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtusernameedit" runat="server" SkinID="TXT" Width="300px" Text='<%# bind("REAL_NAME") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="REQ_SignatoryName_EDIT" runat="server" ControlToValidate="TXT_SIGNATORY_NAME_EDIT"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="TableColumns" style="width: 15%; text-align: right; color: red;">
                                    Signature Image :
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:FileUpload ID="TXT_UPLOAD_IMAGE_PATH_EDIT" runat="server" SkinID="TXT"
                                        Width="300px" />
                                    <asp:RequiredFieldValidator ID="REQ_UPLOAD_IMAGE_PATH_EDIT" runat="server" ControlToValidate="TXT_UPLOAD_IMAGE_PATH_EDIT"
                                        ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="TableColumns" style="width: 15%; text-align: right">
                                    Status :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:DropDownList ID="DDL_CURRENT_STATUS_EDIT" runat="server" SelectedValue='<%# Bind("CURRENT_STATUS") %>'>
                                        <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                                        <asp:ListItem Value="0">Inactive</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table cellspacing="0" class="login" width="100%">
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
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr align="right" style="font-size: 8pt; color: #000000">
                                <td class="TableColumns" style="width: 15%; text-align: right; color: red;">
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
                                <td style="width: 15%; text-align: right; color: red;" class="TableColumns">
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
                                <td style="width: 15%; text-align: right" class="TableColumns">
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
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <table cellspacing="0" class="login" width="100%">
                            <tr>
                                <td>
                                    <asp:Button ID="BTN_EDIT" runat="server" CommandName="Edit" Font-Bold="True" Font-Names="Verdana"
                                        Font-Size="10pt" Text="Edit" Width="60px" OnClick="BTN_EDIT_Click" />
                                    <asp:Button ID="BTN_DELETE" runat="server" Font-Bold="True" Font-Names="Verdana"
                                        Enabled="false" Font-Size="10pt" Text="Delete" Width="60px" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                    <asp:Button ID="BTN_Cancel" runat="server" Font-Bold="True" Font-Names="Verdana"
                                        Font-Size="10pt" OnClick="BTN_Cancel_Click" Text="Cancel" Width="60px" />
                                    <asp:Button ID="btnAuthorize" runat="server" CausesValidation="False" CommandName="Authorize"
                                        Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" OnClick="btnAuthorize_Click"
                                        Text="Authorize" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: CENTER">
                                    <asp:Label ID="lblDuplicate_Auth" runat="server" Font-Bold="True" Font-Size="Smaller"
                                        ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table cellspacing="0" class="air" style="font-size: 10pt; font-family: Verdana"
                            width="100%">
                            <tr align="right">
                                <td class="TableColumns" style="width: 15%; text-align: right">
                                    Signatory ID :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_ID_DISPLAY" runat="server" Text='<%# Bind("ID") %>' Width="95%"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="TableColumns" style="width: 15%; text-align: right">
                                    Name :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_SIGNATORY_NAME_DISPLAY" runat="server" Text='<%# Bind("REAL_NAME") %>'
                                        Width="95%"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="TableColumns" style="width: 15%; text-align: right">
                                    Status :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_CURRENT_STATUS_DISPLAY" runat="server" Text='<%# Bind("CURRENT_STATUS_DISPLAY") %>'
                                        Width="95%"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="TableColumns" style="width: 15%; text-align: right">
                                    Image File Name :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_UPLOAD_IMAGE_PATH_DISPLAY" runat="server" Text='<%# Bind("UPLOAD_IMAGE_PATH") %>'
                                        Width="95%"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="TableColumns" style="width: 15%; text-align: right">
                                    Image :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Image ID="DispayImage" runat="server" BorderColor="GradientInactiveCaption"
                                        ImageUrl='<%# bind("PreviewImage") %>' Width="80px" />
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
                                    Edit by :&nbsp;
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
                                    &nbsp;<asp:Label ID="TXT_A_userID_DISPLAY" runat="server" Text='<%# Bind("AUTHORIZER") %>'
                                        Width="95%"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="ColLines1" style="width: 15%; text-align: right">
                                    Edit At :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_E_DateTime_DISPLAY" runat="server" Text='<%# Bind("E_DateTime") %>'
                                        Width="95%"></asp:Label>
                                </td>
                            </tr>
                            <tr align="right">
                                <td class="TableColumns" style="width: 15%; text-align: right">
                                    Authorized At :&nbsp;
                                </td>
                                <td class="ColLines" style="width: 35%; text-align: left">
                                    &nbsp;<asp:Label ID="TXT_A_DateTime_DISPLAY" runat="server" Text='<%# Bind("AUTH_DT") %>'
                                        Width="95%"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="Label_HEAD" runat="server" Font-Names="Trebuchet MS" Font-Size="18pt"
                            SkinID="FormViewHeading" Text="Signatory Setup" Width="100%"></asp:Label>
                    </HeaderTemplate>
                </asp:FormView>
            </td>
        </tr>
    </table>
    <table cellspacing="0" class="loginDown" width="100%">
        <tr>
            <td>
            </td>
        </tr>
    </table>
    <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Get_SPDS_SignatorySetup_SPC"
        TypeName="LOV_COLLECTION">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="ID" SessionField="SPDS_SignatorySetup_ID"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>
</asp:Content>
