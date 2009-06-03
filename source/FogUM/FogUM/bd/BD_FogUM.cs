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
using FogUM.bd;

namespace FogUM
{
    public class BD_FogUM
    {

        //private int nextCodCmd;
        //private int nextCodConcelho;
        //private int nextCodCorp;
        //private int nextCodDepo;
        //private int nextCodEstado;
        //private int nextCodFogo;
        //private int nextCodHeli;
        //private int nextCodRel;
        //private int nextCodTipo;
        //private int nextCodVol;

        //public BD_FogUM()
        //{
        //    this.nextCodCmd = this.nextCodCmd();
        //    this.nextCodConcelho = this.nextCodConcelho();
        //    this.nextCodCorp = this.nextCodCorp();
        //    this.nextCodDepo = this.nextCodDepo();
        //    this.nextCodEstado = this.nextCodEstado();
        //    this.nextCodFogo = this.nextCodFogo();
        //    this.nextCodHeli = this.nextCodHeli();
        //    this.nextCodRel = this.nextCodRel();
        //    this.nextCodTipo = this.nextCodTipo();
        //    this.nextCodVol = this.nextCodVol();         
        //}

        private static int COD_ESTADO_EXTINTO = 3;

        #region Testes
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
        #endregion

        #region Gets
        //----------------------------
        //-------GETS----------------
        //-------------------------

        #region GETS-ESTATISCAS
        public int getTotCorps()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                from auxs in bdf.CORPORACAOs
                select auxs.COD_CORPORACAO;

            if (auxQuery == null)
                return 0;
            return auxQuery.Count();
        }

        public int getTotCmds()
        {    
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                from auxs in bdf.COMANDANTEs
                select auxs.COD_COMANDANTE;

            if (auxQuery == null)
                return 0;
            return auxQuery.Count();
        }

        public int getTotHelis()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                from auxs in bdf.HELIs
                select auxs.COD_HELI;

