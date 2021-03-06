﻿﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registar_Empresas.aspx.cs" Inherits="Avaliadores_Empresas.Registar_Empresas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Portal dos Avaliadores - Registo de Empresas</title>
    <meta charset="utf-8">
    <link runat="server" rel="icon" href="../Imagens/Logos/favicon.ico" type="image/x-icon" />
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.carousel.css" />
    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.theme.default.min.css" />

    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,500,600,700" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        <link rel="stylesheet" href="../CSS/Main.css">

    <link rel="stylesheet" href="../CSS/rEmp_style.css">
</head>



<body>
    <form id="form1" runat="server">

        <div class="custompopup" id="div5" runat="server" visible="false">
            <p>
                <asp:Label ID="Label1" runat="server" Text="Quer efetuar que tipo de pagamento?"></asp:Label>
            </p>

            <asp:Button ID="Button2" runat="server" Text="Mensal" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Anual" OnClick="Button3_Click" />
        </div>

        <header>
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
                        <a href="SobreNos" class="dropdown-item">Somos Nos</a>
                        <a href="Registar_Avaliadores" class="dropdown-item ">Avaliador</a>
                        <a href="Registar_Empresas" class="dropdown-item ativo">Empresa</a>
                        <a href="Contactos" class="dropdown-item ">Contactos</a>
                        <asp:LinkButton id="LinkButton4" runat="server" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-log-out" style="padding-right: 2px"></span></asp:LinkButton>

                    </div>
                </div>
            </nav>
        </header>


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
                <div class="main_div row ml-0 mr-0">
                    <div class="rEmp_innerDiv">
                        <div class="w-100" style="text-align: left">
                            <h1>Registar Empresa</h1>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="col-lg-3">
                                        <p>nome </p>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="nome_emp" placeholder="nome" Width="100%" CssClass="textboxContactos" runat="server" required></asp:TextBox>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <p>e-mail </p>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="email_emp" placeholder="email" Width="100%" CssClass="textboxContactos" runat="server" required TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <p>telefone </p>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="mobile_emp" placeholder="telefone" Width="100%" CssClass="textboxContactos" MaxLength="9" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <p>morada </p>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="morada_emp" placeholder="morada" Width="100%" CssClass="textboxContactos" runat="server" required></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="col-lg-4">
                                        <p>nº registo CMVM </p>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="nregisto_emp" Width="100%" placeholder="CMVM" CssClass="textboxContactos" runat="server" required></asp:TextBox>
                                    </div>
                                </div>


                            </div>
                        </div>
                        <br>
                        &nbsp;

                            <div class="row">
                                <div class="col-xl-6">
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <p>password </p>
                                        </div>
                                        <div class="col-lg-9">
                                            <asp:TextBox ID="pass_emp" placeholder="password" runat="server" CssClass="textboxContactos" TextMode="Password" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <p>confirmar password </p>
                                        </div>
                                        <div class="col-lg-9">
                                            <asp:TextBox ID="confpass_emp" placeholder="confirmar password" runat="server" CssClass="textboxContactos" TextMode="Password" required></asp:TextBox>
                                            <br>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 align-right">
                                            <asp:Button ID="btn_regist_emp" runat="server" CssClass="btn-registar" OnClick="btn_regist_emp_Click" Text="Registar" />
                                        </div>
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

