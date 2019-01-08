using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avaliadores_Empresas
{
    public partial class PublicarPedidoAvaliacao3 : System.Web.UI.Page
    {
        int contadorerro = 0;
        int Variavelidpacotetoal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                    Response.Redirect("Login");
                }
                comand.Connection = con;
                comand.ExecuteNonQuery();
                bindddl();
                bindddl2();
            }
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
                    PPA3DropDownList1.DataSource = dt;
                    PPA3DropDownList1.DataTextField = "Nome";
                    PPA3DropDownList1.DataValueField = "id";
                    PPA3DropDownList1.DataBind();
                }
            }
        }
        private void bindddl2()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                MySqlDataAdapter adp = new MySqlDataAdapter("CALL `selectalltblimovel`();", conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    PPA3DropDownList2.DataSource = dt;
                    PPA3DropDownList2.DataTextField = "Nome";
                    PPA3DropDownList2.DataValueField = "id";
                    PPA3DropDownList2.DataBind();
                }
            }
        }
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
            if (contadorerro == 0)
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
                contadorerro = 1;
                Label1.Visible = true;
                Label1.Text = Label1.Text + ", " + rollno1;
            }

            string Localizacao = sname.First().ToString().ToUpper() + sname.Substring(1);
            if (PPA3DropDownList1.Items.FindByText(sname) != null)
            {
            }
            else
            {
                contadorerro = 1;
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