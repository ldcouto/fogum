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

    Proc_Cmd procCmd = new Proc_Cmd(new Comandante(6, "Dummy CMD for Tests", "teste", "teste0!"));
    public Dictionary<int,int> amx;
    public Dictionary<int, GooglePoints> cm;

    public Dictionary<int, Dictionary<int,int> > heliamx;
    public Dictionary<int, GooglePoints> helicm;

    public SortedDictionary<double, int> pontosAgua;

    protected void Page_Load(object sender, EventArgs e)
    {
        procCmd.novoFogo();
        procCmd.getFogo(10);
        
        GoogleMapForASPNet1.GoogleMapObject.AutomaticBoundaryAndZoom = false;
        //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
        //For samples to run properly, set GoogleAPIKey in Web.Config file.
        GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];

        //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
        GoogleMapForASPNet1.GoogleMapObject.Width = "800px"; // You can also specify percentage(e.g. 80%) here
        GoogleMapForASPNet1.GoogleMapObject.Height = "500px";

        //Specify initial Zoom level.
        GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 16;

        //Specify Center Point for map. Map will be centered on this point.
        GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", 41.71931177723655, -8.16007375717163);
    }
    

    public void drawCircle(GooglePoint centro, double raio, int tipo)
    {
        GooglePolyline aresta = new GooglePolyline();
        double d = raio / 6378.8;

        double lat1 = (Math.PI / 180) * centro.Latitude; // radians
        double lng1 = (Math.PI / 180) * centro.Longitude; // radians

        for (int a = 0; a < 361; a++)
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
        //tracaRota(GoogleMapForASPNet1.GoogleMapObject.Points["4"], GoogleMapForASPNet1.GoogleMapObject.Points["2"]);

        GoogleMapForASPNet1.GoogleMapObject.Polylines.Add(lin1);
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


    public GooglePoints getPontosaDistancia(double metros, GooglePoint gp1, GooglePoint gp2, int x)
    {
        double next = metros;
        double y = 10000000;
        GooglePoints gps = new GooglePoints();
        if (metros <= 0) return gps;
        double dist = 0;
        dist += Distance(gp1, gp2);
        float n = procCmd.FogoCombate.Raio_fogo * 1000;
        if (x == 1)
        y = (dist - n);
        while (dist > next && next < y)
        {
            var m = next / dist;
            GooglePoint newpoint = new GooglePoint();
            newpoint.Latitude = gp1.Latitude + ((gp2.Latitude - gp1.Latitude) * m);
            newpoint.Longitude = gp1.Longitude + ((gp2.Longitude - gp1.Longitude) * m);
            gps.Add(newpoint);
            next += metros;
        }
        return gps;
    }

    public double Distance(GooglePoint pos1, GooglePoint pos2)
    {
        double RaioTerraKm = 6371;
        double dLat = toRadian(pos2.Latitude - pos1.Latitude);
        double dLon = toRadian(pos2.Longitude - pos1.Longitude);
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

    protected void Button8_Click(object sender, EventArgs e)
    {
        String result = ListBox1.SelectedValue.ToString();
        String[] n = result.Split('|');
        
        int x = Convert.ToInt32((n[0]));
        
        procCmd.adicionaCorp(procCmd.getCorp(x));
        actListBox();
        //para mexer
        
        amx = (Dictionary<int, int>)ViewState["amx"];
        if (amx == null)
            amx = new Dictionary<int, int>();

        cm = (Dictionary<int, GooglePoints>)ViewState["cm"];
        if (cm == null)
            cm = new Dictionary<int, GooglePoints>();
        GooglePoints pts = getPontosaDistancia(50, GoogleMapForASPNet1.GoogleMapObject.Points["C"+x.ToString()], GoogleMapForASPNet1.GoogleMapObject.Points["fogo"], 1);
        amx.Add(x, 0);
        cm.Add(x, pts);
        ViewState["amx"] = amx;
        ViewState["cm"] = cm;
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        String result = ListBox2.SelectedValue.ToString();
        String[] n = result.Split('|');
        int x = Convert.ToInt32(n[0]);
        procCmd.remCorp(procCmd.getCorp(x));
        actListBox();


        amx = (Dictionary<int, int>)ViewState["amx"];
        if (amx == null)
            amx = new Dictionary<int, int>();

        cm = (Dictionary<int, GooglePoints>)ViewState["cm"];
        if (cm == null)
            cm = new Dictionary<int, GooglePoints>();

        if (amx.ContainsKey(x))
            amx.Remove(x);
        if (cm.ContainsKey(x))
            cm.Remove(x);

        GoogleMapForASPNet1.GoogleMapObject.Points["C" + x.ToString()].Latitude = procCmd.getCorp(x).Latitude;

        GoogleMapForASPNet1.GoogleMapObject.Points["C" + x.ToString()].Longitude = procCmd.getCorp(x).Longitude;
        ViewState["amx"] = amx;
        ViewState["cm"] = cm;
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
    }

    protected void Button11_Click(object sender, EventArgs e)
    {

        String result = ListBox3.SelectedValue.ToString();
        String[] n = result.Split('|');

        int x = Convert.ToInt32((n[0]));
        procCmd.adicionaHeli(procCmd.getHeli(x));
        actListBox();

        //move no google maps
        heliamx = (Dictionary<int, Dictionary<int, int>>)ViewState["heliamx"];
        if (heliamx == null)
            heliamx = new Dictionary<int, Dictionary<int, int>>();

        helicm = (Dictionary<int, GooglePoints>)ViewState["helicm"];
        if (helicm == null)
            helicm = new Dictionary<int, GooglePoints>();
         pontosAgua = (SortedDictionary<double, int>)ViewState["pontosAgua"];
            if (pontosAgua == null)
                pontosAgua = new SortedDictionary<double, int>();
        double agua = pontosAgua.First().Value;
        pontosAgua.Remove(pontosAgua.First().Key);
        GooglePoints pts = getPontosaDistancia(100, GoogleMapForASPNet1.GoogleMapObject.Points["H"+x.ToString()], GoogleMapForASPNet1.GoogleMapObject.Points["A"+agua.ToString()], 0);
        
        Dictionary<int, int> novo = new Dictionary<int, int>();
        novo.Add(0, 0);
        heliamx.Add(x, novo);
        helicm.Add(x, pts);
        ViewState["heliamx"] = heliamx;
        ViewState["helicm"] = helicm;
        ViewState["pontosAgua"] = pontosAgua;

    }
    //Remove helis do fogo
    protected void Button12_Click(object sender, EventArgs e)
    {
        String result = ListBox4.SelectedValue.ToString();
        String[] n = result.Split('|');

        int x = Convert.ToInt32((n[0]));
        procCmd.remHeli(procCmd.getHeli(x));
        actListBox();
        GoogleMapForASPNet1.GoogleMapObject.Points["H" + x.ToString()].Latitude = 41.71887132733453;
        GoogleMapForASPNet1.GoogleMapObject.Points["H" + x.ToString()].Longitude = -8.167364001274109;

        heliamx = (Dictionary<int, Dictionary<int, int>>)ViewState["heliamx"];
        if (heliamx == null)
            heliamx = new Dictionary<int, Dictionary<int, int>>();

        helicm = (Dictionary<int, GooglePoints>)ViewState["helicm"];
        if (helicm == null)
            helicm = new Dictionary<int, GooglePoints>();
        pontosAgua = (SortedDictionary<double, int>)ViewState["pontosAgua"];
        if (pontosAgua == null)
            pontosAgua = new SortedDictionary<double, int>();
       

        heliamx.Remove(x);
        helicm.Remove(x);

        ViewState["heliamx"] = heliamx;
        ViewState["helicm"] = helicm;

        ViewState["pontosAgua"]=new SortedDictionary<double,int>();
        criaAgua(1);
        
       
    }
    //muda raio normal
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
            GoogleMapForASPNet1.GoogleMapObject.Polylines.Clear();
            drawCircle(GoogleMapForASPNet1.GoogleMapObject.Points["fogo"], procCmd.FogoCombate.Raio_fogo, 0);
            drawCircle(GoogleMapForASPNet1.GoogleMapObject.Points["fogo"], procCmd.FogoCombate.Raio_seg, 1);

            
        }
    }
    // Muda raio de seguranca
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
            GoogleMapForASPNet1.GoogleMapObject.Polylines.Clear();
            drawCircle(GoogleMapForASPNet1.GoogleMapObject.Points["fogo"], procCmd.FogoCombate.Raio_fogo, 0);
            drawCircle(GoogleMapForASPNet1.GoogleMapObject.Points["fogo"], procCmd.FogoCombate.Raio_seg, 1);
     
        }
    }

    public void criaFogoExemplo()
    {
        
        actListBox();
       
        GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", procCmd.FogoCombate.Latitude, procCmd.FogoCombate.Longitude);
        //icon fogo
        GooglePoint GP2 = new GooglePoint();
        GP2.ID = "fogo";
        GP2.Latitude = procCmd.FogoCombate.Latitude;
        GP2.Longitude = procCmd.FogoCombate.Longitude;
        GP2.InfoHTML = "Centro do fogo";
        GP2.IconImage = "icons/fire.png";
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP2);
        

        drawCircle(GoogleMapForASPNet1.GoogleMapObject.Points["fogo"], procCmd.FogoCombate.Raio_fogo, 0);
        drawCircle(GoogleMapForASPNet1.GoogleMapObject.Points["fogo"], procCmd.FogoCombate.Raio_seg, 1);

        foreach (KeyValuePair<int, Corporacao> c in procCmd.getCoorpDisponiveis())
        {
            GooglePoint GP6 = new GooglePoint();
            GP6.ID = "C" + c.Key;
            GP6.Latitude = c.Value.Latitude;
            GP6.Longitude = c.Value.Longitude;
            GP6.InfoHTML = c.Value.Nome;
            GP6.IconImage = "icons/FireTruck.png";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP6);
        }

        foreach (KeyValuePair<int, Corporacao> co in procCmd.getCoorpDestacadas())
        {
            GooglePoint CO6 = new GooglePoint();
            CO6.ID = "C" + co.Key;
            CO6.Latitude = co.Value.Latitude;
            CO6.Longitude = co.Value.Longitude;
            CO6.InfoHTML = co.Value.Nome;
            CO6.IconImage = "icons/FireTruck.png";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(CO6);
        }

        foreach (KeyValuePair<int, Heli> h in procCmd.getHeliDisponiveis())
        {
           
            GooglePoint GP4 = new GooglePoint();
            GP4.ID = "H" + h.Key;
            GP4.Latitude = 41.71887132733453;
            GP4.Longitude = -8.167364001274109;
            GP4.InfoHTML = h.Value.Desig;
            GP4.IconImage = "icons/helicopter2.png";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP4);
        }

        foreach (KeyValuePair<int, Heli> he in procCmd.getHelisDestacados())
        {

            GooglePoint HE4 = new GooglePoint();
            HE4.ID = "H" + he.Key;
            HE4.Latitude = 41.71887132733453;
            HE4.Longitude = -8.167364001274109;
            HE4.InfoHTML = he.Value.Desig;
            HE4.IconImage = "icons/helicopter2.png";
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(HE4);
        }
        criaAgua(0);
       
    }
    public void criaAgua(int x)
    {
        procCmd.constDepDisp(200);
        foreach (Deposito d in procCmd.DepositosDisp)
        {

            GooglePoint GP9 = new GooglePoint();
            GP9.ID = "A" + d.Cod;
            GP9.Latitude = d.Latitude;
            GP9.Longitude = d.Longitude;
            GP9.InfoHTML = d.Volume.ToString();
            GP9.IconImage = "icons/watertrans.png";
            if (x == 0)
                GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP9);

            pontosAgua = (SortedDictionary<double, int>)ViewState["pontosAgua"];
            if (pontosAgua == null)
                pontosAgua = new SortedDictionary<double, int>();

            pontosAgua.Add(Distance(GP9, GoogleMapForASPNet1.GoogleMapObject.Points["fogo"]), d.Cod);

            ViewState["pontosAgua"] = pontosAgua;
        }
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
    
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        mexe();
    }

    public void mexe()
    {
      //move corporacao
        amx = (Dictionary<int, int>)ViewState["amx"];
        if (amx == null)
            amx = new Dictionary<int, int>();

        cm = (Dictionary<int, GooglePoints>)ViewState["cm"];
        if (cm == null)
            cm = new Dictionary<int, GooglePoints>();

        Dictionary<int, int> aMexerNovoMudado= new Dictionary<int, int>();
        Dictionary<int, GooglePoints> ComoMexerNovoMudado = new Dictionary<int, GooglePoints>();
        foreach(KeyValuePair<int,int> linha in amx)
        {
            GooglePoints pts;
            cm.TryGetValue(linha.Key, out pts);
            if (linha.Value < pts.Count)
            {
                GoogleMapForASPNet1.GoogleMapObject.Points["C"+linha.Key.ToString()].Latitude = pts[linha.Value].Latitude;
                GoogleMapForASPNet1.GoogleMapObject.Points["C"+linha.Key.ToString()].Longitude = pts[linha.Value].Longitude;
                int x= linha.Value + 1;
                aMexerNovoMudado.Add(linha.Key, x);
                ComoMexerNovoMudado.Add(linha.Key, pts);
            }
        }
        ViewState["amx"] = aMexerNovoMudado;
        ViewState["cm"] = ComoMexerNovoMudado;
        //move heli

        heliamx = (Dictionary<int, Dictionary<int, int>>)ViewState["heliamx"];
        if (heliamx == null)
            heliamx = new Dictionary<int, Dictionary<int, int>>();

        helicm = (Dictionary<int, GooglePoints>)ViewState["helicm"];
        if (helicm == null)
            helicm = new Dictionary<int, GooglePoints>();

        Dictionary<int, Dictionary<int, int>> heliaMexer = new Dictionary<int, Dictionary<int, int>>();
        Dictionary<int, GooglePoints> heliComoMexer = new Dictionary<int, GooglePoints>();
        foreach (KeyValuePair<int, Dictionary<int, int>> linha in heliamx)
        {
            int aondeVai = 0 ;
            int sentido=0;
            int x =0;
            GooglePoints pts;
            helicm.TryGetValue(linha.Key, out pts);
            foreach (KeyValuePair<int, int> n in linha.Value)
            {
                aondeVai = n.Key;
                sentido = n.Value;
            }
            
                if (aondeVai < pts.Count && aondeVai>=0)
            {
                GoogleMapForASPNet1.GoogleMapObject.Points["H"+linha.Key.ToString()].Latitude = pts[aondeVai].Latitude;
                GoogleMapForASPNet1.GoogleMapObject.Points["H"+linha.Key.ToString()].Longitude = pts[aondeVai].Longitude;
                if (sentido == 0)
                    x = aondeVai + 1;
                if (sentido == 1)
                    x = aondeVai + 1;
                if (sentido == 2)
                    x = aondeVai - 1;
                Dictionary<int, int> novo = new Dictionary<int, int>();
                novo.Add(x, sentido);
                heliaMexer.Add(linha.Key, novo);
                heliComoMexer.Add(linha.Key, pts);
            }
                if (aondeVai == pts.Count && sentido == 0)
                {
                    GooglePoints pts1 = getPontosaDistancia(55, GoogleMapForASPNet1.GoogleMapObject.Points["H"+linha.Key.ToString()], GoogleMapForASPNet1.GoogleMapObject.Points["fogo"], 0);
                    Dictionary<int, int> novo = new Dictionary<int, int>();
                    novo.Add(0,1);
                    heliaMexer.Add(linha.Key, novo);
                    heliComoMexer.Add(linha.Key, pts1);
                }
                if (aondeVai == pts.Count && sentido == 1)
                {
                    Dictionary<int, int> novo = new Dictionary<int, int>();
                    novo.Add((pts.Count-1), 2);
                    heliaMexer.Add(linha.Key, novo);
                    heliComoMexer.Add(linha.Key, pts);
                }
                if (aondeVai <= -1 && sentido == 2)
                {
                    Dictionary<int, int> novo = new Dictionary<int, int>();
                    novo.Add(0, 1);
                    heliaMexer.Add(linha.Key, novo);
                    heliComoMexer.Add(linha.Key, pts);
                }       
        }
        ViewState["heliamx"] = heliaMexer;
        ViewState["helicm"] = heliComoMexer;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Timer1.Enabled = true;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Timer1.Enabled = false;
    }
}
