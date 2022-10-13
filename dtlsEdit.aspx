<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dtlsEdit.aspx.cs" Inherits="tcsDemoWebForms2.dtlsEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="ID"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="First Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Country"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server"></asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click"/>
        </div>
    </form>
</body>
</html>
