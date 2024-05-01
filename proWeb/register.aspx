<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="proWeb.register" %>
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
        width : 30%;
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
    .login-form input[type="password"],
    .login-form input[type="email"] {
      width: 90%;
      padding: 10px;
      border: 1px solid #ccc;
      border-radius: 4px;
      margin-bottom: 15px;
    }

    .login-form form {
      display: flex;
      flex-direction: column; /* Stack inputs and buttons vertically */

    }

    .login-form button {
        width: 90%;
      background-color: #0f7bff;
      color: #fff;
      padding: 10px 20px;
      border: none;
      border-radius: 4px;
      cursor: pointer;
      margin-top: 10px; /* Add spacing between button and form elements */
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
        <h1>Registrarse</h1>

        <form method="post">
          <div class="form-group">
            <label for="Nombre">*Nombre:</label>
            <asp:TextBox ID="Nombre" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="Apellidos">*Apellidos:</label>
            <asp:TextBox ID="Apellidos" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="Email">*Email:</label>
            <asp:TextBox ID="Email" runat="server" TextMode="Email" CssClass="form-control" Required="true"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="Contraseña">*Contraseña:</label>
            <asp:TextBox ID="Contraseña" runat="server" TextMode="Password" CssClass="form-control" Required="true"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="Telefono">Teléfono:</label>
            <asp:TextBox ID="Telefono" runat="server" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="NIF">*NIF/DNI:</label>
            <asp:TextBox ID="NIF" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="Direccion">*Dirección:</label>
            <asp:TextBox ID="Dirección" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div>
                *Opciones obligatorias
            </div>
          <div>
          <button type="submit" class="btn btn-primary">Registrarse</button>
          </div>
        </form>
      </div>
    </div>
  </body>
  </html>
</asp:Content>