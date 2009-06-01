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
            Label2.Text = "*Impossivel Localizar Endereço";           
            Label2.Font.Italic = true;
            Label2.Visible = true;
        }

        if (flag == 0)
        {
            if (b1 || b2 == false)
                Label2.Visible = true;
            else
                if (b2 == true)
                {
                    Label2.Visible = false;
                    mor = 1;
                    lat = gp.Latitude;
                    lng = gp.Longitude;
                }
        } 

        if (IsNumeric(compr.Text.ToString()) || (compr.Text.ToString().Equals(""))|| (compr.Text.ToString().Equals("0")))
        {
            Label6.Visible = true;
        }
        else
        {
            comp = Convert.ToDouble(compr.Text.ToString());
            Label6.Visible = false;
        }

        if (IsNumeric(altura.Text.ToString()) || (altura.Text.ToString().Equals("")) || (altura.Text.ToString().Equals("0")))
        {
            Label4.Visible = true;
        }
        else
        {
            alt = Convert.ToDouble(altura.Text.ToString());
            Label4.Visible = false;
        }

        if (IsNumeric(largura.Text.ToString()) || (largura.Text.ToString().Equals("")) || (largura.Text.ToString().Equals("0")))
        {
            Label8.Visible = true;
        }
        else
        {
            larg = Convert.ToDouble(largura.Text.ToString());
            Label8.Visible = false;
        }

        if (DropDownList1.Text.ToString().Equals(""))
            Label13.Visible = true;
        else
        {
            tipo = 1;
            Label13.Visible = false;
        }

        if (DropDownList2.Text.ToString().Equals(""))
            Label15.Visible = true;
        else
        {
            distr = 1;
            Label15.Visible = false;
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
}
