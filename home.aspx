<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="tcsDemoWebForms2.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formHome" runat="server">
        <div>
            <asp:GridView ID="gridViewHome" runat="server" AutoGenerateColumns="false" OnRowCommand="gridViewHome_RowCommand" >
                <Columns>
                    <asp:BoundField ItemStyle-Width="150px" DataField="ID" HeaderText="ID" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="FIRST NAME" HeaderText="FIRST NAME" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="LAST NAME" HeaderText="LAST NAME" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="COUNTRY" HeaderText="COUNTRY" />
                    <asp:TemplateField ItemStyle-Width="30px" HeaderText="Edit">
                        <ItemTemplate> 
                            <asp:Button runat="server" ID="btnEdit" Text="Edit" CommandName = "editDtls"  CommandArgument='<%# Container.DataItemIndex%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="30px" HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" Text="Delete" CommandName='deleteDtls'  CommandArgument='<%# Container.DataItemIndex %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnAddDtls" Text="Add" runat="server" OnClick="btnAddDtls_Click" />
        </div>
    </form>
</body>
</html>
