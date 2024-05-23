<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="proWeb.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Enlace al archivo CSS -->
    <link rel="stylesheet" href="styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container login-form">
            <h1>Registrarse</h1>
            <div class="mb-3">
                <label for="Nombre">Nombre</label>
                <asp:TextBox ID="Nombre" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Apellidos">Apellidos</label>
                <asp:TextBox ID="Apellidos" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Email">Email</label>
                <asp:TextBox ID="Email" runat="server" TextMode="Email" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Contraseña">Contraseña</label>
                <asp:TextBox ID="Contraseña" runat="server" TextMode="Password" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="mb-3">Teléfono</label>
                <asp:TextBox ID="Telefono" runat="server" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="NIF">DNI</label>
                <asp:TextBox ID="NIF" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3 related-products">
                <div class="mb-3 flex-item">
                    <label for="cop_postal">Código postal</label>
                    <asp:TextBox ID="cod_postal" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
                </div>
                <div class="mb-3 flex-item">
                    <label for="calle">Calle</label>
                    <asp:TextBox ID="calle" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
                </div>
                <div class="mb-3 flex-item">
                    <label for="Ciudad">Ciudad</label>
                    <asp:TextBox ID="ciudad" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
                </div>
                <div class="mb-3 flex-item">
                    <label for="Pais">País</label>
                    <asp:TextBox ID="pais" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
                </div>
            </div>
            <div>
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