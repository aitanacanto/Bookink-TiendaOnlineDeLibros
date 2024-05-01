<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="proWeb.WebForm1" %>
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
    .login-form botones{
      display: flex;
      width: 100%;
      justify-content: space-between;
    }
    .login-form form {
      display: flex;
      justify-content: space-between; /* Align buttons horizontally */
    }
    .login-form h1 {
      text-align: center;
      margin-bottom: 20px;
    }
  </style>

  <div class="container">
      <form class="login-form">
          <h1>INICIO DE SESIÓN</h1>
          <div class="mb-3">
              <label for="exampleInputEmail1" class="form-label">Correo electrónico</label>
              <asp:TextBox runat="server" type="email" class="form-control" ID="exampleInputEmail1" aria-describedby="emailHelp"></asp:TextBox>
              <div id="emailHelp" class="form-text">No compartiremos tu email con nadie ;).</div>
          </div>
          <div class="mb-3">
              <label for="exampleInputPassword1" class="form-label">Contraseña</label>
              <asp:TextBox runat="server" type="password" class="form-control" id="exampleInputPassword1"></asp:TextBox>
          </div>
          <div class="mb-3 form-check">
              <input type="checkbox" class="form-check-input" id="exampleCheck1">
              <label class="form-check-label" for="exampleCheck1">Mostrar contraseña</label>
          </div>
          <div class="botones">
              <button type="submit" class="btn btn-primary">Iniciar sesión</button>
              <button type="submit" class="btn btn-primary">Registrase</button>
          </div>
      </form>
  </div>
</asp:Content>
