﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empresa.aspx.cs" Inherits="Avaliadores_Empresas.Empresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link runat="server" rel="icon" href="Imagens/Logos/favicon.ico" type="image/x-icon" />
    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,500,600,700" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="stylesheet/style_empresa.css" />
    <title>Empresa</title>

</head>
<body>
    <form id="form1" runat="server">
        <header>
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
                            <a class="nav-link " href="../sobreNos/SobreNos.aspx">Somos Nos</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link " href="../R_Avaliador/Registar_Avaliadores.aspx">Avaliador</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link ativo" href="Empresa.aspx">Empresa</a>
                        </li>
                        <li class="nav-item ">
                            <a class="nav-link" href="../Contactos/Contactos.aspx">Contactos</a>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-log-out" style="padding-right: 2px"></span>Logout</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>

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
        <div class="Emp_div">
            <div class="Emp_innerDiv">
                <ul style="list-style-type: none;">
                    <li>
                        <asp:Button ID="BtnPerfil" runat="server" Text="Perfil" OnClick="BtnPerfil_Click" />
                    </li>
                    <li>
                        <asp:Button ID="BtnPesquisaAvaliacoes" runat="server" Text="Pesquisa Avaliadores" OnClick="BtnPesquisaAvaliacoes_Click" />
                    </li>
                    <li>
                        <asp:Button ID="BtnPublicarPedidoAvaliacao" runat="server" Text="Publicar Pedido Avaliacao" OnClick="BtnPublicarPedidoAvaliacao_Click" />
                    </li>
                    <li>
                        <asp:Button ID="BtnMinhasAvaliacoes" runat="server" Text="Meus Trabalhos" OnClick="BtnMinhasAvaliacoes_Click" />
                    </li>
                    <li>
                        <asp:Button ID="BtnLicenca" runat="server" Text="Licença" OnClick="BtnLicenca_Click" />
                    </li>
                    <li>
                        <asp:Button ID="BtnAvaliacoes" runat="server" Text="Avaliações" OnClick="BtnAvaliacoes_Click" />
                    </li>
                    <li>
                        <asp:Button ID="BtnRanking" runat="server" Text="Ranking" OnClick="BtnRanking_Click" />
                    </li>
                </ul>


            </div>

        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row main_div">
            <div class="col-xl-10 col-12">
                <div class="container">
                    <asp:Panel ID="DivPerfil" CssClass="DivBtn" runat="server" Visible="False">
                        <div class="divPerfil_inner">
                            <div class="row">
                                <div class="col-xl-12">
                                    <h1>Perfil </h1>
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xl-6">
                                    <p>nome </p>
                                </div>
                                <div class="col-xl-6">
                                    <asp:TextBox ID="TBoxPerfilNome" placeholder="Nome" CssClass="form-control" runat="server"></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xl-6">
                                    <p>e-mail </p>
                                </div>
                                <div class="col-xl-6">
                                    <asp:TextBox ID="TBoxPerfilEmail" placeholder="Email" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xl-6">
                                    <p>telemovel </p>
                                </div>
                                <div class="col-xl-6">
                                    <asp:TextBox ID="TBoxPerfilTelefone" placeholder="Telefone" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xl-6">
                                    <p>Nº Registo </p>
                                </div>
                                <div class="col-xl-6">
                                    <asp:TextBox ID="TBoxPerfilNRegisto" placeholder="Número de Registo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xl-6">
                                    <p>Morada </p>
                                </div>
                                <div class="col-xl-6">
                                    <asp:TextBox ID="TBoxPerfilMorada" placeholder="Morada" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xl-12">
                                    <asp:Button ID="BtnPerfilConfirmar" runat="server" Text="Confirmar" OnClick="BtnPerfilConfirmar_Click" />

                                </div>

                            </div>



                            <br />
                            <div class="custompopup" id="divThankYou" runat="server" visible="false">
                                <p>
                                    <asp:Label ID="lblmessage" runat="server">Password Antiga</asp:Label>
                                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                                </p>
                                <asp:Button ID="Button3" CssClass="butoespopup" Width="25%" runat="server" Text="Ok" OnClick="Button3_Click" />
                                <asp:Button ID="Button14" runat="server" Text="Voltar" OnClick="Button14_Click" />
                            </div>
                            <div class="custompopup" id="divNovaPass" runat="server" visible="false">
                                <p>
                                    <asp:Label ID="Label2" runat="server" Text="Nova Password"></asp:Label>
                                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                                    <br />
                                    <asp:Label ID="Label3" runat="server" Text="Confirmar Password"></asp:Label>
                                    <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
                                </p>
                                <asp:Button ID="Button2" CssClass="butoespopup" Width="25%" runat="server" Text="Ok" OnClick="Button2_Click" />
                            </div>
                            <asp:Button ID="Button1" runat="server" Text="Mudar Password" OnClick="Button1_Click1" />

                            <br />

                            <br />
                            <br />

                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="DivPesquisaAvaliacoes" CssClass="DivBtn" runat="server" Visible="False">

                        <input id="LatitudeDragend" type="hidden" value="0" runat="server" />
                        <input id="LongitudeDragend" type="hidden" value="0" runat="server" />
                        <input id="ZoomDragend" type="hidden" value="0" runat="server" />
                        <input id="Latlnglat" type="hidden" runat="server" />
                        <input id="Latlnglng" type="hidden" runat="server" />
                        <input id="Hidden1" type="hidden" runat="server" />
                        <input id="Hidden2" type="hidden" runat="server" />
                        <input id="Hidden3" type="hidden" runat="server" />

                        <asp:TextBox ID="TextBox1" runat="server" onkeydown="return (event.keyCode!=13);"></asp:TextBox>

                        <asp:TextBox runat="server" ID="pacinput" class="form-control" type="text" placeholder="Find Address of conflict &#xF002;" Style="display: none" AutoPostBack="True"></asp:TextBox>
                        <div id="googleMapZOOM" style="width: 100%; height: 300px;"></div>




                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>

                        <table id="tbl" width="60%" style="visibility: hidden;" border="1">
                            <tr>
                                <td>Nome</td>
                            </tr>
                        </table>
                        <table id="tblcontatos" style="visibility: hidden;" width="60%" border="1">
                            <tr>
                                <td>Nome</td>
                                <td>Contatos</td>
                                <td>Password</td>
                            </tr>
                        </table>


                    </asp:Panel>
                    <asp:Panel ID="DivPublicarPedidoAvaliacao" CssClass="DivBtn" runat="server" Visible="False">

                        <asp:Panel ID="Panel2" runat="server">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="col-sm-4">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:Button ID="Button6" CssClass="btn_numeros btn btn-dark" runat="server" Text="1" OnClick="Button6_Click" />

                                            </div>

                                        </div>
                                        <div class="row" style="padding: 20px;">
                                            <div class="speech-bubble">
                                                <p>Inserir </p>
                                                <p>uma </p>
                                                <p>avaliação </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:Button ID="Button7" CssClass="btn_numeros btn btn-dark" runat="server" Text="2" OnClick="Button7_Click" />
                                            </div>
                                        </div>
                                        <div class="row" style="padding: 20px;">
                                            <div class="speech-bubble">
                                                <p>Importar </p>
                                                <p>várias </p>
                                                <p>avaliações </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:Button ID="Button8" CssClass="btn_numeros btn btn-dark" runat="server" Text="3" OnClick="Button8_Click" />
                                            </div>
                                        </div>
                                        <div class="row" style="padding: 20px;">
                                            <div class="speech-bubble">
                                                <p>Importar </p>
                                                <p>pacote de  </p>
                                                <p>avaliações </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                    </asp:Panel>

                    <asp:Panel ID="DivMinhasAvaliacoes" CssClass="DivBtn" runat="server" Visible="False">
                        <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField SelectText="Ver Avaliadores" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>

                        <div class="custompopup" id="div2" runat="server" visible="false">
                            <p>
                                <asp:ListBox ID="ListBox5" runat="server" Visible="False"></asp:ListBox>
                                <asp:ListBox ID="ListBox6" runat="server" Visible="False"></asp:ListBox>
                                <asp:GridView ID="GridView5" runat="server" OnSelectedIndexChanged="GridView5_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField SelectText="Escolher" ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </p>
                            <asp:Button ID="Button9" CssClass="butoespopup" Width="25%" runat="server" Text="Voltar" OnClick="Button9_Click" />
                        </div>

                        <br />
                        <asp:GridView ID="GridView3" runat="server" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" OnRowCommand="GridView3_RowCommand">
                            <Columns>
                                <asp:CommandField SelectText="Ver Avaliações" ShowSelectButton="True" />
                                <asp:ButtonField CommandName="Select2" Text="Ver Avaliadores" />
                            </Columns>
                        </asp:GridView>
                        <div class="custompopup" id="div3" runat="server" visible="false">
                            <p>
                                <asp:ListBox ID="ListBox1" runat="server" Visible="False"></asp:ListBox>
                                <asp:ListBox ID="ListBox4" runat="server" Visible="False"></asp:ListBox>
                                <asp:GridView ID="GridView6" runat="server" OnSelectedIndexChanged="GridView6_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField SelectText="Escolher" ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </p>
                            <asp:Button ID="Button10" CssClass="butoespopup" runat="server" Text="Voltar" OnClick="Button10_Click" />
                        </div>
                        <div class="custompopup" id="div4" runat="server" visible="false">
                            <p>
                                <asp:Label ID="Label7" runat="server" Text="Escolheu com sucesso o avaliador"></asp:Label>
                                <asp:GridView ID="GridView7" runat="server"></asp:GridView>
                            </p>
                            <asp:Button ID="Button11" CssClass="butoespopup" runat="server" Text="Voltar" OnClick="Button11_Click" />
                        </div>
                        <br />
                        <asp:ListBox ID="ListBox2" runat="server" Visible="false"></asp:ListBox>
                        <div class="custompopup" id="div1" runat="server" visible="false">
                            <p>
                                <asp:GridView ID="GridView4" runat="server"></asp:GridView>
                            </p>
                            <asp:Button ID="Button5" CssClass="butoespopup" Width="25%" runat="server" Text="Voltar" OnClick="Button5_Click" />
                        </div>
                        <asp:ListBox ID="ListBox3" runat="server" Visible="False"></asp:ListBox>
                        <asp:ListBox ID="ListBox7" runat="server" Visible="False"></asp:ListBox>
                        <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick1">
                        </asp:Timer>
                    </asp:Panel>
                    <asp:Panel ID="DivLicenca" CssClass="DivBtn" runat="server" Visible="False">
                        <asp:Label ID="Label4" runat="server">Estado de Licenciamento:</asp:Label>
                        <br />
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label6" runat="server">Final da Licença:</asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True" TextMode="Date"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBox6" runat="server" ReadOnly="True" TextMode="Date" Visible="False"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="Button4" runat="server" Text="Pagar" OnClick="Button4_Click" />
                        &nbsp;
                                                                    <asp:Button ID="Button16" runat="server" OnClick="Button16_Click" Text="Pagar ano" />
                    </asp:Panel>
                    <asp:Panel ID="DivAvaliacoes" CssClass="DivBtn" runat="server" Visible="False">
                        <asp:GridView ID="GridView8" runat="server" OnSelectedIndexChanged="GridView8_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField SelectText="Avaliar" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>

                        <div class="custompopup" id="div6" runat="server" visible="false">
                            <p>
                            </p>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label8" runat="server" Text="Trato"></asp:Label>
                                    <ajaxToolkit:Rating ID="Rating1" runat="server" CurrentRating="3" EmptyStarCssClass="EmptyStars" FilledStarCssClass="FilledStars" StarCssClass="starRating" WaitingStarCssClass="WatingStars">
                                    </ajaxToolkit:Rating>
                                    <asp:Label ID="Label9" runat="server" Text="Qualidade"></asp:Label>
                                    <ajaxToolkit:Rating ID="Rating2" runat="server" CurrentRating="3" EmptyStarCssClass="EmptyStars" FilledStarCssClass="FilledStars" StarCssClass="starRating" WaitingStarCssClass="WatingStars">
                                    </ajaxToolkit:Rating>
                                    <asp:Label ID="Label10" runat="server" Text="Cumprimento de prazo"></asp:Label>
                                    <ajaxToolkit:Rating ID="Rating3" runat="server" CurrentRating="3" EmptyStarCssClass="EmptyStars" FilledStarCssClass="FilledStars" StarCssClass="starRating" WaitingStarCssClass="WatingStars">
                                    </ajaxToolkit:Rating>
                                    <asp:Label ID="Label11" runat="server" Text="Outro"></asp:Label>
                                    <ajaxToolkit:Rating ID="Rating4" runat="server" CurrentRating="3" EmptyStarCssClass="EmptyStars" FilledStarCssClass="FilledStars" StarCssClass="starRating" WaitingStarCssClass="WatingStars">
                                    </ajaxToolkit:Rating>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <p>
                            </p>
                            <asp:Button ID="Button13" runat="server" CssClass="butoespopup" OnClick="Button13_Click" Text="Avaliar" />
                            <asp:Button ID="Button15" runat="server" Text="Voltar" OnClick="Button15_Click" />
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                        </div>
                        <br />
                        <asp:GridView ID="GridView9" runat="server" OnRowCommand="GridView5_RowCommand" OnSelectedIndexChanged="GridView9_SelectedIndexChanged">
                            <Columns>
                                <asp:ButtonField CommandName="Select2" Text="Ver avaliações" />
                                <asp:CommandField SelectText="Avaliar" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:ListBox ID="ListBox8" runat="server" Visible="False"></asp:ListBox>
                        <div class="custompopup" id="div5" runat="server" visible="false">
                            <p>
                                <asp:GridView ID="GridView10" runat="server"></asp:GridView>
                            </p>
                            <asp:Button ID="Button12" CssClass="butoespopup" Width="25%" runat="server" Text="Voltar" OnClick="Button12_Click" />
                        </div>
                        <asp:ListBox ID="ListBox11" runat="server"></asp:ListBox>
                        <asp:ListBox ID="ListBox12" runat="server" Visible="False"></asp:ListBox>
                        <asp:ListBox ID="ListBox13" runat="server"></asp:ListBox>
                        <asp:ListBox ID="ListBox14" runat="server"></asp:ListBox>
                    </asp:Panel>
                     <asp:Panel ID="DivRanking" CssClass="DivBtn" runat="server" Visible="False">
                            <asp:Label ID="Label12" runat="server" Text="Empresa"></asp:Label>
                            <br />
                            <asp:ListBox ID="ListBox9" runat="server"></asp:ListBox>
                            <br />
                            <br />
                            <asp:Label ID="Label13" runat="server" Text="Avaliador"></asp:Label>
                            <br />
                            <asp:ListBox ID="ListBox10" runat="server"></asp:ListBox>

                        </asp:Panel>

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
<script src="https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/markerclusterer.js">
</script>
<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDeVOiLBWezK_PJE24rPdwB1BAOLNowNfQ&libraries=places&callback=initAutocomplete"
    async defer></script>
