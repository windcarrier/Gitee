using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebAppTest1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = "Input your name";
            txtmessage.Text = " "; 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TextBox1.Text)) 
            {

                  // Access the HttpServerUtility methods through
                  // the intrinsic Server object.
                Label1.Text = "Welcome, " + Server.HtmlEncode(TextBox1.Text) + ". <br/> The url is " + Server.UrlEncode(Request.Url.ToString());
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            txtmessage.Text = " ";
            txtmessage.Text = "Selected node changed to: " + TreeView1.SelectedNode.Text;
            TreeNodeCollection childnodes = TreeView1.SelectedNode.ChildNodes;

            if (childnodes != null)
            {
                txtmessage.Text = " ";

                foreach (TreeNode t in childnodes)
                {
                    txtmessage.Text += t.Value;
                }

            }

        }

    }
}

