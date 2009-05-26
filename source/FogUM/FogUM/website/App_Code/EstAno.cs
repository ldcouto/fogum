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

/// <summary>
/// Summary description for EstAno
/// </summary>

    public class EstAno
    {
        int ano;

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }


        int numFogos;

        public int NumFogos
        {
            get { return numFogos; }
            set { numFogos = value; }
        }
        float areaArdida;

        public float AreaArdida
        {
            get { return areaArdida; }
            set { areaArdida = value; }
        }
        int totalBaixasC;

        public int TotalBaixasC
        {
            get { return totalBaixasC; }
            set { totalBaixasC = value; }
        }

        int totalBaixasB;

        public int TotalBaixasB
        {
            get { return totalBaixasB; }
            set { totalBaixasB = value; }
        }

        public EstAno()
        {
            numFogos = 0;
            areaArdida = 0;
            totalBaixasB = 0;
            totalBaixasC = 0;
        }
        public EstAno(int nFogos, float areaArdida, int totalBaixasC, int totalBaixasB, int ano)
        {
            this.ano = ano;
            this.numFogos = nFogos;
            this.areaArdida = areaArdida;
            this.totalBaixasC = totalBaixasC;
            this.totalBaixasB = totalBaixasB;
        }
    }