<script>
 

    function initAutocomplete() {
                                    var markers = [
                                        <asp:Repeater ID="rptMarkers" runat="server">
                                            <ItemTemplate>
        {
            "id": '<%# Eval("id") %>',
               "lat": '<%# Eval("Longitude") %>',
                                "lng": '<%# Eval("Latitude") %>',
							    "NomeCidade": '<%# Eval("Nome") %>',
                                "NomeAvaliador": '<%# Eval("Nome2") %>',
                                "Email": '<%# Eval("Email") %>',
                                "Telemovel": '<%# Eval("Telemovel") %>',
                                "idAvaliador": '<%# Eval("idAvaliador") %>',
}
                            </ItemTemplate>
    <SeparatorTemplate>
        ,
                            </SeparatorTemplate>
                                        </asp:Repeater >
                                           
                    ];
var myLatlng = "";
var data;
var locations = []
for (i = 0; i < markers.length; i++) {
    data = markers[i]
    myLatlng = new google.maps.LatLng(data.lat, data.lng);
    locations.push(myLatlng);
}

var LatitudeDragendvar2 = <%=LatitudeDragend.ClientID %>;
var LongitudeDragendvar2 = <%=LongitudeDragend.ClientID %>;
var ZoomDragendvar = <%=ZoomDragend.ClientID %>;
if (LatitudeDragendvar2.value == "0") {
    var mapProp = {
        center: { lat: 39.47436540986871, lng: -8.186874453125029 },
        zoom: 6,
        styles: [{ "featureType": "administrative.country", "elementType": "geometry", "stylers": [{ "visibility": "simplified" }, { "hue": "#ff0000" }] }, { "featureType": "administrative.province", "elementType": "geometry", "stylers": [{ "visibility": "on" }, { "hue": "#ff0000" }, { "invert_lightness": true }] }],

    };
}
else {
    var mapProp = {
        center: { lat: parseFloat(LatitudeDragendvar2.value), lng: parseFloat(LongitudeDragendvar2.value) },
        zoom: parseFloat(ZoomDragendvar.value),
        styles: [{ "featureType": "administrative.country", "elementType": "geometry", "stylers": [{ "visibility": "simplified" }, { "hue": "#ff0000" }] }, { "featureType": "administrative.province", "elementType": "geometry", "stylers": [{ "visibility": "on" }, { "hue": "#ff0000" }, { "invert_lightness": true }] }],

    };
}



var map = new google.maps.Map(document.getElementById("googleMapZOOM"), mapProp);
map.addListener('bounds_changed', function () {

    var LatitudeDragendvar = <%=LatitudeDragend.ClientID %>;
    LatitudeDragendvar.value = map.getCenter().lat();

    var LongitudeDragendvar = <%=LongitudeDragend.ClientID %>;
    LongitudeDragendvar.value = map.getCenter().lng();
    var ZoomDragendvar = <%=ZoomDragend.ClientID %>;
    ZoomDragendvar.value = map.getZoom();
});
// Add some markers to the map.
// Note: The code uses the JavaScript Array.prototype.map() method to
// create an array of markers based on a given "locations" array.
// The map() method here has nothing to do with the Google Maps API.
var markers2 = locations.map(function (location, i) {
    return new google.maps.Marker({
        position: location
    });
});

for (var i = 0; i < markers2.length; i++) {
    data = markers[i];
    (function (i, data) {
        google.maps.event.addListener(markers2[i], 'click', function () {
            document.getElementById("tbl").style.visibility = "visible";

            while (tbl.children[0].hasChildNodes && tbl.children[0].children.length != 1) {
                tbl.children[0].removeChild(tbl.children[0].lastChild);
            }

            var tr = document.createElement("tr");
            tr.id = data.id;


            var td = document.createElement("td");

            td.innerText = data.NomeAvaliador;
            td.value = data.idAvaliador;

            tr.appendChild(td);



            tr.style.backgroundColor = "lightgrey";

            //AddCidades

            tbl.children[0].appendChild(tr);

            var idvariavelinc = "";
            var Nomevariavelinc = "";

            idvariavelinc += data.id;
            Nomevariavelinc += data.NomeAvaliador;

            var hidden1 = <%=Hidden2.ClientID %>;
            hidden1.value = idvariavelinc;

            var hidden2 = <%=Hidden1.ClientID %>;
            hidden2.value = Nomevariavelinc;
        });
    })(i, data);
}


// Add a marker clusterer to manage the markers.
var markerCluster = new MarkerClusterer(map, markers2,
    { imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m' });


google.maps.event.addListener(markerCluster, 'clusterclick', function (cluster) {
    document.getElementById("tbl").style.visibility = "visible";


    while (tbl.children[0].hasChildNodes && tbl.children[0].children.length != 1) {
        tbl.children[0].removeChild(tbl.children[0].lastChild);
    }

    var content = '';

    // Convert lat/long from cluster object to a usable MVCObject
    var info = new google.maps.MVCObject;
    info.set('position', cluster.center_);

    //----
    //Get markers
    var markers3 = cluster.getMarkers();

    var titles = "";
    //Get all the titles
    var myArray = [];
    var myArrayNome = [];
    var myArrayId = [];
    var idvariavelinc = "";
    var Nomevariavelinc = "";

    for (var i = 0; i < markers3.length; i++) {
        for (z = 0; z < markers.length; z++) {
            var data = markers[z]
            myLatlng = new google.maps.LatLng(data.lat, data.lng);

            var strngmyLatlng = myLatlng;
            var strngmarkers3 = markers3[i].getPosition();

            var pesquisa = strngmarkers3.toString();
            pesquisa += data.NomeAvaliador;

            if (strngmyLatlng.toString() == strngmarkers3.toString()) {
                if (myArrayNome.indexOf(pesquisa) === -1) {
                    var opt = document.createElement("option");
                    opt.text = data.NomeCidade;
                    opt.value = data.id;

                    myArrayNome.push(pesquisa);
                    idvariavelinc += data.id + ",";
                    Nomevariavelinc += data.NomeAvaliador + ",";

                    if (myArrayId.indexOf(data.idAvaliador) === -1) {
                        myArrayId.push(data.idAvaliador);

                        var tr = document.createElement("tr");
                        tr.id = data.id;


                        var td = document.createElement("td");

                        td.innerText = data.NomeAvaliador;
                        td.value = data.idAvaliador;

                        tr.appendChild(td);

                        tr.style.backgroundColor = "lightgrey";



                        //Addcidades 

                        tbl.children[0].appendChild(tr);

                    }
                }
            }
            var hidden1 = <%=Hidden2.ClientID %>;
            hidden1.value = idvariavelinc;

            var hidden2 = <%=Hidden1.ClientID %>;
            hidden2.value = Nomevariavelinc;
        }

        titles += markers3[i].getPosition() + "\n";
    }

    //----




}); var markers2 = [];



var marker2;

google.maps.event.addListener(map, 'tilesloaded', function () {
    var lat2 = '<%= Latlnglat.ClientID %>';
    var lng2 = '<%= Latlnglng.ClientID %>';
    if (document.getElementById(lat2).value != "" && document.getElementById(lng2).value != "") {
        var myLatlng = new google.maps.LatLng(document.getElementById(lat2).value, document.getElementById(lng2).value);
        markers2.forEach(function (marker2) {
            marker2.setMap(null);
        });
        marker2.setPosition(myLatlng);
    }
});

function placeMarker(location) {
    markers2.forEach(function (marker2) {
        marker2.setMap(null);
    });
    marker2.setPosition(location);

}

// Create the search box and link it to the UI element.
var input = document.getElementById('TextBox1');

var searchBox = new google.maps.places.SearchBox(input);

// Bias the SearchBox results towards current map's viewport.
map.addListener('bounds_changed', function () {
    searchBox.setBounds(map.getBounds());
});

var markers2 = [];
// Listen for the event fired when the user selects a prediction and retrieve
// more details for that place.
searchBox.addListener('places_changed', function () {
    var places = searchBox.getPlaces();

    if (places.length == 0) {
        return;
    }

    // Clear out the old markers2.
    if (marker2) {
        marker2.setPosition(null);
    }
    markers2.forEach(function (marker2) {
        marker2.setMap(null);
    });
    markers2 = [];

    // For each place, get the icon, name and location.
    var bounds = new google.maps.LatLngBounds();
    places.forEach(function (place) {
        if (!place.geometry) {
            console.log("Returned place contains no geometry");
            return;
        }
        var lat = '<%= Latlnglat.ClientID %>';
        document.getElementById(lat).value = place.geometry.location.lat();
        var lng = '<%= Latlnglng.ClientID %>';
        document.getElementById(lng).value = place.geometry.location.lng();
        // Create a marker for each place.                     

        if (place.geometry.viewport) {
            // Only geocodes have viewport.
            bounds.union(place.geometry.viewport);
        } else {
            bounds.extend(place.geometry.location);
        }

    });
    map.fitBounds(bounds);
});
                                }


           
</script>

</html>
