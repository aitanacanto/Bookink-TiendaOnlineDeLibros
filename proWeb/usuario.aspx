<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="proWeb.usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="styles.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container content-box">
        <h1 class="admin-title">Mi cuenta</h1>
        
        <table class="user-info-table">
            <tr>
                <td class="label-column"><asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label></td>
                <td class="data-column"><asp:Label ID="lblNombreActual" runat="server" Text=""></asp:Label></td>
                <td class="input-column"></td>
            </tr>
            <tr>
                <td class="label-column"><asp:Label ID="lblCorreo" runat="server" Text="Correo electrónico:"></asp:Label></td>
                <td class="data-column"><asp:Label ID="lblCorreoActual" runat="server" Text=""></asp:Label></td>
                <td class="input-column"><asp:TextBox ID="txtCorreoNuevo" runat="server" TextMode="Email" placeholder="Ingrese su nuevo correo electrónico"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-column"><asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label></td>
                <td class="data-column"><asp:Label ID="lblContraseñaActual" runat="server" Text="********" CssClass="password"></asp:Label></td>
                <td class="input-column"><asp:TextBox ID="txtContraseñaNueva" runat="server" TextMode="Password" placeholder="Ingrese su nueva contraseña"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-column"><asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label></td>
                <td class="data-column"><asp:Label ID="lblTelefonoActual" runat="server" Text=""></asp:Label></td>
                <td class="input-column"><asp:TextBox ID="txtTelefonoNuevo" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3"><hr /></td>
            </tr>
            <tr>
                <td class="label-column"><asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label></td>
                <td class="data-column"><asp:Label ID="lblDireccionActual" runat="server" Text=""></asp:Label></td>
                <td class="input-column"><asp:TextBox ID="txtDireccionNueva" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-column"><asp:Label ID="lblCodPostal" runat="server" Text="Código Postal:"></asp:Label></td>
                <td class="data-column"><asp:Label ID="lblCodPostalActual" runat="server" Text=""></asp:Label></td>
                <td class="input-column"><asp:TextBox ID="txtCodPostalNuevo" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-column"><asp:Label ID="lblCiudad" runat="server" Text="Ciudad:"></asp:Label></td>
                <td class="data-column"><asp:Label ID="lblCiudadActual" runat="server" Text=""></asp:Label></td>
                <td class="input-column"><asp:TextBox ID="txtCiudadNueva" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="label-column"><asp:Label ID="lblPais" runat="server" Text="País:"></asp:Label></td>
                <td class="data-column"><asp:Label ID="lblPaisActual" runat="server" Text=""></asp:Label></td>
                <td class="input-column"><asp:TextBox ID="txtPaisNuevo" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        
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
