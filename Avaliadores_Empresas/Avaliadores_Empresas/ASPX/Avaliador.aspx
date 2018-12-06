<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Avaliador.aspx.cs" Inherits="Avaliadores_Empresas.Avaliador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link runat="server" rel="icon" href="../Imagens/Logos/favicon.ico" type="image/x-icon" />

    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,500,600,700" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"
        crossorigin="anonymous">

    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.carousel.css" />
    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.theme.default.min.css" />

    <link rel="stylesheet" type="text/css" href="../CSS/Aval_style.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

    <link rel="stylesheet" href="../CSS/Main.css">
    <title>Avaliadores </title>
    <style>

    </style>
</head>

<body>
    <form id="form1" runat="server">
        <header>
            <nav class="navbar navbar-expand-lg navbar-dark fixed-top">
                <a class="navbar-brand" href="../HomePage">
                    <img src="../images/Logos/favicon.ico" width="40" height="40" alt="">
                </a>

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".dual-collapse2"
                    aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
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

        <div>
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

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div class="container-fluid">
                <div class="row main_div">
                    <div class="col-9">
                        <div class="container">
                            <asp:Panel ID="DivPerfil" runat="server" Visible="true">
                                <div class="divPerfil_inner">
                                    <div class="row">
                                        <div class="container">
                                            <div class="col-xl-12">
                                                <h1>Perfil </h1>
                                                <hr class="mt-0" />
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-6">
                                            <div class="row">
                                                <div class="col-4">
                                                    <p>nome </p>
                                                </div>
                                                <div class="col">
                                                    <asp:TextBox ID="TxtPerfilNome" class="form-control" placeholder="Nome"
                                                        runat="server"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <p>e-mail </p>
                                                </div>
                                                <div class="col">
                                                    <asp:TextBox ID="TxtPerfilEmail" placeholder="E-mail" class="form-control"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <p>telemovel </p>
                                                </div>
                                                <div class="col">
                                                    <asp:TextBox ID="TxtPerfilTelemovel" placeholder="Telemovel" class="form-control"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <p>Nº Registo </p>
                                                </div>
                                                <div class="col">
                                                    <asp:TextBox ID="TxtPerfilNRegisto" placeholder="Numero de Registo"
                                                        class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <p>Morada </p>
                                                </div>
                                                <div class="col">
                                                    <asp:TextBox ID="TxtPerfilMorada" placeholder="Morada" class="form-control"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <p>Estado de Licenciamento:</p>
                                                </div>
                                                <div class="col">
                                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <p>Estado de Licenciamento:</p>
                                                </div>
                                                <div class="col">
                                                    <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True" TextMode="Date"></asp:TextBox>
                                                    <asp:TextBox ID="TextBox6" runat="server" ReadOnly="True" TextMode="Date"
                                                        Visible="False"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <asp:Button ID="Button6" runat="server"  CssClass="btn" OnClick="Button6_Click"
                                                        Text="Renovar por mais 30 dias (10€)" />
                                                    &nbsp;
                                                    <asp:Button ID="Button16" runat="server"  CssClass="btn" OnClick="Button16_Click"
                                                        Text="Renovar por mais 1 ano (100€)" />
                                                </div>
                                                <div class="col">
                            
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-6">
                                            <asp:DropDownList ID="dpPerfilArea" runat="server"></asp:DropDownList>
                                            <asp:Button ID="BtnPerfilDropdown" CssClass="btn btn-dark" runat="server"
                                                Text="Add" OnClick="BtnPerfilDropdown_Click" />
                                            <br />
                                            <asp:ListBox ID="LBoxPerfilArea" runat="server"></asp:ListBox>
                                            <br />
                                            <asp:Button ID="Button1" CssClass="btn btn-dark" runat="server" OnClick="Button1_Click"
                                                Style="display: none;" Text="Apagar Área Selecionada" />
                                            <script>
                                                $("#LBoxPerfilArea").keyup(function (e) {
                                                    if (e.which == 46) {
                                                        $("#Button1").click();
                                                    }
                                                });
                                            </script>
                                            <br />
                                            <div class="custompopup" id="divThankYou" runat="server" visible="false">
                                                <div class="row">
                                                    <div class="col-xl-12">
                                                        <asp:Label ID="lblmessage" runat="server">Password Antiga</asp:Label>
                                                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <asp:Button ID="Button3" CssClass="butoespopup" Width="25%" runat="server"
                                                    Text="Ok" OnClick="Button3_Click" />
                                                <asp:Button ID="Button12" runat="server" Text="Voltar" OnClick="Button12_Click" />
                                            </div>
                                            <!-- divThankYou -->

                                            <div class="custompopup" id="divNovaPass" runat="server" visible="false">
                                                <div class="row">
                                                    <div class="col-xl-12">
                                                        <asp:Label ID="Label2" runat="server" Text="Nova Password"></asp:Label>
                                                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xl-12">
                                                        <asp:Label ID="Label3" runat="server" Text="Confirmar Password"></asp:Label>
                                                        <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <asp:Button ID="Button2" CssClass="butoespopup" Width="25%" runat="server"
                                                    Text="Ok" OnClick="Button2_Click" />
                                            </div>
                                            <!-- divNovaPass -->

                                            <asp:Button ID="Button4" runat="server" Text="Mudar Password" CssClass="btn btn-change-pswd"
                                                OnClick="Button1_Click1" />

                                            <br />

                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                        </div>
                                        <div class="container">
                                            <div class="col-xl-12">
                                                <asp:Button ID="BtnPerfilConfirmar" CssClass="btn" runat="server" Text="Confirmar"
                                                    OnClick="BtnPerfilConfirmar_Click" />

                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </asp:Panel>
                            <!-- DivPerfil -->

                            <asp:Panel ID="DivAvaliacoesDisponiveis" CssClass="DivBtn" runat="server" Visible="False">
                                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField SelectText="Concorrer" ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                                <div class="custompopup" id="div2" runat="server" visible="false">
                                    <p>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </p>
                                    <asp:Button ID="Button7" CssClass="butoespopup" runat="server" Text="Concorrer"
                                        OnClick="Button7_Click" />
                                    <asp:Button ID="Button14" runat="server" Text="Voltar" OnClick="Button14_Click" />
                                </div>
                                <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                                    OnRowCommand="GridView2_RowCommand">
                                    <Columns>
                                        <asp:ButtonField CommandName="Select2" Text="Concorrer" />
                                        <asp:CommandField SelectText="Ver Avaliações" ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                                <div class="custompopup" id="div3" runat="server" visible="false">
                                    <p>
                                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                        <asp:ListBox ID="ListBox1" runat="server" Visible="False"></asp:ListBox>
                                    </p>
                                    <asp:Button ID="Button8" CssClass="butoespopup" runat="server" Text="Concorrer"
                                        OnClick="Button8_Click" />
                                    <asp:Button ID="Button15" runat="server" Text="Voltar" OnClick="Button15_Click" />
                                </div>
                                <br />
                                <asp:ListBox ID="ListBox2" runat="server" Visible="False"></asp:ListBox>
                                <div class="custompopup" id="div1" runat="server" visible="false">
                                    <p>
                                        <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                                    </p>
                                    <asp:Button ID="Button5" CssClass="butoespopup" Width="25%" runat="server" Text="Voltar"
                                        OnClick="Button5_Click" />
                                </div>
                                <asp:ListBox ID="ListBox3" runat="server" Visible="False"></asp:ListBox>
                                <asp:ListBox ID="ListBox4" runat="server" Visible="False"></asp:ListBox>
                                <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick1">
                                </asp:Timer>
                                <asp:ListBox ID="ListBox5" runat="server" Visible="False"></asp:ListBox>
                            </asp:Panel>
                            <!-- DivAvaliacoesDisponiveis -->

                            <asp:Panel ID="DivTrabalhosRealizados" CssClass="DivBtn" runat="server" Visible="False">
                                <asp:GridView ID="GridView7" runat="server"></asp:GridView>
                                <br />
                                <asp:GridView ID="GridView8" runat="server" OnRowCommand="GridView8_RowCommand">
                                    <Columns>
                                        <asp:ButtonField CommandName="Select2" Text="Ver avaliações" />
                                    </Columns>
                                </asp:GridView>
                                <asp:ListBox ID="ListBox7" runat="server" Visible="False"></asp:ListBox>
                            </asp:Panel>
                            <!-- DivTrabalhosRealizados -->

                            <asp:Panel ID="DivAvaliacoes" CssClass="DivBtn" runat="server" Visible="False">
                                <asp:GridView ID="GridView4" runat="server" OnSelectedIndexChanged="GridView4_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField SelectText="Avaliar" ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <asp:GridView ID="GridView5" runat="server" OnRowCommand="GridView5_RowCommand"
                                    OnSelectedIndexChanged="GridView5_SelectedIndexChanged">
                                    <Columns>
                                        <asp:ButtonField CommandName="Select2" Text="Ver avaliações" />
                                        <asp:CommandField SelectText="Avaliar" ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                                <asp:ListBox ID="ListBox6" runat="server" Visible="False"></asp:ListBox>
                                <div class="custompopup" id="div4" runat="server" visible="false">
                                    <p>
                                        <asp:GridView ID="GridView6" runat="server"></asp:GridView>
                                    </p>
                                    <asp:Button ID="Button9" CssClass="butoespopup" Width="25%" runat="server" Text="Voltar"
                                        OnClick="Button9_Click" />
                                </div>
                                <asp:ListBox ID="ListBox10" runat="server"></asp:ListBox>
                                <asp:ListBox ID="ListBox11" runat="server" Visible="False"></asp:ListBox>
                                <asp:ListBox ID="ListBox12" runat="server" Visible="False"></asp:ListBox>
                                <asp:ListBox ID="ListBox13" runat="server"></asp:ListBox>
                            </asp:Panel>
                            <!-- DivAvaliacoes -->

                            <asp:Panel ID="DivRanking" CssClass="DivBtn" runat="server" Visible="False">
                                <asp:Label ID="Label11" runat="server" Text="Empresa"></asp:Label>
                                <br />
                                <asp:ListBox ID="ListBox8" runat="server"></asp:ListBox>
                                <br />
                                <br />
                                <asp:Label ID="Label12" runat="server" Text="Avaliador"></asp:Label>
                                <br />
                                <asp:ListBox ID="ListBox9" runat="server"></asp:ListBox>

                            </asp:Panel>
                            <!-- DivRanking -->
                            <div class="custompopup" id="div5" runat="server" visible="false">
                                <p>
                                    <asp:GridView ID="GridView9" runat="server"></asp:GridView>
                                </p>
                                <asp:Button ID="Button10" CssClass="butoespopup" Width="25%" runat="server" Text="Voltar"
                                    OnClick="Button10_Click" />
                            </div>
                            <div class="custompopup" id="div6" runat="server" visible="false">
                                <p>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="Label7" runat="server" Text="Trato"></asp:Label>
                                            <ajaxToolkit:Rating ID="Rating1" runat="server" StarCssClass="starRating"
                                                FilledStarCssClass="FilledStars" EmptyStarCssClass="EmptyStars"
                                                WaitingStarCssClass="WatingStars" CurrentRating="3"></ajaxToolkit:Rating>

                                            <asp:Label ID="Label8" runat="server" Text="Qualidade"></asp:Label>
                                            <ajaxToolkit:Rating ID="Rating2" runat="server" StarCssClass="starRating"
                                                FilledStarCssClass="FilledStars" EmptyStarCssClass="EmptyStars"
                                                WaitingStarCssClass="WatingStars" CurrentRating="3"></ajaxToolkit:Rating>

                                            <asp:Label ID="Label9" runat="server" Text="Cumprimento de prazo"></asp:Label>
                                            <ajaxToolkit:Rating ID="Rating3" runat="server" StarCssClass="starRating"
                                                FilledStarCssClass="FilledStars" EmptyStarCssClass="EmptyStars"
                                                WaitingStarCssClass="WatingStars" CurrentRating="3"></ajaxToolkit:Rating>

                                            <asp:Label ID="Label10" runat="server" Text="Outro"></asp:Label>
                                            <ajaxToolkit:Rating ID="Rating4" runat="server" StarCssClass="starRating"
                                                FilledStarCssClass="FilledStars" EmptyStarCssClass="EmptyStars"
                                                WaitingStarCssClass="WatingStars" CurrentRating="3"></ajaxToolkit:Rating>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </p>
                                <asp:Button ID="Button11" CssClass="butoespopup" Width="25%" runat="server" Text="Avaliar"
                                    OnClick="Button11_Click" />
                                <asp:Button ID="Button13" runat="server" Text="Voltar" OnClick="Button13_Click" />
                            </div>
                        </div>

                    </div>
                    <!-- col-8 -->
                    <div class="col-3">
                        <div class="Aval_div">
                            <div class="Aval_innerDiv">
                                <ul style="list-style-type: none;">
                                    <li>
                                        <asp:Button ID="BtnPerfil" CssClass="" runat="server" Text="Perfil" OnClick="BtnPerfil_Click" />
                                    </li>
                                    <li>
                                        <asp:Button ID="BtnAvaliacoesDisponiveis" CssClass="" runat="server" Text="Trabalhos Disponiveis"
                                            OnClick="BtnAvaliacoesDisponiveis_Click" />
                                    </li>
                                    <li>
                                        <asp:Button ID="BtnTrabalhosRealizados" CssClass="" runat="server" Text="Trabalhos ativos"
                                            OnClick="BtnTrabalhosRealizados_Click" />
                                    </li>
                                    <li>
                                        <asp:Button ID="BtnAvaliacoes" CssClass="" runat="server" Text="Avaliações"
                                            OnClick="BtnAvaliacoes_Click" />
                                    </li>
                                    <li>
                                        <asp:Button ID="BtnRanking" CssClass="" runat="server" Text="Ranking" OnClick="BtnRanking_Click" />
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

</html>