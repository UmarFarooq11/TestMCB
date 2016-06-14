<%@ Page Language="C#" Theme="ColorSchemeBlue" AutoEventWireup="true" CodeFile="LovWHOfile.aspx.cs" Inherits="LOV_LovWHOfile" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../WebControls/AlphaSelection.ascx" TagName="AlphaSelection" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title title=""></title>
    <base target="_self" />

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

</head>
<body style="background-repeat: repeat; text-align: left; vertical-align: middle;
    background-position-x: center; background-attachment: scroll; background-color: #f6f6f6;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
        <contenttemplate>
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
                                        File Name :</td>
                                    <td style="width: 25%; text-align: left">
                                        &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="80%"></asp:TextBox>
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
                                 Text="Search" />
                            <asp:Button ID="Button2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt"
                                 Text="Clear" /></td>
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
                                            /></td>
                                    <td style="width: 0%">
                                        <asp:ImageButton ID="CMD_MoveBack" runat="server" ImageUrl="~/Images/MovePrevious.gif"
                                             /></td>
                                    <td style="width: 0%">
                                        <asp:DropDownList ID="DRP_LIST" runat="server" AutoPostBack="True" 
                                            Style="font-size: 8pt; font-family: Arial, Tahoma" Width="50px">
                                        </asp:DropDownList></td>
                                    <td style="width: 0%">
                                        <asp:ImageButton ID="CMD_MoveNext" runat="server" ImageUrl="~/Images/MoveNext.gif"
                                             /></td>
                                    <td style="width: 0%">
                                        <asp:ImageButton ID="CMD_MoveLast" runat="server" ImageUrl="~/Images/MoveLast.gif"
                                           /></td>
                                </tr>
                            </table>
                
        
            <div>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="FILE_NAME" DataSourceID="ObjectDataSource1"
                    Font-Names="Verdana" Font-Size="8pt" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                    PageSize="20" ShowFooter="True" Style="width: 100%" Width="100%">
                    <pagersettings firstpageimageurl="~/Images/MoveTop.gif" firstpagetext="Move First"
                        lastpageimageurl="~/Images/MoveLast.gif" lastpagetext="Move Last" nextpageimageurl="~/Images/MoveNext.gif"
                        nextpagetext="Move Next" pagebuttoncount="100" position="TopAndBottom" previouspageimageurl="~/Images/MovePrevious.gif"
                        previouspagetext="Move Previous" visible="False" />
                    <footerstyle borderstyle="Solid" borderwidth="1px" />
                    <columns>
                    <asp:BoundField DataField="FILE_NAME" HeaderText="File Name" SortExpression="FILE_NAME" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Select" ImageUrl="~/Images/edit1.gif"
                                OnClientClick="CloseWindow();" OnClick="ImageButton1_Click" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                </columns>
                    <pagerstyle bordercolor="#404040" borderstyle="Solid" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getfilename"
                    TypeName="LOV_COLLECTION" OldValuesParameterFormatString="original_{0}">
                    <selectparameters>
                    <asp:SessionParameter DefaultValue="%" Name="P_FILE_NAME" SessionField="FILE_NAME"
                        Type="String" />
                </selectparameters>
                </asp:ObjectDataSource>
            </div>
            </contenttemplate>
        <%--</asp:UpdatePanel>--%>
    </form>
</body>
</html>
