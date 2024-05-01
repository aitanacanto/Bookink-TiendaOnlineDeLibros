<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="proWeb.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <style>
    body {
      background-color: #f2f2f2;
    }

    .container {
      width: 60%;
      min-width:400px;
      align-items: center;
      justify-content: center;
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

    <div class="container">
        <form method="post" class="login-form">
            <h1>Registrarse</h1>
            <div class="mb-3">
                <label for="Nombre">*Nombre:</label>
                <asp:TextBox ID="Nombre" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Apellidos">*Apellidos:</label>
                <asp:TextBox ID="Apellidos" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Email">*Email:</label>
                <asp:TextBox ID="Email" runat="server" TextMode="Email" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Contraseña">*Contraseña:</label>
                <asp:TextBox ID="Contraseña" runat="server" TextMode="Password" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="mb-3">Teléfono:</label>
                <asp:TextBox ID="Telefono" runat="server" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="NIF">*NIF/DNI:</label>
                <asp:TextBox ID="NIF" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
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
</asp:Content>