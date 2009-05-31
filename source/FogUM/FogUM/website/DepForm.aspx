<%@ Page Language="C#" MasterPageFile="~/AppMaster.master" AutoEventWireup="true" CodeFile="DepForm.aspx.cs" Inherits="DepForm" Title="Untitled Page" %>

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
    <div style="height: 22px; border-top-color: #006600; border-bottom-style: solid; color: #006600; font-size: large;">
        FogUM - Registar Depósito Água</div>
    <div style="height: 269px; width: 355px;">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Morada"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="moradaD" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Font-Italic="True" ForeColor="Red" 
            Text="* Inválido" Visible="False"></asp:Label>
        <br />
        <br />
        <div style="color: #006600">Dados do Depósito</div>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Tipo Depósito"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="TIPO_DESIGN" 
            DataValueField="TIPO_DESIGN" AppendDataBoundItems="true">
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
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
        <div style="border-color: #FFFFFF; position: relative; top: -253px; left: 350px; width: 182px; height: 229px;">
            <img alt="" src="Imagens/gota.jpg" 
                style="border-color: #FFFFFF; height: 207px; width: 164px" /></div>
                
    </div>
    
</asp:Content>

