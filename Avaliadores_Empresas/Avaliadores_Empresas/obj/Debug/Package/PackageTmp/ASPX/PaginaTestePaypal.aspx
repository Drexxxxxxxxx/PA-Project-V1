<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaTestePaypal.aspx.cs" Inherits="Avaliadores_Empresas.PaginaTestePaypal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }

        .custompopup {
            background-color: #fff;
            border: 3px solid #fff;
            display: inline-block;
            left: 50%;
            padding: 15px;
            position: fixed;
            text-align: justify;
            top: 40%;
            z-index: 10;
            -webkit-transform: translate(-50%, -50%);
            -moz-transform: translate(-50%, -50%);
            -ms-transform: translate(-50%, -50%);
            -o-transform: translate(-50%, -50%);
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            -ms-border-radius: 10px;
            -o-border-radius: 10px;
            -webkit-box-shadow: 0 1px 1px 2px rgba(0, 0, 0, 0.4) inset;
            -moz-box-shadow: 0 1px 1px 2px rgba(0, 0, 0, 0.4) inset;
            -ms-box-shadow: 0 1px 1px 2px rgba(0, 0, 0, 0.4) inset;
            -o-box-shadow: 0 1px 1px 2px rgba(0, 0, 0, 0.4) inset;
            -webkit-transition: opacity .5s, top .5s;
            -moz-transition: opacity .5s, top .5s;
            -ms-transition: opacity .5s, top .5s;
            -o-transition: opacity .5s, top .5s;
        }

        .custompopup p, .custompopup div {
            margin-bottom: 10px;
        }

        .custompopup label {
            display: inline-block;
            text-align: left;
            width: 120px;
        }

        .custompopup input[type="text"], .custompopup input[type="password"] {
            border-left: 1px solid #ccc;
            border-right: 1px solid #ccc;
            border-top: 1px solid #999;
            border-bottom: 1px solid #ccc;
            padding: 2px;
            -webkit-border-radius: 2px;
            -moz-border-radius: 2px;
            -ms-border-radius: 2px;
            -o-border-radius: 2px;
            border-radius: 2px;
            margin-left: 0;
            margin-right: 0;
        }

        .custompopup input[type="text"]:hover, .custompopup input[type="password"]:hover {
            border-color: #555 #888 #888;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Pagamento por referencia" />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Pagamento com o Mbway" />
            <asp:TextBox ID="TextBox2" runat="server" placeholder="o numero para o mbway"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>


            <div class="custompopup" id="divReferencia" runat="server" visible="false">
                <asp:Button ID="MensalRef" Width="50%" runat="server" Text="+1 Mês (10€)" OnClick="MensalRef_Click"/>
                <asp:Button ID="AnualRef" Width="50%" runat="server" Text="+1 ano (100€)" OnClick="AnualRef_Click"/>
                <asp:Button ID="Button2" Width="50%" runat="server" Text="cancelar" OnClick="FecharDivs_Click"/>
            </div>

            <div class="custompopup" id="divMbway" runat="server" visible="false">
                <asp:Button ID="MensalMbway" Width="50%" runat="server" Text="+1 Mês (10€)" OnClick="MensalMbway_Click"/>
                <asp:Button ID="AnualMbway" Width="50%" runat="server" Text="+1 ano (100€)" OnClick="AnualMbway_Click"/>
                <asp:Button ID="Button1" Width="50%" runat="server" Text="cancelar" OnClick="FecharDivs_Click"/>
            </div>
        </div>

        <asp:Button ID="Button4" runat="server" Visible="false" OnClick="Button4_Click" Text="Button" />
    </form>
</body>
</html>
