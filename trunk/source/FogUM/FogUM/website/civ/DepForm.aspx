<%@ Page Language="C#" MasterPageFile="~/AppMaster.master" AutoEventWireup="true" CodeFile="DepForm.aspx.cs" Inherits="DepForm" Title="FogUM - Registo de Depósito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phSidebar" Runat="Server">

    <h3>
        Meteorologia</h3>
    <div class="sbcontentcontainer">  
    
        <%--<p>
            <div style='width: 160px; height: 600px; background-image: url( http://vortex.accuweather.com/adcbin/netweather_v2/backgrounds/green_160x600_bg.jpg ); background-repeat: no-repeat; background-color: #336633;' ><div style='height: 585px;' ><script src='http://netweather.accuweather.com/adcbin/netweather_v2/netweatherV2.asp?partner=netweather&tStyle=whteYell&logo=0&zipcode=EUR|PT|PO004|BRAGA|&lang=eng&size=15&theme=green&metric=1&target=_self'></script></div><div style='text-align: center; font-family: arial, helvetica, verdana, sans-serif; font-size: 10px; line-height: 15px; color: #FFFFFF;' ><a style='color: #FFFFFF' href='http://www.accuweather.com/world-index-forecast.asp?partner=netweather&locCode=EUR|PT|PO004|BRAGA|&metric=1' >Weather Forecast</a> | <a style='color: #FFFFFF' href='http://www.accuweather.com/maps-satellite.asp' >Weather Maps</a></div></div>
        </p>--%>
    </div>
    
    
    <p><embed id="favloc" src="http://vortex.accuweather.com/includes/flash/favoritelocations/fav.swf" name="favloc" wmode="transparent" pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" allowscriptaccess="always" width="230" height="200"></p>

    <h3>
        Links Úteis</h3>
                                        <div style="height: 394px">
                                            <p>
                                                &nbsp;
                                                <asp:Image ID="Image1" runat="server" Height="21px" 
                                                    ImageUrl="~/civ/Imagens/bombeiros_portugal.jpg" Width="22px" 
                                                    ImageAlign="AbsMiddle" />
                                                <a href="http://www.bombeiros.pt/" target=_blank >Bombeiros de Portugal</a></p>
                                            <p>
                                                &nbsp;
                                                <asp:Image ID="Image2" runat="server" Height="21px" 
                                                    ImageUrl="~/civ/Imagens/bombVolunt.jpg" Width="22px" 
                                                    ImageAlign="AbsMiddle" />
                                                <a href="http://www.apbv.org/" target=_blank >Bombeiros Voluntários</a></p>
                                            <p style="height: 32px">
                                                &nbsp;
                                                <asp:Image ID="Image3" runat="server" Height="21px" 
                                                    ImageUrl="~/civ/Imagens/florestabemcuidada.png" Width="22px" 
                                                    ImageAlign="AbsMiddle" />
                                                <a href="http://www.florestabemcuidada.com/" target=_blank >Floresta Bem Cuidada</a></p>
                                            <p>
                                                &nbsp;
                                                <asp:Image ID="Image4" runat="server" Height="21px" 
                                                    ImageUrl="~/civ/Imagens/floresta unida.jpg" Width="22px" 
                                                    ImageAlign="AbsMiddle" />
                                                <a href="hhttp://www.florestaunida.com/" target=_blank >Floresta Unida</a></p>
                                            <p>
                                                &nbsp;
                                                <asp:Image ID="Image5" runat="server" Height="21px" 
                    ImageUrl="~/civ/Imagens/logo_inem.jpeg" Width="22px" ImageAlign="AbsMiddle" />
                                                <a href="http://www.inem.pt/" target=_blank >INEM</a></p>
                                            <p>
                                                &nbsp;
                                                <asp:Image ID="Image6" runat="server" Height="21px" 
                                                    ImageUrl="~/civ/Imagens/meteorologia.JPG" Width="22px" 
                                                    ImageAlign="AbsMiddle" />
                                                <a href="http://www.meteo.pt/pt/" target=_blank >Instituto Meteorologia</a></p>
                                            <p>
                                                &nbsp;
                                                <asp:Image ID="Image7" runat="server" Height="21px" 
                                                    ImageUrl="~/civ/Imagens/min_agricultura.JPG" Width="22px" 
                                                    ImageAlign="AbsMiddle" />
                                                <a href="http://www.afn.min-agricultura.pt/portal" target=_blank >Ministério da Agricultura</a></p>
                                            <p>
                                                &nbsp;
                                                <asp:Image ID="Image8" runat="server" Height="21px" 
                                                    ImageUrl="~/civ/Imagens/ministAmb.JPG" Width="22px" 
                                                    ImageAlign="AbsMiddle" />
                                                <a href="http://www.maotdr.gov.pt/" target=_blank >Ministério do Ambiente</a></p>
                                            <p>
                                                &nbsp;
                                                <asp:Image ID="Image9" runat="server" Height="21px" 
                                                    ImageUrl="~/civ/Imagens/ligaProtNat.JPG" Width="22px" 
                                                    ImageAlign="AbsMiddle" />
                                                <a href="http://www.lpn.pt/" target=_blank >Protecção da Natureza</a></p>
                                            <p>
                                                &nbsp;
                                                <asp:Image ID="Image10" runat="server" Height="21px" 
                                                    ImageUrl="~/civ/Imagens/protCivil.jpeg" Width="22px" 
                                                    ImageAlign="AbsMiddle" />
                                                <a href="http://www.proteccaocivil.pt/" target=_blank >Protecção Civil</a></p>
                                        </div>
    <h3>Nºs Telefónicos:</h3>
    <div class="sbcontentcontainer">
        <p><b>Protecção Civil</b></p>
        <ul>
        <li>
            <asp:Image ID="Image11" runat="server" Height="20px" ImageAlign="AbsMiddle" 
                ImageUrl="~/civ/Imagens/telefone.png" Width="20px" />
            Braga: 253 201 350</li>
        <li>
            <asp:Image ID="Image12" runat="server" Height="20px" ImageAlign="AbsMiddle" 
                ImageUrl="~/civ/Imagens/telefone.png" Width="20px" />
            Beja: 284 313 050</li>
        <li>
            <asp:Image ID="Image13" runat="server" Height="20px" ImageAlign="AbsMiddle" 
                ImageUrl="~/civ/Imagens/telefone.png" Width="20px" />
            Faro: 289 887 510</li>
        <li>
            <asp:Image ID="Image14" runat="server" Height="20px" ImageAlign="AbsMiddle" 
                ImageUrl="~/civ/Imagens/telefone.png" Width="20px" />
            Lisboa: 218 820 960</li>
        <li>
            <asp:Image ID="Image15" runat="server" Height="20px" ImageAlign="AbsMiddle" 
                ImageUrl="~/civ/Imagens/telefone.png" Width="20px" />
            Porto: 226 197 650</li>
        <li>
            <asp:Image ID="Image16" runat="server" Height="20px" ImageAlign="AbsMiddle" 
                ImageUrl="~/civ/Imagens/telefone.png" Width="20px" />
            Vila Real: 259 301 000</li>
        </ul>
        <p><b>Outros:</b></p>
        <ul>
        <li>
            <asp:Image ID="Image17" runat="server" Height="20px" ImageAlign="AbsMiddle" 
                ImageUrl="~/civ/Imagens/telefone.png" Width="20px" />
            Emergencia: 112</li>
        <li dir="ltr" style="width: 739px">
            <asp:Image ID="Image18" runat="server" Height="20px" ImageAlign="AbsMiddle" 
                ImageUrl="~/civ/Imagens/telefone.png" Width="20px" />
            Protecção da Floresta: 117</li>
        </ul>
