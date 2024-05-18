<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="proWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Enlace al archivo CSS -->
    <link rel="stylesheet" href="styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="login-form container">
      <asp:Login ID="loginForm" runat ="server">
          <LayoutTemplate>
              <h1>INICIO DE SESIÓN</h1>
              <div class="mb-3">
                  <label for="UserName" class="form-label">Correo electrónico</label>
                  <asp:TextBox ID="UserName" runat="server" type="email" class="form-control" aria-describedby="emailHelp" placeholder ="nombre@ejemplo.com"></asp:TextBox>
                  <div id="emailHelp" class="form-text">No compartiremos tu email con nadie ;).</div>
              </div>
              <div class="mb-3">
                  <label for="Password" class="form-label">Contraseña</label>
                  <asp:TextBox ID="Password" runat="server" type="password" class="form-control" placeholder ="1234"></asp:TextBox>
              </div>
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
          </LayoutTemplate>
      </asp:Login>
      <asp:Label ID="LabelOculta" runat="server" Visible="false">fdsafjdasklfjdas</asp:Label>          
  </div>
</asp:Content>
