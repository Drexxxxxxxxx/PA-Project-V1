﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Avaliadores_Empresas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link runat="server" rel="icon" href="../Imagens/Logos/favicon.ico" type="image/x-icon" />

    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.carousel.css" />
    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.theme.default.min.css" />

    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,500,600,700" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <link rel="stylesheet" href="../CSS/Main.css">
    <link rel="stylesheet" href="../CSS/login_style.css">


    <title>Portal dos Avaliadores - Login </title>
    <style>
                   
    </style>

</head>
<body>
    <form id="form1" runat="server" defaultbutton="btn_entrar">
        <nav class="navbar navbar-expand-lg navbar-dark fixed-top">
            <a class="navbar-brand" href="../HomePage">
                <img src="../images/Logos/favicon.ico" width="40" height="40" alt="">
            </a>

            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".dual-collapse2" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="navbar-collapse collapse w-100 order-2 dual-collapse2">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a class="nav-link " href="SobreNos">Somos Nos</a>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="LinkButton5" runat="server" Text="Avaliador" OnClick="LinkButton5_Click"></asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="LinkButton4" runat="server" Text="Empresa" OnClick="LinkButton4_Click"></asp:LinkButton>
                    </li>
                    <li class="nav-item ">
                        <a class="nav-link" href="Contactos">Contactos</a>
                    </li>
                    <li class="nav-item active">
                        <asp:LinkButton ID="LinkButton1" CssClass="ativo" runat="server" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-log-out" style="padding-right: 2px"></span></asp:LinkButton>
                    </li>
                </ul>
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

            <div class="main_div mr-0 ml-0">
                <div class="login_innerDiv">
                    <div class="col-xl-12" style="text-align: center">
                        <h1>Login</h1>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row">
                                <div class="col-lg-3">
                                    <p>E-mail </p>
                                </div>
                                <div class="col-lg">
                                    <asp:TextBox runat="server" ID="txt_email" TextMode="SingleLine" placeholder="e-mail"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-3">
                                    <p>Password </p>
                                </div>
                                <div class="col-lg">
                                    <asp:TextBox runat="server" ID="txt_pass" TextMode="Password" placeholder="password"></asp:TextBox>

                                </div>
                            </div>

                        </div>

                    </div>
                    <br>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row">
                                <div class="col-lg-5 offset-3">
                                    <asp:Button ID="btn_entrar" runat="server" CssClass="btn-entrar" Text="Login" OnClick="btn_entrar_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-9 offset-3">
                                    <asp:LinkButton CssClass="color_white" ID="LinkButton3" runat="server" OnClick="LinkButton2_Click">Esqueceu-se da Palavra Passe ?</asp:LinkButton>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-lg-9 offset-3">
                                    <asp:Label ID="lbl_msg" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                </div>
                            </div>

                        </div>

                    </div>
                    <br>
                    &nbsp;
                </div>
                <div class="custompopup" id="div1" runat="server" visible="false">
                    <p>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="borders" placeholder="Email"></asp:TextBox>
                    </p>
                    <asp:Button ID="Button2" CssClass="borders" Width="25%" runat="server" Text="Ok" OnClick="Button5_Click" />
                    &nbsp;
               <asp:Button ID="Button3" runat="server" CssClass="borders" Text="Voltar" OnClick="Button1_Click" />
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
