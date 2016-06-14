<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true" CodeFile="PRI_Upload_OB.aspx.cs" Inherits="PRI_Upload_OB" Title="SPDS - PRI-Upload other Bank" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    function CustomerLOV() 
{
    var a;
    var c='<%= Session["HEIGHT"] %>';
    var b='<%= Session["WIDTH"] %>';
    a=window.showModalDialog('../LOV/LOV_Customer.aspx',null,'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
}
function SearchBankCodeInsert()
{
    document.getElementById("ctl00_ContentPlaceHolder1_btnCustomerCodeSearch").click();
    return false;
}
</script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellspacing="0" class="air1" width="100%">
        <tr>
            <td colspan="3" style="height: 1px">
    <asp:UpdatePanel id="UpdatePanel2" runat="server">
        <contenttemplate>
<TABLE cellSpacing=0 width="100%"><TBODY><TR><TD></TD><TD><asp:Label id="Label1" runat="server" SkinID="FormViewHeading" Width="100%" Text="PRI Upload other Bank" Font-Size="Large"></asp:Label> <TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" class="air" cellSpacing=0 width="100%"><TBODY><TR><TD style="TEXT-ALIGN: left" class="ColLines" colSpan=2><asp:Button id="btnGenerate" tabIndex=8 onclick="btnGenerate_Click" runat="server" Width="79px" Text="Upload" Font-Bold="True"></asp:Button> <asp:Button id="Button1" tabIndex=8 onclick="Button1_Click" runat="server" Width="79px" Text="Refresh" Font-Bold="True"></asp:Button>&nbsp;&nbsp;</TD></TR></TBODY></TABLE>
<HR style="COLOR: darkgray" />
<TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" cellSpacing=0 width="100%"><TBODY><TR align=right><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: center" colSpan=2><asp:Label id="lbl_Message" runat="server" CssClass="lblMessage"></asp:Label>&nbsp; </TD></TR><TR align=right></TR><TR align=right></TR></TBODY></TABLE><TABLE style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" class="air" cellSpacing=0 width="100%"><TBODY><TR><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">Customer :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines"><asp:UpdatePanel id="UpdatePanel1" runat="server"><ContentTemplate>
&nbsp;<asp:TextBox id="txtCustomerCode" tabIndex=1 runat="server" Width="50px" SkinID="TXT" MaxLength="4"></asp:TextBox> <asp:ImageButton id="btnCustomerCode" tabIndex=2 onclick="btnCustomerCode_Click" runat="server" CssClass="imagebtnlov" ImageUrl="~/images/search_16x16.png" OnClientClick="CustomerLOV() "></asp:ImageButton> <asp:TextBox id="txtCustomerName" tabIndex=3 runat="server" Width="200px" SkinID="TXT" MaxLength="50" Enabled="False"></asp:TextBox> <asp:RequiredFieldValidator id="rfvCustomerCode" runat="server" ValidationGroup="group" ErrorMessage="Proper Information Required" ControlToValidate="txtCustomerCode"></asp:RequiredFieldValidator> <cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCustomerCode" FilterType="Numbers"></cc1:FilteredTextBoxExtender> <asp:Button id="btnCustomerCodeSearch" onclick="btnCustomerCodeSearch_Click" runat="server" Text="." OnClientClick="SearchBankCodeInsert();"></asp:Button>
</ContentTemplate>
</asp:UpdatePanel></TD></TR><TR><TD style="WIDTH: 15%; COLOR: red; TEXT-ALIGN: right" class="ColLines1">File Name :</TD><TD style="WIDTH: 35%; TEXT-ALIGN: left" class="ColLines">&nbsp; <asp:DropDownList id="TXT_Description" runat="server" Width="300px">
    </asp:DropDownList></TD></TR></TBODY></TABLE><BR /><asp:GridView id="GridView1" runat="server" Width="100%" Font-Size="8pt" Font-Names="Verdana" DataSourceID="ObjRPS_DATA"><Columns>
<asp:BoundField DataField="Uploaded File Name" HeaderText="Uploaded File Name" SortExpression="Uploaded File Name"></asp:BoundField>
<asp:BoundField DataField="No. of Rejections" HeaderText="No. of Rejections" SortExpression="No. of Rejections"></asp:BoundField>
</Columns>
</asp:GridView> </TD></TR></TBODY></TABLE>
<HR style="COLOR: gainsboro" />
<asp:ObjectDataSource id="ObjRPS_DATA" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="PRIUploadedFileList" TypeName="LOV_COLLECTION"></asp:ObjectDataSource> 
</contenttemplate>
    </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

