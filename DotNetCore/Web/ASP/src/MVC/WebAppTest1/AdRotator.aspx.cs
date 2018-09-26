using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebAppTest1
{
    public partial class AdRotator : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (fileUpload1.HasFile)
            {
                try
                {
                    sb.AppendFormat("Uploading File: {0}", fileUpload1.FileName);
                    fileUpload1.SaveAs("C:\\SaveFiles\\" + fileUpload1.FileName);
                    sb.AppendFormat("<br /> Save As {0}", fileUpload1.PostedFile.FileName);
                    sb.AppendFormat("<br /> File type: {0}", fileUpload1.PostedFile.FileName);
                    sb.AppendFormat("<br /> File name: {0}", fileUpload1.PostedFile.FileName);
                    sb.AppendFormat("<br /> File length: {0} bit", fileUpload1.PostedFile.ContentLength);

                    Message.Text = sb.ToString();
                }
                catch (Exception ex)
                {
                    sb.Append("<br /> Error <br />");
                    sb.AppendFormat("Unable to save file <br /> {0}", ex.Message);
                }     
            }
            else
            {
                Message.Text = sb.ToString();
            }
        } 
    }
}