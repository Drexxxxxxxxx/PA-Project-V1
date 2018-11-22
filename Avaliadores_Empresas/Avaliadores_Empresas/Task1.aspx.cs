using MySql.Data.MySqlClient;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Json;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avaliadores_Empresas
{
    public partial class Task1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Avaliar();
            AvaliarPacote();
            ApagarPassadodata();
            ApagarPassadodataPacote();
            MudarContaAval();
            MudarContaEmp();
            VerificarPagouRefEmp();
            VerificarPagouRefAval();
        }
        void VerificarPagouRefAval()
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblavaliador";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            // string empresanomestr = "";
            // string avaliadoremailstr = "";


            MySqlDataReader read = comand.ExecuteReader();

            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                if (read[13].ToString() == "1" || read[13].ToString() == "2")
                {
                    var client = new RestClient("https://replica.eupago.pt/clientes/rest_api/multibanco/info");
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("postman-token", "0571c54a-b107-2ce0-3a1b-bd3d53ec51d1");
                    request.AddHeader("content-type", "application/json");

                    request.AddParameter("application/json", "{\n\t\"chave\" : \"demo-f706-5d02-dff2-e0a\",\n\t\"referencia\" : \"" + read[9].ToString() + "\"\n}", ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    var a = JsonValue.Parse(response.Content);

                    try
                    {
                        if (a["pagamentos"].ToString().Trim('"') != "")
                        {
                            JsonObject jo = new JsonObject();
                            // populate the array
                            jo.Add("arrayName", a["pagamentos"]);

                            string Estado = jo["arrayName"][0]["estado"];
                            if (Estado == "paga")
                            {
                                MySqlConnection con5 = new MySqlConnection(constr);
                                con5.Open();
                                string NomeLocalizacao5 = "";
                                DateTime dataverify = DateTime.Parse(read[8].ToString());
                                DateTime dataadd;
                                if ((dataverify - DateTime.Now).TotalDays > 0)
                                {
                                    dataadd = DateTime.Parse(read[8].ToString());
                                }
                                else
                                {
                                    dataadd = DateTime.Today;
                                }
                                if (read[13].ToString() == "1")
                                {
                                    dataadd = dataadd.AddDays(30);
                                    NomeLocalizacao5 = "UPDATE tblavaliador SET TipoPagamento=0, datadeexpiracao=@data, Ativo=0 WHERE id=@id";
                                }
                                if (read[13].ToString() == "2")
                                {
                                    dataadd = dataadd.AddYears(1);
                                    NomeLocalizacao5 = "UPDATE tblavaliador SET TipoPagamento=0, datadeexpiracao=@data, Ativo=3 WHERE id=@id";
                                }
                                MySqlCommand comand5 = new MySqlCommand(NomeLocalizacao5);
                                comand5.Parameters.AddWithValue("@data", dataadd.ToString("yyyy-MM-dd"));
                                comand5.Parameters.AddWithValue("@id", read[7].ToString());
                                comand5.Connection = con5;
                                comand5.ExecuteNonQuery();

                                con5.Close();

                                MailMessage mail = new MailMessage();

                                mail.From = new MailAddress("geral@portaldoavaliador.com");
                                mail.To.Add(read[3].ToString());
                                mail.Subject = "Pagamento Efetuado";
                                //Envia a password já decriptada
                                // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
                                mail.Body = "";
                                LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
                                LinkedImage.ContentId = "MyPic";
                                //Added the patch for Thunderbird as suggested by Jorge
                                LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                                  "Olá " + read[1].ToString() + ",<br><br>O pagamento da sua conta já foi efectuado, muito obrigado pela sua renovação.<br><br>Aceda aqui ao site www.portaldoavaliador.com <br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
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
                    catch
                    {

                    }
                }
            }
            con.Close();
            read.Close();
        }

        void VerificarPagouRefEmp()
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblempresa";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            // string empresanomestr = "";
            // string avaliadoremailstr = "";


            MySqlDataReader read = comand.ExecuteReader();

            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                if (read[13].ToString() == "1" || read[13].ToString() == "2")
                {
                    var client = new RestClient("https://replica.eupago.pt/clientes/rest_api/multibanco/info");
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("postman-token", "0571c54a-b107-2ce0-3a1b-bd3d53ec51d1");
                    request.AddHeader("content-type", "application/json");

                    request.AddParameter("application/json", "{\n\t\"chave\" : \"demo-f706-5d02-dff2-e0a\",\n\t\"referencia\" : \"" + read[9].ToString() + "\"\n}", ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    var a = JsonValue.Parse(response.Content);

                    try
                    {
                        if (a["pagamentos"].ToString().Trim('"') != "")
                        {
                            JsonObject jo = new JsonObject();
                            // populate the array
                            jo.Add("arrayName", a["pagamentos"]);

                            string Estado = jo["arrayName"][0]["estado"];
                            if (Estado == "paga")
                            {
                                MySqlConnection con5 = new MySqlConnection(constr);
                                con5.Open();
                                string NomeLocalizacao5 = "";
                                DateTime dataverify = DateTime.Parse(read[8].ToString());
                                DateTime dataadd;
                                if ((dataverify - DateTime.Now).TotalDays > 0)
                                {
                                    dataadd = DateTime.Parse(read[8].ToString());
                                }
                                else
                                {
                                    dataadd = DateTime.Today;
                                }
                                if (read[13].ToString() == "1")
                                {
                                   dataadd = dataadd.AddDays(30);
                                    NomeLocalizacao5 = "UPDATE tblempresa SET TipoPagamento=0,datadeexpiracao=@data,Ativo=0 WHERE id=@id";
                                }
                                if (read[13].ToString() == "2")
                                {
                                    dataadd = dataadd.AddYears(1);
                                    NomeLocalizacao5 = "UPDATE tblempresa SET TipoPagamento=0,datadeexpiracao=@data,Ativo=3 WHERE id=@id";
                                }
                                MySqlCommand comand5 = new MySqlCommand(NomeLocalizacao5);
                                comand5.Parameters.AddWithValue("@data", dataadd.ToString("yyyy-MM-dd"));
                                comand5.Parameters.AddWithValue("@id", read[7].ToString());
                                comand5.Connection = con5;
                                comand5.ExecuteNonQuery();

                                con5.Close();

                                MailMessage mail = new MailMessage();

                                mail.From = new MailAddress("geral@portaldoavaliador.com");
                                mail.To.Add(read[3].ToString());
                                mail.Subject = "Pagamento Efetuado";
                                //Envia a password já decriptada
                                // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
                                mail.Body = "";
                                LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
                                LinkedImage.ContentId = "MyPic";
                                //Added the patch for Thunderbird as suggested by Jorge
                                LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                                  "Olá " + read[1].ToString() + ",<br><br>O pagamento da sua conta já foi efectuado, muito obrigado pela sua renovação.<br><br>Aceda aqui ao site www.portaldoavaliador.com <br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
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
                    catch
                    {

                    }
                }
            }
            con.Close();
            read.Close();
        }

        void Avaliar()
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblavaliacao where estado = 1 AND estadoavaliacao = 1";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            // string empresanomestr = "";
            // string avaliadoremailstr = "";


            MySqlDataReader read = comand.ExecuteReader();

            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                DateTime myDate = DateTime.Parse(read[3].ToString());
                myDate = myDate.AddDays(4);
                if ((myDate - DateTime.Now).TotalDays >= 0)
                {
                    //Avaliacaoempresa = Convert.ToInt16(read[4].ToString());
                    MySqlConnection con2 = new MySqlConnection(constr);
                    con2.Open();
                    string NomeLocalizacao = "SELECT * from tblempresa where id = @id";
                    MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                    comand2.Parameters.AddWithValue("@id", read[4].ToString());
                    comand2.Connection = con2;
                    comand2.ExecuteNonQuery();

                    MySqlDataReader read2 = comand2.ExecuteReader();
                    while (read2.Read())
                    {
                    }

                    MySqlConnection con4 = new MySqlConnection(constr);
                    con4.Open();
                    string Tipo = "SELECT * FROM tblavaliadoresnumaavaliacao WHERE idAvaliacao = @id AND Escolhido = 1";
                    MySqlCommand comand4 = new MySqlCommand(Tipo);
                    comand4.Parameters.AddWithValue("@id", read[0].ToString());
                    comand4.Connection = con4;
                    comand4.ExecuteNonQuery();


                    MySqlDataReader read4 = comand4.ExecuteReader();
                    while (read4.Read())
                    {
                    }

                    MySqlConnection con3 = new MySqlConnection(constr);
                    con3.Open();
                    string NomeLocalizacao3 = "SELECT * from tblavaliador where id = @id";
                    MySqlCommand comand3 = new MySqlCommand(NomeLocalizacao3);
                    comand3.Parameters.AddWithValue("@id", read4[1].ToString());
                    comand3.Connection = con3;
                    comand3.ExecuteNonQuery();

                    MySqlDataReader read3 = comand3.ExecuteReader();
                    while (read3.Read())
                    {
                    }

                    if (read[11].ToString() == "0")
                    {
                        MailMessage mail = new MailMessage();

                        mail.From = new MailAddress("geral@portaldoavaliador.com");
                        mail.To.Add(read2[3].ToString());
                        mail.Subject = "Avaliar Avaliador";
                        //Envia a password já decriptada
                        // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
                        mail.Body = "";
                        LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
                        LinkedImage.ContentId = "MyPic";
                        //Added the patch for Thunderbird as suggested by Jorge
                        LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          "Olá " + read2[1].ToString() + ",<br><br>Na sequência da avaliação " + read[6].ToString() + " pediamos que dispensasse uns minutos para proceder a avaliação do avaliador " + read3[1].ToString() + ".<br><br>Aceda aqui para fazer a avaliação www.portaldoavaliador.com/Empresa.aspx <br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
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

                        MailMessage mail2 = new MailMessage();

                        mail2.From = new MailAddress("geral@portaldoavaliador.com");
                        mail2.To.Add(read2[3].ToString());
                        mail2.Subject = "Avaliar empresa";
                        //Envia a password já decriptada
                        // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
                        mail2.Body = "";
                        LinkedResource Linkedimage2 = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
                        Linkedimage2.ContentId = "MyPic";
                        //Added the patch for Thunderbird as suggested by Jorge
                        Linkedimage2.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                        AlternateView htmlview2 = AlternateView.CreateAlternateViewFromString(
                          "Olá " + read3[1].ToString() + ",<br><br>Na sequência da avaliação " + read[6].ToString() + " pediamos que dispensasse uns minutos para proceder a avaliação da empresa " + read2[1].ToString() + ".<br><br>Aceda aqui para fazer a avaliação www.portaldoavaliador.com/Avaliador.aspx <br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
                          null, "text/html");

                        htmlview2.LinkedResources.Add(Linkedimage2);
                        mail2.AlternateViews.Add(htmlview2);
                        mail2.IsBodyHtml = true;
                        SmtpClient smtp2 = new SmtpClient("webmail.portaldoavaliador.com");
                        smtp2.Port = 25;
                        smtp2.Credentials = new System.Net.NetworkCredential("geral@portaldoavaliador.com", "P@ssword1");
                        smtp2.EnableSsl = true;
                        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                        smtp2.Send(mail2);
                        smtp2.Dispose();
                        mail2.Dispose();


                        MySqlConnection con5 = new MySqlConnection(constr);
                        con5.Open();
                        string NomeLocalizacao5 = "UPDATE tblavaliacao SET EnviouEmail = 1 WHERE id = @id";
                        MySqlCommand comand5 = new MySqlCommand(NomeLocalizacao5);
                        comand5.Parameters.AddWithValue("@id", read[0].ToString());
                        comand5.Connection = con5;
                        comand5.ExecuteNonQuery();

                        con5.Close();
                    }

                    read2.Close();
                    con2.Close();

                    read3.Close();
                    con3.Close();

                    read4.Close();
                    con4.Close();
                }
            }
            con.Close();
            read.Close();
        }

        void ApagarPassadodata()
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblavaliacao";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

           // string empresanomestr = "";
           // string avaliadoremailstr = "";


            MySqlDataReader read = comand.ExecuteReader();

            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                DateTime myDate = DateTime.Parse(read[3].ToString());
                myDate = myDate.AddDays(4);
                if ((myDate - DateTime.Now).TotalDays < 0)
                {
                    //Avaliacaoempresa = Convert.ToInt16(read[4].ToString());
                    MySqlConnection con2 = new MySqlConnection(constr);
                    con2.Open();
                    string NomeLocalizacao = "SELECT * from tblempresa where id = @id";
                    MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                    comand2.Parameters.AddWithValue("@id", read[4].ToString());
                    comand2.Connection = con2;
                    comand2.ExecuteNonQuery();

                    MySqlDataReader read2 = comand2.ExecuteReader();
                    while (read2.Read())
                    {
                    }

                      MySqlConnection con4 = new MySqlConnection(constr);
                      con4.Open();
                      string Tipo = "DELETE FROM tblavaliadoresnumaavaliacao WHERE idAvaliacao = @id";
                      MySqlCommand comand4 = new MySqlCommand(Tipo);
                      comand4.Parameters.AddWithValue("@id", read[0].ToString());
                      comand4.Connection = con4;
                      comand4.ExecuteNonQuery();
                      con4.Close();

                    MySqlConnection con5 = new MySqlConnection(constr);
                    con5.Open();
                    string Tipo2 = "DELETE FROM tblavaliacao WHERE id = @id";
                    MySqlCommand comand5 = new MySqlCommand(Tipo2);
                    comand5.Parameters.AddWithValue("@id", read[0].ToString());
                    comand5.Connection = con5;
                    comand5.ExecuteNonQuery();
                    con5.Close();


                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress("geral@portaldoavaliador.com");
                    mail.To.Add(read2[3].ToString());
                    mail.Subject = "Avaliação eliminada";
                    //Envia a password já decriptada
                    // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
                    mail.Body = "";
                    LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
                    LinkedImage.ContentId = "MyPic";
                    //Added the patch for Thunderbird as suggested by Jorge
                    LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                      "Olá " + read2[1].ToString() + ",<br><br>A avaliação " + read[6].ToString() + " Foi apagada devido a ter passado os dias do deadline.<br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
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

                    con2.Close();
                    read2.Close();
                }
            }
            con.Close();
            read.Close();
        }

        void AvaliarPacote()
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblpacotetotal where Estado = 1 AND estadoavaliacao = 1";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            // string empresanomestr = "";
            // string avaliadoremailstr = "";


            MySqlDataReader read = comand.ExecuteReader();

            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                DateTime myDate = DateTime.Parse(read[2].ToString());
                myDate = myDate.AddDays(4);
                if ((myDate - DateTime.Now).TotalDays >= 0)
                {
                        //Avaliacaoempresa = Convert.ToInt16(read[3].ToString());
                        MySqlConnection con2 = new MySqlConnection(constr);
                        con2.Open();
                        string NomeLocalizacao = "SELECT * from tblempresa where id = @id";
                        MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                        comand2.Parameters.AddWithValue("@id", read[3].ToString());
                        comand2.Connection = con2;
                        comand2.ExecuteNonQuery();

                        MySqlDataReader read2 = comand2.ExecuteReader();
                        while (read2.Read())
                        {
                        }

                        MySqlConnection con4 = new MySqlConnection(constr);
                        con4.Open();
                        string Tipo = "SELECT * FROM tblavaliadoresnumpacote WHERE idAvaliacao = @id AND Escolhido = 1";
                        MySqlCommand comand4 = new MySqlCommand(Tipo);
                        comand4.Parameters.AddWithValue("@id", read[0].ToString());
                        comand4.Connection = con4;
                        comand4.ExecuteNonQuery();


                        MySqlDataReader read4 = comand4.ExecuteReader();
                        while (read4.Read())
                        {
                        }

                        MySqlConnection con3 = new MySqlConnection(constr);
                        con3.Open();
                        string NomeLocalizacao3 = "SELECT * from tblavaliador where id = @id";
                        MySqlCommand comand3 = new MySqlCommand(NomeLocalizacao3);
                        comand3.Parameters.AddWithValue("@id", read4[1].ToString());
                        comand3.Connection = con3;
                        comand3.ExecuteNonQuery();

                        MySqlDataReader read3 = comand3.ExecuteReader();
                        while (read3.Read())
                        {
                        }

                    if (read[9].ToString() == "0")
                    {
                        MailMessage mail = new MailMessage();

                        mail.From = new MailAddress("geral@portaldoavaliador.com");
                        mail.To.Add(read2[3].ToString());
                        mail.Subject = "Avaliar Avaliador";
                        //Envia a password já decriptada
                        // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
                        mail.Body = "";
                        LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
                        LinkedImage.ContentId = "MyPic";
                        //Added the patch for Thunderbird as suggested by Jorge
                        LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          "Olá " + read2[1].ToString() + ",<br><br>Na sequência do pacote de avaliação " + read[1].ToString() + " pediamos que dispensasse uns minutos para proceder a avaliação do avaliador " + read3[1].ToString() + ".<br><br>Aceda aqui para fazer a avaliação www.portaldoavaliador.com/Empresa.aspx <br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
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

                        MailMessage mail2 = new MailMessage();

                        mail2.From = new MailAddress("geral@portaldoavaliador.com");
                        mail2.To.Add(read2[3].ToString());
                        mail2.Subject = "Avaliar empresa";
                        //Envia a password já decriptada
                        // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
                        mail2.Body = "";
                        LinkedResource Linkedimage2 = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
                        Linkedimage2.ContentId = "MyPic";
                        //Added the patch for Thunderbird as suggested by Jorge
                        Linkedimage2.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                        AlternateView htmlview2 = AlternateView.CreateAlternateViewFromString(
                          "Olá " + read3[1].ToString() + ",<br><br>Na sequência da avaliação " + read[1].ToString() + " pediamos que dispensasse uns minutos para proceder a avaliação da empresa " + read2[1].ToString() + ".<br><br>Aceda aqui para fazer a avaliação www.portaldoavaliador.com/Avaliador.aspx <br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
                          null, "text/html");

                        htmlview2.LinkedResources.Add(Linkedimage2);
                        mail2.AlternateViews.Add(htmlview2);
                        mail2.IsBodyHtml = true;
                        SmtpClient smtp2 = new SmtpClient("webmail.portaldoavaliador.com");
                        smtp2.Port = 25;
                        smtp2.Credentials = new System.Net.NetworkCredential("geral@portaldoavaliador.com", "P@ssword1");
                        smtp2.EnableSsl = true;
                        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                        smtp2.Send(mail2);
                        smtp2.Dispose();
                        mail2.Dispose();


                        MySqlConnection con5 = new MySqlConnection(constr);
                        con5.Open();
                        string NomeLocalizacao5 = "UPDATE tblpacotetotal SET EnviouEmail = 1 WHERE id = @id";
                        MySqlCommand comand5 = new MySqlCommand(NomeLocalizacao5);
                        comand5.Parameters.AddWithValue("@id", read[0].ToString());
                        comand5.Connection = con5;
                        comand5.ExecuteNonQuery();

                        con5.Close();
                    }

                    read2.Close();
                    con2.Close();

                    read3.Close();
                    con3.Close();

                    read4.Close();
                    con4.Close();
                }
            }
            con.Close();
            read.Close();
        }

        void ApagarPassadodataPacote()
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblpacotetotal";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            // string empresanomestr = "";
            // string avaliadoremailstr = "";


            MySqlDataReader read = comand.ExecuteReader();

            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                DateTime myDate = DateTime.Parse(read[2].ToString());
                myDate = myDate.AddDays(4);
                if ((myDate - DateTime.Now).TotalDays < 0)
                {
                    //Avaliacaoempresa = Convert.ToInt16(read[3].ToString());
                    MySqlConnection con2 = new MySqlConnection(constr);
                    con2.Open();
                    string NomeLocalizacao = "SELECT * from tblempresa where id = @id";
                    MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                    comand2.Parameters.AddWithValue("@id", read[3].ToString());
                    comand2.Connection = con2;
                    comand2.ExecuteNonQuery();

                    MySqlDataReader read2 = comand2.ExecuteReader();
                    while (read2.Read())
                    {
                    }

                    MySqlConnection con4 = new MySqlConnection(constr);
                    con4.Open();
                    string Tipo = "DELETE FROM tblavaliadoresnumpacote WHERE idAvaliacao = @id";
                    MySqlCommand comand4 = new MySqlCommand(Tipo);
                    comand4.Parameters.AddWithValue("@id", read[0].ToString());
                    comand4.Connection = con4;
                    comand4.ExecuteNonQuery();
                    con4.Close();

                    MySqlConnection con6 = new MySqlConnection(constr);
                    con6.Open();
                    string Tipo6 = "DELETE FROM tblpacoteindividual WHERE idpacotetotal = @id";
                    MySqlCommand comand6 = new MySqlCommand(Tipo6);
                    comand6.Parameters.AddWithValue("@id", read[0].ToString());
                    comand6.Connection = con6;
                    comand6.ExecuteNonQuery();
                    con6.Close();

                    MySqlConnection con5 = new MySqlConnection(constr);
                    con5.Open();
                    string Tipo2 = "DELETE FROM tblpacotetotal WHERE id = @id";
                    MySqlCommand comand5 = new MySqlCommand(Tipo2);
                    comand5.Parameters.AddWithValue("@id", read[0].ToString());
                    comand5.Connection = con5;
                    comand5.ExecuteNonQuery();
                    con5.Close();


                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress("geral@portaldoavaliador.com");
                    mail.To.Add(read2[3].ToString());
                    mail.Subject = "Pacote de Avaliação eliminada";
                    //Envia a password já decriptada
                    // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
                    mail.Body = "";
                    LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
                    LinkedImage.ContentId = "MyPic";
                    //Added the patch for Thunderbird as suggested by Jorge
                    LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                      "Olá " + read2[1].ToString() + ",<br><br>A avaliação " + read[1].ToString() + " Foi apagada devido a ter passado os dias do deadline.<br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
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

                    con2.Close();
                    read2.Close();
                }
            }
            con.Close();
            read.Close();
        }

        void MudarContaAval()
        {
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT * from tblavaliador";
            MySqlCommand comand = new MySqlCommand(N_Avaliador);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();
            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                DateTime myDate = DateTime.Parse(read[8].ToString());

                if ((myDate - DateTime.Now).TotalDays <= 0)
                {
                    if (read[12].ToString() == "0")
                    {
                        MailMessage mail = new MailMessage();

                        mail.From = new MailAddress("geral@portaldoavaliador.com");
                        mail.To.Add(read[3].ToString());
                        mail.Subject = "Avaliar Avaliador";
                        //Envia a password já decriptada
                        // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
                        mail.Body = "";
                        LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
                        LinkedImage.ContentId = "MyPic";
                        //Added the patch for Thunderbird as suggested by Jorge
                        LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          "Olá " + read[1].ToString() + ",<br><br>Falta 1 dia para acabar a sua licença, pediamos que dispensasse uns minutos para Renovar a sua conta.<br><br>Aceda aqui para fazer a renovação www.portaldoavaliador.com/Avaliador.aspx <br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
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

                        MySqlConnection con5 = new MySqlConnection(constr);
                        con5.Open();
                        string NomeLocalizacao5 = "UPDATE tblavaliador SET EnviouEmail = 1 WHERE id = @id";
                        MySqlCommand comand5 = new MySqlCommand(NomeLocalizacao5);
                        comand5.Parameters.AddWithValue("@id", read[7].ToString());
                        comand5.Connection = con5;
                        comand5.ExecuteNonQuery();

                        con5.Close();
                    }
                    
                }
            }

            con.Close();
            read.Close();
        
        }

        void MudarContaEmp()
        {
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT * from tblempresa";
            MySqlCommand comand = new MySqlCommand(N_Avaliador);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();
            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                DateTime myDate = DateTime.Parse(read[8].ToString());


                if ((myDate - DateTime.Now).TotalDays <= 0)
                {
                    if (read[12].ToString() == "0")
                    {
                        MailMessage mail = new MailMessage();

                        mail.From = new MailAddress("geral@portaldoavaliador.com");
                        mail.To.Add(read[3].ToString());
                        mail.Subject = "Avaliar Empresa";
                        //Envia a password já decriptada
                        // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
                        mail.Body = "";
                        LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
                        LinkedImage.ContentId = "MyPic";
                        //Added the patch for Thunderbird as suggested by Jorge
                        LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          "Olá " + read[1].ToString() + ",<br><br>Falta 1 dia para acabar a sua licença, pediamos que dispensasse uns minutos para Renovar a sua conta.<br><br>Aceda aqui para fazer a renovação www.portaldoavaliador.com/Empresa.aspx <br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
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

                        MySqlConnection con5 = new MySqlConnection(constr);
                        con5.Open();
                        string NomeLocalizacao5 = "UPDATE tblempresa SET EnviouEmail = 1 WHERE id = @id";
                        MySqlCommand comand5 = new MySqlCommand(NomeLocalizacao5);
                        comand5.Parameters.AddWithValue("@id", read[7].ToString());
                        comand5.Connection = con5;
                        comand5.ExecuteNonQuery();

                        con5.Close();
                    }

                }
            }

            con.Close();
            read.Close();

        }
    }
}