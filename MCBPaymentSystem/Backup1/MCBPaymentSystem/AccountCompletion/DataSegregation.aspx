<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="DataSegregation.aspx.cs" Inherits="DataSegregation" Title="MCB -Cash Payment" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
//function BankLOV(rowIndex,hiddenfield) 
//{
//    document.getElementById('<%=hdRowIndex.ClientID %>').value=rowIndex;
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
<TABLE class="air1" cellSpacing=0 width="100%"><TBODY>
<TR><TD style="WIDTH: 1%"></TD><TD>
<asp:Label id="Label1" runat="server" Font-Size="Large" Text="Data Segregation" Width="100%" SkinID="FormViewHeading"></asp:Label>
 </TD>
 <TD style="WIDTH: 1%">
 </TD>
 </TR>
 <TR><TD colSpan=3>
 <TABLE cellSpacing=0 width="100%">
 <TBODY><TR>
 <TD>
 </TD>
 <TD align=center>
 <asp:Label id="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
  
</TD>
<TD>
</TD>
</TR>
<TR>
<TD><asp:UpdateProgress id="UpdateProgress1" runat="server">
<ProgressTemplate>
<asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
</ProgressTemplate>
</asp:UpdateProgress>
</TD>
<TD>
<HR style="COLOR: darkgray" />
 <table class="air" cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%">
 <TBODY>
 <TR>
 <TD style="WIDTH: 25%; TEXT-ALIGN: right" class="TableColumns">Agent :&nbsp;</TD>
 <TD class="ColLines" colSpan=4><asp:DropDownList id="ddlCompanyCode" runat="server" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged"></asp:DropDownList>
 </TD>
 </TR>
 <TR>
 <TD style="TEXT-ALIGN: right" class="TableColumns">File :&nbsp;</TD>
 <TD class="ColLines">
 <asp:DropDownList id="ddlFile" runat="server" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged"></asp:DropDownList>
  </TD>
  <TD style="TEXT-ALIGN: right" class="ColLines1" colSpan=2>
  <asp:Label id="lblTotalFile" runat="server" Text="File Total Records :"></asp:Label>
  &nbsp;</TD>
  <TD style="TEXT-ALIGN: left" class="ColLines">
  <asp:Label id="lblTotalRecord" runat="server"></asp:Label> </TD>
  </TR><TR><TD class="ColLines1">&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines">
  <asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Fetch" Width="100px" Font-Bold="True" ValidationGroup="search" CssClass="btnSearch"></asp:Button> <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" Width="100px" Font-Bold="True" CssClass="btnSearch"></asp:Button> </TD><TD style="TEXT-ALIGN: right" class="ColLines1" colSpan=2>&nbsp;<asp:Label id="lblFieldTrans" runat="server" Text="No. of Transaction :" Width="130px"></asp:Label></TD><TD style="TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblTransaction" runat="server"></asp:Label>&nbsp;</TD></TR><TR><TD colSpan=5><DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 385px"><asp:GridView id="GridView1" runat="server" Width="100%" PageSize="5" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnSorting="GridView1_Sorting"><Columns>
<asp:BoundField DataField="ROWID" HeaderText="ROWID" SortExpression="ROWID">
<HeaderStyle CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TRANS_TYPE" HeaderText="Payment Mode" SortExpression="TRANS_TYPE"></asp:BoundField>
<asp:BoundField DataField="bank_code" HeaderText="Bank Code" SortExpression="bank_code"></asp:BoundField>
<asp:BoundField DataField="BANK" HeaderText="Bank Name" SortExpression="BANK"></asp:BoundField>
<asp:BoundField DataField="branch_code" HeaderText="Branch Code" SortExpression="branch_code"></asp:BoundField>
<asp:BoundField DataField="Branch_name" HeaderText="Branch Name" SortExpression="Branch_name"></asp:BoundField>
<asp:BoundField DataField="BENENAME" HeaderText="Beneficary Name" SortExpression="BENENAME"></asp:BoundField>
<asp:BoundField DataField="REMENAME" HeaderText="Remitter Name" SortExpression="REMENAME"></asp:BoundField>
<asp:BoundField DataField="CONTACTNUMBER" HeaderText="Contact No." SortExpression="CONTACTNUMBER"></asp:BoundField>
<asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account No" SortExpression="ACCOUNTNUMBER"></asp:BoundField>
<asp:BoundField DataField="CNIC" HeaderText="CNIC" SortExpression="CNIC"></asp:BoundField>
<asp:BoundField DataField="CUSTOMERREFERENCENUMBER" HeaderText="Reference#." SortExpression="CUSTOMERREFERENCENUMBER"></asp:BoundField>
<asp:BoundField DataField="XPIN" HeaderText="XPIN" SortExpression="XPIN"></asp:BoundField>
<asp:BoundField DataField="TRANSAMOUNT" HeaderText="Amount" SortExpression="TRANSAMOUNT"></asp:BoundField>
<asp:TemplateField HeaderText="Change To Payment Mode"><ItemTemplate>
<asp:DropDownList id="DDLCHANGETO" runat="server" Width="100px" __designer:wfdid="w18"><asp:ListItem>Select Mode</asp:ListItem>
<asp:ListItem>DD</asp:ListItem>
<asp:ListItem>A2A</asp:ListItem>
<asp:ListItem>COC</asp:ListItem>
<asp:ListItem>PRI</asp:ListItem>
<asp:ListItem>IBF</asp:ListItem>
</asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle CssClass="gridFooterStyle"></FooterStyle>

<HeaderStyle CssClass="gridHeaderStyle"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR><TR><TD class="tdCenter" colSpan=5><asp:TextBox id="txtagent" tabIndex=1 runat="server" Width="50px" SkinID="TXT" Visible="False" MaxLength="5"></asp:TextBox><asp:ImageButton id="btnCustomerCode" tabIndex=2 onclick="btnCustomerCode_Click" runat="server" CssClass="imagebtnlov" Visible="False" ImageUrl="~/images/search_16x16.png" OnClientClick="AGENTLOV();"></asp:ImageButton><asp:TextBox id="txtagentname" tabIndex=1 runat="server" Width="329px" SkinID="TXT" Visible="False" MaxLength="5"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="search" Enabled="False" EnableTheming="True" ControlToValidate="txtagent" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator></TD></TR><TR><TD class="tdRight" colSpan=5><asp:HiddenField id="hdRowIndex" runat="server"></asp:HiddenField> </TD></TR></TBODY></TABLE>
<HR style="COLOR: gainsboro" />
</TD><TD></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
