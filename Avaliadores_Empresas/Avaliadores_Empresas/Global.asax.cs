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
            routes.MapPageRoute("ASPX/Admin", "ASPX/Admin", "~/ASPX/Admin.aspx");
            routes.MapPageRoute("ASPX/Login", "ASPX/Login", "~/ASPX/Login.aspx");
            routes.MapPageRoute("ASPX/Avaliador", "ASPX/Avaliador", "~/ASPX/Avaliador.aspx");
            routes.MapPageRoute("ASPX/Charge", "ASPX/Charge", "~/ASPX/Charge.aspx");
            routes.MapPageRoute("ASPX/Contactos", "ASPX/Contactos", "~/ASPX/Contactos.aspx");
            routes.MapPageRoute("ASPX/Empresa", "ASPX/Empresa", "~/ASPX/Empresa.aspx");
            routes.MapPageRoute("ASPX/Avaliacao2", "ASPX/Avaliacao2", "~/ASPX/PublicarPedidoAvaliacao2.aspx");
            routes.MapPageRoute("ASPX/Avaliacao1", "ASPX/Avaliacao1", "~/ASPX/PublicarPedidoAvaliacao1.aspx");
            routes.MapPageRoute("ASPX/Perfis", "ASPX/Perfis", "~/ASPX/Perfis.aspx");
            routes.MapPageRoute("ASPX/Avaliacao3", "ASPX/Avaliacao3", "~/ASPX/PublicarPedidoAvaliacao3.aspx");
            routes.MapPageRoute("ASPX/Registar_Avaliadores", "ASPX/Registar_Avaliadores", "~/ASPX/Registar_Avaliadores.aspx");
            routes.MapPageRoute("ASPX/Registar_Empresas", "ASPX/Registar_Empresas", "~/ASPX/Registar_Empresas.aspx");
            routes.MapPageRoute("ASPX/SobreNos", "ASPX/SobreNos", "~/ASPX/SobreNos.aspx");
            routes.MapPageRoute("ASPX/Stripe", "ASPX/Stripe", "~/ASPX/Stripe.aspx");
            routes.MapPageRoute("ASPX/Sucesso", "ASPX/Sucesso", "~/ASPX/Sucesso.aspx");
            routes.MapPageRoute("ASPX/Payment", "ASPX/Payment", "~/ASPX/PaginaTestePaypal.aspx");
            routes.MapPageRoute("ASPX/HomePage", "ASPX/HomePage", "~/Homepagebottstrap.aspx");
            routes.MapPageRoute("ASPX/Manuntencao", "ASPX/Manuntencao", "~/Manuntencao.aspx");
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