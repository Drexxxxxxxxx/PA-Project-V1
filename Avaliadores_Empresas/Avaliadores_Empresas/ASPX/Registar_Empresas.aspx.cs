using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avaliadores_Empresas
{
    public partial class Registar_Empresas : System.Web.UI.Page
    {
        public void Limpar()
        {
            email_emp.Text = "";       
            nome_emp.Text = "";
            pass_emp.Text = "";


        }
        string idAvaliadorstrng = "";
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "avaliadores&empresas2018";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49,
                    0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(),
                   CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;

        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "avaliadores&empresas2018";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76,
                    0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(),
                   CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sessaostrng = Session["idAvaliador"].ToString();
                LinkButton1.Text = "Logout";
                LinkButton4.Text = "Logout";

            }
            catch
            {
                LinkButton1.Text = "Login";
                LinkButton4.Text = "Login";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login");
        }

        protected void btn_regist_emp_Click(object sender, EventArgs e)
        {
            // Registar Empresa
            if (mobile_emp.Text.Length != 9 || pass_emp.Text != confpass_emp.Text)
            {
                if (mobile_emp.Text.Length != 9)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('O numero de telemóvel tem que ter 9 digitos')", true);
                }
                if (pass_emp.Text != confpass_emp.Text)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('As palavras passes estão diferentes')", true);
                }
            }
            else
            {
                try
                {
                    int contadoremail = 1;
                    string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                    // Codigo para registar
                    MySqlConnection con = new MySqlConnection(constr);
                    con.Open();
                    string N_Avaliador = "SELECT id from tblavaliador where Email = @Email";
                    MySqlCommand comand = new MySqlCommand(N_Avaliador);
                    comand.Parameters.AddWithValue("@Email", email_emp.Text);
                    comand.Connection = con;
                    comand.ExecuteNonQuery();

                    MySqlDataReader read = comand.ExecuteReader();
                    //SE EXISTIR ELE ENTRA NO IF
                    if (read.Read())
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Já existe um avaliador com esse email')", true);
                        contadoremail = 0;
                        //limpar();

                    }
                    con.Close();
                    con.Open();
                    N_Avaliador = "SELECT id from tblempresa where Email = @Email";
                    comand = new MySqlCommand(N_Avaliador);
                    comand.Parameters.AddWithValue("@Email", email_emp.Text);
                    comand.Connection = con;
                    comand.ExecuteNonQuery();

                    read = comand.ExecuteReader();
                    //SE EXISTIR ELE ENTRA NO IF
                    if (read.Read())
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Já existe uma empresa com esse email')", true);
                        contadoremail = 0;
                        //limpar();

                    }
                    con.Close();

                    //SENÃO NÃO ENTRA
                    if (contadoremail == 1)
                    {
                        con.Open();

                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "insertempresa";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("varN_Registo", nregisto_emp.Text.Trim());
                        cmd.Parameters.AddWithValue("varNome", nome_emp.Text.Trim());
                        cmd.Parameters.AddWithValue("varPass", Encrypt(pass_emp.Text.Trim()));
                        cmd.Parameters.AddWithValue("varEmail", email_emp.Text.Trim());
                        cmd.Parameters.AddWithValue("varTelefone", mobile_emp.Text.Trim());
                        cmd.Parameters.AddWithValue("varMorada", morada_emp.Text.Trim());
                        cmd.Parameters.AddWithValue("varAtivo", 1);
                        DateTime myDate = DateTime.Today;
                        myDate = myDate.AddDays(5);
                        cmd.Parameters.AddWithValue("vardatadeexpiracao", myDate.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                        con.Close();

                        LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
                        SendEmail(email_emp.Text.Trim(), "Registo Portal do Avaliador", LinkedImage, "Parabéns! <br><br>Obrigado pelo registo no Portal do Avaliador. <br><br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br><br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>");

                        SendEmail("geral@portaldoavaliador.com", "Nova empresa", LinkedImage, "Nova empresa com o email: " + email_emp.Text.Trim() + " foi registado, está agora com o pagamento pendente");

                        con.Open();
                        string nregistotoid = "";
                        N_Avaliador = "SELECT id from tblempresa where N_Registo = @N_Registo";
                        comand = new MySqlCommand(N_Avaliador);
                        comand.Parameters.AddWithValue("@N_Registo", nregisto_emp.Text);
                        comand.Connection = con;
                        comand.ExecuteNonQuery();

                        read = comand.ExecuteReader();
                        //SE EXISTIR ELE ENTRA NO IF
                        if (read.Read())
                        {
                            nregistotoid = read[0].ToString();
                            //limpar();

                        }
                        con.Close();

                        //Pagamento
                        idAvaliadorstrng = nregistotoid;
                    }



                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
                }
            }
        }

        private void SendEmail(string To, string Subject, LinkedResource LinkedImage, string body)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("geral@portaldoavaliador.com");
            mail.To.Add(To);
            mail.Subject = Subject;
            //Envia a password já decriptada
            // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
            mail.Body = "This is the body of the email";

            LinkedImage.ContentId = "MyPic";
            //Added the patch for Thunderbird as suggested by Jorge
            LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
              body,
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["idAvaliador"] = idAvaliadorstrng;
            Session["Tipo"] = "2";
            Session["PagarTipo"] = "0";
            Response.Redirect("Payment");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["idAvaliador"] = idAvaliadorstrng;
            Session["Tipo"] = "2";
            Session["PagarTipo"] = "1";
            Response.Redirect("Payment");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            int contadortipo = 0;
            try
            {
                if (Session["Tipo"].ToString() == "1")
                {
                    contadortipo = 1;
                    try
                    {
                        string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                        // Codigo para registar
                        MySqlConnection con = new MySqlConnection(constr);
                        con.Open();
                        string N_Avaliador = "SELECT * from tblavaliador where id = @id";
                        MySqlCommand comand = new MySqlCommand(N_Avaliador);

                        try
                        {
                            comand.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
                        }
                        catch
                        {
                            Response.Redirect("Registar_Avaliadores");
                        }

                        comand.Connection = con;
                        comand.ExecuteNonQuery();
                    }
                    catch
                    {
                        Response.Redirect("Registar_Avaliadores");
                    }
                }
                if (contadortipo != 1)
                {
                    Response.Redirect("Registar_Avaliadores");
                }
            }
            catch
            {
                Response.Redirect("Registar_Avaliadores");
            }
            Response.Redirect("Avaliador");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            int contadortipo = 0;
            try
            {
                if (Session["Tipo"].ToString() == "2")
                {
                    contadortipo = 1;
                    try
                    {
                        string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                        // Codigo para registar
                        MySqlConnection con = new MySqlConnection(constr);
                        con.Open();
                        string N_Avaliador = "SELECT * from TblEmpresa where id = @id";
                        MySqlCommand comand = new MySqlCommand(N_Avaliador);

                        try
                        {
                            comand.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
                        }
                        catch
                        {
                            Response.Redirect("Registar_Empresas");
                        }

                        comand.Connection = con;
                        comand.ExecuteNonQuery();
                    }
                    catch
                    {
                        Response.Redirect("Registar_Empresas");
                    }
                }
                if (contadortipo != 1)
                {
                    Response.Redirect("Registar_Empresas");
                }
            }
            catch
            {
                Response.Redirect("Registar_Empresas");
            }
            Response.Redirect("Empresa");
        }
    }
}