using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    public partial class Avaliador : System.Web.UI.Page
    {
        string intestadoaval = "";
        string intestadopacote = "";

        string denominacaoemail;
        string denominacaoemailpacote;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Saber se é Avaliador ?
                    string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                    // Codigo para registar
                    MySqlConnection con = new MySqlConnection(constr);
                    con.Open();
                    string N_Avaliador = "SELECT * from tblavaliador where id = @id";
                    MySqlCommand comand = new MySqlCommand(N_Avaliador);
                    if (Session["Tipo"].ToString() == "1")
                    {
                        try
                        {
                            comand.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
                        }
                        catch
                        {
                            Response.Redirect("Login.aspx");
                        }
                    }
                    comand.Connection = con;
                    comand.ExecuteNonQuery();

                    MySqlDataReader read = comand.ExecuteReader();
                    //SE EXISTIR ELE ENTRA NO IF
                    if (read.Read())
                    {
                        TxtPerfilNRegisto.Text = read[0].ToString();
                        TxtPerfilNome.Text = read[1].ToString();
                        TxtPerfilEmail.Text = read[3].ToString();
                        TxtPerfilTelemovel.Text = read[4].ToString();
                        TxtPerfilMorada.Text = read[5].ToString();
                        DateTime myDate = DateTime.Parse(read[8].ToString());
                        TextBox6.Text = myDate.ToString("yyyy-MM-dd");

                        if (read[6].ToString() == "2")
                        {
                            Label5.Text = "Cancelada";
                            TextBox5.Visible = false;
                            Label6.Visible = false;
                            BtnTrabalhosRealizados.Visible = false;
                            BtnAvaliacoesDisponiveis.Visible = false;
                            BtnAvaliacoes.Visible = false;
                            BtnRanking.Visible = false;
                        }

                        TextBox5.Text = myDate.ToString("yyyy-MM-dd");
                        if ((myDate - DateTime.Now).TotalDays > 0)
                        {
                            if (read[6].ToString() == "0")
                            {
                                Label5.Text = "Ativo";
                            }
                            if (read[6].ToString() == "1")
                            {
                                Label5.Text = "Demo";
                            }
                            if (read[6].ToString() == "2")
                            {
                                Label5.Text = "Cancelada";
                                TextBox5.Visible = false;
                                Label6.Visible = false;
                            }
                            if (read[6].ToString() == "3")
                            {
                                Label5.Text = "Ativo";
                            }
                        }
                        else
                        {
                            Inativo();
                        }
                    }

                    con.Close();
                    read.Close();
                    bindddl();
                    binLbox();
                }
                catch
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        void Inativo()
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "alterestadotblavaliador";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("varAtivo", 2);
            cmd.Parameters.AddWithValue("varid", Session["idAvaliador"].ToString());
            cmd.Parameters.AddWithValue("vardata", TextBox6.Text.Trim());
            cmd.ExecuteNonQuery();
            con.Close();

            Label5.Text = "Cancelada";
            TextBox5.Visible = false;
            Label6.Visible = false;
            BtnTrabalhosRealizados.Visible = false;
            BtnAvaliacoesDisponiveis.Visible = false;
            BtnAvaliacoes.Visible = false;
            BtnRanking.Visible = false;
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

        protected void BtnPerfil_Click(object sender, EventArgs e)
        {
            InvisibleDiv();
            DivPerfil.Visible = true;
        }

        protected void BtnAvaliacoesDisponiveis_Click(object sender, EventArgs e)
        {
            InvisibleDiv();
            DivAvaliacoesDisponiveis.Visible = true;
            int Avaliacaoid = 0;
            string Avaliacaotipo = "";
            string Avaliacaolocalizacao = "";
            string Avaliacaodeadline = "";
            string Avaliacaoempresa = "";
            string Avaliacaodenominacao = "";
            ListBox3.Items.Clear();
            ListBox4.Items.Clear();

            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * from tblavaliacao";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Localizacao");
            dt.Columns.Add("Deadline");
            dt.Columns.Add("Empresa");
            dt.Columns.Add("Denominação");
            dt.Columns.Add("Contador");


            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                if (read[5].ToString() == "0")
                {
                    Avaliacaoid = Convert.ToInt16(read[0].ToString());
                    Avaliacaotipo = read[1].ToString();
                    //Avaliacaolocalizacao = Convert.ToInt16(read[2].ToString());
                    Avaliacaodeadline = read[3].ToString();
                    Avaliacaodenominacao = read[6].ToString();

                    ListBox3.Items.Add(read[0].ToString());
                    //Avaliacaoempresa = Convert.ToInt16(read[4].ToString());
                    MySqlConnection con2 = new MySqlConnection(constr);
                    con2.Open();
                    string NomeLocalizacao = "SELECT * from tblareasatuacao where id = @id";
                    MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                    comand2.Parameters.AddWithValue("@id", read[2].ToString());
                    comand2.Connection = con2;
                    comand2.ExecuteNonQuery();

                    MySqlDataReader read2 = comand2.ExecuteReader();
                    while (read2.Read())
                    {
                        Avaliacaolocalizacao = read2[1].ToString();
                    }
                    read2.Close();
                    con2.Close();

                    MySqlConnection con3 = new MySqlConnection(constr);
                    con3.Open();
                    string NomeEmpresa = "SELECT Nome, Email FROM tblempresa WHERE id = @id";
                    MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                    comand3.Parameters.AddWithValue("@id", read[4].ToString());
                    comand3.Connection = con3;
                    comand3.ExecuteNonQuery();

                    MySqlDataReader read3 = comand3.ExecuteReader();
                    while (read3.Read())
                    {
                        ListBox4.Items.Add(read3[1].ToString());
                        Avaliacaoempresa = read3[0].ToString();
                    }
                    read3.Close();
                    con3.Close();


                    MySqlConnection con4 = new MySqlConnection(constr);
                    con4.Open();
                    string Tipo = "SELECT Nome FROM tblimovel WHERE id = @id";
                    MySqlCommand comand4 = new MySqlCommand(Tipo);
                    comand4.Parameters.AddWithValue("@id", Avaliacaotipo);
                    comand4.Connection = con4;
                    comand4.ExecuteNonQuery();

                    MySqlDataReader read4 = comand4.ExecuteReader();
                    while (read4.Read())
                    {
                        Avaliacaotipo = read4[0].ToString();
                    }
                    read4.Close();
                    con4.Close();

                    DataRow dr = dt.NewRow();
                    dr["Tipo"] = Avaliacaotipo;
                    dr["Localizacao"] = Avaliacaolocalizacao;
                    DateTime myDatedeadline = DateTime.Parse(Avaliacaodeadline);
                    dr["Deadline"] = myDatedeadline.ToShortDateString();
                    dr["Empresa"] = Avaliacaoempresa;
                    dr["Denominação"] = Avaliacaodenominacao;
                    if (read[8].ToString() != "1")
                    {
                        dr["Contador"] = "";
                    }
                    if (read[8].ToString() == "1")
                    {
                        DateTime myDate = DateTime.Parse(read[7].ToString());
                        double doublehours = (myDate - DateTime.Now).TotalMinutes;
                        /*doublehours = System.Math.Round(doublehours, 2);
                        string stringhours = Convert.ToString(doublehours);
                        stringhours = stringhours.Replace(@",", @":");*/

                        doublehours = System.Math.Round(doublehours, 0);
                        doublehours = doublehours % 1440;

                        double Hour = doublehours / 60;
                        double Minute = doublehours % 60;
                        dr["Contador"] = FormatTwoDigits(Hour) + ":" + FormatTwoDigits(Minute) + "";




                        // dr["Contador"] = stringhours;
                    }
                    dt.Rows.Add(dr);

                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

            con.Close();
            read.Close();

            fillgridview2();
        }

        private string FormatTwoDigits(double i)
        {
            string functionReturnValue = null;
            i = System.Math.Floor(i);

            if (10 > i)
            {
                functionReturnValue = "0" + i.ToString();
            }
            else
            {
                functionReturnValue = i.ToString();
            }
            return functionReturnValue;
        }

        void fillgridview2()
        {
            ListBox2.Items.Clear();
            ListBox5.Items.Clear();
            int Avaliacaoid = 0;
            string AvaliacaoDescricao = "";
            string Avaliacaodeadline = "";
            string Avaliacaoempresa = "";

            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * from tblpacotetotal";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("Descrição");
            dt.Columns.Add("Deadline");
            dt.Columns.Add("Empresa");
            dt.Columns.Add("Contador");


            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
                {
                if (read[4].ToString() == "0")
                {
                    ListBox2.Items.Add(read[0].ToString());
                    Avaliacaoid = Convert.ToInt16(read[0].ToString());
                    AvaliacaoDescricao = read[1].ToString();
                    //Avaliacaolocalizacao = Convert.ToInt16(read[2].ToString());
                    Avaliacaodeadline = read[2].ToString();
                    //Avaliacaoempresa = Convert.ToInt16(read[4].ToString());

                    MySqlConnection con3 = new MySqlConnection(constr);
                    con3.Open();
                    string NomeEmpresa = "SELECT Nome, Email FROM tblempresa WHERE id = @id";
                    MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                    comand3.Parameters.AddWithValue("@id", read[3].ToString());
                    comand3.Connection = con3;
                    comand3.ExecuteNonQuery();

                    MySqlDataReader read3 = comand3.ExecuteReader();
                    while (read3.Read())
                    {
                        Avaliacaoempresa = read3[0].ToString();
                        ListBox5.Items.Add(read3[1].ToString());
                    }
                    read3.Close();
                    con3.Close();

                    DataRow dr = dt.NewRow();
                    dr["Descrição"] = AvaliacaoDescricao;
                    DateTime myDatedeadline = DateTime.Parse(Avaliacaodeadline);
                    dr["Deadline"] = myDatedeadline.ToShortDateString();
                    dr["Empresa"] = Avaliacaoempresa;
                    if (read[6].ToString() != "1")
                    {
                        dr["Contador"] = "";
                    }
                    if (read[6].ToString() == "1")
                    {
                        DateTime myDate = DateTime.Parse(read[5].ToString());
                        double doublehours = (myDate - DateTime.Now).TotalMinutes;
                        /*doublehours = System.Math.Round(doublehours, 2);
                        string stringhours = Convert.ToString(doublehours);
                        stringhours = stringhours.Replace(@",", @":");*/

                        doublehours = System.Math.Round(doublehours, 0);
                        doublehours = doublehours % 1440;

                        double Hour = doublehours / 60;
                        double Minute = doublehours % 60;
                        dr["Contador"] = FormatTwoDigits(Hour) + ":" + FormatTwoDigits(Minute) + "";




                        // dr["Contador"] = stringhours;
                    }
                    dt.Rows.Add(dr);

                }
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();


            con.Close();
            read.Close();

        }

        protected void BtnTrabalhosRealizados_Click(object sender, EventArgs e)
        {
            InvisibleDiv();
            DivTrabalhosRealizados.Visible = true;
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblavaliacao WHERE estado = 0 AND estadoavaliacao = 1";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Denominação");
            dt.Columns.Add("Localização");
            dt.Columns.Add("Deadline");
            dt.Columns.Add("Empresa");


            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {

                DateTime myDate = DateTime.Parse(read[3].ToString());
                if ((myDate - DateTime.Now).TotalDays >= 0)
                {                  
                        MySqlConnection con5 = new MySqlConnection(constr);
                        con5.Open();
                        string String5 = "SELECT * FROM tblavaliadoresnumaavaliacao WHERE idAvaliacao = @id";
                        MySqlCommand comand5 = new MySqlCommand(String5);
                        comand5.Parameters.AddWithValue("@id", read[0].ToString());
                        comand5.Connection = con5;
                        comand5.ExecuteNonQuery();

                        MySqlDataReader read5 = comand5.ExecuteReader();
                        while (read5.Read())
                        {
                            if (Session["idAvaliador"].ToString() == read5[1].ToString())
                            {
                                //Avaliacaoempresa = Convert.ToInt16(read[4].ToString());
                                MySqlConnection con2 = new MySqlConnection(constr);
                                con2.Open();
                                string NomeLocalizacao = "SELECT * from tblimovel where id = @id";
                                MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                                comand2.Parameters.AddWithValue("@id", read[1].ToString());
                                comand2.Connection = con2;
                                comand2.ExecuteNonQuery();

                                MySqlDataReader read2 = comand2.ExecuteReader();
                                while (read2.Read())
                                {
                                }


                                MySqlConnection con3 = new MySqlConnection(constr);
                                con3.Open();
                                string NomeEmpresa = "SELECT * FROM tblareasatuacao WHERE id = @id";
                                MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                                comand3.Parameters.AddWithValue("@id", read[2].ToString());
                                comand3.Connection = con3;
                                comand3.ExecuteNonQuery();

                                MySqlDataReader read3 = comand3.ExecuteReader();
                                while (read3.Read())
                                {
                                }


                                MySqlConnection con4 = new MySqlConnection(constr);
                                con4.Open();
                                string Tipo = "SELECT * FROM tblempresa WHERE id = @id";
                                MySqlCommand comand4 = new MySqlCommand(Tipo);
                                comand4.Parameters.AddWithValue("@id", read[4].ToString());
                                comand4.Connection = con4;
                                comand4.ExecuteNonQuery();

                                MySqlDataReader read4 = comand4.ExecuteReader();
                                while (read4.Read())
                                {
                                }

                                DataRow dr = dt.NewRow();
                                dr["Tipo"] = read2[1].ToString();
                                dr["Denominação"] = read[6].ToString();
                                dr["Localização"] = read3[1].ToString();
                                dr["Deadline"] = myDate.ToShortDateString();
                                dr["Empresa"] = read4[1].ToString();
                                dt.Rows.Add(dr);

                                read2.Close();
                                con2.Close();

                                read3.Close();
                                con3.Close();

                                read4.Close();
                                con4.Close();
                            }
                        }
                        read5.Close();
                        con5.Close();                    
                }
            }
            GridView7.DataSource = dt;
            GridView7.DataBind();

            con.Close();
            read.Close();
            BtnAvaliacoes3();
        }

        void BtnAvaliacoes3()
        {
            ListBox7.Items.Clear();
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblpacotetotal WHERE 	Estado = 0 AND estadoavaliacao = 1";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("Descrição");
            dt.Columns.Add("Deadline");
            dt.Columns.Add("Empresa");


            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                DateTime myDate = DateTime.Parse(read[2].ToString());
                if ((myDate - DateTime.Now).TotalDays >= 0)
                {
                        MySqlConnection con5 = new MySqlConnection(constr);
                        con5.Open();
                        string String5 = "SELECT * FROM tblavaliadoresnumpacote WHERE idAvaliacao = @id";
                        MySqlCommand comand5 = new MySqlCommand(String5);
                        comand5.Parameters.AddWithValue("@id", read[0].ToString());
                        comand5.Connection = con5;
                        comand5.ExecuteNonQuery();

                        MySqlDataReader read5 = comand5.ExecuteReader();
                        while (read5.Read())
                        {
                            if (Session["idAvaliador"].ToString() == read5[1].ToString())
                            {
                                /*   //Avaliacaoempresa = Convert.ToInt16(read[4].ToString());
                                   MySqlConnection con2 = new MySqlConnection(constr);
                                   con2.Open();
                                   string NomeLocalizacao = "SELECT * from tblimovel where id = @id";
                                   MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                                   comand2.Parameters.AddWithValue("@id", read[1].ToString());
                                   comand2.Connection = con2;
                                   comand2.ExecuteNonQuery();

                                   MySqlDataReader read2 = comand2.ExecuteReader();
                                   while (read2.Read())
                                   {
                                   }*/


                                /*  MySqlConnection con3 = new MySqlConnection(constr);
                                  con3.Open();
                                  string NomeEmpresa = "SELECT * FROM tblareasatuacao WHERE id = @id";
                                  MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                                  comand3.Parameters.AddWithValue("@id", read[2].ToString());
                                  comand3.Connection = con3;
                                  comand3.ExecuteNonQuery();

                                  MySqlDataReader read3 = comand3.ExecuteReader();
                                  while (read3.Read())
                                  {
                                  }*/


                                MySqlConnection con4 = new MySqlConnection(constr);
                                con4.Open();
                                string Tipo = "SELECT * FROM tblempresa WHERE id = @id";
                                MySqlCommand comand4 = new MySqlCommand(Tipo);
                                comand4.Parameters.AddWithValue("@id", read[3].ToString());
                                comand4.Connection = con4;
                                comand4.ExecuteNonQuery();

                                MySqlDataReader read4 = comand4.ExecuteReader();
                                while (read4.Read())
                                {
                                }
                            ListBox7.Items.Add(read[0].ToString());

                            DataRow dr = dt.NewRow();
                                dr["Descrição"] = read[1].ToString();
                                dr["Deadline"] = myDate.ToShortDateString();
                                dr["Empresa"] = read4[1].ToString();
                                dt.Rows.Add(dr);

                                /*  read2.Close();
                                  con2.Close();

                                  read3.Close();
                                  con3.Close();*/

                                read4.Close();
                                con4.Close();
                            }
                        }
                        read5.Close();
                        con5.Close();
                }
            }
            GridView8.DataSource = dt;
            GridView8.DataBind();

            con.Close();
            read.Close();
        }

        void InvisibleDiv()
        {
            DivPerfil.Visible = false;
            DivAvaliacoesDisponiveis.Visible = false;
            DivTrabalhosRealizados.Visible = false;
            DivLicenca.Visible = false;
            DivAvaliacoes.Visible = false;
            DivRanking.Visible = false;
        }
        private void bindddl()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                MySqlDataAdapter adp = new MySqlDataAdapter("CALL `selectalltblareasatuacao`();", conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dpPerfilArea.DataSource = dt;
                    dpPerfilArea.DataTextField = "Nome";
                    dpPerfilArea.DataValueField = "id";
                    dpPerfilArea.DataBind();
                }
            }
        }
        private void binLbox()
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "selectnometblavaliadorareas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("varidAvaliador", Session["idAvaliador"].ToString());
            cmd.ExecuteNonQuery();

            MySqlDataReader read = cmd.ExecuteReader();
            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                LBoxPerfilArea.Items.Add(new ListItem(read[4].ToString(), read[3].ToString()));
                //limpar();
            }
            con.Close();

        }

        protected void BtnPerfilDropdown_Click(object sender, EventArgs e)
        {
            try
            {
                if (LBoxPerfilArea.Items.FindByValue(dpPerfilArea.SelectedValue.ToString()).Value == "")
                {

                }
            }
            catch
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();

                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandText = "insertavaliadorareas";
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("varidAvaliador", Convert.ToInt16(Session["idAvaliador"].ToString()));
                cmd2.Parameters.AddWithValue("varidArea", Convert.ToInt16(dpPerfilArea.SelectedValue.ToString()));

                cmd2.ExecuteNonQuery();
                con.Close();
                LBoxPerfilArea.Items.Clear();
                binLbox();
            }
        }

        protected void BtnPerfilConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "altertblavaliador";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("varN_Registo", TxtPerfilNRegisto.Text.Trim());
                cmd.Parameters.AddWithValue("varNome", TxtPerfilNome.Text.Trim());
                cmd.Parameters.AddWithValue("varEmail", TxtPerfilEmail.Text.Trim());
                cmd.Parameters.AddWithValue("varTelemovel", TxtPerfilTelemovel.Text.Trim());
                cmd.Parameters.AddWithValue("varMorada", TxtPerfilMorada.Text.Trim());
                cmd.Parameters.AddWithValue("varid", Session["idAvaliador"].ToString());
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Label1.Text = ex.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (LBoxPerfilArea.SelectedIndex != -1)
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string N_Avaliador = "DELETE FROM tblavaliadorareas WHERE idAvaliador = @idAvaliador AND idArea = @idarea; ";
                MySqlCommand comand = new MySqlCommand(N_Avaliador);
                comand.Parameters.AddWithValue("@idAvaliador", Session["idAvaliador"].ToString());
                comand.Parameters.AddWithValue("@idarea", LBoxPerfilArea.SelectedValue.ToString());
                comand.Connection = con;
                comand.ExecuteNonQuery();
                LBoxPerfilArea.Items.Clear();
                con.Close();
                binLbox();
            }

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT Pass from tblavaliador where id = @id";
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == TextBox4.Text && TextBox2.Text != "")
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string N_Avaliador = "UPDATE tblavaliador SET tblavaliador.Pass = @pass WHERE tblavaliador.id = @id; ";
                MySqlCommand comand = new MySqlCommand(N_Avaliador);
                comand.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
                comand.Parameters.AddWithValue("@pass", Encrypt(TextBox2.Text));
                comand.Connection = con;
                comand.ExecuteNonQuery();
                con.Close();
                divNovaPass.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password alterada com sucesso')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password incorreta')", true);
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            divThankYou.Visible = true;
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            div1.Visible = true;

            string Avaliacaotipo = "";
            string Avaliacaolocalizacao = "";
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string AllAvaliacoes = "SELECT * from tblpacoteindividual where idpacotetotal = @id";
                MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
                comand.Parameters.AddWithValue("@id", ListBox2.Items[GridView2.SelectedIndex].ToString());
                comand.Connection = con;
                comand.ExecuteNonQuery();

                MySqlDataReader read = comand.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add("Tipo");
                dt.Columns.Add("Localização");

                //SE EXISTIR ELE ENTRA NO IF
                while (read.Read())
                {
                    MySqlConnection con2 = new MySqlConnection(constr);
                    con2.Open();
                    string NomeLocalizacao = "SELECT * from tblimovel where id = @id";
                    MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                    comand2.Parameters.AddWithValue("@id", read[1].ToString());
                    comand2.Connection = con2;
                    comand2.ExecuteNonQuery();

                    MySqlDataReader read2 = comand2.ExecuteReader();
                    while (read2.Read())
                    {
                        Avaliacaotipo = read2[1].ToString();
                    }
                    read2.Close();
                    con2.Close();


                MySqlConnection con4 = new MySqlConnection(constr);
                con4.Open();
                string Localizacao = "SELECT * from tblareasatuacao where id = @id";
                MySqlCommand comand4 = new MySqlCommand(Localizacao);
                comand4.Parameters.AddWithValue("@id", read[3].ToString());
                comand4.Connection = con4;
                comand4.ExecuteNonQuery();

                MySqlDataReader read4 = comand4.ExecuteReader();
                while (read4.Read())
                {
                    Avaliacaolocalizacao = read4[1].ToString();
                }
                read4.Close();
                con4.Close();


                DataRow dr = dt.NewRow();
                dr["Tipo"] = Avaliacaotipo;
                dr["Localização"] = Avaliacaolocalizacao;
                dt.Rows.Add(dr);
            }
                GridView3.DataSource = dt;
                GridView3.DataBind();

                con.Close();
                read.Close();

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            div1.Visible = false;
        }

        protected void BtnLicenca_Click(object sender, EventArgs e)
        {
            InvisibleDiv();
            DivLicenca.Visible = true;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Session["PagarTipo"] = "0";

            Response.Redirect("PaginaTestePaypal.aspx");

            /*string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "alterestadotblavaliador";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("varAtivo", 0);
            cmd.Parameters.AddWithValue("varid", Session["idAvaliador"].ToString());
            cmd.Parameters.AddWithValue("vardata", DateTime.Today.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();
            con.Close();

            Label5.Text = "Ativo";
            TextBox5.Visible = true;
            Label6.Visible = true;
            Response.Redirect("Avaliador.aspx");*/
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (jaconcorreu() == 0)
            {
                div2.Visible = true;
            }
        }

        private int jaconcorreu()
        {
            int jacorreu;
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT * FROM tblavaliadoresnumaavaliacao WHERE idAvaliador = @idavaliador AND idAvaliacao = @idavaliacao";
            MySqlCommand comand = new MySqlCommand(N_Avaliador);
            comand.Parameters.AddWithValue("@idavaliador", Session["idAvaliador"].ToString());
            comand.Parameters.AddWithValue("@idavaliacao", ListBox3.Items[GridView1.SelectedIndex].ToString());
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();
            //SE EXISTIR ELE ENTRA NO IF
            if (read.Read())
            {
                jacorreu = 1;
            }
            else
            {
                jacorreu = 0;
            }

            con.Close();
            read.Close();
            return jacorreu;
        }

        void verificarprimeiroconcorrer()
        {
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT * from tblavaliacao where id = @id";
            MySqlCommand comand = new MySqlCommand(N_Avaliador);
            comand.Parameters.AddWithValue("@id", ListBox3.Items[GridView1.SelectedIndex].ToString());
             
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();
            //SE EXISTIR ELE ENTRA NO IF
            if (read.Read())
            {
                intestadoaval = read[8].ToString();               
            }

            con.Close();
            read.Close();
        }

        void primeiroconcorrer()
        {



            DateTime myDate = DateTime.Now;
            myDate = myDate.AddHours(24);


            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "concorrerprimeiroavaliador";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("varestadoavaliacao", 1);
            cmd.Parameters.AddWithValue("varcontador", myDate.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("varid", ListBox3.Items[GridView1.SelectedIndex].ToString());

            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void Timer1_Tick1(object sender, EventArgs e)
        {
            int Avaliacaoid = 0;
            string Avaliacaotipo = "";
            string Avaliacaolocalizacao = "";
            string Avaliacaodeadline = "";
            string Avaliacaoempresa = "";
            string Avaliacaodenominacao = "";
            ListBox3.Items.Clear();
            ListBox4.Items.Clear();

            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * from tblavaliacao";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Localizacao");
            dt.Columns.Add("Deadline");
            dt.Columns.Add("Empresa");
            dt.Columns.Add("Denominação");
            dt.Columns.Add("Contador");


            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                if (read[5].ToString() == "0")
                {
                    Avaliacaoid = Convert.ToInt16(read[0].ToString());
                    Avaliacaotipo = read[1].ToString();
                    //Avaliacaolocalizacao = Convert.ToInt16(read[2].ToString());
                    Avaliacaodeadline = read[3].ToString();
                    Avaliacaodenominacao = read[6].ToString();

                    ListBox3.Items.Add(read[0].ToString());
                    //Avaliacaoempresa = Convert.ToInt16(read[4].ToString());
                    MySqlConnection con2 = new MySqlConnection(constr);
                    con2.Open();
                    string NomeLocalizacao = "SELECT * from tblareasatuacao where id = @id";
                    MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                    comand2.Parameters.AddWithValue("@id", read[2].ToString());
                    comand2.Connection = con2;
                    comand2.ExecuteNonQuery();

                    MySqlDataReader read2 = comand2.ExecuteReader();
                    while (read2.Read())
                    {
                        Avaliacaolocalizacao = read2[1].ToString();
                    }
                    read2.Close();
                    con2.Close();

                    MySqlConnection con3 = new MySqlConnection(constr);
                    con3.Open();
                    string NomeEmpresa = "SELECT Nome, Email FROM tblempresa WHERE id = @id";
                    MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                    comand3.Parameters.AddWithValue("@id", read[4].ToString());
                    comand3.Connection = con3;
                    comand3.ExecuteNonQuery();

                    MySqlDataReader read3 = comand3.ExecuteReader();
                    while (read3.Read())
                    {
                        ListBox4.Items.Add(read3[1].ToString());
                        Avaliacaoempresa = read3[0].ToString();
                    }
                    read3.Close();
                    con3.Close();


                    MySqlConnection con4 = new MySqlConnection(constr);
                    con4.Open();
                    string Tipo = "SELECT Nome FROM tblimovel WHERE id = @id";
                    MySqlCommand comand4 = new MySqlCommand(Tipo);
                    comand4.Parameters.AddWithValue("@id", Avaliacaotipo);
                    comand4.Connection = con4;
                    comand4.ExecuteNonQuery();

                    MySqlDataReader read4 = comand4.ExecuteReader();
                    while (read4.Read())
                    {
                        Avaliacaotipo = read4[0].ToString();
                    }
                    read4.Close();
                    con4.Close();

                    DataRow dr = dt.NewRow();
                    dr["Tipo"] = Avaliacaotipo;
                    dr["Localizacao"] = Avaliacaolocalizacao;
                    DateTime myDatedeadline = DateTime.Parse(Avaliacaodeadline);
                    dr["Deadline"] = myDatedeadline.ToShortDateString();
                    dr["Empresa"] = Avaliacaoempresa;
                    dr["Denominação"] = Avaliacaodenominacao;
                    if (read[8].ToString() != "1")
                    {
                        dr["Contador"] = "";
                    }
                    if (read[8].ToString() == "1")
                    {
                        DateTime myDate = DateTime.Parse(read[7].ToString());
                        double doublehours = (myDate - DateTime.Now).TotalMinutes;
                        /*doublehours = System.Math.Round(doublehours, 2);
                        string stringhours = Convert.ToString(doublehours);
                        stringhours = stringhours.Replace(@",", @":");*/

                        doublehours = System.Math.Round(doublehours, 0);
                        doublehours = doublehours % 1440;

                        double Hour = doublehours / 60;
                        double Minute = doublehours % 60;
                        dr["Contador"] = FormatTwoDigits(Hour) + ":" + FormatTwoDigits(Minute) + "";




                        // dr["Contador"] = stringhours;
                    }
                    dt.Rows.Add(dr);

                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

            con.Close();
            read.Close();

            fillgridview2();
        }
        
        protected void Button7_Click(object sender, EventArgs e)
        {
            div2.Visible = false;

                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "insertavaliadoresnumaavaliacao";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("varidavaliacao", ListBox3.Items[GridView1.SelectedIndex].ToString());
                cmd.Parameters.AddWithValue("varidAvaliador", Session["idAvaliador"].ToString());
                cmd.Parameters.AddWithValue("varpreco", TextBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                verificarprimeiroconcorrer();
                if (intestadoaval != "1")
                {
                    primeiroconcorrer();
                }


            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("geral@portaldoavaliador.com");
            mail.To.Add(ListBox4.Items[GridView1.SelectedIndex].ToString());
            mail.Subject = "Avaliação com proposta";
            //Envia a password já decriptada
            // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
            LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
            LinkedImage.ContentId = "MyPic";
            //Added the patch for Thunderbird as suggested by Jorge
            LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
              "Olá " + Empresanome() + ",<br><br>A avaliação " + denominacaoemail + " têm um avaliador interessado.<br><br> Aceda aqui para verificar www.portaldoavaliador.com/Empresa.aspx <br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
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

        string Empresanome()
        {
            string Avaliacaoempresa;
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT * from tblavaliacao where id = @id";
            MySqlCommand comand = new MySqlCommand(N_Avaliador);
            comand.Parameters.AddWithValue("@id", ListBox3.Items[GridView1.SelectedIndex].ToString());

            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();
            //SE EXISTIR ELE ENTRA NO IF
            if (read.Read())
            {
                denominacaoemail = read[6].ToString();
            }


            MySqlConnection con3 = new MySqlConnection(constr);
            con3.Open();
            string NomeEmpresa = "SELECT Nome FROM tblempresa WHERE id = @id";
            MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
            comand3.Parameters.AddWithValue("@id", read[4].ToString());
            comand3.Connection = con3;
            comand3.ExecuteNonQuery();

            MySqlDataReader read3 = comand3.ExecuteReader();
            if (read3.Read())
            {
                Avaliacaoempresa = read3[0].ToString();
            }
            else
            {
                Avaliacaoempresa = "Error";
            }
            read3.Close();
            con3.Close();

            con.Close();
            read.Close();
            return Avaliacaoempresa;
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select2")
            {
                ListBox1.Items.Clear();
                int indexs = Convert.ToInt32(e.CommandArgument);
                if (jaconcorreu2(indexs) == 0)
                {
                    div3.Visible = true;
                    ListBox1.Items.Add(Convert.ToString(indexs));
                }
            }
        }

        private int jaconcorreu2(int indexs)
        {
            int jacorreu;
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT * FROM tblavaliadoresnumpacote WHERE idAvaliador = @idavaliador AND idAvaliacao = @idavaliacao";
            MySqlCommand comand = new MySqlCommand(N_Avaliador);
            comand.Parameters.AddWithValue("@idavaliador", Session["idAvaliador"].ToString());
            comand.Parameters.AddWithValue("@idavaliacao", ListBox2.Items[indexs].ToString());
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();
            //SE EXISTIR ELE ENTRA NO IF
            if (read.Read())
            {
                jacorreu = 1;
            }
            else
            {
                jacorreu = 0;
            }

            con.Close();
            read.Close();
            return jacorreu;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            div3.Visible = false;

            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "insertavaliadoresnumpacote";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("varidavaliacao", ListBox2.Items[Convert.ToInt16(ListBox1.Items[0].ToString())].ToString());
            cmd.Parameters.AddWithValue("varidAvaliador", Session["idAvaliador"].ToString());
            cmd.Parameters.AddWithValue("varPreco", TextBox7.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            verificarprimeiroconcorrer2();
            if (intestadopacote != "1")
            {
                primeiroconcorrer2();
            }

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("geral@portaldoavaliador.com");
            mail.To.Add(ListBox5.Items[Convert.ToInt16(ListBox1.Items[0].ToString())].ToString());
            mail.Subject = "Pacote de Avaliação com proposta";
            //Envia a password já decriptada
            // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
            LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
            LinkedImage.ContentId = "MyPic";
            //Added the patch for Thunderbird as suggested by Jorge
            LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
              "Olá " + Empresanome2() + ",<br><br>O pacote de avaliações " + denominacaoemailpacote + " têm um avaliador interessado.<br><br> Aceda aqui para verificar www.portaldoavaliador.com/Empresa.aspx <br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
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

        void verificarprimeiroconcorrer2()
        {
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT * from tblpacotetotal where id = @id";
            MySqlCommand comand = new MySqlCommand(N_Avaliador);
            comand.Parameters.AddWithValue("@id", ListBox2.Items[Convert.ToInt16(ListBox1.Items[0].ToString())].ToString());

            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();
            //SE EXISTIR ELE ENTRA NO IF
            if (read.Read())
            {
                intestadopacote = read[6].ToString();
            }

            con.Close();
            read.Close();
        }
        void primeiroconcorrer2()
        {
            DateTime myDate = DateTime.Now;
            myDate = myDate.AddHours(24);


            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "concorrerprimeiroavaliadorpacote";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("varestadoavaliacao", 1);
            cmd.Parameters.AddWithValue("varcontador", myDate.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("varid", ListBox2.Items[Convert.ToInt16(ListBox1.Items[0].ToString())].ToString());

            cmd.ExecuteNonQuery();
            con.Close();
        }

        string Empresanome2()
        {
            string Avaliacaoempresa;
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT * from tblpacotetotal where id = @id";
            MySqlCommand comand = new MySqlCommand(N_Avaliador);
            comand.Parameters.AddWithValue("@id", ListBox2.Items[Convert.ToInt16(ListBox1.Items[0].ToString())].ToString());

            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();
            //SE EXISTIR ELE ENTRA NO IF
            if (read.Read())
            {
                denominacaoemailpacote = read[1].ToString();
            }


            MySqlConnection con3 = new MySqlConnection(constr);
            con3.Open();
            string NomeEmpresa = "SELECT Nome FROM tblempresa WHERE id = @id";
            MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
            comand3.Parameters.AddWithValue("@id", read[3].ToString());
            comand3.Connection = con3;
            comand3.ExecuteNonQuery();

            MySqlDataReader read3 = comand3.ExecuteReader();
            if (read3.Read())
            {
                Avaliacaoempresa = read3[0].ToString();
            }
            else
            {
                Avaliacaoempresa = "Error";
            }
            read3.Close();
            con3.Close();

            con.Close();
            read.Close();
            return Avaliacaoempresa;
        }

        protected void BtnAvaliacoes_Click(object sender, EventArgs e)
        {
            btnavaliacoesvoid();
        }
        void btnavaliacoesvoid()
        {
            ListBox13.Items.Clear();
            ListBox10.Items.Clear();
            InvisibleDiv();
            DivAvaliacoes.Visible = true;
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblavaliacao WHERE estado = 1 AND JaavaliadoEmp = 0 AND estadoavaliacao = 1";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Denominação");
            dt.Columns.Add("Localização");
            dt.Columns.Add("Deadline");
            dt.Columns.Add("Empresa");


            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {

                DateTime myDate = DateTime.Parse(read[3].ToString());
                if ((myDate - DateTime.Now).TotalDays <= 0)
                {
                    myDate = myDate.AddDays(4);
                    if ((myDate - DateTime.Now).TotalDays >= 0)
                    {
                        MySqlConnection con5 = new MySqlConnection(constr);
                        con5.Open();
                        string String5 = "SELECT * FROM tblavaliadoresnumaavaliacao WHERE Escolhido = 1 AND idAvaliacao = @id";
                        MySqlCommand comand5 = new MySqlCommand(String5);
                        comand5.Parameters.AddWithValue("@id", read[0].ToString());
                        comand5.Connection = con5;
                        comand5.ExecuteNonQuery();

                        MySqlDataReader read5 = comand5.ExecuteReader();
                        while (read5.Read())
                        {
                            if (Session["idAvaliador"].ToString() == read5[1].ToString())
                            {
                                //Avaliacaoempresa = Convert.ToInt16(read[4].ToString());
                                MySqlConnection con2 = new MySqlConnection(constr);
                                con2.Open();
                                string NomeLocalizacao = "SELECT * from tblimovel where id = @id";
                                MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                                comand2.Parameters.AddWithValue("@id", read[1].ToString());
                                comand2.Connection = con2;
                                comand2.ExecuteNonQuery();

                                MySqlDataReader read2 = comand2.ExecuteReader();
                                while (read2.Read())
                                {
                                }


                                MySqlConnection con3 = new MySqlConnection(constr);
                                con3.Open();
                                string NomeEmpresa = "SELECT * FROM tblareasatuacao WHERE id = @id";
                                MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                                comand3.Parameters.AddWithValue("@id", read[2].ToString());
                                comand3.Connection = con3;
                                comand3.ExecuteNonQuery();

                                MySqlDataReader read3 = comand3.ExecuteReader();
                                while (read3.Read())
                                {
                                }


                                MySqlConnection con4 = new MySqlConnection(constr);
                                con4.Open();
                                string Tipo = "SELECT * FROM tblempresa WHERE id = @id";
                                MySqlCommand comand4 = new MySqlCommand(Tipo);
                                comand4.Parameters.AddWithValue("@id", read[4].ToString());
                                comand4.Connection = con4;
                                comand4.ExecuteNonQuery();

                                MySqlDataReader read4 = comand4.ExecuteReader();
                                while (read4.Read())
                                {
                                }
                                ListBox10.Items.Add(read[4].ToString());
                                ListBox13.Items.Add(read[0].ToString());

                                DataRow dr = dt.NewRow();
                                dr["Tipo"] = read2[1].ToString();
                                dr["Denominação"] = read[6].ToString();
                                dr["Localização"] = read3[1].ToString();
                                dr["Deadline"] = myDate.ToShortDateString();
                                dr["Empresa"] = read4[1].ToString();
                                dt.Rows.Add(dr);

                                read2.Close();
                                con2.Close();

                                read3.Close();
                                con3.Close();

                                read4.Close();
                                con4.Close();
                            }
                        }
                        read5.Close();
                        con5.Close();
                    }
                }
            }
            GridView4.DataSource = dt;
            GridView4.DataBind();

            con.Close();
            read.Close();
            BtnAvaliacoes2();
        }
        void BtnAvaliacoes2()
        {
            ListBox6.Items.Clear();
            ListBox12.Items.Clear();
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblpacotetotal WHERE 	Estado = 1 AND JaavaliadoEmp = 0 AND estadoavaliacao = 1";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("Descrição");
            dt.Columns.Add("Deadline");
            dt.Columns.Add("Empresa");


            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                DateTime myDate = DateTime.Parse(read[2].ToString());
                if ((myDate - DateTime.Now).TotalDays <= 0)
                {
                    myDate = myDate.AddDays(4);
                    if ((myDate - DateTime.Now).TotalDays >= 0)
                    {
                        MySqlConnection con5 = new MySqlConnection(constr);
                        con5.Open();
                        string String5 = "SELECT * FROM tblavaliadoresnumpacote WHERE Escolhido = 1 AND idAvaliacao = @id";
                        MySqlCommand comand5 = new MySqlCommand(String5);
                        comand5.Parameters.AddWithValue("@id", read[0].ToString());
                        comand5.Connection = con5;
                        comand5.ExecuteNonQuery();

                        MySqlDataReader read5 = comand5.ExecuteReader();
                        while (read5.Read())
                        {
                            if (Session["idAvaliador"].ToString() == read5[1].ToString())
                            {
                                /*   //Avaliacaoempresa = Convert.ToInt16(read[4].ToString());
                                   MySqlConnection con2 = new MySqlConnection(constr);
                                   con2.Open();
                                   string NomeLocalizacao = "SELECT * from tblimovel where id = @id";
                                   MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                                   comand2.Parameters.AddWithValue("@id", read[1].ToString());
                                   comand2.Connection = con2;
                                   comand2.ExecuteNonQuery();

                                   MySqlDataReader read2 = comand2.ExecuteReader();
                                   while (read2.Read())
                                   {
                                   }*/


                                /*  MySqlConnection con3 = new MySqlConnection(constr);
                                  con3.Open();
                                  string NomeEmpresa = "SELECT * FROM tblareasatuacao WHERE id = @id";
                                  MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                                  comand3.Parameters.AddWithValue("@id", read[2].ToString());
                                  comand3.Connection = con3;
                                  comand3.ExecuteNonQuery();

                                  MySqlDataReader read3 = comand3.ExecuteReader();
                                  while (read3.Read())
                                  {
                                  }*/

                                ListBox6.Items.Add(read[0].ToString());

                                MySqlConnection con4 = new MySqlConnection(constr);
                                con4.Open();
                                string Tipo = "SELECT * FROM tblempresa WHERE id = @id";
                                MySqlCommand comand4 = new MySqlCommand(Tipo);
                                comand4.Parameters.AddWithValue("@id", read[3].ToString());
                                comand4.Connection = con4;
                                comand4.ExecuteNonQuery();
                                ListBox12.Items.Add(read[3].ToString());
                                MySqlDataReader read4 = comand4.ExecuteReader();
                                while (read4.Read())
                                {
                                }

                                DataRow dr = dt.NewRow();
                                dr["Descrição"] = read[1].ToString();
                                dr["Deadline"] = myDate.ToShortDateString();
                                dr["Empresa"] = read4[1].ToString();
                                dt.Rows.Add(dr);

                              /*  read2.Close();
                                con2.Close();

                                read3.Close();
                                con3.Close();*/

                                read4.Close();
                                con4.Close();
                            }
                        }
                        read5.Close();
                        con5.Close();
                    }
                }
            }
            GridView5.DataSource = dt;
            GridView5.DataBind();

            con.Close();
            read.Close();
        }

        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select2")
            {
                int indexs = Convert.ToInt32(e.CommandArgument);
                ListBox6.Items[indexs].ToString();


                div4.Visible = true;

                string Avaliacaotipo = "";
                string Avaliacaolocalizacao = "";
                // Saber se é Avaliador ?
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string AllAvaliacoes = "SELECT * from tblpacoteindividual where idpacotetotal = @id";
                MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
                comand.Parameters.AddWithValue("@id", ListBox6.Items[indexs].ToString());
                comand.Connection = con;
                comand.ExecuteNonQuery();

                MySqlDataReader read = comand.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add("Tipo");
                dt.Columns.Add("Localização");

                //SE EXISTIR ELE ENTRA NO IF
                while (read.Read())
                {
                    MySqlConnection con2 = new MySqlConnection(constr);
                    con2.Open();
                    string NomeLocalizacao = "SELECT * from tblimovel where id = @id";
                    MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                    comand2.Parameters.AddWithValue("@id", read[1].ToString());
                    comand2.Connection = con2;
                    comand2.ExecuteNonQuery();

                    MySqlDataReader read2 = comand2.ExecuteReader();
                    while (read2.Read())
                    {
                        Avaliacaotipo = read2[1].ToString();
                    }
                    read2.Close();
                    con2.Close();


                    MySqlConnection con4 = new MySqlConnection(constr);
                    con4.Open();
                    string Localizacao = "SELECT * from tblareasatuacao where id = @id";
                    MySqlCommand comand4 = new MySqlCommand(Localizacao);
                    comand4.Parameters.AddWithValue("@id", read[3].ToString());
                    comand4.Connection = con4;
                    comand4.ExecuteNonQuery();

                    MySqlDataReader read4 = comand4.ExecuteReader();
                    while (read4.Read())
                    {
                        Avaliacaolocalizacao = read4[1].ToString();
                    }
                    read4.Close();
                    con4.Close();


                    DataRow dr = dt.NewRow();
                    dr["Tipo"] = Avaliacaotipo;
                    dr["Localização"] = Avaliacaolocalizacao;
                    dt.Rows.Add(dr);
                }
                GridView6.DataSource = dt;
                GridView6.DataBind();

                con.Close();
                read.Close();

            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            div4.Visible = false;
        }

        protected void GridView8_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select2")
            {
                int indexs = Convert.ToInt32(e.CommandArgument);
                ListBox7.Items[indexs].ToString();


                div5.Visible = true;

                string Avaliacaotipo = "";
                string Avaliacaolocalizacao = "";
                // Saber se é Avaliador ?
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string AllAvaliacoes = "SELECT * from tblpacoteindividual where idpacotetotal = @id";
                MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
                comand.Parameters.AddWithValue("@id", ListBox7.Items[indexs].ToString());
                comand.Connection = con;
                comand.ExecuteNonQuery();

                MySqlDataReader read = comand.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add("Tipo");
                dt.Columns.Add("Localização");

                //SE EXISTIR ELE ENTRA NO IF
                while (read.Read())
                {
                    MySqlConnection con2 = new MySqlConnection(constr);
                    con2.Open();
                    string NomeLocalizacao = "SELECT * from tblimovel where id = @id";
                    MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                    comand2.Parameters.AddWithValue("@id", read[1].ToString());
                    comand2.Connection = con2;
                    comand2.ExecuteNonQuery();

                    MySqlDataReader read2 = comand2.ExecuteReader();
                    while (read2.Read())
                    {
                        Avaliacaotipo = read2[1].ToString();
                    }
                    read2.Close();
                    con2.Close();


                    MySqlConnection con4 = new MySqlConnection(constr);
                    con4.Open();
                    string Localizacao = "SELECT * from tblareasatuacao where id = @id";
                    MySqlCommand comand4 = new MySqlCommand(Localizacao);
                    comand4.Parameters.AddWithValue("@id", read[3].ToString());
                    comand4.Connection = con4;
                    comand4.ExecuteNonQuery();

                    MySqlDataReader read4 = comand4.ExecuteReader();
                    while (read4.Read())
                    {
                        Avaliacaolocalizacao = read4[1].ToString();
                    }
                    read4.Close();
                    con4.Close();


                    DataRow dr = dt.NewRow();
                    dr["Tipo"] = Avaliacaotipo;
                    dr["Localização"] = Avaliacaolocalizacao;
                    dt.Rows.Add(dr);
                }
                GridView9.DataSource = dt;
                GridView9.DataBind();

                con.Close();
                read.Close();

            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            div5.Visible = false;
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox11.Items.Clear();
            div6.Visible = true;
            ListBox11.Items.Add("0");
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            div6.Visible = false;

            double rankings = 0;
            int NumeroRanks = 0;

            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            MySqlConnection con2 = new MySqlConnection(constr);
            con2.Open();
            string NomeLocalizacao = "SELECT * from tblempresa where id = @id";
            MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
            if (ListBox11.Items[0].ToString() == "0")
            {
                comand2.Parameters.AddWithValue("@id", ListBox10.Items[GridView4.SelectedIndex].ToString());
            }
            else
            {
                comand2.Parameters.AddWithValue("@id", ListBox12.Items[GridView5.SelectedIndex].ToString());
            }
            comand2.Connection = con2;
            comand2.ExecuteNonQuery();

            MySqlDataReader read2 = comand2.ExecuteReader();
            while (read2.Read())
            {
                rankings = Convert.ToDouble(read2[10].ToString());
                NumeroRanks = Convert.ToInt16(read2[11].ToString());
            }
            read2.Close();
            con2.Close();

            rankings = rankings * NumeroRanks;

            double Rating1dbl = Convert.ToDouble(Rating1.CurrentRating.ToString());
            double Rating2dbl = Convert.ToDouble(Rating2.CurrentRating.ToString());
            double Rating3dbl = Convert.ToDouble(Rating3.CurrentRating.ToString());
            double Rating4dbl = Convert.ToDouble(Rating4.CurrentRating.ToString());
            Rating1dbl = Rating1dbl + Rating2dbl + Rating3dbl + Rating4dbl;
            Rating1dbl = Rating1dbl / 4;

            rankings = rankings + Rating1dbl;

            NumeroRanks = NumeroRanks + 1;

            rankings = rankings / NumeroRanks;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "alterrankingtblempresa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("varranking", rankings);
            if(ListBox11.Items[0].ToString() == "0")
            {
                cmd.Parameters.AddWithValue("varid", ListBox10.Items[GridView4.SelectedIndex].ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("varid", ListBox12.Items[GridView5.SelectedIndex].ToString());
            }


            cmd.ExecuteNonQuery();
            con.Close();

            if (ListBox11.Items[0].ToString() == "0")
            {
            MySqlConnection con3 = new MySqlConnection(constr);
            con3.Open();

            MySqlCommand cmd3 = con3.CreateCommand();
            cmd3.CommandText = "Jaavaliadotblavaliacao";
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.AddWithValue("varid", ListBox13.Items[GridView4.SelectedIndex].ToString());
            cmd3.ExecuteNonQuery();
            con3.Close();
            }
            else
            {
                MySqlConnection con3 = new MySqlConnection(constr);
                con3.Open();

                MySqlCommand cmd3 = con3.CreateCommand();
                cmd3.CommandText = "Jaavaliadotblpacotetotal";
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("varid", ListBox6.Items[GridView5.SelectedIndex].ToString());
                cmd3.ExecuteNonQuery();
                con3.Close();
            }
            eliminar();
            btnavaliacoesvoid();
        }
        void eliminar()
        {
            eliminartblavaliadoresnumaavaliacao();
            eliminarConstraintsPacote();

            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            MySqlConnection con2 = new MySqlConnection(constr);
            con2.Open();
            string NomeLocalizacao = "DELETE FROM tblavaliacao WHERE JaavaliadoEmp = 1 AND JaavaliadoAval = 1";
            MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
            comand2.Connection = con2;
            comand2.ExecuteNonQuery();
            con2.Close();


            MySqlConnection con3 = new MySqlConnection(constr);
            con3.Open();
            string NomeLocalizacao2 = "DELETE FROM tblpacotetotal WHERE JaavaliadoEmp = 1 AND JaavaliadoAval = 1";
            MySqlCommand comand3 = new MySqlCommand(NomeLocalizacao2);
            comand3.Connection = con3;
            comand3.ExecuteNonQuery();
            con3.Close();
        }

        void eliminartblavaliadoresnumaavaliacao()
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblavaliacao WHERE JaavaliadoEmp = 1 AND JaavaliadoAval = 1";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();

            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                MySqlConnection con3 = new MySqlConnection(constr);
                con3.Open();
                string NomeLocalizacao2 = "DELETE FROM tblavaliadoresnumaavaliacao WHERE idAvaliacao = @id";
                MySqlCommand comand3 = new MySqlCommand(NomeLocalizacao2);
                comand3.Parameters.AddWithValue("@id", read[0].ToString());
                comand3.Connection = con3;
                comand3.ExecuteNonQuery();
                con3.Close();
            }
            con.Close();
            read.Close();
        }

        void eliminarConstraintsPacote()
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblpacotetotal WHERE JaavaliadoEmp = 1 AND JaavaliadoAval = 1";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();

            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                MySqlConnection con3 = new MySqlConnection(constr);
                con3.Open();
                string NomeLocalizacao2 = "DELETE FROM tblavaliadoresnumpacote WHERE idAvaliacao = @id";
                MySqlCommand comand3 = new MySqlCommand(NomeLocalizacao2);
                comand3.Parameters.AddWithValue("@id", read[0].ToString());
                comand3.Connection = con3;
                comand3.ExecuteNonQuery();
                con3.Close();

                MySqlConnection con4 = new MySqlConnection(constr);
                con4.Open();
                string NomeLocalizacao3 = "DELETE FROM tblpacoteindividual WHERE idpacotetotal = @id";
                MySqlCommand comand4 = new MySqlCommand(NomeLocalizacao3);
                comand4.Parameters.AddWithValue("@id", read[0].ToString());
                comand4.Connection = con4;
                comand4.ExecuteNonQuery();
                con4.Close();
            }
            con.Close();
            read.Close();
        }

        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox11.Items.Clear();
            div6.Visible = true;
            ListBox11.Items.Add("1");
        }

        protected void BtnRanking_Click(object sender, EventArgs e)
        {
            InvisibleDiv();
            DivRanking.Visible = true;
            int Contador = 1;
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblempresa ORDER BY ranking DESC";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();

            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                ListBox8.Items.Add(Convert.ToString(Contador) + "º " + read[1].ToString());
                Contador = Contador + 1;
            }
            con.Close();
            read.Close();
            RankingAval();
        }
        void RankingAval()
        {
            int Contador = 1;
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblavaliador ORDER BY ranking DESC";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();

            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                ListBox9.Items.Add(Convert.ToString(Contador) + "º " + read[1].ToString());
                Contador = Contador + 1;
            }

            con.Close();
            read.Close();
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            divThankYou.Visible = false;
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            div6.Visible = false;
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            div2.Visible = false;
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            div3.Visible = false;
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            Session["PagarTipo"] = "1";

            Response.Redirect("PaginaTestePaypal.aspx");

            /*string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "alterestadotblavaliador";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("varAtivo", 3);
            cmd.Parameters.AddWithValue("varid", Session["idAvaliador"].ToString());
            cmd.Parameters.AddWithValue("vardata", DateTime.Today.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();
            con.Close();

            Label5.Text = "Ativo";
            TextBox5.Visible = true;
            Label6.Visible = true;
            Response.Redirect("Avaliador.aspx");*/
        }
    }
}