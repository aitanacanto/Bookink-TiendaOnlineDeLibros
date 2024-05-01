<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="proWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html>
<html lang="es">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>@ViewData["Title"]</title>

  <style>
    body {
      font-family: sans-serif;
      background-color: #f2f2f2;
    }

    .container {
      display: flex;
      align-items: center;
      justify-content: center;
      min-height: 100vh;
    }

    .login-form {
        display: flex;
        flex-direction: column;
      background-color: #fff;
      padding: 50px 90px;
      border-radius: 30px;
      box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
    }

    .login-form h1 {
      text-align: center;
      margin-bottom: 20px;
    }

    .login-form label {
      display: block;
      margin-bottom: 5px;
    }

    .login-form input[type="text"],
    .login-form input[type="password"] {
      width: 90%;
      padding: 10px;
      border: 1px solid #ccc;
      border-radius: 4px;
      margin-bottom: 15px;
    }

    .login-form form {
      display: flex;
      justify-content: space-between; /* Align buttons horizontally */
    }
    
    .login-form button {
      background-color: #0f7bff;
      color: #fff;
      padding: 10px 20px;
      border: none;
      border-radius: 4px;
      cursor: pointer;
    }

    .login-form .error {
      color: red;
      margin-bottom: 15px;
    }
  </style>
</head>
<body>
  <div class="container">
    <div class="login-form">
      <h1>Iniciar sesión</h1>

      <form method="post">
        <div class="form-group">
          <label for="NombreUsuario">Nombre de usuario:</label>
          <input type="text" asp-for="NombreUsuario" class="form-control" />
        </div>
        <div class="form-group">
          <label for="Contraseña">Contraseña:</label>
          <input type="password" asp-for="Contraseña" class="form-control" />
        </div>
        <div class ="btn_container">
          <button type="submit" class="btn btn-primary">Iniciar sesión</button>
          <button type="submit" class="btn btn-primary">Registrarse</button>
        </div>
      </form>
    </div>
  </div>
</body>
</html>
</asp:Content>
