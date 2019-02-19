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

        protected void Button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 3; i++)
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("geral@portaldoavaliador.com");
                mail.To.Add("luis.128.b@gmail.com");
                mail.Subject = "Pagamento Efetuado";
                //Envia a password já decriptada
                // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
                mail.Body = "";
                LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
                LinkedImage.ContentId = "MyPic";
                //Added the patch for Thunderbird as suggested by Jorge
                LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                  "Olá ,<br><br>O pagamento da sua conta já foi efectuado, muito obrigado pela sua renovação.<br><br>Aceda aqui ao site www.portaldoavaliador.com <br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
                  null, "text/html");

                htmlView.LinkedResources.Add(LinkedImage);
                mail.AlternateViews.Add(htmlView);
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("webmail.portaldoavaliador.com");
                smtp.Port = 25;
                smtp.Credentials = new System.Net.NetworkCredential("geral@portaldoavaliador.com", "P@ssword1");
                smtp.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtp.Send(mail);
                smtp.Dispose();
                mail.Dispose();
            }
        }
    }
}