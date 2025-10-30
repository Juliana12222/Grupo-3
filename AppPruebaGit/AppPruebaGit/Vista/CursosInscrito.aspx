<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CursosInscrito.aspx.cs" Inherits="appCursosP.Vista.CursosInscrito" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cursos InscritoS</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="mb-4">Cursos Inscritos</h2>
            <div class="row">
                <asp:Repeater ID="RptCursosInscrito" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-3">
                            <div class="card h-100">
                                <asp:Image ID="imgCurso" runat="server" ImageUrl='<%# Eval("imgCurso") %>' CssClass="card-img-top" />
                                <div class="card-body d-flex flex-column">
                                    <h5 class="card-title"><%# Eval("nombreCurso") %></h5>
                                    <p class="card-text"><%# Eval("descripcion") %></p>
                                    <p class="card-text fw-bold">Precio: <%# Eval("precio", "{0:C}") %></p>
                                    <p class="card-text">Duración: <%# Eval("tiempo") %></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
