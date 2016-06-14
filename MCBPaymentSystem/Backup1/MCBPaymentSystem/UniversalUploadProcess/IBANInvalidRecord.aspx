<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IBANInvalidRecord.aspx.cs"
    Inherits="IBANInvalidRecord" Title="IBAN Invalid Records" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="overflow: auto; width: 100%; height: 300px">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label><br />
                    <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Data Found" OnSorting="GridView1_Sorting"
                        Font-Names="Verdana" PageSize="1000000" AutoGenerateColumns="False" AllowSorting="True"
                        Width="100%" Font-Size="8pt">
                        <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
                            LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
                            NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous"
                            Visible="False"></PagerSettings>
                        <Columns>
                            <asp:BoundField DataField="company_code" HeaderText="Company Code" SortExpression="company_code">
                            </asp:BoundField>
                            <asp:BoundField DataField="file_name" HeaderText="File Name" SortExpression="file_name">
                            </asp:BoundField>
                            <asp:BoundField DataField="TRANS_TYPE" HeaderText="Payment Mode" SortExpression="TRANS_TYPE">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="BANK_CODE" HeaderText="Bank Code" SortExpression="BANK_CODE">
                            </asp:BoundField>
                            <asp:BoundField DataField="BANK" HeaderText="Bank Name" SortExpression="BANK">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="BRANCH_CODE" HeaderText="Branch Code" SortExpression="BRANCH_CODE">
                            </asp:BoundField>
                            <asp:BoundField DataField="BRANCH_Name" HeaderText="Branch Name" SortExpression="BRANCH_Name">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="BENENAME" HeaderText="Beneficary Name" SortExpression="BENENAME">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="REMENAME" HeaderText="Remitter Name" SortExpression="REMENAME">
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTACTNUMBER" HeaderText="Contact No." SortExpression="CONTACTNUMBER">
                            </asp:BoundField>
                            <asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account No." SortExpression="ACCOUNTNUMBER">
                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="cnic" HeaderText="CNIC" SortExpression="cnic">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CUSTOMERREFERENCENUMBER" HeaderText="Reference#" SortExpression="CUSTOMERREFERENCENUMBER">
                            </asp:BoundField>
                            <asp:BoundField DataField="XPIN" HeaderText="XPIN" SortExpression="XPIN"></asp:BoundField>
                            
                            <asp:BoundField DataField="TRANSAMOUNT" HeaderText="Amount" SortExpression="TRANSAMOUNT">
                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="REFERENCE#4" HeaderText="IBAN" SortExpression="REFERENCE#4"></asp:BoundField>
                        </Columns>
                        <FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>
                        <PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
