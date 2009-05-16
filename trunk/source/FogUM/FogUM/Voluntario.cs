using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FogUM
{
    public class Voluntario
    {
        private int codigo;
        private int disp;
        private int codDist;
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

        public int Disp
        {
            get { return disp; }
            set { disp = value; }
        }

        public int CodDist
        {
            get { return codDist; }
            set { codDist = value; }
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
        public Voluntario(int cod, int disp, int codDist, String nome, String morada, String distrito, String telefone, String email)
        {
            this.codigo = cod;
            this.disp = disp;
            this.codDist = codDist;
            this.nome = nome;
            this.morada = morada;
            this.distrito = distrito;
            this.telefone = telefone;
            this.email = email;
        }
    }
}
