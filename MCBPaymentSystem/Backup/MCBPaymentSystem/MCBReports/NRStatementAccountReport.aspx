<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true" CodeFile="NRStatementAccountReport.aspx.cs" Inherits="NRStatementAccountReport" Title="Untitled Page" %>
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
<asp:Label id="lbl_Heading" runat="server" Text="NR Statement Account" Width="100%" SkinID="FormViewHeading" Font-Size="Large" CssClass="lblHeading"></asp:Label> <asp:Button id="btn_OK" onclick="btn_OK_Click" runat="server" Text="Generate" Width="78px" ValidationGroup="GP" Font-Bold="True"></asp:Button> 
<HR style="COLOR: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: center" class="TableColumns" colSpan=5><asp:Label id="lblmessage" runat="server" CssClass="lblMessage"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress> </TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" colSpan=2><asp:Label id="lblcompanynamedisplay" runat="server"></asp:Label> <asp:Label id="lblcompanycodedisplay" runat="server"></asp:Label> :&nbsp; </TD><TD style="TEXT-ALIGN: left" class="ColLines" colSpan=1>&nbsp;<asp:Label id="lblcompanyname" runat="server"></asp:Label><asp:DropDownList id="ddlCompanyCode" runat="server" Width="300px">
            </asp:DropDownList></TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" class="TableColumns" width="10%" colSpan=1>Date :&nbsp; </TD><TD style="FONT-WEIGHT: bold; COLOR: red; TEXT-ALIGN: left" class="ColLines" width="50%" colSpan=1><asp:TextBox id="txtDate" runat="server" Width="100px" MaxLength="12"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="GP" Enabled="False" ErrorMessage="*" ControlToValidate="txtDate"></asp:RequiredFieldValidator><cc1:CalendarExtender id="CalendarExtender2" runat="server" TargetControlID="txtDate" PopupButtonID="txtDate" Format="dd-MM-yyyy"></cc1:CalendarExtender></TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 20%; TEXT-ALIGN: right" colSpan=2></TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" colSpan=1>&nbsp;&nbsp; </TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" colSpan=1>&nbsp;</TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" colSpan=1>&nbsp;&nbsp; </TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 20%; TEXT-ALIGN: right" colSpan=2></TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" colSpan=1></TD><TD style="FONT-WEIGHT: bold; TEXT-ALIGN: right" colSpan=1></TD><TD style="FONT-WEIGHT: bold; WIDTH: 30%; COLOR: red; TEXT-ALIGN: left" colSpan=1>&nbsp;</TD></TR><TR align=right><TD style="FONT-WEIGHT: bold; COLOR: red; HEIGHT: 26px; TEXT-ALIGN: center" colSpan=5></TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

