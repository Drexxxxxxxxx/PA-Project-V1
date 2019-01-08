<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicarPedidoAvaliacao2.aspx.cs" Inherits="Avaliadores_Empresas.PublicarPedidoAvaliacao2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <link runat="server" rel="icon" href="../Imagens/Logos/favicon.ico" type="image/x-icon" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<asp:Panel ID="Panel2" runat="server">
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
    </form>
</body>
</html>
