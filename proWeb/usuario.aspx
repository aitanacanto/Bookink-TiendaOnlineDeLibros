<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="proWeb.usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="styles.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#btnVerMasDirecciones").click(function () {
                $("#collapseDirecciones").toggle();
            });
        });

        function confirmarEliminacion(id) {
            return confirm('¿Está seguro de que desea eliminar esta dirección?');
        }
    </script>
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
                <td class="input-column">
                    <asp:TextBox ID="txtDireccionNueva" runat="server"></asp:TextBox>
                </td>
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
            <tr>
                <td class="label-column" colspan="3">
                    <asp:Button ID="btnVerMasDirecciones" runat="server" Text="Ver más direcciones" OnClientClick="return false;" />
                </td>
            </tr>
        </table>

        <div id="collapseDirecciones" style="display:none;">
            <h2>Direcciones Adicionales</h2>
            <asp:Repeater ID="repeaterDirecciones" runat="server">
                <HeaderTemplate>
                    <table class="address-table">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="label-column">Dirección:</td>
                        <td class="data-column"><%# Eval("Direccion") %></td>
                    </tr>
                    <tr>
                        <td class="label-column">Código Postal:</td>
                        <td class="data-column"><%# Eval("CodPostal") %></td>
                    </tr>
                    <tr>
                        <td class="label-column">Ciudad:</td>
                        <td class="data-column"><%# Eval("Ciudad") %></td>
                    </tr>
                    <tr>
                        <td class="label-column">País:</td>
                        <td class="data-column"><%# Eval("Pais") %></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnEliminarDireccion" runat="server" Text="Eliminar" CommandArgument='<%# Eval("ID") %>' OnClick="BtnEliminarDireccion_Click" OnClientClick="return confirmarEliminacion();" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><hr /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Button ID="btnAgregarDireccion" runat="server" Text="Agregar Dirección" OnClick="BtnAgregarDireccion_Click" />
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
