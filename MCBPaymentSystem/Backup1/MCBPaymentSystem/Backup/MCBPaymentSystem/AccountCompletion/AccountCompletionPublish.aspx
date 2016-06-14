<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="AccountCompletionPublish.aspx.cs" Inherits="AccountCompletionPublish"
    Title="MCB - Data Publish" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    function SelectAll(id)
    {
       var frm1 = document.getElementById('<%= this.GridView1.ClientID %>');
       var frm = document.forms[0];
       for (i=0;i<frm.elements.length;i++)
       {
           if (frm.elements[i].type == "checkbox")
           {
               frm.elements[i].checked = document.getElementById(id).checked;
           }
       }
    }
    function BankLOV(rowIndex,hiddenfield) 
    {
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
    var frm = document.forms[0];
    var checked = '';
    for (i=0;i<frm.elements.length;i++)
    {
        if (frm.elements[i].type == "checkbox")
        {
            if(frm.elements[i].checked == true)
            {
                checked = 'yes';   
            }
        }
    }
    if(checked == 'yes')
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
    else
    {
        alert("Please check mark any one.");
    }
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
                                    <asp:Label ID="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="Data Publish"
                                        Font-Size="Large">
                                    </asp:Label>
                                </td>
                                <td style="width: 1%">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <hr style="color: darkgray" />
                                    <table class="air" cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%">
                                        <tbody>
                                            <tr align="right">
                                                <td style="font-weight: bold; width: 15%; color: red; text-align: center" class="ColLines1"
                                                    colspan="2">
                                                    &nbsp;<asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label><asp:UpdateProgress
                                                        ID="UpdateProgress1" runat="server">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table style="width: 100%" class="air1">
                                        <tbody>
                                            <tr>
                                                <td style="width: 25%; text-align: right" class="TableColumns">
                                                    Agent :&nbsp;
                                                </td>
                                                <td style="text-align: left" class="ColLines1" colspan="4">
                                                    <asp:DropDownList ID="ddlCompanyCode" runat="server" Width="355px" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged"
                                                        AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td class="ColLines1">
                                                    &nbsp;&nbsp;</td>
                                                <td style="text-align: left" class="ColLines1" colspan="4">
                                                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Width="100px"
                                                        Text="Submit" Font-Bold="True" CssClass="btnSearch"></asp:Button></td>
                                            </tr>
                                            <tr>
                                                <td class="ColLines1" colspan="5">
                                                    <div style="overflow: auto; width: 100%; height: 180px">
                                                        <asp:GridView ID="GridView2" runat="server" Width="100%" Font-Size="8pt" OnRowCommand="GridView2_RowCommand"
                                                            PageSize="5" Font-Names="Verdana" OnRowDataBound="GridView2_RowDataBound" AutoGenerateColumns="False"
                                                            EmptyDataText="DATA NOT FOUND">
                                                            <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
                                                                LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
                                                                NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous"
                                                                Visible="False"></PagerSettings>
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="File Name">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox runat="server" Text='<%# Bind("File_name") %>' ID="TextBox1"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbfile_name" runat="server" Text='<%# Bind("File_name") %>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="total_records" HeaderText="Total Records"></asp:BoundField>
                                                                <asp:BoundField DataField="min_trans" HeaderText="Start Trans. No."></asp:BoundField>
                                                                <asp:BoundField DataField="max_trans" HeaderText="End Trans. No."></asp:BoundField>
                                                                <asp:BoundField DataField="Publish" HeaderText="Status"></asp:BoundField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="Ckb_SelectALL" runat="server"></asp:CheckBox>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="Ckb_Select" runat="server"></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>
                                                            <PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>
                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                            <EmptyDataRowStyle Font-Size="30pt" ForeColor="LightSteelBlue" HorizontalAlign="Center"
                                                                VerticalAlign="Middle" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                    <div style="overflow: auto; width: 100%; height: 300px">
                                                        <asp:GridView ID="GridView1" runat="server" Width="100%" Font-Size="8pt" PageSize="5"
                                                            Font-Names="Verdana" AutoGenerateColumns="False">
                                                            <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
                                                                LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
                                                                NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous"
                                                                Visible="False"></PagerSettings>
                                                            <Columns>
                                                                <asp:BoundField DataField="ROWID" HeaderText="Row ID">
                                                                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                                                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="TRANS_TYPE" HeaderText="Payment Mode">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="bank_code" HeaderText="Bank Code"></asp:BoundField>
                                                                <asp:BoundField DataField="BANK" HeaderText="Bank Name">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="branch_code" HeaderText="Branch Code"></asp:BoundField>
                                                                <asp:BoundField DataField="BRANCH_Name" HeaderText="Branch Name">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="BENENAME" HeaderText="Beneficary Name">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="REMENAME" HeaderText="Remitter Name">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CONTACTNUMBER" HeaderText="Contact No."></asp:BoundField>
                                                                <asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account No.">
                                                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CNIC" HeaderText="CNIC"></asp:BoundField>
                                                                <asp:BoundField DataField="CUSTOMERREFERENCENUMBER" HeaderText="Reference #"></asp:BoundField>
                                                                <asp:BoundField DataField="XPIN" HeaderText="XPIN"></asp:BoundField>
                                                                <asp:BoundField DataField="TRANSAMOUNT" HeaderText="Amount">
                                                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbPublish" runat="server"></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>
                                                            <PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>
                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                            <EmptyDataRowStyle Font-Size="30pt" ForeColor="LightSteelBlue" HorizontalAlign="Center"
                                                                VerticalAlign="Middle" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="loginDown" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
