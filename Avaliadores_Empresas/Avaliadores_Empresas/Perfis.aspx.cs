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
    public partial class Perfis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string trimlink = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] words = trimlink.Split('?');
            string idvalor = "";
            string Tipo = "";
            foreach (string word in words)
            {
                string[] ids = word.Split('=');
                try
                {
                    Tipo = ids.First();
                    idvalor = ids.Last();
                }
                catch
                {
                }
            }
            
            if(Tipo == "Emp")
            {
                // Saber se é Avaliador ?
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string N_Avaliador = "SELECT * from tblempresa where id = @id";
                MySqlCommand comand = new MySqlCommand(N_Avaliador);
                        comand.Parameters.AddWithValue("@id", idvalor);
                comand.Connection = con;
                comand.ExecuteNonQuery();

                MySqlDataReader read = comand.ExecuteReader();
                //SE EXISTIR ELE ENTRA NO IF
                if (read.Read())
                {
                    Label2.Text = read[1].ToString();
                    Label4.Text = read[3].ToString();
                    Label6.Text = read[4].ToString();
                }

                con.Close();
                read.Close();
            }
            if (Tipo == "Aval")
            {
                // Saber se é Avaliador ?
                string constr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                // Codigo para registar
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string N_Avaliador = "SELECT * from tblavaliador where id = @id";
                MySqlCommand comand = new MySqlCommand(N_Avaliador);

                        comand.Parameters.AddWithValue("@id", idvalor);
                
                comand.Connection = con;
                comand.ExecuteNonQuery();

                MySqlDataReader read = comand.ExecuteReader();
                //SE EXISTIR ELE ENTRA NO IF
                if (read.Read())
                {
                   Label2.Text = read[1].ToString();
                   Label4.Text = read[3].ToString();
                   Label6.Text = read[4].ToString();
                }

                con.Close();
                read.Close();
            }
        }
    }
}