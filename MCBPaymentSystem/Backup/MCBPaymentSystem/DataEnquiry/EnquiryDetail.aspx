<%@ Page Language="C#" Theme="SkinFile" AutoEventWireup="true" CodeFile="EnquiryDetail.aspx.cs" Inherits="DataEnquiry_EnquiryDetail" Title="Transaction Enquiry"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">

    <div style="text-align: center;">
        <table style="width: 421px" class="air1">
            <tr>
                <td colspan="2" style="text-align: left">
                    <asp:Label ID="Label1" runat="server" Font-Size="Large" SkinID="FormViewHeading"
                        Text="Transaction Enquiry" Width="100%"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Company Code :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_CompanyCode" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Company Name :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_CompanyName" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Draft No./ XPIN :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_DraftNo" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Amount :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_Amount" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Trans. No. :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_TransNo" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Transaction Date :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_TransactionDate" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Customer Ref # :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_CustomerRef" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Payment Date :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_PaymentDate" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Trans Type :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_TransType" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Transfer Method :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_TransferMethod" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Beneficiary Name :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_BeneficiaryName" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Beneficiary Address :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_BeneficiaryAddress" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Account No. :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_AccountNo" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    CNIC :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_CNIC" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Contact No. :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_ContactNo" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Payee Branch :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_PayeeBranch" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Bank Code :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_BankCode" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Bank Name :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_BankName" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Branch Code :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_BranchCode" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Branch Name :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_BranchName" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Remitter Name :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_RemitterName" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Status :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_Status" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Cancel Date :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_CancelDate" runat="server"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="ColLines1">
                    Remarks :</td>
                <td style="text-align: left" class="ColLines">
                    <asp:Label ID="lbl_Remarks" runat="server"></asp:Label>&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

