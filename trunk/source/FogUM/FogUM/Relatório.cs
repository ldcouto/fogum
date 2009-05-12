using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FogUM
{
    public class Relatório
    {
        private int codigo;
        private String comentario;

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public String Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }
    }
}
