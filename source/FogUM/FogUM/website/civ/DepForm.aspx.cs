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
using FogUM.bd;
using FogUM;

public partial class DepForm : PageBase
{
    Proc_Civil pc = new Proc_Civil();
    GooglePoint gp = new GooglePoint();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        // BUILD STATS LIST
        BListStats.Items.Add("Corporações: " + pc.getTotCorps().ToString());
        BListStats.Items.Add("Comandantes: " + pc.getTotCmds().ToString());
        BListStats.Items.Add("Helicópetros: " + pc.getTotHelis().ToString());
        BListStats.Items.Add("Fogos: " + pc.getTotFogs().ToString());
        BListStats.Items.Add("Voluntários: " + pc.getTotVols().ToString());
        BListStats.Items.Add("Depósitos: " + pc.getTotDepos().ToString());
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


    protected void Button2_Click(object sender, EventArgs e)
    {
        Deposito dep = new Deposito();
        DBLinqDataContext bdf = new DBLinqDataContext();

        double comp = 0, alt = 0, larg = 0, mor = 0, tipo = 0, distr=0;
        double lat=0, lng=0;

        int flag = 0;

        string morada = moradaD.Text.ToString()+","+DropDownList2.Text.ToString()+","+"Portugal";

        gp.Address = morada;
        bool b1 = moradaD.Text.ToString().Equals("");
        bool b2 = gp.GeocodeAddress("ABQIAAAARjBz8x6IK17on8A12juLMhT2yXp_ZAY8_ufC3CFXhHIE1NvwkxSAGQSOkASydSDhHVgCsbb99KH0PQ");

        if (b2 == false)
        {
            flag = 1;
            // WebMsgBox.Show("IMPOSSIVEL LOCALIZAR ENDEREÇO");
            //Image19.Text = "*Impossivel Localizar Endereço";           
           // Image19.Font.Italic = true;
            Image29.Visible = false;
            Image19.Visible = true;
        }

        if (flag == 0)
        {
            if (b1 || b2 == false)
            {

                Image19.Visible = true;
                Image29.Visible = false;
            }
            else
                if (b2 == true)
                {
                    Image19.Visible = false;
                    Image29.Visible = true;
                    mor = 1;
                    lat = gp.Latitude;
                    lng = gp.Longitude;
                }
        } 

        if (IsNumeric(compr.Text.ToString()) || (compr.Text.ToString().Equals(""))|| (compr.Text.ToString().Equals("0")))
        {
            Image22.Visible = true;
            Image26.Visible = false;
        }
        else
        {
            comp = Convert.ToDouble(compr.Text.ToString());
            Image22.Visible = false;
            Image26.Visible = true;
        }

        if (IsNumeric(altura.Text.ToString()) || (altura.Text.ToString().Equals("")) || (altura.Text.ToString().Equals("0")))
        {
            Image23.Visible = true;
            Image27.Visible = false;
        }
        else
        {
            alt = Convert.ToDouble(altura.Text.ToString());
            Image23.Visible = false;
            Image27.Visible = true;
        }

        if (IsNumeric(largura.Text.ToString()) || (largura.Text.ToString().Equals("")) || (largura.Text.ToString().Equals("0")))
        {
            Image24.Visible = true;
            Image28.Visible = false;
        }
        else
        {
            larg = Convert.ToDouble(largura.Text.ToString());
            Image24.Visible = false;
            Image28.Visible = true;
        }

        if (DropDownList1.Text.ToString().Equals(""))
        {
            Image21.Visible = true;
            Image25.Visible = false;
        }
        else
        {
            tipo = 1;
            Image21.Visible = false;
            Image25.Visible = true;
        }

        if (DropDownList2.Text.ToString().Equals(""))
        {
            Image20.Visible = true;
            Image30.Visible = false;
        }
        else
        {
            distr = 1;
            Image20.Visible = false;
            Image30.Visible = true;
        }

        if ((comp == 0) || (alt == 0) || (larg == 0) || (mor==0) || (tipo==0) || (distr==0))
            WebMsgBox.Show("FORMULÁRIO INVÁLIDO");
        else
        {
            dep.Latitude = lat;
            dep.Longitude = lng;
            dep.Cod=  0;
            dep.CodTipo = pc.testaCod(DropDownList1.Text.ToString());
            dep.Volume =(float) (comp * alt * larg);

            pc.insereDeposito(dep);

            WebMsgBox.Show("OBRIGADO PELA SUA COLABORAÇÃO");
           
            DropDownList1.ClearSelection();
            moradaD.Text = "";
            DropDownList2.ClearSelection();
            compr.Text = "";
            largura.Text = "";
            altura.Text = "";
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
