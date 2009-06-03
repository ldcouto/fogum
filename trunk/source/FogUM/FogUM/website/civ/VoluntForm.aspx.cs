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
using System.IO;

public partial class VoluntForm : PageBase
{
    Proc_Civil pc = new Proc_Civil();


    protected void Page_Load(object sender, EventArgs e)
    {

        // BUILD STATS LIST
        Proc_Civil proc = new Proc_Civil();
        BListStats.Items.Add("Corporações: " + proc.getTotCorps().ToString());
        BListStats.Items.Add("Comandantes: " + proc.getTotCmds().ToString());
        BListStats.Items.Add("Helicópetros: " + proc.getTotHelis().ToString());
        BListStats.Items.Add("Fogos: " + proc.getTotFogs().ToString());
        BListStats.Items.Add("Voluntários: " + proc.getTotVols().ToString());
        BListStats.Items.Add("Depósitos: " + proc.getTotDepos().ToString());
        //bool flag = true;

        //try
        //{
        //    FileStream f = new FileStream("FogUM/website/bda/xmls/" + "DumpFogUM-" + DateTime.Now.ToShortDateString().ToString() + ".xml", FileMode.Open);
        //}
        //catch (Exception exc)
        //{
        //    flag = false;
        //}

        //if (flag==false)
        //{
        //    Parser ps = new Parser();
        //    ps.criarXML();
        //}


      
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
     

        int fnome = 0, fmail = 0, ftelef = 0, fmorada = 0, disp = 0, distr = 0;



        if (!IsNumeric(nome.Text.ToString()) && (nome.Text.ToString().Contains("")))
        {
            Image19.Visible = true;
            Image25.Visible = false;
        }


        else
        {

            fnome = 1;
            Image19.Visible = false;
            Image25.Visible = true;
        }

        bool b1 = email.Text.ToString().Contains("@") ;
        bool b2 =email.Text.ToString().Contains(".");
        bool b3 = (!email.Text.ToString().Contains(""));

        if (b1 && b2 || b3)
        {
            
            fmail = 1;
            Image20.Visible = false;
            Image26.Visible = true;
        }
        else
        {
            Image20.Visible = true;
            Image26.Visible = false;
            
        }

        if ((telefone.Text.ToString().Length != 9) || (IsNumeric(telefone.Text.ToString())))
        {
            Image24.Visible = true;
            Image30.Visible = false;
        }
        else
        {

            ftelef = 1;
            Image24.Visible = false;
            Image29.Visible = true;
        }

           if (morada.Text.ToString().Equals(""))
           {
               Image21.Visible = true;
               Image27.Visible = false;
           }
           else
           {
               fmorada = 1;
               Image21.Visible = false;
               Image27.Visible = true;
           }

           if (DropDownList1.Text.ToString().Equals(""))
           {
               Image22.Visible = true;
               Image28.Visible = false;
           }
           else
           {
               Image22.Visible = false;
               Image28.Visible = true;
               distr = 1;
           }

           if (DropDownList2.Text.ToString().Equals(""))
           {
               Image23.Visible = true;
               Image29.Visible = false;
           }
           if (DropDownList2.Text.ToString().Equals("3 Meses"))
           {
               
               Image23.Visible = false;
               Image29.Visible = true;
               disp = 3;
           }
           if (DropDownList2.Text.ToString().Equals("6 Meses"))
           {
             
               Image23.Visible = false;
               Image29.Visible = true;
               disp = 6;
           }
           if (DropDownList2.Text.ToString().Equals("12 Meses"))
           {
               
               Image23.Visible = false;
               Image29.Visible = true;
               disp = 12;
           }

           if ((fnome == 0) || (fmail == 0) || (ftelef == 0) || (fmorada == 0) || (disp == 0) || (distr == 0))
               WebMsgBox.Show("FORMULÁRIO INVÁLIDO");
               
           else
           {
               vol.CodDist = pc.testaCodDistr(DropDownList1.Text.ToString());
               vol.Cod = 1;  // ????
               vol.Email = email.Text.ToString();
               vol.Nome = nome.Text.ToString();
               vol.Telefone = telefone.Text.ToString();
               vol.Disp = disp;// ???

               pc.submeterVoluntario(vol);

               WebMsgBox.Show("OBRIGADO PELA SUA COLABORAÇÃO");
               nome.Text = "";
               morada.Text = "";
               telefone.Text = "";
               email.Text = "";
               DropDownList2.ClearSelection();
               DropDownList1.ClearSelection();
               Image25.Visible = false;
               Image26.Visible = false;
               Image27.Visible = false;
               Image28.Visible = false;
               Image29.Visible = false;
               Image30.Visible = false;


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
