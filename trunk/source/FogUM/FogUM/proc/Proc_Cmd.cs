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
        private Dictionary<Fogo, Relatorio> relatorios;
        private List<Corporacao> corporacoes;
        private List<Heli> helis;

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
        public Dictionary<Fogo,Relatorio> Relatorios
        {
            get { return relatorios; }
            set { relatorios = value; }
        }

        public List<Corporacao> Corporacoes
        {
            get { return corporacoes; }
            set { corporacoes = value; }
        }

        public List<Heli> Helis
        {
            get { return helis; }
            set { helis = value; }
        }


        public Proc_Cmd(Comandante cmd)
        {
            this.cmd = cmd;
            this.depositosDisp = new List<Deposito>();
            this.bd = new BD_FogUM();
            this.relatorios = bd.getRelsPendentesCFogos(cmd.User);
            this.corporacoes = new List<Corporacao>();
            this.helis = new List<Heli>();
        }


        //metodos....
        //public Boolean verificaRaioSeg(float raioSeg)
        //{
        //    if(raioSeg>fogoCombate.Raio_fogo && raioSeg>0)
        //        return true;
        //    return false;
        //}

        //public Boolean verificaRaio(float raio)
        //{
        //    if (raio > 0 && raio < fogoCombate.Raio_seg)
        //        return true;
        //    return false;
        //}
        public Boolean TestaRaio(float raio)
        {
            if (raio > 0)
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

        public int getCodConcelhoByName(string concelho)
        {
            return bd.getCodConsByName(concelho);
        }

        public Dictionary<int, Corporacao> getCoorpDestacadas()
        {
            // Dictionary<int, Corporacao> corpdes = new Dictionary<int, Corporacao>();
            // corpdes = 

            // corporacoes = dicToList(corpdes);
            return bd.getCorpsDestacadas(this.fogoCombate);
        }

        public Dictionary<int, Heli> getHelisDestacados()
        {
            return bd.getHelisDestacados(this.fogoCombate);
        }

        public void remCorp(Corporacao corpR)
        {
            List<Corporacao> teste = new List<Corporacao>();
            corporacoes = dicToList(getCoorpDestacadas());
            foreach (Corporacao c in corporacoes)
            {
                if (corpR.Cod != c.Cod)
                    teste.Add(c);
            }
            corporacoes = teste;
            corpR.Disponivel = true;
            bd.updateCorp(corpR);


            bd.setCorps(corporacoes, this.fogoCombate);


        }
        public void remHeli(Heli heliR)
        {
            List<Heli> teste1 = new List<Heli>();
            helis = dicToListH(getHelisDestacados());
            foreach (Heli h in helis)
            {
                if (heliR.Cod != h.Cod)
                    teste1.Add(h);
            }
            helis = teste1;
            heliR.Disp = true;
            bd.updateHeli(heliR);
            bd.setHelis(helis, this.fogoCombate);
        }


        public void adicionaCorp(Corporacao corp)
        {
            corporacoes = dicToList(getCoorpDestacadas());
            corp.Disponivel = false;
            corporacoes.Add(corp);
            bd.updateCorp(corp);

            bd.setCorps(corporacoes, this.fogoCombate);

        }

        public void adicionaHeli(Heli hel)
        {
            helis = dicToListH(getHelisDestacados());
            hel.Disp = false;
            bd.updateHeli(hel);
            helis.Add(hel);
            bd.setHelis(helis, this.fogoCombate);
        }


        /*public List<int> getListaEstados()
        {
            //Nao faço a minima ideia do k faz
        }*/

        public void defineEstado(int estad)
        {
            //falta a data

            //MAdiciona a Data
            this.fogoCombate.Estado = estad;
            DateTime agora = DateTime.Now;
            if (estad == 2)
                this.fogoCombate.Dh_circunscrito = agora;
            bd.updateFogo(this.fogoCombate);

        }
        //mudei este para void????????
        public void novoFogo()
        {
            this.fogoCombate = new Fogo();
            //FIX contra chaves estrangeiras
            fogoCombate.CodConcelho = 1;
            fogoCombate.Dh_circunscrito = DateTime.Now;
            fogoCombate.Dh_comeco = DateTime.Now;
            fogoCombate.Dh_extinto = DateTime.Now;
            fogoCombate.Codigo = bd.setNovoFogo(fogoCombate, Cmd);
            
        }


        public Boolean subFomFogo(Comandante cmd)
        {
            bd.setNovoFogo(this.fogoCombate, cmd);
            return true;
        }

        public void selTermComb()
        {
            // 3 Extinto - combate terminado falta por a data
            this.fogoCombate.Estado = 3;

            //Muda a Data
            DateTime agora = DateTime.Now;
            this.fogoCombate.Dh_extinto = agora;
            //libertar corporacoes e heli
            List<Corporacao> corpVazia = new List<Corporacao>();
            List<Heli> heliVazia = new List<Heli>();
            foreach (Corporacao c in dicToList(getCoorpDestacadas()))
            {
                c.Disponivel = true;
                bd.updateCorp(c);
            }
       //     bd.setCorps(corpVazia, this.fogoCombate);
       //     corporacoes = corpVazia;

            foreach (KeyValuePair<int, Heli> h in getHelisDestacados())
            {
                h.Value.Disp = true;
                bd.updateHeli(h.Value);
            }
       //     bd.setHelis(heliVazia, this.fogoCombate);
        //    helis = heliVazia;
            bd.updateFogo(this.fogoCombate);
        }
        public void setRaio(float raioNovo)
        {
            float n = (this.fogoCombate.Raio_seg) - (this.fogoCombate.Raio_fogo);
            n += raioNovo;
            this.fogoCombate.Raio_fogo = raioNovo;
            this.fogoCombate.Raio_seg = n;
            bd.updateFogo(this.FogoCombate);
        }
        //este adicionei nao existia
        public void setRaioS(float raioNovo)
        {
            this.fogoCombate.Raio_seg = raioNovo;
            bd.updateFogo(this.FogoCombate);
        }


        public Relatorio getRelatorio(int codRel)
        {

            foreach (Relatorio r in this.relatorios.Values)
            {
                if (r.Codigo == codRel)
                    return r;
            }
            return null;
        }


        
        public void submitRel(Relatorio rel, Fogo f)
        {
            //adiciona a base de dados, penso que é preciso
            bd.submitRel(rel, f);
            
        }

        public void constDepDisp(float dis)
        {
            dis += fogoCombate.Raio_fogo;
            List<Deposito> aux = bd.getDepositos();
            foreach (Deposito dep in aux)
            {
                double distancia = GeoCodeCalc.CalcDistance(fogoCombate.Latitude, fogoCombate.Longitude, dep.Latitude, dep.Longitude, GeoCodeCalcMeasurement.Kilometers);
                if (distancia < dis && distancia > this.fogoCombate.Raio_fogo)
                    depositosDisp.Add(dep);

            }
        }

        public double distanciaFogo(float lat, float longit)
        {
            return GeoCodeCalc.CalcDistance(fogoCombate.Latitude, fogoCombate.Longitude, lat, longit, GeoCodeCalcMeasurement.Kilometers);
        }
        public Dictionary<int, Corporacao> listToDic(List<Corporacao> list)
        {
            Dictionary<int, Corporacao> nDic = new Dictionary<int, Corporacao>();
            foreach (Corporacao corp1 in list)
            {
                nDic.Add(corp1.Cod, corp1);
            }
            return nDic;
        }
        public List<Corporacao> dicToList(Dictionary<int, Corporacao> dict)
        {
            List<Corporacao> list = new List<Corporacao>();
            foreach (KeyValuePair<int, Corporacao> corp1 in dict)
            {
                list.Add(corp1.Value);
            }
            return list;
        }

        public List<Heli> dicToListH(Dictionary<int, Heli> dict)
        {
            List<Heli> list = new List<Heli>();
            foreach (KeyValuePair<int, Heli> corp1 in dict)
            {
                list.Add(corp1.Value);
            }
            return list;
        }

        public Corporacao getCorp(int codCorp)
        {
            return bd.getCorp(codCorp);
        }

        public Heli getHeli(int codHeli)
        {
            return bd.getHeli(codHeli);
        }

        public void getFogo(int cod)
        {
            this.fogoCombate = bd.getFogo(cod);
        }

        public String getEstadoString()
        {
            int estado = this.FogoCombate.Estado;
            if (estado == 1)
                return "ACTIVO";
            if (estado == 2)
                return "CIRCUNSCRITO";
            else
                return "EXTINTO";
        }

        public Comandante getCmdbyuser(String user)
        {
            return bd.getComandante(user);
        }

        public void setComentario(string coment)
        {
            this.fogoCombate.Comentario = coment;
            bd.updateFogo(this.fogoCombate);
        }



        public void updateFogo()
        {
            bd.updateFogo(fogoCombate);
        }

    }
}
