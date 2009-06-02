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
using System.Text;
using FogUM.bd;
using FogUM;

public partial class VoluntForm : PageBase
{
    Proc_Civil pc = new Proc_Civil();


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
        Voluntario vol = new Voluntario();
      // DBLinqDataContext bdf = new DBLinqDataContext();

        int fnome = 0, fmail = 0, ftelef = 0, fmorada = 0, disp = 0, distr = 0;


           if (!IsNumeric(nome.Text.ToString()) && (nome.Text.ToString().Contains("")))
               Label17.Visible = true;
           else
           {
               
               fnome = 1;
               Label17.Visible = false;
           }

           if ((!email.Text.ToString().Contains("@")) && (!email.Text.ToString().Contains(".")) && (email.Text.ToString().Contains("")))
               Label21.Visible = true;
           else
           {
               
               fmail = 1;
               Label21.Visible = false;
           }

           if ((telefone.Text.ToString().Length != 9) || (IsNumeric(telefone.Text.ToString())))
               Label20.Visible = true;
           else
           {
               
               ftelef = 1;
               Label20.Visible = false;
           }

           if (morada.Text.ToString().Equals(""))
               Label19.Visible = true;
           else
           {
               fmorada = 1;
               Label19.Visible = false;
           }

           if (DropDownList1.Text.ToString().Equals(""))
               Label23.Visible = true;
           else
           {
               Label23.Visible = false;
               distr = 1;
           }

           if (DropDownList2.Text.ToString().Equals(""))
               Label22.Visible = true;

           if (DropDownList2.Text.ToString().Equals("3 Meses"))
           {
               
               Label22.Visible = false;
               disp = 3;
           }
           if (DropDownList2.Text.ToString().Equals("6 Meses"))
           {
             
               Label22.Visible = false;
               disp = 6;
           }
           if (DropDownList2.Text.ToString().Equals("12 Meses"))
           {
               
               Label22.Visible = false;
               disp = 12;
           }

           if ((fnome == 0) || (fmail == 0) || (ftelef == 0) || (fmorada == 0) || (disp ==0) || (distr==0))
               WebMsgBox.Show("FORMULÁRIO INVÁLIDO");
           else
           {
               vol.CodDist = pc.testaCodDistr(DropDownList1.Text.ToString());
               vol.Cod = 1;
               vol.Email = email.Text.ToString();
               vol.Nome = nome.Text.ToString();
               vol.Telefone = telefone.Text.ToString();
               vol.Disp = disp;

               pc.submeterVoluntario(vol);
             
               WebMsgBox.Show("OBRIGADO PELA SUA COLABORAÇÃO");
               nome.Text = "";
               morada.Text = "";
               telefone.Text = "";
               email.Text = "";
               DropDownList2.ClearSelection();
               DropDownList1.ClearSelection();
               
              
           }

                     
        

        
        
        
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "";
    }

}
