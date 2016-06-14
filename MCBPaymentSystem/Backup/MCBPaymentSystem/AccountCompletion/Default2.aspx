<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>--%>

<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="Default2.aspx.cs" Inherits="Default2" Title="MCB -Cash Payment" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
    function lov()
    {
        
        var a;
        var c='<%= Session["HEIGHT"] %>';
        var b='<%= Session["WIDTH"] %>';
        a=window.showModalDialog('LOV.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');

    }
    
    function rowsIndex(index)
    {
        document.getElementById("<%=hdRows.ClientID%>").value = index;
        alert(index);
    }
    $(function() {
     $("#ctl00_ContentPlaceHolder1_sort_table").dataTable();
    });
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="small_container">
                            <div style="overflow: auto; width: 100%; height: 900px">
                                <asp:GridView ID="sort_table" runat="server" Font-Size="8pt" Width="90%" 
                                    AutoGenerateColumns="False"  Font-Names="Verdana"
                                    PageSize="20" AllowSorting="True" >
                                    <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
                                        LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
                                        NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous"
                                        Visible="False"></PagerSettings>
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
                                        <asp:BoundField DataField="BENEADDRESS" HeaderText="Beneficary Address" SortExpression="BENEADDRESS">
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TRANSAMOUNT" HeaderText="Amount" SortExpression="TRANSAMOUNT">
                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account No." SortExpression="ACCOUNTNUMBER">
                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BRANCH_Code" HeaderText="Branch" SortExpression="BRANCH_Code">
                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Select Branch">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("BRANCH_code") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtBranchCode" runat="server" Width="163px" SkinID="TXT" Height="17px"
                                                    TextMode="MultiLine"></asp:TextBox>
                                                <asp:ImageButton ID="btnLov" runat="server" ImageUrl="~/Images/search_16x16.png"
                                                    CommandName="Select"></asp:ImageButton>
                                                <asp:HiddenField ID="hf_BranchCode" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>
                                    <PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:GridView>
                            </div>
                            <%--<asp:GridView ID="sort_table" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="Empno" HeaderText="Empno" />
                                    <asp:BoundField DataField="ename" HeaderText="Ename" />
                                    <asp:BoundField DataField="sal" HeaderText="Salary" />
                                </Columns>
                            </asp:GridView>--%>
                            <asp:HiddenField ID="hdRows" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
