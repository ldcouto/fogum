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
using System.Text;
using System.IO;
using FogUM.bd;


namespace FogUM
{
    public class Parser
    {

        public string parseFogo()
        {

            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from fog in bdf.FOGOs
                select fog;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TAB_FOGO>\n\n");

            foreach (FOGO f in fQuery)
            {
                sb.Append("\t<FOGO>\n");
                sb.Append("\t\t<codFogo> " + f.COD_FOGO + " </codFogo> \n");
                sb.Append("\t\t<codEstado> " + f.COD_ESTADO + " </codEstado> \n");
                sb.Append("\t\t<codConcelho> " + f.COD_CONCELHO + " </codConcelho> \n");
                sb.Append("\t\t<codComandante> " + f.COD_COMANDANTE + " </codComandante> \n");
                sb.Append("\t\t<latitude> " + f.LATITUDE_FOGO + " </latitude> \n");
                sb.Append("\t\t<longitude> " + f.LONGITUDE_FOGO + " </longitude> \n");
                sb.Append("\t\t<dataCircunscrito> " + f.DH_CIRCUNSCRITO + " </dataCircunscrito> \n");
                sb.Append("\t\t<dataFim> " + f.DH_FIM + " </dataFim> \n");
                sb.Append("\t\t<dataInicio> " + f.DH_START + " </dataInicio> \n");
                sb.Append("\t\t<raioFogo> " + f.RAIO_FOGO + " </raioFogo> \n");
                sb.Append("\t\t<raioSeguranca> " + f.RAIO_SEGURANCA + " </raioSeguranca> \n");
                sb.Append("\t\t<baixasBomb> " + f.BAIXAS_BOMBEIROS + " </baixasBomb> \n");
                sb.Append("\t\t<baixasCivis> " + f.BAIXAS_CIVIS + " </baixasCivis> \n");
                sb.Append("\t\t<codRelatorio> " + f.COD_RELATORIO + " </codRelatorio> \n");
                sb.Append("\t\t<relatorio> " + f.RELATORIO + " </relatorio> \n");
                // sb.Append("\t\t<comandante> " + f.COMANDANTE + " </comandante> \n");
                // sb.Append("\t\t<concelho> " + f.CONCELHO + " </concelho> \n");
                // sb.Append("\t\t<corpFogos> " + f.CORPFOGOs + " </corpFogos> \n");                
                // sb.Append("\t\t<estado> " + f.ESTADO_FOGO + " </estado> \n");
                // sb.Append("\t\t<helis> " + f.HELIFOGOs + " </helis> \n");
                // sb.Append("\t\t<relatorios> " + f.RELATORIOs + " </relatorios> \n");
                sb.Append("\t</FOGO>\n\n");
            }
            sb.Append("</TAB_FOGO>\n\n");
            return sb.ToString();
        }


        public string parseComandante()
        {

            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from cmd in bdf.COMANDANTEs
                select cmd;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TAB_COMANDANTE>\n\n");

            foreach (COMANDANTE c in fQuery)
            {
                sb.Append("\t<COMANDANTE>\n");
                sb.Append("\t\t<nome> " + c.NOME + " </nome> \n");
                sb.Append("\t\t<codComandante> " + c.COD_COMANDANTE + " </codComandate> \n");
                //   sb.Append("\t\t<fogos> " + c.FOGOs + " </fogos> \n"); 
                sb.Append("\t\t<username> " + c.USERNAME + " </username> \n");
                sb.Append("\t\t<password> " + c.PASSWORD + " </password> \n");
                sb.Append("\t</COMANDANTE>\n\n");
            }
            sb.Append("</TAB_COMANDANTE>\n\n");
            return sb.ToString();
        }



        public string parseConselho()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from conc in bdf.CONCELHOs
                select conc;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TAB_CONCELHO>\n\n");

            foreach (CONCELHO c in fQuery)
            {
                sb.Append("\t<CONCELHO>\n");
                sb.Append("\t\t<codConcelho> " + c.COD_CONCELHO + " </codConcelho> \n");
                sb.Append("\t\t<concDesignacao> " + c.CONCELHO_DESIGN + " </concDesignacao> \n");
                //  sb.Append("\t\t<fogos> " + c.FOGOs + " </fogos> \n");
                sb.Append("\t</CONCELHO>\n\n");
            }
            sb.Append("</TAB_CONCELHO>\n\n");
            return sb.ToString();
        }



        public string parseCorpFogo()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from cp in bdf.CORPFOGOs
                select cp;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TAB_CORPFOGO>\n\n");

