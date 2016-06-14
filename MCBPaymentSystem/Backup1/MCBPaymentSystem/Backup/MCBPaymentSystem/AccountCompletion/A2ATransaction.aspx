<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="A2ATransaction.aspx.cs" Inherits="A2ATransaction" Title="MCB - Data Publish" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
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
<asp:Label id="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="A2A Transaction" Font-Size="Large"></asp:Label>
</td>
            <td style="width: 1%">
            </td>
        </tr>
        <tr>
            <td colspan="3">
            <hr style="color: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 15%; COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2>&nbsp;<asp:Label id="lblMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label><asp:UpdateProgress id="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>&nbsp; </TD>
                                                        </TR><TR align=right></TR>
                                                        <TR align=right></TR>
                                                        </TBODY>
                                                        </TABLE>
<table class="air" cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%">                                                        <TR>
                                                        <TD style="TEXT-ALIGN: right" class="TableColumns" width="19%">From&nbsp;Date&nbsp;:&nbsp; </TD>
                                                        <TD class="ColLines1" width="16%">
                                                        <asp:TextBox id="txtFromDate" runat="server" SkinID="TXT" Width="90px">
                                                        </asp:TextBox>&nbsp; 
                                                        <cc1:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="txtFromDate" Format="dd-MM-yyyy">
                                                        </cc1:CalendarExtender>
                                                        </TD>
                                                        <TD style="TEXT-ALIGN: right" class="TableColumns" width="8%">To Date :&nbsp;&nbsp; 
                                                        </TD>
                                                        <TD class="ColLines1" width="30%" colSpan=2><asp:TextBox id="txtToDate" runat="server" SkinID="TXT" Width="90px">
                                                        </asp:TextBox>&nbsp; <cc1:CalendarExtender id="CalendarExtender2" runat="server" TargetControlID="txtToDate" Format="dd-MM-yyyy">
                                                        </cc1:CalendarExtender> </TD>
                                                        </TR>
                                                        <TR>
                                                        <TD style="TEXT-ALIGN: right" class="TableColumns">Agent :&nbsp; </TD>
                                                        <TD class="ColLines1" colSpan=2>
                                                        <asp:DropDownList id="ddlCompanyCode" runat="server" Width="355px" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                        </TD>
                                                        <TD style="TEXT-ALIGN: right" class="ColLines1">&nbsp;<asp:Label id="lblStart" runat="server" Text="Start Trans. No. :"></asp:Label>
                                                        </TD>
                                                        <TD class="ColLines1"><asp:Label id="lblStartTrans" runat="server"></asp:Label>&nbsp;</TD>
                                                        </TR>
                                                        <TR>
                                                        <TD style="TEXT-ALIGN: right" class="TableColumns">File :&nbsp; </TD><TD class="ColLines1" colSpan=2><asp:DropDownList id="ddlFile" runat="server" SkinID="TXT" Width="355px" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged" AutoPostBack="True" CssClass="dropdown"></asp:DropDownList></TD><TD style="TEXT-ALIGN: right" class="ColLines1">&nbsp;<asp:Label id="lblEnd" runat="server" Text="End Trans No. :"></asp:Label></TD>
                                                        <TD class="ColLines1"><asp:Label id="lblEndTrans" runat="server"></asp:Label>&nbsp;</TD></TR>
                                                        <TR>
                                                        <TD style="TEXT-ALIGN: right" class="ColLines1">&nbsp;&nbsp; </TD>
                                                        <TD class="ColLines1">
                                                        <asp:TextBox id="txtAccountNo" runat="server" SkinID="TXT" CssClass="hidden"></asp:TextBox>&nbsp;</TD>
                                                        <TD class="ColLines1">&nbsp; </TD><TD style="TEXT-ALIGN: right" class="ColLines1">&nbsp;
                                                        <asp:Label id="lblTotalFile" runat="server" Text="File Total Records :"></asp:Label></TD>
                                                        <TD class="ColLines1"><asp:Label id="lblTotalRecord" runat="server"></asp:Label>&nbsp;</TD>
                                                        </TR><TR><TD style="TEXT-ALIGN: right" class="ColLines1">&nbsp;&nbsp;</TD>
                                                        <TD class="ColLines1">
                                                        <asp:TextBox id="txtCNIC" runat="server" SkinID="TXT" CssClass="hidden"></asp:TextBox>&nbsp;</TD><TD class="ColLines1">&nbsp;&nbsp; </TD><TD style="TEXT-ALIGN: right" class="ColLines1">&nbsp;<asp:Label id="lblFieldTrans" runat="server" Width="130px" Text="No. of Transaction :"></asp:Label></TD><TD class="ColLines1"><asp:Label id="lblTransaction" runat="server"></asp:Label>&nbsp;</TD></TR><TR><TD style="TEXT-ALIGN: right" class="ColLines1">&nbsp;&nbsp; </TD><TD class="ColLines1"><asp:TextBox id="txtCustomerRefNo" runat="server" SkinID="TXT" CssClass="hidden" __designer:wfdid="w1"></asp:TextBox>&nbsp; </TD><TD class="ColLines1">&nbsp; </TD><TD style="TEXT-ALIGN: right" class="ColLines1">&nbsp;</TD><TD class="ColLines1">&nbsp;</TD></TR><TR><TD class="ColLines1">&nbsp; </TD><TD class="ColLines1" colSpan=2><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="100px" Text="Search" Font-Bold="True" CssClass="btnSearch" ValidationGroup="search"></asp:Button>&nbsp;<asp:Button id="btnReset" onclick="btnReset_Click" runat="server" Width="100px" Text="Reset" Font-Bold="True" CssClass="btnSearch"></asp:Button> <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Width="100px" Text="Submit" Font-Bold="True" CssClass="btnSearch"></asp:Button></TD><TD class="ColLines1">&nbsp; </TD><TD class="ColLines1">&nbsp; </TD></TR><TR><TD colSpan=5>&nbsp;</TD></TR>
                                                        </TABLE>
