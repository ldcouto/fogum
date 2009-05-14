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
    public class Proc_Cmd
    {
        private Comandante cmd;
        private Fogo fogoCombate;
        private List<Deposito> depositosDisp;
        private BD_FogUM bd;
        private List<Relatorio> relatorio;
        private Dictionary<int, Unidade> unidades;
        
        
        public Comandante Cmd
        {
            get { return cmd; }
            set { cmd = value; }          
        }
     
        public Fogo FogoCombate
        {
            get { return fogoCombate; }
            set { fogoCombate = value; }
        }

        public List<Deposito> DepositosDisp
        {
            get { return depositosDisp; }
            set { depositosDisp = value; }
        }

        public BD_FogUM Bd
        {
            get { return bd; }
            set { bd = value; }
        }
        public List<Relatorio> Relatorio
        {
            get { return relatorio; }
            set { relatorio = value; }
        }

        public Dictionary<int, Unidade> Unidades
        {
            get { return unidades; }
            set { unidades = value; }
        }
        //metodos....
        public Boolean verificaRaioSeg(float raioSeg)
        {
            if(raioSeg>fogoCombate.Raio_fogo && raioSeg>0)
                return true;
            return false;
        }

        public Boolean verificaRaio(float raio)
        {
            if (raio > 0 && raio < fogoCombate.Raio_seg)
                return true;
            return false;
        }

        /* public Dictionary<int, Unidade> getUnidadesDisponiveis()
         {
             getUnidadesDisponiveis() - Vai a base de dados buscar as unidades disponiveis 
         }*/

        public Dictionary<int, Unidade> getUnidadesDestacadas()
        {
            //igual a propriedade Unidades
            return unidades;
        }

        public void remUnidade(int cod)
        {
            //muda a tag de disponivel
            //faz update dessa unidade na base de dados
            // Remove da map a unidade(feito)
            unidades.Remove(cod);
            
        }
        
        public void adicionaUnidades(Unidade uni)
        {
            //Muda a tag na base de dados temos k mudar 
        }

        /*public List<int> getListaEstados()
        {
            //Nao faço a minima ideia do k faz
        }*/

        public void defineEstado(int estad)
        {
            //falta a data
            this.fogoCombate.Estado = estad;
        }
        //mudei este para void????????
        public void novoFogo()
        {
            this.fogoCombate = new Fogo();
        }

        
        /*public Boolean subFomFogo(Fogo nFogo)
        { 
        // Vai a base de dados e submete um novo fogo
        }*/
        public void selTermComb()
        {
            // 4 combate terminado falta por a data
            this.fogoCombate.Estado = 4;
            DateTime agora = new DateTime();
            this.fogoCombate.Dh_extinto = agora;
        }
        public void setRaio(float raioNovo)
        {
            this.fogoCombate.Raio_fogo = raioNovo;
        }
        //este adicionei nao existia
        public void setRaioS(float raioNovo)
        {
            this.fogoCombate.Raio_seg = raioNovo;
        }

        /*
        public Relatorio getRelatorio(String relatorioP)
        {
            //Nao faço ideia do k faz
        }*/

        
         /* public Boolean submitRel(Relatorio rel)
        {
            //Insere na base de dados o relatorio
        }*/
         

    }
}
