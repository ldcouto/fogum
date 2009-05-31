<%@ Page Language="C#" MasterPageFile="~/AppMaster.master" AutoEventWireup="true" CodeFile="Civil.aspx.cs" Inherits="Civil" Title="Untitled Page" %>
<%@ Register Src="~/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>

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
    <div class="sbcontentcontainer">
        <ul>
            <li><a href="http://www.bombeiros.pt/" target=_blank >Bombeiros de Portugal</a></li>
            <li><a href="http://www.apbv.org/" target=_blank >Bombeiros Voluntários</a></li> 
            <li><a href="http://www.proteccaocivil.pt/" target=_blank >Protecção Civil</a></li>
            <li><a href="http://www.inem.pt/" target=_blank >Inem</a></li>  
            <li><a href="http://www.florestabemcuidada.com/" target=_blank >Floresta Bem Cuidada</a></li>
            <li><a href="hhttp://www.florestaunida.com/" target=_blank >Floresta Unida</a></li>
            <li><a href="http://www.lpn.pt/" target=_blank >Protecção da Natureza</a></li> 
            <li><a href="http://www.afn.min-agricultura.pt/portal" target=_blank >Ministério da Agricultura</a></li> 
            <li><a href="http://www.maotdr.gov.pt/" target=_blank >Ministério do Ambiente</a></li>             
            <li><a href="http://www.meteo.pt/pt/" target=_blank >Instituto Meteorologia</a></li>                   
        </ul>
    </div>
    <h3>
        Contactos</h3>
    <div class="sbcontentcontainer">
        
        <p>Protecção Civil</p>
                <p style="margin-left: 20px">
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
         <p>Protecção da Floresta:&nbsp;&nbsp;117</p>
    </div>
    <h3>
        NewsLetter FogUM</h3>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged" 
>Insira o seu email</asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="OK" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
    </p>
        
    <h3>
        Estatisticas</h3>
    <div class="sbcontentcontainer">
        <p>
            Por numero de COORP estatisticas varias</p>
        <p>
            Sed dapibus, .</p>
    </div>
    
    
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
<header><font color="#FF0000"><h1>Incêndios Florestais em Portugal</h1></font></header>
    <br /><br />
<uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
   <font color="#FF0000"><h3>Legenda:</h3></font><img src="icons/fire.png" align=middle /> Fogo Activo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <img src="icons/fire2.png" align=middle /> Fogo Circunscrito
   
 
   
   
   
    </asp:Content>

