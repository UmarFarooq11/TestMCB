<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="DepositoryAddandRemove.aspx.cs" Inherits="DepositoryAddandRemove"
    Title="MCB - Depository Add and Remove" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    function clickbtnaccount(rowIndex)
    {
        document.getElementById('<%=hdRowIndex.ClientID %>').value=rowIndex;
        //document.getElementById('<%=btnGetSymbolAcct_title.ClientID %>').click();
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
                    <ContentTemplate>
 <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td style="width: 1%">
            </td>
            <td>
<asp:Label id="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="Depository Add and Remove" Font-Size="Large" ToolTip="Depository Add and Remove">
</asp:Label>  </td>
            <td style="width: 1%">
            </td>
        </tr>
        <tr>
            <td colspan="3">
<hr style="color: darkgray" />
                                 
                                     
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%">
<TBODY>
<TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 15%; COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2>&nbsp;<asp:Label id="lblMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label><asp:UpdateProgress id="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress> </TD></TR>
                                                        <TR align=right></TR><TR align=right></TR></TBODY></TABLE>
   <table class="air" cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%"><TBODY>
<TR><TD style="WIDTH: 25%; TEXT-ALIGN: right" class="TableColumns">Depository Account No. :&nbsp; </TD>
<TD class="ColLines" colSpan=4><asp:TextBox id="txtAccountNo" runat="server" SkinID="TXT" Width="193px" __designer:wfdid="w3"></asp:TextBox>
</TD></TR><TR>
<TD style="WIDTH: 25%; TEXT-ALIGN: right" class="TableColumns">Branch Code&nbsp;:&nbsp; </TD>
<TD class="ColLines" colSpan=4><asp:TextBox id="txtBranchCode" runat="server" SkinID="TXT" Width="76px" __designer:wfdid="w4"></asp:TextBox></TD></TR><TR>
<TD class="ColLines1">&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines" colSpan=4><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="100px" Text="Search" Font-Bold="True" __designer:wfdid="w127" CssClass="btnSearch" ValidationGroup="search"></asp:Button>&nbsp;
<asp:Button id="btnReset" onclick="btnReset_Click" runat="server" Width="100px" Text="Clear" Font-Bold="True" __designer:wfdid="w133"></asp:Button>
 <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Width="100px" Text="Submit" Font-Bold="True" __designer:wfdid="w118"></asp:Button> </TD></TR></TBODY>
 </TABLE>
 <%--<asp:Panel id="Panel1" runat="server" Width="970px" __designer:wfdid="w2" ScrollBars="Both" Height="300px">--%><DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px" onscroll="SetDivPosition()" id="divTest"><asp:GridView id="GridView1" runat="server" SkinID="PSGV" Font-Size="8pt" __designer:wfdid="w1" PageSize="1000000" Font-Names="Verdana" AutoGenerateColumns="False" AllowSorting="True">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous" Visible="False"></PagerSettings>
<Columns>
<asp:BoundField DataField="ROWID" HeaderText="Row ID">
<HeaderStyle CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Account No."><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" __designer:wfdid="w125"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtAccountNo" runat="server" Text='<%# Bind("ACCOUNTNUMBER") %>' Width="121px" SkinID="TXT" __designer:wfdid="w129"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Branch Code"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w131"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtBranchCode" runat="server" Text='<%# bind("BRANCH_CODE") %>' Width="71px" SkinID="TXT" __designer:wfdid="w130"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Title of Account"><EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("symbol_title") %>' __designer:wfdid="w128"></asp:TextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:TextBox id="txtTitleofAccount" runat="server" SkinID="TXT" Width="209px" Text='<%# bind("file_title") %>' __designer:wfdid="w127"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="file_accountnumber" HeaderText="Depository Account No."></asp:BoundField>
<asp:BoundField DataField="Dep_BranchCode" HeaderText="Depository Branch Code"></asp:BoundField>
<asp:BoundField DataField="file_title" HeaderText="Depository Title of Account"></asp:BoundField>
<asp:BoundField DataField="change_dt" HeaderText="Last Change"></asp:BoundField>
<asp:BoundField DataField="change_user" HeaderText="Change User"></asp:BoundField>
</Columns>

<FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>

<PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:GridView> <%--</asp:Panel>--%></DIV><BR />
<asp:HiddenField id="hdRowIndex" runat="server" __designer:wfdid="w183"></asp:HiddenField> 
<TABLE class="loginDown" cellSpacing=0 width="100%">
<TBODY>
<TR><TD style="HEIGHT: 26px">
<asp:Button id="btnGetSymbolAcct_title" runat="server" Width="100px" Text="Account Title" __designer:wfdid="w184">
</asp:Button></TD></TR></TBODY></TABLE>
</td>
        </tr>
    </table>
</ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
