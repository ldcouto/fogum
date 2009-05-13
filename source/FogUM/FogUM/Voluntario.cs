using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FogUM
{
    public class Voluntario
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

        //CONSTRUCTORES
        public Voluntario(int cod, String nome, String morada, String distrito, String telefone, String email)
        {
            this.codigo = cod;
            this.nome = nome;
            this.morada = morada;
            this.distrito = distrito;
            this.telefone = telefone;
            this.email = email;
        }
    }
}
