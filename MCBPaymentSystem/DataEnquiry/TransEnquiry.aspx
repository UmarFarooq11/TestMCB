<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
   EnableEventValidation="false" CodeFile="TransEnquiry.aspx.cs" Inherits="TransEnquiry" Title="MCB -Transaction Enquiry" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../Script/Script.js" type="text/javascript" language="javascript"></script>
<script language="javascript" type="text/javascript">
    var oldgridSelectedColor;
    function setMouseOverColor(element) 
    {
        oldgridSelectedColor = element.style.backgroundColor;
        //element.style.backgroundColor='yellow';
        element.style.cursor='hand';
        element.style.textDecoration='underline';
    }
    function setMouseOutColor(element) 
    {
        element.style.backgroundColor=oldgridSelectedColor;
        element.style.textDecoration='none';
    }
    </script>
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
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <contenttemplate>
<TABLE cellSpacing=0 width="100%"><TBODY><TR><TD style="TEXT-ALIGN: left"><asp:Label id="Label1" runat="server" Font-Size="Large" Text="Transaction Enquiry" Width="100%" SkinID="FormViewHeading"></asp:Label> <TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 15%; COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2><asp:Label id="lblMessage" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label><asp:UpdateProgress id="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress> </TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE><TABLE style="WIDTH: 100%" class="air1"><TBODY><TR><TD style="TEXT-ALIGN: right" class="TableColumns" width="40%">Draft / XPin No.&nbsp;:&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines1" colSpan=1><asp:TextBox id="txtDraftNo" runat="server" SkinID="TXT" __designer:wfdid="w1"></asp:TextBox> </TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns" width="40%">Customer&nbsp;Reference No.&nbsp;:&nbsp; </TD><TD style="TEXT-ALIGN: left" class="ColLines1" colSpan=1><asp:TextBox id="txtCustomerRef" runat="server" SkinID="TXT" __designer:wfdid="w2"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns" width="40%">Account No. :&nbsp; </TD><TD style="TEXT-ALIGN: left" class="ColLines1" colSpan=1><asp:TextBox id="txtAccountNo" runat="server" SkinID="TXT" __designer:wfdid="w6"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: right" class="ColLines1" width="40%">&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines1" colSpan=1><asp:Label id="lblRecord" runat="server" Width="130px" __designer:wfdid="w13"></asp:Label> </TD></TR><TR><TD style="TEXT-ALIGN: center" class="ColLines1" width="40%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD><TD style="TEXT-ALIGN: left" class="ColLines1" colSpan=1><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" Width="100px" Font-Bold="true" __designer:wfdid="w1" CssClass="btnSearch"></asp:Button>&nbsp; <asp:Button id="btnPrint" runat="server" Text="Print" Width="100px" Font-Bold="true" __designer:wfdid="w2" CssClass="btnSearch"></asp:Button></TD></TR><TR><TD colSpan=4><DIV style="OVERFLOW: auto; WIDTH: 970px; HEIGHT: 180px" id="Print_All"><asp:GridView id="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" PageSize="20" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" OnPageIndexChanging="GridView1_PageIndexChanging" EmptyDataText="No data found">
<PagerSettings FirstPageText="" LastPageText="" NextPageText=""></PagerSettings>
<Columns>
<asp:BoundField DataField="company_code" HeaderText="Company Code"></asp:BoundField>
<asp:BoundField DataField="company_name" HeaderText="Company Name">
<HeaderStyle Wrap="False" Width="100%"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False" Width="100%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="draftno" HeaderText="Draft /XPin No.">
<HeaderStyle Wrap="False"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="draftamount" HeaderText="Amount"></asp:BoundField>
<asp:BoundField DataField="trans_no" HeaderText="Trans. No."></asp:BoundField>
<asp:BoundField DataField="draftdate" HeaderText="Transaction Date">
<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CUSTREFNUMBER" HeaderText="Customer Ref #">
<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="E_DATETIME" HeaderText="Payment Date">
<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="trans_type" HeaderText="Trans Type">
<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="transfer_method" HeaderText="Transfer Method">
<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="bene_name" HeaderText="Beneficiary Name">
<ItemStyle VerticalAlign="Top" Wrap="False" Width="100%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="bene_address" HeaderText="Beneficiary Address">
<ItemStyle VerticalAlign="Top" Wrap="False" Width="100%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACCOUNTNO" HeaderText="Account No.">
<ItemStyle VerticalAlign="Top" Wrap="False" Width="100%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="NICNO" HeaderText="CNIC">
<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PHONENO" HeaderText="Contact No.">
<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="paybranchid" HeaderText="Payee Branch"></asp:BoundField>
<asp:BoundField DataField="correspondingbankid" HeaderText="Bank Code">
<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="bank_name" HeaderText="Bank Name">
<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="branchid" HeaderText="Branch Code">
<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="branch_name" HeaderText="Branch Name">
<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="rem_name" HeaderText="Remitter Name">
<ItemStyle VerticalAlign="Top" Wrap="False" Width="100%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="STATUS" HeaderText="Status">
<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="canceldate" HeaderText="Cancel Date"></asp:BoundField>
<asp:BoundField DataField="remarks" HeaderText="Remarks">
<ItemStyle VerticalAlign="Top" Wrap="False" Width="100%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle CssClass="gridFooterStyle"></FooterStyle>

<PagerStyle HorizontalAlign="Left" Wrap="True" CssClass="gridPagerStyle"></PagerStyle>

<HeaderStyle CssClass="gridHeaderStyle"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView></DIV></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
