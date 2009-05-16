<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BDTestForm.aspx.cs" Inherits="FogUM.BDTestForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
        <asp:BulletedList ID="BulletedList1" runat="server" Height="90px" Width="261px">
        </asp:BulletedList>
    
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Button" />
    
    </div>
    </form>
</body>
</html>
