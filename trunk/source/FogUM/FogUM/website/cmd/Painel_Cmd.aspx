<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Painel_Cmd.aspx.cs" Inherits="Painel_Cmd" UICulture="Auto" StylesheetTheme="Brown"%>

<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Painel de Controlo FogUM</title>
</head>
<body>
    <a href="Relatorios.aspx">Voltar Atrás</a>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Table ID="Table1" runat="server" BorderStyle="Groove">
            <asp:TableRow runat="server">
                <asp:TableCell>
                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" Height="450px" Width="430px">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="Button15" runat="server" BackColor="#0033CC" onclick="Button15_Click" Text="Carregar Dados do Fogo" Width="430px" Font-Bold="True" />
                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label3" runat="server" Text="Destacamento de Corporações" Width="220px" Font-Bold="True" BorderStyle="Inset"></asp:Label><br />
                            <asp:Table ID="Table2" runat="server" BorderStyle="Groove">
                                <asp:TableRow ID="TableRow1" runat="server">
                                    <asp:TableCell>
                                        <asp:Label ID="Label4" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Disponíveis" Width="80px" Font-Bold="True" ></asp:Label><br />
                                        <asp:ListBox ID="ListBox1" runat="server" Width="168px" ></asp:ListBox>   
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Button ID="Button8" runat="server" onclick="Button8_Click" Text="Adicionar" style="height: 26px" /><br />
                                        <asp:Button ID="Button9" runat="server" onclick="Button9_Click" Text="Remover" style="height: 26px" /><br />   
                                    </asp:TableCell>
                                    <asp:TableCell>
                                    <asp:Label ID="Label5" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Destacadas" Width="80px" Font-Bold="True" ></asp:Label><br />
                                        <asp:ListBox ID="ListBox2" runat="server" Width="168px"></asp:ListBox>     
                                    </asp:TableCell>
                                </asp:TableRow>    
                            </asp:Table>
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label6" runat="server" Text="Destacamento de Helicópteros" Width="225px" Font-Bold="True" BorderStyle="Inset"></asp:Label><br />
                            <asp:Table ID="Table3" runat="server" BorderStyle="Groove">
                                <asp:TableRow runat="server">
                                    <asp:TableCell>
                                        <asp:Label ID="Label7" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Disponíveis" Width="80px" Font-Bold="True" ></asp:Label><br />
                                        <asp:ListBox ID="ListBox3" runat="server" Width="168px"></asp:ListBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Button ID="Button11" runat="server" onclick="Button11_Click" Text="Adicionar" style="height: 26px" /><br />
                                        <asp:Button ID="Button12" runat="server" onclick="Button12_Click" Text="Remover" style="height: 26px" /><br />
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Label ID="Label8" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Destacados" Width="80px" Font-Bold="True" ></asp:Label><br />
                                        <asp:ListBox ID="ListBox4" runat="server" Width="168px"></asp:ListBox>                 
                                    </asp:TableCell>
                                </asp:TableRow>    
                            </asp:Table>
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="Raio de Fogo:" Width="140px" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="RaioFogo" runat="server" Height="23px" Width="23px" align="middle"></asp:TextBox>                            
                            &nbsp; Km&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button13" runat="server" onclick="Button13_Click" Text="Actualizar" align="middle"/>
                            &nbsp;( Exemplo: 15,2 )
                            <asp:Label ID="Label1" runat="server" Text="Raio de Segurança:" Width="140px" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="RaioSeguranca" runat="server" Height="23px" Width="23px" align="middle"></asp:TextBox>
                            &nbsp; Km&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button14" runat="server" Text="Actualizar" onclick="Button14_Click" align="middle"/>
                            &nbsp;( Exemplo: 17,4)
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label9" runat="server" Text="Alteração do Estado do Fogo" Width="205px" Font-Bold="True" BorderStyle="Inset"></asp:Label><br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="ButEstAct" runat="server" onclick="ButEstAct_Click" Text="Activo" Width="113px" />
                            <asp:Button ID="ButEstCir" runat="server" onclick="Button17_Click" Text="Circunscrito" Width="113px" />
                            <asp:Button ID="ButEstExt" runat="server" onclick="ButEstExt_Click" Text="Extinto" Width="113px" />
                            <br />
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </asp:Panel>
                    <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" Height="50px" Width="430px">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" onclick="ImageButton1_Click" Width="50px" ImageUrl="~/icons/play2.jpeg" ImageAlign="Right" />
                                <asp:ImageButton ID="ImageButton2" runat="server" Height="50px" onclick="ImageButton2_Click" Width="50px" ImageUrl="~/icons/pause.jpg" Visible="False" ImageAlign="Right" />
                                <asp:Label ID="Label10" runat="server" Text="Pressione Play para Iniciar a Simulação" Width="300px" Font-Bold="True" ></asp:Label>
                                <asp:Label ID="Label11" runat="server" Text="Pressione Pause para Parar a Simulação" Width="300px" Font-Bold="True" Visible="False"></asp:Label>
                                <asp:Label ID="Label12" runat="server" Text="Verifique se o campo que seleccionou está correcto!" Width="350px" Font-Italic="True" Visible="False" ForeColor="Red"></asp:Label>
                            </ContentTemplate>                    
                        </asp:UpdatePanel>
                        </asp:Panel>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="508px" Width="800px">
                        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
                    </asp:Panel>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="100" 
                        ontick="Timer1_Tick">
                    </asp:Timer>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
                    
                    </div>    
    </form>
    <MARQUEE BEHAVIOR=SCROLL DIRECTION="RIGHT" BGCOLOR="YELLOW"WIDTH=50%>SIMULAÇÃO EM EXECUÇ</MARQUEE>
</body>
</html>
