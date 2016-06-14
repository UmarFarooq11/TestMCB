<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="DemandDraftBranchWiseReport.aspx.cs" Inherits="DemandDraftBranchWiseReport"
    Title="Untitled Page" %>

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
<asp:Label id="lbl_Heading" runat="server" CssClass="lblHeading" Font-Size="Large" SkinID="FormViewHeading" Width="100%" Text="Demand Drafts - Branch Wise Summary"></asp:Label> 
<HR style="COLOR: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: center" class="TableColumns" colSpan=5><asp:Label id="lblmessage" runat="server" CssClass="lblMessage"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress> </TD></TR><TR align=right>
        <TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" colSpan=2><asp:Label id="lblcompanynamedisplay" runat="server"></asp:Label> <asp:Label id="lblcompanycodedisplay" runat="server"></asp:Label> : </TD><TD style="TEXT-ALIGN: left" class="TableColumns" colSpan=1><asp:Label id="lblcompanyname" runat="server"></asp:Label><asp:DropDownList id="ddlCompanyCode" runat="server" Width="300px">
            </asp:DropDownList></TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" width="10%" colSpan=1>Transaction Type :</TD><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: left" class="TableColumns" width="50%" colSpan=1><asp:DropDownList id="ddlcompany_type" runat="server" Width="204px"><asp:ListItem Value="C">Corporate</asp:ListItem>
<asp:ListItem Value="A">Agent</asp:ListItem>
<asp:ListItem Value="R">RDA</asp:ListItem>
</asp:DropDownList></TD></TR>
<TR align=right>
<TD style="FONT-WEIGHT: bold; WIDTH: 20%; TEXT-ALIGN: right" class="TableColumns" colSpan=2>From Date : </TD>
<TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1>
<asp:TextBox id="TXT_FROM" runat="server" Width="100px" MaxLength="50"></asp:TextBox> <asp:RequiredFieldValidator id="RFV_TXTFROM" runat="server" ControlToValidate="TXT_FROM" ErrorMessage="*" Enabled="False" ValidationGroup="GP"></asp:RequiredFieldValidator>&nbsp; <cc1:CalendarExtender id="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="TXT_FROM" TargetControlID="TXT_FROM"></cc1:CalendarExtender></TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" colSpan=1>To Date : </TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1><asp:TextBox id="TXT_TO" runat="server" Width="100px" MaxLength="50"></asp:TextBox> <asp:RequiredFieldValidator id="RFV_TXTTO" runat="server" ControlToValidate="TXT_TO" ErrorMessage="*" Enabled="False" ValidationGroup="GP"></asp:RequiredFieldValidator>&nbsp; <cc1:CalendarExtender id="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="TXT_TO" TargetControlID="TXT_TO"></cc1:CalendarExtender></TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 20%; TEXT-ALIGN: right" class="TableColumns" colSpan=2></TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1></TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" colSpan=1></TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" class="TableColumns" colSpan=1>&nbsp; </TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; COLOR: red; HEIGHT: 26px; TEXT-ALIGN: center" class="TableColumns" colSpan=5><asp:Button id="btn_OK" onclick="btn_OK_Click" runat="server" Width="78px" Text="Search" ValidationGroup="GP" Font-Bold="True"></asp:Button></TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
