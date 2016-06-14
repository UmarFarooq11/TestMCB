<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="AccountCompletion.aspx.cs" Inherits="AccountCompletion_AccountCompletion"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    function SelectAll(id)
    {
       var frm1 = document.getElementById('<%= this.GridView1.ClientID %>');
       var grow = frm1.rows.length;
       var source = "";
       for (var i=1; i < grow; i++)
       {
           source = frm1.rows[i].cells[6].innerHTML;
           if (source == "SYMBOLS" || source == "ACCOUNTLIKELIHOOD")
           {
               frm1.rows[i].cells[7].children[0].checked = document.getElementById(id).checked;
           }
       }
    }
    
    function SelectAllAVA(id)
    {
   // alert('ibrahim');
//       var frm = document.forms[0];
//       //alert(frm.elements.length);
//       for (i=0;i<frm.elements.length;i++)
//       {
//           if (frm.elements[i].type == "checkbox")
//           {
//               frm.elements[i].checked = document.getElementById(id).checked;
//           }
//       }
//       var frm1 = document.getElementById('<%= this.GridView1.ClientID %>');
//       var grow = frm1.rows.length;
//       var source = "";
//       for (var i=1; i < grow; i++)
//       {
//           source = frm1.rows[i].cells[6].innerHTML;
//           if (source == "SYMBOLS")
//           {
//               frm1.rows[i].cells[7].children[0].checked = document.getElementById(id).checked;
//           }
//       }
    }
    
    function funConfirm()
    {
        var a = confirm('Are you sure to Execute?');
        if(a == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
function AGENTLOV() 
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_Company.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
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

    <asp:ScriptManager id="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
 <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td style="width: 1%">
            </td>
            <td>
<asp:Label id="Label1" runat="server" Font-Size="Large" SkinID="FormViewHeading" Width="100%" 
Text="Account Completion"></asp:Label>
 </td>
            <td style="width: 1%">
            </td>
        </tr>
        <tr>
            <td colspan="3">
            <hr style="color: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right>
<TD style="FONT-WEIGHT: bold; WIDTH: 15%; COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2>&nbsp;<asp:Label id="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label><asp:UpdateProgress id="UpdateProgress1" runat="server"><progresstemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif"></asp:Image> 
</progresstemplate>
                                        </asp:UpdateProgress> </TD>
 </TR><TR align=right></TR><TR align=right></TR>
 </TBODY>
 </TABLE>
 <table class="air" cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%">
 <TBODY>
 <TR>
 <TD style="WIDTH: 25%; TEXT-ALIGN: right" class="TableColumns">Agent :</TD>
 <TD class="ColLines" colSpan=3>
 <asp:DropDownList id="ddlCompanyCode" runat="server" __designer:dtid="1407374883553311" Width="355px" __designer:wfdid="w5" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">File :</TD><TD class="ColLines"><asp:DropDownList id="ddlFile" runat="server" Width="333px" AutoPostBack="True" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged">
                                        </asp:DropDownList></TD>
                                        <TD style="TEXT-ALIGN: right" class="ColLines"><asp:Label id="lblTotalFile" runat="server" Text="File Total Records :"></asp:Label>&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblTotalRecord" runat="server"></asp:Label></TD></TR><TR><TD style="HEIGHT: 15px" class="ColLines1">&nbsp;</TD><TD style="HEIGHT: 15px; TEXT-ALIGN: left" class="ColLines"><asp:Button id="btnprocess" onclick="btnprocess_Click" runat="server" Width="100px" Text="Process" Font-Bold="True" __designer:wfdid="w1" CssClass="btn"></asp:Button> <asp:Button id="btnFetch" onclick="btnFetch_Click" runat="server" Width="100px" Text="Search" Font-Bold="True" CssClass="btn" ValidationGroup="search"></asp:Button> <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Width="100px" Text="Submit" Font-Bold="True" CssClass="btn"></asp:Button> </TD><TD style="HEIGHT: 15px; TEXT-ALIGN: right" class="ColLines"><asp:Label id="lblFieldTrans" runat="server" Width="135px" Text="No. of Transaction :">
                                        </asp:Label></TD><TD style="HEIGHT: 15px; TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblTransaction" runat="server"></asp:Label>&nbsp;</TD></TR><TR><TD colSpan=5>&nbsp;</TD></TR><TR><TD colSpan=5></TD></TR><TR><TD colSpan=5><asp:Panel id="Panel1" runat="server" Width="100%" Height="325px"><DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px" onscroll="SetDivPosition()" id="div1"><asp:GridView style="WIDTH: 100%" id="GridView1" runat="server" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnSorting="GridView1_Sorting" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ROWID" PageSize="5">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous"></PagerSettings>
<Columns>
<asp:BoundField DataField="ROWID" HeaderText="ROWID" SortExpression="ROWID">
<HeaderStyle CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="BeneficiaryName" HeaderText="Beneficiary Name" SortExpression="BeneficiaryName"></asp:BoundField>
<asp:BoundField DataField="TitleofAccount" HeaderText="Bene Name /Title of Account" SortExpression="TitleofAccount"></asp:BoundField>
<asp:BoundField DataField="BENENAME" HeaderText="Beneficiary Name" SortExpression="BENENAME"></asp:BoundField>
<asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account Number " SortExpression="ACCOUNTNUMBER"></asp:BoundField>
<asp:BoundField DataField="BRANCH_CODE" HeaderText="Branch Code" SortExpression="BRANCH_CODE"></asp:BoundField>
<asp:BoundField DataField="source" HeaderText="Source" SortExpression="source"></asp:BoundField>
<asp:TemplateField HeaderText="Select"><HeaderTemplate>
<asp:CheckBox id="Ckb_SelectALL" runat="server" __designer:wfdid="w23"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="Ckb_Select" runat="server" __designer:wfdid="w22"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView></DIV></asp:Panel> </TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=5></TD></TR><TR><TD class="tdCenter" colSpan=5><asp:Panel id="Panel2" runat="server" Width="100%" Height="325px"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="TEXT-ALIGN: center"><asp:Label id="Label2" runat="server" SkinID="FormViewHeading" Text="MULTIPLELIKELIHOOD" Font-Bold="False"></asp:Label></TD></TR><TR><TD style="TEXT-ALIGN: center"><asp:Label id="Label3" runat="server" Text="Transaction Information " Font-Bold="False">
                                        </asp:Label></TD></TR><TR><TD><DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px" onscroll="SetDivPosition()" id="div2"><asp:GridView style="WIDTH: 100%" id="GV_TransInfo" runat="server" Width="100%" __designer:wfdid="w8" OnSelectedIndexChanged="GV_TransInfo_SelectedIndexChanged" PageSize="5" DataKeyNames="ROWID" AutoGenerateColumns="False" AllowSorting="True" OnRowCommand="GV_TransInfo_RowCommand">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous"></PagerSettings>
<Columns>
<asp:BoundField DataField="ROWID" HeaderText="ROWID" SortExpression="ROWID">
<HeaderStyle CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Beneficiary Name" SortExpression="BENENAME"><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("BENENAME") %>' __designer:wfdid="w5"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
&nbsp;<asp:LinkButton id="LinkButton1" runat="server" Text='<%# Bind("BENENAME") %>' __designer:wfdid="w4" OnClick="LinkButton1_Click"></asp:LinkButton>
</ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="BENEADDRESS" HeaderText="Bene Address" SortExpression="BENEADDRESS">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account Number " SortExpression="ACCOUNTNUMBER">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="BRANCH_CODE" HeaderText="Branch Code" SortExpression="BRANCH_CODE">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView> </DIV></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=5></TD></TR><TR><TD class="tdCenter" colSpan=5><asp:Panel id="Panel3" runat="server" Width="100%" Height="325px"><TABLE style="WIDTH: 100%"><TBODY><TR><TD style="TEXT-ALIGN: center"><asp:Label id="Label4" runat="server" Text="Available Matched Information" Font-Bold="True">
                                        </asp:Label></TD></TR><TR><TD><DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px" onscroll="SetDivPosition()" id="div3"><asp:GridView id="GV_AvalilableMatch" runat="server" Font-Size="8pt" Width="100%" __designer:wfdid="w9" PageSize="5" AutoGenerateColumns="False" AllowSorting="True" OnSorting="GridView1_Sorting" OnRowDataBound="GV_AvalilableMatch_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" Font-Names="Verdana">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous"></PagerSettings>
<Columns>
<asp:BoundField DataField="ROWID" HeaderText="Row ID">
<HeaderStyle CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="BENENAME" HeaderText="Beneficary Name" SortExpression="BENENAME">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Bene Name/Title of Account" SortExpression="ACCOUNTNUMBER">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account Number" SortExpression="ACCOUNTNUMBER">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="BRANCH_CODE" HeaderText="Branch Code" SortExpression="BRANCH_CODE">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="source" HeaderText="Source" SortExpression="source">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="B_ROWID" HeaderText="B_ROW_ID">
<HeaderStyle CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Select"><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("BRANCH_code") %>' __designer:wfdid="w26"></asp:TextBox>
</EditItemTemplate>
<HeaderTemplate>
<asp:CheckBox id="CkbGVA_SelectALL" runat="server" __designer:wfdid="w27"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="CkbGVA_Select" runat="server" __designer:wfdid="w25"></asp:CheckBox> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>

<PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:GridView> </DIV></TD></TR><TR><TD>&nbsp;</TD></TR></TBODY></TABLE></asp:Panel>&nbsp; <asp:TextBox id="txtagent" tabIndex=1 runat="server" SkinID="TXT" Width="50px" __designer:wfdid="w1" Enabled="False" Visible="False" MaxLength="5"></asp:TextBox><asp:ImageButton id="btnCustomerCode" tabIndex=2 onclick="btnCustomerCode_Click" runat="server" __designer:wfdid="w2" CssClass="imagebtnlov" Enabled="False" Visible="False" OnClientClick="AGENTLOV();" ImageUrl="~/images/search_16x16.png"></asp:ImageButton><asp:TextBox id="txtagentname" tabIndex=1 runat="server" SkinID="TXT" Width="329px" __designer:wfdid="w3" Enabled="False" Visible="False" MaxLength="5"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" __designer:wfdid="w4" ValidationGroup="search" Enabled="False" Visible="False" ControlToValidate="txtagent" ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator></TD></TR><TR><TD class="tdRight" colSpan=5>&nbsp; </TD></TR></TBODY></TABLE>
<TABLE class="loginDown" cellSpacing=0 width="100%">
<TBODY>
<TR><TD>
<%--<asp:HiddenField ID="hdRowIndex" runat="server"></asp:HiddenField>--%></TD>
</TR></TBODY>
</TABLE>
 <hr style="color: gainsboro" />
</TD>
</TR></TBODY></TABLE>&nbsp; 
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
