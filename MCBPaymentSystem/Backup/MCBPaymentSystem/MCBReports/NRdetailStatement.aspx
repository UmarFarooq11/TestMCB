<%@ Page Language="C#" Theme="ColorSchemeBlue" MasterPageFile="~/MasterPage/RoutinePage.master"
    AutoEventWireup="true" CodeFile="NRdetailStatement.aspx.cs" Inherits="NRdetailStatement"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

    <script runat="server">

        protected void Page_Load(object sender, EventArgs e)
        {

        }
</script>

    <script language="javascript" type="text/javascript">
        //        function pageLoad(sender, args) 
        //        { 
        //              $("[id$=TXT_FROM]").datepicker({
        //              onSelect:function(){},
        //              dateFormat: 'dd/mm/yy'
        //              });
        //              
        //            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(
        //                function(sender, args) 
        //                {
        //              $("[id$=TXT_FROM]").datepicker({onSelect:function(){},dateFormat: 'dd/mm/yy'});
        //                });
        //                
        //                
        //                
        //                
        //                $("[id$=TXT_TO]").datepicker({
        //              onSelect:function(){},
        //              dateFormat: 'dd/mm/yy'
        //              });
        //              
        //            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(
        //                function(sender, args) 
        //                {
        //              $("[id$=TXT_TO]").datepicker({onSelect:function(){},dateFormat: 'dd/mm/yy'});
        //                });
        //                
        //                
        //                
        //        }


        function CorrLOV() {
            var a;
            var c = '<%= Session["HEIGHT"] %>';
            var b = '<%= Session["WIDTH"] %>';
            a = window.showModalDialog('../../LOV/LOV_Correspondent.aspx', null, 'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
        }

    </script>

    <div style="text-align: left">
        <table cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lbl_Heading" runat="server" Text="NR Detail Statement" Width="100%"
                                SkinID="FormViewHeading" Font-Size="Large" CssClass="lblHeading"></asp:Label>
                            <hr style="color:Gray" />
                            <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                <tbody>
                                    <tr align="right">
                                        <td style="font-weight: bold; color: red; text-align: center" class="TableColumns"
                                            colspan="4">
                                            <asp:Label ID="lblmessage" runat="server" CssClass="lblMessage"></asp:Label>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                <ProgressTemplate>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td style="font-weight: bold; text-align: right" class="TableColumns">
                                            &nbsp;</td>
                                        <td style="text-align: left" class="TableColumns" colspan="1">
                                            &nbsp;</td>
                                        <td style="font-weight: bold; text-align: right" class="TableColumns" width="10%"
                                            colspan="1">
                                            &nbsp;
                                        </td>
                                        <td style="font-weight: bold; color: red; text-align: left" class="TableColumns"
                                            width="50%" colspan="1">
                                            &nbsp;</td>
                                    </tr>
                                    <tr align="right">
                                        <td style="font-weight: bold; width: 20%; text-align: right" 
                                            class="TableColumns">
                                            From Date :
                                        </td>
                                        <td style="font-weight: bold; width: 30%; color: red; text-align: left" class="TableColumns"
                                            colspan="1">
                                            <asp:TextBox ID="TXT_FROM" runat="server" Width="100px" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_TXTFROM" runat="server" Enabled="False" ErrorMessage="*"
                                                ControlToValidate="TXT_FROM" ValidationGroup="GP"></asp:RequiredFieldValidator>&nbsp;
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TXT_FROM"
                                                PopupButtonID="TXT_FROM" Format="dd/MM/yyyy">
                                            </cc1:CalendarExtender>
                                        </td>
                                        <td style="font-weight: bold; text-align: right" class="TableColumns" colspan="1">
                                            To Date :
                                        </td>
                                        <td style="font-weight: bold; width: 30%; color: red; text-align: left" class="TableColumns"
                                            colspan="1">
                                            <asp:TextBox ID="TXT_TO" runat="server" Width="100px" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_TXTTO" runat="server" Enabled="False" ErrorMessage="*"
                                                ControlToValidate="TXT_TO" ValidationGroup="GP"></asp:RequiredFieldValidator>
                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TXT_TO"
                                                PopupButtonID="TXT_TO" Format="dd/MM/yyyy">
                                            </cc1:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td style="font-weight: bold; color: red; height: 26px; text-align: center" class="TableColumns"
                                            colspan="4">
                                            <asp:Button ID="btn_OK" OnClick="btn_OK_Click" runat="server" Text="Search" Width="78px"
                                                ValidationGroup="GP" Font-Bold="True"></asp:Button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btn_OK" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
