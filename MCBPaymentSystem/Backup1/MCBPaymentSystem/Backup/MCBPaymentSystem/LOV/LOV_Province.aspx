<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LOV_Province.aspx.cs" Inherits="Forms_LOV_Bank"
    Title="List of Province" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Selection of Province</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;
            <asp:GridView ID="grvBank" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Font-Names="Arial" Font-Size="8pt" ForeColor="#333333" GridLines="None" Height="1px"
                OnRowCommand="grvBank_RowCommand" OnRowDataBound="grvBank_RowDataBound" Width="303px"
                DataKeyNames="FILE_NAME">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Activity Ref. No." SortExpression="FILE_NAME">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FILE_NAME") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            &nbsp;
                            <asp:LinkButton ID="lnkCode" runat="server" CausesValidation="False" CommandArgument='<%# Bind("FILE_NAME") %>'
                                CommandName="View" ForeColor="Black" Text='<%# Bind("FILE_NAME") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EmptyDataTemplate>
                    <asp:LinkButton ID="linkbtn" runat="server">LinkButton</asp:LinkButton>
                </EmptyDataTemplate>
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
            </asp:GridView>
            <br />
            <br />
            &nbsp;
        </div>
    </form>
</body>
</html>