            if (auxQuery == null)
                return 0;
            return auxQuery.Count();
        }
        public int getTotFogs()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                from auxs in bdf.FOGOs
                select auxs.COD_FOGO;

            if (auxQuery == null)
                return 0;
            return auxQuery.Count();
        }
        public int getTotVols()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                from auxs in bdf.VOLUNTARIADOs
                select auxs.COD_VOLUNTARIO;

            if (auxQuery == null)
                return 0;
            return auxQuery.Count();
        }

        public int getTotDepos()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                from auxs in bdf.DEPOSITOs
                select auxs.COD_DEPO;

            if (auxQuery == null)
                return 0;
            return auxQuery.Count();
        }
        #endregion


        public int getCodDistrByName(string distr)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                from bDep in bdf.DISTRITOs
                where bDep.DISTRITO_DESIGN == distr
                select bDep.COD_DISTRITO;

            if (auxQuery.Count() == 0)
                return -1;
            return auxQuery.First();
        }

        public int getCodConsByName(string conc)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                from bDep in bdf.CONCELHOs
                where bDep.CONCELHO_DESIGN == conc
                select bDep.COD_CONCELHO;

            if (auxQuery.Count() == 0)
                return -1;
            return auxQuery.First();
        }

        public int getCodTipDepByName(string dep)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                from bDep in bdf.TIPOS_DEPOs
                where bDep.TIPO_DESIGN == dep
                select bDep.COD_TIPO;

            if (auxQuery.Count() == 0)
                return -1;
            return auxQuery.First();
        }

        /// <summary>
        /// Devolver uma corporacao dando o codigo
        /// </summary>
        /// <param name="fogop">codigo corporacao</param>
        /// <returns>Corporacao</returns>
        public Corporacao getCorp(int codCorp)
        {

            DBLinqDataContext bdf = new DBLinqDataContext();
            var corpQuery =
               from corp in bdf.CORPORACAOs
               where corp.COD_CORPORACAO == codCorp
               select corp;

            if (corpQuery == null) return null;
            return new Corporacao(corpQuery.First());

        }

        /// <summary>
        /// Devolver um heli dando o codigo
        /// </summary>
        /// <param name="fogop">codigo heli</param>
        /// <returns>Heli</returns>
        public Heli getHeli(int codHeli)
        {

            DBLinqDataContext bdf = new DBLinqDataContext();

            var heliQuery =
               from heli in bdf.HELIs
               where heli.COD_HELI == codHeli
               select heli;

            if (heliQuery == null) return null;
            return new Heli(heliQuery.First());

        }



        /// <summary>
        /// Devolver estatísticas de Fogos para um dia.
        /// </summary>
        /// <param name="dt">DateTime com o dia desejado</param>
        /// <returns>List de packs de estatísticas</returns>
        public List<EstFogo> getEstFogos(DateTime dt)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            List<EstFogo> r = new List<EstFogo>();
            var auxQuery =
                    from fogs in bdf.FOGOs
                    where fogs.DH_FIM.Date.Equals(dt.Date)
                    select fogs.COD_FOGO;
            foreach (int i in auxQuery)
                r.Add(this.getEFAux(i));
            return r;
        }

      

        /// <summary>
        /// Devolver o total de fogos ocorridos num ano
        /// </summary>
        /// <param name="ano">O ano desejado</param>
        /// <returns>Número de fogos que Terminaram no ano dado</returns>
        public int getFogosAno(int ano)
        {
            int r = 0;
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from fogs in bdf.FOGOs
                where fogs.DH_FIM.Year == ano
                select fogs.COD_FOGO;
            r = fQuery.Count();
            return r;
        }

        /// <summary>
        /// Devolver o total de baixas civis num ano
        /// </summary>
        /// <param name="ano">O ano desejado</param>
        /// <returns>Número de baixas civis em fogos que Terminaram no ano dado</returns>
        public int getBaixasCAno(int ano)
        {
            int r = 0;
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from fogs in bdf.FOGOs
                where fogs.DH_FIM.Year == ano
                select fogs.BAIXAS_CIVIS;

            foreach (int b in fQuery)
                r += b;
            return r;
        }

        public Comandante getComandante(String user)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from cmd in bdf.COMANDANTEs
                where cmd.USERNAME==user
                select cmd;
            if (fQuery.Count() != 1)
                return null;
            Comandante c = new Comandante();
            c.Cod = fQuery.First().COD_COMANDANTE;
            c.Nome  = fQuery.First().NOME;
            c.Pass = fQuery.First().PASSWORD;
            c.User = fQuery.First().USERNAME;
            return c;

        }
        /// <summary>
        /// Devolver o total de baixas nos bombeiros num ano
        /// </summary>
        /// <param name="ano">O ano desejado</param>
        /// <returns>Número de baixas nos bombeiros em fogos que Terminaram no ano dado</returns>
        public int getBaixasBAno(int ano)
        {
            int r = 0;
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from fogs in bdf.FOGOs
                where fogs.DH_FIM.Year == ano
                select fogs.BAIXAS_BOMBEIROS;

            foreach (int b in fQuery)
                r += b;
            return r;
        }

        /// <summary>
        /// Devolver o total da área ardida num ano
        /// </summary>
        /// <param name="ano">O ano desejado</param>
        /// <returns>Total de área ardida em fogos que Terminaram no ano dado</returns>
        public float getAAano(int ano)
        {
            float r = 0;
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from fogs in bdf.FOGOs
                where fogs.DH_FIM.Year == ano
                select fogs.RAIO_FOGO;

            foreach (float a in fQuery)
                r += a;
            return r;
        }

        /// <summary>
        /// Devolver lista de voluntários para um dado distrito
        /// </summary>
        /// <param name="codDistrito">Indicativo telf do distrito em questão (253-Braga)</param>
        /// <returns>Lista com os voluntários do distrito pedido</returns>
        public List<Voluntario> getVols(int codDistrito)
        {
            List<Voluntario> r = new List<Voluntario>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            var volQuery =
                from vols in bdf.VOLUNTARIADOs
                where vols.COD_DISTRITO == codDistrito
                select vols;

            if (volQuery != null)
            {
                foreach (VOLUNTARIADO vol in volQuery)
                {
                    Voluntario v = new Voluntario(vol);
                    r.Add(v);
                }
            }

            return r;
        }

        /// <summary>
        /// Devolver lista de voluntários para um dado distrito
        /// </summary>
        /// <param name="distrito">Nome do distrito em questão. Não é tão fiável, claro</param>
        /// <returns>Lista com os voluntários do distrito pedido</returns>
        public List<Voluntario> getVols(string distrito)
        {
            List<Voluntario> r = new List<Voluntario>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            var volQuery =
                from vols in bdf.VOLUNTARIADOs
                where vols.DISTRITO.ToString().ToLower() == distrito.ToLower()
                select vols;

            if (volQuery != null)
            {
                foreach (VOLUNTARIADO vol in volQuery)
                {
                    Voluntario v = new Voluntario(vol);
                    r.Add(v);
                }
            }
            return r;
        }

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

            if (listQuery != null)
            {
                foreach (string s in listQuery)
                    r.Add(s);
            }
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
            if (relQuery != null)
            {
                foreach (RELATORIO rel1 in relQuery)
                {
                    Relatorio rel2 = new Relatorio(rel1.COD_RELATORIO, rel1.COMENTARIO);
                    r.Add(rel2);
                }
            }
            return r;
        }

        /// <summary>
        /// Devolver uma lista com os relatórios pendentes para um dado Comandante.
        /// </summary>
        /// <param name="cmd">O username do comandante cujos relatórios são pedidos.</param>
        /// <returns>A lista de relatórios pendentes.</returns>
        public List<Relatorio> getRelsPendentes(string cmdUsername)
        {
            List<Relatorio> r = new List<Relatorio>();

            DBLinqDataContext bdf = new DBLinqDataContext();

            var relQuery =
                from aux in bdf.FOGOs
                where aux.COD_RELATORIO == null && aux.COMANDANTE.USERNAME == cmdUsername
                select aux.COD_FOGO;

            if (relQuery != null)
            {
                foreach (int cf in relQuery)
                {
                    Relatorio r1 = new Relatorio(cf, "Ainda não preenchido");
                    r.Add(r1);
                }
            }
            return r;
        }


        /// <summary>
        /// Devolver um Dicionário Fogo->Relatório (pendente) para um dado Comandante.
        /// </summary>
        /// <param name="cmd">O username do comandante cujos relatórios são pedidos.</param>
        /// <returns>Dicionário com os Fogos a que os rels se referem e os próprios rels</returns>
        public Dictionary<Fogo,Relatorio> getRelsPendentesCFogos(string cmdUsername)
        {
            Dictionary<Fogo, Relatorio> r = new Dictionary<Fogo, Relatorio>();

            DBLinqDataContext bdf = new DBLinqDataContext();

            var relQuery =
                from aux in bdf.FOGOs
                where aux.COD_RELATORIO == null && aux.COD_ESTADO == COD_ESTADO_EXTINTO && aux.COMANDANTE.USERNAME == cmdUsername
                select aux;

            if (relQuery.Count()>0)
            {
                foreach (FOGO cf in relQuery)
                {
                    Fogo f1 = new Fogo(cf);
                    f1.Comentario="Ainda não preenchido";
                    Relatorio r1 = new Relatorio(cf.COD_FOGO, "Ainda não preenchido");
                    r.Add(f1,r1);
                }
            }
            return r;
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

            if (fireQuery.Count() == 0) 
                return null;
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

            if (depQuery != null)
            {
                foreach (DEPOSITO d1 in depQuery)
                {
                    Deposito d2 = new Deposito(d1);
                    r.Add(d2);
                }
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

            if (corpQuery != null)
            {
                foreach (CORPORACAO c1 in corpQuery)
                {
                    Corporacao c2 = new Corporacao(c1);
                    r.Add(c2);
                }
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

            if (fireQuery != null)
            {
                // Run Query
                foreach (FOGO f in fireQuery)
                {
                    Fogo f2 = new Fogo(f);
                    r.Add(f2.Codigo, f2);
                }
            }
            return r;
        }

        public Dictionary<int, Fogo> getFogos_Activos(int cod)
        {
            Dictionary<int, Fogo> r = new Dictionary<int, Fogo>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            // Make Select Query
            var fireQuery =
                from fog in bdf.FOGOs 
                where fog.ESTADO_FOGO.ESTADO_DESIGN != "Extinto" && fog.COD_COMANDANTE==cod
                select fog;

            if (fireQuery != null)
            {
                // Run Query
                foreach (FOGO f in fireQuery)
                {
                    Fogo f2 = new Fogo(f);
                    r.Add(f2.Codigo, f2);
                }
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

            if (corpQuery != null)
            {
                // Run Query
                foreach (CORPORACAO c1 in corpQuery)
                {
                    Corporacao c2 = new Corporacao(c1);
                    r.Add(c2.Cod, c2);
                }
            }
            // HELI
            // Make Select Query
            var heliQuery =
                from heli in bdf.HELIs
                where heli.HELI_DISPONIBILIDADE == true
                select heli;
            if (heliQuery != null)
            {
                // Run Query
                foreach (HELI h1 in heliQuery)
                {
                    Heli h2 = new Heli(h1);
                    r.Add(h2.Cod, h2);
                }
            }
            return r;
        }

        /// <summary>
        /// Devolver dicionário com as Corps disponíveis
        /// </summary>
        /// <returns>Dicionário de pares (código, Corp) </returns>
        public Dictionary<int, Corporacao> getCorpsDisponiveis()
        {
            Dictionary<int, Corporacao> r = new Dictionary<int, Corporacao>();
            DBLinqDataContext bdf = new DBLinqDataContext();

            var corpQuery =
                from corp in bdf.CORPORACAOs
                where corp.DISPONIBILIDADE_CORP == true
                select corp;

            if (corpQuery != null)
            {
                foreach (CORPORACAO c1 in corpQuery)
                {
                    Corporacao c2 = new Corporacao(c1);
                    r.Add(c2.Cod, c2);
                }
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

            if (heliQuery != null)
            {
                foreach (HELI h1 in heliQuery)
                {
                    Heli h2 = new Heli(h1);
                    r.Add(h2.Cod, h2);
                }
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

            if (corpQuery != null)
            {
                foreach (CORPORACAO c1 in corpQuery)
                {
                    Corporacao c2 = new Corporacao(c1);
                    r.Add(c2.Cod, c2);
                }
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

            if (heliQuery != null)
            {
                foreach (HELI h1 in heliQuery)
                {
                    Heli h2 = new Heli(h1);
                    r.Add(h2.Cod, h2);
                }
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
                where aux.COD_FOGO == fogoP.Codigo
                select corp;
            // Run Query

            if (corpQuery != null)
            {
                foreach (CORPORACAO c1 in corpQuery)
                {
                    Corporacao c2 = new Corporacao(c1);
                    r.Add(c2.Cod, c2);
                }
            }
            //HELI
            // Make Select Query
            var heliQuery =
                from heli in bdf.HELIs
                join aux2 in bdf.HELIFOGOs on heli.COD_HELI equals aux2.COD_HELI
                where aux2.COD_FOGO == fogoP.Codigo
                select heli;
            // Run Query

            if (heliQuery != null)
            {
                foreach (HELI h1 in heliQuery)
                {
                    Heli h2 = new Heli(h1);
                    r.Add(h2.Cod, h2);
                }
            }
            return r;
        }

        #endregion

        #region Inserts
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
            dep.COD_DEPO = this.nextCodDepo();
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
        private void setNovoRel(Relatorio nRel)
        {
            RELATORIO rel = new RELATORIO();
            rel.COD_RELATORIO = this.nextCodRel();
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
            vol.COD_VOLUNTARIO = this.nextCodVol();
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
        public int setNovoFogo(Fogo nFogo, Comandante cmd)
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            int ncFogo = this.nextCodFogo();
            FOGO newFog = new FOGO();
            newFog.COD_FOGO = ncFogo;
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
            return ncFogo;
        }

        /// <summary>
        /// Adicionar NOVO relatório à BD.
        /// </summary>
        /// <param name="rel">Relatório a inserir</param>
        /// <param name="f">Fogo ao qual o relatório se refere</param>
        public void submitRel(Relatorio rel, Fogo f)
        {
            int nextCodRel = this.nextCodRel();
            RELATORIO bdrel = new RELATORIO();
            bdrel.COD_RELATORIO = nextCodRel;
            bdrel.COD_FOGO = f.Codigo;
            bdrel.COMENTARIO = rel.Comentario;

            DBLinqDataContext bdf = new DBLinqDataContext();
            bdf.RELATORIOs.InsertOnSubmit(bdrel);

            var currFogo =
            from cf in bdf.FOGOs
            where cf.COD_FOGO == f.Codigo
            select cf;

            if (currFogo.Count() != 0)
                  currFogo.First().COD_RELATORIO = nextCodRel;

            bdf.SubmitChanges();
        }
        #endregion

        #region Updates
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
                currFogo.First().COD_ESTADO = codEstado;
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
                    Corporacao ic = (Corporacao)u;
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
                currFogo.First().LATITUDE_FOGO = fogoP.Latitude;
                currFogo.First().LONGITUDE_FOGO = fogoP.Longitude;
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

        #endregion

        #region Aux

        //----------------------------
        //-------AUXILIARES----------
        //-------------------------

        public EstFogo getEFAux(int codFogo)
        {
            EstFogo r = new EstFogo();
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from fogs in bdf.FOGOs
                where fogs.COD_FOGO == codFogo
                select fogs;
            if (fQuery == null) return r;
            else
            {
                var fQ = fQuery.First();
                r.AreaArdida = (float)fQ.RAIO_FOGO;
                r.Cmd = fQ.COMANDANTE.NOME;
                r.DhEnd = fQ.DH_FIM.ToString();
                r.DhStart = fQ.DH_START.ToString();
                r.Estado = fQ.ESTADO_FOGO.ESTADO_DESIGN;
                r.NBaixasB = (int)fQ.BAIXAS_BOMBEIROS;
                r.NCompanhias =
                    (from fCs in bdf.CORPFOGOs
                     where fCs.COD_FOGO == codFogo
                     select fCs).Count();
                r.NHelis =
                    (from fCs in bdf.HELIFOGOs
                     where fCs.COD_FOGO == codFogo
                     select fCs).Count();
                r.Zona = fQ.CONCELHO.CONCELHO_DESIGN;

                var corpQuery =
                    from corp in bdf.CORPORACAOs
                    join aux in bdf.CORPFOGOs on corp.COD_CORPORACAO equals aux.COD_CORPORACAO
                    where aux.COD_FOGO == codFogo
                    select corp;

                r.NHelis = (from hs in bdf.HELIs
                            join aux in bdf.HELIFOGOs on hs.COD_HELI equals aux.COD_HELI
                            where aux.COD_FOGO == codFogo
                            select aux.COD_HELI).Count();

                var fQuery3 =
                    from cs in bdf.CORPORACAOs
                    join aux in bdf.CORPFOGOs on cs.COD_CORPORACAO equals aux.COD_CORPORACAO
                    where aux.COD_FOGO == codFogo
                    select new { Homens = cs.NUM_HOMENS_DISP, Veiculos = cs.NUM_VEICULOS_DISP };

                r.NVeiculos = 0;
                r.NHomens = 0;
                foreach (var aux in fQuery3)
                {
                    r.NVeiculos += (int)aux.Veiculos;
                    r.NHomens += (int)aux.Homens;
                }

                return r;
            }
        }

        private int nextCodCmd()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                (from aux in bdf.COMANDANTEs
                 orderby aux.COD_COMANDANTE descending
                 select aux.COD_COMANDANTE);
            if (auxQuery == null)
                return 0;
            return (int)auxQuery.First() + 1;
        }

        private int nextCodConcelho()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                (from aux in bdf.CONCELHOs
                 orderby aux.COD_CONCELHO descending
                 select aux.COD_CONCELHO);
            if (auxQuery == null)
                return 0;
            return (int)auxQuery.First() + 1;
        }

        private int nextCodCorp()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                (from aux in bdf.CORPORACAOs
                 orderby aux.COD_CORPORACAO descending
                 select aux.COD_CORPORACAO);
            if (auxQuery == null)
                return 0;
            return (int)auxQuery.First() + 1;
        }

        private int nextCodDepo()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                (from aux in bdf.DEPOSITOs
                 orderby aux.COD_DEPO descending
                 select aux.COD_DEPO);
            if (auxQuery == null)
                return 0;
            return (int)auxQuery.First() + 1;
        }

        private int nextCodEStado()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                (from aux in bdf.ESTADO_FOGOs
                 orderby aux.COD_ESTADO descending
                 select aux.COD_ESTADO);
            if (auxQuery == null)
                return 0;
            return (int)auxQuery.First() + 1;
        }

        private int nextCodFogo()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                (from aux in bdf.FOGOs
                 orderby aux.COD_FOGO descending
                 select aux.COD_FOGO);
            if (auxQuery == null)
                return 0;
            return (int)auxQuery.First() + 1;
        }

        private int nextCodHeli()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                (from aux in bdf.HELIs
                 orderby aux.COD_HELI descending
                 select aux.COD_HELI);
            if (auxQuery == null)
                return 0;
            return (int)auxQuery.First() + 1;
        }

        private int nextCodRel()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                (from aux in bdf.RELATORIOs
                 orderby aux.COD_RELATORIO descending
                 select aux.COD_RELATORIO);
            if (auxQuery == null)
                return 0;
            return (int)auxQuery.First() + 1;
        }

        private int nextCodTipo()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                (from aux in bdf.TIPOS_DEPOs
                 orderby aux.COD_TIPO descending
                 select aux.COD_TIPO);
            if (auxQuery == null)
                return 0;
            return (int)auxQuery.First() + 1;
        }

        private int nextCodVol()
        {
            DBLinqDataContext bdf = new DBLinqDataContext();
            var auxQuery =
                (from aux in bdf.VOLUNTARIADOs
                 orderby aux.COD_VOLUNTARIO descending
                 select aux.COD_VOLUNTARIO);
            if (auxQuery == null)
                return 0;
            return (int)auxQuery.First() + 1;
        }

        //private int getNextRelCod()
        //{
        //    DBLinqDataContext bdf = new DBLinqDataContext();
        //    var auxQuery =
        //        (from rel in bdf.RELATORIOs
        //         orderby rel.COD_RELATORIO descending
        //         select rel.COD_RELATORIO);
        //    if (auxQuery == null)
        //        return 0;
        //    return (int) auxQuery.First() + 1;
        //}

        //private int getNextFogCod()
        //{
        //    DBLinqDataContext bdf = new DBLinqDataContext();
        //    var auxQuery =
        //        (from fog in bdf.FOGOs
        //         orderby fog.COD_FOGO descending
        //         select fog.COD_FOGO);
        //    if (auxQuery == null)
        //        return 0;
        //    return (int)auxQuery.First() + 1;
        //}

        #endregion

    }
}
