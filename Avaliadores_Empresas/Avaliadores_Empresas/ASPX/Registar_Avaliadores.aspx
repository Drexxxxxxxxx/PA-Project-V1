﻿﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registar_Avaliadores.aspx.cs" Inherits="Avaliadores_Empresas.Registar_Avaliadores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Portal dos Avaliadores - Registo de Avaliadores</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link runat="server" rel="icon" href="../Imagens/Logos/favicon.ico" type="image/x-icon" />


    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.carousel.css" />
    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.theme.default.min.css" />

    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,500,600,700" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="../CSS/sumoselect.css" rel="stylesheet">


    <link rel="stylesheet" href="../CSS/Main.css">
    <link rel="stylesheet" href="../CSS/rAval_style.css">
    
</head>

<body>
    <form runat="server">  
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
                        <a href="Registar_Avaliadores" class="dropdown-item ativo">Avaliador</a>
                        <a href="Registar_Empresas" class="dropdown-item">Empresa</a>
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
                <div class="row main_div mr-0 ml-0">
                    <div class="rAval_innerDiv">
                        <div class="w-100" style="text-align: left">
                            <h1>Registar Avaliador</h1>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="col-lg-3">
                                        <p>nome </p>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="nome_aval" placeholder="nome" CssClass="textboxContactos" Width="100%" runat="server" required></asp:TextBox>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <p>e-mail </p>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="email_aval" CssClass="textboxContactos" placeholder="e-mail" Width="100%" runat="server" required TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <p>telefone  </p>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="mobile_aval" CssClass="textboxContactos" placeholder="telefone" Width="100%" MaxLength="9" oninput="this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <p>morada </p>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="morada_aval" CssClass="textboxContactos" placeholder="morada" Width="100%" runat="server" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <p>nº registo CMVM </p>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="nregisto_aval" placeholder="CMVM" CssClass="textboxContactos" Width="100%" runat="server" required></asp:TextBox>

                                    </div>
                                </div>

                            </div>
                            <div class="col-12 col-lg-6">
                                <div class="row">
                                    <div class="col-12">
                                        <p>área de atuação </p>
                                    </div>
                                    <div class="col">
                                        <asp:TextBox ID="TextBox1" CssClass="area-text" runat="server" onfocus="Textboxdp_areaFocus()" onchange="sortDpArea()" onkeydown="sortDpArea()"></asp:TextBox>
                                         <asp:button text="Get Values" visible="false" id="btnGetSelectedValues" onclick="btnGetSelectedValues_Click" runat="server"></asp:button>
                                        <asp:listbox runat="server" id="dp_area" selectionmode="Multiple">
                                        </asp:listbox>
                                    </div>                            
                                </div>


                            </div>
                        </div>
                        <br/>

                        <div class="row">
                            <div class="col-xl-6">
                                <div class="row">
                                    <div class="col-lg-3">
                                        <p>password </p>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="pass_aval" runat="server" placeholder="password" CssClass="textboxContactos" Width="100%" TextMode="Password" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <p>confirmar password </p>
                                    </div>
                                    <div class="col-lg-9">
                                       <asp:TextBox ID="confpass_aval" placeholder="confirmar password" runat="server" CssClass="textboxContactos" Width="100%" TextMode="Password" required></asp:TextBox>

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
    <script src="../JS/jquery.sumoselect.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
<script src="../OwlCarousel/dist/owl.carousel.min.js"></script>
<script src="../JS/carrousels.js"></script>

    
<script type="text/javascript">
    $(document).ready(function () {
        $(<%=dp_area.ClientID%>).SumoSelect();
    });
</script>

    <script>
        function sortDpArea() {
            $(".optWrapper.multiple ul li").each(function (index) {
                $(this).show();           
                var contains = $(this).text().includes(capitalizeFirstLetter($("#TextBox1").val()));
                if (!contains) {
                    $(this).hide();
                }
            });
        }

        function Textboxdp_areaFocus() {
            $(".SumoSelect.sumo_dp_area").addClass("open");
        }

        function capitalizeFirstLetter(string) {
            return string.charAt(0).toUpperCase() + string.slice(1);
        }
    </script>
</html>
