using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Web.Services;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Avaliadores_Empresas
{
    public partial class Empresa : System.Web.UI.Page
    {
        int contadorerro = 0;
        string[] id;
        /*    string[] Nome2;
            string[] N_Registo;
            string[] Email;
            string[] Telemovel;
            string[] Morada;
            string[] Ativo;
            string[] idAvaliador;
            string[] idArea;
            string[] Nome;
            string[] Longitude;
            string[] Latitude;*/

        protected void Page_Load(object sender, EventArgs e)
        {
            // Saber se é Avaliador ?
            if (!IsPostBack)
            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                    // Codigo para registar
                    MySqlConnection con = new MySqlConnection(constr);
                    con.Open();
                    string N_Avaliador = "SELECT * from TblEmpresa where id = @id";
                    MySqlCommand comand = new MySqlCommand(N_Avaliador);
                    if (Session["Tipo"].ToString() == "2")
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
                        TBoxPerfilNRegisto.Text = read[0].ToString();
                        TBoxPerfilNome.Text = read[1].ToString();
                        TBoxPerfilEmail.Text = read[3].ToString();
                        TBoxPerfilTelefone.Text = read[4].ToString();

                        TBoxPerfilMorada.Text = read[5].ToString();

                        DateTime myDate = DateTime.Parse(read[8].ToString());
                        TextBox6.Text = myDate.ToString("yyyy-MM-dd");

                        if (read[6].ToString() == "1")
                        {
                            BtnPublicarPedidoAvaliacao.Visible = false;
                        }
                        if (read[6].ToString() == "2")
                        {
                            Label5.Text = "Cancelada";
                            TextBox5.Visible = false;
                            Label6.Visible = false;
                            BtnPesquisaAvaliacoes.Visible = false;
                            BtnPublicarPedidoAvaliacao.Visible = false;
                            BtnMinhasAvaliacoes.Visible = false;
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


                    DataTable dt = this.GetData("selectallAvaliadoresMorada");

                    id = new string[dt.Columns.Count];


                    DataRow drid = dt.Rows[0];


                    for (int i = 0; i < drid.ItemArray.Length; i++)
                    {
                        id[i] = drid[i].ToString();
                    }

                    rptMarkers.DataSource = dt;
                    rptMarkers.DataBind();

                    /*rptMarkers2.DataSource = dt;
                    rptMarkers2.DataBind();

                    rptMarkers3.DataSource = dt;
                    rptMarkers3.DataBind();*/
                }
                catch
                {
                    Response.Redirect("Login");
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
            cmd.CommandText = "alterestadotblempresa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("varAtivo", 2);
            cmd.Parameters.AddWithValue("varid", Session["idAvaliador"].ToString());
            cmd.Parameters.AddWithValue("vardata", TextBox6.Text.Trim());
            cmd.ExecuteNonQuery();
            con.Close();

            Label5.Text = "Cancelada";
            TextBox5.Visible = false;
            Label6.Visible = false;
            BtnPesquisaAvaliacoes.Visible = false;
            BtnPublicarPedidoAvaliacao.Visible = false;
            BtnMinhasAvaliacoes.Visible = false;

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


        private DataTable GetData(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            MySqlCommand cmd = new MySqlCommand(query);
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;

                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }



        protected void BtnPerfil_Click(object sender, EventArgs e)
        {
            InvisibleDiv();
            DivPerfil.Visible = true;
        }

        protected void BtnPesquisaAvaliacoes_Click(object sender, EventArgs e)
        {
            InvisibleDiv();
            DivPesquisaAvaliacoes.Visible = true;
        }

        protected void BtnPublicarPedidoAvaliacao_Click(object sender, EventArgs e)
        {
            InvisibleDiv();
            DivPublicarPedidoAvaliacao.Visible = true;
        }
        void InvisibleDiv()
        {
            DivMinhasAvaliacoes.Visible = false;
            DivPerfil.Visible = false;
            DivPesquisaAvaliacoes.Visible = false;
            DivPublicarPedidoAvaliacao.Visible = false;
            DivAvaliacoes.Visible = false;
            DivRanking.Visible = false;
            DivPublicarPedidoBtn1.Visible = false;
            DivPublicarPedidoBtn2.Visible = false;
            DivPublicarPedidoBtn3.Visible = false;
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
                cmd.CommandText = "altertblempresa";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("varN_Registo", TBoxPerfilNRegisto.Text.Trim());
                cmd.Parameters.AddWithValue("varNome", TBoxPerfilNome.Text.Trim());
                cmd.Parameters.AddWithValue("varEmail", TBoxPerfilEmail.Text.Trim());
                cmd.Parameters.AddWithValue("varTelefone", TBoxPerfilTelefone.Text.Trim());
                cmd.Parameters.AddWithValue("varMorada", TBoxPerfilMorada.Text.Trim());
                cmd.Parameters.AddWithValue("varid", Session["idAvaliador"].ToString());

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Label1.Text = ex.Message;
            }

        }


        protected void Button6_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Avaliacao1");
            bindddl(1);
            bindddl2(1);
            InvisibleDiv();
            DivPublicarPedidoBtn1.Visible = true;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Avaliacao2");
            bindddl(2);
            bindddl2(2);
            InvisibleDiv();
            DivPublicarPedidoBtn2.Visible = true;
        }

        protected void BtnMinhasAvaliacoes_Click(object sender, EventArgs e)
        {
            InvisibleDiv();
            DivMinhasAvaliacoes.Visible = true;
            int Avaliacaoid = 0;
            string Avaliacaotipo = "";
            string Avaliacaolocalizacao = "";
            string Avaliacaodeadline = "";
            string Avaliacaoempresa = "";
            string Avaliacaodenominacao = "";

            ListBox3.Items.Clear();
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * from tblavaliacao  where idEmpresa = @id";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
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
                    string NomeEmpresa = "SELECT Nome FROM tblempresa WHERE id = @id";
                    MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                    comand3.Parameters.AddWithValue("@id", read[4].ToString());
                    comand3.Connection = con3;
                    comand3.ExecuteNonQuery();

                    MySqlDataReader read3 = comand3.ExecuteReader();
                    while (read3.Read())
                    {
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
            GridView2.DataSource = dt;
            GridView2.DataBind();

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
            int Avaliacaoid = 0;
            string AvaliacaoDescricao = "";
            string Avaliacaodeadline = "";
            string Avaliacaoempresa = "";

            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * from tblpacotetotal where idEmpresa = @id";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
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
                    string NomeEmpresa = "SELECT Nome FROM tblempresa WHERE id = @id";
                    MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                    comand3.Parameters.AddWithValue("@id", read[3].ToString());
                    comand3.Connection = con3;
                    comand3.ExecuteNonQuery();

                    MySqlDataReader read3 = comand3.ExecuteReader();
                    while (read3.Read())
                    {
                        Avaliacaoempresa = read3[0].ToString();
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
            GridView3.DataSource = dt;
            GridView3.DataBind();


            con.Close();
            read.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT Pass from TblEmpresa where id = @id";
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
                string N_Avaliador = "UPDATE tblempresa SET tblempresa.Pass = @pass WHERE tblempresa.id = @id;";
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
            Response.Redirect("Login");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Avaliacao3");
            bindddl(3);
            bindddl2(3);
            InvisibleDiv();
            DivPublicarPedidoBtn3.Visible = true;
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
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
            comand.Parameters.AddWithValue("@id", ListBox2.Items[GridView3.SelectedIndex].ToString());
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
            GridView4.DataSource = dt;
            GridView4.DataBind();

            con.Close();
            read.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            div1.Visible = false;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment");
            /*string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "alterestadotblempresa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("varAtivo", 0);
            cmd.Parameters.AddWithValue("varid", Session["idAvaliador"].ToString());
            cmd.Parameters.AddWithValue("vardata", DateTime.Today.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();
            con.Close();

            Label5.Text = "Ativo";
            TextBox5.Visible = true;
            Label6.Visible = true;
            Response.Redirect("Empresa.aspx");*/
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
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * from tblavaliacao  where idEmpresa = @id";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
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
                    string NomeEmpresa = "SELECT Nome FROM tblempresa WHERE id = @id";
                    MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                    comand3.Parameters.AddWithValue("@id", read[4].ToString());
                    comand3.Connection = con3;
                    comand3.ExecuteNonQuery();

                    MySqlDataReader read3 = comand3.ExecuteReader();
                    while (read3.Read())
                    {
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
                    dr["Deadline"] = myDatedeadline.ToShortDateString(); dr["Empresa"] = Avaliacaoempresa;
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
            GridView2.DataSource = dt;
            GridView2.DataBind();

            con.Close();
            read.Close();

            fillgridview2();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            div2.Visible = false;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            div2.Visible = true;

            string Avaliacaotipo = "";
            string AvaliacaoPreco = "";

            ListBox5.Items.Clear();
            ListBox6.Items.Clear();

            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * from tblavaliadoresnumaavaliacao where idAvaliacao = @id";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Parameters.AddWithValue("@id", ListBox3.Items[GridView2.SelectedIndex].ToString());
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("Nome");
            dt.Columns.Add("Preço");

            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                ListBox6.Items.Add(read[0].ToString());

                MySqlConnection con2 = new MySqlConnection(constr);
                con2.Open();
                string NomeLocalizacao = "SELECT * from tblavaliador where id = @id";
                MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                comand2.Parameters.AddWithValue("@id", read[1].ToString());
                comand2.Connection = con2;
                comand2.ExecuteNonQuery();
                ListBox5.Items.Add(read[1].ToString());
                AvaliacaoPreco = read[3].ToString();
                MySqlDataReader read2 = comand2.ExecuteReader();
                while (read2.Read())
                {
                    Avaliacaotipo = read2[1].ToString();
                }
                read2.Close();
                con2.Close();

                DataRow dr = dt.NewRow();
                dr["Nome"] = Avaliacaotipo;
                dr["Preço"] = AvaliacaoPreco;
                dt.Rows.Add(dr);
            }
            GridView5.DataSource = dt;
            GridView5.DataBind();

            con.Close();
            read.Close();
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select2")
            {
                int indexs = Convert.ToInt32(e.CommandArgument);
                div3.Visible = true;

                string Avaliacaotipo = "";
                string AvaliacaoPreco = "";
                ListBox7.Items.Clear();
                // Saber se é Avaliador ?
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string AllAvaliacoes = "SELECT * from tblavaliadoresnumpacote where idAvaliacao = @id";
                MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
                ListBox7.Items.Add(Convert.ToString(indexs));
                comand.Parameters.AddWithValue("@id", ListBox2.Items[indexs].ToString());
                comand.Connection = con;
                comand.ExecuteNonQuery();

                MySqlDataReader read = comand.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add("Nome");
                dt.Columns.Add("Preço");

                //SE EXISTIR ELE ENTRA NO IF
                while (read.Read())
                {
                    ListBox4.Items.Add(read[0].ToString());
                    MySqlConnection con2 = new MySqlConnection(constr);
                    con2.Open();
                    string NomeLocalizacao = "SELECT * from tblavaliador where id = @id";
                    MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
                    comand2.Parameters.AddWithValue("@id", read[1].ToString());
                    ListBox1.Items.Add(read[1].ToString());
                    comand2.Connection = con2;
                    comand2.ExecuteNonQuery();
                    AvaliacaoPreco = read[3].ToString();
                    MySqlDataReader read2 = comand2.ExecuteReader();
                    while (read2.Read())
                    {
                        Avaliacaotipo = read2[1].ToString();
                    }
                    read2.Close();
                    con2.Close();

                    DataRow dr = dt.NewRow();
                    dr["Nome"] = Avaliacaotipo;
                    dr["Preço"] = AvaliacaoPreco;
                    dt.Rows.Add(dr);
                }
                GridView6.DataSource = dt;
                GridView6.DataBind();

                con.Close();
                read.Close();
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            div3.Visible = false;
        }

        protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Id do pacote
            // ListBox2.Items[index2].ToString();

            string teste = Session["idAvaliador"].ToString();

            div3.Visible = false;
            div4.Visible = true;
                   // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "UPDATE tblpacotetotal SET Contador = '0000-00-00 00:00:00', Estado = 1 WHERE id = @id";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Parameters.AddWithValue("@id", ListBox2.Items[Convert.ToInt16(ListBox7.Items[0].ToString())].ToString());
            comand.Connection = con;
            comand.ExecuteNonQuery();

            con.Close();



            MySqlConnection con3 = new MySqlConnection(constr);
            con3.Open();
            string NomeEmpresa = "UPDATE tblavaliadoresnumpacote SET Escolhido = 1 WHERE id = @id";
            MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
            comand3.Parameters.AddWithValue("@id", ListBox4.Items[Convert.ToInt16(ListBox7.Items[0].ToString())].ToString());
            comand3.Connection = con3;
            comand3.ExecuteNonQuery();
            con3.Close();


            MySqlConnection con2 = new MySqlConnection(constr);
            con2.Open();
            string NomeLocalizacao = "SELECT * from tblavaliador where id = @id";
            MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
            comand2.Parameters.AddWithValue("@id", ListBox1.Items[GridView6.SelectedIndex].ToString());
            comand2.Connection = con2;
            comand2.ExecuteNonQuery();
            DataTable dt = new DataTable();
            dt.Columns.Add("Nome");
            dt.Columns.Add("Email");
            dt.Columns.Add("Telemovel");

            MySqlDataReader read2 = comand2.ExecuteReader();
            while (read2.Read())
            {
                DataRow dr = dt.NewRow();
                dr["Nome"] = read2[1].ToString();
                dr["Email"] = read2[3].ToString();
                dr["Telemovel"] = read2[4].ToString();
                dt.Rows.Add(dr);
            }
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("geral@portaldoavaliador.com");
            mail.To.Add(read2[3].ToString());
            mail.Subject = "Venceu o concurso da avaliação";
            //Envia a password já decriptada
            // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
            LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
            LinkedImage.ContentId = "MyPic";
            //Added the patch for Thunderbird as suggested by Jorge
            LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
              "Olá " + read2[1].ToString() + ",<br><br>Venceu o concurso da avaliação " + GridView3.Rows[Convert.ToInt16(ListBox7.Items[0].ToString())].Cells[2].Text + "<br><br> Aceda aqui para recolheres os dados da " + GridView3.Rows[Convert.ToInt16(ListBox7.Items[0].ToString())].Cells[4].Text + " de forma a obter a informação que necessita para a avaliação<br>www.portaldoavaliador.com/Perfis?Emp=" + teste + "<br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
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
            GridView7.DataSource = dt;
            GridView7.DataBind();
            read2.Close();
            con2.Close();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            div4.Visible = false;
        }

        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Id do pacote
            // ListBox2.Items[index2].ToString();

            string teste = Session["idAvaliador"].ToString();

            div3.Visible = false;
            div4.Visible = true;
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "UPDATE tblavaliacao SET Contador = '0000-00-00 00:00:00', estado = 1 WHERE id = @id";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Parameters.AddWithValue("@id", ListBox3.Items[GridView2.SelectedIndex].ToString());
            comand.Connection = con;
            comand.ExecuteNonQuery();

            con.Close();



            MySqlConnection con3 = new MySqlConnection(constr);
            con3.Open();
            string NomeEmpresa = "UPDATE tblavaliadoresnumaavaliacao SET Escolhido = 1 WHERE id = @id";
            MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
            comand3.Parameters.AddWithValue("@id", ListBox6.Items[0].ToString());
            comand3.Connection = con3;
            comand3.ExecuteNonQuery();
            con3.Close();


            MySqlConnection con2 = new MySqlConnection(constr);
            con2.Open();
            string NomeLocalizacao = "SELECT * from tblavaliador where id = @id";
            MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
            comand2.Parameters.AddWithValue("@id", ListBox5.Items[0].ToString());
            comand2.Connection = con2;
            comand2.ExecuteNonQuery();
            DataTable dt = new DataTable();
            dt.Columns.Add("Nome");
            dt.Columns.Add("Email");
            dt.Columns.Add("Telemovel");

            MySqlDataReader read2 = comand2.ExecuteReader();
            while (read2.Read())
            {
                DataRow dr = dt.NewRow();
                dr["Nome"] = read2[1].ToString();
                dr["Email"] = read2[3].ToString();
                dr["Telemovel"] = read2[4].ToString();
                dt.Rows.Add(dr);
            }
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("geral@portaldoavaliador.com");
            mail.To.Add(read2[3].ToString());
            mail.Subject = "Venceu o concurso da avaliação";
            //Envia a password já decriptada
            // mail.Body = "Parabéns! <br>Obrigado pelo registo no Portal do Avaliador. <br>Pode aceder ao portal nos próximos 5 dias sem qualquer custo. <br>Basta aceder a www.portaldoavaliador.com e efetuar o login <br>Alguma questão não hesite em contactar,<br>";
            LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~/") + "salazar-01.ico");
            LinkedImage.ContentId = "MyPic";
            //Added the patch for Thunderbird as suggested by Jorge
            LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
              "Olá " + read2[1].ToString() + ",<br><br>Venceu o concurso da avaliação " + GridView2.Rows[GridView2.SelectedIndex].Cells[5].Text + "<br><br> Aceda aqui para recolheres os dados da " + GridView2.Rows[GridView2.SelectedIndex].Cells[4].Text + " de forma a obter a informação que necessita para a avaliação<br>www.portaldoavaliador.com/Perfis?Emp=" + teste + "<br><br>Alguma questão não hesite em contactar,<br><br><div>" + @"<div style=""display: inline-block;""> <img style=""width:65px;"" src='cid:" + LinkedImage.ContentId + @"'/></div><div style=""display: inline-block;"">Portal do avaliador <br> www.portaldoavaliador.com</div></div>",
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

            GridView7.DataSource = dt;
            GridView7.DataBind();
            read2.Close();
            con2.Close();
        }

        protected void BtnAvaliacoes_Click(object sender, EventArgs e)
        {
            btnavaliacoesvoid();
        }
        void btnavaliacoesvoid()
        {
            ListBox14.Items.Clear();
            ListBox11.Items.Clear();
            InvisibleDiv();
            DivAvaliacoes.Visible = true;
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblavaliacao WHERE estado = 1 AND estadoavaliacao = 1 AND JaavaliadoAval = 0 AND idEmpresa = @id";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
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
                            ListBox11.Items.Add(read5[1].ToString());

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
                            ListBox14.Items.Add(read[0].ToString());

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
                        read5.Close();
                        con5.Close();
                    }
                }
            }
            GridView8.DataSource = dt;
            GridView8.DataBind();

            con.Close();
            read.Close();
            BtnAvaliacoes2();
        }
        void BtnAvaliacoes2()
        {
            ListBox8.Items.Clear();
            ListBox13.Items.Clear();
            // Saber se é Avaliador ?
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string AllAvaliacoes = "SELECT * FROM tblpacotetotal WHERE 	Estado = 1 AND estadoavaliacao = 1 AND JaavaliadoAval = 0 AND idEmpresa = @id";
            MySqlCommand comand = new MySqlCommand(AllAvaliacoes);
            comand.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
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
                ListBox8.Items.Add(read[0].ToString());
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
                            ListBox13.Items.Add(read5[1].ToString());

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
                        read5.Close();
                        con5.Close();
                    }
                }
            }
            GridView9.DataSource = dt;
            GridView9.DataBind();

            con.Close();
            read.Close();
        }

        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select2")
            {
                int indexs = Convert.ToInt32(e.CommandArgument);
                ListBox8.Items[indexs].ToString();


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
                comand.Parameters.AddWithValue("@id", ListBox8.Items[indexs].ToString());
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
                GridView10.DataSource = dt;
                GridView10.DataBind();

                con.Close();
                read.Close();

            }
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            div5.Visible = false;
        }

        protected void GridView8_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox12.Items.Clear();
            div6.Visible = true;
            ListBox12.Items.Add("0");
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            div6.Visible = false;

            double rankings = 0;
            int NumeroRanks = 0;

            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            MySqlConnection con2 = new MySqlConnection(constr);
            con2.Open();
            string NomeLocalizacao = "SELECT * from tblavaliador where id = @id";
            MySqlCommand comand2 = new MySqlCommand(NomeLocalizacao);
            if (ListBox12.Items[0].ToString() == "0")
            {
                comand2.Parameters.AddWithValue("@id", ListBox11.Items[GridView8.SelectedIndex].ToString());
            }
            else
            {
                comand2.Parameters.AddWithValue("@id", ListBox13.Items[GridView9.SelectedIndex].ToString());
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
            cmd.CommandText = "alterrankingtblavaliador"; 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("varranking", rankings);
            if (ListBox12.Items[0].ToString() == "0")
            {
                cmd.Parameters.AddWithValue("varid", ListBox11.Items[GridView8.SelectedIndex].ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("varid", ListBox13.Items[GridView9.SelectedIndex].ToString());
            }
            cmd.ExecuteNonQuery();
            con.Close();


            if (ListBox12.Items[0].ToString() == "0")
            {
                MySqlConnection con3 = new MySqlConnection(constr);
                con3.Open();

                MySqlCommand cmd3 = con3.CreateCommand();
                cmd3.CommandText = "JaavaliadotblavaliacaoAval";
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("varid", ListBox14.Items[GridView8.SelectedIndex].ToString());
                cmd3.ExecuteNonQuery();
                con3.Close();
            }
            else
            {
                MySqlConnection con3 = new MySqlConnection(constr);
                con3.Open();

                MySqlCommand cmd3 = con3.CreateCommand();
                cmd3.CommandText = "JaavaliadotblpacotetotalAval";
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("varid", ListBox8.Items[GridView9.SelectedIndex].ToString());
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
            string NomeLocalizacao2 = "DELETE FROM tblavaliacao WHERE JaavaliadoEmp = 1 AND JaavaliadoAval = 1";
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

        protected void GridView9_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox12.Items.Clear();
            div6.Visible = true;
            ListBox12.Items.Add("1");
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
               ListBox9.Items.Add(Convert.ToString(Contador) + "º " + read[1].ToString());
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
                ListBox10.Items.Add(Convert.ToString(Contador) + "º " + read[1].ToString());
                Contador = Contador + 1;
            }

            con.Close();
            read.Close();
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            divThankYou.Visible = false;
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            div6.Visible = false;
        }

        //publicar pedido avaliação
        private void bindddl(int dropdown)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                MySqlDataAdapter adp = new MySqlDataAdapter("CALL `selectalltblareasatuacao`();", conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (dropdown == 1)
                    {
                        PPA1DropDownList1.DataSource = dt;
                        PPA1DropDownList1.DataTextField = "Nome";
                        PPA1DropDownList1.DataValueField = "id";
                        PPA1DropDownList1.DataBind();
                    }
                    if (dropdown == 2)
                    {
                        PPA2DropDownList1.DataSource = dt;
                        PPA2DropDownList1.DataTextField = "Nome";
                        PPA2DropDownList1.DataValueField = "id";
                        PPA2DropDownList1.DataBind();
                    }
                    if (dropdown == 3)
                    {
                        PPA3DropDownList1.DataSource = dt;
                        PPA3DropDownList1.DataTextField = "Nome";
                        PPA3DropDownList1.DataValueField = "id";
                        PPA3DropDownList1.DataBind();
                    }
                }
            }
        }

        private void bindddl2(int dropdown)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                MySqlDataAdapter adp = new MySqlDataAdapter("CALL `selectalltblimovel`();", conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (dropdown == 1)
                    {
                        PPA1DropDownList2.DataSource = dt;
                        PPA1DropDownList2.DataTextField = "Nome";
                        PPA1DropDownList2.DataValueField = "id";
                        PPA1DropDownList2.DataBind();
                    }
                    if (dropdown == 2)
                    {
                        PPA2DropDownList2.DataSource = dt;
                        PPA2DropDownList2.DataTextField = "Nome";
                        PPA2DropDownList2.DataValueField = "id";
                        PPA2DropDownList2.DataBind();
                    }
                    if (dropdown == 3)
                    {
                        PPA3DropDownList2.DataSource = dt;
                        PPA3DropDownList2.DataTextField = "Nome";
                        PPA3DropDownList2.DataValueField = "id";
                        PPA3DropDownList2.DataBind();
                    }
                }
            }
        }

        //publicar pedido avaliação 1
        protected void PPA1Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "insertavaliacao";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("vartipo", PPA1DropDownList2.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("varlocalizacao", PPA1DropDownList1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("vardeadline", PPA1TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("varidempresa", Session["idAvaliador"].ToString());
                cmd.Parameters.AddWithValue("vartextotipo", PPA1TextBox1.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Avaliação Criada com sucesso')", true);
                Response.Redirect("Empresa");
            }
            catch
            {
                Label5.Text = "Ocorreu um erro!";
            }
        }

        protected void PPA1Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empresa");
        }


        //publicar pedido avaliação 2
        int PPA2contadorerro = 0;

        protected void PPA2Button2_Click(object sender, EventArgs e)
        {
            string rollno;
            string sname;
            string fname;
            string Denominacao;
            OleDbConnection mycon;
            string path = Path.GetFileName(PPA2FileUpload1.FileName);
            path = path.Replace(" ", "");
            try
            {
                PPA2FileUpload1.SaveAs(Server.MapPath("~/ExcelFileEdited/") + path);
                PPA2Label7.Text = path;
                String ExcelPath = Server.MapPath("~/ExcelFileEdited/") + path;
                mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            }
            catch
            {
                PPA2FileUpload1.SaveAs(Server.MapPath("~/ExcelFileEdited/") + PPA2Label7.Text);
                String ExcelPath = Server.MapPath("~/ExcelFileEdited/") + PPA2Label7.Text;
                mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            }
            mycon.Open();
            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                rollno = dr[0].ToString();
                sname = dr[1].ToString();
                fname = dr[2].ToString();
                Denominacao = dr[3].ToString();
                Verificacao(rollno, sname, fname);
            }
            dr.Close();
            if (PPA2contadorerro == 0)
            {
                dr = cmd.ExecuteReader();
                DataTable dt2 = new DataTable();
                DataColumn[] columns = {
    new DataColumn("Tipo", System.Type.GetType("System.String")),
        new DataColumn("Localidade", System.Type.GetType("System.String")),
        new DataColumn("Deadline", System.Type.GetType("System.String")),
                new DataColumn("Denominação", System.Type.GetType("System.String"))
};
                dt2.Columns.AddRange(columns);
                DataRow dr2;
                while (dr.Read())
                {
                    rollno = dr[0].ToString();
                    sname = dr[1].ToString();
                    fname = dr[2].ToString();
                    Denominacao = dr[3].ToString();
                    string localidade = sname;
                    string Tipo = rollno;
                    dr2 = dt2.NewRow();
                    dr2[0] = Tipo;
                    dr2[1] = localidade;
                    DateTime enteredDate = DateTime.Parse(fname);
                    dr2[2] = enteredDate.ToString("yyyy-MM-dd");
                    dr2[3] = Denominacao;
                    dt2.Rows.Add(dr2);
                }
                PPA2GridView1.DataSource = dt2;
                PPA2GridView1.DataBind();
                PPA2Label1.Visible = true;
                PPA2Label1.Text = "Data Has Been Saved Successfully";
                dr.Close();
                PPA2Button3.Visible = true;
            }
            else
            {

            }
            mycon.Close();
            PPA2Button4.Visible = true;
            PPA2Button2.Visible = false;
            PPA2FileUpload1.Visible = false;
            PPA2Button5.Visible = true;
        }

        private void Verificacao(string rollno1, string sname1, string fname1)
        {
            string deadline = fname1;
            string localidade = sname1.First().ToString().ToUpper() + sname1.Substring(1);
            if (PPA2DropDownList1.Items.FindByText(sname1) != null)
            {
            }
            else
            {
                PPA2contadorerro = 1;
                PPA2Label1.Visible = true;
                PPA2Label1.Text = PPA2Label1.Text + ", " + sname1;
            }
            string Tipo = rollno1.First().ToString().ToUpper() + rollno1.Substring(1);
            if (PPA2DropDownList2.Items.FindByText(rollno1) != null)
            {
            }
            else
            {
                PPA2contadorerro = 1;
                PPA2Label1.Visible = true;
                PPA2Label1.Text = PPA2Label1.Text + ", " + rollno1;
            }
            try
            {
                DateTime dt = DateTime.Parse(fname1);
            }
            catch
            {
                PPA2contadorerro = 1;
                PPA2Label1.Text = "Um ou mais dados no campo Deadline não é uma data";
            }
        }

        protected void PPA2Button3_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Formulario.xlsx");
            Response.TransmitFile(Server.MapPath("~/ExcelFileOriginal/Formulario.xlsx"));
            Response.End();
        }

        protected void PPA2Button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PPA2GridView1.Rows.Count; i++)
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string idlocalizacao = "";
                string idTipo = "";

                for (int k = 0; k < PPA2DropDownList2.Items.Count; k++)
                {
                    string testao1 = HttpUtility.HtmlDecode(PPA2DropDownList2.Items[k].Text);
                    string testao2 = HttpUtility.HtmlDecode(PPA2GridView1.Rows[i].Cells[0].Text);
                    if (testao1 == testao2)
                    {
                        idTipo = PPA2DropDownList2.Items[k].Value;
                    }
                }

                for (int z = 0; z < PPA2DropDownList1.Items.Count; z++)
                {
                    string testao11 = HttpUtility.HtmlDecode(PPA2DropDownList1.Items[z].Text);
                    string testao22 = HttpUtility.HtmlDecode(PPA2GridView1.Rows[i].Cells[1].Text);

                    if (testao11 == testao22)
                    {
                        idlocalizacao = PPA2DropDownList1.Items[z].Value;
                    }
                }

                string Denominacao = HttpUtility.HtmlDecode(PPA2GridView1.Rows[i].Cells[3].Text);
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandText = "insertavaliacao";
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("vartipo", idTipo);
                cmd2.Parameters.AddWithValue("varlocalizacao", idlocalizacao);
                cmd2.Parameters.AddWithValue("vardeadline", PPA2GridView1.Rows[i].Cells[2].Text);
                cmd2.Parameters.AddWithValue("varidempresa", Session["idAvaliador"].ToString());
                cmd2.Parameters.AddWithValue("vartextotipo", Denominacao);
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Avaliações Criadas com sucesso')", true);
            Response.Redirect("Empresa");
        }

        protected void PPA2Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empresa");
        }


        //publicar pedido avaliação 3
        int PPA3contadorerro = 0;
        int Variavelidpacotetoal = 0;

        protected void PPA3Button2_Click(object sender, EventArgs e)
        {
            string rollno;
            string sname;
            OleDbConnection mycon;
            string path = Path.GetFileName(PPA3FileUpload1.FileName);
            path = path.Replace(" ", "");
            try
            {
                PPA3FileUpload1.SaveAs(Server.MapPath("~/ExcelFileEdited/") + path);
                PPA3Label7.Text = path;
                String ExcelPath = Server.MapPath("~/ExcelFileEdited/") + path;
                mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            }
            catch
            {
                PPA3FileUpload1.SaveAs(Server.MapPath("~/ExcelFileEdited/") + PPA3Label7.Text);
                String ExcelPath = Server.MapPath("~/ExcelFileEdited/") + PPA3Label7.Text;
                mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            }
            mycon.Open();
            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                rollno = dr[0].ToString();
                sname = dr[1].ToString();
                Verificacao(rollno, sname);
            }
            dr.Close();
            if (PPA3contadorerro == 0)
            {
                dr = cmd.ExecuteReader();
                DataTable dt2 = new DataTable();
                DataColumn[] columns = {
    new DataColumn("Localização", System.Type.GetType("System.String")),
        new DataColumn("Tipo", System.Type.GetType("System.String"))
};
                dt2.Columns.AddRange(columns);
                DataRow dr2;
                while (dr.Read())
                {
                    rollno = dr[0].ToString();
                    sname = dr[1].ToString();
                    string localidade = sname;
                    string Tipo = rollno;
                    dr2 = dt2.NewRow();
                    dr2[0] = Tipo;
                    dr2[1] = localidade;
                    dt2.Rows.Add(dr2);
                }
                PPA3GridView1.DataSource = dt2;
                PPA3GridView1.DataBind();
                dr.Close();
                PPA3Button3.Visible = true;
            }
            else
            {

            }
            mycon.Close();
            PPA3Button4.Visible = true;
            PPA3Button2.Visible = false;
            PPA3FileUpload1.Visible = false;
            PPA3Button5.Visible = true;
        }

        private void Verificacao(string rollno1, string sname)
        {
            string Tipo = rollno1.First().ToString().ToUpper() + rollno1.Substring(1);
            if (PPA3DropDownList2.Items.FindByText(rollno1) != null)
            {
            }
            else
            {
                PPA3contadorerro = 1;
                Label1.Visible = true;
                Label1.Text = Label1.Text + ", " + rollno1;
            }

            string Localizacao = sname.First().ToString().ToUpper() + sname.Substring(1);
            if (PPA3DropDownList1.Items.FindByText(sname) != null)
            {
            }
            else
            {
                PPA3contadorerro = 1;
                Label1.Visible = true;
                Label1.Text = Label1.Text + ", " + sname;
            }
        }

        protected void PPA3Button3_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Formulario2.xlsx");
            Response.TransmitFile(Server.MapPath("~/ExcelFileOriginal/Formulario2.xlsx"));
            Response.End();
        }

        protected void PPA3Button4_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandText = "insertpacotetotal";
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("vardescricao", PPA3TextBox1.Text);
            cmd2.Parameters.AddWithValue("vardeadline", PPA3TextBox2.Text);
            cmd2.Parameters.AddWithValue("varidempresa", Session["idAvaliador"].ToString());
            cmd2.ExecuteNonQuery();
            con.Close();

            FindIDpacotetotal();
            insertpacotesindividuais();
            /*  string idlocalizacao = "";
              string idTipo = "";

              for (int z = 0; z < PPA3DropDownList1.Items.Count; z++)
              {
                  string testao11 = HttpUtility.HtmlDecode(PPA3DropDownList1.Items[z].Text);
                  string testao22 = HttpUtility.HtmlDecode(PPA3GridView1.Rows[i].Cells[1].Text);

                  if (testao11 == testao22)
                  {
                      idlocalizacao = PPA3DropDownList1.Items[z].Value;
                  }
              }*/
            Response.Redirect("Empresa");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Avaliação Criada com sucesso')", true);
        }

        void FindIDpacotetotal()
        {
            string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            // Codigo para registar
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string N_Avaliador = "SELECT id FROM tblpacotetotal WHERE Descricao = @Descricao AND idEmpresa = @idEmpresa;";
            MySqlCommand comand = new MySqlCommand(N_Avaliador);
            if (Session["Tipo"].ToString() == "2")
            {
                try
                {
                    comand.Parameters.AddWithValue("@Descricao", PPA3TextBox1.Text);
                    comand.Parameters.AddWithValue("@idEmpresa", Session["idAvaliador"].ToString());
                }
                catch
                {
                    Response.Redirect("Login");
                }
            }
            comand.Connection = con;
            comand.ExecuteNonQuery();

            MySqlDataReader read = comand.ExecuteReader();
            //SE EXISTIR ELE ENTRA NO IF
            while (read.Read())
            {
                Variavelidpacotetoal = Convert.ToInt16(read[0].ToString());
            }
            con.Close();
        }

        void insertpacotesindividuais()
        {
            for (int i = 0; i < PPA3GridView1.Rows.Count; i++)
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string idlocalizacao = "";
                string idTipo = "";

                for (int k = 0; k < PPA3DropDownList2.Items.Count; k++)
                {
                    string testao1 = HttpUtility.HtmlDecode(PPA3DropDownList2.Items[k].Text);
                    string testao2 = HttpUtility.HtmlDecode(PPA3GridView1.Rows[i].Cells[0].Text);
                    if (testao1 == testao2)
                    {
                        idTipo = PPA3DropDownList2.Items[k].Value;
                    }
                }

                for (int z = 0; z < PPA3DropDownList1.Items.Count; z++)
                {
                    string testao11 = HttpUtility.HtmlDecode(PPA3DropDownList1.Items[z].Text);
                    string testao22 = HttpUtility.HtmlDecode(PPA3GridView1.Rows[i].Cells[1].Text);

                    if (testao11 == testao22)
                    {
                        idlocalizacao = PPA3DropDownList1.Items[z].Value;
                    }
                }
                string denominacao = HttpUtility.HtmlDecode(PPA3GridView1.Rows[i].Cells[1].Text);
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandText = "insertpacoteindividual";
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("varidTipo", idTipo);
                cmd2.Parameters.AddWithValue("varlocalizacao", idlocalizacao);
                cmd2.Parameters.AddWithValue("varidpacotetotal", Variavelidpacotetoal);
                cmd2.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void PPA3Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empresa");
        }

        protected void PPA3Button5_Click(object sender, EventArgs e)
        {

        }
    }
}

