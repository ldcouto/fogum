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
using System.IO;
using FogUM;

public partial class XMLForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //FogUM.Parser p = new FogUM.Parser();
        //p.criarXML();
        


        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/")+"/bda/xmls");
        FileInfo[] files =  di.GetFiles("*.xml");


        if (!IsPostBack)
        {
            foreach (FileInfo f in files)
                ListBox1.Items.Add(f.Name);
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Parser_xml px = new Parser_xml();
        px.apagaBD();
        WebMsgBox.Show("REGISTOS APAGADOS");
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Parser_xml px = new Parser_xml();
        if (ListBox1.SelectedValue.ToString() == "") WebMsgBox.Show("SELECCIONE UM FICHEIRO XML");     
        else
        {
            string path = Server.MapPath("~/") + "/bda/xmls/" + ListBox1.SelectedValue.ToString();
            px.le_xml(path);
            WebMsgBox.Show("FICHEIRO XML CARREGADO");
        }
    }
}
