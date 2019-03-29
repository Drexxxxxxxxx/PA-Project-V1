using MySql.Data.MySqlClient;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avaliadores_Empresas
{
    public partial class Charge : System.Web.UI.Page
    {
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
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = Request.Form["stripeEmail"],
                SourceToken = Request.Form["stripeToken"]
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            Console.WriteLine(charge);
        }
    }
}