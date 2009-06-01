<%@ Page Language="C#" MasterPageFile="~/AppMaster.master" AutoEventWireup="true" CodeFile="VoluntForm.aspx.cs" Inherits="VoluntForm" Title="FogUM - Voluntários" %>

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
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phMain" Runat="Server">
    <div style="border-color: #006600; height: 29px; font-size: large; color: #339933; border-bottom-style: groove; width: 796px;">
    &nbsp;&nbsp;&nbsp;&nbsp;FogUM - Novo Voluntário<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    &nbsp;&nbsp;&nbsp;<div 
    style="width: 465px; height: 198px; margin-right: 0px; top: 1px; left: 2px;" align="left" 
    dir="ltr">
    <asp:Label ID="Lnome" runat="server" Text="Nome"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="nome" 
        runat="server" Width="200px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label17" runat="server" Font-Italic="True" ForeColor="#FF3300" 
        Text="* Inválido" Visible="False"></asp:Label>
    <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <asp:Label ID="Lmorada" runat="server" Text="Email"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="email" 
        runat="server" Width="200px"></asp:TextBox>
    <asp:Label ID="Label21" runat="server" Font-Italic="True" ForeColor="#FF3300" 
        Text="* Inválido" Visible="False"></asp:Label>
      
    <br />
    <br />
    <asp:Label ID="Ldistrito" runat="server" Text="Morada"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox 
        ID="morada" runat="server" Width="200px"></asp:TextBox>
    <asp:Label ID="Label19" runat="server" Font-Italic="True" ForeColor="#FF3300" 
        Text="* Inválido" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Ltelef" runat="server" Text="Distrito"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:DropDownList 
            ID="DropDownList1" runat="server" 
        DataSourceID="SqlDataSource1" DataTextField="DISTRITO_DESIGN" 
        DataValueField="DISTRITO_DESIGN" Height="20px" Width="205px" 
            AppendDataBoundItems="true">
            <asp:ListItem Value=""></asp:ListItem>
    </asp:DropDownList>
        <asp:Label ID="Label23" runat="server" Font-Italic="True" ForeColor="Red" 
            Text="* Inválido" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Lmail" runat="server" Text="Disponibilidade"></asp:Label>
        &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" Height="20px" 
            Width="205px">
            <asp:ListItem></asp:ListItem>
        <asp:ListItem>3 Meses</asp:ListItem>
        <asp:ListItem>6 Meses</asp:ListItem>
        <asp:ListItem>12 Meses</asp:ListItem>
    </asp:DropDownList>
        <asp:Label ID="Label22" runat="server" Font-Italic="True" ForeColor="Red" 
            Text="* Inválido" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label16" runat="server" Text="Telefone"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="telefone" runat="server" MaxLength="9" Width="200px"></asp:TextBox>
    <asp:Label ID="Label20" runat="server" Font-Italic="True" ForeColor="#FF3300" 
        Text="* Inválido" Visible="False"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" 
        Text="Submeter" onclick="Button2_Click" />
        
      <div style="border-color: #FFFFFF; position: relative; top: -274px; left: 399px; width: 214px; height: 253px;">
          <img alt="" src="Imagens/arvore1.jpg" 
              style="border-color: #FFFFFF; height: 251px; width: 214px" /><asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:BDFConnectionString %>" 
        SelectCommand="SELECT [DISTRITO_DESIGN] FROM [DISTRITO]" 
        ProviderName="<%$ ConnectionStrings:BDFConnectionString.ProviderName %>">
    </asp:SqlDataSource>
        </div>
</div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
    </asp:Content>

