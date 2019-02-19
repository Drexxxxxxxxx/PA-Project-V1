<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation ="false" CodeBehind="testegridview.aspx.cs" Inherits="Avaliadores_Empresas.testegridview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="//code.jquery.com/jquery-1.11.3.min.js"></script>
        <script src="//code.jquery.com/jquery-migrate-1.2.1.min.js"></script>
    <style>
               .custompopup
        {
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

        .custompopup p, .custompopup div
        {
            margin-bottom: 10px;
        }
        .custompopup label
        {
            display: inline-block;
            text-align: left;
            width: 120px;
        }
        .custompopup input[type="text"], .custompopup input[type="password"]
        {
            border: 1px solid;
            border-color: #999 #ccc #ccc;
            margin: 0;
            padding: 2px;
            -webkit-border-radius: 2px;
            -moz-border-radius: 2px;
            -ms-border-radius: 2px;
            -o-border-radius: 2px;
            border-radius: 2px;
        }
        .custompopup input[type="text"]:hover, .custompopup input[type="password"]:hover
        {
            border-color: #555 #888 #888;
        }
        .starRating {
            width: 50px;
            height: 50px;
            cursor: pointer;
            background-repeat: no-repeat;
            display: block;
            background-size: cover;
        }
        .FilledStars {
            background-image:url(Imagens/Estrelas/EstrelaAmarela.png)
        }
         .WatingStars {
            background-image:url(Imagens/Estrelas/EstrelaCinzenta.png)
        }
          .EmptyStars {
            background-image:url(Imagens/Estrelas/EstrelaCinzenta.png);
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </form>
</body>
</html>
