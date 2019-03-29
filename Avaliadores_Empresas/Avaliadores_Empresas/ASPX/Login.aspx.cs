using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avaliadores_Empresas
{
    public partial class Login : System.Web.UI.Page
    {
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
            KillSleepingConnections(100);

            try
            {
                string sessaostrng = Session["idAvaliador"].ToString();
                
                LinkButton2.Text = "Logout";

            }
            catch
            {
                
                LinkButton2.Text = "Login";
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login");
        }


        protected void btn_entrar_Click(object sender, EventArgs e)
        {
            // Saber se é Avaliador ?
            int contadoremail = 0;
           string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar


            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT id, Pass from tblavaliador where Email = '" + txt_email.Text + "'", con))
                using (MySqlDataReader read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        string encriptacaopass = Encrypt(txt_pass.Text);
                        if (encriptacaopass == read[1].ToString())
                        {
                            Session["idAvaliador"] = read[0].ToString();
                            Session["Tipo"] = "1";
                            Response.Redirect("Avaliador");
                        }
                        else
                        {
                            lbl_msg.Text = "Password Incorreta";
                        }
                    }
                    else
                    {
                        contadoremail++;
                    }
                }
            }

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT id, Pass from tblempresa where Email = '" + txt_email.Text + "'", con))
                using (MySqlDataReader read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        string encriptacaopass = Encrypt(txt_pass.Text);
                        if (encriptacaopass == read[1].ToString())
                        {
                            Session["idAvaliador"] = read[0].ToString();
                            Session["Tipo"] = "2";
                            Response.Redirect("Empresa");
                        }
                        else
                        {
                            lbl_msg.Text = "Password Incorreta";
                        }
                    }
                    else
                    {
                        contadoremail++;
                    }
                }
            }

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT id, Pass from tbladmin where Email = '" + txt_email.Text + "'", con))
                using (MySqlDataReader read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        string encriptacaopass = Encrypt(txt_pass.Text);
                        if (encriptacaopass == read[1].ToString())
                        {
                            Session["idAvaliador"] = read[0].ToString();
                            Session["Tipo"] = "3";
                            Response.Redirect("Admin");
                        }
                        else
                        {
                            lbl_msg.Text = "Password Incorreta";
                        }
                    }
                    else
                    {
                        contadoremail++;
                    }
                }
            }

            if (txt_email.Text == "" && txt_pass.Text == "")
            {
                lbl_msg.Text = " Tem que preencher os dois campos ";
            }

            // Se não preencher nada ?
            if(contadoremail == 3)
            {
                lbl_msg.Text = "Email incorreto";
            }
            if (txt_email.Text == "" && txt_pass.Text == "")
            {
                lbl_msg.Text = " Tem que preencher os dois campos ";
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            div1.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            // Saber se é Avaliador ?
            int contadoremail = 0;
            string password = "";
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT id, Pass from tblavaliador where Email = '" + TextBox1.Text + "'", con))
                using (MySqlDataReader read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        password = read[1].ToString();
                    }
                    else
                    {
                        contadoremail++;
                    }
                }
            }
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT id, Pass from tblempresa where Email = '" + TextBox1.Text + "'", con))
                using (MySqlDataReader read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        password = read[1].ToString();
                    }
                    else
                    {
                        contadoremail++;
                    }
                }
            }

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT id, Pass from tbladmin where Email = '" + TextBox1.Text + "'", con))
                using (MySqlDataReader read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        password = read[1].ToString();
                    }
                    else
                    {
                        contadoremail++;
                    }
                }
            }
            // Se não preencher nada ?
            if (contadoremail != 3)
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("geral@portaldoavaliador.com");
                mail.To.Add(TextBox1.Text);
                mail.Subject = "Portal dos Avaliadores Recuperação da password";
                //Envia a password já decriptada
                mail.Body = "Boas, como pedido enviamos lhe a sua palavra passe que é a seguinte: " + Decrypt(password);


                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("webmail.portaldoavaliador.com");
                smtp.Port = 25;
                smtp.Credentials = new System.Net.NetworkCredential("geral@portaldoavaliador.com", "P@ssword1");
                smtp.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtp.Send(mail);
                smtp.Dispose();
                mail.Dispose();

                /*MailMessage mail = new MailMessage();


                mail.From = new MailAddress("luis3.128.b80@gmail.com");
                mail.To.Add(TextBox1.Text);
                mail.Subject = "Portal dos Avaliadores Recuperação da password";
                //Envia a password já decriptada
                mail.Body = "Boas, como pedido enviamos lhe a sua palavra passe que é a seguinte: " + Decrypt(password);


                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 25;
                smtp.Credentials = new System.Net.NetworkCredential("luis3.128.b80@gmail.com", "14112000");
                smtp.EnableSsl = true;
                smtp.Send(mail);*/
            }
            div1.Visible = false;
        }

        static public int KillSleepingConnections(int iMinSecondsToExpire)
        {
            string strSQL = "show processlist";
            System.Collections.ArrayList m_ProcessesToKill = new ArrayList();
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            MySqlConnection myConn = new MySqlConnection(constr);
            MySqlCommand myCmd = new MySqlCommand(strSQL, myConn);
            MySqlDataReader MyReader = null;

            try
            {
                myConn.Open();

                // Get a list of processes to kill.
                MyReader = myCmd.ExecuteReader();
                while (MyReader.Read())
                {
                    // Find all processes sleeping with a timeout value higher than our threshold.
                    int iPID = Convert.ToInt32(MyReader["Id"].ToString());
                    string strState = MyReader["Command"].ToString();
                    int iTime = Convert.ToInt32(MyReader["Time"].ToString());

                    if (strState == "Sleep" && iTime >= iMinSecondsToExpire && iPID > 0)
                    {
                        // This connection is sitting around doing nothing. Kill it.
                        m_ProcessesToKill.Add(iPID);
                    }
                }

                MyReader.Close();

                foreach (int aPID in m_ProcessesToKill)
                {
                    strSQL = "kill " + aPID;
                    myCmd.CommandText = strSQL;
                    myCmd.ExecuteNonQuery();
                }
            }
            catch (Exception excep)
            {
            }
            finally
            {
                if (MyReader != null && !MyReader.IsClosed)
                {
                    MyReader.Close();
                }

                if (myConn != null && myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }

            return m_ProcessesToKill.Count;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            div1.Visible = false;
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
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
                        using (MySqlConnection con = new MySqlConnection(constr))
                        {
                            con.Open();
                            using (MySqlCommand command = new MySqlCommand("SELECT * from tblavaliador where id = @id", con))
                            {
                                try
                                {
                                    command.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
                                }
                                catch
                                {
                                    Response.Redirect("Registar_Avaliadores");
                                }

                                command.Connection = con;
                                command.ExecuteNonQuery();
                            }
                        }                  
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

        protected void LinkButton4_Click(object sender, EventArgs e)
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
                        using (MySqlConnection con = new MySqlConnection(constr))
                        {
                            con.Open();
                            using (MySqlCommand command = new MySqlCommand("SELECT * from TblEmpresa where id = @id", con))
                            {
                                try
                                {
                                    command.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
                                }
                                catch
                                {
                                    Response.Redirect("Registar_Empresas");
                                }

                                command.Connection = con;
                                command.ExecuteNonQuery();
                            }
                        }
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