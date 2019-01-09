<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Avaliadores_Empresas.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Admin</title>
    <style>
        .custompopup {
            background-color: #fff;
            border: 3px solid #fff;
            display: inline-block;
            left: 50%;
            padding: 15px;
            position: fixed;
            text-align: justify;
            top: 40%;
            z-index: 10;
            -webkit-transform: translate(-50%, -50%);
            -moz-transform: translate(-50%, -50%);
            -ms-transform: translate(-50%, -50%);
            -o-transform: translate(-50%, -50%);
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            -ms-border-radius: 10px;
            -o-border-radius: 10px;
            -webkit-box-shadow: 0 1px 1px 2px rgba(0, 0, 0, 0.4) inset;
            -moz-box-shadow: 0 1px 1px 2px rgba(0, 0, 0, 0.4) inset;
            -ms-box-shadow: 0 1px 1px 2px rgba(0, 0, 0, 0.4) inset;
            -o-box-shadow: 0 1px 1px 2px rgba(0, 0, 0, 0.4) inset;
            -webkit-transition: opacity .5s, top .5s;
            -moz-transition: opacity .5s, top .5s;
            -ms-transition: opacity .5s, top .5s;
            -o-transition: opacity .5s, top .5s;
        }

            .custompopup p, .custompopup div {
                margin-bottom: 10px;
            }

            .custompopup label {
                display: inline-block;
                text-align: left;
                width: 120px;
            }

            .custompopup input[type="text"], .custompopup input[type="password"] {
                border: 1px solid;
                border-color: #999 #ccc #ccc;
                margin: 0;
                padding: 2px;
                -webkit-border-radius: 2px;
                -moz-border-radius: 2px;
                -ms-border-radius: 2px;
                -o-border-radius: 2px;
                border-radius: 2px;
            }

                .custompopup input[type="text"]:hover, .custompopup input[type="password"]:hover {
                    border-color: #555 #888 #888;
                }

        .butoespopup {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Height="37px" OnClick="Button1_Click" Text="Registos" Width="160px" />
            <asp:Button ID="Button2" runat="server" Height="37px" Text="Perfil (Default)" Width="160px" OnClick="Button2_Click" />
            <br />
            <br />
            <div id="DivRegistos" runat="server" visible="true">
                <asp:Label ID="Label1" runat="server" Text="Contas Teste Avaliador" Font-Size="X-Large"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                        <asp:ButtonField CommandName="Select2" Text="Eliminar" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="Label12" runat="server"></asp:Label>
                <asp:Label ID="Label13" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Contas Teste Empresa" Font-Size="X-Large"></asp:Label>
                <asp:GridView ID="GridView3" runat="server" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" OnRowCommand="GridView3_RowCommand">
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                        <asp:ButtonField CommandName="Select2" Text="Eliminar" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:ListBox ID="ListBox1" runat="server" Visible="False"></asp:ListBox>
                <asp:ListBox ID="ListBox2" runat="server" Visible="False"></asp:ListBox>
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
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Mudar Password" />
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
                <asp:Button ID="Button3" runat="server" Height="29px" OnClick="Button3_Click" Text="Confirmar" Width="75px" />
            </div>
        </div>
        <div class="custompopup" id="div1" runat="server" visible="false">
            <p>
                <asp:Label ID="Label9" runat="server" Text="Data expiração"></asp:Label>
                <asp:TextBox ID="TextBox8" runat="server" TextMode="Date"></asp:TextBox>
            </p>
            <asp:Button ID="Button7" CssClass="butoespopup" Width="25%" runat="server" Text="Ok" OnClick="Button7_Click" />
        </div>
        <div class="custompopup" id="div2" runat="server" visible="false">
            <p>
                <asp:Label ID="Label8" runat="server" Text="Data expiração"></asp:Label>
                <asp:TextBox ID="TextBox7" runat="server" TextMode="Date"></asp:TextBox>
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
    </form>
</body>
</html>
