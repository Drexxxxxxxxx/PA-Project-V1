using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Avaliadores_Empresas
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var secretKey = WebConfigurationManager.AppSettings["StripeSecretKey"];
            StripeConfiguration.SetApiKey(secretKey);
            RegisterRoutes(RouteTable.Routes);
        }
        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Admin", "Admin", "~/ASPX/Admin.aspx");
            routes.MapPageRoute("Login", "Login", "~/ASPX/Login.aspx");
            routes.MapPageRoute("Avaliador", "Avaliador", "~/ASPX/Avaliador.aspx");
            routes.MapPageRoute("Charge", "Charge", "~/ASPX/Charge.aspx");
            routes.MapPageRoute("Contactos", "Contactos", "~/ASPX/Contactos.aspx");
            routes.MapPageRoute("Empresa", "Empresa", "~/ASPX/Empresa.aspx");
            routes.MapPageRoute("Avaliacao2", "Avaliacao2", "~/ASPX/PublicarPedidoAvaliacao2.aspx");
            routes.MapPageRoute("Avaliacao1", "Avaliacao1", "~/ASPX/PublicarPedidoAvaliacao1.aspx");
            routes.MapPageRoute("Perfis", "Perfis", "~/ASPX/Perfis.aspx");
            routes.MapPageRoute("Avaliacao3", "Avaliacao3", "~/ASPX/PublicarPedidoAvaliacao3.aspx");
            routes.MapPageRoute("Registar_Avaliadores", "Registar_Avaliadores", "~/ASPX/Registar_Avaliadores.aspx");
            routes.MapPageRoute("Registar_Empresas", "Registar_Empresas", "~/ASPX/Registar_Empresas.aspx");
            routes.MapPageRoute("SobreNos", "SobreNos", "~/ASPX/SobreNos.aspx");
            routes.MapPageRoute("Stripe", "Stripe", "~/ASPX/Stripe.aspx");
            routes.MapPageRoute("Sucesso", "Sucesso", "~/ASPX/Sucesso.aspx");
            routes.MapPageRoute("Payment", "Payment", "~/ASPX/PaginaTestePaypal.aspx");
            routes.MapPageRoute("HomePage", "HomePage", "~/Homepagebottstrap.aspx");
            routes.MapPageRoute("Manuntencao", "Manuntencao", "~/Manuntencao.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}