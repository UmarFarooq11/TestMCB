<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="DepositReport.aspx.cs" Inherits="DepositReport" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
       

function CorrLOV()
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../../LOV/LOV_Correspondent.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
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
                            <table class="air1" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="width: 1%">
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_Heading" runat="server" Text="RECEIVE REPORT" Width="100%" SkinID="FormViewHeading"
                                                Font-Size="Large" CssClass="lblHeading"></asp:Label>
                                        </td>
                                        <td style="width: 1%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <hr style="color: darkgray" />
                                            <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                                <tbody>
                                                    <tr align="right">
                                                        <td style="font-weight: bold; color: red; text-align: center" colspan="5">
                                                            <asp:Label ID="lblmessage" runat="server" CssClass="lblMessage"></asp:Label>
                                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                                <ProgressTemplate>
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                    </tr>
                                                    <tr align="right">
                                                        <td style="font-weight: bold; text-align: center" class="TableColumns" colspan="5">
                                                            <asp:Label ID="lbl_Message" runat="server" __designer:wfdid="w1"></asp:Label></td>
                                                    </tr>
                                                    <tr align="right">
                                                        <td style="font-weight: bold; text-align: right" class="TableColumns" colspan="2">
                                                            Company&nbsp; :
                                                        </td>
                                                        <td style="text-align: left" class="ColLines" colspan="1">
                                                            <asp:DropDownList ID="ddlCompanyCode" runat="server" Width="300px">
                                                            </asp:DropDownList></td>
                                                        <td style="font-weight: bold; text-align: right" class="TableColumns" width="10%"
                                                            colspan="1">
                                                            Transaction Type :</td>
                                                        <td style="font-weight: bold; color: red; text-align: left" class="ColLines" width="50%"
                                                            colspan="1">
                                                            <asp:DropDownList ID="DDL_TransType" runat="server" Width="320px">
                                                                <asp:ListItem Value="">ALL</asp:ListItem>
                                                                <asp:ListItem Value="DD">Instrument</asp:ListItem>
                                                                <asp:ListItem Value="PRI">Other Banks</asp:ListItem>
                                                                <asp:ListItem Value="COC">Cash Over Counter</asp:ListItem>
                                                                <asp:ListItem Value="A2A">Account To Account</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr align="right">
                                                        <td style="font-weight: bold; width: 20%; text-align: right" class="TableColumns"
                                                            colspan="2">
                                                            From Date :
                                                        </td>
                                                        <td style="font-weight: bold; width: 30%; color: red; text-align: left" class="ColLines"
                                                            colspan="1">
                                                            <asp:TextBox ID="TXT_FROM" runat="server" Width="100px" MaxLength="50"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RFV_TXTFROM" runat="server" Enabled="False" ErrorMessage="*"
                                                                ControlToValidate="TXT_FROM" ValidationGroup="GP"></asp:RequiredFieldValidator><cc1:CalendarExtender
                                                                    ID="CalendarExtender1" runat="server" TargetControlID="TXT_FROM" PopupButtonID="TXT_FROM"
                                                                    Format="dd/MM/yyyy">
                                                                </cc1:CalendarExtender>
                                                        </td>
                                                        <td style="font-weight: bold; text-align: right" class="TableColumns" colspan="1">
                                                            To Date :
                                                        </td>
                                                        <td style="font-weight: bold; width: 30%; color: red; text-align: left" class="ColLines"
                                                            colspan="1">
                                                            <asp:TextBox ID="TXT_TO" runat="server" Width="100px" MaxLength="50"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RFV_TXTTO" runat="server" Enabled="False" ErrorMessage="*"
                                                                ControlToValidate="TXT_TO" ValidationGroup="GP"></asp:RequiredFieldValidator><cc1:CalendarExtender
                                                                    ID="CalendarExtender2" runat="server" TargetControlID="TXT_TO" PopupButtonID="TXT_TO"
                                                                    Format="dd/MM/yyyy">
                                                                </cc1:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                    <tr align="right">
                                                        <td style="font-weight: bold; width: 20%; height: 15px; text-align: right" class="TableColumns"
                                                            colspan="2">
                                                            Business Nature&nbsp;</td>
                                                        <td style="font-weight: bold; width: 30%; color: red; height: 15px; text-align: left"
                                                            class="ColLines" colspan="1">
                                                            <asp:DropDownList ID="ddl_BusinessNature" runat="server">
                                                            </asp:DropDownList></td>
                                                        <td style="font-weight: bold; height: 15px; text-align: right" class="TableColumns"
                                                            colspan="1">
                                                        </td>
                                                        <td style="font-weight: bold; width: 30%; color: red; height: 15px; text-align: left"
                                                            class="ColLines" colspan="1">
                                                        </td>
                                                    </tr>
                                                    <tr align="right">
                                                        <td style="font-weight: bold; color: red; height: 26px; text-align: center" colspan="5">
                                                            <asp:Button ID="btn_OK" OnClick="btn_OK_Click" runat="server" Text="Search" Width="78px"
                                                                Visible="false" ValidationGroup="GP" Font-Bold="True"></asp:Button>&nbsp;<asp:Button
                                                                    ID="btnExcel" Visible="false" OnClick="btnExcel_Click" runat="server" Text="Export To Excel"
                                                                    Font-Bold="True"></asp:Button></td>
                                                    </tr>
                                                    <tr align="right">
                                                    </tr>
                                                    <tr align="right">
                                                    </tr>
                                                </tbody>
                                            </table>
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
