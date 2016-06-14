<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="LoadDataUpdation.aspx.cs" Inherits="LoadDataUpdation" Title="MCB - Load Data Updation" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    function BankLOV(rowIndex,hiddenfield) 
    {
        document.getElementById('<%=hdRowIndex.ClientID %>').value=rowIndex;
        var a;
        var c='<%= Session["HEIGHT"] %>';
        var b='<%= Session["WIDTH"] %>';
        a=window.showModalDialog('../LOV/LOV_SETUP_BRANCH.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
    }
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
function OnConfirmGV()
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
function OnConfirmAuth()
{
    var a = confirm('Are you sure to Authorize?');
    if (a == true)
    {
        return true;
    }
    else
    {
        return false;
    }
}

function OnConf32342irmAuth()
    {
        return confirm('Are you sure you want to delete this entry?');
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
            <asp:Label id="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="Load Data Updation" Font-Size="Large" ToolTip="Load Data Updation"></asp:Label>

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
<asp:Label id="lblMessage" runat="server" ForeColor="Red" Font-Bold="True">
</asp:Label><asp:UpdateProgress id="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress> 
                                                        </TD>
 </TR>
                                                </TBODY>
                                                        </TABLE>
 <table class="air" cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%">
<TBODY>
<TR>
<TD style="WIDTH: 25%; TEXT-ALIGN: right" class="TableColumns">Agent :&nbsp; </TD>
<TD class="ColLines" colSpan=4><asp:DropDownList id="ddlCompanyCode" runat="server" Width="355px" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">File :&nbsp; </TD><TD class="ColLines"><asp:DropDownList id="ddlFile" runat="server" SkinID="TXT" Width="355px" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged" AutoPostBack="True" CssClass="dropdown"></asp:DropDownList> </TD><TD style="TEXT-ALIGN: right" class="ColLines1" colSpan=2><asp:Label id="lblTotalFile" runat="server" Text="File Total Records :"></asp:Label>&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblTotalRecord" runat="server"></asp:Label></TD></TR><TR><TD class="ColLines1">&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines"><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="100px" Text="Search" Font-Bold="True" CssClass="btnSearch" ValidationGroup="search"></asp:Button> <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Width="100px" Text="Submit" Font-Bold="True" CssClass="btnSearch"></asp:Button></TD><TD style="TEXT-ALIGN: right" class="ColLines1" colSpan=2>&nbsp;<asp:Label id="lblFieldTrans" runat="server" Width="130px" Text="No. of Transaction :"></asp:Label></TD><TD style="TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblTransaction" runat="server"></asp:Label>&nbsp;</TD></TR><TR><TD colSpan=5></TD></TR><TR><TD class="tdCenter" colSpan=5><asp:TextBox id="txtAgnetCode" runat="server" SkinID="TXT" Width="61px" Visible="False"></asp:TextBox><asp:ImageButton id="btnAgent" onclick="btnAgent_Click" runat="server" Visible="False" ImageUrl="~/images/search_16x16.png" OnClientClick="AGENTLOV();"></asp:ImageButton><asp:TextBox id="txtAgentName" runat="server" SkinID="TXT" Width="329px" Visible="False"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="search" Visible="False" Enabled="False" ErrorMessage="Proper Information Required" ControlToValidate="txtAgnetCode"></asp:RequiredFieldValidator></TD></TR><TR><TD class="tdRight" colSpan=5><asp:HiddenField id="hdRowIndex" runat="server"></asp:HiddenField> </TD></TR></TBODY></TABLE>
  <hr style="color: gainsboro" />
<asp:Panel id="Panel1" runat="server" Width="970px" Height="300px" ScrollBars="Both">
<asp:GridView id="GridView1" runat="server" Font-Size="8pt" SkinID="PSGV" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowSorting="True" OnRowCancelingEdit="GridView1_RowCancelingEdit" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" Font-Names="Verdana" PageSize="1000000" OnSorting="GridView1_Sorting" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous" Visible="False"></PagerSettings>
<Columns>
<asp:BoundField DataField="ROWID" HeaderText="Row ID">
<HeaderStyle CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TRANS_TYPE" HeaderText="Payment Mode" ReadOnly="True" SortExpression="TRANS_TYPE">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="bank_code" HeaderText="Bank Code" 
        SortExpression="bank_code"></asp:BoundField>
<asp:BoundField DataField="BANK" HeaderText="Bank Name" ReadOnly="True" SortExpression="BANK">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="branch_code" HeaderText="Branch Code" ReadOnly="True" SortExpression="branch_code"></asp:BoundField>
<asp:BoundField DataField="BRANCH_Name" HeaderText="Branch Name" ReadOnly="True" SortExpression="BRANCH_Name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="BENENAME" HeaderText="Beneficary Name" SortExpression="BENENAME">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="REMENAME" HeaderText="Remitter Name" ReadOnly="True" SortExpression="REMENAME">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CONTACTNUMBER" HeaderText="Contact No." ReadOnly="True" SortExpression="CONTACTNUMBER"></asp:BoundField>
<asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account No." SortExpression="ACCOUNTNUMBER"></asp:BoundField>
<asp:BoundField DataField="CNIC" HeaderText="CNIC" ReadOnly="True" SortExpression="CNIC"></asp:BoundField>
<asp:BoundField DataField="CUSTOMERREFERENCENUMBER" HeaderText="Reference #" ReadOnly="True" SortExpression="CUSTOMERREFERENCENUMBER"></asp:BoundField>
<asp:BoundField DataField="XPIN" HeaderText="XPIN" ReadOnly="True" SortExpression="XPIN"></asp:BoundField>
<asp:BoundField DataField="TRANSAMOUNT" HeaderText="Amount" ReadOnly="True" SortExpression="TRANSAMOUNT"></asp:BoundField>
<asp:BoundField DataField="auth_status" HeaderText="Transaction Status" ReadOnly="True" SortExpression="auth_status"></asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Action"></asp:CommandField>
<asp:CommandField SelectText="Authorize" ShowSelectButton="True" HeaderText="Action"></asp:CommandField>
</Columns>

<FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>

<PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:GridView>
</asp:Panel>

</TD>
</TR>
</TABLE>
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
