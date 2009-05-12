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

namespace FogUM
{
    public class Coorporacao : Unidade
    {
        private int codigo;
        private String nome;
        private String morada;
        private float latitude;
        private float longitude;
        private int n_homens;
        private int n_veiculos;

        public int Cod
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public String Nome
        {
            get { return nome; }
            set {nome = value; }
        }

        public String Morada
        {
            get { return morada; }
            set { morada = value; }
        }

        public float Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public float Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public int N_homens
        {
            get { return n_homens; }
            set { n_homens = value; }
        }

        public int N_veiculos
        {
            get { return n_veiculos; }
            set { n_veiculos = value; }
        }

        //constructores
        
        public Coorporacao(string cod,string nome,string morada,float latitude, float longitude,int n_veiculos,int n_homens)
        {
            this.codigo = cod;
            this.nome = nome;
            this.morada = morada;
            this.latitude = latitude;
            this.longitude = longitude;
            this.n_veiculos = n_veiculos;
            this.n_homens = n_homens;
            
        }
    }
}
