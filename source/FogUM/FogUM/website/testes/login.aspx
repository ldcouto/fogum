<%@ Page Language="C#" MasterPageFile="~/AppMaster.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="testes_Autht" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phSidebar" Runat="Server">

    <p>
</p>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phMain" Runat="Server">
    OLá Meu!
Clica <a href="../cmd/Painel_Cmd.aspx">aqui</a> para ires pós CMDS!<asp:Login 
    ID="Login1" runat="server" onauthenticate="Login1_Authenticate">
</asp:Login>
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</asp:Content>

