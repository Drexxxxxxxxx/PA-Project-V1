using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avaliadores_Empresas
{
    public partial class SobreNos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sessaostrng = Session["idAvaliador"].ToString();
                LinkButton1.Text = "Logout";

            }
            catch
            {
                LinkButton1.Text = "Login";
            }
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