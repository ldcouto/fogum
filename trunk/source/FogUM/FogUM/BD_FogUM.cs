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

        //----------------------------
        //-------TESTES--------------
        //-------------------------
        public List<String> teste()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            // Make Select Query
            var testQuery =
                from fog in bdf.FOGOs
                where fog.ESTADO_FOGO.ESTADO_DESIGN == "Não Circunscrito"
                select fog.COMANDANTE.NOME;

            List<String> r = new List<string>();
            // Run Query
            foreach (string nome in testQuery)
            {
                r.Add(nome);
            }
            return r;
        }

        public void teste2(Comandante cmd)
        {
            // Make new COMANDANTE
            COMANDANTE com = new COMANDANTE();
            com.NOME = cmd.Nome;
            com.PASSWORD = cmd.Pass;
            com.USERNAME = cmd.User;

            // Insert new entity
            DBLinqDataContext bdf = new DBLinqDataContext();
            bdf.COMANDANTEs.InsertOnSubmit(com);
            bdf.SubmitChanges();
        }

        public void teste3(Comandante cmd)
        {
            // Select existing COMANDANTE
            DBLinqDataContext bdf = new DBLinqDataContext();
            var existCom =
                (from c in bdf.COMANDANTEs
                 where c.COD_COMANDANTE == cmd.Cod
                 select c)
                 .First();

            existCom.NOME = "Rui Pereira";
            bdf.SubmitChanges();
        }

        //----------------------------
        //-------GETS----------------
        //-------------------------

        /// <summary>
        /// Devolver um fogo a partir dum código
        /// </summary>
        /// <param name="codFogo">Código do Fogo a devolver</param>
        /// <returns>Fogo do código dado ou NULL</returns>
        public Fogo getFogo(int codFogo)
        {
            Fogo r = new Fogo();
            DBLinqDataContext bdf = new DBLinqDataContext();

            var fireQuery =
                from fog in bdf.FOGOs
                where fog.COD_FOGO == codFogo
                select fog;

            if (fireQuery == null) return null;
            return new Fogo(fireQuery.First());
        }

        /// <summary>
        /// Devolver a lista de todos os depósitos
        /// </summary>
        /// <returns>Lista de depósitos</returns>
        public List<Deposito> getDepositos()
        {
            List<Deposito> r = new List<Deposito>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            var depQuery =
                from dep in bdf.DEPOSITOs
                select dep;

            foreach (DEPOSITO d1 in depQuery)
            {
                Deposito d2 = new Deposito(d1);
                r.Add(d2);
            }
            return r;
        }

        /// <summary>
        /// Devolver a lista de todas as corporações
        /// </summary>
        /// <returns>Lista de corporações</returns>
        public List<Corporacao> getCorporacoes()
        {
            List<Corporacao> r = new List<Corporacao>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            var corpQuery =
                from corp in bdf.CORPORACAOs
                select corp;

            foreach (CORPORACAO c1 in corpQuery)
            {
                Corporacao c2 = new Corporacao(c1);
                r.Add(c2);
            }
            return r;
        }

        /// <summary>
        /// Devolver os Fogos Activos de momento num Dicionário.
        /// </summary>
        /// <returns> Dicionário de pares (Código, Fogo)</returns>
        public Dictionary<int, Fogo> getFogos_Activos()
        {
            Dictionary<int, Fogo> r = new Dictionary<int, Fogo>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            // Make Select Query
            var fireQuery =
                from fog in bdf.FOGOs
                where fog.ESTADO_FOGO.ESTADO_DESIGN != "Extinto"
                select fog;

            // Run Query
            foreach (FOGO f in fireQuery)
            {
                Fogo f2 = new Fogo(f);
                r.Add(f2.Codigo, f2);
            }
            return r;
        }

        /// <summary>
        /// Devolver um dicionário de unidades disponíveis
        /// </summary>
        /// <returns>Dicionário de pares (Código de Unidade, Unidade) </returns>
        public Dictionary<int, Unidade> getUnidadesDisponiveis()
        {
            Dictionary<int, Unidade> r = new Dictionary<int, Unidade>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            // Make Select Query
            var corpQuery =
                from corp in bdf.CORPORACAOs
                where corp.DISPONIBILIDADE_CORP == true
                select corp;

            // Run Query
            foreach (CORPORACAO c1 in corpQuery)
            {
                Corporacao c2 = new Corporacao(c1);
                r.Add(c2.Cod, c2);
            }

            return r;
        }

        /// <summary>
        /// Devolver um dicionário com todas as unidades destacadas a um dado fogo
        /// </summary>
        /// <param name="fogoP">O fogo cujas unidades destacadas serão devolvidas</param>
        /// <returns>Dicionário de pares (código de unidade, Unidade)</returns>
        public Dictionary<int, Unidade> getUnidadesDestacadas(Fogo fogoP)
        {
            Dictionary<int, Unidade> r = new Dictionary<int, Unidade>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            //CORP
            // Make Select Query
            var corpQuery = 
                from corp in bdf.CORPORACAOs
                join aux in bdf.CORPFOGOs on corp.COD_CORPORACAO equals aux.COD_CORPORACAO
                where aux.COD_FOGO==fogoP.Codigo
                select corp;
            // Run Query
            foreach (CORPORACAO c1 in corpQuery)
            {
                Corporacao c2 = new Corporacao(c1);
                r.Add(c2.Cod, c2);
            }

            //HELI
            // Make Select Query
            var heliQuery =
                from heli in bdf.HELIs
                join aux2 in bdf.HELIFOGOs on heli.COD_HELI equals aux2.COD_HELI
                where aux2.COD_FOGO == fogoP.Codigo
                select heli;
            // Run Query
            foreach (HELI h1 in heliQuery)
            {
                Heli h2 = new Heli(h1);
                r.Add(h2.Cod, h2);
            }

            return r;
        }

        //----------------------------
        //-------INSERTS-------------
        //-------------------------

        /// <summary>
        /// Inserir novo depósito na BD
        /// </summary>
        /// <param name="d">Novo deposito a inserir. O codigo e descartado e criado um novo pelo motor da BD</param>
        public void insereDeposito(Deposito d)
        {
            DEPOSITO dep = new DEPOSITO();
            dep.COD_TIPO = d.CodTipo;
            dep.LATITUDE = d.Latitude;
            dep.LONGITUDE = d.Longitude;
            dep.VOLUME = d.Volume;

            DBLinqDataContext bdf = new DBLinqDataContext();
            bdf.DEPOSITOs.InsertOnSubmit(dep);
            bdf.SubmitChanges();
        }

        /// <summary>
        /// Inserir um novo voluntário na BD
        /// </summary>
        /// <param name="v">Voluntário a inserir. O código é descartado pois será gerado um novo pela BD</param>
        public void setVoluntario(Voluntario v)
        {
            VOLUNTARIADO vol = new VOLUNTARIADO();
            vol.COD_DISTRITO = v.CodDist;
            vol.DISPONIBILIDADE = v.Disp;
            vol.EMAIL = v.Email;
            vol.NOME_VOLUNTARIO = v.Nome;
            vol.NUM_TELEFONE = v.Telefone;

            DBLinqDataContext bdf = new DBLinqDataContext();
            bdf.VOLUNTARIADOs.InsertOnSubmit(vol);
            bdf.SubmitChanges();

        }

        /// <summary>
        /// Adicionar NOVO fogo à BD.
        /// </summary>
        /// <param name="nFogo">Fogo a Inserir</param>
        public void setNovoFogo(Fogo nFogo, Comandante cmd)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();

            FOGO newFog = new FOGO();
            newFog.BAIXAS_BOMBEIROS = nFogo.Baixas_bombeiros;
            newFog.BAIXAS_CIVIS = nFogo.Baixas_civis;
            newFog.COD_COMANDANTE = cmd.Cod;
            newFog.COD_CONCELHO = nFogo.CodConcelho;
            newFog.COD_ESTADO = nFogo.Estado;
            newFog.COD_RELATORIO = null;
            newFog.DH_CIRCUNSCRITO = nFogo.Dh_circunscrito;
            newFog.DH_FIM = nFogo.Dh_extinto;
            newFog.DH_START = nFogo.Dh_comeco;
            newFog.LATITUDE_FOGO = nFogo.Latitude;
            newFog.LONGITUDE_FOGO = nFogo.Longitude;
            newFog.RAIO_FOGO = nFogo.Raio_fogo;
            newFog.RAIO_SEGURANCA = nFogo.Raio_seg;

            //RELATORIO newRel = new RELATORIO();
            //newRel.COD_FOGO = getNextRelCod();
            //newRel.COMENTARIO = "";

            bdf.FOGOs.InsertOnSubmit(newFog);
            //  bdf.RELATORIOs.InsertOnSubmit(newRel);
            bdf.SubmitChanges();
        }

        /// <summary>
        /// Adicionar NOVO relatório à BD.
        /// </summary>
        /// <param name="rel">Relatório a inserir</param>
        /// <param name="f">Fogo ao qual o relatório se refere</param>
        public void submitRel(Relatorio rel, Fogo f)
        {
            RELATORIO newRel = new RELATORIO();
            newRel.COD_FOGO = f.Codigo;
            newRel.COD_RELATORIO = rel.Codigo;
            newRel.COMENTARIO = rel.Comentario;

            DBLinqDataContext bdf = new DBLinqDataContext();
            bdf.RELATORIOs.InsertOnSubmit(newRel);
            bdf.SubmitChanges();
        }

        //----------------------------
        //-------UPDATES-------------
        //-------------------------

        public void setUnidades(List<Unidade> units, Fogo f)
        {
            int codFogo = f.Codigo;
                        // Select existing HELI
            DBLinqDataContext bdf = new DBLinqDataContext();
            var currHFs =
                 from h in bdf.HELIFOGOs
                 where h.COD_FOGO == codFogo
                 select h;
            bdf.HELIFOGOs.DeleteAllOnSubmit(currHFs);

            foreach (Unidade u in units)
            {
                if (u.GetType().Name == "Corporacao")
                {
                    Corporacao ic = (Corporacao) u;
                    CORPFOGO icf = new CORPFOGO();
                    icf.COD_CORPORACAO = ic.Cod;
                    icf.COD_FOGO = codFogo;
                    bdf.CORPFOGOs.InsertOnSubmit(icf);
                }

                if (u.GetType().Name == "Heli")
                {
                    Heli ih = (Heli)u;
                    HELIFOGO ihf = new HELIFOGO();
                    ihf.COD_FOGO = codFogo;
                    ihf.COD_HELI = ih.Cod;
                    bdf.HELIFOGOs.InsertOnSubmit(ihf);
                }
            }

            // Submit change
            bdf.SubmitChanges();

        }
        
        /// <summary>
        /// Actualizar um Heli na BD. Apenas altera a flag de disp
        /// </summary>
        /// <param name="helic">Heli a actualizar</param>
        public void updateHeli(Heli helic)
        {
            // Select existing HELI
            DBLinqDataContext bdf = new DBLinqDataContext();
            var currHeli =
                (from h in bdf.HELIs
                 where h.COD_HELI == helic.Cod
                 select h)
                 .First();
            // Make and submit change
            currHeli.HELI_DISPONIBILIDADE = helic.Disp;
            bdf.SubmitChanges();
        }

        /// <summary>
        /// Actualizar um Fogo na BD.
        /// </summary>
        /// <param name="fogoP">Fogo a actualizar</param>
        public void updateFogo(Fogo fogoP)
        {
            // Select existing FOGO
            DBLinqDataContext bdf = new DBLinqDataContext();
            var currFogo =
                (from f in bdf.FOGOs
                 where f.COD_FOGO == fogoP.Codigo
                 select f)
                 .First();
            // Make and submit change
            currFogo.BAIXAS_BOMBEIROS = fogoP.Baixas_bombeiros;
            currFogo.BAIXAS_CIVIS = fogoP.Baixas_civis;
            currFogo.COD_ESTADO = fogoP.Estado;
            currFogo.DH_CIRCUNSCRITO = fogoP.Dh_circunscrito;
            currFogo.DH_FIM = fogoP.Dh_extinto;
            currFogo.DH_START = fogoP.Dh_comeco;
            currFogo.RAIO_FOGO = fogoP.Raio_fogo;
            currFogo.RAIO_SEGURANCA = fogoP.Raio_seg;
            bdf.SubmitChanges();
        }

        /// <summary>
        /// Actualizar uma corp na BD. Apenas altera a flag de disp
        /// </summary>
        /// <param name="coorp">Corp a actualizar</param>
        public void updateCorp(Corporacao corp)
        {
            // Select existing HELI
            DBLinqDataContext bdf = new DBLinqDataContext();
            var currCorp =
                (from c in bdf.CORPORACAOs
                 where c.COD_CORPORACAO == corp.Cod
                 select c)
                 .First();
            // Make and submit change
            currCorp.DISPONIBILIDADE_CORP = corp.Disponivel;
            bdf.SubmitChanges();
        }

        //----------------------------
        //-------AUXILIARES----------
        //-------------------------

        private int getNextRelCod()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                (from rel in bdf.RELATORIOs
                 orderby rel.COD_RELATORIO descending
                 select rel.COD_RELATORIO);
            if (auxQuery == null)
                return 0;
            return (int) auxQuery.First() + 1;
        }

        private int getNextFogCod()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                (from fog in bdf.FOGOs
                 orderby fog.COD_FOGO descending
                 select fog.COD_FOGO);
            if (auxQuery == null)
                return 0;
            return (int)auxQuery.First() + 1;
        }
            
    }
}
