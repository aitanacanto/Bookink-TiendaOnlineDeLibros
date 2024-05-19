<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="proWeb.usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .container.content-box .item {
            text-align: left;
        }
    </style>
    
    <div class="container content-box">
        <h1 class="admin-title">Mi cuenta</h1>
        
        <!-- Nombre -->
        <div class="item">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:Label ID="lblNombreActual" runat="server" Text=""></asp:Label>
        </div>
        
        <!-- Correo electrónico -->
        <div class="item">
            <asp:Label ID="lblCorreo" runat="server" Text="Correo electrónico:"></asp:Label>
            <asp:Label ID="lblCorreoActual" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtCorreoNuevo" runat="server" TextMode="Email" placeholder="Ingrese su nuevo correo electrónico"></asp:TextBox>
        </div>
        
        <!-- Contraseña -->
        <div class="item">
            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label>
            <asp:Label ID="lblContraseñaActual" runat="server" Text="********" CssClass="password"></asp:Label>
            <asp:TextBox ID="txtContraseñaNueva" runat="server" TextMode="Password" placeholder="Ingrese su nueva contraseña"></asp:TextBox>
        </div>
        
        <!-- Teléfono -->
        <div class="item">
            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
            <asp:Label ID="lblTelefonoActual" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtTelefonoNuevo" runat="server"></asp:TextBox>
        </div>
        
        <!-- Dirección -->
         <div class="item">
            <asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label>
            <asp:Label ID="lblDireccionActual" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtDireccionNueva" runat="server"></asp:TextBox>
        </div>
        <!-- Código Postal -->
        <div class="item">
            <asp:Label ID="lblCodPostal" runat="server" Text="Código Postal:"></asp:Label>
            <asp:Label ID="lblCodPostalActual" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtCodPostalNuevo" runat="server"></asp:TextBox>
        </div>

        <!-- Ciudad -->
        <div class="item">
            <asp:Label ID="lblCiudad" runat="server" Text="Ciudad:"></asp:Label>
            <asp:Label ID="lblCiudadActual" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtCiudadNueva" runat="server"></asp:TextBox>
        </div>

        <!-- País -->
        <div class="item">
            <asp:Label ID="lblPais" runat="server" Text="País:"></asp:Label>
            <asp:Label ID="lblPaisActual" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtPaisNuevo" runat="server"></asp:TextBox>
        </div>

        
        <!-- Botón para actualizar información -->
        <div class="button-container">
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar información" OnClick="BtnActualizar_Click" CssClass="button" />
            <asp:Button ID="btnLogOut" runat="server" Text="Cerrar Sesión" OnClick="BtnLogOut" CssClass="button" />
            <asp:Button ID="btnDeleteUser" runat="server" Text="Borrar Cuenta" OnClick="BtnDeleteUser" CssClass="button" />
        </div>

        <!-- Mensaje -->
        <div class="item">
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>

    </div>
</asp:Content>
