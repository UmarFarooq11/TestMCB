<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="Receive_WhoReport.aspx.cs" Inherits="Receive_WhoReport" Title="Untitled Page" %>

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
//       function FILENAME() 
//    {

//        var a;
//        var c='<%= Session["HEIGHT"] %>';
//        var b='<%= Session["WIDTH"] %>';
//        a=window.showModalDialog('../LOV/LOV_FILENAME.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
//    }
   function beneaddress()
    {

        var a;
        var c='<%= Session["HEIGHT"] %>';
        var b='<%= Session["WIDTH"] %>';
        a=window.showModalDialog('../LOV/LOV_beneaddress.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
    }
    
   function REMENAME()
    {

        var a;
        var c='<%= Session["HEIGHT"] %>';
        var b='<%= Session["WIDTH"] %>';
        a=window.showModalDialog('../LOV/LOV_REMETTER_NAME.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
    }
    
     
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
                        <contenttemplate>
                            <asp:Label ID="lbl_Heading" runat="server" Text="RECEIVE - WHO REPORT" Width="100%"
                                SkinID="FormViewHeading" Font-Size="Large" CssClass="lblHeading"></asp:Label>
                            <hr style="color: darkgray" />
                            <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
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
                                    <td style="font-weight: bold; height: 15px; text-align: right" colspan="2">
                                    </td>
                                    <td style="height: 15px; text-align: left" colspan="1">
                                    </td>
                                    <td style="font-weight: bold; width: 94px; height: 15px; text-align: right" colspan="1">
                                    </td>
                                    <td style="font-weight: bold; color: red; height: 15px; text-align: left" width="50%"
                                        colspan="1">
                                    </td>
                                </tr>
                                <tr align="right">
                                    <td style="font-weight: bold; text-align: right" class="TableColumns" colspan="2">
                                        Activity Ref. No. :
                                    </td>
                                    <td style="font-weight: bold; width: 30%; color: red; height: 28px; text-align: left"
                                        class="ColLines" colspan="1">
                                        <%-- <asp:TextBox ID="txt_filename" runat="server" Width="200px"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ServiceMethod="ActivityRef" MinimumPrefixLength="2" CompletionInterval="100"
                                            EnableCaching="false" CompletionSetCount="10" TargetControlID="txt_filename"
                                            ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                        </cc1:AutoCompleteExtender>--%>
                                        <%--   <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                            <ContentTemplate>--%>
                                        <asp:TextBox ID="txt_filename" runat="server" Width="200px"></asp:TextBox>
                                        <asp:ImageButton ID="btnLov" runat="server" ImageUrl="~/Images/search_16x16.png"></asp:ImageButton>
                                        <%--    </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                    </td>
                                    <td style="font-weight: bold; text-align: right" class="TableColumns" colspan="1">
                                        Province :</td>
                                    <td style="font-weight: bold; width: 30%; color: red; height: 28px; text-align: left"
                                        class="ColLines" colspan="1">
                                        &nbsp;<asp:TextBox ID="txtBeneAddress" runat="server" Width="200px"></asp:TextBox>&nbsp;<asp:ImageButton
                                            ID="ImageButton1" runat="server" ImageUrl="~/Images/search_16x16.png"></asp:ImageButton></td>
                                </tr>
                                <tr align="right">
                                    <td style="font-weight: bold; width: 20%; height: 28px; text-align: right" class="TableColumns"
                                        colspan="2">
                                        District :</td>
                                    <td style="font-weight: bold; width: 30%; color: red; height: 28px; text-align: left"
                                        class="ColLines" colspan="1">
                                        &nbsp;<asp:TextBox ID="txtRemitterName" runat="server" Width="200px"></asp:TextBox>&nbsp;<asp:ImageButton
                                            ID="LOV_REMEADDRESS" runat="server" ImageUrl="~/Images/search_16x16.png"></asp:ImageButton></td>
                                    <td style="font-weight: bold; width: 94px; height: 28px; text-align: right" class="TableColumns"
                                        colspan="1">
                                    </td>
                                    <td style="font-weight: bold; width: 30%; color: red; height: 28px; text-align: left"
                                        colspan="1">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr align="right">
                                    <td style="font-weight: bold; text-align: right" class="TableColumns" colspan="2">
                                        From Date :
                                    </td>
                                    <td style="font-weight: bold; width: 30%; color: red; text-align: left" class="ColLines"
                                        colspan="1">
                                        &nbsp;<asp:TextBox ID="TXT_FROM" runat="server" Width="100px" MaxLength="50"></asp:TextBox>
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
                                        &nbsp;<asp:TextBox ID="TXT_TO" runat="server" Width="100px" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFV_TXTTO" runat="server" Enabled="False" ErrorMessage="*"
                                            ControlToValidate="TXT_TO" ValidationGroup="GP"></asp:RequiredFieldValidator><cc1:CalendarExtender
                                                ID="CalendarExtender2" runat="server" TargetControlID="TXT_TO" PopupButtonID="TXT_TO"
                                                Format="dd/MM/yyyy">
                                            </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr align="right">
                                    <td style="font-weight: bold; color: red; height: 26px; text-align: center" class="ColLines"
                                        colspan="5">
                                        <asp:Button ID="btn_OK" OnClick="btn_OK_Click" runat="server" Text="Fetch" Width="78px"
                                            ValidationGroup="GP" Visible="FALSE" Font-Bold="True"></asp:Button>&nbsp;<asp:Button
                                                ID="btnExcel" OnClick="btnExcel_Click" runat="server" Text="Export To Excel"
                                                Font-Bold="True"></asp:Button></td>
                                </tr>
                                <tr align="right">
                                </tr>
                                <tr align="right">
                                </tr>
                            </table>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
