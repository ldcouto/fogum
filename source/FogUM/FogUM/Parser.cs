using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;


namespace FogUM
{
    public class Parser
    {
        public string parseFogo()
        {
            TextWriter path = new StreamWriter("bd.xml");
            DBLinqDataContext bdf = new DBLinqDataContext();
            var fQuery =
                from fog in bdf.FOGOs
                select fog;
            StringBuilder sb = new StringBuilder();
            
            sb.Append("<Tab_fogo>\n");
            foreach (FOGO f in fQuery)
            {
                sb.Append("\t<fogo>\n");
                sb.Append("\t\t<bbomb>" + f.BAIXAS_BOMBEIROS + "<\\bbomb> \n");
                sb.Append("\t\t<bcivis>" + f.BAIXAS_CIVIS + "<\\bcivis> \n"); 
                sb.Append("\t<\\fogo>\n");
                        
            }
            sb.Append("<\\Tab_fogo>\n");
            path.Write(sb.ToString());

            path.Close();
            return sb.ToString();
        }
    }
}
