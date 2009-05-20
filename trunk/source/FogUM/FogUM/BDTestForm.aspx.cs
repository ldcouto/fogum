using System;
using System.Collections;
using System.Configuration;
using System.Data;
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
    public partial class BDTestForm : System.Web.UI.Page
    {

        BD_FogUM testes = new BD_FogUM();
        Comandante c1 = new Comandante(1, "Rui Pereira", "teste", "teste");
        Proc_Cmd procCmd = new Proc_Cmd(new Comandante(1, "Rui Pereira", "teste", "teste"));
        Parser parsefog = new Parser();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (string s in testes.teste())
                ListBox1.Items.Add(s);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Mexi aqui para teste pois nao conseguia adicionar outro butao. VAsco
            ListBox1.Items.Add("Zona de teste Proc_cmd");
            procCmd.novoFogo();
            
            procCmd.FogoCombate.Raio_fogo = 2;
            procCmd.FogoCombate.Raio_seg = 4;
            procCmd.getCoorpDisponiveis();
            ListBox1.Items.Add(procCmd.verificaRaio(4).ToString());
            DateTime agora = DateTime.Now;
            ListBox1.Items.Add(GeoCodeCalc.CalcDistance(41.455079, -8.295364, 38.72034, -9.135818, GeoCodeCalcMeasurement.Kilometers).ToString()); 
            ListBox1.Items.Add(agora.ToString());
            ListBox1.Items.Add(procCmd.getCoorpDisponiveis().Count.ToString());
            //Comandante c = new Comandante(1, "João Castro", "JCastro", "JC22");
            //testes.teste3(c);
            parsefog.parseFogo();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Add("vasda");
        
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Comandante c = new Comandante(1, "", "", "");
            Fogo nf = new Fogo(15, 3, 41.44753562970768, -8.28096628189087, 15, 17, "",
                new DateTime(2009, 1, 23, 14, 25, 55), new DateTime(2009, 1, 23, 17, 25, 55), 
                new DateTime(2009, 1, 23, 18, 25, 55), 10, 23, "", 1);
            foreach (Unidade u in testes.getUnidadesDestacadas(nf).Values)
            {
                if (u.GetType().Name.Equals("Corporacao"))
                {
                    Corporacao c = (Corporacao)u;
                    ListBox1.Items.Add(c.Nome);
                }
            }
            int i = 0;
            i++;
        }
    }
}
