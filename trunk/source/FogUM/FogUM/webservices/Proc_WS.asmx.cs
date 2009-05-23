using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using FogUM.bd;
using FogUM;

namespace FogUM.webservices
{
    /// <summary>
    /// WebServices da Plataforma FogUM
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Proc_WS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }



        [System.Web.Services.WebMethod()]
    public List<int> teste1()
    {
        DBLinqDataContext bdf = new DBLinqDataContext();
        var auxQuery =
            (from rels in bdf.RELATORIOs
             where rels.COD_RELATORIO == 6
             select rels);

        List<int> r = new List<int>();
        r.Add(1);
        r.Add(2);
        r.Add(3);
        r.Add(4);
        r.Add(5);
        r.Add(6);

        return r;

    }


        [System.Web.Services.WebMethod(Description="Listagens de Voluntários para um Distrito")]
        public List<Vol_WS> listVols(int codDistrito)
        {
            List<Vol_WS> r = new List<Vol_WS>();
            BD_FogUM bdf = new BD_FogUM();
            List<Voluntario> aux = new List<Voluntario>();
            aux = bdf.getVols(codDistrito);
            foreach (Voluntario v in aux)
            {
                r.Add(new Vol_WS(v));
            }
            return r;
        }



    
    }
}
