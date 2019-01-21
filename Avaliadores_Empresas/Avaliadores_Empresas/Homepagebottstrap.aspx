<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepagebottstrap.aspx.cs" Inherits="Avaliadores_Empresas.Homepagebottstrap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Portal dos Avaliadores - Index</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link runat="server" rel="icon" href="Imagens/Logos/favicon.ico" type="image/x-icon" />

    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,500,600,700" rel="stylesheet">
    <link rel="stylesheet" href="OwlCarousel/dist/assets/owl.carousel.css" />
    <link rel="stylesheet" href="OwlCarousel/dist/assets/owl.theme.default.min.css" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <link rel="stylesheet" href="CSS/Hp_style.css">
    <link rel="stylesheet" href="CSS/Main.css">
</head>

<body>
    <form runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark fixed-top">
            <a class="navbar-brand" href="#">
                <img src="images/Logos/favicon.ico" width="40" height="40" alt="">
            </a>

            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".dual-collapse2" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="navbar-collapse collapse w-100 order-2 dual-collapse2">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="SobreNos">Somos Nos</a>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="LinkButton2" runat="server" Text="Avaliador" OnClick="LinkButton2_Click"></asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="LinkButton3" runat="server" Text="Empresa" OnClick="LinkButton3_Click"></asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Contactos">Contactos</a>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-log-out" style="padding-right: 2px"></span></asp:LinkButton>

                    </li>
                </ul>
            </div>
        </nav>


        <div class="row slider">
            <div class="container-fluid">
                <div class="row slider">
                    <div class="owl-carousel owl-theme" id="owl">
                        <div class="item">
                            <img src="images/imagens_em_azul/1.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/2.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/3.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/4.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/5.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/6.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/7.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/8.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/9.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/10.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/11.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/12.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/13.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/14.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/15.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/16.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/17.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/18.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="images/imagens_em_azul/19.jpg" alt="">
                        </div>

                    </div>


                    <div class="texto">
                        <div>
                            <h1 class="sub_tit">Bem Vindo ao teu </h1>
                            <h1 class="titulo">Portal do Avaliador </h1>
                            <asp:Button runat="server" ID="button2" CssClass="hp_button" OnClick="Button1_Click" Text="Somos Nos" />
                        </div>
                    </div>

                </div>

            </div>

          

        </div>



        <footer class="footer">
            <div class="container-fluid">
                <span class="">@Copyright</span>
            </div>
        </footer>


    </form>



</body>


<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
<script src="OwlCarousel/dist/owl.carousel.min.js"></script>
<script src="JS/carrousels.js"></script>

</html>
