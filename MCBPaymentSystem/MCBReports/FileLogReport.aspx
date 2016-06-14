<%@ Page Language="C#" Theme="ColorSchemeBlue" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true" CodeFile="FileLogReport.aspx.cs" Inherits="FileLogReport" Title="Untitled Page" %>
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
<asp:Label id="lbl_Heading" runat="server" Text="FILE LOG REPORT" Width="100%" SkinID="FormViewHeading" Font-Size="Large" CssClass="lblHeading"></asp:Label> 
<HR style="COLOR: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: center" class="TableColumns" colSpan=5><asp:Label id="lblmessage" runat="server" CssClass="lblMessage"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress> </TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" colSpan=2><asp:Label id="lblcompanynamedisplay" runat="server"></asp:Label> <asp:Label id="lblcompanycodedisplay" runat="server"></asp:Label>&nbsp; : </TD><TD style="TEXT-ALIGN: left" class="TableColumns" colSpan=1><asp:Label id="lblcompanyname" runat="server"></asp:Label> <asp:DropDownList id="ddlCompanyCode" runat="server" Width="300px">
            </asp:DropDownList></TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" width="10%" colSpan=1>Company&nbsp;Type :&nbsp;</TD><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: left" class="TableColumns" width="50%" colSpan=1><asp:DropDownList id="ddl_companytype" runat="server"><asp:ListItem>All</asp:ListItem>
<asp:ListItem Value="A">Agent</asp:ListItem>
<asp:ListItem Value="R">RDA</asp:ListItem>
<asp:ListItem Value="C">Corporate</asp:ListItem>
</asp:DropDownList> <asp:DropDownList id="DDL_TransType" runat="server" Width="320px" Visible="False"><asp:ListItem Value="NULL">ALL</asp:ListItem>
<asp:ListItem Value="DD">Instrument</asp:ListItem>
<asp:ListItem Value="PRI">Other Banks</asp:ListItem>
<asp:ListItem Value="COC">Cash Over Counter</asp:ListItem>
<asp:ListItem Value="A2A">Account To Account</asp:ListItem>
</asp:DropDownList></TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 20%; TEXT-ALIGN: right" class="TableColumns" colSpan=2>From Date : </TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1><asp:TextBox id="TXT_FROM" runat="server" Width="100px" MaxLength="50"></asp:TextBox> <asp:RequiredFieldValidator id="RFV_TXTFROM" runat="server" Enabled="False" ErrorMessage="*" ControlToValidate="TXT_FROM" ValidationGroup="GP"></asp:RequiredFieldValidator>&nbsp; <cc1:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="TXT_FROM" PopupButtonID="TXT_FROM" Format="dd/MM/yyyy"></cc1:CalendarExtender></TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" colSpan=1>To Date : </TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1><asp:TextBox id="TXT_TO" runat="server" Width="100px" MaxLength="50"></asp:TextBox> <asp:RequiredFieldValidator id="RFV_TXTTO" runat="server" Enabled="False" ErrorMessage="*" ControlToValidate="TXT_TO" ValidationGroup="GP"></asp:RequiredFieldValidator> <cc1:CalendarExtender id="CalendarExtender2" runat="server" TargetControlID="TXT_TO" PopupButtonID="TXT_TO" Format="dd/MM/yyyy"></cc1:CalendarExtender></TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; COLOR: red; HEIGHT: 26px; TEXT-ALIGN: center" class="TableColumns" colSpan=5><asp:Button id="btn_OK" onclick="btn_OK_Click" runat="server" Text="Search" Width="78px" ValidationGroup="GP" Font-Bold="True"></asp:Button></TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE>
</contenttemplate>
                <Triggers>
                <asp:PostBackTrigger ControlID="btn_OK" />
                </Triggers>
                </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

