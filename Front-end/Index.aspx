<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Prueba_Tecnica_Loymark.Front_end.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-/bQdsTh/da6pkI1MST/rWKFNjaCP5gBSY4sEBT38Q/9RBh9AH40zEOg7Hlq2THRZ" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css"/>
    <title>Pagina Principal </title>
</head>
<body>
    <form id="form1" runat="server">
        <header class="p-3 mb-3 border-bottom">
            <div class="container">
                <div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                    <nav class="navbar navbar-default">
                        <div class="container-fluid">
                            <div class="navbar-header">
                                
                                    <asp:Image runat="server" Height="40" src="/Archivos/Imagenes/logo.png" />
                                </>
                            </div>
                        </div>
                    </nav>
                    <ul class="nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0">
                        <li><a href="/Front-end/Index.aspx" class="nav-link px-2 link-secondary">Inicio</a></li>
                        <li><a href="Actividades.aspx" class="nav-link px-2 link-dark" >Actividades </a></li>
                        <li><a href="Usuarios.aspx" class="nav-link px-2 link-dark">Usuarios</a></li>
                        <li><a href="/Front-end/Back-end/Perfil.aspx" class="nav-link px-2 link-dark">Configuracion</a></li>
                    </ul>
                    <div>
                        <asp:Label runat="server" ID="lblUsuario"></asp:Label>
                    </div>
                    <div class="dropdown text-end">
                        <a href="#" class="d-block link-dark text-decoration-none dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false">
                            <asp:Image runat="server" ID="imgPerfil" Width="50" Height="50" CssClass="rounded-circle img-thumbnail" />
                        </a>
                        <ul class="dropdown-menu text-small" aria-labelledby="dropdownuser">
                            <li>
                                <asp:Button runat="server" Text="Perfil" class="dropdown-item" OnClick="Perfil" ></asp:Button>
                            </li>
                            <li>
                                <hr class="dropdown-divider" />
                            </li>
                            <li>
                                <asp:Button runat="server" Text="Cerrar sesión" class="dropdown-item"  OnClick="Salir" ></asp:Button>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </header>
        <div>

        </div>
    </form>
</body>
</html>