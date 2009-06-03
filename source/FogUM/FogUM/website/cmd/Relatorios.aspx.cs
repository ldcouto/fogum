﻿using System;

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
    Proc_Cmd proc = new Proc_Cmd(new Comandante());
    Proc_Civil proc_civ = new Proc_Civil();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            proc.Cmd=proc.getCmdbyuser(User.Identity.Name);
            getRelsPendentes(proc.Cmd.User);
            getFogos_ACtivos();
      //      WebMsgBox.Show("Olá " + proc.Cmd.Nome);
        }
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
        Image20.Visible = false; // KO l_b_civ
                                //l_b_civ.Visible = false;
                                 //l_b_bomb.Visible = false;
        Image30.Visible = false;
        Image1.Visible = false;//ko l_b_bomb
        Image2.Visible = false;


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
        Image1.Visible = false;
        Image20.Visible = false;

        if (IsNumeric(txt_baixas_bomb.Text)) 
        {
            Image1.Visible = true;
            Image2.Visible = false;
            flag = false;
        }
        if (IsNumeric(txt_baixas_civis.Text)) 
        {
            Image20.Visible = true;
            Image30.Visible = false;
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
            ListBox_rels.Items.Remove(ListBox_rels.SelectedItem.Text);
           
        }
        //foreach (string x in ListBox1.Text)
        //    if (x.Contains(txt_cod_rel.Text))
        //        ListBox1.Items.Remove(x);

        


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

    protected void btn_novo_fogo_Click(object sender, EventArgs e)
    {
        txt_morada.Enabled = true;
        l_morada.Enabled = true;
        DropDown_concelhos.Enabled = true;
        l_concelho.Enabled = true;
        btn_inic_Fogo.Visible= true;
        txt_lat.Enabled = true;
        l_lat.Enabled = true;
        txt_long.Enabled = true;
        l_long.Enabled = true;
    }
    protected void btn_inic_Fogo_Click(object sender, EventArgs e)
    {
        Boolean flag = true;
        //testar se latitude a long invalida
        if (txt_lat.Text == "" || txt_long.Text == "" || txt_long.Text.Contains('.') || txt_lat.Text.Contains('.'))
        {
            WebMsgBox.Show("Latitude ou Longitude inválida ex: 41,1111");
            flag = false;            
        }

        if (txt_morada.Text == "" || DropDown_concelhos.Text == "")
        {
            WebMsgBox.Show("Não inseriu a Morada ou não selecionaou o Distrito");
            flag = false;
        }
        if (flag)
        {

            proc.novoFogo();
            proc.FogoCombate.Concelho = DropDown_concelhos.Text.ToString();
            proc.FogoCombate.CodConcelho = proc.getCodConcelhoByName(txt_morada.Text);
            proc.FogoCombate.Estado = 1;
            proc.FogoCombate.Raio_fogo = 0.1f;
            proc.FogoCombate.Raio_seg = 0.5f;
            proc.FogoCombate.Latitude = Convert.ToDouble(txt_lat.Text);
            proc.FogoCombate.Longitude = Convert.ToDouble(txt_long.Text);
            proc.updateFogo();
            string[] aux = proc.FogoCombate.Dh_comeco.ToString().Split(' ');
            ListBox_fogos.Items.Add(proc.FogoCombate.Codigo + " - " + proc.FogoCombate.Concelho + "-" + aux[0]);
            txt_morada.Text = "";
            txt_long.Text = "";
            txt_lat.Text = "";
            txt_lat.Enabled = false;
            txt_long.Enabled = false;
            txt_morada.Enabled = false;
            btn_inic_Fogo.Enabled = false;
        }
    }

    protected void btn_reiniciar_fogo_Click(object sender, EventArgs e)
    {
        String drop = ListBox_fogos.Text;
        string[] aux = drop.Split('-');
        int cod = Convert.ToInt32(aux[0]);
        proc.getFogo(cod);
        ViewState["fogoActivo"] = proc.FogoCombate;
    }
}
 
