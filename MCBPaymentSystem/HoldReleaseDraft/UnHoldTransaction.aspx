<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="UnHoldTransaction.aspx.cs" Inherits="A2ATransaction" Title="MCB - Data Publish" %>

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
    function SelectAllAVA(id)
    {
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


    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <contenttemplate>
<TABLE class="air1" cellSpacing=0 width="100%"><TBODY><TR><TD style="WIDTH: 1%"></TD><TD><asp:Label id="Label1" runat="server" Font-Size="Large" Text="UnHold Transaction" Width="100%" SkinID="FormViewHeading"></asp:Label> </TD><TD style="WIDTH: 1%"></TD></TR><TR><TD colSpan=3>
<HR style="COLOR: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="FONT-WEIGHT: bold; WIDTH: 15%; COLOR: red; TEXT-ALIGN: center" class="ColLines1" colSpan=2>&nbsp;<asp:Label id="lblMessage" runat="server" Font-Bold="True"></asp:Label><asp:UpdateProgress id="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>&nbsp; </TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" class="air" cellSpacing=0 width="100%"><TBODY><TR><TD style="TEXT-ALIGN: right" class="TableColumns">XPIN :&nbsp;&nbsp; </TD><TD class="ColLines1" colSpan=4><asp:TextBox id="txtXpin" runat="server" SkinID="TXT" __designer:wfdid="w2"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: right" class="TableColumns">&nbsp;Customer Ref# : &nbsp;</TD><TD class="ColLines1" colSpan=4><asp:TextBox id="txtCustomerRef" runat="server" SkinID="TXT" __designer:wfdid="w3"></asp:TextBox></TD></TR><TR><TD class="ColLines1">&nbsp; </TD><TD class="ColLines1" colSpan=4><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" Text="Search" Width="100px" Font-Bold="True" __designer:wfdid="w4" ValidationGroup="search" CssClass="btnSearch"></asp:Button>&nbsp;<asp:Button id="btnReset" onclick="btnReset_Click" runat="server" Text="Reset" Width="100px" Font-Bold="True" __designer:wfdid="w5" CssClass="btnSearch"></asp:Button> <asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" Text="Submit" Width="100px" Font-Bold="True" __designer:wfdid="w6" CssClass="btnSearch"></asp:Button></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 100%" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()"><TBODY><TR><TD class="tdCenter" colSpan=5><DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px" onscroll="SetDivPosition()" id="divTest"><asp:GridView id="GridView1" runat="server" Font-Size="8pt" Width="100%" EmptyDataText="No data found." OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" Font-Names="Verdana" PageSize="5">
<PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First" LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif" NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous" Visible="False"></PagerSettings>
<Columns>
<asp:BoundField DataField="ROWID" HeaderText="Row ID">
<HeaderStyle CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TRANS_TYPE" HeaderText="Payment Mode">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="company_name" HeaderText="Company Name"></asp:BoundField>
<asp:BoundField DataField="bank_code" HeaderText="Bank Code"></asp:BoundField>
<asp:BoundField DataField="bank_name" HeaderText="Bank Name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="branch_code" HeaderText="Branch Code"></asp:BoundField>
<asp:BoundField DataField="branch_name" HeaderText="Branch Name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="custrefnumber" HeaderText="Reference #"></asp:BoundField>
<asp:BoundField DataField="draftno" HeaderText="XPIN"></asp:BoundField>
<asp:BoundField DataField="draftamount" HeaderText="Amount">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField><HeaderTemplate>
<asp:CheckBox id="Ckb_SelectALL" runat="server"></asp:CheckBox>
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="cbPublish" runat="server" __designer:wfdid="w7"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status"><ItemTemplate>
<asp:Label id="lblStatus" runat="server" Text="" __designer:wfdid="w8"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>

<PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:GridView> </DIV></TD></TR><TR><TD class="tdCenter" colSpan=5></TD></TR><TR><TD class="tdRight" colSpan=5>&nbsp;</TD></TR></TBODY></TABLE>
<HR style="COLOR: gainsboro" />
</TD></TR></TBODY></TABLE>
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
