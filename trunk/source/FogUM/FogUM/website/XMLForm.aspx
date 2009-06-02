<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XMLForm.aspx.cs" Inherits="XMLForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       
        <div>
            <p style="width: 583px; margin-left: 160px; position: relative; top: 0px; left: 191px;" 
                align="center">
        &nbsp;<asp:Label ID="Label3" runat="server" 
            Text="PAINEL DE ADMINISTRAÇÃO DA BASE DE DADOS" 
            Font-Bold="True" Font-Size="Large" ForeColor="Black"></asp:Label>
            &nbsp;&nbsp;
            </p>
        </div>
&nbsp;&nbsp;&nbsp;
        <br />
        <div style="width: 365px; position: relative; top: 126px; left: 67px;" 
            align="center">
            <asp:Label ID="Label4" runat="server" Text="Eliminar Registos da Base de Dados" 
                Font-Bold="True" Font-Size="Medium"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="OK" Height="23px" 
                onclick="Button1_Click" />
        </div>
        <br />
        <br />
        <br />
        <div style="position: relative; top: -29px; left: 711px; width: 343px; height: 302px;" 
            align="center">
            <asp:Label ID="Label5" runat="server" 
                Text="Seleccione XML para Recuperar Base de Dados" Font-Bold="True" 
                Font-Size="Medium"></asp:Label>
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Height="141px" Width="312px">
            </asp:ListBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click1" Text="OK" />
        </div>
        <br />
        
    </div>
    </form>
</body>
</html>
