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


public partial class Civil : PageBase
{

    Proc_Civil proc = new Proc_Civil();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        GoogleMapForASPNet1.GoogleMapObject.AutomaticBoundaryAndZoom = false;
        //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
        //For samples to run properly, set GoogleAPIKey in Web.Config file.
        GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["GoogleAPIKey"];

        //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
        GoogleMapForASPNet1.GoogleMapObject.Width = "600px"; // You can also specify percentage(e.g. 80%) here
        GoogleMapForASPNet1.GoogleMapObject.Height = "700px";

        //Specify initial Zoom level.
      
        GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 7;
        GoogleMapForASPNet1.GoogleMapObject.MapType = "G_HYBRID_MAP";

        //Specify Center Point for map. Map will be centered on this point.
        GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", 39.639000, -7.849731);



        MostraFogos();

    
    }


    private void MostraFogos()
    {
        Dictionary<int, Fogo> fogos = proc.selectMapaIncendios();

        foreach (Fogo f in fogos.Values)
        {
            GooglePoint GP1 = new GooglePoint();
            GP1.Latitude = f.Latitude;
            GP1.Longitude = f.Longitude;
            GP1.ID = "" + f.Codigo + "";
            string estado;
            string circunscrito;

            if (f.Estado == 1)
            {
                GP1.IconImage = "icons/fire.png";
                estado = "Activo";
                circunscrito = "";
            }
            else
            {
                GP1.IconImage = "icons/fire2.png";
                estado = "Circunscrito";
                circunscrito = "Circunscrito: " + f.Dh_circunscrito + "<br />";
            }

            GP1.InfoHTML = "<font color=\"#FF0000\"><U>    INFO DO FOGO</U></font><br /><br />" + "*** " + estado + "***" + "<br />" + "Concelho: " + f.Concelho + "<br />" + "Inicio: " + f.Dh_comeco + "<br />" + circunscrito + "Unidades no terreno: ";

            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP1);
        }

    }


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "";
    }
}
