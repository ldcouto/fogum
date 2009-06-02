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
using System.Text.RegularExpressions;

public partial class Relatorios : PageBase
{
    Proc_Cmd proc = new Proc_Cmd(new Comandante(6, "Marco da Costa", "teste", "teste0!"));
    Proc_Civil proc_civ = new Proc_Civil();

    protected void Page_Load(object sender, EventArgs e)
    {
        getFogos_ACtivos();
        if (!IsPostBack)
            getRelsPendentes(proc.Cmd.User);
    }

    protected void getRelsPendentes(string cmdUsername)
    {
        Dictionary<Fogo, Relatorio> rels = proc.Relatorios;
        if (rels!=null)
        {
            ListBox_rels.Items.Clear();
            foreach (KeyValuePair<Fogo, Relatorio> fr in rels)
            {
                string[] aux = fr.Key.Dh_extinto.ToString().Split(' ');
                ListBox_rels.Items.Add(fr.Value.Codigo + " - " + fr.Key.Concelho + " - " + aux[0]);
            }
        }


    }


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {


    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        String drop = ListBox_rels.Text;
        l_b_civ.Visible = false;
        l_b_bomb.Visible = false;


        if (drop != "")
        {
            string[] aux = drop.Split('-');
            int cod = Convert.ToInt32(aux[0]);
            Dictionary<Fogo, Relatorio> rels = proc.Relatorios;
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

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        bool flag = true;
        l_b_bomb.Visible = false;
        l_b_civ.Visible = false;

        if (IsNumeric(txt_baixas_bomb.Text)) 
        {
            l_b_bomb.Visible = true;
            flag = false;
        }
        if (IsNumeric(txt_baixas_civis.Text)) 
        {
            l_b_civ.Visible = true;
            flag = false;
        }
        if (flag)
        {
            int cod = Convert.ToInt32(txt_cod_rel.Text);
            Dictionary<Fogo, Relatorio> rels = proc.Relatorios;
            foreach (KeyValuePair<Fogo, Relatorio> fr in rels)
                if (fr.Value.Codigo == cod)
                {
                    fr.Value.Comentario = txt_comentario.Text;
                    proc.submitRel(fr.Value,fr.Key);
                }
            txt_baixas_bomb.Text = "";
            txt_baixas_civis.Text = "";
            txt_cod_fog.Text = "";
            txt_cod_rel.Text = "";
            txt_comentario.Text = "";
            txt_concelho.Text = "";
            txt_data_cir.Text = "";
            txt_data_fim.Text = "";
            txt_data_ini.Text = "";
           
        }
        //foreach (string x in ListBox1.Text)
        //    if (x.Contains(txt_cod_rel.Text))
        //        ListBox1.Items.Remove(x);

        ListBox_rels.Items.Remove(ListBox_rels.SelectedItem.Text);


    }

    private void getFogos_ACtivos()
    {
        Dictionary<int, Fogo> fogos = proc_civ.selectMapaIncendios();
        //TODO ISTO NÃO TÁ direito! Está a mostrar fogos activos com relatórios já preenchidos.
        // Tem de se iterar sobre o conjunto de fogos devolvido pelo rels pendentes
        foreach (Fogo f in fogos.Values)
        {
            string[] aux = f.Dh_comeco.ToString().Split(' ');
            ListBox_fogos.Items.Add(f.Codigo+" - "+f.Concelho+"-"+aux[0]);
            
        }

    }

    public bool IsNumeric(string s)
    {
        foreach (char c in s)
        {
            if (!char.IsNumber(c))
                return true;
        }
        return false;
    }
}
 
