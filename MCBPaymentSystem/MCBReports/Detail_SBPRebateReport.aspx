<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true" CodeFile="Detail_SBPRebateReport.aspx.cs" Inherits="Detail_SBPRebateReport" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                    <asp:ScriptManager id="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<asp:Label id="lbl_Heading" runat="server" Text="Detail of SBP Rebate" Width="100%" SkinID="FormViewHeading" Font-Size="Large" CssClass="lblHeading"></asp:Label> <asp:Button id="btn_OK" onclick="btn_OK_Click" runat="server" Text="Generate" Width="78px" ValidationGroup="GP" Font-Bold="True"></asp:Button> 
<HR style="COLOR: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: center" class="TableColumns" colSpan=5><asp:Label id="lblmessage" runat="server" CssClass="lblMessage"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress> </TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 20%; TEXT-ALIGN: right" class="TableColumns" colSpan=2>
            Company Name :</TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1>&nbsp;<asp:DropDownList ID="ddlCompanyCode" runat="server" SkinID="TXT" Width="239px">
            </asp:DropDownList></TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" colSpan=1>
                </TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1>&nbsp;</TD></TR>
    <tr align="right">
        <td class="TableColumns" colspan="2" style="font-weight: bold; width: 20%; text-align: right">
            From Date :</td>
        <td class="TableColumns" colspan="1" style="font-weight: bold; width: 30%; color: black;
            text-align: left">
            &nbsp;<asp:TextBox ID="TXT_FROM" runat="server" MaxLength="50" Width="100px"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_FROM" Enabled="False"
                ErrorMessage="*" ValidationGroup="GP"></asp:RequiredFieldValidator>
            &nbsp;&nbsp; (DD-MON-YYYY)
            <cc1:CalendarExtender
                    ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" PopupButtonID="TXT_FROM"
                    TargetControlID="TXT_FROM">
                </cc1:CalendarExtender>
        </td>
        <td class="TableColumns" colspan="1" style="font-weight: bold; text-align: right">
            To Date :</td>
        <td class="TableColumns" colspan="1" style="font-weight: bold; width: 30%; color: black;
            text-align: left">
            &nbsp;<asp:TextBox ID="TXT_TO" runat="server" MaxLength="50" Width="100px"></asp:TextBox><asp:RequiredFieldValidator
                ID="RFV_TXTTO" runat="server" ControlToValidate="TXT_TO" Enabled="False" ErrorMessage="*"
                ValidationGroup="GP"></asp:RequiredFieldValidator>
            &nbsp;&nbsp; (DD-MON-YYYY)
            <cc1:CalendarExtender ID="CalendarExtender3"
                    runat="server" Format="dd-MMM-yyyy" PopupButtonID="TXT_TO" TargetControlID="TXT_TO">
                </cc1:CalendarExtender>
        </td>
    </tr>
    <tr align="right">
        <td class="TableColumns" colspan="2" style="font-weight: bold; width: 20%; text-align: right">
            Saudi Riyal :</td>
        <td class="TableColumns" colspan="1" style="font-weight: bold; width: 30%; color: red;
            text-align: left">
            &nbsp;<asp:TextBox ID="txt_FC_SaudiRiyal" runat="server" MaxLength="50" Width="100px"></asp:TextBox></td>
        <td class="TableColumns" colspan="1" style="font-weight: bold; text-align: right">
            US Rate :</td>
        <td class="TableColumns" colspan="1" style="font-weight: bold; width: 30%; color: red;
            text-align: left">
            &nbsp;<asp:TextBox ID="txt_UsRate" runat="server" MaxLength="50" Width="100px"></asp:TextBox></td>
    </tr>
    <TR align=right><TD style="FONT-WEIGHT: bold; COLOR: red; HEIGHT: 26px; TEXT-ALIGN: center" class="TableColumns" colSpan=5></TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

