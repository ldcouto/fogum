<%@ Page Language="C#" MasterPageFile="~/AppMaster.master" AutoEventWireup="true" CodeFile="Civil.aspx.cs" Inherits="Civil" Title="FogUM - Mapa de Incêndios" %>
<%@ Register Src="~/civ/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>

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
                                                <a href="http://www.florestaunida.com/" target=_blank >Floresta Unida</a></p>
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
    <header><font color="#FF0000"><h1>Fogos Florestais em Portugal</h1></font></header>
    <br /><br />
<uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
   <font color="#FF0000"><h3>Legenda:</h3></font><img src="icons/fire.png" align=middle /> Fogo Activo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <img src="icons/fire2.png" align=middle /> Fogo Circunscrito
   
 
   
   
   
    </asp:Content>

