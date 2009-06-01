using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using FogUM;
using System.Collections.Generic;

public partial class Painel_Cmd : System.Web.UI.Page
{

    Proc_Cmd procCmd = new Proc_Cmd(new Comandante(1, "Rui Pereira", "teste", "teste"));
    Dictionary<int,int> aMexer;
    Dictionary<int, GooglePoints> comoMexer;
    public String teste = "start";

    protected void Page_Load(object sender, EventArgs e)
    {
        procCmd.novoFogo();
       // procCmd.getFogo(5);
        procCmd.getFogo(5);
        String g;
        //Criar Fogo exemplo
      


        //Codigo Nao sei se é preciso
        
        //        procCmd.subFomFogo(new Comandante(1, "Rui Pereira", "teste", "teste"));

        //    actListBox();

        GoogleMapForASPNet1.GoogleMapObject.AutomaticBoundaryAndZoom = false;
        //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
        //For samples to run properly, set GoogleAPIKey in Web.Config file.
        GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];

        //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
        GoogleMapForASPNet1.GoogleMapObject.Width = "1200px"; // You can also specify percentage(e.g. 80%) here
        GoogleMapForASPNet1.GoogleMapObject.Height = "500px";

        //Specify initial Zoom level.
        GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 16;

        //Specify Center Point for map. Map will be centered on this point.
        GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", 41.71931177723655, -8.16007375717163);

        //Add pushpins for map. 
        //This should be done with intialization of GooglePoint class. 
        //ID is to identify a pushpin. It must be unique for each pin. Type is string.
        //Other properties latitude and longitude.
        GooglePoint GP1 = new GooglePoint();
        GP1.ID = "1";
        GP1.Latitude = 41.71908754857274;
        GP1.Longitude = -8.167304992675781;
        //Specify bubble text here. You can use standard HTML tags here.
        GP1.InfoHTML = "This is Pushpin 1";

