<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dataupdate.aspx.cs" Inherits="dataupdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script language="javascript" type="text/javascript">
    function checkVal()
    {
        var val = document.getElementById('txtUploadFolder').value;
        if(val == '')
        {
            var a = confirm('Are you sure to upload file in root.');
            if (a== true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <table style="text-align: center; width: 850px;">
                <tr>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divLogin" runat="server" style="text-align: center;">
            <table style="width: 850px;">
                <tr>
                    <td align="right" style="width: 50%">
                        User ID :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtUserID" runat="server" Width="140px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Password :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="140px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="80px" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divProcess" runat="server" style="text-align: center;">
            <table style="width: 850px;">
                <tr>
                    <td align="right">
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Folder / File Name :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtFileDownload" runat="server" Width="320px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDownload" runat="server" Text="Download" Width="80px" OnClick="btnDownload_Click" /></td>
                </tr>
                <tr>
                    <td align="right">
                        Folder Name :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtUploadFolder" runat="server" Width="320px"></asp:TextBox>&nbsp;
                        <asp:CheckBox ID="chNewFolder" Text="Create New Folder" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right">
                        Upload File :&nbsp;
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="410px" />&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" Width="80px" OnClientClick="return checkVal()"
                            OnClick="btnUpload_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" Width="80px" OnClick="btnReset_Click" />&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
