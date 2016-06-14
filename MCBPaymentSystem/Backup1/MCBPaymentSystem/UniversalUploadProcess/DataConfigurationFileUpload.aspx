<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="DataConfigurationFileUpload.aspx.cs" Inherits="DataConfigurationFileUpload"
    Title="Data Configuration File Upload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    var oldgridSelectedColor;
    function setMouseOverColor(element) 
    {
        oldgridSelectedColor = element.style.backgroundColor;
        //element.style.backgroundColor='yellow';
        element.style.cursor='hand';
        element.style.textDecoration='underline';
    }
    function setMouseOutColor(element) 
    {
        element.style.backgroundColor=oldgridSelectedColor;
        element.style.textDecoration='none';
    }
    
    function NODuplicate(element) 
    {
        element.style.backgroundColor=oldgridSelectedColor;
        element.style.textDecoration='none';
    }
    
    </script>

    <script language="javascript" type="text/javascript">
    //window.onload = validate();
    //var uploadcontrol = document.getElementById('<%=FileUpload1.ClientID%>').value;
    
   
    
    
    

    function validate()
    {
        var uploadcontrol = document.getElementById('<%=FileUpload1.ClientID%>').value;
        var reg = /^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.xlsx|.csv|.txt|.XLS|.XLSX|.CSV|.TXT)$/;
        if (uploadcontrol.length > 0)
        {
            if (reg.test(uploadcontrol))
            {
                alert(reg.test(uploadcontrol));
                return true;
            }
            else
            {
                alert(reg.test(uploadcontrol));
                alert("Only xls, xlsx, csv and txt files are allowed!");
                return false;
            }
        }
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
   function funConfirmRollback()
   {
            var a = confirm('Are you sure to Roll Back?');
            if (a == true)
            {
                return true;
            }
            else
            {
                return false;
            }
    }
        

