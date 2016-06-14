<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="FetchIBFTTitle.aspx.cs" Inherits="AccountCompletion_AccountCompletion"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE class="air1" cellSpacing=0 width="100%"><TBODY><TR><TD style="WIDTH: 1%"></TD><TD><asp:Label id="Label1" runat="server" Width="100%" Text="Fetch IBFT Title" SkinID="FormViewHeading" Font-Size="Large"></asp:Label> </TD><TD style="WIDTH: 1%"></TD></TR><TR><TD colSpan=3>
<HR style="COLOR: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 15%; COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2>&nbsp;<asp:Label id="lblMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server">
<ProgressTemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif"></asp:Image> 
</ProgressTemplate>
</asp:UpdateProgress> </TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" class="air" cellSpacing=0 width="100%"><TBODY><TR><TD style="WIDTH: 25%; TEXT-ALIGN: right" class="TableColumns">Agent :</TD><TD class="ColLines" colSpan=3><asp:DropDownList id="ddlCompanyCode" runat="server" Width="355px" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">File :</TD><TD class="ColLines"><asp:DropDownList id="ddlFile" runat="server" Width="355px" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="TEXT-ALIGN: right" class="ColLines"><asp:Label id="lblTotalFile" runat="server" Text="File Total Records :"></asp:Label>&nbsp;</TD><TD style="TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblTotalRecord" runat="server"></asp:Label></TD></TR><TR><TD style="HEIGHT: 15px" class="ColLines1">&nbsp;</TD><TD style="HEIGHT: 15px; TEXT-ALIGN: left" class="ColLines"><asp:Button id="btnGetAccountTitle" onclick="btnGetAccountTitle_Click" runat="server" Width="154px" Text="Get Account Title " Font-Bold="True" ValidationGroup="search" CssClass="btn"></asp:Button> <asp:Button id="btnPreview" runat="server" Width="100px" Text="Preview" Font-Bold="True" ValidationGroup="search" CssClass="btn" __designer:wfdid="w1" OnClick="btnPreview_Click"></asp:Button> <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Width="100px" Text="Submit" Font-Bold="True" CssClass="btn"></asp:Button> </TD><TD style="HEIGHT: 15px; TEXT-ALIGN: right" class="ColLines"><asp:Label id="lblFieldTrans" runat="server" Width="135px" Text="No. of Transaction :">
                                        </asp:Label></TD><TD style="HEIGHT: 15px; TEXT-ALIGN: left" class="ColLines"><asp:Label id="lblTransaction" runat="server"></asp:Label>&nbsp;</TD></TR><TR><TD colSpan=5>&nbsp;</TD></TR><TR><TD colSpan=5><DIV style="OVERFLOW: auto; HEIGHT: 250px"><asp:GridView style="WIDTH: 100%" id="GridView1" runat="server" Width="100%" PageSize="5" DataKeyNames="ROWID" AutoGenerateColumns="False" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" EmptyDataText="No data found.">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous"></PagerSettings>
<Columns>
<asp:BoundField DataField="ROWID" HeaderText="rowid">
<HeaderStyle CssClass="hidden"></HeaderStyle>
<ItemStyle CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="accountnumber" HeaderText="Account Number "></asp:BoundField>
<asp:BoundField DataField="benename" HeaderText="Bene Name in File"></asp:BoundField>
<asp:BoundField DataField="titleofaccount" HeaderText="Bene Name / Title of Account"></asp:BoundField>
<asp:BoundField DataField="bank_code" HeaderText="Bank Code"></asp:BoundField>
<asp:TemplateField HeaderText="Select"><HeaderTemplate>
<asp:CheckBox id="Ckb_SelectALL" runat="server"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="Ckb_Select" runat="server"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField HeaderText="Status">

</asp:BoundField>

</Columns>

</asp:GridView> </DIV></TD></TR><TR><TD colSpan=5></TD></TR></TBODY></TABLE><TABLE class="loginDown" cellSpacing=0 width="100%"><TBODY><TR><TD><%--<asp:HiddenField ID="hdRowIndex" runat="server"></asp:HiddenField>--%></TD></TR></TBODY></TABLE>
<HR style="COLOR: gainsboro" />
</TD></TR></TBODY></TABLE>&nbsp; 
</contenttemplate>
    </asp:UpdatePanel>

    <script language="javascript" type="text/javascript">
    function SelectAll(id)
    {
       var frm1 = document.getElementById('<%= this.GridView1.ClientID %>');
       var grow = frm1.rows.length;
       for (var i=1; i < grow; i++)
       {
           frm1.rows[i].cells[5].children[0].checked = document.getElementById(id).checked;
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

</asp:Content>
