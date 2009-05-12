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
        private float raio_foge;
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

        private int cod
        {
            get { return codigo; }
            set { codigo = value; }
        }
        
        private float lat
        {
            get { return latitude; }
            set { latitude = value; }
        }
        
        private float longi
        {
            get { return longitude; }
            set { longitude = value; }
        } 
        
        private float raio_f
        {
            get { return raio_foge; }
            set { raio_foge = value; }
        }
        
        private float raio_s
        {
            get { return raio_seg; }
            set { raio_seg = value; }
        }
        
        private string conc
        {
            get { return concelho; }
            set { concelho = value; }
        }

        private string dist
        {
            get { return distrito; }
            set { distrito = value; }
        }

        private DateTime dh_com
        {
            get { return dh_comeco; }
            set { dh_comeco = value; }
        }

        private DateTime dh_circ
        {
            get { return dh_circunscrito; }
            set { dh_circunscrito = value; }
        }

        private DateTime dh_ext
        {
            get { return dh_extinto; }
            set { dh_extinto = value; }
        }
        
        private int baixas_c
        {
            get { return baixas_civis; }
            set { baixas_civis = value; }
        }
        
        private int baixas_b
        {
            get { return baixas_bombeiros; }
            set { baixas_bombeiros = value; }
        }
        
        private string coment
        {
            get { return comentario; }
            set { comentario = value; }
        }
        
        private int est
        {
            get { return estado; }
            set { estado = value; }
        }

       

        //constructores
        public Fogo()
        {
            this.codigo=0;
            this.latitude=0;
            this.longitude=0;
            this.raio_foge=0;
            this.raio_seg=0;
            this.concelho="";
            this.distrito="";
            //this.dh_comeco=Null;
            //this.dh_circunscrito=Null;
            //this.dh_extinto=Null;
            this.baixas_civis=0;
            this.baixas_bombeiros=0;
            this.comentario="";
            this.estado=0;
        }

        public Fogo(int cod, float lat, float longi, float raio_f, float raio_s, string conc, string dist, DateTime dh_com, DateTime dh_cir, DateTime dh_ext, int baixas_civ, int baixas_bomb, string coment, int est)
        {
            this.codigo=cod;
            this.latitude=lat;
            this.longitude=longi;
            this.raio_foge=raio_f;
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
