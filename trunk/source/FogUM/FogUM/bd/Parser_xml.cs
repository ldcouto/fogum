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
using System.IO;
using System.Text.RegularExpressions;
using FogUM.bd;

namespace FogUM
{
    public class Parser_xml
    {




        public void le_fogo(StreamReader st)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();

            bd.FOGO f = new bd.FOGO();
            string linha;
            String[] aux;
            linha = st.ReadLine();
            while (!linha.Contains("</FOGO>"))
            {

                if (linha.Contains("codFogo"))
                {
                    Regex expF = new Regex("<codFogo>|</codFogo>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_FOGO = Convert.ToInt16(aux[1]);

                }
                if (linha.Contains("codEstado"))
                {
                    Regex expF = new Regex("<codEstado>|</codEstado>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_ESTADO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("codConcelho"))
                {
                    Regex expF = new Regex("<codConcelho>|</codConcelho>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_CONCELHO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("codComandante"))
                {
                    Regex expF = new Regex("<codComandante>|</codComandante>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_COMANDANTE = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("latitude"))
                {
                    Regex expF = new Regex("<latitude>|</latitude>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.LATITUDE_FOGO = Convert.ToDouble(aux[1]);
                }
                if (linha.Contains("longitude"))
                {
                    Regex expF = new Regex("<longitude>|</longitude>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.LONGITUDE_FOGO = Convert.ToDouble(aux[1]);
                }
                if (linha.Contains("dataCircunscrito"))
                {
                    Regex expF = new Regex("<dataCircunscrito>|</dataCircunscrito>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.DH_CIRCUNSCRITO = Convert.ToDateTime(aux[1]);
                }
                if (linha.Contains("dataFim"))
                {
                    Regex expF = new Regex("<dataFim>|</dataFim>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.DH_FIM = Convert.ToDateTime(aux[1]);
                }
                if (linha.Contains("dataInicio"))
                {
                    Regex expF = new Regex("<dataInicio>|</dataInicio>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.DH_START = Convert.ToDateTime(aux[1]);
                }
                if (linha.Contains("raioFogo"))
                {
                    Regex expF = new Regex("<raioFogo>|</raioFogo>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.RAIO_FOGO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("raioSeguranca"))
                {
                    Regex expF = new Regex("<raioSeguranca>|</raioSeguranca>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.RAIO_SEGURANCA = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("baixasBomb"))
                {
                    Regex expF = new Regex("<baixasBomb>|</baixasBomb>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.BAIXAS_BOMBEIROS = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("baixasCivis"))
                {
                    Regex expF = new Regex("<baixasCivis>|</baixasCivis>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.BAIXAS_CIVIS = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("codRelatorio"))
                {
                    Regex expF = new Regex("<codRelatorio>|</codRelatorio>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_RELATORIO = Convert.ToInt16(aux[1]);
                }
                linha = st.ReadLine();
            }
            //  bdf.ExecuteCommand("SET IDENTITY_INSERT FOGO ON");
            bdf.FOGOs.InsertOnSubmit(f);
            bdf.SubmitChanges();
            //  bdf.ExecuteCommand("SET IDENTITY_INSERT FOGO OFF");           
        }




        public void le_Comandante(StreamReader st)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            bd.COMANDANTE f = new bd.COMANDANTE();
            string linhaC;
            String[] aux;
            linhaC = st.ReadLine();
            while (!linhaC.Contains("</COMANDANTE>"))
            {

                if (linhaC.Contains("nome"))
                {
                    Regex expF = new Regex("<nome>|</nome>");
                    aux = expF.Split(linhaC);
                    f.NOME = aux[1];
                }
                if (linhaC.Contains("codComandante"))
                {
                    Regex expF = new Regex("<codComandante>|</codComandante>");
                    aux = expF.Split(linhaC);
                    if (aux[1] != "")
                        f.COD_COMANDANTE = Convert.ToInt16(aux[1]);
                }
                if (linhaC.Contains("username"))
                {
                    Regex expF = new Regex("<username>|</username>");
                    aux = expF.Split(linhaC);
                    f.USERNAME = aux[1];
                }
                if (linhaC.Contains("password"))
                {
                    Regex expF = new Regex("<password>|</password>");
                    aux = expF.Split(linhaC);
                    f.PASSWORD = aux[1];
                }
                linhaC = st.ReadLine();
            }
            //   bdf.ExecuteCommand("SET IDENTITY_INSERT COMANDANTE ON");
            bdf.COMANDANTEs.InsertOnSubmit(f);
            bdf.SubmitChanges();
            //   bdf.ExecuteCommand("SET IDENTITY_INSERT COMANDANTE OFF");
        }





        public void le_Conselho(StreamReader st)
        {
            int i = 0;
            DBLinqDataContext bdf = new DBLinqDataContext();
            bd.CONCELHO f = new bd.CONCELHO();
            string linha;
            String[] aux;
            linha = st.ReadLine();
            while (!linha.Contains("</CONCELHO>"))
            {

                if (linha.Contains("codConcelho"))
                {
                    Regex expF = new Regex("<codConcelho>|</codConcelho>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_CONCELHO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("concDesignacao"))
                {
                    Regex expF = new Regex("<concDesignacao>|</concDesignacao>");
                    aux = expF.Split(linha);
                    f.CONCELHO_DESIGN = aux[1];
                }
                linha = st.ReadLine();
            }

            //bdf.ExecuteCommand("SET IDENTITY_INSERT CONCELHO ON");
            bdf.CONCELHOs.InsertOnSubmit(f);
            //if (f.COD_CONCELHO == 3)
            //    i = 1;
            bdf.SubmitChanges();
            // bdf.ExecuteCommand("SET IDENTITY_INSERT CONCELHO OFF");




        }




        public void le_Corporacao(StreamReader st)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            bd.CORPORACAO f = new bd.CORPORACAO();
            string linha;
            String[] aux;
            linha = st.ReadLine();
            while (!linha.Contains("</CORPORACAO>"))
            {

                if (linha.Contains("codCorporacao"))
                {
                    Regex expF = new Regex("<codCorporacao>|</codCorporacao>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_CORPORACAO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("designCorporacao"))
                {
                    Regex expF = new Regex("<designCorporacao>|</designCorporacao>");
                    aux = expF.Split(linha);
                    f.CORPORACAO_DESIGN = aux[1];
                }
                if (linha.Contains("latitude"))
                {
                    Regex expF = new Regex("<latitude>|</latitude>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.LATITUDE_CORP = Convert.ToDouble(aux[1]);
                }
                if (linha.Contains("longitude"))
                {
                    Regex expF = new Regex("<longitude>|</longitude>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.LONGITUDE_CORP = Convert.ToDouble(aux[1]);
                }
                if (linha.Contains("numHomens"))
                {
                    Regex expF = new Regex("<numHomens>|</numHomens>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.NUM_HOMENS_DISP = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("numVeiculos"))
                {
                    Regex expF = new Regex("<numVeiculos>|</numVeiculos>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.NUM_VEICULOS_DISP = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("disponibilidade"))
                {
                    Regex expF = new Regex("<disponibilidade>|</disponibilidade>");
                    aux = expF.Split(linha);
                    f.DISPONIBILIDADE_CORP = Convert.ToBoolean(aux[1]);
                }
                linha = st.ReadLine();
            }
            //   bdf.ExecuteCommand("SET IDENTITY_INSERT CORPORACAO ON");
            bdf.CORPORACAOs.InsertOnSubmit(f);
            bdf.SubmitChanges();
            //   bdf.ExecuteCommand("SET IDENTITY_INSERT CORPORACAO OFF");
        }




        public void le_CorpFogo(StreamReader st)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            bd.CORPFOGO f = new bd.CORPFOGO();
            string linha;
            String[] aux;
            linha = st.ReadLine();
            while (!linha.Contains("</CORP_FOGO>"))
            {

                if (linha.Contains("codCorporacao"))
                {
                    Regex expF = new Regex("<codCorporacao>|</codCorporacao>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_CORPORACAO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("codFogo"))
                {
                    Regex expF = new Regex("<codFogo>|</codFogo>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_FOGO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("numHomens"))
                {
                    Regex expF = new Regex("<numHomens>|</numHomens>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.NUM_HOMENS = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("numVeiculos"))
                {
                    Regex expF = new Regex("<numVeiculos>|</numVeiculos>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.NUM_VEICULOS = Convert.ToInt16(aux[1]);
                }
                linha = st.ReadLine();
            }
            //     bdf.ExecuteCommand("SET IDENTITY_INSERT CORPFOGO ON");
            bdf.CORPFOGOs.InsertOnSubmit(f);
            bdf.SubmitChanges();
            //    bdf.ExecuteCommand("SET IDENTITY_INSERT CORPFOGO OFF");
        }




        public void le_Depositos(StreamReader st)
        {

            DBLinqDataContext bdf = new DBLinqDataContext();
            bd.DEPOSITO f = new bd.DEPOSITO();
            string linha;
            String[] aux;
            linha = st.ReadLine();
            while (!linha.Contains("</DEPOSITO>"))
            {

                if (linha.Contains("codDeposito"))
                {
                    Regex expF = new Regex("<codDeposito>|</codDeposito>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_DEPO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("codTipoDeposito"))
                {
                    Regex expF = new Regex("<codTipoDeposito>|</codTipoDeposito>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_TIPO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("volume"))
                {
                    Regex expF = new Regex("<volume>|</volume>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.VOLUME = Convert.ToInt32(aux[1]);
                }
                if (linha.Contains("atitude"))
                {
                    Regex expF = new Regex("<latitude>|</latitude>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.LATITUDE = Convert.ToDouble(aux[1]);
                }
                if (linha.Contains("longitude"))
                {
                    Regex expF = new Regex("<longitude>|</longitude>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.LONGITUDE = Convert.ToDouble(aux[1]);
                }
                linha = st.ReadLine();
            }
            //    bdf.ExecuteCommand("SET IDENTITY_INSERT DEPOSITO ON");
            bdf.DEPOSITOs.InsertOnSubmit(f);
            bdf.SubmitChanges();
            //   bdf.ExecuteCommand("SET IDENTITY_INSERT DEPOSITO OFF");
        }




        public void le_Distritos(StreamReader st)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            bd.DISTRITO f = new bd.DISTRITO();
            string linha;
            String[] aux;
            linha = st.ReadLine();
            while (!linha.Contains("</DISTRITO>"))
            {

                if (linha.Contains("codDistrito"))
                {
                    Regex expF = new Regex("<codDistrito>|</codDistrito>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_DISTRITO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("designDistrito"))
                {
                    Regex expF = new Regex("<designDistrito>|</designDistrito>");
                    aux = expF.Split(linha);
                    f.DISTRITO_DESIGN = aux[1];
                }

                linha = st.ReadLine();
            }
            //   bdf.ExecuteCommand("SET IDENTITY_INSERT DISTRITO ON");
            bdf.DISTRITOs.InsertOnSubmit(f);
            bdf.SubmitChanges();
            //  bdf.ExecuteCommand("SET IDENTITY_INSERT DISTRITO OFF");
        }




        public void le_EstadoFogo(StreamReader st)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            bd.ESTADO_FOGO f = new bd.ESTADO_FOGO();
            string linha;
            String[] aux;
            linha = st.ReadLine();
            while (!linha.Contains("</ESTADO_FOGO>"))
            {

                if (linha.Contains("codEstado"))
                {
                    Regex expF = new Regex("<codEstado>|</codEstado>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_ESTADO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("designEstado"))
                {
                    Regex expF = new Regex("<designEstado>|</designEstado>");
                    aux = expF.Split(linha);
                    f.ESTADO_DESIGN = aux[1];
                }

                linha = st.ReadLine();
            }
            //    bdf.ExecuteCommand("SET IDENTITY_INSERT ESTADO_FOGO ON");
            bdf.ESTADO_FOGOs.InsertOnSubmit(f);
            bdf.SubmitChanges();
            //    bdf.ExecuteCommand("SET IDENTITY_INSERT ESTADO_FOGO OFF");
        }




        public void le_Heli(StreamReader st)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            bd.HELI f = new bd.HELI();
            string linha;
            String[] aux;
            linha = st.ReadLine();
            while (!linha.Contains("</HELICOPTERO>"))
            {

                if (linha.Contains("codDistrito"))
                {
                    Regex expF = new Regex("<codHelicoptero>|</codHelicoptero>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_HELI = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("designHelicoptero"))
                {
                    Regex expF = new Regex("<designHelicoptero>|</designHelicoptero>");
                    aux = expF.Split(linha);
                    f.HELI_DESIGN = aux[1];
                }
                if (linha.Contains("disponibilidade"))
                {
                    Regex expF = new Regex("<disponibilidade>|</disponibilidade>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.HELI_DISPONIBILIDADE = Convert.ToBoolean(aux[1]);
                }

                linha = st.ReadLine();
            }
            //     bdf.ExecuteCommand("SET IDENTITY_INSERT HELICOPTERO ON");
            bdf.HELIs.InsertOnSubmit(f);
            bdf.SubmitChanges();
            //     bdf.ExecuteCommand("SET IDENTITY_INSERT HELICOPTERO OFF");
        }




        public void le_HeliFogo(StreamReader st)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            bd.HELIFOGO f = new bd.HELIFOGO();
            string linha;
            String[] aux;
            linha = st.ReadLine();
            while (!linha.Contains("</HELIFOGO>"))
            {

                if (linha.Contains("codFogo"))
                {
                    Regex expF = new Regex("<codFogo>|</codFogo>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_FOGO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("codHelicoptero"))
                {
                    Regex expF = new Regex("<codHelicoptero>|</codHelicoptero>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_HELI = Convert.ToInt16(aux[1]);
                }

                linha = st.ReadLine();
            }
            //      bdf.ExecuteCommand("SET IDENTITY_INSERT HELIFOGO ON");
            bdf.HELIFOGOs.InsertOnSubmit(f);
            bdf.SubmitChanges();
            //      bdf.ExecuteCommand("SET IDENTITY_INSERT HELIFOGO OFF");

        }




        public void le_Relatorio(StreamReader st)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            bd.RELATORIO f = new bd.RELATORIO();
            string linha;
            String[] aux;
            linha = st.ReadLine();
            while (!linha.Contains("</RELATORIO>"))
            {

                if (linha.Contains("codRelatorio"))
                {
                    Regex expF = new Regex("<codRelatorio>|</codRelatorio>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_RELATORIO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("codFogo"))
                {
                    Regex expF = new Regex("<codFogo>|</codFogo>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_FOGO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("comentario"))
                {
                    Regex expF = new Regex("<comentario>|</comentario>");
                    aux = expF.Split(linha);
                    f.COMENTARIO = aux[1];
                }

                linha = st.ReadLine();
            }
            //      bdf.ExecuteCommand("SET IDENTITY_INSERT RELATORIO ON");
            bdf.RELATORIOs.InsertOnSubmit(f);
            bdf.SubmitChanges();
            //      bdf.ExecuteCommand("SET IDENTITY_INSERT RELATORIO OFF");
        }




        public void le_TiposDepos(StreamReader st)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            bd.TIPOS_DEPO f = new bd.TIPOS_DEPO();
            string linha;
            String[] aux;
            linha = st.ReadLine();
            while (!linha.Contains("</TIPO_DEPO>"))
            {

                if (linha.Contains("codTipo"))
                {
                    Regex expF = new Regex("<codTipo>|</codTipo>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_TIPO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("designTipo"))
                {
                    Regex expF = new Regex("<designTipo>|</designTipo>");
                    aux = expF.Split(linha);
                    f.TIPO_DESIGN = aux[1];
                }

                linha = st.ReadLine();
            }
            //        bdf.ExecuteCommand("SET IDENTITY_INSERT TIPOS_DEPOS ON");
            bdf.TIPOS_DEPOs.InsertOnSubmit(f);
            bdf.SubmitChanges();
            //        bdf.ExecuteCommand("SET IDENTITY_INSERT TIPOS_DEPOS OFF");
        }




        public void le_Voluntariado(StreamReader st)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            bd.VOLUNTARIADO f = new bd.VOLUNTARIADO();
            string linha;
            String[] aux;
            linha = st.ReadLine();
            while (!linha.Contains("</VOLUNTARIO>"))
            {

                if (linha.Contains("nome"))
                {
                    Regex expF = new Regex("<nome>|</nome>");
                    aux = expF.Split(linha);
                    f.NOME_VOLUNTARIO = aux[1];
                }
                if (linha.Contains("numTelefone"))
                {
                    Regex expF = new Regex("<numTelefone>|</numTelefone>");
                    aux = expF.Split(linha);
                    f.NUM_TELEFONE = aux[1];
                }
                if (linha.Contains("email"))
                {
                    Regex expF = new Regex("<email>|</email>");
                    aux = expF.Split(linha);
                    f.EMAIL = aux[1];
                }
                if (linha.Contains("codDistrito"))
                {
                    Regex expF = new Regex("<codDistrito>|</codDistrito>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_DISTRITO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("codVoluntario"))
                {
                    Regex expF = new Regex("<codVoluntario>|</codVoluntario>");
                    aux = expF.Split(linha);
                    if (aux[1] != "")
                        f.COD_VOLUNTARIO = Convert.ToInt16(aux[1]);
                }
                if (linha.Contains("disponibilidade"))
                {
                    Regex expF = new Regex("<disponibilidade>|</disponibilidade>");
                    aux = expF.Split(linha);
                    f.DISPONIBILIDADE = Convert.ToInt16(aux[1]);
                }
                linha = st.ReadLine();
            }
            //       bdf.ExecuteCommand("SET IDENTITY_INSERT VOLUNTARIADO ON");
                     bdf.VOLUNTARIADOs.InsertOnSubmit(f);
                     bdf.SubmitChanges();
            //       bdf.ExecuteCommand("SET IDENTITY_INSERT VOLUNTARIADO OFF");
        }



        public void apagaBD()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
               from fog in bdf.CORPFOGOs
               select fog;
            foreach (CORPFOGO f in fQuery)
            {
                bdf.CORPFOGOs.DeleteOnSubmit(f);
                bdf.SubmitChanges();
            }

            var fQuery1 =
                from fog in bdf.RELATORIOs
                select fog;
            foreach (RELATORIO f in fQuery1)
            {
                bdf.RELATORIOs.DeleteOnSubmit(f);
                bdf.SubmitChanges();
            }

            var fQuery2 =
                from fog in bdf.FOGOs
                select fog;
            foreach (FOGO f in fQuery2)
            {
                bdf.FOGOs.DeleteOnSubmit(f);
                bdf.SubmitChanges();
            }

            var fQuery3 =
                from fog in bdf.CORPORACAOs
                select fog;
            foreach (CORPORACAO f in fQuery3)
            {
                bdf.CORPORACAOs.DeleteOnSubmit(f);
                bdf.SubmitChanges();
            }

            var fQuery4 =
               from fog in bdf.VOLUNTARIADOs
               select fog;
            foreach (VOLUNTARIADO f in fQuery4)
            {
                bdf.VOLUNTARIADOs.DeleteOnSubmit(f);
                bdf.SubmitChanges();
            }

            var fQuery5 =
               from fog in bdf.HELIs
               select fog;
            foreach (HELI f in fQuery5)
            {
                bdf.HELIs.DeleteOnSubmit(f);
                bdf.SubmitChanges();
            }

            var fQuery6 =
               from fog in bdf.HELIFOGOs
               select fog;
            foreach (HELIFOGO f in fQuery6)
            {
                bdf.HELIFOGOs.DeleteOnSubmit(f);
                bdf.SubmitChanges();
            }

            var fQuery7 =
               from fog in bdf.ESTADO_FOGOs
               select fog;
            foreach (ESTADO_FOGO f in fQuery7)
            {
                bdf.ESTADO_FOGOs.DeleteOnSubmit(f);
                bdf.SubmitChanges();
            }

            var fQuery8 =
               from fog in bdf.DISTRITOs
               select fog;
            foreach (DISTRITO f in fQuery8)
            {
                bdf.DISTRITOs.DeleteOnSubmit(f);
                bdf.SubmitChanges();
            }

            var fQuery9 =
               from fog in bdf.CONCELHOs
               select fog;
            foreach (CONCELHO f in fQuery9)
            {
                bdf.CONCELHOs.DeleteOnSubmit(f);
                bdf.SubmitChanges();
            }

            var fQuery11 =
              from fog in bdf.DEPOSITOs
              select fog;
            foreach (DEPOSITO f in fQuery11)
            {
                bdf.DEPOSITOs.DeleteOnSubmit(f);
                bdf.SubmitChanges();
            }

            var fQuery10 =
               from fog in bdf.TIPOS_DEPOs
               select fog;
            foreach (TIPOS_DEPO f in fQuery10)
            {
                bdf.TIPOS_DEPOs.DeleteOnSubmit(f);
                bdf.SubmitChanges();
            }



            var fQuery12 =
               from fog in bdf.COMANDANTEs
               select fog;
            foreach (COMANDANTE f in fQuery12)
            {
                bdf.COMANDANTEs.DeleteOnSubmit(f);
                bdf.SubmitChanges();
            }

        }
        
        
        
        
        public void le_xml(string data)
        {


            apagaBD();


            Regex expFg = new Regex("<FOGO>");
            Regex expCmd =new Regex("<COMANDANTE>");
            Regex expConc = new Regex("<CONCELHO>");
            Regex expCorp = new Regex("<CORPORACAO>");
            Regex expCorpFg = new Regex("<CORP_FOGO>");
            Regex expDep = new Regex("<DEPOSITO>");
            Regex expDist = new Regex("<DISTRITO>");
            Regex expEstFg = new Regex("<ESTADO_FOGO>");
            Regex expHeli = new Regex("<HELI>");
            Regex expHeliFg = new Regex("<HELIFOGO>");
            Regex expRel = new Regex("<RELATORIO>");
            Regex expTipoDep = new Regex("<TIPO_DEPO>");
            Regex expVol = new Regex("<VOLUNTARIO>");

            string aux = data + ".xml";


            FileStream file = new FileStream(aux, FileMode.Open);
            StreamReader st = new StreamReader(file);
            string linha;
            linha = st.ReadLine();
            while ((linha=st.ReadLine())!=null)
            {


                if (expFg.IsMatch(linha))
                    le_fogo(st);


                if (expCmd.IsMatch(linha))
                    le_Comandante(st);

                if (expConc.IsMatch(linha))
                    le_Conselho(st);

                if (expCorp.IsMatch(linha))

                    le_Corporacao(st);

                if (expCorpFg.IsMatch(linha))
                    le_CorpFogo(st);

                if (expDep.IsMatch(linha))
                    le_Depositos(st);

                if (expDist.IsMatch(linha))
                    le_Distritos(st);

                if (expEstFg.IsMatch(linha))
                    le_EstadoFogo(st);

                if (expHeli.IsMatch(linha))
                    le_Heli(st);

                if (expHeliFg.IsMatch(linha))
                    le_HeliFogo(st);
                if (expRel.IsMatch(linha))
                    le_Relatorio(st);

                if (expTipoDep.IsMatch(linha))
                    le_TiposDepos(st);

                if (expVol.IsMatch(linha))
                    le_Voluntariado(st);
                
            }
            st.Close();
            file.Close();

        }

       
    }
}
