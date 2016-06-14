<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="SBPRebateSummReport.aspx.cs" Inherits="SBPRebateSummReport" Title="Untitled Page" %>

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
                    <asp:ScriptManager id="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<asp:Label id="lbl_Heading" runat="server" CssClass="lblHeading" Font-Size="Large" SkinID="FormViewHeading" Width="100%" Text="SBP Rebate Summary"></asp:Label> <asp:Button id="btn_OK" onclick="btn_OK_Click" runat="server" Width="78px" Text="Generate" Font-Bold="True" ValidationGroup="GP"></asp:Button> 
<HR style="COLOR: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: center" class="TableColumns" colSpan=5><asp:Label id="lblmessage" runat="server" CssClass="lblMessage"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress> </TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 20%; TEXT-ALIGN: right" class="TableColumns" colSpan=2>Company Name :</TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1>&nbsp;<asp:DropDownList id="ddlCompanyCode" runat="server" SkinID="TXT" Width="239px">
            </asp:DropDownList></TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" colSpan=1></TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1></TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 20%; TEXT-ALIGN: right" class="TableColumns" colSpan=2>From Date : </TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: black; TEXT-ALIGN: left" class="TableColumns" colSpan=1>&nbsp;<asp:TextBox id="TXT_FROM" runat="server" Width="100px" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator id="RFV_TXTFROM" runat="server" ValidationGroup="GP" ControlToValidate="TXT_FROM" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>
                (DD-MM-YYYY)<cc1:CalendarExtender id="CalendarExtender2" runat="server" Format="dd-MM-yyyy" PopupButtonID="TXT_FROM" TargetControlID="TXT_FROM"></cc1:CalendarExtender></TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" colSpan=1>To Date :</TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: black; TEXT-ALIGN: left" class="TableColumns" colSpan=1>&nbsp;&nbsp;<asp:TextBox id="TXT_TO" runat="server" Width="100px" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator id="RFV_TXTTO" runat="server" ValidationGroup="GP" ControlToValidate="TXT_TO" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>
                (DD-MM-YYYY)<cc1:CalendarExtender id="CalendarExtender3" runat="server" Format="dd-MM-yyyy" PopupButtonID="TXT_TO" TargetControlID="TXT_TO"></cc1:CalendarExtender></TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 20%; TEXT-ALIGN: right" class="TableColumns" colSpan=2>Saudi Riyal :</TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1>&nbsp;<asp:TextBox id="txt_FC_SaudiRiyal" runat="server" Width="100px" MaxLength="50"></asp:TextBox></TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" colSpan=1>US Rate :</TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1>&nbsp;<asp:TextBox id="txt_UsRate" runat="server" Width="100px" MaxLength="50"></asp:TextBox></TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; COLOR: red; HEIGHT: 26px; TEXT-ALIGN: center" class="TableColumns" colSpan=5></TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
