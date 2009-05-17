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
        Proc_Cmd procCmd = new Proc_Cmd();

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

            ListBox1.Items.Add("Zona de teste Proc_cmd");
            procCmd.novoFogo();
            procCmd.FogoCombate.Raio_fogo = 2;
            procCmd.FogoCombate.Raio_seg = 4;
            ListBox1.Items.Add(procCmd.verificaRaio(4).ToString());
            DateTime n = new DateTime();
            ListBox1.Items.Add(n.ToString());
            //Comandante c = new Comandante(1, "João Castro", "JCastro", "JC22");
            //testes.teste3(c);
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
