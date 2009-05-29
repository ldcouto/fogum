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
using System.Collections.Generic;



namespace FogUM
{
    public class Proc_Civil
    {
        private Voluntario volunt;
        private BD_FogUM bd=new BD_FogUM();
        private Deposito deposito_regist;
        private Dictionary<int,Fogo> fogosPais;

        //PROPRIEDADES
        public Voluntario Volunt
        {
            get { return volunt; }
            set { volunt = value; }
        }

        public Deposito Deposito_res
        {
            get { return deposito_regist; }
            set { deposito_regist = value; }
        }

        public Dictionary<int, Fogo> FogosPais
        {
            get { return fogosPais; }
            set { fogosPais = value; }
        }


        //METODOS

        //metodo completamente inofensivo....
        public void regDeposito()
        {
            Deposito_res = new Deposito();
            
        }
        
        public void insereDeposito(Deposito d)
        {
            bd.insereDeposito(d);
        }

        public float calcularVol(float altura, float largura,float comprimento)
        {
            float res=0;
            res = comprimento * largura * altura;
            return res;
        }

        //metodo que seleciona os incendios activos num dado dia,       e circunscritos axo que fazia sentido???
        public Dictionary<int, Fogo> selectMapaIncendios()
        {
            return bd.getFogos_Activos();//s calhar e perferivel devolver um treemap com todos os fogos e escolher 
                                        //os activos aqui nos procedimentos?? ou vem logo da BD direito??
        }

        public void submeterVoluntario(Voluntario v)
        {
            bd.setVoluntario(v);
        }

    }
}
