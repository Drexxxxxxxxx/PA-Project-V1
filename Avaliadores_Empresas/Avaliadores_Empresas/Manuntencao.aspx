<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manuntencao.aspx.cs" Inherits="Avaliadores_Empresas.Manuntencao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link runat="server" rel="icon" href="Imagens/Logos/favicon.ico" type="image/x-icon" />

    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,500,600,700" rel="stylesheet">
    <link rel="stylesheet" href="OwlCarousel/dist/assets/owl.carousel.css" />
    <link rel="stylesheet" href="OwlCarousel/dist/assets/owl.theme.default.min.css" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    
    <link rel="stylesheet" href="CSS/Main.css">
    <link rel="stylesheet" href="CSS/Hp_style.css">
    <link rel="stylesheet" href="CSS/Manuntecao_style.css">

</head>

<body>
    <form runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark fixed-top">
            <a class="navbar-brand">
                <img src="images/Logos/favicon.ico" width="40" height="40" alt="">
            </a>
         
        </nav>


        <div class="position-relative slider">
            <div class="container-fluid">
                <div class="row slider">
                    <div class="owl-carousel owl-theme" id="owl">
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/1.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/2.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/3.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/4.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/5.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/6.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/7.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/8.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/9.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/10.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/11.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/12.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/13.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/14.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/15.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/16.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/17.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/18.jpg" alt="">
                        </div>
                        <div class="item">
                            <img src="Imagens/imagens_cinzas/19.jpg" alt="">
                        </div>

                    </div>


                    <div class="main-div texto">
                        <div class="inner">
                            <asp:Image ID="spinner" runat="server" ImageUrl="~/Imagens/Logos/lg_branco.png" Width="200px" />
                            <asp:Label ID="Label2" runat="server" Text="BREVEMENTE" CssClass="LabelPortal mb-1 ml-4 mr-4"></asp:Label><br />

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

