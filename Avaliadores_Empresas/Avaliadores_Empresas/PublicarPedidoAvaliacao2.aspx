<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicarPedidoAvaliacao2.aspx.cs" Inherits="Avaliadores_Empresas.PublicarPedidoAvaliacao2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <link runat="server" rel="icon" href="Imagens/Logos/favicon.ico" type="image/x-icon" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<asp:Panel ID="Panel2" runat="server">
             <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Verificar" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="download form" OnClick="Button3_Click" />
        <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
        </asp:DropDownList>
             <asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
             </asp:DropDownList>
                <asp:Label ID="Label7" runat="server"></asp:Label>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Button ID="Button4" runat="server" Text="Enviar" Visible="False" OnClick="Button4_Click" />
                <asp:Button ID="Button5" runat="server" Text="Enviar Outro" Visible="False" />
             <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Voltar" />
             <br />
             <asp:Label ID="Label1" runat="server"></asp:Label>
            </asp:Panel>
    </form>
</body>
</html>