<%--                <p style="margin-left: 20px">
                &nbsp;Braga:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;253 201 350</p>
        <p style="margin-left: 20px">
                &nbsp;Vila Real:&nbsp;259 301 000</p>
                <p style="margin-left: 20px">
                &nbsp;Porto:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;226 197 650</p>
                <p style="margin-left: 20px">
                &nbsp;Lisboa:&nbsp;&nbsp;&nbsp;&nbsp;218 820 960</p>
                <p style="margin-left: 20px">
                &nbsp;Beja:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;284 313 050</p>
                <p style="margin-left: 20px">
                &nbsp;Faro:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;289 887 510</p>
         <p>Emergencia:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;112</p>
         <p>Protecção da Floresta:&nbsp;&nbsp;117</p>--%>
    </div>
    <h3>
        Newsletter FogUM</h3>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:TextBox ID="TextBox1" runat="server">Insira o seu email</asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="OK" onclick="Button1_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
        
    <h3>
        Estatísticas</h3>
    <asp:BulletedList ID="BListStats" runat="server" BulletStyle="Square" 
        style="margin-left: 37px">
    </asp:BulletedList>
    <p>
    </p>
    
    
    <%--<p>
    <div>
    <font color="#FF0000"><h2>Contactos:</h2></font>
    <br /><br /><br /><br />
     
    <font color="#FF0000"><h3>Links Uteis:</h3></font>
    <br />  
    <div>
    <a href="http://www.bombeiros.pt/" target=_blank >Bombeiros de Portugal</a>
    <br />
    <a href="http://www.proteccaocivil.pt/" target=_blank >Protecção Civil</a>
    </div>    
        </p>
        </div>--%>

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phMain" Runat="Server">
    <div style="height: 22px; border-top-color: #006600; border-bottom-style: solid; color: #006600; font-size: large;">
        FogUM - Registar Depósito Água</div>
    <div style="height: 269px; width: 472px;">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Rua"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="moradaD" runat="server" Width="200px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Font-Italic="True" ForeColor="Red" 
            Text="* Inválido" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label14" runat="server" Text="Distrito"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server" 
            DataSourceID="SqlDataSource2" DataTextField="DISTRITO_DESIGN" 
            DataValueField="DISTRITO_DESIGN" AppendDataBoundItems="true" Height="22px" 
            Width="200px">
            <asp:ListItem Value=""></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label15" runat="server" Font-Italic="True" ForeColor="Red" 
            Text="* Inválido" Visible="False"></asp:Label>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BDFConnectionString %>" 
            SelectCommand="SELECT [DISTRITO_DESIGN] FROM [DISTRITO]">
        </asp:SqlDataSource>
        <br />
        <br />
        <br />
        <div style="color: #006600">Dados do Depósito</div>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Tipo Depósito"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="TIPO_DESIGN" 
            DataValueField="TIPO_DESIGN" AppendDataBoundItems="true" Height="22px" 
            Width="145px">
            <asp:ListItem Value=""></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label13" runat="server" Font-Italic="True" ForeColor="Red" 
            Text="* Inválido" Visible="False"></asp:Label>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BDFConnectionString %>" 
            SelectCommand="SELECT [TIPO_DESIGN] FROM [TIPOS_DEPOS]"></asp:SqlDataSource>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Comprimento"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="compr" runat="server" Width="88px"></asp:TextBox>
        <asp:Label ID="Label9" runat="server" Font-Size="Small" Text="(metros)"></asp:Label>
        <asp:Label ID="Label6" runat="server" Font-Italic="True" ForeColor="Red" 
            Text="* Inválido" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Altura"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="altura" runat="server" Width="88px"></asp:TextBox>
        <asp:Label ID="Label10" runat="server" Font-Size="Small" Text="(metros)"></asp:Label>
        <asp:Label ID="Label4" runat="server" Font-Italic="True" ForeColor="Red" 
            Text="* Inválido" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Largura"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="largura" runat="server" Width="88px"></asp:TextBox>
        <asp:Label ID="Label11" runat="server" Font-Size="Small" Text="(metros)"></asp:Label>
        <asp:Label ID="Label8" runat="server" Font-Italic="True" ForeColor="Red" 
            Text="* Inválido" Visible="False"></asp:Label>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Submeter" onclick="Button2_Click" />
        <div style="border-color: #FFFFFF; position: relative; top: -253px; left: 377px; width: 182px; height: 229px;">
            <img alt="" src="Imagens/gota.jpg" 
                style="border-color: #FFFFFF; height: 207px; width: 164px" /></div>
                
    </div>
    
</asp:Content>

