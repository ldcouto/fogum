using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace FogUM
{
    public class Fogo
    {
        private int codigo;
        private float latitude;
        private float longitude;
        private float raio_fogo;
        private float raio_seg;
        private string concelho;
        private string distrito;
        private DateTime dh_comeco;
        private DateTime dh_circunscrito;
        private DateTime dh_extinto;
        private int baixas_civis;
        private int baixas_bombeiros;
        private string comentario;
        private int estado;
        private Relatorio relatorio;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
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

        public float Raio_fogo
        {
            get { return raio_fogo; }
            set { raio_fogo = value; }
        }

        public float Raio_seg
        {
            get { return raio_seg; }
            set { raio_seg = value; }
        }

        public string Concelho
        {
            get { return concelho; }
            set { concelho = value; }
        }

        public string Distrito
        {
            get { return distrito; }
            set { distrito = value; }
        }

        public DateTime Dh_comeco
        {
            get { return dh_comeco; }
            set { dh_comeco = value; }
        }

        public DateTime Dh_circunscrito
        {
            get { return dh_circunscrito; }
            set { dh_circunscrito = value; }
        }

        public DateTime Dh_extinto
        {
            get { return dh_extinto; }
            set { dh_extinto = value; }
        }

        public int Baixas_civis
        {
            get { return baixas_civis; }
            set { baixas_civis = value; }
        }

        public int Baixas_bombeiros
        {
            get { return baixas_bombeiros; }
            set { baixas_bombeiros = value; }
        }

        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Relatorio Rel
        {
            get { return relatorio; }
            set { relatorio = value; }
        }

       

        //CONSTRUCTORES
        public Fogo()
        {
           // this.codigo=0; temos de mudar isto
            this.latitude=0;
            this.longitude=0;
            this.raio_fogo=0;
            this.raio_seg=0;
            this.concelho="";
            this.distrito="";
            this.dh_comeco = new DateTime();
            //this.dh_circunscrito = new DateTime();
            //this.dh_extinto = new DateTime();
            this.baixas_civis=0;
            this.baixas_bombeiros=0;
            this.comentario="";
            this.estado=1; //1- Começo
        }

        public Fogo(int cod, float lat, float longi, float raio_f, float raio_s, string conc, string dist, DateTime dh_com, DateTime dh_cir, DateTime dh_ext, int baixas_civ, int baixas_bomb, string coment, int est)
        {
            this.codigo=cod;
            this.latitude=lat;
            this.longitude=longi;
            this.raio_fogo=raio_f;
            this.raio_seg=raio_s;
            this.concelho=conc;
            this.distrito=dist;
            this.dh_comeco=dh_com;
            this.dh_circunscrito=dh_cir;
            this.dh_extinto=dh_ext;
            this.baixas_civis=baixas_civ;
            this.baixas_bombeiros=baixas_bomb;
            this.comentario=coment;
            this.estado=est;
        }
    }
}
