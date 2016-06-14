<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="DataUPDAfterPublish.aspx.cs" Inherits="DataUPDAfterPublish"
    Title="MCB - Load Data Updation (After Publish)" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
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
                    <ContentTemplate>
<TABLE cellSpacing=0 width="100%"><TBODY><TR><TD><asp:Label id="Label1" runat="server" ToolTip="Load Data Updation (After Publish)" Font-Size="Large" Text="Load Data Updation (After Publish)" Width="100%" SkinID="FormViewHeading"></asp:Label><BR /><TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD></TD></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 15%; COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2>&nbsp;<asp:Label id="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label><asp:UpdateProgress id="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress> </TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE><TABLE style="WIDTH: 100%" class="air1"><TBODY><TR><TD style="WIDTH: 40%; TEXT-ALIGN: right" class="TableColumns">Draft / XPin No.&nbsp;:&nbsp; </TD><TD class="ColLines" colSpan=4><asp:TextBox id="txtDraftNo" runat="server" SkinID="TXT" __designer:wfdid="w3"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">Customer&nbsp;Reference No.&nbsp;:&nbsp; </TD><TD class="ColLines" colSpan=4><asp:TextBox id="txtCustomerRef" runat="server" SkinID="TXT" __designer:wfdid="w8"></asp:TextBox>&nbsp;</TD></TR><TR><TD class="ColLines1"></TD><TD style="TEXT-ALIGN: left" class="ColLines" colSpan=4><asp:Label id="lblRecord" runat="server" Width="130px" __designer:wfdid="w5"></asp:Label></TD></TR><TR><TD class="ColLines1">&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines" colSpan=4><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" Width="100px" Font-Bold="True" __designer:wfdid="w9" ValidationGroup="search" CssClass="btnSearch"></asp:Button> <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" Width="100px" Font-Bold="True" __designer:wfdid="w10" CssClass="btnSearch" Visible="False"></asp:Button>&nbsp;&nbsp;</TD></TR><TR><TD colSpan=5></TD></TR></TBODY></TABLE><DIV style="OVERFLOW: auto; WIDTH: 970px; HEIGHT: 200px"><asp:GridView id="GridView1" runat="server" Font-Size="8pt" __designer:wfdid="w1" OnRowCancelingEdit="GridView1_RowCancelingEdit" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" Font-Names="Verdana" PageSize="1000000" OnSorting="GridView1_Sorting" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous" Visible="False"></PagerSettings>
<Columns>
<asp:BoundField DataField="ROWID" HeaderText="Row ID">
<HeaderStyle CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="company_code" HeaderText="Company Code" ReadOnly="True" SortExpression="company_code">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="company_name" HeaderText="Company Name" ReadOnly="True" SortExpression="company_name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False" Width="100%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="draftno" HeaderText="Draft / XPIN No." ReadOnly="True" SortExpression="draftno">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="E_DATETIME" HeaderText="Transaction Date" ReadOnly="True" SortExpression="E_DATETIME">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CUSTREFNUMBER" HeaderText="Customer Ref #" ReadOnly="True" SortExpression="CUSTREFNUMBER">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="draftdate" HeaderText="Payment Date" ReadOnly="True" SortExpression="draftdate">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="trans_type" HeaderText="Trans Type" ReadOnly="True" SortExpression="trans_type">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="transfer_method" HeaderText="Transfer Method" ReadOnly="True" SortExpression="transfer_method">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="bene_name" HeaderText="Beneficiary Name" SortExpression="BENENAME">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="bene_address" HeaderText="Beneficiary Address" ReadOnly="True" SortExpression="bene_address">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACCOUNTNO" HeaderText="Account No." SortExpression="ACCOUNTNO">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="NICNO" HeaderText="CNIC" ReadOnly="True" SortExpression="NICNO">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PHONENO" HeaderText="Contact No." ReadOnly="True" SortExpression="PHONENO">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="correspondingbankid" HeaderText="Bank Code" SortExpression="correspondingbankid">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="bank_name" HeaderText="Bank Name" ReadOnly="True" SortExpression="bank_name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="branchid" HeaderText="Branch Code" SortExpression="branchid">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="branch_name" HeaderText="Branch Name" ReadOnly="True" SortExpression="branch_name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="rem_name" HeaderText="Remitter Name" ReadOnly="True" SortExpression="rem_name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="STATUS" HeaderText="Status" ReadOnly="True" SortExpression="status">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="remarks" HeaderText="Remarks" ReadOnly="True" SortExpression="remarks">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="auth_status" HeaderText="Type" ReadOnly="True" SortExpression="auth_status">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle VerticalAlign="Top" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Action"></asp:CommandField>
<asp:CommandField SelectText="Authorize" ShowSelectButton="True" HeaderText="Action"></asp:CommandField>
</Columns>

<FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>

<PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:GridView> </DIV><BR /><TABLE class="loginDown" cellSpacing=0 width="100%"><TBODY><TR><TD></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>
                </asp:UpdatePanel>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
