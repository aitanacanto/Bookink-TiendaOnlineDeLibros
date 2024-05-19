<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="proWeb.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Enlace al archivo CSS -->
    <link rel="stylesheet" href="styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container login-form">
            <h1>Registrarse</h1>
            <div class="mb-3">
                <label for="Nombre">*Nombre</label>
                <asp:TextBox ID="Nombre" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Apellidos">*Apellidos</label>
                <asp:TextBox ID="Apellidos" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Email">*Email</label>
                <asp:TextBox ID="Email" runat="server" TextMode="Email" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Contraseña">*Contraseña</label>
                <asp:TextBox ID="Contraseña" runat="server" TextMode="Password" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="mb-3">Teléfono</label>
                <asp:TextBox ID="Telefono" runat="server" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="NIF">*NIF/DNI</label>
                <asp:TextBox ID="NIF" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Direccion">*Dirección</label>
                <asp:TextBox ID="Dirección" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div>
                *Opciones obligatorias
                <asp:Label ID="LabelOculta" runat="server" Visible="false">fdsafjdasklfjdas</asp:Label>          
            </div>
            <div class="button-container" style="text-align: center; margin-top: 20px;"> 
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