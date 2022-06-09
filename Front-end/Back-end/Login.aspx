<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Prueba_Tecnica_Loymark.Front_end.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-/bQdsTh/da6pkI1MST/rWKFNjaCP5gBSY4sEBT38Q/9RBh9AH40zEOg7Hlq2THRZ" crossorigin="anonymous"></script>
    <title>Inicio de sesión</title>
</head>
<body>
    <form id="form1" runat="server" class="container d-flex justify-content-center align-items-center">
      <br />
    <br />
    <br />
    <br />
 
        <div class="col-5">
            <div class="form-control card card-body align-items-center">
                <div class="modal-title align-content-center h3">
                    <asp:Label runat="server" Text="Inicio de sesión" Font-Size="Larger"></asp:Label>
                </div>
                <br />
                 <!-- TextBox y Solicitud de datos-->
                <div class="input-group">
                    <asp:TextBox runat="server" CssClass="form-control" placeholder="User" ID="tbUsuario"></asp:TextBox>
                </div>
                <br />
                <div class="input-group">
                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" ID="tbClave"></asp:TextBox>
                </div>
                <br />
                <div class="input-group">
                    <asp:Button runat="server" CssClass="form-control btn btn-dark" Text="Iniciar Sesión" OnClick="Unnamed2_Click" ></asp:Button>
                </div>
                <br />
                <br />
                <div>
                    <asp:Label runat="server" ID="lblError" class="alert-danger"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="¿No tienes una cuenta?, Regístrate"></asp:Label>
                    <asp:LinkButton runat="server" Text=" aquí" OnClick="Unnamed4_Click" ></asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>