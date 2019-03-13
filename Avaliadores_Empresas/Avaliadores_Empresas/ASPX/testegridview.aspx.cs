using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;
using System.Net.Mime;

namespace Avaliadores_Empresas
{
    public partial class testegridview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGetSelectedValues_Click(object sender, EventArgs e)
        {
            string selectedValues = string.Empty;
            foreach (ListItem li in lstBoxTes2t.Items)
            {
                if (li.Selected == true)
                {
                    selectedValues += li.Text + ",";
                }
            }
            Response.Write(selectedValues.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (int i in lstBoxTes2t.GetSelectedIndices())
            {
               ListBox1.Items.Add(lstBoxTes2t.Items[i].Value);
            }
        }
    }
}