<TABLE style="WIDTH: 100%" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()"><TBODY><TR><TD class="tdCenter" colSpan=5><DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px" onscroll="SetDivPosition()" id="divTest"><asp:GridView id="GridView1" runat="server" Width="100%" Font-Size="8pt" OnSorting="GridView1_Sorting" PageSize="5" Font-Names="Verdana" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous" Visible="False"></PagerSettings>
<Columns>
<asp:BoundField DataField="ROWID" HeaderText="Row ID">
<HeaderStyle CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TRANS_TYPE" HeaderText="Payment Mode" SortExpression="TRANS_TYPE">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="bank_code" HeaderText="Bank Code" SortExpression="bank_code"></asp:BoundField>
<asp:BoundField DataField="BANK" HeaderText="Bank Name" SortExpression="BANK">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="branch_code" HeaderText="Branch Code" SortExpression="branch_code"></asp:BoundField>
<asp:BoundField DataField="BRANCH_Name" HeaderText="Branch Name" SortExpression="BRANCH_Name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="BENENAME" HeaderText="Beneficary Name" SortExpression="BENENAME">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="REMENAME" HeaderText="Remitter Name" SortExpression="REMENAME">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CONTACTNUMBER" HeaderText="Contact No." SortExpression="CONTACTNUMBER"></asp:BoundField>
<asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account No." SortExpression="ACCOUNTNUMBER">
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
<asp:BoundField DataField="system_reply" HeaderText="System Reply"></asp:BoundField>
<asp:TemplateField><HeaderTemplate>
<asp:CheckBox id="Ckb_SelectALL" runat="server"></asp:CheckBox>
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="cbPublish" runat="server" __designer:wfdid="w4"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>

<PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:GridView> </DIV></TD></TR><TR><TD class="tdCenter" colSpan=5></TD></TR><TR><TD class="tdRight" colSpan=5>&nbsp;</TD></TR></TBODY></TABLE>
<hr style="color: gainsboro" />
</TD></TR></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
