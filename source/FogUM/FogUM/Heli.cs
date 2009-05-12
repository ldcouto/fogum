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
    public class Heli : Unidade
    {
        private int codigo;
        private String designacao;
        private Boolean disponivel;

        public int Cod
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public String Desig
        {
            get { return designacao; }
            set { designacao = value; }
        }

        public Boolean Disp
        {
            get { return disponivel; }
            set { disponivel = value; }
        }

        //constructores
       
        public Heli(int cod,string desig)
        {
            this.codigo = cod;
            this.designacao = desig;
            this.disponivel = true;
        }


    }
}
