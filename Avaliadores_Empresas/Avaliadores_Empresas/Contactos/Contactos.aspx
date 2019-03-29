<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contactos.aspx.cs" Inherits="Avaliadores_Empresas.Contactos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Contactos</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link runat="server" rel="icon" href="Imagens/Logos/favicon.ico" type="image/x-icon" />
     <link rel="stylesheet" href="stylesheet/Ct_style.css">
    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,500,600,700" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

</head>

<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark fixed-top">
                <a class="navbar-brand" href="../Homepagebottstrap.aspx">
                        <img src="../images/Logos/favicon.ico" width="40" height="40" alt="">
                      </a>

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".dual-collapse2" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse w-100 order-2 dual-collapse2">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="../sobreNos/SobreNos.aspx">Somos Nos</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../R_Avaliador/Registar_Avaliadores.aspx">Avaliador</a>
                        </li>
                        <li class="nav-item">
                                <a class="nav-link" href="../R_Empresa/Registar_Empresas.aspx">Empresa</a>
                        </li>
                        <li class="nav-item ativo">
                                <a class="nav-link" href="Contactos.aspx">Contactos</a>
                        </li>
                        <li class="nav-item">
                              <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-log-out" style="padding-right: 2px"></span></asp:LinkButton>

                        </li>
                    </ul>
                </div>
        </nav>

        <div class="row slider">
            <div class="container-fluid fill">
                    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                            <div class="carousel-inner" role="listbox">
                              <!-- Slide -->
                              <div class="fill carousel-item active" style="background-image: url('../images/imagens_em_azul/1.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class=" fill carousel-item" style="background-image: url('../images/imagens_em_azul/2.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/3.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class=" fill carousel-item " style="background-image: url('../images/imagens_em_azul/4.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/5.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/6.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class=" fill carousel-item " style="background-image: url('../images/imagens_em_azul/7.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/8.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class=" fill carousel-item " style="background-image: url('../images/imagens_em_azul/9.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/10.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/11.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/12.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/13.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/14.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/15.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/16.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/17.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/18.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                              <!-- Slide  -->
                              <div class="fill carousel-item " style="background-image: url('../images/imagens_em_azul/19.jpg')">
                                <div class="carousel-caption d-none d-md-block">

                                </div>
                              </div>
                            </div>
                          </div>
            
            </div>

          



        </div>
        <div class="contactos_div">
                <div class="contactos_innerDiv">
                            <div class="col-xl-12" style="text-align: left">
                                    <h1>Contactos</h1>
                            </div><hr>
                            <div class="row">
                                <div class="col-lg-4">
                                    nome    
                                </div>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="TextBox1" CssClass="textboxContactos" placeholder="nome" runat="server"></asp:TextBox><br />
                                </div>
                            </div>
                            <div class="row">
                                    <div class="col-lg-4">
                                            e-mail    
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextBox2" placeholder="e-mail" CssClass="textboxContactos" runat="server"></asp:TextBox><br />
                                        </div>
                            </div>
                            <div class="row">
                                    <div class="col-lg-4">
                                            assunto    
                                        </div>
                                        <div class="col-lg-8">
                                             <asp:TextBox ID="TextBox3" placeholder="assunto" CssClass="textboxContactos" runat="server"></asp:TextBox><br />
                                        </div>
                            </div>
                            <div class="row">
                                    <div class="col-lg-4">
                                            descrição    
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextBox4" placeholder="descrição" CssClass="textboxContactos" runat="server" TextMode="MultiLine" Height="178px" Width="247px"></asp:TextBox><br />

                                        </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <asp:Button ID="Button1" runat="server" CssClass="buttonsobrenos" Text="Enviar" OnClick="Button1_Click" />
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

</html>
