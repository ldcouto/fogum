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
using FogUM.bd;
using FogUM;

    public class Vol_WS
    {
        private String disp;
        public String Disp
        {
            get { return disp; }
            set { disp = value; }
        }

        private String nome;
        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private String distrito;
        public String Distrito
        {
            get { return distrito; }
            set { distrito = value; }
        }

        private String telefone;
        public String Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        private String email;
        public String Email
        {
            get { return email; }
            set { email = value; }
        }


        public Vol_WS(VOLUNTARIADO bdVol)
        {
            this.disp = this.makeDisp((int)bdVol.DISPONIBILIDADE);
            this.nome = bdVol.NOME_VOLUNTARIO;
            this.distrito = bdVol.DISTRITO.DISTRITO_DESIGN;
            this.nome = bdVol.NOME_VOLUNTARIO;
            this.telefone = bdVol.NUM_TELEFONE.ToString();
            this.email = bdVol.EMAIL;

        }

        public Vol_WS()
        {
            this.disp="";
            this.distrito ="";
            this.email="";
            this.nome="";
            this.telefone="";
        }

        public Vol_WS(Voluntario volN)
        {
            this.disp = this.makeDisp(volN.Disp);
            this.distrito = volN.Distrito;
            this.email = volN.Email;
            this.nome = volN.Nome;
            this.telefone = volN.Telefone;
        }

        private string makeDisp(int cod)
        {
            System.Text.StringBuilder r = new System.Text.StringBuilder();
            r.Append(cod);
            r.Append(" meses");
            return r.ToString();


            //string r="Nenhuma";
            //switch (cod)
            //{
            //    case 0:
            //        r = "Baixa";
            //        break;
            //    case 1:
            //        r = "Média";
            //        break;
            //    case 2:
            //        r = "Alta";
            //        break;
            //    default:
            //        break;
            //}

            //return r;
        }

    }


