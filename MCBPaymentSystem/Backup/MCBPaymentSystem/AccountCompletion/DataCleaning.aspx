<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeFile="DataCleaning.aspx.cs" Inherits="DataCleaning"
    Title="MCB - Data Cleaning" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    
    function SelectAll(id)
    {
       var frm1 = document.getElementById('<%= this.GridView1.ClientID %>');
       var frm = document.forms[0];
       for (i=0;i<frm.elements.length;i++)
       {
           if (frm.elements[i].type == "checkbox")
           {
               frm.elements[i].checked = document.getElementById(id).checked;
           }
       }
    }
    function SelectAllAVA(id)
    {
       var frm = document.forms[0];
       for (i=0;i<frm.elements.length;i++)
       {
           if (frm.elements[i].type == "checkbox")
           {
               frm.elements[i].checked = document.getElementById(id).checked;
           }
       }
    }
function BankLOV(rowIndex,hiddenfield) 
{
    
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_SETUP_Bank.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
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
    
     window.onload = function(){
        var strCook = document.cookie;
        if(strCook.indexOf("!~")!=0){
          var intS = strCook.indexOf("!~");
          var intE = strCook.indexOf("~!");
          var strPos = strCook.substring(intS+2,intE);
          document.getElementById("divTest").scrollTop = strPos;
        }
      }
      function SetDivPosition()
      {
        var intY = document.getElementById("divTest").scrollTop;
        document.title = intY;
        document.cookie = "yPos=!~" + intY + "~!";
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
<asp:Label id="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="Data Cleaning" Font-Size="Large"></asp:Label>
</td>
            <td style="width: 1%">
            </td>
        </tr>
        <tr>
            <td colspan="3">
            <hr style="color: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%">
<TBODY><TR align=right>
<TD style="FONT-WEIGHT: bold; WIDTH: 15%; COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2>&nbsp;
<asp:Label id="lblMessage" runat="server" ForeColor="Red" Font-Bold="True">
</asp:Label>
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
<TD style="WIDTH: 25%; TEXT-ALIGN: right" class="TableColumns">Agent :
</TD>
<TD class="ColLines" colSpan=3><asp:DropDownList id="ddlCompanyCode" runat="server" __designer:dtid="1407374883553311" Width="355px" __designer:wfdid="w109" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD style="TEXT-ALIGN: right" class="ColLines1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD><TD class="ColLines"><asp:DropDownList id="ddlFile" runat="server" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged" Visible="False"></asp:DropDownList>&nbsp; </TD><TD style="TEXT-ALIGN: right" class="ColLines">&nbsp; <asp:Label id="lblTotalFile" runat="server" Text="File Total Records :" Visible="False"></asp:Label>&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblTotalRecord" runat="server" Visible="False"></asp:Label>&nbsp;</TD></TR><TR><TD class="ColLines1">&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines"><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="100px" Text="Fetch" Font-Bold="True" Visible="False" ValidationGroup="search" CssClass="btnSearch"></asp:Button> <asp:Button id="btnCleaning" onclick="btnCleaning_Click" runat="server" Width="100px" Text="Cleaning" Font-Bold="True" CssClass="btnSearch"></asp:Button></TD><TD style="TEXT-ALIGN: right" class="ColLines">&nbsp;<asp:Label id="lblFieldTrans" runat="server" Width="135px" Text="No. of Transaction :" Visible="False"></asp:Label></TD><TD style="TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblTransaction" runat="server" Visible="False"></asp:Label>&nbsp; </TD></TR><TR>
<TD style="TEXT-ALIGN: center" class="ColLines" colSpan=4>
<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 140px" onscroll="SetDivPosition()" id="div1"><asp:GridView id="GridView1" runat="server" Font-Size="8pt" __designer:wfdid="w22" OnRowCommand="GridView1_RowCommand" PageSize="1000000" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" Font-Names="Verdana">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous" Visible="False"></PagerSettings>
<Columns>
<asp:TemplateField HeaderText="File Name" SortExpression="file_name"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("file_name") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" Text='<%# Bind("file_name") %>' __designer:wfdid="w29"></asp:LinkButton> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="total_records" HeaderText="File Total Record(s)" SortExpression="total_records">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="cleaning" HeaderText="Status" SortExpression="cleaning">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField><HeaderTemplate>
<asp:CheckBox id="Ckb_SelectALL" runat="server" __designer:wfdid="w25"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="cbPublish" runat="server" __designer:wfdid="w26"></asp:CheckBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>

<PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:GridView> </DIV>
</TD>
</TR>
<TR>
<TD colSpan=5>
<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px" onscroll="SetDivPosition()" id="divTest">
<asp:GridView id="grdTransaction" runat="server" PageSize="1000000" AutoGenerateColumns="False" OnSorting="grdTransaction_Sorting">
<PagerSettings Visible="False"></PagerSettings>
<Columns>
<asp:BoundField DataField="ROWID" HeaderText="ROWID" SortExpression="ROWID">
<HeaderStyle CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TRANS_TYPE" HeaderText="Payment Mode" SortExpression="TRANS_TYPE">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="BANK_CODE" HeaderText="Bank Code" SortExpression="BANK_CODE"></asp:BoundField>
<asp:BoundField DataField="BANK" HeaderText="Bank Name" SortExpression="BANK">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="branch_code" HeaderText="Branch Code" SortExpression="branch_code"></asp:BoundField>
<asp:BoundField DataField="branch_name" HeaderText="Branch Name" SortExpression="branch_name"></asp:BoundField>
<asp:BoundField DataField="BENENAME" HeaderText="Beneficary Name" SortExpression="BENENAME">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="REMENAME" HeaderText="Remitter Name" SortExpression="REMENAME">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CONTACTNUMBER" HeaderText="Contact No." SortExpression="CONTACTNUMBER"></asp:BoundField>
<asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account No" SortExpression="ACCOUNTNUMBER">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CNIC" HeaderText="CNIC" SortExpression="CNIC"></asp:BoundField>
<asp:BoundField DataField="CUSTOMERREFERENCENUMBER" HeaderText="Reference #" SortExpression="CUSTOMERREFERENCENUMBER"></asp:BoundField>
<asp:BoundField DataField="XPIN" HeaderText="XPIN" SortExpression="XPIN"></asp:BoundField>
<asp:BoundField DataField="TRANSAMOUNT" HeaderText="Amount" SortExpression="TRANSAMOUNT">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle CssClass="gridFooterStyle"></FooterStyle>

<HeaderStyle CssClass="gridHeaderStyle"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR></TBODY>
</TABLE>
<TABLE class="loginDown" cellSpacing=0 width="100%">
<TBODY>
<TR>
<TD>
<%--<asp:HiddenField ID="hdRowIndex" runat="server"></asp:HiddenField>--%>
</TD>
</TR>
</TBODY>
</TABLE> <hr style="color: gainsboro" />
</TD>
</TR>
</TABLE>
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
