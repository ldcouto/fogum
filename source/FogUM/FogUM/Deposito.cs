using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FogUM
{
    public class Deposito
    {
        private int codigo;
        private float latitude;
        private float longitude;
        private float volume;
        private String descricao;

        public int Cod
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

        //CONSTRUCTORES
        public Deposito(int cod,float latitude,float longitude,float volume,String desc)
        {
            this.codigo = cod;
            this.latitude = latitude;
            this.longitude = longitude;
            this.descricao = desc;
        }
    }
}
