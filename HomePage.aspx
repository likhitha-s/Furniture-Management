<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="My__First_App.BHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div style="background-color:white; color:black; width:100%; text-align:center" >
            <h2>FURNITURE MANAGEMENT</h2>
        </div>

        <asp:Button ID="Client" runat="server" BackColor="#003366" ForeColor="White" Height="32px" OnClick="Client_Click" Text="CLIENT DETAILS"
            Width="200px" />

        <asp:Button ID="Card" runat="server" BackColor="#003366" ForeColor="White" Height="32px" OnClick="Card_Click" Text="CARD DETAILS"
            Width="200px" />

        <asp:Button ID="Transaction" runat="server" BackColor="#003366" ForeColor="White" Height="32px" OnClick="Transaction_Click" Text="TRANSACTION DETAILS"
            Width="200px" />

        <asp:Button ID="Furniture" runat="server" BackColor="#003366" ForeColor="White" Height="32px" OnClick="Furniture_Click" Text="FURNITURE DETAILS"
            Width="200px" />

        <asp:Button ID="Delivery" runat="server" BackColor="#003366" ForeColor="White" Height="32px" OnClick="Delivery_Click" Text="DELIVERY DETAILS"
            Width="200px" />

    </form>
</body>
</html>
