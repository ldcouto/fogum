using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace FogUM.bd
{
    public class EstFogo
    {
        string zona;
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        int nHomens;
        public int NHomens
        {
            get { return nHomens; }
            set { nHomens = value; }
        }

        int nVeiculos;
        public int NVeiculos
        {
            get { return nVeiculos; }
            set { nVeiculos = value; }
        }
        int nHelis;
        public int NHelis
        {
            get { return nHelis; }
            set { nHelis = value; }
        }

        float areaArdida;
        public float AreaArdida
        {
            get { return areaArdida; }
            set { areaArdida = value; }
        }

        string dhStart;
        public string DhStart
        {
            get { return dhStart; }
            set { dhStart = value; }
        }

        string dhEnd;
        public string DhEnd
        {
            get { return dhEnd; }
            set { dhEnd = value; }
        }

        int totalHH;
        public int TotalHH
        {
            get { return totalHH; }
            set { totalHH = value; }
        }

        string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        int nCompanhias;
        public int NCompanhias
        {
            get { return nCompanhias; }
            set { nCompanhias = value; }
        }

        int nBaixasC;
        public int NBaixasC
        {
            get { return nBaixasC; }
            set { nBaixasC = value; }
        }

        int nBaixasB;
        public int NBaixasB
        {
            get { return nBaixasB; }
            set { nBaixasB = value; }
        }

        string cmd;
        public string Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }

        public EstFogo()
        {

        }
    }
}
