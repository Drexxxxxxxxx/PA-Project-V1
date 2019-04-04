<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SobreNos.aspx.cs" Inherits="Avaliadores_Empresas.SobreNos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Portal dos Avaliadores - Sobre Nos</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link runat="server" rel="icon" href="../Imagens/Logos/favicon.ico" type="image/x-icon" />

    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.carousel.css" />
    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.theme.default.min.css" />

    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,500,600,700" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

        <link rel="stylesheet" href="../CSS/Main.css">
    <link rel="stylesheet" href="../CSS/sN_style.css">
</head>
<body>
    <form runat="server">


        <nav class="navbar navbar-expand-md navbar-dark fixed-top">
            <a class="navbar-brand" href="../HomePage">
                <img src="../images/Logos/favicon.ico" width="40" height="40" alt="">
            </a>

            <div class="dropdown dp-nav">
                <button class="btn" type="button" id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <img src="../images/Logos/favicon.ico" width="40" height="40" alt="">
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                    <a href="HomePage" class="dropdown-item ">Home Page</a>
                    <a href="SobreNos" class="dropdown-item ativo">Somos Nos</a>
                    <a href="Registar_Avaliadores" class="dropdown-item ">Avaliador</a>
                    <a href="Registar_Empresas" class="dropdown-item ">Empresa</a>
                    <a href="Contactos" class="dropdown-item ">Contactos</a>
                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-log-out" style="padding-right: 2px"></span></asp:LinkButton>

                </div>
            </div>
            
        </nav>

        <div class="position-relative slider">
            <div class="owl-carousel owl-theme" id="owl">
                <div class="item">
                    <img src="../images/imagens_em_azul/1.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/2.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/3.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/4.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/5.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/6.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/7.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/8.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/9.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/10.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/11.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/12.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/13.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/14.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/15.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/16.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/17.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/18.jpg" alt="">
                </div>
                <div class="item">
                    <img src="../images/imagens_em_azul/19.jpg" alt="">
                </div>

            </div>
            <div class="container">
                <div class="row main_div mr-0 ml-0">
                    <div class="somosNos_innerDiv">
                        <div class="w-100" style="text-align: left">
                            <h1>Sobre Nós</h1>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-6 col-lg-6">
                                <div class="div_texto bg_escura color_white">
                                    Gere o teu trabalho, negoceia os teus honorários, avalia e ganha o teu lugar no ranking
                                </div>

                            </div>
                            <div class="col-6 col-lg-6">
                                <div class="div_texto bg_clara">
                                    Obtem os melhores e mais adequados avaliadores para os trabalhos que tens em mãos.
                                </div>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6 col-lg-4">
                                <div class="div_texto bg_clara">
                                    Avalia e sê avaliado. 
                                </div>
                            </div>
                            <div class="col-6 col-lg-4">
                                <div class="div_texto bg_escura color_white">
                                    Plataforma de gestão de avaliações de imóveis
                                </div>
                            </div>
                            <div class="col-12 col-lg-4">
                                <div class="div_texto bg_clara">
                                    Demonstra que a tua empresa é de todas a que presta melhor serviço."
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-6 col-lg-6">
                                <div class="div_texto bg_clara ">
                                    Destaca-te!
                                </div>
                            </div>
                            <div class="col-6 col-lg-6">
                                <div class="div_texto bg_escura color_white">
                                    Local onde as Empresas de avaliação podem publicar os seus trabalhos e obter os melhores profissionais.
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6 col-lg-4 ">
                                <div class="div_texto bg_escura color_white">
                                    Motor de pesquisa de trabalhos disponiveis para que o avaliador possa obter e organizar o seu trabalho.
                                </div>
                            </div>
                            <div class="col-6 col-lg-4">
                                <div class="div_texto bg_clara">
                                    Motor de avaliação dos avaliadores e das próprias empresas
                                </div>
                            </div>
                            <div class="col-12 col-lg-4 ">
                                <div class="div_texto bg_escura color_white">
                                    Ranking de satisfação para empresas e avaliadores                               
                                </div>
                            </div>
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
<script src="../OwlCarousel/dist/owl.carousel.min.js"></script>
<script src="../JS/carrousels.js"></script>

</html>
