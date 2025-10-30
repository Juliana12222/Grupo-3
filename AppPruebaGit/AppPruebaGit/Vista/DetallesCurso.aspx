<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallesCurso.aspx.cs" Inherits="appCursosP.Vista.DetallesCurso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Detalles Cursos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <asp:Repeater ID="PaginaDetalles" runat="server">
                <ItemTemplate>
                    <div class="card shadow-lg p-4">
                        <div class="row">
                            <div class="col-md-5">
                                <img src='<%#Eval("imgCurso")%>' class="img-fluid rounded" alt="" />
                            </div>
                            <div class="col-md-7">
                                <h3><%# Eval("nombreCurso")%></h3>
                                <p class="text-muted">Duracion: <%#Eval("tiempo") %> </p>
                                <p><%#Eval("descripcion") %> </p>
                                <p class="text-primary">Precio: <%#Eval("precio","{0:C}") %> </p>
                                <asp:Button ID="btnInscribirse" runat="server"
                                    Text="Inscribirse"
                                    CssClass="btn btn-primary boton-espaciado"
                                    OnClientClick="return validarSesion();"
                                    CommandArgument='<%# Eval("idCurso") %>'
                                    OnCommand="btnInscripcion_Command" />
                            </div>

                        </div>

                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
