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
    public class BD_FogUM
    {

        //metodo para inserir deposito
        public void insereDeposito(Deposito d)
        {
            //metodo para inserir deposito
        }


        //metodo que devolve os fogos activos para mostrar no mapa
        
        public Dictionary<int, Fogo> getFogos_Activos()
        {
            Dictionary<int, Fogo> aux = new Dictionary<int, Fogo>();
            return aux;
        }

        //metodo que insere um voluntario na BD
        public void setVoluntario(Voluntario v)
        {
            //metodo que insere um voluntario na BD
        }
       
        //Metodos k falta fazer
        //public Dictionary<int, Unidade> getUnidadesDisponiveis()-metodo que da um map com a lista de unidades disponiveis
       
    }
}