function CompanyLOV() 
{
 var a;
 var c='<%= Session["HEIGHT"] %>';
var b='<%= Session["WIDTH"] %>';
  a=window.showModalDialog('../LOV/LOV_Company.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function ConfigdescLOV() 
{
 var a;
 var c='<%= Session["HEIGHT"] %>';
var b='<%= Session["WIDTH"] %>';
  a=window.showModalDialog('../LOV/LOV_CustomerConfigLink.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}


    </script>

    <div style="text-align: left">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table cellspacing="0" class="air1" width="100%">
            <tr>
                <td colspan="3" style="height: 1px">
                    <table cellspacing="0" width="100%">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="Universal Upload Process"
                                        Font-Size="Large"></asp:Label>
                                    <hr style="color: darkgray" />
                                    <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr align="right">
                                                <td style="font-weight: bold; width: 15%; color: red; text-align: center" class="ColLines1"
                                                    colspan="2">
                                                    <asp:Label ID="lbl_Message" runat="server" CssClass="lblMessage"></asp:Label>&nbsp;
                                                    <asp:UpdateProgress id="UpdateProgress1" runat="server">
                                                        <progresstemplate>
                <asp:Image id="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif"></asp:Image> 
                </progresstemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table style="font-size: 8pt; font-family: Verdana" class="air" cellspacing="0" width="100%"
                                        id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
                                        <tbody>
                                            <tr>
                                                <td class="ColLines1" colspan="2" style="font-weight: bold; text-align: right" width="30%">
                                                    &nbsp;</td>
                                                <td class="ColLines1" width="80%">
                                                    &nbsp;</td>
                                                <td class="ColLines1" colspan="6" style="text-align: center">
                                                    <asp:Label ID="lblSummary" runat="server" Text="Total File Summary"></asp:Label>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="ColLines1" colspan="2" style="font-weight: bold; width: 25%; text-align: right">
                                                    &nbsp;</td>
                                                <td class="ColLines1" width="60%">
                                                    &nbsp;</td>
                                                <td class="ColLines1" colspan="2" style="text-align: right" width="5%">
                                                    &nbsp;</td>
                                                <td class="ColLines1" style="text-align: left" width="8%">
                                                    <asp:Label ID="lblrecord" runat="server" Text="Record"></asp:Label></td>
                                                <td class="ColLines1" style="text-align: left" width="8%">
                                                    <asp:Label ID="lblamount" runat="server" Text="Amount"></asp:Label>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="TableColumns" style="font-weight: bold; width: 25%; text-align: right"
                                                    colspan="2">
                                                    Customer&nbsp;Code :&nbsp;
                                                </td>
                                                <td class="ColLines1" width="60%">
                                                    <asp:DropDownList ID="ddlCompanyCode" runat="server" Width="355px" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged"
                                                        AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                                <td class="ColLines1" style="text-align: right" width="5%" colspan="2">
                                                    <asp:Label ID="lbA2A" runat="server" Text="A2A : "></asp:Label></td>
                                                <td class="ColLines1" style="text-align: left" width="3%">
                                                    &nbsp;
                                                    <asp:Label ID="lblA2A" runat="server"></asp:Label></td>
                                                <td class="ColLines1" style="text-align: right" width="8%">
                                                    <asp:Label ID="lblA2ATOT" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="font-weight: bold; width: 15%; text-align: right" class="TableColumns"
                                                    colspan="2">
                                                    Configuration Defination ID :&nbsp;
                                                </td>
                                                <td class="ColLines1">
                                                    <asp:DropDownList ID="ddlConfigID" runat="server" Width="355px">
                                                    </asp:DropDownList></td>
                                                <td class="ColLines1" colspan="2" style="text-align: right">
                                                    <asp:Label ID="lbPRI" runat="server" Text="PRI : "></asp:Label></td>
                                                <td class="ColLines1" style="text-align: left" contenteditable="true">
                                                    &nbsp;
                                                    <asp:Label ID="lblPRI" runat="server"></asp:Label></td>
                                                <td class="ColLines1" style="text-align: right">
                                                    <asp:Label ID="lblPRITOT" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="TableColumns" colspan="2" style="font-weight: bold; width: 15%; text-align: right">
                                                    Upload File :&nbsp;
                                                </td>
                                                <td class="ColLines1">
                                                    <asp:FileUpload ID="FileUpload1" TabIndex="3" runat="server" Width="355px"></asp:FileUpload>
                                                    </td>
                                                <td class="ColLines1" colspan="2" style="text-align: right">
                                                    <asp:Label ID="lbCOC" runat="server" Text="COC : "></asp:Label></td>
                                                <td class="ColLines1" colspan="1" style="text-align: left">
                                                    &nbsp;
                                                    <asp:Label ID="lblCOC" runat="server"></asp:Label></td>
                                                <td class="ColLines1" style="text-align: right">
                                                    <asp:Label ID="lblCOCTOT" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="TableColumns" colspan="2" style="font-weight: bold; width: 15%; text-align: right">
                                                </td>
                                                <td class="ColLines1">
                                                <asp:Button ID="btnUpload" TabIndex="4" OnClick="btnUpload_Click" runat="server"
                                                        Text="Upload" ValidationGroup="BOTH"></asp:Button>&nbsp;
                                                    <asp:Button ID="btnRollBack" runat="server" Text="Roll Back" OnClick="btnRollBack_Click"
                                                        TabIndex="5" />&nbsp;<asp:Button ID="btnProcess" TabIndex="5" 
                                                        OnClick="btnProcess_Click" runat="server"
                                                        Text="Submit" ValidationGroup="BOTH" Font-Bold="False"></asp:Button>
                                                </td>
                                                <td class="ColLines1" colspan="2" style="text-align: right">
                                                    <asp:Label ID="lbIBFT" runat="server" Text="IBFT : "></asp:Label></td>
                                                <td class="ColLines1" colspan="1" style="text-align: left">
                                                    &nbsp;
                                                    <asp:Label ID="lblIBFT" runat="server"></asp:Label></td>
                                                <td class="ColLines1" style="text-align: right">
                                                    <asp:Label ID="lblIBFTTOT" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="TableColumns" colspan="2" style="font-weight: bold; width: 15%; text-align: right">
                                                    Transaction Type DD :&nbsp;
                                                </td>
                                                <td class="ColLines1">
                                                    <asp:CheckBox ID="chTransDD" runat="server" /></td>
                                                <td class="ColLines1" colspan="2" style="text-align: right">
                                                    <asp:Label ID="lbDD" runat="server" Text="DD : "></asp:Label></td>
                                                <td class="ColLines1" colspan="1" style="text-align: left">
                                                    &nbsp;
                                                    <asp:Label ID="lblDD" runat="server"></asp:Label></td>
                                                <td class="ColLines1" style="text-align: right">
                                                    <asp:Label ID="lblDDTOT" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="ColLines1" style="text-align: right; height: 19px;" colspan="5">
                                                    &nbsp; &nbsp;&nbsp;
                                                    <asp:Label ID="lbDuplicateRecords" runat="server" Text="Duplicate : "></asp:Label></td>
                                                <td class="ColLines1" style="text-align: left">
                                                    &nbsp;
                                                    <asp:Label ID="lblDuplicateRecords" runat="server"></asp:Label></td>
                                                <td class="ColLines1" style="text-align: right">
                                                    <asp:Label ID="lblDUPTOT" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="ColLines1" colspan="5" style="height: 19px; text-align: right">
                                                    <asp:Label ID="lbIBANRecords" runat="server" Text="IBANRecords : "></asp:Label></td>
                                                <td class="ColLines1" style="text-align: left">
                                                    &nbsp;
                                                    <asp:Label ID="lblInvalidIBANRecords" runat="server"></asp:Label></td>
                                                <td class="ColLines1" style="text-align: right">
                                                    <asp:Label ID="lblIBANTOT" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="ColLines1" style="text-align: right; height: 17px;" colspan="5">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lbTotalTransaction" runat="server" Text="Total : "></asp:Label></td>
                                                <td class="ColLines1" style="text-align: left">
                                                    &nbsp;
                                                    <asp:Label ID="lblTotalRecord" runat="server"></asp:Label></td>
                                                <td class="ColLines1" style="text-align: right">
                                                    &nbsp;<asp:Label ID="lblTotalAmount" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="ColLines1" colspan="5" style="height: 17px; text-align: right">
                                                    <asp:Label ID="lbTotalAmount" runat="server" Text="Total Amount : " Visible="False"></asp:Label></td>
                                                <td class="ColLines1" style="text-align: right" colspan="2">
                                                    &nbsp; &nbsp;
                                                </td>
                                            </tr>
                                            <tr align="right">
                                                <td class="ColLines1" colspan="8" style="font-size: 9pt; color: #444444; font-family: Arial, Tahoma;
                                                    text-align: left">
                                                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                        <contenttemplate>
<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px"><asp:GridView id="GridView1" runat="server" Font-Size="8pt" Width="100%" AllowSorting="True" AutoGenerateColumns="False" PageSize="1000000" Font-Names="Verdana" OnSorting="GridView1_Sorting" EmptyDataText="No Data Found">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous" Visible="False"></PagerSettings>
<Columns>
<asp:BoundField DataField="TRANS_TYPE" HeaderText="Payment Mode" SortExpression="TRANS_TYPE">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="BANK_CODE" HeaderText="Bank Code" SortExpression="BANK_CODE"></asp:BoundField>
<asp:BoundField DataField="BANK" HeaderText="Bank Name" SortExpression="BANK">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="BRANCH_CODE" HeaderText="Branch Code" SortExpression="BRANCH_CODE"></asp:BoundField>
<asp:BoundField DataField="BRANCH_Name" HeaderText="Branch Name" SortExpression="BRANCH_Name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="BENENAME" HeaderText="Beneficary Name" SortExpression="BENENAME">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="REMENAME" HeaderText="Remitter Name" SortExpression="REMENAME"></asp:BoundField>
<asp:BoundField DataField="CONTACTNUMBER" HeaderText="Contact No." SortExpression="CONTACTNUMBER"></asp:BoundField>
<asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account No." SortExpression="ACCOUNTNUMBER">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="cnic" HeaderText="CNIC" SortExpression="cnic">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CUSTOMERREFERENCENUMBER" HeaderText="Reference#" SortExpression="CUSTOMERREFERENCENUMBER"></asp:BoundField>
<asp:BoundField DataField="XPIN" HeaderText="XPIN" SortExpression="XPIN"></asp:BoundField>
<asp:BoundField DataField="TRANSAMOUNT" HeaderText="Amount" SortExpression="TRANSAMOUNT">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>

<PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:GridView></DIV>
</contenttemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    </td>
            </tr>
        </table>
</asp:Content>
