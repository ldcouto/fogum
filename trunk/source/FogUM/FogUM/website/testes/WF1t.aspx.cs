using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FogUM;

public partial class testes_WF1t : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Comandante c1 = new Comandante(1,"","","");
        Proc_Cmd pc = new Proc_Cmd(c1);
        Dictionary<int,Corporacao> r = pc.getCoorpDisponiveis();
        foreach (KeyValuePair<int, Corporacao> kp in r)
            ListBox1.Items.Add(kp.Value.Nome);
    }
}
