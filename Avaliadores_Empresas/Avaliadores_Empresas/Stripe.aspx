<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stripe.aspx.cs" Inherits="Avaliadores_Empresas.Stripe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <form id="form1" action="/Charge.aspx" method="POST" runat="server">
          <script
        src="https://checkout.stripe.com/checkout.js" class="stripe-button"
        data-key="<%= stripePublishableKey %>"
        data-amount="1000"
        data-name="Stripe.com"
        data-description="Sample Charge"
        data-locale="auto"
        data-zip-code="true">
    </script>
    <div>
    
    </div>
    </form>
</body>
</html>
