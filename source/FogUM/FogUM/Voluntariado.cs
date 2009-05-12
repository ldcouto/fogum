using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FogUM
{
    class Voluntariado
    {
        private int codigo;
        private String nome;
        private String morada;
        private String distrito;
        private String telefone;
        private String email;

        public int Cod
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public String Morada
        {
            get { return morada; }
            set { morada = value; }
        }

        public String Distrito
        {
            get { return distrito; }
            set { distrito = value; }
        }

        public String Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
