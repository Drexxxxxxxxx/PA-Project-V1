﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avaliadores_Empresas
{
    public partial class PublicarPedidoAvaliacao1 : System.Web.UI.Page
    {
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
                    PPA1DropDownList1.DataSource = dt;
                    PPA1DropDownList1.DataTextField = "Nome";
                    PPA1DropDownList1.DataValueField = "id";
                    PPA1DropDownList1.DataBind();
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
                    PPA1DropDownList2.DataSource = dt;
                    PPA1DropDownList2.DataTextField = "Nome";
                    PPA1DropDownList2.DataValueField = "id";
                    PPA1DropDownList2.DataBind();
                }
            }
        }
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
    }
}