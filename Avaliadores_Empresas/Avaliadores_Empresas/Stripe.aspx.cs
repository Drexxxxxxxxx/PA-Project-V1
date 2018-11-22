using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avaliadores_Empresas
{
    public partial class Stripe : System.Web.UI.Page
    {
        public string stripePublishableKey = WebConfigurationManager.AppSettings["StripePublishableKey"];

        protected void Page_Load(object sender, EventArgs e)
        {
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
                    Response.Redirect("Login.aspx");
                }
                comand.Connection = con;
                comand.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}