using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTest1
{
    public partial class SessionState : System.Web.UI.Page
    {
        String mystr;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblshstr.Text = this.mystr;
            this.lblsession.Text = (String)this.Session["asdf"];
        }

        protected void btnstr_Click(object sender, EventArgs e)
        {
            this.mystr = this.txtstr.Text;
            this.Session["asdf"] = this.txtstr.Text + "Session_String";
            this.lblshstr.Text = this.mystr;
            this.lblsession.Text = (String)this.Session["asdf"];
        }
    }
}