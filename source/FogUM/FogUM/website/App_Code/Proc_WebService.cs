﻿using System;
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


    /// <summary>
    /// WebServices da Plataforma FogUM
    /// </summary>
    // Definir e identificar os Web Services
    [WebService(Name="FogUM WS", Description="Web Services Plataforma FogUM", Namespace = "FogUM")]
    // Adicionar uma especificação
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Proc_WebService : System.Web.Services.WebService
    {
        BD_FogUM bdf = new BD_FogUM();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        // Marcar um método como WebMethod para o tornar acessível como Web Service
        [System.Web.Services.WebMethod(Description="Obter lista de voluntários para o seu distrito")]
        // Codificar e implementar o método normalmente
        public List<Vol_WS> listarVoluntarios(int codigoDistrito)
        {
            List<Vol_WS> r = new List<Vol_WS>();
            List<Voluntario> aux = new List<Voluntario>();
            aux = bdf.getVols(codigoDistrito);
            foreach (Voluntario v in aux)
            {
                r.Add(new Vol_WS(v));
            }
            return r;
        }

        [System.Web.Services.WebMethod(Description="Obter estatísticas de fogos florestais de um ano")]
        public EstAno estatatiscasAnuais(int ano)
        {
            EstAno r = new EstAno();
            r.Ano = ano;
            r.AreaArdida = bdf.getAAano(ano);
            r.NumFogos = bdf.getFogosAno(ano);
            r.TotalBaixasB = bdf.getBaixasBAno(ano);
            r.TotalBaixasC = bdf.getBaixasCAno(ano);
            return r;
        }

        // NEEDS TESTING!
        [System.Web.Services.WebMethod(Description = "Obter estatísticas dos fogos florestais dos últimos 7 dias")]
        public List<EstFogo> estataticasUltimos7Dias()
        {
            List<EstFogo> r = new List<EstFogo>();
            DateTime now = DateTime.Now;
            DateTime aux;
            float i;
            for (i = 0; i < 7; i++)
            {
               // TimeSpan ts = new TimeSpan(i, 0, 0, 0);
                aux = now.AddDays(-i);
                //dt.AddDays(-i);
                r.AddRange(bdf.getEstFogos(aux));
            }
            return r;
        }

    }
