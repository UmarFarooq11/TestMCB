<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeFile="BranchIdentificy.aspx.cs" Inherits="BranchIdentificy"
    Title="MCB -Cash Payment" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    function clickbtn(rowIndex)
    {
        document.getElementById('<%=hdRowIndex.ClientID %>').value=rowIndex;
        document.getElementById('<%=btnGetBranch.ClientID %>').click();
        
    }
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


//var _Y=0;
//function SetDivPosition()
//{
//_Y = document.getElementById('divTest').scrollTop;
//}
//function SetNewPosition()
//{
//if(_Y!=0)
//document.getElementById('divTest').scrollTop = _Y;}
//}


      

    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
    <table cellspacing="0" class="air1" width="100%">
        <input id="scroll" type="hidden" runat="server" />
        <tr>
            <td style="width: 1%">
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="Branch  Identification"
                    Width="100%" SkinID="FormViewHeading"></asp:Label>
            <td style="width: 1%">
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <hr style="color: darkgray" />
                <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                    <tr align="right">
                        <td style="font-weight: bold; width: 15%; color: red; text-align: center" class="ColLines1"                          colspan="2" rowspan="">
                            &nbsp;<asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            <asp:UpdateProgress id="UpdateProgress1" runat="server">
                                <progresstemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                            </progresstemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
                 <table class="air" cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%">
                    <tbody>
                        <tr>
                            <td style="width: 25%; text-align: right" class="TableColumns">
                                Agent :&nbsp;
                            </td>
                            <td class="ColLines" colspan="4">
                                <asp:DropDownList ID="ddlCompanyCode" runat="server" Width="355px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="TableColumns">
                                File :&nbsp;
                            </td>
                            <td class="ColLines">
                                <asp:DropDownList ID="ddlFile" runat="server" Width="355px" SkinID="TXT" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlFile_SelectedIndexChanged" CssClass="dropdown">
                                </asp:DropDownList></td>
                            <td style="text-align: right" class="ColLines" colspan="2">
                                <asp:Label ID="lblTotalFile" runat="server" Text="File Total Records :"></asp:Label>&nbsp;</td>
                            <td style="text-align: left" class="ColLines">
                                <asp:Label ID="lblTotalRecord" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="ColLines1">
                                &nbsp;</td>
                            <td style="text-align: left" class="ColLines">
                                <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search"
                                    Width="100px" Font-Bold="True" CssClass="btnSearch" ValidationGroup="search"></asp:Button>&nbsp;
                                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit"
                                    Width="100px" Font-Bold="True" CssClass="btnSearch"></asp:Button><%--<asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Width="100px"
                                                            Text="Submit" Font-Bold="True" CssClass="btn"></asp:Button>--%></td>
                            <td style="text-align: right" class="ColLines" colspan="2">
                                &nbsp;<asp:Label ID="lblFieldTrans" runat="server" Text="No. of Transaction :" Width="135px"></asp:Label></td>
                            <td style="text-align: left" class="ColLines">
                                <asp:Label ID="lblTransaction" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 21px" class="ColLines1">
                            </td>
                            <td style="height: 21px; text-align: left" class="ColLines">
                            </td>
                            <td style="height: 21px; text-align: right" class="ColLines" colspan="2">
                            </td>
                            <td style="height: 21px; text-align: left" class="ColLines">
                            </td>
                        </tr>
                        <tr>
                            <td class="ColLines1" colspan="5">
                                <div style="overflow: auto; width: 100%; height: 300px" onscroll="SetDivPosition()"
                                    id="divTest">
                                    <%--<asp:Panel style="WIDTH: 100%; HEIGHT: 300px" id="Panel1" runat="server" ScrollBars="Auto">--%>
                                    <asp:GridView ID="sort_table" runat="server" Font-Size="8pt" AutoGenerateColumns="False"
                                        OnRowDataBound="sort_table_RowDataBound" Font-Names="Verdana" PageSize="10000"
                                        OnSorting="sort_table_Sorting" OnRowCommand="sort_table_RowCommand">
                                        <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
                                            LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
                                            NextPageText="Move Next" PageButtonCount="10000000" PreviousPageImageUrl="~/Images/MovePrevious.gif"
                                            PreviousPageText="Move Previous" Visible="False"></PagerSettings>
                                        <Columns>
                                            <asp:BoundField DataField="ROWID" HeaderText="Row ID">
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
                                            <asp:BoundField DataField="CONTACTNUMBER" HeaderText="Contact No." SortExpression="CONTACTNUMBER">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account No." SortExpression="ACCOUNTNUMBER">
                                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CNIC" HeaderText="CNIC" SortExpression="CNIC"></asp:BoundField>
                                            <asp:BoundField DataField="CUSTOMERREFERENCENUMBER" HeaderText="Reference #" SortExpression="CUSTOMERREFERENCENUMBER">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="XPIN" HeaderText="XPIN" SortExpression="XPIN"></asp:BoundField>
                                            <asp:BoundField DataField="TRANSAMOUNT" HeaderText="Amount" SortExpression="TRANSAMOUNT">
                                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bank_code" HeaderText="Bank Code" SortExpression="bank_code">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bank" HeaderText="Bank Name" SortExpression="bank"></asp:BoundField>
                                            <asp:BoundField DataField="BRANCH_Code" HeaderText="Branch Code" SortExpression="BRANCH_Code">
                                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BRANCH_NAME" HeaderText="Branch Name" SortExpression="BRANCH_NAME">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Select Branch" SortExpression="branch_write">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("BRANCH_code") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtBranchCode" onchange="if(this.value=='Branch not found') this.value"
                                                        Text='<%# Bind("branch_write") %>' runat="server" Width="104px" SkinID="TXT">
                                                    </asp:TextBox>&nbsp;<asp:ImageButton ID="btnLov" OnClick="btnLov_Click" runat="server"
                                                        ImageUrl="~/Images/search_16x16.png" CommandName="Select"></asp:ImageButton><asp:HiddenField
                                                            ID="hf_BranchCode" runat="server"></asp:HiddenField>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="LinkButtonBranch" runat="server" CommandArgument="branch_write"
                                                        CommandName="Sort" Text="Select Branch" Font-Bold="True" ForeColor="White"></asp:LinkButton>
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>
                                        <PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:GridView>
                                </div>
                                <%--</asp:Panel>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdRight" colspan="5">
                                <asp:HiddenField ID="hdRowIndex" runat="server"></asp:HiddenField>
                                <asp:TextBox ID="txtAgnetCode" runat="server" Width="60px" SkinID="TXT" Enabled="False"
                                    Visible="False"></asp:TextBox><asp:ImageButton ID="btnAgent" OnClick="btnAgent_Click"
                                        runat="server" Enabled="False" Visible="False" OnClientClick="AGENTLOV();" ImageUrl="~/images/search_16x16.png">
                                    </asp:ImageButton><asp:TextBox ID="txtAgentName" runat="server" Width="329px" SkinID="TXT"
                                        Enabled="False" Visible="False"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                            runat="server" ValidationGroup="search" Enabled="False" Visible="False" ControlToValidate="txtAgnetCode"
                                            ErrorMessage="Proper Information Required"></asp:RequiredFieldValidator></td>
                        </tr>
                    </tbody>
                </table>
                <table class="loginDown" cellspacing="0" width="100%">
                    <tbody>
                        <tr>
                            <td>
                                &nbsp;&nbsp;
                                <asp:DropDownList ID="ddlBranch" runat="server" Width="270px" Visible="False">
                                </asp:DropDownList></td>
                        </tr>
                    </tbody>
                </table>
                <asp:Button ID="btnGetBranch" OnClick="btnGetBranch_Click" runat="server" Text="Button">
                </asp:Button></td>
        </tr>
    </table>
    <asp:PlaceHolder ID="ABC" runat="server"></asp:PlaceHolder>
    <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
</asp:Content>
