<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="AccountEnquiry.aspx.cs" Inherits="AccountEnquiry" Title="MCB -Account Enquiry" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script src="../Script/Script.js" type= "text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
<!--
function onPrint() 
{
    //open new window set the height and width =0,set windows position at bottom
    var a = window.open ('','','left =' + screen.width + ',top=' + screen.height + ',width=0,height=0,toolbar=0,scrollbars=0,status=0');
    //write gridview data into newly open window
    a.document.write(document.getElementById('<%= GridView1.ClientID %>').innerHTML);
    a.document.close();
    a.focus();
    //call print
    a.print();
    a.close();
    return false;
}
// -->
    </script>

    <script language="javascript" type="text/javascript">
//function BankLOV(rowIndex,hiddenfield) 
//{
//    var a;
//    var c='<%= Session["HEIGHT"] %>';
//    var b='<%= Session["WIDTH"] %>';
//    a=window.showModalDialog('../LOV/LOV_SETUP_Bank.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
//}

function AGENTLOV() 
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_Company.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function funConfirm()
{
    var a = confirm('Are you sure to Execute?');
    if (a == true)
    {
        return true;
    }
    else
    {
        return false;
    }
}
   
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <contenttemplate>
<TABLE cellSpacing=0 width="100%"><TBODY><TR><TD style="TEXT-ALIGN: left"><asp:Label id="Label1" runat="server" Font-Size="Large" Text="Data Enquiry" Width="100%" SkinID="FormViewHeading"></asp:Label><BR /><TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD></TD></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 15%; COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2>&nbsp;<asp:Label id="lblMessage" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label><asp:UpdateProgress id="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress> </TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE><TABLE style="WIDTH: 100%" class="air"><TBODY><TR><TD style="TEXT-ALIGN: center" class="ColLines1" colSpan=4><asp:RadioButton id="rbAccountEnquiry" runat="server" Text="Account Enquiry" GroupName="group" OnCheckedChanged="rbAccountEnquiry_CheckedChanged" AutoPostBack="true"></asp:RadioButton>&nbsp;&nbsp; <asp:RadioButton id="rbBranchEnquiry" runat="server" Text="Branch Enquiry" GroupName="group" OnCheckedChanged="rbBranchEnquiry_CheckedChanged" AutoPostBack="true">
                                                         </asp:RadioButton></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=4><asp:Panel id="span1" runat="server" Width="100%"><TABLE style="TEXT-ALIGN: center" class="table_center" width="700%"><TBODY><TR><TD style="TEXT-ALIGN: right" class="TableColumns" width="40%">Account No.&nbsp;:&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines1"><asp:TextBox id="txtAccountNo" runat="server" SkinID="TXT"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">Customer CNIC :&nbsp; </TD><TD style="TEXT-ALIGN: left" class="ColLines1"><asp:TextBox id="txtCNIC" runat="server" SkinID="TXT"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">Account Title&nbsp;:&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines1"><asp:TextBox id="txtAccountTitle" runat="server" SkinID="TXT"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">Branch Code :&nbsp; </TD><TD style="TEXT-ALIGN: left" class="ColLines1"><asp:TextBox id="txtBranchCode" runat="server" SkinID="TXT"></asp:TextBox>&nbsp; </TD></TR></TBODY></TABLE></asp:Panel> <asp:Panel id="span2" runat="server" Width="100%"><TABLE class="table_center" width="700%"><TBODY><TR><TD style="TEXT-ALIGN: right" class="TableColumns" width="40%">Branch / Location Name&nbsp;:&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines1"><asp:TextBox id="txtBrLocation" runat="server" SkinID="TXT"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">City&nbsp;:&nbsp; </TD><TD style="TEXT-ALIGN: left" class="ColLines1"><asp:TextBox id="txtCity" runat="server" SkinID="TXT"></asp:TextBox></TD></TR></TBODY></TABLE></asp:Panel></TD></TR><TR><TD style="TEXT-ALIGN: center" class="ColLines1" colSpan=4><asp:Label id="lblRecord" runat="server" Width="130px"></asp:Label></TD></TR><TR><TD style="TEXT-ALIGN: center" class="ColLines1" width="40%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD><TD style="TEXT-ALIGN: left" class="ColLines1" colSpan=1><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" Width="100px" Font-Bold="true" __designer:wfdid="w1" ValidationGroup="search" CssClass="btnSearch"></asp:Button>&nbsp; <asp:Button id="btnPrint" runat="server" Text="Print" Width="100px" Font-Bold="true" __designer:wfdid="w2" CssClass="btnSearch"></asp:Button></TD></TR><TR><TD colSpan=4><DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 580px" id="Print_All"><asp:GridView id="GridView1" runat="server" Width="100%" SkinID="DATAENQ" PageSize="20" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" EmptyDataText="No data found">
<PagerSettings FirstPageText="" LastPageText="" NextPageText=""></PagerSettings>

<FooterStyle CssClass="gridFooterStyle"></FooterStyle>

<PagerStyle HorizontalAlign="Left" Wrap="True" CssClass="gridPagerStyle"></PagerStyle>

<HeaderStyle CssClass="gridHeaderStyle"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR><TR><TD class="tdCenter" colSpan=4></TD></TR><TR><TD class="tdRight" colSpan=4>&nbsp;</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
