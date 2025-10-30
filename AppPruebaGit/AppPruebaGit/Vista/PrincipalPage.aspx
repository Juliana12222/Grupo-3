<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrincipalPage.aspx.cs" Inherits="appCursosP.Vista.PrincipalPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Principal</title>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.css" rel="stylesheet" />
    <style>
        body {
            background-color: #FFFFF0;
            margin: 0;
            padding: 0;
        }
    </style>
    <style>
        .modal.fade .modal-dialog {
            transform: translateY(-40px);
            transition: transform 0.35s ease-out;
        }

        .modal.fade.show .modal-dialog {
            transform: translateY(0);
        }

        .modal.fade:not(.show) .modal-dialog {
            transition-delay: 0.05s;
        }
    </style>
    <style>
        .carousel-item {
            transition: transform 0.6s ease-in-out;
        }
    </style>
    <style>
        .imgCarrusel {
            height: 290px;
            object-fit: cover;
        }
    </style>
    <style>
        .carousel-control-next-icon,
        .carousel-control-prev-icon {
            background-color: #0026ff;
            border-radius: 50%;
            padding: 10px;
        }
    </style>
    <style>
        .card {
            font-size: 0.9rem;
        }

        .card-img-top {
            height: 180px;
            object-fit: cover;
        }
    </style>
    <style>
        .boton-espaciado {
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <nav class="navbar navbar-expand-lg bg-#FFFFF0 px-3 ">
            <a class="navbar-brand d-flex align-items-center text-dark" href="#">
                <img src="Imagenes/LogoPagina.png" width="90" height="90" class="d-inline-block align-text-top me-2" />
            </a>
            <div class="ms-auto d-flex align-items-center">
                <button id="btnLogin" runat="server" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#login">
                    Login
                </button>
                <button id="btnRegistrarse" runat="server" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#Registrar">
                    Registrar
                </button>

                <asp:Label ID="LblNombreUsuario" runat="server" CssClass="fw-bold text-primary"></asp:Label>
                <asp:Button ID="BtnCursosInscrito" runat="server" Text="Cursos Inscritos" CssClass="btn btn-primary ms-2"
                    OnClick="BtnCursosInscrito_Click" />


                <div class="modal fade" id="login" tabindex="-1" role="dialog" aria-labelledby="Iniciotext" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="Iniciotext">Login</h5>
                            </div>
                            <div class="modal-body">
                                <div class="container d-flex align-items-center justify-content-center">
                                    <div class="text-center mb-4">
                                        <i class="bi bi-person-circle display-1 text-primary"></i>
                                        <h3 class="mt-2">Iniciar Sesión</h3>
                                        <div class="mb-3">
                                            <asp:Label ID="LblUsuario" runat="server" Text="Usuario" AssociatedControlID="txtUsuario" CssClass="form-label"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-text"><i class="bi bi-person"></i></span>
                                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Digite Email" TextMode="Email"></asp:TextBox>
                                            </div>
                                            <div class="mb-3">
                                                <asp:Label ID="LblContraseña" runat="server" Text="Contraseña" AssociatedControlID="txtContraseña" CssClass="form-label"></asp:Label>
                                                <div class="input-group">
                                                    <span class="input-group-text"><i class="bi bi-person"></i></span>
                                                    <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" placeholder="Digite Contraseña" TextMode="Password"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="d-grid">
                                                <asp:Button ID="btnIngreso" runat="server" Text="Iniciar Sesion" OnClick="btnIngreso_Click" CssClass="btn btn-primary" UseSubmitBehavior="false" /><br />
                                            </div>


                                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

                                        </div>

                                    </div>
                                </div>

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>

                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal fade" id="Registrar" tabindex="-1" role="dialog" aria-labelledby="Registrotext" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="Registrotext">Registrar</h5>
                            </div>
                            <div class="modal-body">
                                <div class="container d-flex align-items-center justify-content-center">
                                    <div class="text-center mb-4">
                                        <i class="bi bi-person-circle display-1 text-primary"></i>
                                        <h3 class="mt-2">Registrarse</h3>
                                        <div class="mb-3">
                                            <asp:Label ID="lblNombre" runat="server" Text="Nombre" AssociatedControlID="txtNombre" CssClass="form-label"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-text"><i class="bi bi-person"></i></span>
                                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Digite Nombre"></asp:TextBox>
                                            </div>
                                            <asp:Label ID="lblApellido" runat="server" Text="Apellido" AssociatedControlID="txtApellido" CssClass="form-label"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-text"><i class="bi bi-person"></i></span>
                                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Digite Apellido"></asp:TextBox>
                                            </div>
                                            <asp:Label ID="lblTelefono" runat="server" Text="Telefono" AssociatedControlID="txtApellido" CssClass="form-label"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-text"><i class="bi bi-person"></i></span>
                                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Digite Telefono"></asp:TextBox>
                                            </div>
                                            <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="txtEmail" CssClass="form-label"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-text"><i class="bi bi-person"></i></span>
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Digite Email"></asp:TextBox>
                                            </div>
                                            <asp:Label ID="lblDireccion" runat="server" Text="Direccion" AssociatedControlID="txtDireccion" CssClass="form-label"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-text"><i class="bi bi-person"></i></span>
                                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Digite Direccion"></asp:TextBox>
                                            </div>
                                            <asp:Label ID="lblContraseñaR" runat="server" Text="Contraseña" AssociatedControlID="txtContraseñaR" CssClass="form-label"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-text"><i class="bi bi-person"></i></span>
                                                <asp:TextBox ID="txtContraseñaR" runat="server" CssClass="form-control" placeholder="Digite Contraseña"></asp:TextBox>
                                            </div>

                                            <div class="d-grid">
                                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" OnClick="btnRegistro_Click" CssClass="btn btn-primary" UseSubmitBehavior="false" /><br />
                                            </div>


                                            <asp:Label ID="lblMensaje2" runat="server" Text=""></asp:Label>

                                        </div>

                                    </div>
                                </div>

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </nav>
        <div class="container mt-4" style="max-width: 700px;">
            <div id="ImagenesCarrusel" class="carousel slide" data-bs-ride="carousel" data-bs-interval="3000" style="max-width: 700px;">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <asp:Image ID="img1" runat="server" CssClass="d-block w-100 rounded imgCarrusel" ClientIDMode="Static" />
                    </div>
                    <div class="carousel-item ">
                        <asp:Image ID="Img2" runat="server" CssClass="d-block w-100 rounded imgCarrusel" ClientIDMode="Static" />
                    </div>
                    <div class="carousel-item ">
                        <asp:Image ID="Img3" runat="server" CssClass="d-block w-100 rounded imgCarrusel" ClientIDMode="Static" />
                    </div>
                </div>
                <button class="btn position-absolute top-50 start-0 translate-middle-y" style="margin-left: -70px;" type="button" data-bs-target="#ImagenesCarrusel" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Anterior</span>
                </button>
                <button class="btn position-absolute top-50 end-0 translate-middle-y" style="margin-right: -70px;" type="button" data-bs-target="#ImagenesCarrusel" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Siguiente</span>
                </button>
            </div>
        </div>
        <div class="container mt-4">
            <div class="row">
                <asp:Repeater ID="RptCursos" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-3">
                            <div class="card h-100">
                                <asp:Image ID="img5" runat="server" ImageUrl='<%# Eval("imgCurso") %>' CssClass="card-img-top" />
                                <div class="card-body d-flex flex-column">
                                    <h5 class="card-title"><%# Eval("nombreCurso") %></h5>
                                    <p class="card-text"><%# Eval("descripcion") %></p>
                                    <p class="card-text fw-bold">Precio: <%# Eval("precio", "{0:C}") %></p>
                                    <p class="card-text">Duración: <%# Eval("tiempo") %></p>
                                    <asp:Button ID="btnInscribirse" runat="server"
                                        Text="Inscribirse"
                                        CssClass="btn btn-primary boton-espaciado"
                                        OnClientClick="return validarSesion();"
                                        CommandArgument='<%# Eval("idCurso") %>'
                                        OnCommand="btnInscripcion_Command" />
                                    <asp:Button ID="btnDescripcion" runat="server"
                                        PostBackUrl='<%# "DetallesCurso.aspx?idCurso=" + Eval("idCurso") %>'
                                        Text="Descripcion"
                                        CssClass="btn btn-outline-primary mt-auto" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="modal fade" id="modalInscripcion" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Aviso</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                    </div>
                    <div class="modal-body" id="cuerpoModalInscripcion"></div>
                </div>
            </div>
        </div>


        <div id="alertInscripcion" class="alert alert-success alert-dismissible fade show position-fixed top-0 end-0 m-3" role="alert" style="display: none; z-index: 1050;">
            <span id="mensajeAlerta"></span>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
