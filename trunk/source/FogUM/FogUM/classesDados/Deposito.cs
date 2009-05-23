using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FogUM.bd;

namespace FogUM
{
    public class Deposito
    {
        private int codigo;
        private double latitude;
        private double longitude;
        private float volume;
        private String descricao;
        private int codTipo; // Dá jeito estar isto aqui. - LC

        public int Cod
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

        public float Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public int CodTipo
        {
            get { return codTipo; }
            set { codTipo = value; }
        }

        //CONSTRUCTORES
        public Deposito(int codTipo, int cod, double latitude,double longitude,float volume,String desc)
        {
            this.codTipo = codTipo;
            this.codigo = cod;
            this.latitude = latitude;
            this.longitude = longitude;
            this.descricao = desc;
        }

        public Deposito(DEPOSITO bdD)
        {
            this.codTipo = bdD.COD_TIPO;
            this.codigo = bdD.COD_DEPO;
            this.latitude = bdD.LATITUDE;
            this.longitude = bdD.LONGITUDE;

            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                (from aux in bdf.TIPOS_DEPOs
                where aux.COD_TIPO==bdD.COD_TIPO
                select aux.TIPO_DESIGN).First();
            this.descricao = (string)auxQuery;
        }

        public Deposito()
        {
            //this.codigo = 0; Tem k se fazer a incrementar automaticamente
            this.codTipo = 0;
            this.latitude = 0;
            this.longitude = 0;
            this.descricao = "";
        }
    }
}

