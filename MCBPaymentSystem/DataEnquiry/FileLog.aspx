<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="FileLog.aspx.cs" Inherits="FileLog" Title="MCB -Account Enquiry" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
<table cellspacing="0" class="air1" width="100%">
        <tr>
            <td style="width: 1%">
            </td>
            <td>
<asp:Label id="Label1" runat="server" Font-Size="Large" Text="File Log" Width="100%" SkinID="FormViewHeading">
</asp:Label>
 </td>
            <td style="width: 1%">
            </td>
        </tr>
        <tr>
            <td colspan="3">
             <hr style="color: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%">
<TBODY>
<TR align=right>
<TD style="FONT-WEIGHT: bold; WIDTH: 15%; COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2>&nbsp;
<asp:Label id="lblMessage" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
<asp:UpdateProgress id="UpdateProgress1" runat="server">
<ProgressTemplate>
<asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
</ProgressTemplate>
</asp:UpdateProgress>
</TD>
</TR>
<TR align=right></TR>
<TR align=right></TR>
</TBODY>
</TABLE>
<TABLE style="WIDTH: 100%" class="air1">
<TBODY>
<TR>
<TD style="TEXT-ALIGN: center" class="ColLines1" colSpan=4>&nbsp; &nbsp; &nbsp;&nbsp;
 <asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" Width="100px" Font-Bold="true" ValidationGroup="search" CssClass="btnSearch"></asp:Button>
  <asp:Button id="btnPrint" runat="server" Text="Print" Width="100px" Font-Bold="true" CssClass="btnSearch">
  </asp:Button> &nbsp;</TD></TR><TR><TD colSpan=4><DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 350px"><asp:GridView id="GridView1" runat="server" SkinID="GV6" PageSize="5" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" OnPageIndexChanging="GridView1_PageIndexChanging" __designer:wfdid="w1"><Columns>
<asp:BoundField DataField="company_code" HeaderText="Company Code" SortExpression="company_code"></asp:BoundField>
<asp:BoundField DataField="company_name" HeaderText="Company Name" SortExpression="company_name"></asp:BoundField>
<asp:BoundField DataField="conf_id" HeaderText="Config ID" SortExpression="conf_id"></asp:BoundField>
<asp:BoundField DataField="conf_def_desc" HeaderText="Description" SortExpression="conf_def_desc"></asp:BoundField>
<asp:BoundField DataField="file_name" HeaderText="File Name" SortExpression="file_name"></asp:BoundField>
<asp:BoundField DataField="userid" HeaderText="User ID" SortExpression="userid"></asp:BoundField>
<asp:BoundField DataField="load_date" HeaderText="Load Date" SortExpression="load_date"></asp:BoundField>
<asp:BoundField DataField="total_records" HeaderText="Total Records" SortExpression="total_records"></asp:BoundField>
<asp:BoundField DataField="publish" HeaderText="Publish" SortExpression="publish"></asp:BoundField>
<asp:BoundField DataField="publish_userid" HeaderText="Publish Users ID" SortExpression="publish_userid"></asp:BoundField>
</Columns>
</asp:GridView></DIV></TD></TR><TR>
<TD class="tdCenter" colSpan=4></TD>
</TR><TR>
<TD class="tdRight" colSpan=4>&nbsp;</TD>
</TR>
</TBODY></TABLE>
<hr style="color: gainsboro" />
</TD></TR></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
