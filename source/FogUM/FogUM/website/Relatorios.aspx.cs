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
using System.IO;
using FogUM;

public partial class Relatorios : PageBase
{
    Proc_Cmd proc = new Proc_Cmd(new Comandante(3, "Marco da Costa", "MCosta", "cmd02"));


    protected void Page_Load(object sender, EventArgs e)
    {
        getRelsPendentes(proc.Cmd.User);
    }

    protected void getRelsPendentes(string cmdUsername)
    {
        Dictionary<Fogo, Relatorio> rels = proc.Relatorio;
        foreach (KeyValuePair<Fogo, Relatorio> fr in rels)
        {
            string[] aux = fr.Key.Dh_extinto.ToString().Split(' ');
            ListBox1.Items.Add(fr.Value.Codigo + " - " + fr.Key.Concelho + " - " + aux[0]);
        }


    }


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "";
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        String drop = ListBox1.Text;


        if (drop != "")
        {
            string[] aux = drop.Split('-');
            int cod = Convert.ToInt32(aux[0]);
            Dictionary<Fogo, Relatorio> rels = proc.Relatorio;
            foreach (KeyValuePair<Fogo, Relatorio> fr in rels)
                if (fr.Value.Codigo == cod)
                {
                    txt_cod_fog.Text = fr.Key.Codigo.ToString();
                    txt_cod_rel.Text = cod.ToString();
                    txt_concelho.Text = fr.Key.Concelho.ToString();
                    txt_data_cir.Text = fr.Key.Dh_circunscrito.ToString();
                    txt_data_fim.Text = fr.Key.Dh_extinto.ToString();
                    txt_data_ini.Text = fr.Key.Dh_comeco.ToString();
                    txt_baixas_civis.Text = fr.Key.Baixas_civis.ToString();
                    txt_baixas_bomb.Text = fr.Key.Baixas_bombeiros.ToString();
                }
        }
        ListBox1.Items.Clear();
        getRelsPendentes(proc.Cmd.User);



    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        
    }
}
 