        //Specify icon image. This should be relative to root folder.
        GP1.IconImage = "icons/quartel2.png";
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP1);

        GooglePoint GP2 = new GooglePoint();
        GP2.ID = "2";
        GP2.Latitude = 41.71960007008327;
        GP2.Longitude = -8.151018619537354;
        GP2.InfoHTML = "This is Pushpin 2";
        GP2.IconImage = "icons/fire.png";
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP2);

        GooglePoint GP3 = new GooglePoint();
        GP3.ID = "3";
        GP3.Latitude = 41.723075498734076;
        GP3.Longitude = -8.15359354019165;
        GP3.InfoHTML = "This is Pushpin 3";
        GP3.IconImage = "icons/watertrans.png";
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP3);

        GooglePoint GP4 = new GooglePoint();
        GP4.ID = "4";
        GP4.Latitude = 41.71887132733453;
        GP4.Longitude = -8.167364001274109;
        GP4.InfoHTML = "This is Pushpin 4";
        GP4.IconImage = "icons/helicopter2.png";
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP4);

        GooglePoint GP5 = new GooglePoint();
        GP5.ID = "5";
        GP5.Latitude = 41.71887132755555;
        GP5.Longitude = -8.167364001274109;
        GP5.InfoHTML = "This is Pushpin 5";
        GP5.IconImage = "icons/FireTruck.png";
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP5);

        GooglePoint GP6 = new GooglePoint();
        GP6.ID = "6";
        GP6.Latitude = 41.723075498734076;
        GP6.Longitude = -8.167364001274109;
        GP6.InfoHTML = "This is Pushpin 6";
        GP6.IconImage = "icons/FireTruck.png";
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP6);

        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Note that buttons are placed inside an Ajax UpdatePanel. This is to prevent postback of the page.
        //Change latitude and longitude for point 1
        tracaRota(GoogleMapForASPNet1.GoogleMapObject.Points["4"], GoogleMapForASPNet1.GoogleMapObject.Points["2"]);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Timer1.Enabled == true) Timer1.Enabled = false;
        else Timer1.Enabled = true;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Timer2.Enabled == true) Timer2.Enabled = false;
        else Timer2.Enabled = true;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        double raio = 0.2;
        int tipo = 0;
        GooglePolyline aresta = new GooglePolyline();
        GooglePoint centro = new GooglePoint();

        centro = GoogleMapForASPNet1.GoogleMapObject.Points["2"];
        double d = raio / 6378.8;

        double lat1 = (Math.PI / 180) * centro.Latitude; // radians
        double lng1 = (Math.PI / 180) * centro.Longitude; // radians

        for (int a = 0; a < 270; a++)
        {
            double tc = (Math.PI / 180) * a;
            var y = Math.Asin(Math.Sin(lat1) * Math.Cos(d) + Math.Cos(lat1) * Math.Sin(d) * Math.Cos(tc));
            var dlng = Math.Atan2(Math.Sin(tc) * Math.Sin(d) * Math.Cos(lat1), Math.Cos(d) - Math.Sin(lat1) * Math.Sin(y));
            var x = ((lng1 - dlng + Math.PI) % (2 * Math.PI)) - Math.PI; // MOD function
            GooglePoint point = new GooglePoint();
            point.Latitude = y * (180 / Math.PI);
            point.Longitude = x * (180 / Math.PI);
            aresta.Points.Add(point);
        }

        GooglePolyline lin1 = new GooglePolyline();
        lin1.Points = aresta.Points;
       if (tipo == 0) lin1.ColorCode = "#FF0000";
        if (tipo == 1) lin1.ColorCode = "#00FFFF";
        lin1.Width = 4;

       // GoogleMapForASPNet1.GoogleMapObject.Polygons.Add(lin1);
        GoogleMapForASPNet1.GoogleMapObject.Polylines.Add(lin1);
        
        //drawCircle(GoogleMapForASPNet1.GoogleMapObject.Points["2"], 0.2, 0);
        //drawCircle(GoogleMapForASPNet1.GoogleMapObject.Points["2"], 0.4, 1);
    }

    //=============== animation functions ======================
      

      public void tracaRota(GooglePoint gp1, GooglePoint gp2)
      {
        GooglePolyline PL1 = new GooglePolyline();
        PL1.ID = "PL1";
        PL1.Points.Add(gp1);
        PL1.Points.Add(gp2);
        GoogleMapForASPNet1.GoogleMapObject.Polylines.Add(PL1);
      }


    public GooglePoints getPontosaDistancia(double metros, GooglePoint gp1, GooglePoint gp2)
    {
        double next = metros;
        GooglePoints gps = new GooglePoints();
        // some awkward special cases
        if (metros <= 0) return gps;
        double dist = 0;
        dist += Distance(gp1,gp2);
        while (dist > next)
        {
            var m = next/dist;
            GooglePoint newpoint = new GooglePoint();
            newpoint.Latitude = gp1.Latitude + ((gp2.Latitude-gp1.Latitude)*m);
            newpoint.Longitude = gp1.Longitude + ((gp2.Longitude-gp1.Longitude)*m);
            gps.Add(newpoint);
            next += metros;   
        }
        return gps;    
    }
    
    public double Distance(GooglePoint pos1, GooglePoint pos2)
    {
        double RaioTerraKm = 6371;
        double dLat = toRadian(pos2.Latitude-pos1.Latitude);
        double dLon = toRadian(pos2.Longitude-pos1.Longitude);
        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
        Math.Cos(this.toRadian(pos1.Latitude)) * Math.Cos(this.toRadian(pos2.Latitude)) *
        Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
        double d = RaioTerraKm * c;
        return d * 1000;
    }

    private double toRadian(double val)
    {
        return (Math.PI / 180) * val;
    }

   
