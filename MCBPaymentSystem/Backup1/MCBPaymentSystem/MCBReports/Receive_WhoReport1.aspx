<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Receive_WhoReport1.aspx.cs"
    Inherits="MCBReports_TESTREPORT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script language="javascript" type="text/javascript">
    
         function FILENAME() 
    {

        var a;
        var c='<%= Session["HEIGHT"] %>';
        var b='<%= Session["WIDTH"] %>';
     a=window.showModalDialog('../LOV/LOV_FILENAME.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
 //a=window.showModalDialog('../LOV/LOV_CITY_ALL.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
    }

  function beneaddress()
    {

        var a;
        var c='<%= Session["HEIGHT"] %>';
        var b='<%= Session["WIDTH"] %>';
        a=window.showModalDialog('../LOV/LOV_beneaddress.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
    }
    
   function REMENAME()
    {

        var a;
        var c='<%= Session["HEIGHT"] %>';
        var b='<%= Session["WIDTH"] %>';
        a=window.showModalDialog('../LOV/LOV_REMETTER_NAME.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
    }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/search_16x16.png"
                OnClick="ImageButton1_Click" OnClientClick="FILENAME();" />--%>
            <table cellspacing="0" width="100%">
                <tr>
                    <td>
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <contenttemplate>--%>
                        <asp:Label ID="lbl_Heading" runat="server" Text="RECEIVE - WHO REPORT" Width="100%"
                            SkinID="FormViewHeading" Font-Size="Large" CssClass="lblHeading"></asp:Label>
                        <hr style="color: darkgray" />
                        <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                            <tbody>
                                <tr align="right">
                                    <td style="font-weight: bold; color: red; text-align: center" class="TableColumns"
                                        colspan="5">
                                        <asp:Label ID="lblmessage" runat="server" CssClass="lblMessage"></asp:Label>
                                        <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>--%>
                                    </td>
                                </tr>
                                <tr align="right">
                                    <td style="font-weight: bold; height: 15px; text-align: right" colspan="2">
                                    </td>
                                    <td style="height: 15px; text-align: left" colspan="1">
                                    </td>
                                    <td style="font-weight: bold; width: 94px; height: 15px; text-align: right" colspan="1">
                                    </td>
                                    <td style="font-weight: bold; color: red; height: 15px; text-align: left" width="50%"
                                        colspan="1">
                                    </td>
                                </tr>
                                <tr align="right">
                                    <td style="font-weight: bold; text-align: right" class="TableColumns" colspan="2">
                                        File name :
                                    </td>
                                    <td style="font-weight: bold; width: 30%; color: red; height: 28px; text-align: left"
                                        class="ColLines" colspan="1">
                                        <%--<asp:updatepanel id="UpdatePanel1" runat="server">--%>
                                        <contenttemplate>
                                            <asp:TextBox ID="txt_filename" runat="server" Width="200px"></asp:TextBox>
                                    <asp:ImageButton ID="btnLov" OnClick="btnLov_Click" runat="server" CommandName="Select"
                                        OnClientClick="FILENAME();" ImageUrl="~/Images/search_16x16.png" CausesValidation="False"></asp:ImageButton>
                                       <%-- </ContentTemplate>
                                    </asp:updatepanel>--%>
                                    </td>
                                    <td style="font-weight: bold; text-align: right" class="TableColumns" colspan="1">
                                        Beneficiary Address :</td>
                                    <td style="font-weight: bold; width: 30%; color: red; height: 28px; text-align: left"
                                        class="ColLines" colspan="1">
                                        &nbsp;<asp:TextBox ID="txtBeneAddress" runat="server" Width="200px"></asp:TextBox>&nbsp;<asp:ImageButton
                                            ID="ImageButton1" OnClick="ImageButton1_Click" runat="server" CommandName="Select"
                                            OnClientClick="beneaddress();" ImageUrl="~/Images/search_16x16.png" Enabled="False">
                                        </asp:ImageButton></td>
                                </tr>
                                <tr align="right">
                                    <td style="font-weight: bold; width: 20%; height: 28px; text-align: right" class="TableColumns"
                                        colspan="2">
                                        Remitter Name :</td>
                                    <td style="font-weight: bold; width: 30%; color: red; height: 28px; text-align: left"
                                        class="ColLines" colspan="1">
                                        &nbsp;<asp:TextBox ID="txtRemitterName" runat="server" Width="200px"></asp:TextBox>&nbsp;<asp:ImageButton
                                            ID="LOV_REMEADDRESS" OnClick="LOV_REMEADDRESS_Click" runat="server" CommandName="Select"
                                            OnClientClick="REMENAME();" ImageUrl="~/Images/search_16x16.png" Enabled="False">
                                        </asp:ImageButton></td>
                                    <td style="font-weight: bold; width: 94px; height: 28px; text-align: right" class="TableColumns"
                                        colspan="1">
                                    </td>
                                    <td style="font-weight: bold; width: 30%; color: red; height: 28px; text-align: left"
                                        colspan="1">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr align="right">
                                    <td style="font-weight: bold; text-align: right" class="TableColumns" colspan="2">
                                        From Date :
                                    </td>
                                    <td style="font-weight: bold; width: 30%; color: red; text-align: left" class="ColLines"
                                        colspan="1">
                                        &nbsp;<asp:TextBox ID="TXT_FROM" runat="server" Width="100px" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFV_TXTFROM" runat="server" Enabled="False" ErrorMessage="*"
                                            ControlToValidate="TXT_FROM" ValidationGroup="GP"></asp:RequiredFieldValidator>
                                    </td>
                                    <td style="font-weight: bold; text-align: right" class="TableColumns" colspan="1">
                                        To Date :
                                    </td>
                                    <td style="font-weight: bold; width: 30%; color: red; text-align: left" class="ColLines"
                                        colspan="1">
                                        &nbsp;<asp:TextBox ID="TXT_TO" runat="server" Width="100px" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFV_TXTTO" runat="server" Enabled="False" ErrorMessage="*"
                                            ControlToValidate="TXT_TO" ValidationGroup="GP"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr align="right">
                                    <td style="font-weight: bold; color: red; height: 26px; text-align: center" class="ColLines"
                                        colspan="5">
                                        <asp:Button ID="btn_OK" OnClick="btn_OK_Click" runat="server" Text="Fetch" Width="78px"
                                            ValidationGroup="GP" Font-Bold="True"></asp:Button>
                                        &nbsp;<asp:Button ID="btnExcel" OnClick="btnExcel_Click" runat="server" Text="Export To Excel"
                                            Font-Bold="True"></asp:Button>&nbsp;
                                    </td>
                                </tr>
                                <tr align="right">
                                </tr>
                                <tr align="right">
                                </tr>
                            </tbody>
                        </table>
                        <%--</contenttemplate>
                    </asp:UpdatePanel>--%>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
