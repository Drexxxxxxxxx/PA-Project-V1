<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registar_Avaliadores.aspx.cs" Inherits="Avaliadores_Empresas.Registar_Avaliadores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <style>
        /* Remove the navbar's default margin-bottom and rounded borders */

        .navbar {
            margin-bottom: 0;
            border-radius: 0;
        }


        body, html, header, form {
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            height: 100%;
            overflow-x: hidden;
                        overflow-y: hidden;
            margin: 0;
        }

        .divArea{
             text-align:center;
             margin-left: 49%;
        }
        .LabelsHome {
            position: relative;
            display: inline-block;
            height: 100%;
            vertical-align: top;
            width: 18%;
            text-align: center;
        }

        .Links {
            color: black;
            font-size: 80%;
            text-transform: uppercase;
            font-family: 'Poppins', sans-serif;
            text-decoration: none;
        }

            .Links:hover {
                color: #5373FE;
                text-decoration: none;
            }

        .LabelPortal {
            font-weight: bolder;
            font-size: 347%;
        }

        .labelFont {
            font-family: 'Poppins', sans-serif;
            font-size: 275%;
        }

        .buttonsobrenos {
            border-radius: 6px;
            border: 1px solid;
            background-color: #212425;
            color: white;
           padding: 8px 17px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
        }

            .buttonsobrenos:hover {
                background-color: white;
                color: #212425;
            }

        .container-fluid {
            padding-right: 0px;
            padding-left: 0px;
        }

        .botoestoolbar {
            padding: 0px 15px;
            padding-bottom: 0px;
            padding-left: 0px;
            padding-right: 0px;
            padding-top: 0px;
            height: 60px;
        }

            .botoestoolbar a {
                padding-top: 20px !important;
            }

        .navbar-toggle {
            position: unset;
            float: unset;
        }

        /* Add a gray background color and some padding to the footer */
        footer {
            background-color: #f2f2f2;
            padding: 25px;
        }

        .dropdown {
    width: 90px;
    text-align: center;
    background-color: #080808;
    padding-top: 20px;
    height: 60px;
    position: relative;
    display: inline-block;
    color: #9d9d9d;
    cursor: pointer;
        }

        .dropdown-content {
            color: black;
            display: none !important;
            position: absolute;
            background-color: #f9f9f9;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            padding: 12px 16px;
            z-index: 3;
        }

        .LabelPaddingright {            
            border-radius: 10px;
            margin-right: 2%;
            padding: 4.1px;
            font-family: 'Poppins', sans-serif;
            border: 2px solid;
            font-size: 20px;
        }

        .textboxContactos {
                        border-radius: 10px;
            font-family: 'Poppins', sans-serif;
            border: 2px solid;
            font-size: 20px;
        }
        .DivDescricao{
                         display: block;

        }
        .listboxcss{
                height: 59px;
    width: 132px;
    border-style: none;
    border-width: 0px;
    border: none;
    font-size: 12pt;
    background-color: white;
    color: #212425;
        }
        @media (min-width: 364px) {
             .DivDescricao{
                          display: inline-flex;

        }
            .Div364 {
                display: inline-block;
                text-align: right;
                margin-right: 10%;
            }
        }

        .dropdown:hover .dropdown-content {
            display: block !important;
        }
        .DivsContacto{
    display: inline-block;
    width: 100%;
        }
        .LabelDescricao{
                margin-right: 9px;
        }

        @media (max-width: 590px) {
            .LabelPortal {
                font-size: 200%;
            }

            .labelFont {
                font-size: 150%;
            }
        }

        @media (max-width: 767px) {
            .botoestoolbar {
                padding: 0px 15px !important;
            }
        }
        
         @media (min-width: 523px) {
                   .divArea{
           margin-left: 50%;
        }
        }

         @media (max-width: 522px) {
                   .divArea{
           margin-left: 22%;
        }
        }
                @media (max-width: 320px) {
                   .divArea{
            margin-left:0px;
        }
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
           <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <div style="position: relative; float: right; padding-top: 4px; max-width: 16%;">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                    </div>
                    <div style="max-width: 80%;">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/logo.jpeg" />
                    </div>
                </div>

                <div class="collapse navbar-collapse" id="myNavbar">
                    <div class="dropdown">
                        <span>Registar</span>
                        <div class="dropdown-content">
                            <p><a style="text-decoration: none; color: purple;" href="Registar_Empresas.aspx">Registar Empresa</a></p>
                            <p><a style="text-decoration: none;" href="Registar_Avaliadores.aspx">Registar Avaliador</a></p>
                        </div>
                    </div>
                    <ul class="nav navbar-nav">
                        <li class="botoestoolbar"><a class="botoestoolbar" href="Homepagebottstrap.aspx">Home</a></li>
                        <li class="botoestoolbar"><a class="botoestoolbar" href="Contactos.aspx">Contactos</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li class="botoestoolbar"><a class="botoestoolbar" href="Login.aspx"><span class="glyphicon glyphicon-log-in" style="padding-right:2px"></span>Login</a></li>
                    </ul>
                </div>
            </div>
        </nav>
           <div style="position: relative; text-align: center; height: 91%;">
                        <asp:Image ID="Image1" runat="server" Height="100%" ImageUrl="~/imagemfundo.jpg" Width="100%" />
            <div style="position: absolute; width: 100%; top: 0px; height: 100%; z-index: 1; opacity: 0.7; background-color: #5373FE;"></div>
            <div style="position: absolute; overflow-y:auto; padding-top:10px; max-height: 95%; max-width: 100%; min-width: 200px; top: 50%; left: 0%; right: 0%; transform: translate(-0%, -50%); z-index: 2;">
                <div class="Div364">
                <div class="DivsContacto">
                    <asp:Label ID="Label3" runat="server" CssClass="LabelPaddingright" Text="Nome"></asp:Label> <asp:TextBox ID="nome_aval"  CssClass="textboxContactos" runat="server"></asp:TextBox>
                    
                </div><br /><br />
                <div class="DivsContacto">
                    <asp:Label ID="Label4" runat="server" CssClass="LabelPaddingright" Text="Email"></asp:Label><asp:TextBox ID="email_aval"  CssClass="textboxContactos" runat="server"></asp:TextBox>
                </div><br /><br />
                <div class="DivsContacto">
                    <asp:Label ID="Label5" runat="server" CssClass="LabelPaddingright" Text="Número de telemóvel"></asp:Label> <asp:TextBox ID="mobile_aval"  CssClass="textboxContactos" MaxLength="9" runat="server"></asp:TextBox>
                </div><br /><br />
                <div class="DivsContacto">
                    <asp:Label ID="Label6" runat="server" CssClass="LabelPaddingright LabelDescricao" Height="39px" Text="Morada"></asp:Label><asp:TextBox ID="morada_aval"  CssClass="textboxContactos" runat="server"></asp:TextBox>
                </div><br /><br />
                    <div style="display:inherit">
                <div class="DivsContacto">
                                        <div class="divArea">
                    <asp:Label ID="Label7" runat="server" CssClass="LabelPaddingright LabelDescricao" Height="39px" Text="Area de Atuação"></asp:Label><br /><asp:Button ID="AddtoListbox" runat="server" OnClick="AddtoListbox_Click" CssClass="buttonsobrenos" Text="Add" /> <asp:DropDownList CssClass="buttonsobrenos" ID="dp_area" runat="server"></asp:DropDownList>
                <br /><br />
                 <div class="DivsContacto">
                   <asp:ListBox ID="ListBox1" runat="server" Height="59px" CssClass="listboxcss" Width="132px"></asp:ListBox> <br /> <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  CssClass="buttonsobrenos"  Text="Remover Área Selecionada" /></div>
                </div> </div><br /><br />
                 <div class="DivsContacto">
                    <asp:Label ID="Label12" runat="server" CssClass="LabelPaddingright LabelDescricao" Height="39px" Text="Password"></asp:Label><asp:TextBox ID="pass_aval" runat="server"  CssClass="textboxContactos" TextMode="Password"></asp:TextBox>
                </div><br /><br />
                 <div class="DivsContacto">
                    <asp:Label ID="Label8" runat="server" CssClass="LabelPaddingright LabelDescricao" Height="39px" Text="Confirmar Password"></asp:Label><asp:TextBox ID="confpass_aval" runat="server"  CssClass="textboxContactos" TextMode="Password"></asp:TextBox>
                </div><br /><br />
                 <div class="DivsContacto">
                    <asp:Label ID="Label9" runat="server" CssClass="LabelPaddingright LabelDescricao" Height="39px" Text="Nº Registo"></asp:Label><asp:TextBox ID="nregisto_aval"  CssClass="textboxContactos" runat="server"></asp:TextBox>
                </div><br /><br />
                <div class="DivsContacto">               
                    <asp:Label ID="Label10" runat="server" CssClass="LabelPaddingright LabelDescricao" Height="39px" Text="Apólice Seguro"></asp:Label><asp:TextBox ID="apoliceseguro_aval"  CssClass="textboxContactos" runat="server"></asp:TextBox>
                </div><br /><br />
                <div class="DivsContacto">
                    <asp:Label ID="Label11" runat="server" CssClass="LabelPaddingright LabelDescricao" Height="39px" Text="Validade do Apólice de Seguro"></asp:Label><asp:TextBox ID="validseguro_aval"  CssClass="textboxContactos" TextMode="Date" runat="server"></asp:TextBox>
                </div><br /><br />
                <div class="DivsContacto">
                     <asp:Button ID="btn_regist_Aval" runat="server"  CssClass="buttonsobrenos" OnClick="btn_regist_Aval_Click" Text="Registar" />
                    </div>
        </div>
        </div>
               </div>
   
    </form>
</body>
</html>
