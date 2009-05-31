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
        DEPOSITO dep = new DEPOSITO();
        DBLinqDataContext bdf = new DBLinqDataContext();

        double comp = 0, alt = 0, larg = 0, mor = 0, tipo = 0;
        double lat=0, lng=0;


        if (moradaD.Text.ToString().Equals(""))
            Label2.Visible = true;
        else
        {
            Label2.Visible = false;
            mor = 1;
            //lat =fazer metodo para a partir da morada dar latitude e longitude
            //lng = ...
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

        if ((comp == 0) || (alt == 0) || (larg == 0) || (mor==0) || (tipo==0))
            WebMsgBox.Show("FORMULÁRIO INVÁLIDO");
        else
        {
            //dep.LATITUDE = lat;
            //dep.LONGITUDE = lng;
            //dep.COD_DEPO = 0;
            //dep.COD_TIPO = convDepCod(DropDownList1.Text.ToString());
            //dep.VOLUME = //funçao para calcular volume a partir de comp, alt, larg
            //bdf.DEPOSITOs.InsertOnSubmit(dep);
            //bdf.SubmitChanges();
            string ola = DropDownList1.Text.ToString();
            WebMsgBox.Show("OBRIGADO PELA SUA COLABORAÇÃO");
            compr.Text = "";
            moradaD.Text = "";
            altura.Text = "";
            largura.Text = "";
            DropDownList1.ClearSelection();
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "";
    }
}
