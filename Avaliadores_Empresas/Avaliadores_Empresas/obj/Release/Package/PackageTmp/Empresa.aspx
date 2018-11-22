<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empresa.aspx.cs" Inherits="Avaliadores_Empresas.Empresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style>
        .DivBtn{
            display:inline-block;
        }
        .DivBtn{
            display:inline-block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <asp:Panel ID="DivBtns" CssClass="DivBtn" runat="server">
        <asp:Button ID="BtnCorreio" runat="server" Height="35px" Text="Correio" Width="215px" OnClick="BtnCorreio_Click"/>
        <br />
        <asp:Button ID="BtnPerfil" runat="server" Height="35px" Text="Perfil" Width="215px" OnClick="BtnPerfil_Click"/>
        <br />
        <asp:Button ID="BtnPesquisaAvaliacoes" runat="server" Height="35px" Text="Pesquisa Avaliações" Width="215px" OnClick="BtnPesquisaAvaliacoes_Click"/>
        <br />
        <asp:Button ID="BtnPublicarPedidoAvaliacao" runat="server" Height="35px" Text="Publicar Pedido Avaliacao" Width="215px" OnClick="BtnPublicarPedidoAvaliacao_Click"/>
            </asp:Panel>

        <asp:Panel ID="DivCorreio"  CssClass="DivBtn" runat="server" Visible="False">
            <asp:Label ID="LblCorreio" runat="server" Text="LblCorreio"></asp:Label>            
        </asp:Panel>

        <asp:Panel ID="DivPerfil"  CssClass="DivBtn" runat="server" Visible="False">
               <asp:Label ID="LblPerfilNome" runat="server" Text="Nome"></asp:Label>                       
            <asp:TextBox ID="TBoxPerfilNome" runat="server"></asp:TextBox>    
               <br />

                <asp:Label ID="LblPerfilEmail" runat="server" Text="Email"></asp:Label>         
               <asp:TextBox ID="TBoxPerfilEmail" runat="server"></asp:TextBox>    
                  <br />

               <asp:Label ID="LblPerfilTelefone" runat="server" Text="Telefone"></asp:Label>     
               <asp:TextBox ID="TBoxPerfilTelefone" runat="server"></asp:TextBox>    
            <br />
                       
               <asp:Label ID="LblPerfilNRegisto" runat="server" Text="Número de Registo"></asp:Label>    
               <asp:TextBox ID="TBoxPerfilNRegisto" runat="server"></asp:TextBox>    
            <br />
                        
               <asp:Label ID="LblPerfilApoliceSeguro" runat="server" Text="Apolice Seguro"></asp:Label>    
               <asp:TextBox ID="TBoxPerfilApoliceSeguro" runat="server"></asp:TextBox>    
            <br />
                        
               <asp:Label ID="LblPerfilValidadeApolice" runat="server" Text="Validade Apolice"></asp:Label>    
               <asp:TextBox ID="TBoxPerfilValidadeApolice" runat="server" TextMode="Date"></asp:TextBox>    
            <br />
                        
               <asp:Label ID="LblPerfilMorada" runat="server" Text="Morada"></asp:Label>  
               <asp:TextBox ID="TBoxPerfilMorada" runat="server"></asp:TextBox>
               <br />
            <asp:Button ID="BtnPerfilConfirmar" runat="server" Text="Confirmar Edições" OnClick="BtnPerfilConfirmar_Click" />
            <br />

               <asp:Label ID="Label1" runat="server"></asp:Label>
           </asp:Panel>

        <asp:Panel ID="DivPesquisaAvaliacoes"  CssClass="DivBtn" runat="server" Visible="False">
            <asp:Label ID="LblPesquisaAvaliacoes" runat="server" Text="LblPesquisaAvaliacoes"></asp:Label>  
            </asp:Panel>

        <asp:Panel ID="DivPublicarPedidoAvaliacao"  CssClass="DivBtn" runat="server" Visible="False">
            <asp:Label ID="LblPublicarPedidoAvaliacao" runat="server" Text="LblPublicarPedidoAvaliacao"></asp:Label>  
            </asp:Panel>

    </div>
    </form>
</body>
</html>
