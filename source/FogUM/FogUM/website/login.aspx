<%@ Page Language="C#" MasterPageFile="~/AppMaster.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" Title="FogUM - Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phSidebar" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phMain" Runat="Server">
    <asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#E6E2D8" 
        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
        Font-Size="10pt" ForeColor="#333333">
        <TitleTextStyle BackColor="#397D47" Font-Bold="True" ForeColor="#FFFFFF" />
    </asp:Login>
    <asp:LoginView ID="LoginView1" runat="server">
    </asp:LoginView>
</asp:Content>

