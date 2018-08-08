using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTest1
{
    public partial class StateConfig : System.Web.UI.Page
    {
        public int counter
        {
            get
            {
                if (ViewState["pcounter"] != null)
                {
                    return ((int)ViewState["pcounter"]);
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                ViewState["pcounter"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            aaaaaaa.Text = counter.ToString();
            counter++;
        }

        protected void btnIncrement_Click(object sender, EventArgs e)
        {

        }



    }
}