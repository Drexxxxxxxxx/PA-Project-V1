using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avaliadores_Empresas
{
    public partial class Admin : System.Web.UI.Page
    {
        string index1 = "";
        string index2 = "";
        int DeleteEmpresaIndex = 0;
        int DeleteAvalIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Saber se é Avaliador ?
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string N_Avaliador = "SELECT * from tbladmin where id = @id";
                MySqlCommand comand = new MySqlCommand(N_Avaliador);
                if (Session["Tipo"].ToString() == "3")
                {
                    try
                    {
                        comand.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
                    }
                    catch
                    {
                        Response.Redirect("Login");
                    }
                }
                else
                {
                    Response.Redirect("Login");
                }
                comand.Connection = con;
                comand.ExecuteNonQuery();

                MySqlDataReader read = comand.ExecuteReader();
                //SE EXISTIR ELE ENTRA NO IF
                if (read.Read())
                {
                   // TBoxPerfilNRegisto.Text = read[0].ToString();
                    TextBox1.Text = read[1].ToString();
                    TextBox2.Text = read[3].ToString();
                    TextBox6.Text = read[4].ToString();
                }
                read.Close();
                con.Close();
                AllAvaliadores();
                AllEmpresas();
            }
        }
        void AllAvaliadores()
        {
            ListBox1.Items.Clear();

            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT * from tblavaliador";
            MySqlCommand comand = new MySqlCommand(N_Avaliador);

            comand.Connection = con;
            comand.ExecuteNonQuery();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id pagamento");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Email");
            dt.Columns.Add("Telemovel");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Data de expiração");
            MySqlDataReader read = comand.ExecuteReader();
            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                DataRow dr = dt.NewRow();
                ListBox1.Items.Add(read[7].ToString());

                if (read[6].ToString() == "0")
                {
                    dr["Id pagamento"] = read[9].ToString();
                    dr["Nome"] = read[1].ToString();
                    dr["Email"] = read[3].ToString();
                    dr["Telemovel"] = read[4].ToString();
                    dr["Estado"] = "Teste";
                    DateTime myDate = DateTime.Parse(read[8].ToString());
                    dr["Data de expiração"] = myDate.ToString("yyyy-MM-dd");
                    dt.Rows.Add(dr);
                }
                if (read[6].ToString() == "1")
                {
                    dr["Id pagamento"] = read[9].ToString();
                    dr["Nome"] = read[1].ToString();
                    dr["Email"] = read[3].ToString();
                    dr["Telemovel"] = read[4].ToString();
                    dr["Estado"] = "Ativo";
                    DateTime myDate = DateTime.Parse(read[8].ToString());
                    dr["Data de expiração"] = myDate.ToString("yyyy-MM-dd");
                    dt.Rows.Add(dr);
                }
                if (read[6].ToString() == "2")
                {
                    dr["Id pagamento"] = read[9].ToString();
                    dr["Nome"] = read[1].ToString();
                    dr["Email"] = read[3].ToString();
                    dr["Telemovel"] = read[4].ToString();
                    dr["Estado"] = "Cancelado";
                    DateTime myDate = DateTime.Parse(read[8].ToString());
                    dr["Data de expiração"] = myDate.ToString("yyyy-MM-dd");
                    dt.Rows.Add(dr);
                }
                if (read[6].ToString() == "3")
                {
                    dr["Id pagamento"] = read[9].ToString();
                    dr["Nome"] = read[1].ToString();
                    dr["Email"] = read[3].ToString();
                    dr["Telemovel"] = read[4].ToString();
                    dr["Estado"] = "Ativo";
                    DateTime myDate = DateTime.Parse(read[8].ToString());
                    dr["Data de expiração"] = myDate.ToString("yyyy-MM-dd");
                    dt.Rows.Add(dr);
                }
                if (read[6].ToString() != "1" && read[6].ToString() != "2" && read[6].ToString() != "3" && read[6].ToString() != "0")
                {
                    dr["Id pagamento"] = read[9].ToString();
                    dr["Nome"] = read[1].ToString();
                    dr["Email"] = read[3].ToString();
                    dr["Telemovel"] = read[4].ToString();
                    dr["Estado"] = "Ativo";
                    DateTime myDate = DateTime.Parse(read[8].ToString());
                    dr["Data de expiração"] = myDate.ToString("yyyy-MM-dd");
                    dt.Rows.Add(dr);
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        void AllEmpresas()
        {
            ListBox2.Items.Clear();

            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT * from tblempresa";
            MySqlCommand comand = new MySqlCommand(N_Avaliador);

            comand.Connection = con;
            comand.ExecuteNonQuery();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id pagamento");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Email");
            dt.Columns.Add("Telemovel");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Data de expiração");

            MySqlDataReader read = comand.ExecuteReader();
            //SE EXISTIR ELE ENTRA NO IF

            while (read.Read())
            {
                DataRow dr = dt.NewRow();
                ListBox2.Items.Add(read[7].ToString());

                if (read[6].ToString() == "0")
                {
                    dr["Id pagamento"] = read[9].ToString();
                    dr["Nome"] = read[1].ToString();
                    dr["Email"] = read[3].ToString();
                    dr["Telemovel"] = read[4].ToString();
                    dr["Estado"] = "Teste";
                    DateTime myDate = DateTime.Parse(read[8].ToString());
                    dr["Data de expiração"] = myDate.ToString("yyyy-MM-dd");
                    dt.Rows.Add(dr);
                }
                if (read[6].ToString() == "1")
                {
                    dr["Id pagamento"] = read[9].ToString();
                    dr["Nome"] = read[1].ToString();
                    dr["Email"] = read[3].ToString();
                    dr["Telemovel"] = read[4].ToString();
                    dr["Estado"] = "Ativo";
                    DateTime myDate = DateTime.Parse(read[8].ToString());
                    dr["Data de expiração"] = myDate.ToString("yyyy-MM-dd");
                    dt.Rows.Add(dr);
                }
                if (read[6].ToString() == "2")
                {
                    dr["Id pagamento"] = read[9].ToString();
                    dr["Nome"] = read[1].ToString();
                    dr["Email"] = read[3].ToString();
                    dr["Telemovel"] = read[4].ToString();
                    dr["Estado"] = "Cancelado";
                    DateTime myDate = DateTime.Parse(read[8].ToString());
                    dr["Data de expiração"] = myDate.ToString("yyyy-MM-dd");
                    dt.Rows.Add(dr);
                }
                if (read[6].ToString() == "3")
                {
                    dr["Id pagamento"] = read[9].ToString();
                    dr["Nome"] = read[1].ToString();
                    dr["Email"] = read[3].ToString();
                    dr["Telemovel"] = read[4].ToString();
                    dr["Estado"] = "Ativo";
                    DateTime myDate = DateTime.Parse(read[8].ToString());
                    dr["Data de expiração"] = myDate.ToString("yyyy-MM-dd");
                    dt.Rows.Add(dr);
                }
                if (read[6].ToString() != "1" && read[6].ToString() != "2" && read[6].ToString() != "3" && read[6].ToString() != "0")
                {
                    dr["Id pagamento"] = read[9].ToString();
                    dr["Nome"] = read[1].ToString();
                    dr["Email"] = read[3].ToString();
                    dr["Telemovel"] = read[4].ToString();
                    dr["Estado"] = "Diferente";
                    DateTime myDate = DateTime.Parse(read[8].ToString());
                    dr["Data de expiração"] = myDate.ToString("yyyy-MM-dd");
                    dt.Rows.Add(dr);
                }
            }
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DivRegistos.Visible = true;
            DivPerfil.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DivRegistos.Visible = false;
            DivPerfil.Visible = true;
        }

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

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "altertbladmin";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("varid", Session["idAvaliador"].ToString());
                cmd.Parameters.AddWithValue("varNome", TextBox1.Text);
                cmd.Parameters.AddWithValue("varEmail", TextBox2.Text);
                cmd.Parameters.AddWithValue("varTelemovel", TextBox6.Text);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Label1.Text = ex.Message;
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            divThankYou.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT Pass from tbladmin where id = @id";
            MySqlCommand comand = new MySqlCommand(N_Avaliador);
            comand.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();
            //SE EXISTIR ELE ENTRA NO IF
            if (read.Read())
            {
                if (Decrypt(read[0].ToString()) == TextBox3.Text)
                {
                    divNovaPass.Visible = true;
                    divThankYou.Visible = false;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password incorreta')", true);
                }
            }
            con.Close();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (TextBox4.Text == TextBox5.Text && TextBox4.Text != "")
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string N_Avaliador = "UPDATE tbladmin SET tbladmin.Pass = @pass WHERE tbladmin.id = @id; ";
                MySqlCommand comand = new MySqlCommand(N_Avaliador);
                comand.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
                comand.Parameters.AddWithValue("@pass", Encrypt(TextBox4.Text));
                comand.Connection = con;
                comand.ExecuteNonQuery();
                con.Close();
                divNovaPass.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password alterada com sucesso')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Passwords diferentes')", true);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            div1.Visible = true;

            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT Ativo, datadeexpiracao FROM tblavaliador WHERE id = @id";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Parameters.AddWithValue("@id", ListBox1.Items[GridView1.SelectedIndex].ToString());
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();


            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                DateTime myDate = DateTime.Parse(read[1].ToString());
                TextBox8.Text = myDate.ToString("yyyy-MM-dd");
            }


            con.Close();
            read.Close();

        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            div2.Visible = true;

            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT Ativo, datadeexpiracao FROM tblempresa WHERE id = @id";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Parameters.AddWithValue("@id", ListBox2.Items[GridView3.SelectedIndex].ToString());
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();


            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                DateTime myDate = DateTime.Parse(read[1].ToString());
                TextBox7.Text = myDate.ToString("yyyy-MM-dd");
            }


            con.Close();
            read.Close();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string N_Avaliador = "UPDATE tblavaliador SET datadeexpiracao = @data WHERE id = @id; ";
                MySqlCommand comand = new MySqlCommand(N_Avaliador);
                comand.Parameters.AddWithValue("@id", ListBox1.Items[GridView1.SelectedIndex].ToString());
                comand.Parameters.AddWithValue("@data", TextBox8.Text.Trim());
                comand.Connection = con;
                comand.ExecuteNonQuery();
                con.Close();
            div1.Visible = false;
            Response.Redirect("Admin");


        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            ListBox2.Items.Add(index2);
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "UPDATE tblempresa SET datadeexpiracao = @data WHERE id = @id; ";
            MySqlCommand comand = new MySqlCommand(N_Avaliador);
            comand.Parameters.AddWithValue("@id", ListBox2.Items[GridView3.SelectedIndex].ToString());
            comand.Parameters.AddWithValue("@data", TextBox7.Text.Trim());
            comand.Connection = con;
            comand.ExecuteNonQuery();
            con.Close();
            div2.Visible = false;
            Response.Redirect("Admin");
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select2")
            {
                div3.Visible = true;
                Label13.Text = Convert.ToString(e.CommandArgument);
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "DELETE FROM tblempresa WHERE id = @id";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Parameters.AddWithValue("@id", ListBox2.Items[Convert.ToInt16(Label13.Text)].ToString());
            comand.Connection = con;
            comand.ExecuteNonQuery();
            
            con.Close();
            div3.Visible = false;
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            div3.Visible = false;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select2")
            {
                div4.Visible = true;
                Label12.Text = Convert.ToString(e.CommandArgument);
            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "DELETE FROM tblavaliador WHERE id = @id";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Parameters.AddWithValue("@id", ListBox1.Items[Convert.ToInt16(Label12.Text)].ToString());
            comand.Connection = con;
            comand.ExecuteNonQuery();

            con.Close();
            div4.Visible = false;
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            div4.Visible = false;
        }
    }
}