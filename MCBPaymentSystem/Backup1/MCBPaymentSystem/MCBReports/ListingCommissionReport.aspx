<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true" CodeFile="ListingCommissionReport.aspx.cs" Inherits="ListingCommissionReport" Title="Untitled Page" %>
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
<asp:Label id="lbl_Heading" runat="server" CssClass="lblHeading" Font-Size="Large" SkinID="FormViewHeading" Width="100%" Text="M T - 950 "></asp:Label> <asp:Button id="btn_OK" onclick="btn_OK_Click" runat="server" Width="78px" Text="Generate" Font-Bold="True" ValidationGroup="GP"></asp:Button> 
<HR style="COLOR: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: center" class="TableColumns" colSpan=5><asp:Label id="lblmessage" runat="server" CssClass="lblMessage"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress> </TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" colSpan=2>Month&nbsp;: </TD><TD style="TEXT-ALIGN: left" class="TableColumns" colSpan=1>&nbsp;<asp:TextBox id="txtMonth" runat="server" Width="100px" MaxLength="12"></asp:TextBox> <asp:RequiredFieldValidator id="RFV_TXTDate" runat="server" ValidationGroup="GP" ControlToValidate="txtMonth" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>&nbsp; <cc1:CalendarExtender id="CalendarExtender1" runat="server" Format="MM-yyyy" PopupButtonID="txtMonth" TargetControlID="txtMonth"></cc1:CalendarExtender> </TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" width="10%" colSpan=1></TD><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: left" class="TableColumns" width="50%" colSpan=1></TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 20%; TEXT-ALIGN: right" class="TableColumns" colSpan=2></TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1>&nbsp;&nbsp; </TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" colSpan=1>&nbsp;</TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1>&nbsp;&nbsp; </TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 20%; TEXT-ALIGN: right" class="TableColumns" colSpan=2></TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1></TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" colSpan=1></TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1>&nbsp;</TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; COLOR: red; HEIGHT: 26px; TEXT-ALIGN: center" class="TableColumns" colSpan=5></TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

