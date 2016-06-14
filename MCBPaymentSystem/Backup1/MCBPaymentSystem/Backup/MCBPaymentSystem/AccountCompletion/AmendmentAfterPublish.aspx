<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="AmendmentAfterPublish.aspx.cs" Inherits="AmendmentAfterPublish" Title="MCB - Amendment After Publish" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function BankLOV(rowIndex, hiddenfield) {
            document.getElementById('<%=hdRowIndex.ClientID %>').value = rowIndex;
            var a;
            var c = '<%= Session["HEIGHT"] %>';
            var b = '<%= Session["WIDTH"] %>';
            a = window.showModalDialog('../LOV/LOV_SETUP_BRANCH.aspx', null, 'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
        }
        function AGENTLOV() {
            var a;
            var c = '<%= Session["HEIGHT"] %>';
            var b = '<%= Session["WIDTH"] %>';
            a = window.showModalDialog('../LOV/LOV_Company.aspx', null, 'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
        }
        function funConfirm() {
            var a = confirm('Are you sure to Execute?');
            if (a == true) {
                return true;
            }
            else {
                return false;
            }
        }
        function OnConfirmGV() {
            var a = confirm('Are you sure to Execute?');
            if (a == true) {
                return true;
            }
            else {
                return false;
            }
        }
        function OnConfirmAuth() {
            var a = confirm('Are you sure to Authorize?');
            if (a == true) {
                return true;
            }
            else {
                return false;
            }
        }

        function OnConf32342irmAuth() {
            return confirm('Are you sure you want to delete this entry?');
        }


    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table cellspacing="0" class="air1" width="100%">
                            <tr>
                                <td style="width: 1%">
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="Amendment Post Publish Only A2A"
                                        Font-Size="Large" ToolTip="Amendment Post Publish Only A2A"></asp:Label>
                                </td>
                                <td style="width: 1%">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <hr style="color: darkgray" />
                                    <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr align="right">
                                                <td style="font-weight: bold; width: 15%; color: red; text-align: center" class="ColLines1"
                                                    colspan="2">
                                                    &nbsp;
                                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True">
                                                    </asp:Label><asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="air" cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 25%; text-align: right" class="TableColumns">
                                                    Agent :&nbsp;
                                                </td>
                                                <td class="ColLines" colspan="4">
                                                    <asp:DropDownList ID="ddlCompanyCode" runat="server" Width="355px" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged"
                                                        AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right" class="TableColumns">
                                                    File :&nbsp;
                                                </td>
                                                <td class="ColLines">
                                                    <asp:DropDownList ID="ddlFile" runat="server" SkinID="TXT" Width="355px" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged"
                                                        AutoPostBack="True" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="text-align: right" class="ColLines1" colspan="2">
                                                    <asp:Label ID="lblTotalFile" runat="server" Text="File Total Records :"></asp:Label>&nbsp;
                                                </td>
                                                <td style="text-align: left" class="ColLines">
                                                    <asp:Label ID="lblTotalRecord" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="ColLines1">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: left" class="ColLines">
                                                    <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Width="100px"
                                                        Text="Search" Font-Bold="True" CssClass="btnSearch" ValidationGroup="search">
                                                    </asp:Button>
                                                </td>
                                                <td style="text-align: right" class="ColLines1" colspan="2">
                                                    &nbsp;<asp:Label ID="lblFieldTrans" runat="server" Width="130px" Text="No. of Transaction :"></asp:Label>
                                                </td>
                                                <td style="text-align: left" class="ColLines">
                                                    <asp:Label ID="lblTransaction" runat="server"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdCenter" colspan="5">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdRight" colspan="5">
                                                    <asp:HiddenField ID="hdRowIndex" runat="server"></asp:HiddenField>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <hr style="color: gainsboro" />
                                    <asp:Panel ID="Panel1" runat="server" Width="970px" Height="300px" ScrollBars="Both"
                                        __designer:wfdid="w2">
                                        <asp:GridView ID="GridView1" runat="server" Font-Size="8pt" SkinID="PSGV" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                            __designer:wfdid="w1" AllowSorting="True" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                            AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" Font-Names="Verdana"
                                            PageSize="1000000" OnSorting="GridView1_Sorting" OnRowUpdating="GridView1_RowUpdating"
                                            OnRowEditing="GridView1_RowEditing">
                                            <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
                                                LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
                                                NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous"
                                                Visible="False"></PagerSettings>
                                            <Columns>
                                                <asp:BoundField DataField="ROWID" HeaderText="Row ID">
                                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TRANS_TYPE" HeaderText="Payment Mode" ReadOnly="True"
                                                    SortExpression="TRANS_TYPE">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="bank_code" HeaderText="Bank Code" ReadOnly="True" SortExpression="bank_code">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BANK" HeaderText="Bank Name" ReadOnly="True" SortExpression="BANK">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="branch_code" HeaderText="Branch Code" ReadOnly="True"
                                                    SortExpression="branch_code"></asp:BoundField>
                                                <asp:BoundField DataField="BRANCH_Name" HeaderText="Branch Name" ReadOnly="True"
                                                    SortExpression="BRANCH_Name">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BENENAME" HeaderText="Beneficary Name" SortExpression="BENENAME">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="REMENAME" HeaderText="Remitter Name" ReadOnly="True" SortExpression="REMENAME">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CONTACTNUMBER" HeaderText="Contact No." ReadOnly="True"
                                                    SortExpression="CONTACTNUMBER"></asp:BoundField>
                                                <asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account No." SortExpression="ACCOUNTNUMBER">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CNIC" HeaderText="CNIC" ReadOnly="True" SortExpression="CNIC">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CUSTOMERREFERENCENUMBER" HeaderText="Reference #" ReadOnly="True"
                                                    SortExpression="CUSTOMERREFERENCENUMBER"></asp:BoundField>
                                                <asp:BoundField DataField="XPIN" HeaderText="XPIN" ReadOnly="True" SortExpression="XPIN">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TRANSAMOUNT" HeaderText="Amount" ReadOnly="True" SortExpression="TRANSAMOUNT">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="auth_status" HeaderText="Transaction Status" ReadOnly="True"
                                                    SortExpression="auth_status"></asp:BoundField>
                                                <asp:BoundField DataField="system_reply" HeaderText="Message" ReadOnly="True"
                                                    SortExpression="system_reply"></asp:BoundField>    
                                                <asp:CommandField ShowEditButton="True" HeaderText="Action"></asp:CommandField>
                                                <asp:CommandField SelectText="Authorize" ShowSelectButton="True" HeaderText="Action">
                                                </asp:CommandField>
                                                <asp:BoundField DataField="beneficiaryid" HeaderText="beneficiaryid">
                                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>
                                            <PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
