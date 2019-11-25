<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="My__First_App.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">  
        <div style="background-color:white; color:black; width:100%; text-align:center" >
            <h2>CLIENT DETAILS</h2>
        </div>
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>

        <asp:Button ID="BtnSearch" runat="server" Text="Search" BackColor="LightBlue" ForeColor="Black" OnClick="BtnSearch_Click1" />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" >
            <Columns>
                <asp:BoundField DataField="ClientID" HeaderText="ClientID" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Button5" runat="server" BackColor="#3399FF" Text="Select" CommandName="Select"
                    CommandArgument="<%# Container.DataItemIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


        <hr />

        <asp:Label ID="Label6" runat="server" Text="ClientID"></asp:Label>
        <asp:TextBox ID="txtClientID" runat="server"></asp:TextBox>

        <asp:Label ID="Label1" runat="server" Text="FirstName"></asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>

        <asp:Label ID="Label2" runat="server" Text="LastName"></asp:Label>
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>

        <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        
        <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

        <asp:Button ID="btnSave" runat="server" Text="Save" Style="background-color:cadetblue;color:black;" OnClick="btnSave_Click" />

        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="Update_Click" BackColor="#33CCFF" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" BackColor="#99CCFF" OnClick="btnDelete_Click" />

        <hr />

        <asp:Button ID="Button6" runat="server" BackColor="#003366" ForeColor="White" Height="32px" OnClick="Button6_Click" Text="CARD DETAILS"
            Width="150px" />
        
        <asp:Button ID="Home" runat="server" BackColor="#003366" ForeColor="White" Height="32px" OnClick="Home_Click" Text="HOME"
            Width="150px" />

    </form>
</body>
</html>
