using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avaliadores_Empresas
{
    public partial class Contactos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sessaostrng = Session["idAvaliador"].ToString();
                LinkButton1.Text += "Logout";

            }
            catch
            {
                LinkButton1.Text += "Login";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("geral@portaldoavaliador.com");
            mail.To.Add("geral@portaldoavaliador.com");
            mail.Subject = "Email de Contactos " + TextBox3.Text;
            //Envia a password já decriptada
            string descricao = TextBox4.Text;
            descricao = descricao.Replace(System.Environment.NewLine, "<br>");

            mail.Body = "Nome de quem enviou: " + TextBox1.Text + "<br> Email: " + TextBox2.Text + " <br> Descrição: " + descricao;


            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("webmail.portaldoavaliador.com");
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("geral@portaldoavaliador.com", "P@ssword1");
            smtp.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.Send(mail);
            smtp.Dispose();
            mail.Dispose();

            /*   MailMessage mail = new MailMessage();

               mail.From = new MailAddress("luis3.128.b80@gmail.com");
               mail.To.Add("luis3.128.b80@gmail.com");
               mail.Subject = "Email de Contactos " + TextBox3.Text;
               //Envia a password já decriptada
               string descricao = TextBox4.Text;
               descricao = descricao.Replace(System.Environment.NewLine, "<br>");

               mail.Body = "Nome de quem enviou: " + TextBox1.Text + "<br> Email: " + TextBox2.Text + " <br> Descrição: " + descricao;


               mail.IsBodyHtml = true;
               SmtpClient smtp = new SmtpClient("smtp.gmail.com");
               smtp.Port = 143;
               smtp.Credentials = new System.Net.NetworkCredential("luis3.128.b80@gmail.com", "14112000");
               smtp.EnableSsl = true;
               smtp.Send(mail);*/
        }
    }
}