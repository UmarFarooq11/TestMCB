<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true" CodeFile="LOV_IncomingTrailer.aspx.cs" Inherits="LOV_Batch" Title = "Incoming Trailer - LOV" %>
<%@ Register
Assembly="AjaxControlToolkit"
Namespace="AjaxControlToolkit"
TagPrefix="ajaxToolkit" %>
<%@ Register src="../WebControls/AlphaSelection.ascx" tagname="AlphaSelection" tagprefix="uc1" %> 
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
 function CloseWindow()
    {
        window.close();
    }
    
</script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:Label ID="Label1" runat="server" Font-Names="Trebuchet MS" Font-Size="20pt"
        SkinID="Heading" Text="Incoming Trailer" Width="100%"></asp:Label><br />
<asp:UpdatePanel id="UpdatePanel1" runat="server">
<contenttemplate>
        
<TABLE class="login" cellSpacing=0 width="100%"><TBODY><TR><TD><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 9pt; FONT-FAMILY: Arial, Tahoma" id="LBL_GridStatus" runat="server" Width="100px"></asp:Label></TD><TD><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; FONT-FAMILY: Arial, Tahoma" id="LBL_RowStatus" runat="server" Width="200px"></asp:Label></TD><TD width="100%"></TD><TD><asp:ImageButton id="CMD_MoveFirst" onclick="CMD_MoveFirst_Click" runat="server" ImageUrl="~/Images/MoveTop.gif"></asp:ImageButton></TD><TD><asp:ImageButton id="CMD_MoveBack" onclick="CMD_MoveBack_Click" runat="server" ImageUrl="~/Images/MovePrevious.gif"></asp:ImageButton></TD><TD><asp:DropDownList id="DRP_LIST" runat="server" OnSelectedIndexChanged="DRP_LIST_SelectedIndexChanged" AutoPostBack="True">
</asp:DropDownList></TD><TD><asp:ImageButton id="CMD_MoveNext" onclick="CMD_MoveNext_Click" runat="server" ImageUrl="~/Images/MoveNext.gif"></asp:ImageButton></TD><TD><asp:ImageButton id="CMD_MoveLast" onclick="CMD_MoveLast_Click" runat="server" ImageUrl="~/Images/MoveLast.gif"></asp:ImageButton></TD></TR></TBODY></TABLE><TABLE style="BACKGROUND-COLOR: gainsboro" class="login" cellSpacing=0 width="100%"><TBODY><TR><TD style="FONT-SIZE: 9pt; COLOR: #444444; FONT-FAMILY: Arial, Tahoma; TEXT-ALIGN: left; height: 17px;" colSpan=4>
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True"
        AutoGenerateColumns="False" DataKeyNames="ID" Font-Names="Verdana" Font-Size="8pt"
        OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        PageSize="20" ShowFooter="True" Style="width: 100%" Width="100%" DataSourceID="SP_RPS_INCOMINGTRAILER_ALL" AllowPaging="True">
        <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
            LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
            NextPageText="Move Next" PageButtonCount="100" Position="TopAndBottom" PreviousPageImageUrl="~/Images/MovePrevious.gif"
            PreviousPageText="Move Previous" Visible="False" />
        <FooterStyle BorderStyle="Solid" BorderWidth="1px" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="False" />
            <asp:BoundField DataField="TransactionCode" HeaderText="Transaction Code" SortExpression="TransactionCode" />
            <asp:BoundField DataField="IncomingBatchHeaderID" HeaderText="Incoming Batch Header"
                SortExpression="IncomingBatchHeaderID" />
            <asp:BoundField DataField="BatchDate" HeaderText="Batch Date" SortExpression="BatchDate" />
            <asp:BoundField DataField="BatchNumber" HeaderText="Batch Number" SortExpression="BatchNumber" />
            <asp:BoundField DataField="BatchesToThisDate" HeaderText="Batches To This Date" SortExpression="BatchesToThisDate" />
            <asp:BoundField DataField="LastBatchNumber" HeaderText="Last Batch Number" SortExpression="LastBatchNumber" />
            <asp:BoundField DataField="RecordsToDate" HeaderText="Records To Date" SortExpression="RecordsToDate" />
            <asp:BoundField DataField="CurrencyCode" HeaderText="Currency Code" SortExpression="CurrencyCode" />
            <asp:BoundField DataField="TotalCoverAmountToDate" HeaderText="Total Cover Amount To Date"
                SortExpression="TotalCoverAmountToDate" />
            <asp:BoundField DataField="Authorization" HeaderText="Authorization" SortExpression="Authorization" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Select" ImageUrl="~/Images/edit1.gif"
                        OnClick="ImageButton1_Click" OnClientClick="CloseWindow();"/>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Right" />
            </asp:TemplateField>
        </Columns>
        <PagerStyle BorderColor="#404040" BorderStyle="Solid" />
    </asp:GridView>
        </TD></TR></TBODY></TABLE>
        </contenttemplate>
</asp:UpdatePanel>

 <asp:ObjectDataSource ID="SP_RPS_INCOMINGTRAILER_ALL" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GET_SP_RPS_INCOMINGTRAILERLOV_ALL" TypeName="LOV_COLLECTION">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="ID" SessionField="ID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
