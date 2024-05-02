<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="proWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Enlace al archivo CSS -->
    <link rel="stylesheet" href="styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
          </form>
<div class="button-container" style="text-align: center; margin-top: 20px;"> 
          <!-- Botón para Iniciar Sesión -->
          <asp:Button 
              ID="btnLogin" 
              runat="server" 
              Text="Iniciar Sesión" 
              CssClass="button" 
              OnClick="Login_Click" 
          />
          <!-- Botón para Registrarse -->
          <asp:Button 
              ID="btnRegister" 
              runat="server" 
              Text="Registrarse" 
              CssClass="button" 
              OnClick="Register_Click" 
          />
      </div>
  </div>
</asp:Content>
