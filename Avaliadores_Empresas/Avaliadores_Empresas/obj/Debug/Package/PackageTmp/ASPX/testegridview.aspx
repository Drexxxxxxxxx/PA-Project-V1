<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation ="false" CodeBehind="testegridview.aspx.cs" Inherits="Avaliadores_Empresas.testegridview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
    <script src="../JS/jquery.sumoselect.min.js"></script>
    <link href="../CSS/sumoselect.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <asp:button text="Get Values" visible="false" id="btnGetSelectedValues" onclick="btnGetSelectedValues_Click" runat="server"></asp:button>
        <asp:listbox runat="server" id="lstBoxTes2t" selectionmode="Multiple">
            <asp:listitem text="Red" value="0"></asp:listitem>
            <asp:listitem text="Green" value="1"></asp:listitem>
            <asp:listitem text="Yellow" value="2"></asp:listitem>
            <asp:listitem text="Blue" value="3"></asp:listitem>
            <asp:listitem text="Black" value="4"></asp:listitem>
        </asp:listbox>
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            $(<%=lstBoxTes2t.ClientID%>).SumoSelect();
        });
    </script>
</body>
</html>
