using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace FogUM
{
    public class Comandante
    {
        private int codigo;
        private String nome;
        private String user;
        private String pass;
        
        
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

        public String User
        {
            get { return user; }
            set { user = value; }
        }

        public String Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        //CONTRUCTORES
        public Comandante(int cod,string nome, string user, string pass)
        {
            this.codigo = cod;
            this.nome = nome;
            this.user = user;
            this.pass = pass;
        }
    }
}
