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
    public partial class PublicarPedidoAvaliacao2 : System.Web.UI.Page
    {
        int contadorerro = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    comand.Connection = con;
                    comand.ExecuteNonQuery();
                }
                catch
                {
                    Response.Redirect("Login");
                }
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
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = "Nome";
                    DropDownList1.DataValueField = "id";
                    DropDownList1.DataBind();
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
                    DropDownList2.DataSource = dt;
                    DropDownList2.DataTextField = "Nome";
                    DropDownList2.DataValueField = "id";
                    DropDownList2.DataBind();
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string rollno;
            string sname;
            string fname;
            string Denominacao;
            OleDbConnection mycon;
            string path = Path.GetFileName(FileUpload1.FileName);
            path = path.Replace(" ", "");
            try
            {
                FileUpload1.SaveAs(Server.MapPath("~/ExcelFileEdited/") + path);
                Label7.Text = path;
                String ExcelPath = Server.MapPath("~/ExcelFileEdited/") + path;
                mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            }
            catch
            {
                FileUpload1.SaveAs(Server.MapPath("~/ExcelFileEdited/") + Label7.Text);
                String ExcelPath = Server.MapPath("~/ExcelFileEdited/") + Label7.Text;
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
            if (contadorerro == 0)
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
                GridView1.DataSource = dt2;
                GridView1.DataBind();
                Label1.Visible = true;
                Label1.Text = "Data Has Been Saved Successfully";
                dr.Close();
                Button3.Visible = true;
            }
            else
            {

            }
            mycon.Close();
            Button4.Visible = true;
            Button2.Visible = false;
            FileUpload1.Visible = false;
            Button5.Visible = true;
        }
        private void Verificacao(string rollno1, string sname1, string fname1)
        {
            string deadline = fname1;
            string localidade = sname1.First().ToString().ToUpper() + sname1.Substring(1);
            if (DropDownList1.Items.FindByText(sname1) != null)
            {
            }
            else
            {
                contadorerro = 1;
                Label1.Visible = true;
                Label1.Text = Label1.Text + ", " + sname1;
            }
            string Tipo = rollno1.First().ToString().ToUpper() + rollno1.Substring(1);
            if (DropDownList2.Items.FindByText(rollno1) != null)
            {
            }
            else
            {
                contadorerro = 1;
                Label1.Visible = true;
                Label1.Text = Label1.Text + ", " + rollno1;
            }
            try
            {
                DateTime dt = DateTime.Parse(fname1);
            }
            catch
            {
                contadorerro = 1;
                Label1.Text = "Um ou mais dados no campo Deadline não é uma data";
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Formulario.xlsx");
            Response.TransmitFile(Server.MapPath("~/ExcelFileOriginal/Formulario.xlsx"));
            Response.End();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string idlocalizacao = "";
                string idTipo = "";

                for (int k = 0; k < DropDownList2.Items.Count; k++)
                {
                    string testao1 = HttpUtility.HtmlDecode(DropDownList2.Items[k].Text);
                    string testao2 = HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[0].Text);
                    if (testao1 == testao2)
                    {
                        idTipo = DropDownList2.Items[k].Value;
                    }
                }

                for (int z = 0; z < DropDownList1.Items.Count; z++)
                {
                    string testao11 = HttpUtility.HtmlDecode(DropDownList1.Items[z].Text);
                    string testao22 = HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[1].Text);

                    if (testao11 == testao22)
                    {
                        idlocalizacao = DropDownList1.Items[z].Value;
                    }
                }

                string Denominacao = HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[3].Text);
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandText = "insertavaliacao";
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("vartipo", idTipo);
                cmd2.Parameters.AddWithValue("varlocalizacao", idlocalizacao);
                cmd2.Parameters.AddWithValue("vardeadline", GridView1.Rows[i].Cells[2].Text);
                cmd2.Parameters.AddWithValue("varidempresa", Session["idAvaliador"].ToString());
                cmd2.Parameters.AddWithValue("vartextotipo", Denominacao);
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Avaliações Criadas com sucesso')", true);
            Response.Redirect("Empresa");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empresa");
        }
    }
}