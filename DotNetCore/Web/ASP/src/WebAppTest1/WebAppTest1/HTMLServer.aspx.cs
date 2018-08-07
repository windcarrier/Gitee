using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTest1
{
    public partial class HTMLServer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "";
            str += txtname.Text + "<br />";
            str += txtstreet.Text + "<br />";
            str += txtcity.Text + "<br />";
            str += txtstate.Text + "<br />";
            displayrow.InnerHtml = str;
        }
    }
}