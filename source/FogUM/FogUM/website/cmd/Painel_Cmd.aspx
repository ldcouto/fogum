<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Painel_Cmd.aspx.cs" Inherits="Painel_Cmd" UICulture="Auto" %>

<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Painel de Controlo FogUM</title>
</head>
<body>
    <h3><a href="Painel_Cmd.aspx">Back</a></h3>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <h3>Painel de Controlo de Comandante</h3>
    <div>
        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="Button1" runat="server" Text="Traçar Rota" 
                onclick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Mover Heli" 
                onclick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                Text="Mover Carro" />
            <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                Text="Traçar Raio" />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="500" 
                        ontick="Timer1_Tick">
                    </asp:Timer>
                    <asp:Timer ID="Timer2" runat="server" Enabled="False" Interval="500" 
                        ontick="Timer2_Tick">
                    </asp:Timer>
                    <asp:Timer ID="Timer3" runat="server" Enabled="False" Interval="500" 
                        ontick="Timer3_Tick">
                    </asp:Timer>
                    <asp:Timer ID="Timer4" runat="server" ontick="Timer4_Tick">
                    </asp:Timer>
                    <asp:Button ID="Button5" runat="server" onclick="Button5_Click" Text="Button" />
                    <asp:Button ID="Button6" runat="server" Text="TTTTT" onclick="Button6_Click" />
                    <asp:Button ID="Button20" runat="server" onclick="Button20_Click" 
                        Text="Adicionar Corp" Width="144px" />
                    <asp:Button ID="Button18" runat="server" onclick="Button18_Click" 
                        Text="Adicionar Corp" />
                    <asp:Button ID="Button19" runat="server" onclick="Button19_Click" 
                        Text="Comecar Timer" Width="132px" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="Button15" runat="server" BackColor="#0033CC" 
                                onclick="Button15_Click" Text="Inicializar Teste" Width="745px" />
                            <br />
                            <br />
                            <asp:ListBox ID="ListBox1" runat="server" Width="291px" 
                                ontextchanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
                            <asp:Button ID="Button8" runat="server" onclick="Button8_Click" 
                                Text="Adiciona" style="height: 26px" />
                            <asp:Button ID="Button9" runat="server" Height="27px" onclick="Button9_Click" 
                                Text="Remove" Width="68px" />
                            <asp:ListBox ID="ListBox2" runat="server" Width="306px"></asp:ListBox>
                            <br />
                            <br />
                            <asp:Button ID="Button7" runat="server" onclick="Button7_Click" Text="Button" />
                            <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged"></asp:TextBox>
                            <asp:Button ID="Button10" runat="server" onclick="Button10_Click" 
                                Text="actualiza" />
                            <br />
                            <br />
                            <br />
                            <asp:ListBox ID="ListBox3" runat="server" Width="289px"></asp:ListBox>
                            <asp:Button ID="Button11" runat="server" onclick="Button11_Click" 
                                Text="adiciona" Width="92px" />
                            <asp:Button ID="Button12" runat="server" onclick="Button12_Click" 
                                Text="remove" />
                            <asp:ListBox ID="ListBox4" runat="server" Width="303px"></asp:ListBox>
                            <br />
                            <br />
                            <br />
                            Raio do Fogo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="RaioFogo" runat="server" Height="23px" Width="32px"></asp:TextBox>
                            &nbsp; Km &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button13" runat="server" onclick="Button13_Click" 
                                Text="Actualizar" />
                            &nbsp;( Exemplo: 15,2 )
                            <asp:Label ID="RaioInvalido" runat="server" BorderColor="Red" ForeColor="Red" 
                                Text="*Invalido" Visible="False"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="RaioSucesso" runat="server" ForeColor="#3366FF" 
                                Text=" Raio do Fogo Alterado" Visible="False"></asp:Label>
                            <br />
                            Raio de Segurança:
                            <asp:TextBox ID="RaioSeguranca" runat="server" Width="32px"></asp:TextBox>
                            &nbsp; Km&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button14" runat="server" Text="Actualizar" 
                                onclick="Button14_Click" />
                            &nbsp;( Exemplo: 17,4)
                            <asp:Label ID="RaioSInvalido" runat="server" ForeColor="Red" Text="*Invalido" 
                                Visible="False"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:Label ID="RaioSSucesso" runat="server" Text="Raio de Segurança Alterado" 
                                ForeColor="#3366FF" Visible="False"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="ButEstAct" runat="server" BackColor="Red" 
                                onclick="ButEstAct_Click" Text="Activo" Width="113px" />
                            <asp:Button ID="ButEstCir" runat="server" BackColor="#FF9933" 
                                onclick="Button17_Click" Text="Circunscrito" Width="113px" />
                            <asp:Button ID="ButEstExt" runat="server" BackColor="#66FF33" 
                                onclick="ButEstExt_Click" Text="Extinto" Width="113px" />
                            <br />
                            Estado do fogo:
                            <asp:Label ID="LabEstadoFogo" runat="server" ForeColor="#663300" 
                                Text="EstadoFogo"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            Data de inicio :<asp:Label ID="LabDataEstado1" runat="server"></asp:Label>
                            <br />
                            Data de Circunscrito :<asp:Label ID="LabDataEstado2" runat="server"></asp:Label>
                            <br />
                            Data de Extinto:
                            <asp:Label ID="LabDataEstado3" runat="server"></asp:Label>
                            <br />
                            <br />
                            Comentario:
                            <asp:TextBox ID="TBComentario" runat="server" Width="543px"></asp:TextBox>
                            <asp:Button ID="ButComent" runat="server" onclick="ButComent_Click" 
                                Text="Alterar" Width="100px" />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            Debug:<br />
                            <asp:ListBox ID="ListBox5" runat="server" Width="337px"></asp:ListBox>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            <asp:Button ID="Button16" runat="server" onclick="Button16_Click" 
                                Text="Button" />
                            <asp:Button ID="Button17" runat="server" onclick="Button17_Click1" 
                                Text="Button" />
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    
         <p>
             &nbsp;</p>
    
    </form>
</body>
</html>
