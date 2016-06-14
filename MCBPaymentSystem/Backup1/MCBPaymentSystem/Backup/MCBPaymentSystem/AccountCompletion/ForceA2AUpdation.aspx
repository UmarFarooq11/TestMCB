<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="ForceA2AUpdation.aspx.cs" Inherits="ForceA2AUpdation" Title="MCB - Force A2A Updation" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    function clickbtn(rowIndex)
    {
        document.getElementById('<%=hdRowIndex.ClientID %>').value=rowIndex;
        document.getElementById('<%=btnGetAccount.ClientID %>').click();
        
    }
    function clickbtnaccount(rowIndex)
    {
        document.getElementById('<%=hdRowIndex.ClientID %>').value=rowIndex;
        document.getElementById('<%=btnGetSymbolAcct_title.ClientID %>').click();
        
    }
    function BankLOV(rowIndex,hiddenfield) 
    {

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
<asp:Label id="Label1" runat="server" SkinID="FormViewHeading" Width="100%" 
Text="Force A2A Updation" Font-Size="Large" ToolTip="Force A2A Updation"></asp:Label><BR />
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
<asp:Label id="lblMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
<asp:UpdateProgress id="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
<asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
</ProgressTemplate>
</asp:UpdateProgress> 
</TD>
</TR>
<TR align=right>
</TR>
<TR align=right>
</TR>
</TBODY>
</TABLE>
<table class="air" cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%">
<TBODY>
<TR>
<TD style="WIDTH: 25%; TEXT-ALIGN: right" class="TableColumns">Agent :&nbsp; </TD>
<TD class="ColLines" colSpan=4>
<asp:DropDownList id="ddlCompanyCode" runat="server" Width="355px" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR>
<TD style="TEXT-ALIGN: right" class="TableColumns">File :&nbsp; </TD>
<TD class="ColLines">
<asp:DropDownList id="ddlFile" runat="server" SkinID="TXT" Width="355px" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged" AutoPostBack="True" CssClass="dropdown"></asp:DropDownList> </TD>
<TD style="TEXT-ALIGN: right" class="ColLines1" colSpan=2><asp:Label id="lblTotalFile" runat="server" Text="File Total Records :"></asp:Label>&nbsp;</TD>
<TD style="TEXT-ALIGN: left" class="ColLines">
<asp:Label id="lblTotalRecord" runat="server"></asp:Label>
</TD></TR><TR><TD class="ColLines1">&nbsp;</TD>
<TD style="TEXT-ALIGN: left" class="ColLines">
<asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="100px" Text="Search" Font-Bold="True" CssClass="btnSearch" ValidationGroup="search"></asp:Button>
<asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Width="100px" Text="Submit" Font-Bold="True" CssClass="btnSearch"></asp:Button>&nbsp;
<asp:Button id="btnAuthorize" onclick="btnAuthorize_Click" runat="server" Text="Authorize" Font-Bold="True" CssClass="btnSearch" __designer:wfdid="w175"></asp:Button>&nbsp;
<asp:Button id="btnGetSymbolAcct_title" onclick="btnGetSymbolAcct_title_Click" runat="server" Width="132px" Text="Get Account Title" Font-Bold="True" __designer:wfdid="w168"></asp:Button></TD>
<TD style="TEXT-ALIGN: right" class="ColLines1" colSpan=2>&nbsp;<asp:Label id="lblFieldTrans" runat="server" Width="130px" Text="No. of Transaction :"></asp:Label></TD><TD style="TEXT-ALIGN: left" class="ColLines">
<asp:Label id="lblTransaction" runat="server"></asp:Label>&nbsp;</TD>
</TR><TR><TD class="ColLines1"></TD><TD style="TEXT-ALIGN: left" class="ColLines">
</TD><TD style="TEXT-ALIGN: right" class="ColLines1" colSpan=2></TD>
<TD style="TEXT-ALIGN: left" class="ColLines"></TD></TR></TBODY></TABLE><hr style="color: gainsboro" />
<asp:Panel id="Panel1" runat="server" Width="970px" Height="300px" ScrollBars="Both">
                                                        
                                                        
<asp:GridView id="GridView1" runat="server" SkinID="PSGV" Font-Size="8pt" OnSorting="GridView1_Sorting" PageSize="1000000" Font-Names="Verdana" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" AllowSorting="True">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous" Visible="False"></PagerSettings>
<Columns>
<asp:BoundField DataField="ROWID" HeaderText="Row ID">
<HeaderStyle CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="File Account No." SortExpression="ACCOUNTNUMBER"></asp:BoundField>
<asp:BoundField DataField="BENENAME" HeaderText="File Account Title" SortExpression="BENENAME">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="branch_code" HeaderText="Branch Code" SortExpression="branch_code"></asp:BoundField>
<asp:TemplateField HeaderText="Branch For Force Completion"><ItemTemplate>
<asp:TextBox id="txtBranchCode" runat="server" Width="91px" __designer:wfdid="w169"></asp:TextBox><BR /><asp:HiddenField id="hf_BranchCode" runat="server" __designer:dtid="26740122787512415" __designer:wfdid="w170"></asp:HiddenField> 
</ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Account No. For Force Completion"><ItemTemplate>
<asp:TextBox id="txtaccountno_symbol" runat="server" Width="140px" __designer:wfdid="w171"></asp:TextBox> 
</ItemTemplate>

<ItemStyle Width="140px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="System Account Title"><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ACCOUNTNUMBER") %>' __designer:wfdid="w173"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtSymbolTitle" runat="server" Width="250px" Text='<%# Bind("account_title_symbol") %>' __designer:wfdid="w172"></asp:TextBox> 
</ItemTemplate>

<ItemStyle Width="250px"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="auth_status" HeaderText="Transaction Status" SortExpression="auth_status"></asp:BoundField>
</Columns>

<FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>

<PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:GridView></asp:Panel><BR />
<TABLE class="loginDown" cellSpacing=0 width="100%">
<TBODY><TR><TD>
<asp:Button id="btnGetAccount" onclick="btnGetAccount_Click" runat="server" Width="52px" Text="branch" __designer:wfdid="w129"></asp:Button>&nbsp; 
<asp:HiddenField id="hdRowIndex" runat="server" __designer:wfdid="w131"></asp:HiddenField>
</TD></TR></TBODY></TABLE>
</td>
        </tr>
    </table>






</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