//===============  End of animation functions =====================

    public int ti1 = 0;
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        GooglePoints pts = getPontosaDistancia(100, GoogleMapForASPNet1.GoogleMapObject.Points["4"], GoogleMapForASPNet1.GoogleMapObject.Points["3"]);
        if (ti1 < pts.Count)
        {
            GoogleMapForASPNet1.GoogleMapObject.Points["4"].Latitude = pts[ti1].Latitude;
            GoogleMapForASPNet1.GoogleMapObject.Points["4"].Longitude = pts[ti1].Longitude;
            ti1++;
        }
        else
        {
            Timer1.Enabled = false;
            Timer3.Enabled = true;
        }
    }

    public int ti2 = 0;
    protected void Timer2_Tick(object sender, EventArgs e)
    {
        GooglePoints pts = getPontosaDistancia(100, GoogleMapForASPNet1.GoogleMapObject.Points["5"], GoogleMapForASPNet1.GoogleMapObject.Points["2"]);
        if (ti2 < pts.Count)
        {
            GoogleMapForASPNet1.GoogleMapObject.Points["5"].Latitude = pts[ti2].Latitude;
            GoogleMapForASPNet1.GoogleMapObject.Points["5"].Longitude = pts[ti2].Longitude;
            ti2++;
        }
        else Timer2.Enabled = false;
    }

    public int ti3 = 0;
    protected void Timer3_Tick(object sender, EventArgs e)
    {
        GooglePoints pts = getPontosaDistancia(100, GoogleMapForASPNet1.GoogleMapObject.Points["4"], GoogleMapForASPNet1.GoogleMapObject.Points["2"]);
        if (ti3 < pts.Count)
        {
            GoogleMapForASPNet1.GoogleMapObject.Points["4"].Latitude = pts[ti3].Latitude;
            GoogleMapForASPNet1.GoogleMapObject.Points["4"].Longitude = pts[ti3].Longitude;
            ti3++;
        }
        else
        {
            Timer3.Enabled = false;
            Timer1.Enabled = true;
        }
    }

    public void drawCircle(GooglePoint centro, double raio, int tipo)
    {
        //tracaRota(GoogleMapForASPNet1.GoogleMapObject.Points["4"], GoogleMapForASPNet1.GoogleMapObject.Points["2"]);
        
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Proc_Cmd procCmd = new Proc_Cmd(new Comandante(1,"Rui Pereira","teste","teste"));
        Dictionary<int,Corporacao> n = new Dictionary<int,Corporacao>();
        n=procCmd.getCoorpDisponiveis();
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
          
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        String result = ListBox3.SelectedValue.ToString() ;
        String[] n = result.Split('|');

       TextBox1.Text = n[0];
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        String result = ListBox1.SelectedValue.ToString();
        String[] n = result.Split('|');
        
        int x = Convert.ToInt32((n[0]));
        
        procCmd.adicionaCorp(procCmd.getCorp(x));
        actListBox();
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        String result = ListBox2.SelectedValue.ToString();
        String[] n = result.Split('|');
        int x = Convert.ToInt32(n[0]);
        procCmd.remCorp(procCmd.getCorp(x));
        actListBox();
    }
    public void actListBox()
    {
        String adicio;
        ListBox1.Items.Clear();
        foreach (KeyValuePair<int, Corporacao> corporacao in procCmd.getCoorpDisponiveis())
        {
            adicio = string.Concat(corporacao.Key.ToString()," || ",corporacao.Value.Nome );
            
            ListBox1.Items.Add(adicio);

        }

        ListBox2.Items.Clear();
        foreach (KeyValuePair<int, Corporacao> corpor in procCmd.getCoorpDestacadas())
        {
            adicio = string.Concat(corpor.Key.ToString(), " || ", corpor.Value.Nome);
            ListBox2.Items.Add(adicio);
        }

        ListBox3.Items.Clear();
        foreach (KeyValuePair<int, Heli> heliDis in procCmd.getHeliDisponiveis())
        {
            adicio = string.Concat(heliDis.Key.ToString(), " || ", heliDis.Value.Desig);
            ListBox3.Items.Add(adicio);
        }

        ListBox4.Items.Clear();
        foreach (KeyValuePair<int, Heli> heliDes in procCmd.getHelisDestacados())
        {
            adicio = string.Concat(heliDes.Key.ToString(), " || ", heliDes.Value.Desig);
            ListBox4.Items.Add(adicio);
        }

        RaioFogo.Text = procCmd.FogoCombate.Raio_fogo.ToString();
        RaioSeguranca.Text = procCmd.FogoCombate.Raio_seg.ToString();

        preencheEstados();
        ListBox5.Items.Clear();
        ListBox5.Items.Add("Cod:"+procCmd.FogoCombate.Codigo.ToString());
        ListBox5.Items.Add("raio Fogo"+procCmd.FogoCombate.Raio_fogo.ToString());
        ListBox5.Items.Add("raio Seg"+procCmd.FogoCombate.Raio_seg.ToString());
        ListBox5.Items.Add("estado" + procCmd.FogoCombate.Estado.ToString());

        TBComentario.Text = procCmd.FogoCombate.Comentario;

    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        actListBox();
    }
    protected void Button11_Click(object sender, EventArgs e)
    {

        String result = ListBox3.SelectedValue.ToString();
        String[] n = result.Split('|');

        int x = Convert.ToInt32((n[0]));
        procCmd.adicionaHeli(procCmd.getHeli(x));
        actListBox();

    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        String result = ListBox4.SelectedValue.ToString();
        String[] n = result.Split('|');

        int x = Convert.ToInt32((n[0]));
        procCmd.remHeli(procCmd.getHeli(x));
        actListBox();
    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        
        
        
        float raioFog;
        float.TryParse(RaioFogo.Text.ToString(), out raioFog);
        if (raioFog == 0)
        {
            RaioSucesso.Visible = false;
            RaioInvalido.Visible = true;
            RaioFogo.Text = procCmd.FogoCombate.Raio_fogo.ToString();
        }
        else
        {
            procCmd.setRaio(raioFog);
            actListBox();
            RaioInvalido.Visible = false;
            RaioSucesso.Visible = true;

        }
    }
    protected void Button14_Click(object sender, EventArgs e)
    {
        float raioSeg;
        float.TryParse(RaioSeguranca.Text.ToString(), out raioSeg);
        if (raioSeg == 0 || raioSeg<=procCmd.FogoCombate.Raio_fogo)
        {
            RaioSSucesso.Visible = false;
            RaioSInvalido.Visible = true;
            RaioSeguranca.Text = procCmd.FogoCombate.Raio_seg.ToString();
        
        }
        else
        {
            procCmd.setRaioS(raioSeg);
            actListBox();
            RaioSInvalido.Visible = false;
            RaioSSucesso.Visible = true;
        }
    }

    public void criaFogoExemplo()
    {
        
        actListBox();

    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        criaFogoExemplo();
    }

    public void preencheEstados()
    {
        LabEstadoFogo.Text = procCmd.getEstadoString();
        int estF = procCmd.FogoCombate.Estado;
        if (estF == 1)
        {
           LabDataEstado1.Text = procCmd.FogoCombate.Dh_comeco.ToString();
           ButEstAct.Enabled=false;
           ButEstCir.Enabled = true;
           ButEstExt.Enabled = false;
        }
        
        if (estF == 2)
        {
            LabDataEstado1.Text = procCmd.FogoCombate.Dh_comeco.ToString();
            LabDataEstado2.Text = procCmd.FogoCombate.Dh_circunscrito.ToString();
            ButEstAct.Enabled = true;
            ButEstCir.Enabled = false;
            ButEstExt.Enabled = true;
        }
        if (estF == 3)
        {
            LabDataEstado1.Text = procCmd.FogoCombate.Dh_comeco.ToString();
            LabDataEstado2.Text = procCmd.FogoCombate.Dh_circunscrito.ToString();
            LabDataEstado3.Text = procCmd.FogoCombate.Dh_extinto.ToString();
            ButEstAct.Enabled = true;
            ButEstCir.Enabled = false;
            ButEstExt.Enabled = false;
        }
           



    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        procCmd.defineEstado(2);
        actListBox();
    }
    protected void ButEstAct_Click(object sender, EventArgs e)
    {
        procCmd.defineEstado(1);
        actListBox();
    }
    protected void ButEstExt_Click(object sender, EventArgs e)
    {
        procCmd.selTermComb();
        actListBox();
    }
    protected void ButComent_Click(object sender, EventArgs e)
    {
       procCmd.setComentario(TBComentario.Text);
       actListBox();
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //TextBox1.Text="asdasd";
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button16_Click(object sender, EventArgs e)
    {
       
       ViewState["teste"]= TextBox2.Text;
        TextBox2.Text="";
    }
    public void Button17_Click1(object sender, EventArgs e)
    {

      TextBox3.Text = (String)ViewState["teste"];

    }
    protected void Button18_Click(object sender, EventArgs e)
    {
        Dictionary<int, int> aMexerNovo = new Dictionary<int, int>();
        Dictionary<int, GooglePoints> comoMexerNovo = new Dictionary<int, GooglePoints>();
        aMexerNovo = (Dictionary<int, int>)ViewState["aMexer"];
        comoMexerNovo = (Dictionary<int, GooglePoints>)ViewState["comoMexer"];
        GooglePoints pts = getPontosaDistancia(50, GoogleMapForASPNet1.GoogleMapObject.Points["5"], GoogleMapForASPNet1.GoogleMapObject.Points["3"]);
        aMexerNovo.Add(5, 0);
        comoMexer.Add(5, pts);
        ViewState["aMexer"] = aMexerNovo;
        ViewState["comoMexer"] = comoMexer;
       
    }
    protected void Button20_Click(object sender, EventArgs e)
    {
        Dictionary<int, int> aMexerNovo = new Dictionary<int, int>();
        Dictionary<int, GooglePoints> comoMexerNovo = new Dictionary<int, GooglePoints>();
        aMexerNovo = (Dictionary<int, int>)ViewState["aMexer"];
        comoMexerNovo = (Dictionary<int, GooglePoints>)ViewState["comoMexer"];
        GooglePoints pts = getPontosaDistancia(50, GoogleMapForASPNet1.GoogleMapObject.Points["4"], GoogleMapForASPNet1.GoogleMapObject.Points["3"]);
        aMexerNovo.Add(4, 0);
        comoMexer.Add(4, pts);
        ViewState["aMexer"] = aMexerNovo;
        ViewState["comoMexer"] = comoMexer;
    }
    protected void Button19_Click(object sender, EventArgs e)
    {
        Timer4.Enabled = true;
    }
    protected void Timer4_Tick(object sender, EventArgs e)
    {
        mexe();
    }
    public void mexe()
    {
        Dictionary<int, int> aMexerNovo = new Dictionary<int, int>();
        Dictionary<int, GooglePoints> comoMexerNovo = new Dictionary<int, GooglePoints>();
        aMexerNovo = (Dictionary<int, int>)ViewState["aMexer"];
        comoMexerNovo = (Dictionary<int, GooglePoints>)ViewState["comoMexer"];

        Dictionary<int, int> aMexerNovoMudado= new Dictionary<int, int>();
        foreach(KeyValuePair<int,int> linha in aMexerNovo)
        {
            GooglePoints pts;
            comoMexerNovo.TryGetValue(linha.Key, out pts);
            if (linha.Value < pts.Count)
            {
                GoogleMapForASPNet1.GoogleMapObject.Points[linha.Key.ToString()].Latitude = pts[linha.Value].Latitude;
                GoogleMapForASPNet1.GoogleMapObject.Points[linha.Key.ToString()].Longitude = pts[linha.Value].Longitude;
                int x= linha.Value + 1;
                aMexerNovoMudado.Add(linha.Key, x);
            }
            

        }
        ViewState["aMexer"] = aMexerNovoMudado;


    }
}
