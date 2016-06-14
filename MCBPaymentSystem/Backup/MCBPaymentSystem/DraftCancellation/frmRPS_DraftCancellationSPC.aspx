<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="frmRPS_DraftCancellationSPC.aspx.cs" Inherits="DraftCancellation_frmRPS_DraftCancellationSPC"
    Title="Draft CancellationDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--   <style type="text/css">
.barmodal
{
    position: fixed;
    z-index: 999;
    height: 100%;
    width: 100%;
    top: 0;
    background-color: Black;
    filter: alpha(opacity=60);
    opacity: 0.6;
    -moz-opacity: 0.8;
}
.barpanel
{
    z-index: 1000;
    margin: 1px auto;
    padding: 10px;
    width: 200px;
    /*background-color: White;*/
    border-radius: 10px;
    filter: alpha(opacity=100);
    opacity: 1;
    -moz-opacity: 1;
}
</style>--%>

    <script language="javascript" type="text/javascript">

        function DraftLOV() 
        {
            var a;
            var c='<%= Session["HEIGHT"] %>';
            var b='<%= Session["WIDTH"] %>';
            a=window.showModalDialog('../LOV/LOV_Draft.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
        }
        function CancelLOV() 
        {
            var a;
            var height='<%= Session["HEIGHT"] %>';
            var width='<%= Session["WIDTH"] %>';
            a=window.showModalDialog('../LOV/LOV_DetailCode.aspx',null,'status:no;dialogWidth:' + width + ' px;dialogHeight:' + height + ' px;dialogHide:true;help:no;scroll:yes');
        }

        function SearchCancelCodeEdit()
        {
            document.getElementById("ctl00_ContentPlaceHolder1_BTN_CancelCodeSearch_Edit").click();
            return false;
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" class="air1" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" SkinID="FormViewHeading" Text="Draft Cancellation"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 1px">
                        <table cellspacing="0" class="air" width="100%">
                            <hr style="color: Gray" />
                            &nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Submit" Width="87px" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Back" Width="85px" OnClick="btnCancel_Click" /><tr>
                                <td style="width: 25%; text-align: right">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%; text-align: right">
                                </td>
                                <td>
                                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%; text-align: right" class="TableColumns">
                                    Company Code :
                                </td>
                                <td class="ColLines">
                                    <asp:TextBox ID="txtCompanyCode" ReadOnly="true" runat="server" Width="73px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%; text-align: right" class="TableColumns">
                                    Company Name :
                                </td>
                                <td class="ColLines">
                                    <asp:TextBox ID="txtCompanyName" ReadOnly="true" runat="server" Width="211px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%; text-align: right" class="TableColumns">
                                    Draft No. :
                                </td>
                                <td class="ColLines">
                                    <asp:TextBox ID="txtDraftNo" ReadOnly="true" runat="server" Width="211px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%; text-align: right" class="TableColumns">
                                    Customer Ref# :
                                </td>
                                <td class="ColLines">
                                    <asp:TextBox ID="txtCustomerRef" ReadOnly="true" runat="server" Width="211px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%; text-align: right" class="TableColumns">
                                    Transaction Amount :
                                </td>
                                <td class="ColLines">
                                    <asp:TextBox ID="txtAmount" ReadOnly="true" runat="server" Width="211px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%; text-align: right" class="TableColumns">
                                    Bank Code :
                                </td>
                                <td class="ColLines">
                                    <asp:TextBox ID="txtBankCode" ReadOnly="true" runat="server" Width="211px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%; text-align: right" class="TableColumns">
                                    Bank Name :
                                </td>
                                <td class="ColLines">
                                    <asp:TextBox ID="txtBankName" ReadOnly="true" runat="server" Width="211px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableColumns" style="width: 25%; text-align: right">
                                    Transaction Type :
                                </td>
                                <td class="ColLines">
                                    <asp:TextBox ID="txtTransType" runat="server" ReadOnly="true" Width="73px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%; text-align: right" class="TableColumns">
                                    Cancel Code :
                                </td>
                                <td class="ColLines">
                                    <asp:DropDownList ID="ddlCancelCode" runat="server" Width="235px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%; text-align: right" class="TableColumns">
                                    Cancel Action :
                                </td>
                                <td class="ColLines">
                                    <asp:DropDownList ID="ddlCancelAction" runat="server" Width="235px">
                                        <asp:ListItem Value="R">Refund</asp:ListItem>
                                        <asp:ListItem Value="S">Re-Issue with same Ref No.</asp:ListItem>
                                        <asp:ListItem Value="C">Re-Issue with C</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%; text-align: right">
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
