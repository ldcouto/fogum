<%@ Page Language="C#" MasterPageFile="~/AppMaster.master" AutoEventWireup="true" CodeFile="Relatorios.aspx.cs" Inherits="Relatorios" Title="Untitled Page" %>

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


    <br />
    <h2>Fogos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </h2>
                                        <h2>
                                            <p style="margin-left: 120px">
                                                <asp:ListBox ID="ListBox_fogos" runat="server" Width="230px"></asp:ListBox>
                                            </p>
                                        </h2>
                                        <h2>
                                            <p style="margin-left: 200px">
&nbsp;&nbsp;
                                                <asp:Button ID="btn_reiniciar_fogo" runat="server" Height="30px" 
                                                    Text="Visualizar Fogo"  PostBackUrl="~/cmd/Painel_Cmd.aspx" 
                                                    onclick="btn_reiniciar_fogo_Click"/>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_novo_fogo" runat="server" Text="Novo Fogo" Height="30px"  
                                                    Width="101px" onclick="btn_novo_fogo_Click" />
                                            </p>
                                        </h2>
    <div>
        <p style="margin-left: 20px">
        <asp:Table ID="Table2" runat="server" >
        <asp:TableRow ID="TableRow2" runat="server">
        <asp:TableCell Width="250">
        
            <asp:Label ID="l_morada" runat="server" Text="Morada:" style="margin-left: 40px" 
                    Enabled="False"></asp:Label><br />            
            <asp:TextBox ID="txt_morada" runat="server" style="margin-left: 40px" 
                    Enabled="False"></asp:TextBox><br />
            <asp:Label ID="l_concelho" runat="server" Text="Concelho:" 
                    style="margin-left: 40px" Enabled="False"></asp:Label><br />
            <asp:DropDownList ID="DropDown_concelhos" runat="server" style="margin-left: 40px" Width="128px"
                    DataSourceID="SqlDataSource1" DataTextField="CONCELHO_DESIGN" 
                    DataValueField="CONCELHO_DESIGN" AppendDataBoundItems="true" Enabled="False">
                    <asp:ListItem Value=""></asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BDFConnectionString %>" 
                SelectCommand="SELECT [CONCELHO_DESIGN] FROM [CONCELHO]">
            </asp:SqlDataSource>
        </asp:TableCell>
    
        <asp:TableCell>
            <asp:Label ID="l_lat" runat="server" Text="Latitude:" Enabled="False" style="margin-left: 40px"></asp:Label><br />
            <asp:TextBox id="txt_lat" runat="server" Enabled="false" style="margin-left: 40px"></asp:TextBox><br />
            <asp:Label ID="l_long" runat="server" Text="Longitude:" Enabled="false" style="margin-left: 40px"></asp:Label><br />
            <asp:TextBox ID="txt_long" runat="server" Enabled="false" style="margin-left: 40px"></asp:TextBox> <br /><br />
             
             
        </asp:TableCell>    
        </asp:TableRow> 
        <asp:TableRow ID="TableRow3" runat="server">
        <asp:TableCell Width="250">
        </asp:TableCell>  
        <asp:TableCell>
        <asp:Button ID="btn_inic_Fogo" runat="server" Height="30px" Text="Iniciar Fogo" 
                    OnClick="btn_inic_Fogo_Click" style="margin-left: 80px" Width="101px" Visible="False"/>            
        </asp:TableCell>
        </asp:TableRow> 
        </asp:Table>
        
        </p>
    </div>
    
    <div style="height: 88px">
        <br />
        <hr />
        <h2>Relatórios</h2>
                                            <div>
                                                <p style="margin-left: 120px">
                                                    <asp:ListBox ID="ListBox_rels" runat="server" Width="230px"></asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                                                        style="width: 33px" Text="OK" Width="122px" />
            </p>
        </div>
    </div>
                                        &nbsp;<br />
                                        &nbsp;<br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
    <asp:Table ID="Table1" runat="server" >
    <asp:TableRow ID="TableRow1" runat="server">
    <asp:TableCell Width="250">
    <asp:Label ID="label1" runat="server" Text="Código Fogo:" style="margin-left: 40px"></asp:Label><br />
    <asp:TextBox ID="txt_cod_fog" runat="server" ReadOnly="True" style="margin-left: 40px"></asp:TextBox><br />
    <asp:Label ID="label3" runat="server" Text="Concelho:" style="margin-left: 40px"></asp:Label><br />
    <asp:TextBox ID="txt_concelho" runat="server" ReadOnly="True" style="margin-left: 40px"></asp:TextBox><br />
    <asp:Label ID="label4" runat="server" Text="Baixas Bombeiros:" style="margin-left: 40px"></asp:Label><br />
    <asp:TextBox ID="txt_baixas_bomb" runat="server" style="margin-left: 40px"></asp:TextBox>
    <asp:Image ID="Image20" runat="server" Visible="false" 
            ImageUrl="~/civ/icons/ko.png" Height="16px" Width="17px" />
        <asp:Image ID="Image30" runat="server" Visible="false" Height="16px" 
            ImageUrl="~/civ/icons/ok.png" Width="18px" />
    <asp:Label ID="label6" runat="server" Text="Baixas Cívis:" style="margin-left: 40px"></asp:Label><br />
    <asp:TextBox ID="txt_baixas_civis" runat="server" style="margin-left: 40px"></asp:TextBox>
    <asp:Image ID="Image1" runat="server" Visible="false" 
            ImageUrl="~/civ/icons/ko.png" Height="16px" Width="17px" />
        <asp:Image ID="Image2" runat="server" Visible="false" Height="16px" 
            ImageUrl="~/civ/icons/ok.png" Width="18px" />
    </asp:TableCell>
    
    <asp:TableCell>
    <asp:Label ID="label2" runat="server" Text="Código Relatório:" style="margin-left: 40px"></asp:Label><br />
    <asp:TextBox ID="txt_cod_rel" runat="server" ReadOnly="True" style="margin-left: 40px"></asp:TextBox><br />
    <asp:Label ID="label7" runat="server" Text="Data de Inicio:" style="margin-left: 40px"></asp:Label><br />
    <asp:TextBox ID="txt_data_ini" runat="server" ReadOnly="True" style="margin-left: 40px"></asp:TextBox><br />
    <asp:Label ID="label8" runat="server" Text="Data de Circunscrito:" style="margin-left: 40px"></asp:Label><br />
    <asp:TextBox ID="txt_data_cir" runat="server" ReadOnly="True" style="margin-left: 40px"></asp:TextBox><br />
    <asp:Label ID="label9" runat="server" Text="Data de Fim:" style="margin-left: 40px"></asp:Label><br />
    <asp:TextBox ID="txt_data_fim" runat="server" ReadOnly="True" style="margin-left: 40px"></asp:TextBox><br />
   
    
    </asp:TableCell>    
    </asp:TableRow> 
    </asp:Table>
    
    
    
    <br /><br />
    <div>
        Comentario:
        <asp:TextBox ID="txt_comentario" runat="server" Height="115px" Width="551px" 
            MaxLength="8000" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
            Text="Submeter" />
    </div>
    <br />
    <br />


</asp:Content>

