using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FogUM
{
    public class Relatorio
    {
        private int codigo;
        private String comentario;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public String Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }

        //CONTRUCTORES
        public Relatorio(int cod, String comentario)
        {
            this.codigo = cod;
            this.comentario = comentario;
        }

        public Relatorio()
        {
            this.codigo = 0;
            this.comentario = "";
        }
    }
}
