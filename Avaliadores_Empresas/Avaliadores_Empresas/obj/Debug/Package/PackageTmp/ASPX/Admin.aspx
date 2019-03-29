<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Avaliadores_Empresas.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link runat="server" rel="icon" href="../Imagens/Logos/favicon.ico" type="image/x-icon" />

    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.carousel.css" />
    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.theme.default.min.css" />

    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,500,600,700" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"
        crossorigin="anonymous">

    <link rel="stylesheet" href="../CSS/Main.css" />
    <link rel="stylesheet" href="../CSS/Admin.css"/>

    <title>Admin</title>

</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav class="navbar navbar-expand-md navbar-dark fixed-top">
                <a class="navbar-brand" href="../HomePage">
                    <img src="../images/Logos/favicon.ico" width="40" height="40" alt="">
                </a>
                <div class="dropdown dp-nav">
                    <button class="btn" type="button" id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <img src="../images/Logos/favicon.ico" width="40" height="40" alt=""/>
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-log-out"
                                    style="padding-right: 2px"></span>Logout</asp:LinkButton>
                    </div>
                </div>

                <div class="navbar-collapse collapse w-100 order-2 dual-collapse2">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-log-out"
                                    style="padding-right: 2px"></span>Logout</asp:LinkButton>
                        </li>
                    </ul>
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
            <div class="container-fluid">
                <div class="row main_div ml-0 mr-0">
                    <div class="col-12 col-md-9 order-1 order-md-0">
                        <div class="main-div-inner">
                            <div class="row" id="DivRegistos" runat="server" visible="true">
                                <div class="col-12 col-md-6">
                                    <asp:Label ID="Label1" runat="server" Text="Contas Teste Avaliador" Font-Size="X-Large"></asp:Label>
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridView1" runat="server" CssClass="table" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
                                            <Columns>
                                                <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                                                <asp:ButtonField CommandName="Select2" Text="Eliminar" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                    <asp:Label ID="Label12" runat="server"></asp:Label>
                                    <asp:Label ID="Label13" runat="server"></asp:Label>
                                    <br />
                                </div>
                                <div class="col-12 col-md-6">
                                    <asp:Label ID="Label3" runat="server" Text="Contas Teste Empresa" Font-Size="X-Large"></asp:Label>
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridView3" runat="server" CssClass="table" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" OnRowCommand="GridView3_RowCommand">
                                            <Columns>
                                                <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                                                <asp:ButtonField CommandName="Select2" Text="Eliminar" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                    <br />
                                    <asp:ListBox ID="ListBox1" runat="server" Visible="False"></asp:ListBox>
                                    <asp:ListBox ID="ListBox2" runat="server" Visible="False"></asp:ListBox>
                                </div>


                            </div>

                            <div id="DivPerfil" runat="server" visible="false">
                                <asp:Label ID="Label2" runat="server" Text="Nome"></asp:Label>
                                <br />
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
                                <br />
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Label ID="Label7" runat="server" Text="Telemovel"></asp:Label>
                                <br />
                                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Button ID="Button4" CssClass="btn" runat="server" OnClick="Button4_Click" Text="Mudar Password" />
                                <div class="custompopup" id="divThankYou" runat="server" visible="false">
                                    <p>
                                        <asp:Label ID="lblmessage" runat="server">Password Antiga</asp:Label>
                                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                                    </p>
                                    <asp:Button ID="Button5" CssClass="butoespopup" Width="25%" runat="server" Text="Ok" OnClick="Button5_Click" />
                                </div>
                                <div class="custompopup" id="divNovaPass" runat="server" visible="false">
                                    <p>
                                        <asp:Label ID="Label5" runat="server" Text="Nova Password"></asp:Label>
                                        <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Label6" runat="server" Text="Confirmar Password"></asp:Label>
                                        <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
                                    </p>
                                    <asp:Button ID="Button6" CssClass="butoespopup" Width="25%" runat="server" Text="Ok" OnClick="Button6_Click" />
                                </div>

                                <br />
                                <br />
                                <asp:Button ID="Button3" CssClass="btn" runat="server" OnClick="Button3_Click" Text="Confirmar" />
                            </div>
                            <div class="custompopup" id="div1" runat="server" visible="false">
                                <p>
                                    <asp:Label ID="Label9" runat="server" Text="Data expiração"></asp:Label>
                                    <asp:TextBox ID="TextBox8" runat="server" TextMode="Date"></asp:TextBox>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="0">Ativo</asp:ListItem>
                                        <asp:ListItem Value="1">Demo</asp:ListItem>
                                        <asp:ListItem Value="2">Cancelada</asp:ListItem>
                                    </asp:DropDownList>
                                </p>
                                <asp:Button ID="Button7" CssClass="butoespopup" Width="25%" runat="server" Text="Ok" OnClick="Button7_Click" />
                            </div>
                            <div class="custompopup" id="div2" runat="server" visible="false">
                                <p>
                                    <asp:Label ID="Label8" runat="server" Text="Data expiração"></asp:Label>
                                    <asp:TextBox ID="TextBox7" runat="server" TextMode="Date"></asp:TextBox>
                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                        <asp:ListItem Value="0">Ativo</asp:ListItem>
                                        <asp:ListItem Value="1">Demo</asp:ListItem>
                                        <asp:ListItem Value="2">Cancelada</asp:ListItem>
                                    </asp:DropDownList>
                                </p>
                                <asp:Button ID="Button8" CssClass="butoespopup" Width="25%" runat="server" Text="Ok" OnClick="Button8_Click" />
                            </div>

                            <div class="custompopup" id="div3" runat="server" visible="false">
                                <p>
                                    <asp:Label ID="Label10" runat="server" Text="Tem a certeza que quer eliminar esta conta?"></asp:Label>
                                </p>
                                <asp:Button ID="Button9" CssClass="butoespopup" Width="25%" runat="server" Text="Sim" OnClick="Button9_Click" />
                                <asp:Button ID="Button10" CssClass="butoespopup" Width="25%" runat="server" Text="Não" OnClick="Button10_Click" />
                            </div>

                            <div class="custompopup" id="div4" runat="server" visible="false">
                                <p>
                                    <asp:Label ID="Label11" runat="server" Text="Tem a certeza que quer eliminar esta conta?"></asp:Label>
                                </p>
                                <asp:Button ID="Button11" CssClass="butoespopup" Width="25%" runat="server" Text="Sim" OnClick="Button11_Click" />
                                <asp:Button ID="Button12" CssClass="butoespopup" Width="25%" runat="server" Text="Não" OnClick="Button12_Click" />
                            </div>
                        </div>


                    </div>
                    <div class="col-12 col-md-3  order-0 order-md-1">
                        <div class="admin-div">
                            <div class="admin-innerDiv">
                                <ul style="list-style-type: none;" class="h-100 pl-0">
                                    <li>
                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Registos" />
                                    </li>
                                    <li>
                                        <asp:Button ID="Button2" runat="server" Text="Perfil (Default)" OnClick="Button2_Click" />
                                    </li>

                                </ul>


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
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN"
    crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"
    crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"
    crossorigin="anonymous"></script>
<script src="../OwlCarousel/dist/owl.carousel.min.js"></script>
<script src="../JS/carrousels.js"></script>
<script src="https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/markerclusterer.js">
</script>
<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDeVOiLBWezK_PJE24rPdwB1BAOLNowNfQ&libraries=places&callback=initAutocomplete"
    async defer></script>
</html>
