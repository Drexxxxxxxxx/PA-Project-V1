<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empresa.aspx.cs" Inherits="Avaliadores_Empresas.Empresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link runat="server" rel="icon" href="../Imagens/Logos/favicon.ico" type="image/x-icon" />

    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.carousel.css" />
    <link rel="stylesheet" href="../OwlCarousel/dist/assets/owl.theme.default.min.css" />

    <link href="https://fonts.googleapis.com/css?family=Montserrat:100,200,300,400,500,600,700" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"
        crossorigin="anonymous">
        <link rel="stylesheet" href="../CSS/Main.css">

    <link rel="stylesheet" type="text/css" href="../CSS/style_empresa.css" />
    <title>Portal dos Avaliadores - Empresa</title>

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
                        <img src="../images/Logos/favicon.ico" width="40" height="40" alt="">
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click"><span class="glyphicon glyphicon-log-out"
                                    style="padding-right: 2px"></span>Logout</asp:LinkButton>
                        <hr />
                        <asp:LinkButton ID="BtnPerfil" runat="server" OnClick="BtnPerfil_Click">Perfil</asp:LinkButton>
                        <asp:LinkButton ID="BtnPesquisaAvaliacoes" runat="server" OnClick="BtnPesquisaAvaliacoes_Click"> Pesquisa Avaliadores </asp:LinkButton>
                        <asp:LinkButton ID="BtnPublicarPedidoAvaliacao" runat="server" OnClick="BtnPublicarPedidoAvaliacao_Click">Publicar Pedido Avaliacao</asp:LinkButton>
                        <asp:LinkButton ID="BtnMinhasAvaliacoes" runat="server" OnClick="BtnMinhasAvaliacoes_Click">Meus Trabalhos</asp:LinkButton>
                        <asp:LinkButton ID="BtnAvaliacoes" runat="server" OnClick="BtnAvaliacoes_Click">Avaliações</asp:LinkButton>
                        <asp:LinkButton ID="BtnRanking" runat="server" OnClick="BtnRanking_Click">Ranking</asp:LinkButton>
                        <asp:LinkButton ID="BtnHistorico" runat="server" OnClick="BtnHistorico_Click">Histórico</asp:LinkButton>





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


            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div class="container-fluid">
                <div class="row ml-0 mr-0 main_div">
                    <div class="col-12 col-md-8 col-lg-9 order-1 order-md-0">
                        <asp:Panel ID="DivPerfil" CssClass="" runat="server" Visible="True">
                            <div class="">
                                <div class="divPerfil_inner">
                                    <div class="row">
                                        <div class="w-100">
                                            <div class="col-xl-12">
                                                <h1>Perfil </h1>
                                                <hr class="mt-0" />
                                            </div>
                                        </div>

                                    </div>
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-12 col-md-3">
                                                <p>nome </p>
                                            </div>
                                            <div class="col-12 col-md">
                                                <asp:TextBox ID="TBoxPerfilNome" placeholder="Nome" CssClass="form-control"
                                                    runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12 col-md-3">
                                                <p>e-mail </p>
                                            </div>
                                            <div class="col-12 col-md">
                                                <asp:TextBox ID="TBoxPerfilEmail" placeholder="Email" CssClass="form-control"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12 col-md-3">
                                                <p>telemovel </p>
                                            </div>
                                            <div class="col-12 col-md">
                                                <asp:TextBox ID="TBoxPerfilTelefone" placeholder="Telefone" CssClass="form-control"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12 col-md-3">
                                                <p>Nº Registo </p>
                                            </div>
                                            <div class="col-12 col-md">
                                                <asp:TextBox ID="TBoxPerfilNRegisto" placeholder="Número de Registo"
                                                    CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12 col-md-3">
                                                <p>Morada </p>
                                            </div>
                                            <div class="col-12 col-md">
                                                <asp:TextBox ID="TBoxPerfilMorada" placeholder="Morada" CssClass="form-control"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12 col-md-3">
                                                 <p><asp:Label ID="Label4" runat="server">Estado de Licenciamento</asp:Label> </p>
                                            </div>
                                            <div class="col-12 col-md">
                                                <asp:Label ID="Label5" CssClass="font-weight-bold" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12 col-md-3">
                                                <p><asp:Label ID="Label6" runat="server">Final da Licença</asp:Label> </p>
                                                
                                            </div>
                                            <div class="col-12 col-md">
                                                <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True" TextMode="Date"></asp:TextBox>
                                                <asp:TextBox ID="TextBox6" runat="server" ReadOnly="True" TextMode="Date"
                                                    Visible="False"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-12 col-md-9 offset-md-3 text-right">
                                                <asp:Button ID="Button4" runat="server" CssClass="btn w-100 mt-2" Text="Renovar Licença"
                                                    OnClick="Button4_Click" />

                                                <br>

                                                <asp:Button ID="Button1" runat="server" CssClass="btn  mt-1 w-100" Text="Mudar Password"
                                                    OnClick="Button1_Click1" />

                                                <br />
                                                <asp:Button ID="BtnPerfilConfirmar" CssClass="btn mt-1 w-100" runat="server" Text="Confirmar"
                                                    OnClick="BtnPerfilConfirmar_Click" />

                                            </div>

                                        </div>
                                    </div>

                                    <br />
                                    <div class="custompopup" id="divThankYou" runat="server" visible="false">
                                        <p>
                                            <asp:Label ID="lblmessage" runat="server">Password Antiga</asp:Label>
                                            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                                        </p>
                                        <asp:Button ID="Button3" CssClass="butoespopup" Width="25%" runat="server" Text="Ok"
                                            OnClick="Button3_Click" />
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
                                        <asp:Button ID="Button2" CssClass="butoespopup" Width="25%" runat="server" Text="Ok"
                                            OnClick="Button2_Click" />
                                    </div>

                                    <br />

                                    <br />
                                    <br />

                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </div>
                            </div>

                        </asp:Panel>

                        <asp:Panel ID="DivPesquisaAvaliacoes" CssClass="DivBtn" runat="server" Visible="False">
                            <div class="row">
                                <div class="w-100">
                                    <div class="col-xl-12">
                                        <h1>Pesquisar Avaliadores </h1>
                                        <hr class="mt-0" />
                                    </div>
                                </div>

                            </div>

                            <input id="LatitudeDragend" type="hidden" value="0" runat="server" />
                            <input id="LongitudeDragend" type="hidden" value="0" runat="server" />
                            <input id="ZoomDragend" type="hidden" value="0" runat="server" />
                            <input id="Latlnglat" type="hidden" runat="server" />
                            <input id="Latlnglng" type="hidden" runat="server" />
                            <input id="Hidden1" type="hidden" runat="server" />
                            <input id="Hidden2" type="hidden" runat="server" />
                            <input id="Hidden3" type="hidden" runat="server" />

                            <asp:TextBox ID="TextBox1" runat="server" placeholder="Introduza uma localização" onkeydown="return (event.keyCode!=13);"></asp:TextBox>

                            <asp:TextBox runat="server" ID="pacinput" class="form-control" type="text" placeholder="Find Address of conflict &#xF002;"
                                Style="display: none" AutoPostBack="True"></asp:TextBox>
                            <div id="googleMapZOOM" style="width: 100%; height: 300px;"></div>




                            <asp:GridView ID="GridView1" runat="server">
                            </asp:GridView>
                            &nbsp;

                        <table id="tbl" width="60%" style="visibility: hidden;">
                            <tr>
                                <td class="font-weight-bold">Nome:</td>
                            </tr>
                        </table>
                            <table id="tblcontatos" style="visibility: hidden;" width="60%">
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
                                    <div class="w-100">
                                        <div class="col-xl-12">
                                            <h1>Publicar Pedido de Avaliação </h1>
                                            <hr class="mt-0" />
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:Button ID="Button6" CssClass="btn_numeros btn btn-dark" runat="server"
                                                    Text="1" OnClick="Button6_Click" />

                                            </div>

                                        </div>
                                        <div class="row text-center w-100" style="padding: 20px;">
                                            <div>
                                                <p>
                                                    Inserir
                                                <br>
                                                    uma
                                                <br>
                                                    avaliação
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:Button ID="Button7" CssClass="btn_numeros btn btn-dark" runat="server"
                                                    Text="2" OnClick="Button7_Click" />
                                            </div>
                                        </div>
                                        <div class="row text-center w-100" style="padding: 20px;">
                                            <div class="">
                                                <p>
                                                    Importar
                                                <br>
                                                    várias
                                                <br>
                                                    avaliações
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:Button ID="Button8" CssClass="btn_numeros btn btn-dark" runat="server"
                                                    Text="3" OnClick="Button8_Click" />
                                            </div>
                                        </div>
                                        <div class="row text-center w-100" style="padding: 20px;">
                                            <div class="">
                                                <p>
                                                    Importar
                                                <br>
                                                    pacote de
                                                <br>
                                                    avaliações
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>

                        </asp:Panel>

                        <asp:Panel ID="DivMinhasAvaliacoes" CssClass="DivBtn" runat="server" Visible="False">
                            <div class="row">
                                <div class="w-100">
                                    <div class="col-xl-12">
                                        <h1>Minhas Avaliações </h1>
                                        <hr class="mt-0" />
                                    </div>
                                </div>

                            </div>
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
                                <asp:Button ID="Button9" CssClass="butoespopup" Width="25%" runat="server" Text="Voltar"
                                    OnClick="Button9_Click" />
                            </div>

                            <br />
                            <asp:GridView ID="GridView3" runat="server" OnSelectedIndexChanged="GridView3_SelectedIndexChanged"
                                OnRowCommand="GridView3_RowCommand">
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
                                <asp:Button ID="Button5" CssClass="butoespopup" Width="25%" runat="server" Text="Voltar"
                                    OnClick="Button5_Click" />
                            </div>
                            <asp:ListBox ID="ListBox3" runat="server" Visible="False"></asp:ListBox>
                            <asp:ListBox ID="ListBox7" runat="server" Visible="False"></asp:ListBox>
                            <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick1">
                            </asp:Timer>
                        </asp:Panel>

                        <asp:Panel ID="DivAvaliacoes" CssClass="DivBtn" runat="server" Visible="False">
                            <div class="row">
                                <div class="w-100">
                                    <div class="col-xl-12">
                                        <h1>Avaliações </h1>
                                        <hr class="mt-0" />
                                    </div>
                                </div>

                            </div>
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
                                        <ajaxToolkit:Rating ID="Rating1" runat="server" CurrentRating="3" EmptyStarCssClass="EmptyStars"
                                            FilledStarCssClass="FilledStars" StarCssClass="starRating" WaitingStarCssClass="WatingStars">
                                        </ajaxToolkit:Rating>
                                        <asp:Label ID="Label9" runat="server" Text="Qualidade"></asp:Label>
                                        <ajaxToolkit:Rating ID="Rating2" runat="server" CurrentRating="3" EmptyStarCssClass="EmptyStars"
                                            FilledStarCssClass="FilledStars" StarCssClass="starRating" WaitingStarCssClass="WatingStars">
                                        </ajaxToolkit:Rating>
                                        <asp:Label ID="Label10" runat="server" Text="Cumprimento de prazo"></asp:Label>
                                        <ajaxToolkit:Rating ID="Rating3" runat="server" CurrentRating="3" EmptyStarCssClass="EmptyStars"
                                            FilledStarCssClass="FilledStars" StarCssClass="starRating" WaitingStarCssClass="WatingStars">
                                        </ajaxToolkit:Rating>
                                        <asp:Label ID="Label11" runat="server" Text="Outro"></asp:Label>
                                        <ajaxToolkit:Rating ID="Rating4" runat="server" CurrentRating="3" EmptyStarCssClass="EmptyStars"
                                            FilledStarCssClass="FilledStars" StarCssClass="starRating" WaitingStarCssClass="WatingStars">
                                        </ajaxToolkit:Rating>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <p>
                                </p>
                                <asp:Button ID="Button13" runat="server" CssClass="butoespopup" OnClick="Button13_Click"
                                    Text="Avaliar" />
                                <asp:Button ID="Button15" runat="server" Text="Voltar" OnClick="Button15_Click" />
                                <p>
                                </p>
                                <p>
                                </p>
                                <p>
                                </p>
                            </div>
                            <br />
                            <asp:GridView ID="GridView9" runat="server" OnRowCommand="GridView5_RowCommand"
                                OnSelectedIndexChanged="GridView9_SelectedIndexChanged">
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
                                <asp:Button ID="Button12" CssClass="butoespopup" Width="25%" runat="server" Text="Voltar"
                                    OnClick="Button12_Click" />
                            </div>
                            <asp:ListBox ID="ListBox11" runat="server"></asp:ListBox>
                            <asp:ListBox ID="ListBox12" runat="server" Visible="False"></asp:ListBox>
                            <asp:ListBox ID="ListBox13" runat="server"></asp:ListBox>
                            <asp:ListBox ID="ListBox14" runat="server"></asp:ListBox>
                        </asp:Panel>

                        <asp:Panel ID="DivRanking" CssClass="DivBtn" runat="server" Visible="False">
                            <div class="row">
                                <div class="w-100">
                                    <div class="col-xl-12">
                                        <h1>Ranking </h1>
                                        <hr class="mt-0" />
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-12 col-md-6">
                                    <h2>
                                        <asp:Label ID="Label12" runat="server" Text="Empresa"></asp:Label></h2>
                                    <div class="table-responsive">
                                        <asp:GridView id="GridView11" runat="server" CssClass="table" AllowPaging="True" OnPageIndexChanging="GridView11_PageIndexChanging" PageSize="20" ShowHeader="False">
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="4" />
                                        </asp:GridView>
                                    </div>

                                </div>
                                <div class="col-12 col-md-6">
                                    <h2>
                                        <asp:Label ID="Label13" runat="server" Text="Avaliador"></asp:Label></h2>
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridView12" runat="server" CssClass="table" AllowPaging="True" OnPageIndexChanging="GridView12_PageIndexChanging" PageSize="20" ShowHeader="False">
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="4" />
                                        </asp:GridView>
                                    </div>

                                </div>
                            </div>

                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem Selected="True">20</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>100</asp:ListItem>
                            </asp:DropDownList>

                        </asp:Panel>

                        <asp:Panel ID="DivPublicarPedidoBtn1" CssClass="DivBtn" runat="server" Visible="False">
                            <asp:Panel ID="Panel3" runat="server">
                                <asp:Label ID="Label14" runat="server" Text="Denominação"></asp:Label>
                                <asp:TextBox ID="PPA1TextBox1" runat="server"></asp:TextBox>
                                <br />
                                <asp:Label ID="Label15" runat="server" Text="Tipo"></asp:Label>
                                <asp:DropDownList ID="PPA1DropDownList2" runat="server">
                                </asp:DropDownList>
                                <br />
                                <asp:Label ID="Label16" runat="server" Text="Localidade"></asp:Label>
                                <asp:DropDownList ID="PPA1DropDownList1" runat="server">
                                </asp:DropDownList>
                                <br />
                                <asp:Label ID="Label17" runat="server" Text="Deadline"></asp:Label>
                                <asp:TextBox ID="PPA1TextBox2" runat="server" TextMode="Date"></asp:TextBox>
                                <br />

                                <asp:Button ID="PPA1Button1" runat="server" Text="Registar" OnClick="PPA1Button1_Click" />
                                <asp:Button ID="Button16" runat="server" OnClick="PPA1Button2_Click" Text="Voltar" />
                                <asp:Label ID="Label18" runat="server"></asp:Label>
                            </asp:Panel>
                        </asp:Panel>

                        <asp:Panel ID="DivPublicarPedidoBtn2" CssClass="DivBtn" runat="server" Visible="False">
                            <asp:Panel ID="Panel1" runat="server">
                                <asp:FileUpload ID="PPA2FileUpload1" runat="server" />
                                <br />
                                <asp:Button ID="PPA2Button2" runat="server" Text="Verificar" OnClick="PPA2Button2_Click" />
                                <asp:Button ID="PPA2Button3" runat="server" Text="download form" OnClick="PPA2Button3_Click" />
                                <asp:DropDownList ID="PPA2DropDownList1" runat="server" Visible="False">
                                </asp:DropDownList>
                                <asp:DropDownList ID="PPA2DropDownList2" runat="server" Visible="False">
                                </asp:DropDownList>
                                <asp:Label ID="PPA2Label7" runat="server"></asp:Label>
                                <asp:GridView ID="PPA2GridView1" runat="server">
                                </asp:GridView>
                                <asp:Button ID="PPA2Button4" runat="server" Text="Enviar" Visible="False" OnClick="PPA2Button4_Click" />
                                <asp:Button ID="PPA2Button5" runat="server" Text="Enviar Outro" Visible="False" />
                                <asp:Button ID="PPA2Button6" runat="server" OnClick="PPA2Button6_Click" Text="Voltar" />
                                <br />
                                <asp:Label ID="PPA2Label1" runat="server"></asp:Label>
                            </asp:Panel>
                        </asp:Panel>

                        <asp:Panel ID="DivPublicarPedidoBtn3" CssClass="DivBtn" runat="server" Visible="False">
                            <asp:Panel ID="Panel4" runat="server">
                                <asp:FileUpload ID="PPA3FileUpload1" runat="server" />
                                <br />
                                <asp:Button ID="PPA3Button2" runat="server" Text="Verificar" OnClick="PPA3Button2_Click" Style="height: 26px" />
                                <asp:Button ID="PPA3Button3" runat="server" Text="download form" OnClick="PPA3Button3_Click" />
                                <asp:DropDownList ID="PPA3DropDownList2" runat="server" Visible="False">
                                </asp:DropDownList>
                                <asp:Label ID="PPA3Label7" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="Label19" runat="server" Text="Descrição do pacote"></asp:Label>
                                <br />
                                <asp:TextBox ID="PPA3TextBox1" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <asp:DropDownList ID="PPA3DropDownList1" runat="server" Visible="False">
                                </asp:DropDownList>
                                <br />
                                <asp:Label ID="Label20" runat="server" Text="Deadline"></asp:Label>
                                <br />
                                <asp:TextBox ID="PPA3TextBox2" runat="server" TextMode="Date"></asp:TextBox>
                                <asp:GridView ID="PPA3GridView1" runat="server">
                                </asp:GridView>
                                <asp:Button ID="PPA3Button4" runat="server" Text="Enviar" Visible="False" OnClick="PPA3Button4_Click" />
                                <asp:Button ID="PPA3Button5" runat="server" Text="Enviar Outro" Visible="False" OnClick="PPA3Button5_Click" />
                                <asp:Button ID="PPA3Button6" runat="server" OnClick="PPA3Button6_Click" Text="Voltar" />
                                <br />
                                <asp:Label ID="Label21" runat="server"></asp:Label>
                            </asp:Panel>
                        </asp:Panel>




                         <asp:Panel ID="DivHistorico" CssClass="DivBtn" runat="server" Visible="False">
                            <div class="row">
                                <div class="w-100">
                                    <div class="col-xl-12">
                                        <h1>Historico </h1>
                                        <hr class="mt-0" />
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-12 col-md-6">
                                     <h2>
                                        <asp:Label ID="Label24" runat="server" Text="Avaliação"></asp:Label></h2>
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridViewAval" runat="server" CssClass="table">                                        
                                        </asp:GridView>
                                    </div>
                                </div>

                                <div class="col-12 col-md-6">
                                     <h2>
                                        <asp:Label ID="Label25" runat="server" Text="Pacote de Avaliação"></asp:Label></h2>
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridViewPacoteAval" runat="server" CssClass="table">
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>                          
                        </asp:Panel>



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

                                tr.style.backgroundColor = "rgba(255,255,255,0.8)";



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