            foreach (CORPFOGO cp in fQuery)
            {
                sb.Append("\t<CORP_FOGO>\n");
                sb.Append("\t\t<codCorporacao> " + cp.COD_CORPORACAO + " </codCorporacao> \n");
                sb.Append("\t\t<codFogo> " + cp.COD_FOGO + " </codFogo> \n");
                //  sb.Append("\t\t<corporacao> " + cp.CORPORACAO + " </corporacao> \n");
                //  sb.Append("\t\t<fogo> " + cp.FOGO + " </fogo> \n");
                sb.Append("\t\t<numHomens> " + cp.NUM_HOMENS + " </numHomens> \n");
                sb.Append("\t\t<numVeiculos> " + cp.NUM_VEICULOS + " </numVeiculos> \n");
                sb.Append("\t</CORP_FOGO>\n\n");
            }
            sb.Append("</TAB_CORPFOGO>\n\n");
            return sb.ToString();
        }



        public string parseCorporacao()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from corp in bdf.CORPORACAOs
                select corp;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TAB_CORPORACAO>\n\n");

            foreach (CORPORACAO cp in fQuery)
            {
                sb.Append("\t<CORPORACAO>\n");
                sb.Append("\t\t<codCorporacao> " + cp.COD_CORPORACAO + " </codCorporacao> \n");
                // sb.Append("\t\t<codFogo> " + cp.CORPFOGOs + " </codFogo> \n");
                sb.Append("\t\t<designCorporacao> " + cp.CORPORACAO_DESIGN + " </designCorporacao> \n");
                sb.Append("\t\t<latitude> " + cp.LATITUDE_CORP + " </latitude> \n");
                sb.Append("\t\t<longitude> " + cp.LONGITUDE_CORP + " </longitude> \n");
                sb.Append("\t\t<numHomens> " + cp.NUM_HOMENS_DISP + " </numHomens> \n");
                sb.Append("\t\t<numVeiculos> " + cp.NUM_VEICULOS_DISP + " </numVeiculos> \n");
                sb.Append("\t\t<disponibilidade> " + cp.DISPONIBILIDADE_CORP + " </disponibilidade> \n");
                sb.Append("\t</CORPORACAO>\n\n");
            }
            sb.Append("</TAB_CORPORACAO>\n\n");
            return sb.ToString();
        }




        public string parseDepositos()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from dep in bdf.DEPOSITOs
                select dep;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TAB_DEPOSITOS>\n\n");

            foreach (DEPOSITO dep in fQuery)
            {
                sb.Append("\t<DEPOSITO>\n");
                sb.Append("\t\t<codDeposito> " + dep.COD_DEPO + " </codDeposito> \n");
                sb.Append("\t\t<codTipoDeposito> " + dep.COD_TIPO + " </codTipoDeposito> \n");
                sb.Append("\t\t<volume> " + dep.VOLUME + " </volume> \n");
                sb.Append("\t\t<latitude> " + dep.LATITUDE + " </latitude> \n");
                sb.Append("\t\t<longitude> " + dep.LONGITUDE + " </longitude> \n");
                // sb.Append("\t\t<tiposDeposito> " + dep.TIPOS_DEPO + " </tiposDeposito> \n");
                sb.Append("\t</DEPOSITO>\n\n");
            }
            sb.Append("</TAB_DEPOSITO>\n\n");
            return sb.ToString();
        }



        public string parseDistritos()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from dist in bdf.DISTRITOs
                select dist;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TAB_DISTRITOS>\n\n");

            foreach (DISTRITO disp in fQuery)
            {
                sb.Append("\t<DISTRITO>\n");
                sb.Append("\t\t<codDistrito> " + disp.COD_DISTRITO + " </codDistrito> \n");
                sb.Append("\t\t<designDistrito> " + disp.DISTRITO_DESIGN + " </designDistrito> \n");
                // sb.Append("\t\t<voluntarios> " + disp.VOLUNTARIADOs + " </voluntarios> \n");
                sb.Append("\t</DISTRITO>\n\n");
            }
            sb.Append("</TAB_DISTRITOS>\n\n");
            return sb.ToString();
        }



        public string parseEstadoFogo()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from est in bdf.ESTADO_FOGOs
                select est;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TAB_ESTADO_FOGO>\n\n");

            foreach (ESTADO_FOGO est in fQuery)
            {
                sb.Append("\t<ESTADO_FOGO>\n");
                sb.Append("\t\t<codEstado> " + est.COD_ESTADO + " </codEstado> \n");
                sb.Append("\t\t<designEstado> " + est.ESTADO_DESIGN + " </designEstado> \n");
                // sb.Append("\t\t<fogos> " + est.FOGOs+ " </fogos> \n");
                sb.Append("\t</ESTADO_FOGO>\n\n");
            }
            sb.Append("</TAB_ESTADO_FOGO>\n\n");
            return sb.ToString();
        }



        public string parseHeli()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from heli in bdf.HELIs
                select heli;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TAB_HELI>\n\n");

            foreach (HELI heli in fQuery)
            {
                sb.Append("\t<HELICOPTERO>\n");
                sb.Append("\t\t<codHelicoptero> " + heli.COD_HELI + " </codHelicoptero> \n");
                sb.Append("\t\t<designHelicoptero> " + heli.HELI_DESIGN + " </designHelicoptero> \n");
                sb.Append("\t\t<disponibilidade> " + heli.HELI_DISPONIBILIDADE + " </disponibilidade> \n");
                //sb.Append("\t\t<heliFogo> " + heli.HELIFOGOs + " </heliFogo> \n");
                sb.Append("\t</HELICOPTERO>\n\n");

            }
            sb.Append("</TAB_HELI>\n\n");
            return sb.ToString();
        }



        public string parseHeliFogo()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from heliF in bdf.HELIFOGOs
                select heliF;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TAB_HELIFOGOS>\n\n");

            foreach (HELIFOGO heliF in fQuery)
            {
                sb.Append("\t<HELIFOGO>\n");
                sb.Append("\t\t<codFogo> " + heliF.COD_FOGO + " </codFogo> \n");
                sb.Append("\t\t<codHelicoptero> " + heliF.COD_HELI + " </codHelicoptero> \n");
                //   sb.Append("\t\t<fogo> " + heliF.FOGO + " </fogo> \n");
                //  sb.Append("\t\t<helicoptero> " + heliF.HELI + " </helicoptero> \n");
                sb.Append("\t</HELIFOGO>\n\n");
            }
            sb.Append("</TAB_HELIFOGOS>\n\n");
            return sb.ToString();
        }



        public string parseRelatorio()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from rel in bdf.RELATORIOs
                select rel;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TAB_RELATORIO>\n\n");

            foreach (RELATORIO rel in fQuery)
            {
                sb.Append("\t<RELATORIO>\n");
                sb.Append("\t\t<codRelatorio> " + rel.COD_RELATORIO + " </codRelatorio> \n");
                sb.Append("\t\t<codFogo> " + rel.COD_FOGO + " </codFogo> \n");
                sb.Append("\t\t<comentario> " + rel.COMENTARIO + " </comentario> \n");
                // sb.Append("\t\t<fogo> " + rel.FOGO + " </fogo> \n");
                //  sb.Append("\t\t<fogos> " + rel.FOGOs + " </fogos> \n");
                sb.Append("\t</RELATORIO>\n\n");
            }
            sb.Append("</TAB_RELATORIO>\n\n");
            return sb.ToString();
        }


        public string parseTiposDepos()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from dep in bdf.TIPOS_DEPOs
                select dep;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TAB_TIPOS_DEPO>\n\n");

            foreach (TIPOS_DEPO dep in fQuery)
            {
                sb.Append("\t<TIPO_DEPO>\n");
                sb.Append("\t\t<codTipo> " + dep.COD_TIPO + " </codTipo> \n");
                sb.Append("\t\t<designTipo> " + dep.TIPO_DESIGN + " </designTipo> \n");
                //sb.Append("\t\t<depositos> " + dep.DEPOSITOs + " </depositos> \n");
                sb.Append("\t</TIPO_DEPO>\n\n");
            }
            sb.Append("</TAB_TIPOS_DEPO>\n\n");
            return sb.ToString();
        }



        public string parseVoluntariado()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from vol in bdf.VOLUNTARIADOs
                select vol;
            StringBuilder sb = new StringBuilder();
            sb.Append("<TAB_VOLUNTARIADO>\n\n");

            foreach (VOLUNTARIADO vol in fQuery)
            {
                sb.Append("\t<VOLUNTARIO>\n");
                sb.Append("\t\t<nome> " + vol.NOME_VOLUNTARIO + " </nome> \n");
                sb.Append("\t\t<numTelefone> " + vol.NUM_TELEFONE + " </numTelefone> \n");
                sb.Append("\t\t<email> " + vol.EMAIL + " </email> \n");
                sb.Append("\t\t<distrito> " + vol.DISTRITO + " </distrito> \n");
                sb.Append("\t\t<codDistrito> " + vol.COD_DISTRITO + " </codDistrito> \n");
                sb.Append("\t\t<codVoluntario> " + vol.COD_VOLUNTARIO + " </codVoluntario> \n");
                sb.Append("\t\t<disponibilidade> " + vol.DISPONIBILIDADE + " </disponibilidade> \n");
                sb.Append("\t</VOLUNTARIO\n\n");
            }
            sb.Append("</TAB_VOLUNTARIADO>\n\n");
            return sb.ToString();
        }


        public void criarXML()
        {
            TextWriter path = new StreamWriter("bd.xml");
            path.Write(this.parseFogo());
            path.Write(this.parseComandante());
            path.Write(this.parseConselho());
            path.Write(this.parseCorporacao());
            path.Write(this.parseCorpFogo());
            path.Write(this.parseDepositos());
            path.Write(this.parseDistritos());
            path.Write(this.parseEstadoFogo());
            path.Write(this.parseHeli());
            path.Write(this.parseHeliFogo());
            path.Write(this.parseRelatorio());
            path.Write(this.parseTiposDepos());
            path.Write(this.parseVoluntariado());
            path.Close();
        }

    }
}
