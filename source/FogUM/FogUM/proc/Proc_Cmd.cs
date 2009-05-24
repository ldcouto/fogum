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
        private List<Relatorio> relatorios ;
        private Dictionary<int, Corporacao> corporacoes;
        private Dictionary<int, Heli> helis;

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
            get { return relatorios; }
            set { relatorios = value; }
        }

        public Dictionary<int, Corporacao> Corperacoes
        {
            get { return corporacoes; }
            set { corporacoes = value; }
        }

        public Dictionary<int, Heli> Helis
        {
            get { return helis; }
            set { helis = value; }
        }


        public Proc_Cmd(Comandante cmd)
        {
            this.cmd = cmd;
            this.depositosDisp = new List<Deposito>();
            this.bd = new BD_FogUM();
         //   this.relatorios = bd.getRelsPendentes(cmd.User); Falta funcionar na base de dados
            this.corporacoes = new Dictionary<int, Corporacao>();
            this.helis = new Dictionary<int, Heli>();
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
          //- Vai a base de dados buscar as unidades disponiveis 
         public Dictionary<int, Corporacao> getCoorpDisponiveis()
         {
              return bd.getCorpsDisponiveis();
         }
         
        public Dictionary<int, Heli> getHeliDisponiveis()
         {
             return bd.getHelisDisponiveis();

         }

        public Dictionary<int, Corporacao> getCoorpDestacadas()
        {
            //igual a propriedade Unidades
            return corporacoes;
        }

        public Dictionary<int, Heli> getHelisDestacados()
        {
            //igual a propriedade Unidades
            return helis;
        }

        public void remCorp(int cod)
        {
            Corporacao aux;
            corporacoes.TryGetValue(cod, out aux);
            aux.Disponivel = true;
            bd.updateCorp(aux);
            corporacoes.Remove(cod);                     
            
        }
        public void remHeli(int cod)
        {
            Heli aux;
            helis.TryGetValue(cod, out aux);
            aux.Disp = true;
            bd.updateHeli(aux);
            helis.Remove(cod); 
        }

        
        public void adicionaCorp(Corporacao corp)
        {
            corp.Disponivel = false;
            bd.updateCorp(corp);
            corporacoes.Add(corp.Cod, corp);
        }

        public void adicionaHeli(Heli hel)
        {
            hel.Disp = false;
            bd.updateHeli(hel);
            helis.Add(hel.Cod, hel);
        }

        
        /*public List<int> getListaEstados()
        {
            //Nao faço a minima ideia do k faz
        }*/

        public void defineEstado(int estad)
        {
            //falta a data
            this.fogoCombate.Estado = estad;

            if (estad == 2)
            {
                //MAdiciona a Data
                DateTime agora = DateTime.Now;
                this.fogoCombate.Dh_circunscrito = agora;
            }
        }
        //mudei este para void????????
        public void novoFogo()
        {
            this.fogoCombate = new Fogo();
        }

        
        public Boolean subFomFogo(Fogo nFogo, Comandante cmd)
        {
            bd.setNovoFogo(nFogo, cmd);
            return true;
        }

        public void selTermComb()
        {
            // 3 Extinto - combate terminado falta por a data
            this.fogoCombate.Estado = 3;
            
            //Muda a Data
            DateTime agora = DateTime.Now;
            this.fogoCombate.Dh_extinto = agora;

            //falta libertar Helis e corp
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

        
        public Relatorio getRelatorio(int codRel)
        {
            foreach (Relatorio r in this.relatorios)
            {
                if (r.Codigo == codRel)
                    return r;
            }
            return null;
        }

        
         public Boolean submitRel(Relatorio rel, Fogo f)
        {
            relatorios.Add(rel);
             //adiciona a base de dados, penso que é preciso
            bd.submitRel(rel, f);
            return true;
        }

         public void constDepDisp(float dis)
         {
             dis += fogoCombate.Raio_fogo;
             List<Deposito> aux = bd.getDepositos();
             foreach (Deposito dep in aux)
                 if (GeoCodeCalc.CalcDistance(fogoCombate.Latitude, fogoCombate.Longitude, dep.Latitude, dep.Longitude, GeoCodeCalcMeasurement.Kilometers) < dis)
                     depositosDisp.Add(dep);
         }
         

    }
}
