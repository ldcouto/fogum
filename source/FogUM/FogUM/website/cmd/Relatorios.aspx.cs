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
    Proc_Cmd proc = new Proc_Cmd(new Comandante());
    Proc_Civil proc_civ = new Proc_Civil();

    protected void Page_Load(object sender, EventArgs e)
    {
        proc.Cmd = proc.getCmdbyuser(User.Identity.Name);
        proc = new Proc_Cmd(proc.Cmd);
        
        if (!IsPostBack)
        {
            getRelsPendentes();
            getFogos_ACtivos(proc.Cmd.Cod);
            
        }
        // BUILD STATS LIST
        Proc_Civil pci = new Proc_Civil();
        BListStats.Items.Add("Corporações: " + pci.getTotCorps().ToString());
        BListStats.Items.Add("Comandantes: " + pci.getTotCmds().ToString());
        BListStats.Items.Add("Helicópetros: " + pci.getTotHelis().ToString());
        BListStats.Items.Add("Fogos: " + pci.getTotFogs().ToString());
        BListStats.Items.Add("Voluntários: " + pci.getTotVols().ToString());
        BListStats.Items.Add("Depósitos: " + pci.getTotDepos().ToString());

      //      WebMsgBox.Show("Olá " + proc.Cmd.Nome);

    }

    protected void getRelsPendentes()
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
        img_bx_bomb_KO.Visible = false;
        img_bx_bomb_ok.Visible = false;
        img_bx_civ_KO.Visible = false;
        img_bx_civ_ok.Visible = false;


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
                    btn_sub_rel.Enabled = true;
                }
        }

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        bool flag = true;
        img_bx_bomb_KO.Visible = false;
        img_bx_bomb_ok.Visible = true;
        img_bx_civ_KO.Visible = false;
        img_bx_civ_ok.Visible = true;

        if (IsNumeric(txt_baixas_bomb.Text)) 
        {
            img_bx_bomb_KO.Visible = true;
            img_bx_bomb_ok.Visible = false;
            flag = false;
        }
        if (IsNumeric(txt_baixas_civis.Text)) 
        {
            img_bx_civ_KO.Visible = true;
            img_bx_civ_ok.Visible = false;
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
            img_bx_bomb_KO.Visible = false;
            img_bx_bomb_ok.Visible = false;
            img_bx_civ_KO.Visible = false;
            img_bx_civ_ok.Visible = false;            
           
        }
        //foreach (string x in ListBox1.Text)
        //    if (x.Contains(txt_cod_rel.Text))
        //        ListBox1.Items.Remove(x);

        


    }

    private void getFogos_ACtivos(int cod)
    {
        Dictionary<int, Fogo> fogos = proc.selectMapaIncendios(cod);
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
        l_sel_fogo.Visible = false;
        String drop = ListBox_fogos.Text;
        if (drop != "")
        {
            string[] aux = drop.Split('-');
            int cod = Convert.ToInt32(aux[0]);
            proc.getFogo(cod);
            Session["fogoActivo"] = proc.FogoCombate.Codigo;
            Response.Redirect("~/cmd/Painel_Cmd.aspx");
        }
        else l_sel_fogo.Visible=true;
        
        
      
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
 
