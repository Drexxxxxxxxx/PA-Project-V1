﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registar_Avaliadores.aspx.cs" Inherits="Avaliadores_Empresas.Registar_Avaliadores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registar Avaliador</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link runat="server" rel="icon" href="../Imagens/Logos/favicon.ico" type="image/x-icon" />


    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.carousel.css" />
    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.theme.default.min.css" />

    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,500,600,700" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>


    <link rel="stylesheet" href="../CSS/rAval_style.css">
    <link rel="stylesheet" href="../CSS/Main.css">
</head>

<body>
    <form runat="server">

        <div class="custompopup" id="div5" runat="server" visible="false">
            <p>
                <asp:Label ID="Label1" runat="server" Text="Quer efetuar que tipo de pagamento?"></asp:Label>
            </p>

            <asp:Button ID="Button2" runat="server" Text="Mensal" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Anual" OnClick="Button3_Click" />
        </div>

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
                        <asp:LinkButton ID="LinkButton2" runat="server" Text="Avaliador" OnClick="LinkButton2_Click"></asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="LinkButton3" runat="server" Text="Empresa" OnClick="LinkButton3_Click"></asp:LinkButton>
                    </li>
                    <li class="nav-item ">
                        <a class="nav-link" href="Contactos">Contactos</a>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-log-out" style="padding-right: 2px"></span></asp:LinkButton>

                    </li>
                </ul>
            </div>
        </nav>

        <div class="row slider">
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






        </div>
        <div class="rAval_div">
            <div class="rAval_innerDiv">
                <div class="col-xl-12" style="text-align: left">
                    <h1>Registar Avaliador</h1>
                </div>
                <hr>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="row">
                            <div class="col-lg-3">
                                <p>nome </p>
                            </div>
                            <div class="col-lg">
                                <asp:TextBox ID="nome_aval" placeholder="nome" CssClass="textboxContactos" Width="100%" runat="server"></asp:TextBox>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3">
                                <p>e-mail </p>
                            </div>
                            <div class="col-lg">
                                <asp:TextBox ID="email_aval" CssClass="textboxContactos" placeholder="e-mail" Width="100%" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3">
                                <p>telefone </p>
                            </div>
                            <div class="col-lg">
                                <asp:TextBox ID="mobile_aval" CssClass="textboxContactos" placeholder="telefone" Width="100%" MaxLength="9" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3">
                                <p>morada </p>
                            </div>
                            <div class="col-lg">
                                <asp:TextBox ID="morada_aval" CssClass="textboxContactos" placeholder="morada" Width="100%" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3">
                                <p>nº registo CMVM </p>
                            </div>
                            <div class="col-lg">
                                <asp:TextBox ID="nregisto_aval" placeholder="CMVM" CssClass="textboxContactos" Width="100%" runat="server"></asp:TextBox>

                            </div>
                        </div>

                    </div>
                    <div class="col-lg-6">
                        <div class="row">
                            <div class="col-lg-6">
                                <p>área de atuação </p>
                            </div>
                            <div class="col-lg-6">
                                <asp:DropDownList CssClass="buttonsobrenos" ID="dp_area" runat="server"></asp:DropDownList>
                                <asp:Button ID="AddtoListbox" runat="server" OnClick="AddtoListbox_Click" CssClass="btn-light" Text="Adiciona" />
                            </div>
                            <div class="col-sm-6">
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Visible="true" CssClass="btn-light" Text="Remover Área Selecionada" />

                            </div>
                            <div class="col-sm-6">
                                <asp:ListBox ID="ListBox1" runat="server" Height="59px" CssClass="listboxcss" Width="86%"></asp:ListBox>
                                <script>
                                    $("#ListBox1").keyup(function (e) {
                                        if (e.which == 46) {
                                            $("#Button1").click();
                                        }
                                    });
                                </script>
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
                                        <div class="col-lg">
                                            <asp:TextBox ID="pass_aval" runat="server" placeholder="password" CssClass="textboxContactos" Width="100%" TextMode="Password"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <p>confirmar password </p>
                                        </div>
                                        <div class="col-lg">
                                            <asp:TextBox ID="confpass_aval" placeholder="confirmar password" runat="server" CssClass="textboxContactos" Width="100%" TextMode="Password"></asp:TextBox>

                                            <br>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 align-right">
                                            <asp:Button ID="btn_regist_Aval" runat="server" CssClass="btn-registar" OnClick="btn_regist_Aval_Click" Text="Registar" />

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
