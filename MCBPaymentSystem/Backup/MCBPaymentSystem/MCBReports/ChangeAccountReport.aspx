<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true" CodeFile="ChangeAccountReport.aspx.cs" Inherits="ChangeAccountReport" Title="Untitled Page" %>
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
                        <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td style="width: 1%">
            </td>
            <td>
<asp:Label id="lbl_Heading" runat="server" Text="Bene Recon MIS" Width="100%" SkinID="FormViewHeading" Font-Size="Large" CssClass="lblHeading"></asp:Label> 

  </td>
            <td style="width: 1%">
            </td>
        </tr>
        <tr>
            <td colspan="3">
<HR style="COLOR: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: center" class="TableColumns" colSpan=5><asp:Label id="lblmessage" runat="server" CssClass="lblMessage"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress> </TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right; width: 120px; height: 24px;" class="TableColumns" colSpan=2>
            <asp:Label ID="lblcompanynamedisplay" runat="server"></asp:Label><asp:Label ID="lblcompanycodedisplay"
                runat="server"></asp:Label>:&nbsp; </TD><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: left; height: 24px;" class="ColLines" colSpan=3>
                <asp:Label id="lblcompanyname" runat="server"></asp:Label><asp:DropDownList id="ddlCompanyCode" runat="server" Width="300px"></asp:DropDownList></TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right; width: 120px;" class="TableColumns" colSpan=2>From&nbsp;Date&nbsp;:&nbsp; </TD><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: left" class="ColLines" colSpan=3><asp:TextBox id="txtFromDate" runat="server" Width="120px"></asp:TextBox> <cc1:CalendarExtender id="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate"></cc1:CalendarExtender> </TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right; width: 120px;" class="TableColumns" colSpan=2>To Date :&nbsp; </TD><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: left" class="ColLines" colSpan=3><asp:TextBox id="txtToDate" runat="server" Width="120px"></asp:TextBox> <cc1:CalendarExtender id="CalendarExtender2" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtToDate" TargetControlID="txtToDate"></cc1:CalendarExtender></TD></TR>
    <tr align="right">
        <td class="TableColumns" colspan="2" style="font-weight: bold; text-align: right; width: 120px;">
            Transaction Type :
        </td>
        <td class="ColLines" colspan="3" style="font-weight: bold; color: red; text-align: left">
            <asp:DropDownList ID="DDL_TransType" runat="server" Width="320px">
                <asp:ListItem Value="NULL">ALL</asp:ListItem>
                <asp:ListItem Value="DD">Instrument</asp:ListItem>
                <asp:ListItem Value="PRI">Other Banks</asp:ListItem>
                <asp:ListItem Value="COC">Cash Over Counter</asp:ListItem>
                <asp:ListItem Value="A2A">Account To Account</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <TR align=right><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right; width: 120px;" class="TableColumns" colSpan=2></TD><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: left" class="ColLines" colSpan=3><asp:Button id="btn_OK" onclick="btn_OK_Click" runat="server" Text="Search" Width="78px" Font-Bold="True" ValidationGroup="GP"></asp:Button></TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE>
 
  </td>
        </tr>
    </table>
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

