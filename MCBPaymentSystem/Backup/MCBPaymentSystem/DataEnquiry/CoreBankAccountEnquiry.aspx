<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="CoreBankAccountEnquiry.aspx.cs" Inherits="CoreBankAccountEnquiry" Title="MCB -Core Bank Account Enquiry" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../Script/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
    function setVal(val)
    {
       var b = val.split(';');
       return val.value = b[1];
    }
    function IsIBANCheck() {
        $.ajax({
            type: "POST",
            url: "CoreBankAccountEnquiry.aspx/IsIBANvalid",
            data: '{IBAN: "' + $("#<%=txbIBAN.ClientID%>")[0].value + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function(response) {
                alert(setVal(response));
            }
        });
    }
    function OnSuccess(response) 
    {
        alert(setVal(response));
    }
    </script>

    <script src="../Script/Script.js" type="text/javascript" language="javascript"></script>

    <script language="javascript" type="text/javascript">
//function BankLOV(rowIndex,hiddenfield) 
//{
//    var a;
//    var c='<%= Session["HEIGHT"] %>';
//    var b='<%= Session["WIDTH"] %>';
//    a=window.showModalDialog('../LOV/LOV_SETUP_Bank.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
//}

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

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <table cellspacing="0" class="air1" width="100%">
                <tr>
                    <td colspan="3" style="height: 1px">
                        <table cellspacing="0" width="100%">
                            <tbody>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="IBAN Enquiry"
                                            Font-Size="Large"></asp:Label><br />
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
                                                        &nbsp;<asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
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
                                        <table style="width: 100%" class="air1">
                                            <tbody>
                                                <tr>
                                                    <td style="text-align: right" class="ColLines1" width="40%">
                                                        CNIC :&nbsp;
                                                    </td>
                                                    <td style="text-align: left" class="ColLines1" colspan="1">
                                                        <asp:TextBox ID="txtCNIC" runat="server" SkinID="TXT"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right" class="ColLines1" width="40%">
                                                        Branch&nbsp;Code :</td>
                                                    <td style="text-align: left" class="ColLines1" colspan="1">
                                                        <asp:TextBox ID="txtBranchCode" runat="server" SkinID="TXT"></asp:TextBox>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right" class="ColLines1" width="40%">
                                                        &nbsp;Account No.:&nbsp;</td>
                                                    <td style="text-align: left" class="ColLines1" colspan="1">
                                                        <asp:TextBox ID="txtAccNo" runat="server" SkinID="TXT" MaxLength="16"></asp:TextBox>&nbsp;
                                                        Length Should be between 4 to 16.</td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right" class="ColLines1" width="40%">
                                                        IBAN:</td>
                                                    <td style="text-align: left" class="ColLines1" colspan="1">
                                                        <asp:TextBox ID="txbIBAN" runat="server" SkinID="TXT" Width="216px"
                                                            MaxLength="24"></asp:TextBox>
                                                        &nbsp;<asp:Button ID="btnCheck" runat="server" Width="100px" Text="IBAN Validator" Font-Bold="true"
                                                            CssClass="btnSearch"></asp:Button>
                                                        <%--<input id="btnUserExist" type="button" value="Check IBAN" onclick="IsIBANCheck()" class="btnSearch" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right" class="ColLines1" width="40%">
                                                        &nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td style="text-align: left" class="ColLines1" colspan="1">
                                                        <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Width="100px"
                                                            Text="Fetch" Font-Bold="true" CssClass="btnSearch" ValidationGroup="search">
                                                        </asp:Button>&nbsp;<asp:Button ID="btnReset" OnClick="btnReset_Click" runat="server"
                                                            Width="100px" Text="Reset" Font-Bold="true" CssClass="btnSearch">
                                                        </asp:Button></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left" class="ColLines1" colspan="2">
                                                        <asp:GridView ID="GridView1" runat="server" SkinID="DATAENQ" Width="100%"
                                                            EmptyDataText="No data found" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                            OnSorting="GridView1_Sorting" PageSize="20">
                                                            <PagerSettings FirstPageText="" LastPageText="" NextPageText=""></PagerSettings>
                                                            <Columns>
                                                                <asp:BoundField DataField="benename" HeaderText="ACCOUNT TITLE"></asp:BoundField>
                                                                <asp:BoundField DataField="branch_code" HeaderText="BRANCH CODE"></asp:BoundField>
                                                                <asp:BoundField DataField="ban" HeaderText="BAN"></asp:BoundField>
                                                                <asp:BoundField DataField="iban" HeaderText="IBAN"></asp:BoundField>
                                                                <asp:BoundField DataField="cnic" HeaderText="CNIC"></asp:BoundField>
                                                            </Columns>
                                                            <FooterStyle CssClass="gridFooterStyle"></FooterStyle>
                                                            <PagerStyle HorizontalAlign="Left" Wrap="True" CssClass="gridPagerStyle"></PagerStyle>
                                                            <HeaderStyle CssClass="gridHeaderStyle"></HeaderStyle>
                                                            <AlternatingRowStyle CssClass="gridAlternateRowStyle"></AlternatingRowStyle>
                                                        </asp:GridView>
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
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
