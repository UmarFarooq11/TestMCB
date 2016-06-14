<%@ Page Language="C#" MasterPageFile="~/MasterPage/RoutinePage.master" AutoEventWireup="true"
    CodeFile="AccountCompletionAP.aspx.cs" Inherits="AccountCompletionAP" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function SelectAll(id) {
            var frm1 = document.getElementById('<%= this.GridView1.ClientID %>');
            var grow = frm1.rows.length;
            var source = "";
            for (var i = 1; i < grow; i++) {
                source = frm1.rows[i].cells[6].innerHTML;
                if (source == "SYMBOLS" || source == "ACCOUNTLIKELIHOOD") {
                    frm1.rows[i].cells[7].children[0].checked = document.getElementById(id).checked;
                }
            }
        }

        function SelectAllAVA(id) {
            // alert('ibrahim');
            //       var frm = document.forms[0];
            //       //alert(frm.elements.length);
            //       for (i=0;i<frm.elements.length;i++)
            //       {
            //           if (frm.elements[i].type == "checkbox")
            //           {
            //               frm.elements[i].checked = document.getElementById(id).checked;
            //           }
            //       }
            //       var frm1 = document.getElementById('<%= this.GridView1.ClientID %>');
            //       var grow = frm1.rows.length;
            //       var source = "";
            //       for (var i=1; i < grow; i++)
            //       {
            //           source = frm1.rows[i].cells[6].innerHTML;
            //           if (source == "SYMBOLS")
            //           {
            //               frm1.rows[i].cells[7].children[0].checked = document.getElementById(id).checked;
            //           }
            //       }
        }

        function funConfirm() {
            var a = confirm('Are you sure to Execute?');
            if (a == true) {
                return true;
            }
            else {
                return false;
            }
        }
        function AGENTLOV() {
            var a;
            var c = '<%= Session["HEIGHT"] %>';
            var b = '<%= Session["WIDTH"] %>';
            a = window.showModalDialog('../LOV/LOV_Company.aspx', null, 'status:no;dialogWidth:' + b + ' px;dialogHeight:' + c + ' px;dialogHide:true;help:no;scroll:yes');
        }
        window.onload = function() {
            var strCook = document.cookie;
            if (strCook.indexOf("!~") != 0) {
                var intS = strCook.indexOf("!~");
                var intE = strCook.indexOf("~!");
                var strPos = strCook.substring(intS + 2, intE);
                document.getElementById("divTest").scrollTop = strPos;
            }
        }
        function SetDivPosition() {
            var intY = document.getElementById("divTest").scrollTop;
            document.title = intY;
            document.cookie = "yPos=!~" + intY + "~!";
        }



    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" class="air1" width="100%">
                <tr>
                    <td style="width: 1%">
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Size="Large" SkinID="FormViewHeading"
                            Width="100%" Text="Account Completion Post Publish"></asp:Label>
                    </td>
                    <td style="width: 1%">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <hr style="color: darkgray" />
                        <table style="font-size: 8pt; font-family: Verdana" cellspacing="0" width="100%">
                            <tbody>
                                <tr align="right">
                                    <td style="font-weight: bold; width: 15%; color: red; text-align: center" class="ColLines1"
                                        colspan="2">
                                        &nbsp;<asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label><asp:UpdateProgress
                                            ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/sp-progress2.gif"></asp:Image>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="air" cellspacing="0" style="font-size: 8pt; font-family: Verdana" width="100%">
                            <tbody>
                                <tr>
                                    <td style="width: 25%; text-align: right" class="TableColumns">
                                        Agent :
                                    </td>
                                    <td class="ColLines" colspan="3">
                                        <asp:DropDownList ID="ddlCompanyCode" runat="server" __designer:dtid="1407374883553311"
                                            Width="355px" __designer:wfdid="w5" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right" class="TableColumns">
                                        File :
                                    </td>
                                    <td class="ColLines">
                                        <asp:DropDownList ID="ddlFile" runat="server" Width="355px" AutoPostBack="True" 
                                            OnSelectedIndexChanged="ddlFile_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="text-align: right" class="ColLines">
                                        <asp:Label ID="lblTotalFile" runat="server" Text="File Total Records :"></asp:Label>&nbsp;
                                    </td>
                                    <td style="text-align: left" class="ColLines">
                                        <asp:Label ID="lblTotalRecord" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px" class="ColLines1">
                                        &nbsp;
                                    </td>
                                    <td style="height: 15px; text-align: left" class="ColLines">
                                        <asp:Button ID="btnprocess" OnClick="btnprocess_Click" runat="server" Width="100px"
                                            Text="Process" Font-Bold="True" __designer:wfdid="w1" CssClass="btn"></asp:Button>
                                        <asp:Button ID="btnFetch" OnClick="btnFetch_Click" runat="server" Width="100px" Text="Search"
                                            Font-Bold="True" CssClass="btn" ValidationGroup="search"></asp:Button>
                                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Width="100px"
                                            Text="Submit" Font-Bold="True" CssClass="btn"></asp:Button>
                                    </td>
                                    <td style="height: 15px; text-align: right" class="ColLines">
                                        <asp:Label ID="lblFieldTrans" runat="server" Width="135px" Text="No. of Transaction :">
                                        </asp:Label>
                                    </td>
                                    <td style="height: 15px; text-align: left" class="ColLines">
                                        <asp:Label ID="lblTransaction" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:Panel ID="Panel1" runat="server" Width="100%" Height="325px">
                                            <div style="overflow: auto; width: 100%; height: 300px" onscroll="SetDivPosition()"
                                                id="div1">
                                                <asp:GridView Style="width: 100%" ID="GridView1" runat="server" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                    OnRowDataBound="GridView1_RowDataBound" OnSorting="GridView1_Sorting" AllowSorting="True"
                                                    AutoGenerateColumns="False" DataKeyNames="ROWID" PageSize="5" 
                                                    EmptyDataText="No data found.">
                                                    <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
                                                        LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
                                                        NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous">
                                                    </PagerSettings>
                                                    <Columns>
                                                        <asp:BoundField DataField="ROWID" HeaderText="ROWID" SortExpression="ROWID">
                                                            <HeaderStyle CssClass="hidden"></HeaderStyle>
                                                            <ItemStyle CssClass="hidden"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BeneficiaryName" HeaderText="Beneficiary Name" SortExpression="BeneficiaryName">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TitleofAccount" HeaderText="Bene Name /Title of Account"
                                                            SortExpression="TitleofAccount"></asp:BoundField>
                                                        <asp:BoundField DataField="BENENAME" HeaderText="Beneficiary Name" SortExpression="BENENAME">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account Number " SortExpression="ACCOUNTNUMBER">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BRANCH_CODE" HeaderText="Branch Code" SortExpression="BRANCH_CODE">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="source" HeaderText="Source" SortExpression="source"></asp:BoundField>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="Ckb_SelectALL" runat="server" __designer:wfdid="w23"></asp:CheckBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="Ckb_Select" runat="server" __designer:wfdid="w22"></asp:CheckBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdCenter" colspan="5">
                                        <%--<asp:Panel ID="Panel2" runat="server" Width="100%" Height="325px">
                                            <table style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="text-align: center">
                                                            <asp:Label ID="Label2" runat="server" SkinID="FormViewHeading" Text="MULTIPLELIKELIHOOD"
                                                                Font-Bold="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center">
                                                            <asp:Label ID="Label3" runat="server" Text="Transaction Information " Font-Bold="False">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div style="overflow: auto; width: 100%; height: 300px" onscroll="SetDivPosition()"
                                                                id="div2">
                                                                <asp:GridView Style="width: 100%" ID="GV_TransInfo" runat="server" Width="100%" __designer:wfdid="w8"
                                                                    OnSelectedIndexChanged="GV_TransInfo_SelectedIndexChanged" PageSize="5" DataKeyNames="ROWID"
                                                                    AutoGenerateColumns="False" AllowSorting="True" OnRowCommand="GV_TransInfo_RowCommand">
                                                                    <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
                                                                        LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
                                                                        NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous">
                                                                    </PagerSettings>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ROWID" HeaderText="ROWID" SortExpression="ROWID">
                                                                            <HeaderStyle CssClass="hidden"></HeaderStyle>
                                                                            <ItemStyle CssClass="hidden"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="Beneficiary Name" SortExpression="BENENAME">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("BENENAME") %>' __designer:wfdid="w5"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Bind("BENENAME") %>'
                                                                                    __designer:wfdid="w4" OnClick="LinkButton1_Click"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="BENEADDRESS" HeaderText="Bene Address" SortExpression="BENEADDRESS">
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account Number " SortExpression="ACCOUNTNUMBER">
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="BRANCH_CODE" HeaderText="Branch Code" SortExpression="BRANCH_CODE">
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdCenter" colspan="5">
                                        <%--<asp:Panel ID="Panel3" runat="server" Width="100%" Height="325px">
                                            <table style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="text-align: center">
                                                            <asp:Label ID="Label4" runat="server" Text="Available Matched Information" Font-Bold="True">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div style="overflow: auto; width: 100%; height: 300px" onscroll="SetDivPosition()"
                                                                id="div3">
                                                                <asp:GridView ID="GV_AvalilableMatch" runat="server" Font-Size="8pt" Width="100%"
                                                                    __designer:wfdid="w9" PageSize="5" AutoGenerateColumns="False" AllowSorting="True"
                                                                    OnSorting="GridView1_Sorting" OnRowDataBound="GV_AvalilableMatch_RowDataBound"
                                                                    OnPageIndexChanging="GridView1_PageIndexChanging" Font-Names="Verdana">
                                                                    <PagerSettings FirstPageImageUrl="~/Images/MoveTop.gif" FirstPageText="Move First"
                                                                        LastPageImageUrl="~/Images/MoveLast.gif" LastPageText="Move Last" NextPageImageUrl="~/Images/MoveNext.gif"
                                                                        NextPageText="Move Next" PreviousPageImageUrl="~/Images/MovePrevious.gif" PreviousPageText="Move Previous">
                                                                    </PagerSettings>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ROWID" HeaderText="Row ID">
                                                                            <HeaderStyle CssClass="hidden"></HeaderStyle>
                                                                            <ItemStyle CssClass="hidden"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="BENENAME" HeaderText="Beneficary Name" SortExpression="BENENAME">
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Bene Name/Title of Account"
                                                                            SortExpression="ACCOUNTNUMBER">
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ACCOUNTNUMBER" HeaderText="Account Number" SortExpression="ACCOUNTNUMBER">
                                                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="BRANCH_CODE" HeaderText="Branch Code" SortExpression="BRANCH_CODE">
                                                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="source" HeaderText="Source" SortExpression="source">
                                                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="B_ROWID" HeaderText="B_ROW_ID">
                                                                            <HeaderStyle CssClass="hidden"></HeaderStyle>
                                                                            <ItemStyle CssClass="hidden"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="Select">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("BRANCH_code") %>' __designer:wfdid="w26"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <HeaderTemplate>
                                                                                <asp:CheckBox ID="CkbGVA_SelectALL" runat="server" __designer:wfdid="w27"></asp:CheckBox>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="CkbGVA_Select" runat="server" __designer:wfdid="w25"></asp:CheckBox>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <FooterStyle BorderWidth="1px" BorderStyle="Solid"></FooterStyle>
                                                                    <PagerStyle BorderColor="#404040" BorderStyle="Solid"></PagerStyle>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdRight" colspan="5">
                                        &nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="loginDown" cellspacing="0" width="100%">
                            <tbody>
                                <tr>
                                    <td>
                                        <%--<asp:HiddenField ID="hdRowIndex" runat="server"></asp:HiddenField>--%>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <hr style="color: gainsboro" />
                    </td>
                </tr>
                </TBODY></table>
            &nbsp;
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
