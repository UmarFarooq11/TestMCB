<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true" CodeFile="IBANIdentificy.aspx.cs" Inherits="IBANIdentificy"
    Title="MCB - IBAN Identification" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    
    
    function SelectAll(id)
    {
       var frm1 = document.getElementById('<%= this.grdTransaction.ClientID %>');
       var frm = document.forms[0];
       for (i=0;i<frm.elements.length;i++)
       {
           if (frm.elements[i].type == "checkbox")
           {
               frm.elements[i].checked = document.getElementById(id).checked;
           }
       }
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
    
     function funConfirm_All()
   {
        var a = confirm('Are you sure to Execute All Transaction?');
        if (a == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
    
    
     window.onload = function(){
        var strCook = document.cookie;
        if(strCook.indexOf("!~")!=0){
          var intS = strCook.indexOf("!~");
          var intE = strCook.indexOf("~!");
          var strPos = strCook.substring(intS+2,intE);
          document.getElementById("divTest").scrollTop = strPos;
        }
      }
      function SetDivPosition()
      {
        var intY = document.getElementById("divTest").scrollTop;
        document.title = intY;
        document.cookie = "yPos=!~" + intY + "~!";
      }
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table cellspacing="0" width="100%">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="IBAN  Identification"
                                            Width="100%" SkinID="FormViewHeading"></asp:Label><br />
                                        <table class="login" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr align="right">
                                                    <td style="font-weight: bold; width: 15%; color: red; text-align: center" class="ColLines1"
                                                        colspan="2">
                                                        &nbsp;<asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label><asp:UpdateProgress
                                                            ID="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr align="right">
                                                </tr>
                                                <tr align="right">
                                                </tr>
                                            </tbody>
                                        </table>
                                        <table style="width: 100%" class="air1">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 25%; text-align: right" class="ColLines1">
                                                        Agent :</td>
                                                    <td class="ColLines" colspan="3">
                                                        <asp:DropDownList ID="ddlCompanyCode" runat="server" __designer:dtid="1407374883553311"
                                                            Width="355px" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged" AutoPostBack="True"
                                                            __designer:wfdid="w109">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right" class="ColLines1">
                                                        File :</td>
                                                    <td class="ColLines">
                                                        <asp:DropDownList ID="ddlFile" runat="server" Width="355px" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList></td>
                                                    <td style="text-align: right" class="ColLines">
                                                        <asp:Label ID="lblTotalFile" runat="server" Text="File Total Records :"></asp:Label>&nbsp;</td>
                                                    <td style="text-align: left" class="ColLines">
                                                        <asp:Label ID="lblTotalRecord" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="ColLines1">
                                                        &nbsp;</td>
                                                    <td style="text-align: left" class="ColLines">
                                                        <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Fetch"
                                                            Width="100px" Font-Bold="True" CssClass="btnSearch" ValidationGroup="search"></asp:Button>&nbsp;&nbsp;<asp:Button
                                                                ID="btnConvertAll" OnClick="btnConvertAll_Click" runat="server" Text="Convert All"
                                                                Width="100px" Font-Bold="True" __designer:wfdid="w1" CssClass="btnSearch" ValidationGroup="search"
                                                                Visible="False"></asp:Button>
                                                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit"
                                                            Width="100px" Font-Bold="True" CssClass="btnSearch"></asp:Button>&nbsp;</td>
                                                    <td style="text-align: right" class="ColLines">
                                                        <asp:Label ID="lblFieldTrans" runat="server" Text="No. of Transaction :" Width="135px"></asp:Label></td>
                                                    <td style="text-align: left" class="ColLines">
                                                        <asp:Label ID="lblTransaction" runat="server"></asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">
                                                        <div style="overflow: auto; width: 100%; height: 300px" onscroll="SetDivPosition()"
                                                            id="divTest">
                                                            <asp:GridView ID="grdTransaction" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdTransaction_RowDataBound"
                                                                PageSize="1000000" EmptyDataText="No data found.">
                                                                <PagerSettings Visible="False"></PagerSettings>
                                                                <Columns>
                                                                    <asp:BoundField DataField="ROWID" HeaderText="ROWID" SortExpression="ROWID">
                                                                        <HeaderStyle CssClass="hidden"></HeaderStyle>
                                                                        <ItemStyle CssClass="hidden"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account No" SortExpression="ACCOUNTNUMBER">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="CNIC" HeaderText="CNIC" SortExpression="CNIC"></asp:BoundField>
                                                                    <asp:BoundField DataField="branch_code" HeaderText="Branch Code" SortExpression="branch_code">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="iban" HeaderText="IBAN in File"></asp:BoundField>
                                                                    <asp:BoundField DataField="reference_no" HeaderText="Customer Reference Number"></asp:BoundField>
                                                                    <asp:TemplateField HeaderText="BAN To IBAN" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnBanToIBAN" OnClick="btnBanToIBAN_Click" runat="server" Text="Submit"
                                                                                __designer:wfdid="w2"></asp:Button>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Input IBAN">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtIBAN" runat="server" __designer:wfdid="w2"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="Ckb_SelectALL" runat="server" __designer:wfdid="w4" AutoPostBack="True">
                                                                            </asp:CheckBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="Ckb_Select" runat="server" __designer:wfdid="w3"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <FooterStyle CssClass="gridFooterStyle"></FooterStyle>
                                                                <HeaderStyle CssClass="gridHeaderStyle"></HeaderStyle>
                                                                <AlternatingRowStyle CssClass="gridAlternateRowStyle"></AlternatingRowStyle>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
