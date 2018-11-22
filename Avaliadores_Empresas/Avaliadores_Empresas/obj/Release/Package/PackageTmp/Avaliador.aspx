<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Avaliador.aspx.cs" Inherits="Avaliadores_Empresas.Avaliador" %>

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
        <asp:Button ID="BtnCorreio" runat="server" Height="35px" Text="Correio" Width="215px" OnClick="BtnCorreio_Click" />
        <br />
        <asp:Button ID="BtnPerfil" runat="server" Height="35px" Text="Perfil" Width="215px" OnClick="BtnPerfil_Click" />
        <br />
        <asp:Button ID="BtnAvaliacoesDisponiveis" runat="server" Height="35px" Text="Avaliações Disponiveis" Width="215px" OnClick="BtnAvaliacoesDisponiveis_Click" />
        <br />
        <asp:Button ID="BtnTrabalhosRealizados" runat="server" Height="35px" Text="Trabalhos realizados" Width="215px" OnClick="BtnTrabalhosRealizados_Click" />
            </asp:Panel>

        <asp:Panel ID="DivCorreio"  CssClass="DivBtn" runat="server" Visible="False">
            <asp:Label ID="LblCorreio" runat="server" Text="LblCorreio"></asp:Label>            
        </asp:Panel>

        <asp:Panel ID="DivPerfil"  CssClass="DivBtn" runat="server" Visible="False">
                   <div style="display:inline-block">
               <asp:Label ID="LblPerfilNome" runat="server" Text="Nome"></asp:Label>                       
            <asp:TextBox ID="TxtPerfilNome" runat="server"></asp:TextBox>    
               <br />

                <asp:Label ID="LblPerfilEmail" runat="server" Text="Email"></asp:Label>         
               <asp:TextBox ID="TxtPerfilEmail" runat="server"></asp:TextBox>    
                  <br />

               <asp:Label ID="LblPerfilTelemovel" runat="server" Text="Telemóvel"></asp:Label>     
               <asp:TextBox ID="TxtPerfilTelemovel" runat="server"></asp:TextBox>    
            <br />
                        
               <asp:Label ID="LblPerfilNRegisto" runat="server" Text="Número de Registo"></asp:Label>    
               <asp:TextBox ID="TxtPerfilNRegisto" runat="server"></asp:TextBox>    
            <br />
                        
               <asp:Label ID="LblPerfilApoliceSeguro" runat="server" Text="Apolice Seguro"></asp:Label>    
               <asp:TextBox ID="TxtPerfilApoliceSeguro" runat="server"></asp:TextBox>    
            <br />
                        
               <asp:Label ID="LblPerfilValidadeApolice" runat="server" Text="Validade Apolice"></asp:Label>    
               <asp:TextBox ID="TxtPerfilValidadeApolice" runat="server" TextMode="Date"></asp:TextBox>    
            <br />
                        
               <asp:Label ID="LblPerfilMorada" runat="server" Text="Morada"></asp:Label>  
               <asp:TextBox ID="TxtPerfilMorada" runat="server"></asp:TextBox>    
            <br />

            <asp:Button ID="BtnPerfilConfirmar" runat="server" Text="Confirmar Edições" OnClick="BtnPerfilConfirmar_Click" />
</div>  
            <div style="display:inline-block">
            <asp:DropDownList ID="dpPerfilArea" runat="server"></asp:DropDownList>
            <asp:Button ID="BtnPerfilDropdown" runat="server" Text="Add" OnClick="BtnPerfilDropdown_Click" />
            <br />
            <asp:ListBox ID="LBoxPerfilArea" runat="server"></asp:ListBox>      
            <br />
               <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Apagar Área Selecionada" />
               <br />
               <asp:Label ID="Label1" runat="server"></asp:Label>
            </div>

            </asp:Panel>

        <asp:Panel ID="DivAvaliacoesDisponiveis"  CssClass="DivBtn" runat="server" Visible="False">
            <asp:Label ID="LblAvaliacoesDisponiveis" runat="server" Text="LblAvaliacoesDisponiveis"></asp:Label>  
            </asp:Panel>

        <asp:Panel ID="DivTrabalhosRealizados"  CssClass="DivBtn" runat="server" Visible="False">
            <asp:Label ID="LblTrabalhosRealizados" runat="server" Text="LblTrabalhosRealizados"></asp:Label>  

            </asp:Panel>
    </div>
    </form>
</body>
</html>
