<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="CustomerFundingFileUpload.aspx.cs" Inherits="CustomerFundingFileUpload"
    Title="Customer Funding File Upload" %>

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
                                    <asp:Label ID="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="Customer Finding Upload"
                                        Font-Size="Large"></asp:Label>
                                    <table class="login" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr align="right">
                                                <td style="font-weight: bold; width: 15%; color: red; text-align: center" class="ColLines1"
                                                    colspan="2">
                                                    <asp:Label ID="lbl_Message" runat="server" CssClass="lblMessage"></asp:Label>&nbsp;
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif"></asp:Image>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr align="right">
                                            </tr>
                                            <tr align="right">
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table style="font-size: 8pt; font-family: Verdana" class="air" cellspacing="0" width="100%"
                                        id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
                                        <tbody>
                                            <tr>
                                                <td class="ColLines1" colspan="2" style="font-weight: bold; width: 15%; text-align: right">
                                                    Upload File :&nbsp;
                                                </td>
                                                <td class="ColLines1" colspan="5">
                                                    <asp:FileUpload ID="FileUpload1" TabIndex="3" runat="server" Width="355px"></asp:FileUpload>
                                                    <asp:Button ID="btnUpload" TabIndex="4" OnClick="btnUpload_Click" runat="server"
                                                        Text="Upload" ValidationGroup="BOTH"></asp:Button>&nbsp;<asp:Button ID="btnPreview"
                                                            runat="server" OnClick="btnPreview_Click" Text="Preview" Visible="False" /></td>
                                            </tr>
                                            <tr align="right">
                                                <td class="ColLines1" colspan="8" style="font-size: 9pt; color: #444444; font-family: Arial, Tahoma;
                                                    text-align: left">
                                                    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>--%>
                                                    <div style="overflow: auto; width: 100%; height: 300px">
                                                        <asp:GridView ID="GridView1" runat="server" Font-Size="8pt" Width="100%" EmptyDataText="No Data Found"
                                                            Font-Names="Verdana" PageSize="1000000" AutoGenerateColumns="False">
                                                            <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
                                                                LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
                                                                NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous"
                                                                Visible="False"></PagerSettings>
                                                            <FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>
                                                            <PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>
                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                            <Columns>
                                                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                    <%--  </ContentTemplate>
                                                    </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                            <tr align="right">
                                            </tr>
                                            <tr align="right">
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:HiddenField ID="hdn_value" runat="server" />
                </td>
            </tr>
        </table>
</asp:Content>
