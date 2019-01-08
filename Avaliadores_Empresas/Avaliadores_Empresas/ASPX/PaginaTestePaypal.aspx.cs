using MySql.Data.MySqlClient;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avaliadores_Empresas
{
    public partial class PaginaTestePaypal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int contadortipo = 0;
                if (Session["Tipo"].ToString() == "1")
                {
                    contadortipo = 1;
                    try
                    {
                        // Saber se é Avaliador ?
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
                            Response.Redirect("Login");
                        }

                        comand.Connection = con;
                        comand.ExecuteNonQuery();
                    }
                    catch
                    {
                        Response.Redirect("Login");
                    }
                }
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
                            Response.Redirect("Login");
                        }
 
                    comand.Connection = con;
                    comand.ExecuteNonQuery();
                    }
                    catch
                    {
                        Response.Redirect("Login");
                    }
                }
                if(contadortipo != 1)
                {
                    Response.Redirect("Login");
                }
            }
        }

        void Referencia()
        {
            var client = new RestClient("https://replica.eupago.pt/clientes/rest_api/multibanco/create");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "38f5eb57-63d2-b8bb-575e-268f2f1d1299");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            if (Session["Tipo"].ToString() == "1")
            {
                if (Session["PagarTipo"].ToString() == "0")
                {
                    request.AddParameter("application/json", "{\r\n\"chave\" : \"demo-f706-5d02-dff2-e0a\",\r\n\"valor\" : \"10\",\r\n\"id\" : \"Aval_" + Session["PagarTipo"].ToString() + "_" + Session["idAvaliador"].ToString() + "\"\r\n}\r\n", ParameterType.RequestBody);
                }
                if (Session["PagarTipo"].ToString() == "1")
                {
                    request.AddParameter("application/json", "{\r\n\"chave\" : \"demo-f706-5d02-dff2-e0a\",\r\n\"valor\" : \"100\",\r\n\"id\" : \"Aval_" + Session["PagarTipo"].ToString() + "_" + Session["idAvaliador"].ToString() + "\"\r\n}\r\n", ParameterType.RequestBody);
                }
            }
            if (Session["Tipo"].ToString() == "2")
            {
                if (Session["PagarTipo"].ToString() == "0")
                {
                    request.AddParameter("application/json", "{\r\n\"chave\" : \"demo-f706-5d02-dff2-e0a\",\r\n\"valor\" : \"10\",\r\n\"id\" : \"Emp_" + Session["PagarTipo"].ToString() + "_" + Session["idAvaliador"].ToString() + "\"\r\n}\r\n", ParameterType.RequestBody);
                }
                if (Session["PagarTipo"].ToString() == "1")
                {
                    request.AddParameter("application/json", "{\r\n\"chave\" : \"demo-f706-5d02-dff2-e0a\",\r\n\"valor\" : \"100\",\r\n\"id\" : \"Emp_" + Session["PagarTipo"].ToString() + "_" + Session["idAvaliador"].ToString() + "\"\r\n}\r\n", ParameterType.RequestBody);
                }
            }
            IRestResponse response = client.Execute(request);
            var a = JsonValue.Parse(response.Content);

            Label1.Text = a["referencia"].ToString().Trim('"');

            if (Session["Tipo"].ToString() == "1")
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                string NomeEmpresa = "";
                MySqlConnection con3 = new MySqlConnection(constr);
                con3.Open();
                if (Session["PagarTipo"].ToString() == "1")
                {
                    NomeEmpresa = "UPDATE tblavaliador SET tblavaliador.idpagamento = @idpagamento, TipoPagamento = 2 WHERE tblavaliador.id = @id;";
                }
                if (Session["PagarTipo"].ToString() == "0")
                {
                    NomeEmpresa = "UPDATE tblavaliador SET tblavaliador.idpagamento = @idpagamento, TipoPagamento = 1 WHERE tblavaliador.id = @id;";
                }

                MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                comand3.Parameters.AddWithValue("@idpagamento", Label1.Text);
                comand3.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
                comand3.Connection = con3;
                comand3.ExecuteNonQuery();
                con3.Close();
            }

            if (Session["Tipo"].ToString() == "2")
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

                MySqlConnection con3 = new MySqlConnection(constr);
                con3.Open();
                string NomeEmpresa = "";
                if (Session["PagarTipo"].ToString() == "1")
                {
                    NomeEmpresa = "UPDATE tblempresa SET tblempresa.idpagamento = @idpagamento, TipoPagamento = 2 WHERE tblempresa.id = @id;";
                }
                if (Session["PagarTipo"].ToString() == "0")
                {
                    NomeEmpresa = "UPDATE tblempresa SET tblempresa.idpagamento = @idpagamento, TipoPagamento = 1 WHERE tblempresa.id = @id;";
                }
                MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                comand3.Parameters.AddWithValue("@idpagamento", Label1.Text);
                comand3.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
                comand3.Connection = con3;
                comand3.ExecuteNonQuery();
                con3.Close();
            }
        }

        void Mbway()
        {
            var client = new RestClient("https://replica.eupago.pt/clientes/rest_api//mbway/create");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "5fa93597-8d88-0248-f8ef-df59a68652c7");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            if (Session["Tipo"].ToString() == "1")
            {
                if (Session["PagarTipo"].ToString() == "0")
                {
                    request.AddParameter("application/json", "{\"chave\":\"demo-f706-5d02-dff2-e0a\",\"valor\":\"10\",\"id\":\"Aval_" + Session["PagarTipo"].ToString() + "_" + Session["idAvaliador"].ToString() + "\",\"alias\":\"" + TextBox2.Text + "\",\"descricao\":\"Pagamento mensal do Portal dos Avaliadores\"}", ParameterType.RequestBody);
                }
                if (Session["PagarTipo"].ToString() == "1")
                {
                    request.AddParameter("application/json", "{\"chave\":\"demo-f706-5d02-dff2-e0a\",\"valor\":\"100\",\"id\":\"Aval_" + Session["PagarTipo"].ToString() + "_" + Session["idAvaliador"].ToString() + "\",\"alias\":\"" + TextBox2.Text + "\",\"descricao\":\"Pagamento anual do Portal dos Avaliadores\"}", ParameterType.RequestBody);
                }
            }
            if (Session["Tipo"].ToString() == "2")
            {
                if (Session["PagarTipo"].ToString() == "0")
                {
                    request.AddParameter("application/json", "{\"chave\":\"demo-f706-5d02-dff2-e0a\",\"valor\":\"10\",\"id\":\"Emp_" + Session["PagarTipo"].ToString() + "_" + Session["idAvaliador"].ToString() + "\",\"alias\":\"" + TextBox2.Text + "\",\"descricao\":\"Pagamento mensal do Portal dos Avaliadores\"}", ParameterType.RequestBody);
                }
                if (Session["PagarTipo"].ToString() == "1")
                {
                    request.AddParameter("application/json", "{\"chave\":\"demo-f706-5d02-dff2-e0a\",\"valor\":\"100\",\"id\":\"Emp_" + Session["PagarTipo"].ToString() + "_" + Session["idAvaliador"].ToString() + "\",\"alias\":\"" + TextBox2.Text + "\",\"descricao\":\"Pagamento anual do Portal dos Avaliadores\"}", ParameterType.RequestBody);
                }
            }
            IRestResponse response = client.Execute(request);
            var a = JsonValue.Parse(response.Content);

            Label1.Text = a["referencia"].ToString().Trim('"');

            if (Session["Tipo"].ToString() == "1")
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                string NomeEmpresa = "";
                MySqlConnection con3 = new MySqlConnection(constr);
                con3.Open();
                if (Session["PagarTipo"].ToString() == "1")
                {
                    NomeEmpresa = "UPDATE tblavaliador SET tblavaliador.idpagamento = @idpagamento, TipoPagamento = 2 WHERE tblavaliador.id = @id;";
                }
                if (Session["PagarTipo"].ToString() == "0")
                {
                    NomeEmpresa = "UPDATE tblavaliador SET tblavaliador.idpagamento = @idpagamento, TipoPagamento = 1 WHERE tblavaliador.id = @id;";
                }

                MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                comand3.Parameters.AddWithValue("@idpagamento", Label1.Text);
                comand3.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
                comand3.Connection = con3;
                comand3.ExecuteNonQuery();
                con3.Close();
            }

            if (Session["Tipo"].ToString() == "2")
            {
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

                MySqlConnection con3 = new MySqlConnection(constr);
                con3.Open();
                string NomeEmpresa = "";
                if (Session["PagarTipo"].ToString() == "1")
                {
                    NomeEmpresa = "UPDATE tblempresa SET tblempresa.idpagamento = @idpagamento, TipoPagamento = 2 WHERE tblempresa.id = @id;";
                }
                if (Session["PagarTipo"].ToString() == "0")
                {
                    NomeEmpresa = "UPDATE tblempresa SET tblempresa.idpagamento = @idpagamento, TipoPagamento = 1 WHERE tblempresa.id = @id;";
                }
                MySqlCommand comand3 = new MySqlCommand(NomeEmpresa);
                comand3.Parameters.AddWithValue("@idpagamento", Label1.Text);
                comand3.Parameters.AddWithValue("@id", Session["idAvaliador"].ToString());
                comand3.Connection = con3;
                comand3.ExecuteNonQuery();
                con3.Close();
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            divReferencia.Visible = true;
        }

        protected void FecharDivs_Click(object sender, EventArgs e)
        {
            divReferencia.Visible = false;
            divMbway.Visible = false;
        }

        protected void MensalRef_Click(object sender, EventArgs e)
        {
            Session["PagarTipo"] = "0";
            Referencia();
            divReferencia.Visible = false;
        }

        protected void AnualRef_Click(object sender, EventArgs e)
        {
            Session["PagarTipo"] = "1";
            Referencia();
            divReferencia.Visible = false;
        }

        protected void MensalMbway_Click(object sender, EventArgs e)
        {
            Session["PagarTipo"] = "0";
            Mbway();
            divMbway.Visible = false;
        }

        protected void AnualMbway_Click(object sender, EventArgs e)
        {
            Session["PagarTipo"] = "1";
            Mbway();
            divMbway.Visible = false;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            divMbway.Visible = true;
        }

        /* *o butao esta invisel, por enquanto ta sem utilidade*/
        protected void Button4_Click(object sender, EventArgs e)
            {
                var client = new RestClient("https://replica.eupago.pt/clientes/rest_api/multibanco/info");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("postman-token", "0571c54a-b107-2ce0-3a1b-bd3d53ec51d1");
                request.AddHeader("content-type", "application/json");
                string referencia = "403291218";
                request.AddParameter("application/json", "{\n\t\"chave\" : \"demo-f706-5d02-dff2-e0a\",\n\t\"referencia\" : \"" + referencia + "\"\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var a = JsonValue.Parse(response.Content);

                try
                {
                    if (a["pagamentos"].ToString().Trim('"') != "")
                    {
                        JsonObject jo = new JsonObject();
                        // populate the array
                        jo.Add("arrayName", a["pagamentos"]);

                        string teste = jo["arrayName"][0]["estado"];
                    }
                }
                catch
                {

                }
            }
    }
} 