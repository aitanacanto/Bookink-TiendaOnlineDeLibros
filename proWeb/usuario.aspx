<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="proWeb.usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Mi cuenta</h2>
        
        <!-- Nombre -->
        <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
        <asp:Label ID="lblNombreActual" runat="server" Text=""></asp:Label>
        <br />
        
        <!-- Correo electrónico -->
        <asp:Label ID="lblCorreo" runat="server" Text="Correo electrónico:"></asp:Label>
        <asp:Label ID="lblCorreoActual" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="txtCorreoNuevo" runat="server" TextMode="Email" placeholder="Ingrese su nuevo correo electrónico"></asp:TextBox>
        <br />
        
        <!-- Contraseña -->
        <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label>
        <asp:Label ID="lblContraseñaActual" runat="server" Text="********" CssClass="password"></asp:Label>
        <asp:TextBox ID="txtContraseñaNueva" runat="server" TextMode="Password" placeholder="Ingrese su nueva contraseña"></asp:TextBox>
        <br />
        
        <!-- Teléfono -->
        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
        <asp:Label ID="lblTelefonoActual" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="txtTelefonoNuevo" runat="server"></asp:TextBox>
        <br />
        
        <!-- Dirección -->
        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label>
        <asp:Label ID="lblDireccionActual" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="txtDireccionNueva" runat="server"></asp:TextBox>
        <br />
        
        <!-- Botón para actualizar información -->
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar información" OnClick="btnActualizar_Click" />
        
        <!-- Historial de pedidos -->
        <!-- Aquí podrías agregar un enlace o una sección para ver el historial de pedidos del usuario -->
    </div>
</asp:Content>
