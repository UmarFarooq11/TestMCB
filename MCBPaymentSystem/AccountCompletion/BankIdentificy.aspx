<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeFile="BankIdentificy.aspx.cs" Inherits="BankIdentificy"
    Title="MCB - Bank Identification" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    function clickbtn(rowIndex)
    {
        document.getElementById('<%=hdRowIndex.ClientID %>').value=rowIndex;
        document.getElementById('<%=btnGetBank.ClientID %>').click();
        
    }
function BankLOV(rowIndex,hiddenfield) 
{
    document.getElementById('<%=hdRowIndex.ClientID %>').value=rowIndex;
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
            <td style="width: 1%">
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <contenttemplate>
<TABLE cellSpacing=0 width="100%"><TBODY><TR><TD><asp:Label id="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="Bank  Identification" Font-Size="Large"></asp:Label> 
<HR style="COLOR: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 15%; COLOR: red; TEXT-ALIGN: center" colSpan=2>&nbsp;<asp:Label id="lblMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label><asp:UpdateProgress id="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress> </TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" class="air" cellSpacing=0 width="100%"><TBODY><TR><TD style="WIDTH: 25%; TEXT-ALIGN: right" class="TableColumns">Agent :</TD><TD class="ColLines" colSpan=3><asp:DropDownList id="ddlCompanyCode" runat="server" __designer:dtid="1407374883553311" Width="355px" __designer:wfdid="w109" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">File :</TD><TD class="ColLines"><asp:DropDownList id="ddlFile" runat="server" Width="355px" AutoPostBack="True" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged"></asp:DropDownList></TD><TD style="TEXT-ALIGN: right" class="ColLines"><asp:Label id="lblTotalFile" runat="server" Text="File Total Records :"></asp:Label>&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblTotalRecord" runat="server"></asp:Label></TD></TR><TR><TD class="ColLines1">&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines"><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Width="100px" Text="Search" Font-Bold="True" ValidationGroup="search" CssClass="btnSearch"></asp:Button> <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Width="100px" Text="Submit" Font-Bold="True" CssClass="btnSearch"></asp:Button></TD><TD style="TEXT-ALIGN: right" class="ColLines"><asp:Label id="lblFieldTrans" runat="server" Width="135px" Text="No. of Transaction :"></asp:Label></TD><TD style="TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblTransaction" runat="server"></asp:Label>&nbsp;</TD></TR><TR><TD colSpan=5><DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px" onscroll="SetDivPosition()" id="divTest"><asp:GridView id="grdTransaction" runat="server" PageSize="1000000" OnSorting="grdTransaction_Sorting" OnRowDataBound="grdTransaction_RowDataBound" AutoGenerateColumns="False">
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
<asp:BoundField DataField="branch_code" HeaderText="Branch Code" SortExpression="branch_code"></asp:BoundField>
<asp:BoundField DataField="branch_name" HeaderText="Branch Name" SortExpression="branch_name"></asp:BoundField>
<asp:BoundField DataField="BANK_CODE" HeaderText="Bank Code" SortExpression="BANK_CODE"></asp:BoundField>
<asp:BoundField DataField="BANK" HeaderText="Bank Name" SortExpression="BANK">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Select Bank"><ItemTemplate>
<asp:TextBox id="txtbandcode" SkinID="TXT" runat="server" Width="104px" __designer:wfdid="w13"></asp:TextBox>&nbsp;<asp:ImageButton id="BTN_PrincipleBankId_INSERT" onclick="BTN_PrincipleBankId_INSERT_Click" runat="server" __designer:wfdid="w14" ImageUrl="~/images/search_16x16.png" CausesValidation="False"></asp:ImageButton><asp:HiddenField id="hf_BankCode" runat="server" __designer:wfdid="w15"></asp:HiddenField> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle CssClass="gridFooterStyle"></FooterStyle>

<HeaderStyle CssClass="gridHeaderStyle"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR><TR><TD style="HEIGHT: 5px" class="tdCenter" colSpan=5><asp:TextBox id="txtagent" tabIndex=1 runat="server" SkinID="TXT" Width="50px" __designer:wfdid="w110" Visible="False" MaxLength="5"></asp:TextBox><asp:ImageButton id="btnCustomerCode" tabIndex=2 onclick="btnCustomerCode_Click" runat="server" __designer:wfdid="w111" CssClass="imagebtnlov" Visible="False" OnClientClick="AGENTLOV();" ImageUrl="~/images/search_16x16.png"></asp:ImageButton><asp:TextBox id="txtagentname" tabIndex=1 runat="server" SkinID="TXT" Width="329px" __designer:wfdid="w112" Visible="False" MaxLength="5"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" __designer:wfdid="w113" ValidationGroup="search" Visible="False" Enabled="False" ControlToValidate="txtagent" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator></TD></TR><TR><TD class="tdRight" colSpan=5><asp:HiddenField id="hdRowIndex" runat="server"></asp:HiddenField>&nbsp; <asp:DropDownList id="ddlBank" runat="server" Width="270px" __designer:wfdid="w2" Visible="False"></asp:DropDownList></TD></TR></TBODY></TABLE><TABLE class="loginDown" cellSpacing=0 width="100%"><TBODY><TR><TD><asp:Button id="btnGetBank" onclick="btnGetBank_Click" runat="server" Text="Button" __designer:wfdid="w9"></asp:Button><%--<asp:HiddenField ID="hdRowIndex" runat="server"></asp:HiddenField>--%></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
