<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="CancelationFileUpload.aspx.cs" Inherits="CancelationFileUpload" Title="Cancelation File Upload" %>

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
        <table cellspacing="0" class="air1" style="font-size: 8pt; font-family: Verdana"
            width="100%">
            <tr>
                <td class="ColLines1" colspan="3" style="text-align: left">
                    <asp:Label ID="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="Bulk Cancel / UnHold"
                        Font-Size="Large"></asp:Label>
                    <hr style="color: darkgray" />
                </td>
            </tr>
            <tr>
                <td class="ColLines1" colspan="3" style="font-weight: bold; color: red; text-align: center">
                    <asp:Label ID="lblMessage" runat="server" CssClass="lblMessage"></asp:Label></td>
            </tr>
            <tr>
                <td class="ColLines1" colspan="3" style="text-align: center">
                    <asp:UpdateProgress id="UpdateProgress1" runat="server">
                        <progresstemplate>
                                                            <asp:Image id="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" __designer:wfdid="w1"></asp:Image> 
                                                        </progresstemplate>
                    </asp:UpdateProgress></td>
            </tr>
            <tr>
                <td class="TableColumns" style="font-weight: bold; width: 25%; text-align: right"
                    colspan="2">
                    Company :&nbsp;
                </td>
                <td class="ColLines1" width="60%">
                    <asp:DropDownList ID="ddlCompanyCode" runat="server" Width="355px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="TableColumns" colspan="2" style="font-weight: bold; width: 15%; text-align: right">
                    Upload File :&nbsp;
                </td>
                <td class="ColLines1">
                    <asp:FileUpload ID="FileUpload1" TabIndex="3" runat="server" Width="355px"></asp:FileUpload>
                    <asp:Button ID="btnUpload" TabIndex="4" OnClick="btnUpload_Click" runat="server"
                        Text="Upload" ValidationGroup="BOTH"></asp:Button></td>
            </tr>
            <tr>
                <td class="TableColumns" colspan="2" style="font-weight: bold; width: 15%; text-align: right">
                    File Type :&nbsp;
                </td>
                <td class="ColLines1">
                    <asp:RadioButton ID="rbCancel" runat="server" Checked="True" GroupName="filetype"
                        Text="Cancel" />
                    <asp:RadioButton ID="rbHold" runat="server" GroupName="filetype" Text="UnHold" /></td>
            </tr>
            <tr>
                <td class="TableColumns" colspan="2" style="font-weight: bold; width: 15%; text-align: right">
                    Search File :&nbsp;
                </td>
                <td class="ColLines1">
                    <asp:TextBox ID="txtSearchFileStatus" runat="server" SkinID="TXT" Width="265px"></asp:TextBox>
                    <asp:Button ID="btnSearchFileStatus" runat="server" TabIndex="4" Text="Search File Status" OnClick="btnSearchFileStatus_Click" /></td>
            </tr>
            <tr align="right">
                <td class="ColLines1" colspan="4" style="font-size: 9pt; color: #444444; font-family: Arial, Tahoma;
                    text-align: left">
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 100%"><asp:GridView id="GridView1" runat="server" Font-Size="8pt" Width="99%" AllowSorting="True" AutoGenerateColumns="False" PageSize="1000000" Font-Names="Verdana" EmptyDataText="No Data Found"><Columns>
<asp:BoundField DataField="Xpin" HeaderText="XPIN / Draft No."></asp:BoundField>
<asp:BoundField DataField="status" HeaderText="Status"></asp:BoundField>
<asp:BoundField DataField="Cancel_Date" HeaderText="Cancel / UnHold Date"></asp:BoundField>
<asp:BoundField DataField="file_type" HeaderText="File Type"></asp:BoundField>
<asp:BoundField DataField="file_load_dt" HeaderText="File Upload Date"></asp:BoundField>
</Columns>

<FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>

<PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:GridView> </DIV>
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
