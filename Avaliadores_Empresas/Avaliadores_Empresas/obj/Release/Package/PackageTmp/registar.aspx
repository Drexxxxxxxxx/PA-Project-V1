<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registar.aspx.cs" Inherits="Avaliadores_Empresas.registar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/css/bootstrap.min.css" integrity="sha384-rwoIResjU2yc3z8GV/NPeZWAv56rSmLldC3R/AZzGRnGxQQKnKkoFVhFQhNUwEyJ" crossorigin="anonymous">
<script src="https://code.jquery.com/jquery-3.1.1.slim.min.js" integrity="sha384-A7FZj7v+d/sdmMqp/nOQwliLvUsJfDHW+k9Omg/a/EheAdgtzNs3hpfag6Ed950n" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js" integrity="sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/js/bootstrap.min.js" integrity="sha384-vBWWzlZJ8ea9aCX4pEW3rVHjgjt7zpkNpZk+02D9phzyeVkE+jo0ieGizqPLForn" crossorigin="anonymous"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" class="container">
        <div class="col-sm-12">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>Avaliador</asp:ListItem>
                <asp:ListItem>Empresa</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <asp:Panel ID="pnl_avaliador" runat="server" Visible="false">
            <h2> Registar Avaliador </h2>
            <asp:Label ID="lbl_NRegisto_aval" runat="server" Text="Número de registo"></asp:Label>
            <asp:TextBox ID="NRegisto_aval" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_name_aval" runat="server" Text="Nome"></asp:Label>
            &nbsp;<asp:TextBox ID="nome_aval" runat="server"></asp:TextBox>
            <br />
            Email
            <asp:TextBox ID="email_aval" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            &nbsp;<asp:TextBox ID="pass_aval" runat="server" TextMode="Password" MaxLength="9"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_Telemovel_aval" runat="server" Text="Telemovel"></asp:Label>
            <asp:TextBox ID="Telemovel_aval" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_ApoliseSeguro_aval" runat="server" Text="Apolise Seguro"></asp:Label>
            <asp:TextBox ID="ApoliseSeguro_aval" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_ValidadeApolise_aval" runat="server" Text="Validade Apolise"></asp:Label>
            <asp:TextBox ID="ValidadeApolise_aval" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_Morada_aval" runat="server" Text="Morada"></asp:Label>
            <asp:TextBox ID="Morada_aval" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_msg" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:Button ID="btn_regist_Aval" runat="server" OnClick="btn_regist_Aval_Click" Text="Registar" />
        </asp:Panel>
        <asp:Panel ID="pnl_empresa" runat="server" Visible="false">
            <h2> Registar Empresa </h2>
             <asp:Label ID="lbl_NRegisto_emp" runat="server" Text="Número de registo"></asp:Label>
            <asp:TextBox ID="NRegisto_emp" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="lbl_nome_emp" runat="server" Text="Nome"></asp:Label>
            &nbsp;<asp:TextBox ID="nome_emp" runat="server"></asp:TextBox>
            <br />
            Email
            <asp:TextBox ID="email_emp" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
            &nbsp;<asp:TextBox ID="pass_emp" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_Telefone_emp" runat="server" Text="Telefone"></asp:Label>
            <asp:TextBox ID="Telefone_emp" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_ApoliseSeguro_emp" runat="server" Text="Apolise Seguro"></asp:Label>
            <asp:TextBox ID="ApoliseSeguro_emp" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_ValidadeApolise_emp" runat="server" Text="Validade Apolise"></asp:Label>
            <asp:TextBox ID="ValidadeApolise_emp" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_Morada_emp" runat="server" Text="Morada"></asp:Label>
            <asp:TextBox ID="Morada_emp" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_msg0" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:Button ID="btn_regist_emp" runat="server" OnClick="btn_regist_emp_Click" Text="Registar" />
        </asp:Panel>

        <p>
            &nbsp;</p>

    </form>
</body>
</html>
