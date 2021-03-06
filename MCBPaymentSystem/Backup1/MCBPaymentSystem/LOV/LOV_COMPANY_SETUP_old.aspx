<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LOV_COMPANY_SETUP.aspx.cs" Inherits="LOV_LOV_COMPANY_SETUP" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register
Assembly="AjaxControlToolkit"
Namespace="AjaxControlToolkit"
TagPrefix="ajaxToolkit" %>
<%@ Register src="../WebControls/AlphaSelection.ascx" tagname="AlphaSelection" tagprefix="uc1" %> 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="Server">
    <link href="../CENTER_ARROW.CSS" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
</head>

   <script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

function CloseWindow() 
{
    window.close(); 
}

// ]]>
    </script>

<body style="background-repeat: repeat; text-align: left; vertical-align: middle; background-position-x: center; background-attachment: scroll; background-color: #f6f6f6;">
    <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" BackColor="#FFFFEE"
                    CssClass="ajax__tab_xp1" Font-Names="Verdana" Font-Size="8pt" Style="font-size: 8pt;
                    font-family: Verdana">
                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                        <HeaderTemplate>
                            Basic Search
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table style="font-size: 8pt; font-family: Verdana" width="100%">
                                <tr align="right">
                                    <td style="width: 25%; text-align: right">
                                        Company Code :</td>
                                    <td style="width: 25%; text-align: left">
                                        <asp:TextBox ID="TXT_COMPANY_CODE" runat="server" Width="80%"></asp:TextBox>
                                    </td>
                                    <td style="width: 25%; text-align: right">
                                        Company Name :</td>
                                    <td style="width: 25%; text-align: left">
                                        &nbsp;<asp:TextBox ID="TXT_COMPANY_NAME" runat="server" Width="80%"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            Alpha Search
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table style="font-size: 8pt; font-family: Verdana" width="100%">
                                <tr>
                                    <td style="width: 25%; text-align: center">
                                        <asp:RadioButton ID="RD_COMPANY_CODE" runat="server" GroupName="A" Text="Company Code" /></td>
                                    <td style="width: 25%; text-align: center">
                                        <asp:RadioButton ID="RD_COMPANY_NAME" runat="server" GroupName="A" Text="Company Name" /></td>
                                </tr>
                                <tr>
                                </tr>
                            </table>
                            <uc1:AlphaSelection ID="AlphaSelection1" runat="server" />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
                <table width="100%">
                    <tr>
                        <td style="width: 240px">
                            <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt"
                                OnClick="Button1_Click" Text="Search" />
                            <asp:Button ID="Button2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt"
                                OnClick="Button2_Click" Text="Clear" /></td>
                    </tr>
                </table>
                <table cellspacing="0" style="font-size: 10pt; background-color: #f6f6f6" width="100%">
                    <tr>
                        <td class="GridBar" style="width: 98%">
                            <table cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 0%">
                                        <asp:Label ID="LBL_GridStatus" runat="server" SkinID="LBL_STATUS" Width="120px"></asp:Label></td>
                                    <td style="width: 0%">
                                        <asp:Label ID="LBL_RowStatus" runat="server" SkinID="LBL_STATUS" Width="200px"></asp:Label></td>
                                    <td style="width: 100%">
                                    </td>
                                    <td style="width: 0%">
                                        <asp:ImageButton ID="CMD_MoveFirst" runat="server" ImageUrl="~/Images/MoveTop.gif"
                                            OnClick="CMD_MoveFirst_Click" /></td>
                                    <td style="width: 0%">
                                        <asp:ImageButton ID="CMD_MoveBack" runat="server" ImageUrl="~/Images/MovePrevious.gif"
                                            OnClick="CMD_MoveBack_Click" /></td>
                                    <td style="width: 0%">
                                        <asp:DropDownList ID="DRP_LIST" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DRP_LIST_SelectedIndexChanged"
                                            Style="font-size: 8pt; font-family: Arial, Tahoma" Width="50px">
                                        </asp:DropDownList></td>
                                    <td style="width: 0%">
                                        <asp:ImageButton ID="CMD_MoveNext" runat="server" ImageUrl="~/Images/MoveNext.gif"
                                            OnClick="CMD_MoveNext_Click" /></td>
                                    <td style="width: 0%">
                                        <asp:ImageButton ID="CMD_MoveLast" runat="server" ImageUrl="~/Images/MoveLast.gif"
                                            OnClick="CMD_MoveLast_Click" /></td>
                                </tr>
                            </table>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="COMPANY_CODE" DataSourceID="SP_COMPANY_SETUP_ALL"
                    Font-Names="Verdana" Font-Size="8pt" OnRowDataBound="GridView1_RowDataBound"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="20" ShowFooter="True"
                    Style="width: 100%" Width="100%">
                    <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
                        LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
                        NextPageText="Move Next" PageButtonCount="100" Position="TopAndBottom" PreviousPageImageUrl="~/Images/MovePrevious.gif"
                        PreviousPageText="Move Previous" Visible="False" />
                    <FooterStyle BorderStyle="Solid" BorderWidth="1px" />
                    <Columns>
                        <asp:BoundField DataField="COMPANY_CODE" HeaderText="Company Code" SortExpression="COMPANY_CODE" />
                        <asp:BoundField DataField="COMPANY_NAME" HeaderText="Company Name" SortExpression="COMPANY_NAME" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Select" ImageUrl="~/Images/edit1.gif"
                                    OnClick="ImageButton1_Click" OnClientClick="CloseWindow();" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BorderColor="#404040" BorderStyle="Solid" />
                </asp:GridView>
                        </td>
                    </tr>
                </table>
                <asp:ObjectDataSource ID="SP_COMPANY_SETUP_ALL" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Get_Company_setup_lov" TypeName="LOV_COLLECTION">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="%" Name="COMPANYCODE" SessionField="COMPANY_CODE"
                            Type="String" />
                        <asp:SessionParameter DefaultValue="%" Name="COMPANYNAME" SessionField="COMPANY_NAME"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
