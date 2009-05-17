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

        private int codConcelho;

        public int CodConcelho
        {
            get { return codConcelho; }
            set { codConcelho = value; }
        }

        private double latitude;
        private double longitude;
        private float raio_fogo;
        private float raio_seg;
        private string concelho;
        // private string distrito; <- Não tá na BD - Luis
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

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public double Longitude
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
        // Fogo não leva distrito! - Luis
        //public string Distrito
        //{
        //    get { return distrito; }
        //    set { distrito = value; }
        //}

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
            this.codConcelho = 0;
            this.latitude=0;
            this.longitude=0;
            this.raio_fogo=0;
            this.raio_seg=0;
            this.concelho="";
          //  this.distrito="";
            this.dh_comeco = DateTime.Now;
            //this.dh_circunscrito = new DateTime();
            //this.dh_extinto = new DateTime();
            this.baixas_civis=0;
            this.baixas_bombeiros=0;
            this.comentario="";
            this.estado=1; //1- Começo
        }

        public Fogo(FOGO bdf)
        {
            this.codigo=bdf.COD_FOGO;
            this.codConcelho = bdf.COD_CONCELHO;
            this.latitude = bdf.LATITUDE_FOGO;
            this.longitude = bdf.LONGITUDE_FOGO;
            this.raio_fogo = (float) bdf.RAIO_FOGO;
            this.raio_seg = (float) bdf.RAIO_SEGURANCA;
            this.concelho = bdf.CONCELHO.CONCELHO_DESIGN;
            this.dh_comeco = bdf.DH_START;
            this.dh_circunscrito = bdf.DH_CIRCUNSCRITO;
            this.dh_extinto = bdf.DH_FIM;
            this.baixas_civis = (int) bdf.BAIXAS_CIVIS;
            this.baixas_bombeiros = (int) bdf.BAIXAS_BOMBEIROS;
            this.comentario = bdf.RELATORIO.COMENTARIO;
            this.estado = (int) bdf.COD_ESTADO;
        }

        public Fogo(int cod, int codConcelho, double lat, double longi, float raio_f, float raio_s, string conc, DateTime dh_com, DateTime dh_cir, DateTime dh_ext, int baixas_civ, int baixas_bomb, string coment, int est)
        {
            this.codigo=cod;
            this.codConcelho = codConcelho;
            this.latitude=lat;
            this.longitude=longi;
            this.raio_fogo=raio_f;
            this.raio_seg=raio_s;
            this.concelho=conc;
        //    this.distrito=dist;
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
