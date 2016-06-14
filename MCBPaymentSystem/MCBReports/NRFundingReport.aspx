<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="NRFundingReport.aspx.cs" Inherits="NRFundingReport" Title="NR Funding Report" %>

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
                            <asp:Label ID="lbl_Heading" runat="server" Text="NR Funding Report" Width="100%"
                                SkinID="FormViewHeading" Font-Size="Large" CssClass="lblHeading"></asp:Label>
                            <asp:Button ID="btn_OK" OnClick="btn_OK_Click" runat="server" Text="Generate" Width="78px"
                                ValidationGroup="GP" Font-Bold="True"></asp:Button>
                            <hr style="color: darkgray" />
                            <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                <tbody>
                                    <tr align="right">
                                        <td style="font-weight: bold; color: red; text-align: center" class="TableColumns"
                                            colspan="5">
                                            <asp:Label ID="lblmessage" runat="server" CssClass="lblMessage"></asp:Label>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                <ProgressTemplate>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td style="font-weight: bold; text-align: right" class="TableColumns" colspan="2">
                                            <asp:Label ID="lblcompanynamedisplay" runat="server"></asp:Label>
                                            <asp:Label ID="lblcompanycodedisplay" runat="server"></asp:Label>
                                            :&nbsp;
                                        </td>
                                        <td style="text-align: left" class="ColLines" colspan="1">
                                            &nbsp;<asp:Label ID="lblcompanyname" runat="server"></asp:Label><asp:DropDownList
                                                ID="ddlCompanyCode" runat="server" Width="300px">
                                            </asp:DropDownList></td>
                                        <td style="font-weight: bold; text-align: right" class="TableColumns" width="10%"
                                            colspan="1">
                                            Date :&nbsp;
                                        </td>
                                        <td style="font-weight: bold; color: Black; text-align: left" class="ColLines" width="50%"
                                            colspan="1">
                                            <asp:TextBox ID="txtDate" runat="server" Width="100px" MaxLength="12"></asp:TextBox><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator1" runat="server" ValidationGroup="GP" Enabled="False"
                                                ErrorMessage="*" ControlToValidate="txtDate"></asp:RequiredFieldValidator>&nbsp;
                                            (DD-MON-YYYY)<cc1:CalendarExtender
                                                    ID="CalendarExtender2" runat="server" TargetControlID="txtDate" PopupButtonID="txtDate"
                                                    Format="dd-MMM-yyyy">
                                                </cc1:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr align="right">
                                        <td style="font-weight: bold; color: red; height: 26px; text-align: center" colspan="5">
                                        </td>
                                    </tr>
                                    <tr align="right">
                                    </tr>
                                    <tr align="right">
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
