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

        private static int COD_ESTADO_EXTINTO=3;

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
        /// Devolver a password dum utilizador. Utilizado para autenticar
        /// </summary>
        /// <param name="username">Utilizador da password a consultar</param>
        /// <returns>A password do utilizador caso exista. NULL caso contrário</returns>
        public string getPass(string username)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();

            var passQuery =
                from pass in bdf.COMANDANTEs
                where pass.USERNAME == username
                select pass.PASSWORD;
            if (passQuery == null)
                return null;
            return passQuery.First();
        }

        /// <summary>
        /// Devolver a lista de todos os estados possíveis para um fogo
        /// </summary>
        /// <returns>Lista de strings com os estados</returns>
        public List<string> getListaEstados()
        {
            List<String> r = new List<string>();

            DBLinqDataContext bdf = new DBLinqDataContext();

            var listQuery =
                from estados in bdf.ESTADO_FOGOs
                select estados.ESTADO_DESIGN;

            foreach (string s in listQuery)
                r.Add(s);
            return r;
        }

        /// <summary>
        /// Devolver uma lista com todos os relatórios do sistema
        /// </summary>
        /// <returns>Lista dos relatórios</returns>
        public List<Relatorio> getRels()
        {
            List<Relatorio> r = new List<Relatorio>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            var relQuery =
                from rels in bdf.RELATORIOs
                select rels;

            foreach (RELATORIO rel1 in relQuery)
            {
                Relatorio rel2 = new Relatorio(rel1.COD_RELATORIO, rel1.COMENTARIO);
                r.Add(rel2);
            }

            return r;
        }

        /// <summary>
        /// Devolver uma lista com os relatórios pendentes para um dado Comandante.
        /// </summary>
        /// <param name="cmd">O nome do comandante cujos relatórios são pedidos.</param>
        /// <returns>A lista de relatórios pendentes.</returns>
        public List<Relatorio> getRelsPendentes(string cmd)
        {
           // List<Relatorio> r = new List<Relatorio>();

            throw new Exception("Not yet Implemented");

          //  return r;
        }



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
            // CORP
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
            // HELI
            // Make Select Query
            var heliQuery =
                from heli in bdf.HELIs
                where heli.HELI_DISPONIBILIDADE == true
                select heli;
            // Run Query
            foreach (HELI h1 in heliQuery)
            {
                Heli h2 = new Heli(h1);
                r.Add(h2.Cod, h2);
            }
            return r;
        }

        /// <summary>
        /// Devolver dicionário com as Corps disponíveis
        /// </summary>
        /// <returns>Dicionário de pares (código, Corp) </returns>
        public Dictionary<int, Corporacao> getCorpsDisponiveis()
        {
            Dictionary<int, Corporacao> r = new Dictionary<int,Corporacao>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            var corpQuery =
                from corp in bdf.CORPORACAOs
                where corp.DISPONIBILIDADE_CORP == true
                select corp;

            foreach (CORPORACAO c1 in corpQuery)
            {
                Corporacao c2 = new Corporacao(c1);
                r.Add(c2.Cod, c2);
            }

            return r;
        }

        /// <summary>
        /// Devolver dicionário com os helis disponíveis
        /// </summary>
        /// <returns>Dicionário de pares (código, Heli)</returns>
        public Dictionary<int, Heli> getHelisDisponiveis()
        {
            Dictionary<int, Heli> r = new Dictionary<int, Heli>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            var heliQuery =
                from heli in bdf.HELIs
                where heli.HELI_DISPONIBILIDADE == true
                select heli;
  
            foreach (HELI h1 in heliQuery)
            {
                Heli h2 = new Heli(h1);
                r.Add(h2.Cod, h2);
            }

            return r;
        }

        /// <summary>
        /// Devolver um dicionário com todas as corps destacadas a um dado fogo
        /// </summary>
        /// <param name="fogop">O fogo cujas corps destacadas se pretende</param>
        /// <returns>Dicionário de pares (código, corp)</returns>
        public Dictionary<int, Corporacao> getCorpsDestacadas(Fogo fogoP)
        {
            Dictionary<int, Corporacao> r = new Dictionary<int, Corporacao>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            var corpQuery =
                from corp in bdf.CORPORACAOs
                join aux in bdf.CORPFOGOs on corp.COD_CORPORACAO equals aux.COD_CORPORACAO
                where aux.COD_FOGO == fogoP.Codigo
                select corp;

            foreach (CORPORACAO c1 in corpQuery)
            {
                Corporacao c2 = new Corporacao(c1);
                r.Add(c2.Cod, c2);
            }

            return r;
        }

        /// <summary>
        /// Devolver um dicionário com todos os helis destacados a um fogo
        /// </summary>
        /// <param name="fogoP">O fogo cujos helis destacados se pretende</param>
        /// <returns>Dicionário de pares (código, heli)</returns>
        public Dictionary<int, Heli> getHelisDestacados(Fogo fogoP)
        {
            Dictionary<int, Heli> r = new Dictionary<int, Heli>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            var heliQuery =
                from heli in bdf.HELIs
                join aux2 in bdf.HELIFOGOs on heli.COD_HELI equals aux2.COD_HELI
                where aux2.COD_FOGO == fogoP.Codigo
                select heli;

            foreach (HELI h1 in heliQuery)
            {
                Heli h2 = new Heli(h1);
                r.Add(h2.Cod, h2);
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
        /// Inserir um novo relatório na BD
        /// </summary>
        /// <param name="nRel">Relatório a inserir. O código é destarcado e gerado um novo pela BD</param>
        public void setNovoRel(Relatorio nRel)
        {
            RELATORIO rel = new RELATORIO();
            rel.COD_FOGO = nRel.Codigo;
            rel.COMENTARIO = nRel.Comentario;

            DBLinqDataContext bdf = new DBLinqDataContext();
            bdf.RELATORIOs.InsertOnSubmit(rel);
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

        /// <summary>
        /// Alterar o estado dum fogo
        /// </summary>
        /// <param name="codEstado">Código do novo estado</param>
        /// <param name="f">Fogo cujo estado se quer alterar</param>
        public void setEstado(int codEstado, Fogo f)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var currFogo =
                from cf in bdf.FOGOs
                where cf.COD_FOGO == f.Codigo
                select cf;
            if (currFogo != null)
            {
                currFogo.First().COD_ESTADO=codEstado;
                bdf.SubmitChanges();
            }
        }

        /// <summary>
        /// Alterar a lista de corps alocadas a um fogo
        /// </summary>
        /// <param name="corps">A nova lista de corps</param>
        /// <param name="f">O fogo a que as corps estão alocadas</param>
        public void setCorps(List<Corporacao> corps, Fogo f)
        {
            int codFogo = f.Codigo;
            DBLinqDataContext bdf = new DBLinqDataContext();

            var currCorps =
                from c in bdf.CORPFOGOs
                where c.COD_FOGO == codFogo
                select c;
            bdf.CORPFOGOs.DeleteAllOnSubmit(currCorps);

            // Insert new CORPs
            foreach (Corporacao ic in corps)
            {
                    CORPFOGO icf = new CORPFOGO();
                    icf.COD_CORPORACAO = ic.Cod;
                    icf.COD_FOGO = codFogo;
                    bdf.CORPFOGOs.InsertOnSubmit(icf);
            }

            // Submit changes
            bdf.SubmitChanges();
        }

        /// <summary>
        /// Alterar a lista de helis alocados a um fogo
        /// </summary>
        /// <param name="helis">A nova lista de helis</param>
        /// <param name="f">O fogo a que os helis estão alocados</param>
        public void setHelis(List<Heli> helis, Fogo f)
        {
            int codFogo = f.Codigo;
            DBLinqDataContext bdf = new DBLinqDataContext();

            var currHFs =
                 from h in bdf.HELIFOGOs
                 where h.COD_FOGO == codFogo
                 select h;
            bdf.HELIFOGOs.DeleteAllOnSubmit(currHFs);
          
            // Insert new HELIs
            foreach (Heli ih in helis)
            {
                HELIFOGO ihf = new HELIFOGO();
                ihf.COD_FOGO = codFogo;
                ihf.COD_HELI = ih.Cod;
                bdf.HELIFOGOs.InsertOnSubmit(ihf);
            }

            // Submit changes
            bdf.SubmitChanges();
        }

        /// <summary>
        /// Alterar a lista de unidades alocadas a um fogo
        /// </summary>
        /// <param name="units">A nova lista de unidades</param>
        /// <param name="f">O fogo a que as unidades estão alocadas</param>
        public void setUnidades(List<Unidade> units, Fogo f)
        {
            int codFogo = f.Codigo;
                        // Select and remove existing HELIs
            DBLinqDataContext bdf = new DBLinqDataContext();
            var currHFs =
                 from h in bdf.HELIFOGOs
                 where h.COD_FOGO == codFogo
                 select h;
            bdf.HELIFOGOs.DeleteAllOnSubmit(currHFs);
                     // Select and remove existing CORPs
            var currCorps =
                from c in bdf.CORPFOGOs
                where c.COD_FOGO == codFogo
                select c;
            bdf.CORPFOGOs.DeleteAllOnSubmit(currCorps);

                // Insert new HELIs/CORPs
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

            // Submit changes
            bdf.SubmitChanges();

        }

        /// <summary>
        /// Marcar um fogo como terminado. Corresponde apenas a uma mudança no código de estado.
        /// </summary>
        /// <param name="codFogo">Código do fogo a terminar</param>
        public void setTermComb(int codFogo)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var currFogo =
                from cf in bdf.FOGOs
                where cf.COD_FOGO == codFogo
                select cf;
            if (currFogo != null)
            {
                currFogo.First().COD_ESTADO = COD_ESTADO_EXTINTO;
                bdf.SubmitChanges();
            }

            // Valerá a pena lançar já o relatório deste fogo na BD?

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
                 select h);
            if (currHeli != null)
            {
                currHeli.First().HELI_DISPONIBILIDADE = helic.Disp;
                bdf.SubmitChanges();
            }
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
                 select f);
            if (currFogo != null)
            {
                // Make and submit change
                currFogo.First().BAIXAS_BOMBEIROS = fogoP.Baixas_bombeiros;
                currFogo.First().BAIXAS_CIVIS = fogoP.Baixas_civis;
                currFogo.First().COD_ESTADO = fogoP.Estado;
                currFogo.First().DH_CIRCUNSCRITO = fogoP.Dh_circunscrito;
                currFogo.First().DH_FIM = fogoP.Dh_extinto;
                currFogo.First().DH_START = fogoP.Dh_comeco;
                currFogo.First().RAIO_FOGO = fogoP.Raio_fogo;
                currFogo.First().RAIO_SEGURANCA = fogoP.Raio_seg;
                bdf.SubmitChanges();
            }
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
                 select c);
            if (currCorp != null)
            {
                currCorp.First().DISPONIBILIDADE_CORP = corp.Disponivel;
                bdf.SubmitChanges();
            }
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
