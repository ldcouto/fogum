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

namespace FogUM.webservices
{
    public class Vol_WS
    {
        private String disp;
        private String nome;
        private String distrito;
        private String telefone;
        private String email;


        public Vol_WS(VOLUNTARIADO bdVol)
        {
            this.disp = this.makeDisp((int)bdVol.DISPONIBILIDADE);
            this.nome = bdVol.NOME_VOLUNTARIO;
            this.distrito = bdVol.DISTRITO.DISTRITO_DESIGN;
            this.nome = bdVol.NOME_VOLUNTARIO;
            this.telefone = bdVol.NUM_TELEFONE.ToString();
            this.email = bdVol.EMAIL;

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
            string r="Nenhuma";

            switch (cod)
            {
                case 0:
                    r = "Baixa";
                    break;
                case 1:
                    r = "Média";
                    break;
                case 2:
                    r = "Alta";
                    break;
                default:
                    break;
            }

            return r;
        }

    }

}
