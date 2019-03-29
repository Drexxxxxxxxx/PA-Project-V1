<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginatesteGridviewJavascript.aspx.cs" Inherits="Avaliadores_Empresas.PaginatesteGridviewJavascript" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        function addRow() {
            var trcontatos = document.createElement("tr");

            for (var c = 0; c < 5; c++) {

                var tdcontatos = document.createElement("td");

                tdcontatos.innerText = "Column " + c;
                tdcontatos.value = "ads";

                trcontatos.appendChild(tdcontatos);



                trcontatos.style.backgroundColor = "lightgrey";
            }



            tblcontatos.children[0].appendChild(trcontatos);

        }

</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                  <table id="tbl" width="60%" border="1">
             <tr>
                 <td>1</td>
                 <td>2</td>
                 <td>3</td>
                 <td>4</td>
                 <td>5</td>
             </tr>
      </table>
      <br/><br/>
      <input type="button" onclick="addRow();" value="Add Row" />
        </div>
    </form>
</body>
</html>
