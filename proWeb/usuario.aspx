<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="proWeb.usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="styles.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#btnVerMasDirecciones").click(function () {
                $("#collapseDirecciones").toggle();
            });

            $(".btnEditarDireccion").click(function () {
                var row = $(this).closest("tr");
                row.find(".data-label").hide();
                row.find(".data-input").show();
                row.find(".btnEditarDireccion").hide();
                row.find(".btnConfirmarEdicion").show();
            });

            $(".btnConfirmarEdicion").click(function () {
                var row = $(this).closest("tr");
                row.find(".data-label").show();
                row.find(".data-input").hide();
                row.find(".btnEditarDireccion").show();
                row.find(".btnConfirmarEdicion").hide();
            });

            $("#btnMostrarFormularioAgregar").click(function () {
                $("#formularioAgregarDireccion").toggle();
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
                <td class="label-column" colspan="3">
                    <button class="btn btn-primary" type="button" data-bs-toggle="collapse" data-bs-target="#collapseDirecciones" aria-expanded="false" aria-controls="collapseDirecciones">
                        Ver direcciones
                    </button>
                </td>
            </tr>
        </table>

        <div class="collapse" id="collapseDirecciones">
            <h2>Direcciones Asociadas</h2>
            <asp:Repeater ID="repeaterDirecciones" runat="server">
                <HeaderTemplate>
                    <table class="table">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td colspan="2"><h3>Dirección <%# Container.ItemIndex + 1 %></h3></td>
                    </tr>
                    <tr>
                        <td class="label-column">Dirección:</td>
                        <td class="data-column">
                            <span class="data-label"><%# Eval("Direccion") %></span>
                            <asp:TextBox ID="txtDireccion" runat="server" Text='<%# Eval("Direccion") %>' CssClass="data-input" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="label-column">Código Postal:</td>
                        <td class="data-column">
                            <span class="data-label"><%# Eval("CodPostal") %></span>
                            <asp:TextBox ID="txtCodPostal" runat="server" Text='<%# Eval("CodPostal") %>' CssClass="data-input" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="label-column">Ciudad:</td>
                        <td class="data-column">
                            <span class="data-label"><%# Eval("Ciudad") %></span>
                            <asp:TextBox ID="txtCiudad" runat="server" Text='<%# Eval("Ciudad") %>' CssClass="data-input" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="label-column">País:</td>
                        <td class="data-column">
                            <span class="data-label"><%# Eval("Pais") %></span>
                            <asp:TextBox ID="txtPais" runat="server" Text='<%# Eval("Pais") %>' CssClass="data-input" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnEditarDireccion" runat="server" Text="Editar" CommandArgument='<%# Eval("ID") %>' OnClick="BtnEditarDireccion_Click" CssClass="btnEditarDireccion" />
                            <asp:Button ID="btnConfirmarEdicion" runat="server" Text="Confirmar" CommandArgument='<%# Eval("ID") %>' OnClick="BtnConfirmarEdicion_Click" CssClass="btnConfirmarEdicion" Visible="false" />
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
            <button type="button" class="btn btn-primary" id="btnMostrarFormularioAgregar">Agregar Dirección</button>
            
            <div id="formularioAgregarDireccion" style="display:none;">
                <table class="user-info-table">
                    <tr>
                        <td class="label-column"><asp:Label ID="lblNuevaDireccion" runat="server" Text="Dirección:"></asp:Label></td>
                        <td class="input-column"><asp:TextBox ID="txtNuevaDireccion" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="label-column"><asp:Label ID="lblNuevoCodPostal" runat="server" Text="Código Postal:"></asp:Label></td>
                        <td class="input-column"><asp:TextBox ID="txtNuevoCodPostal" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="label-column"><asp:Label ID="lblNuevaCiudad" runat="server" Text="Ciudad:"></asp:Label></td>
                        <td class="input-column"><asp:TextBox ID="txtNuevaCiudad" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="label-column"><asp:Label ID="lblNuevoPais" runat="server" Text="País:"></asp:Label></td>
                        <td class="input-column"><asp:TextBox ID="txtNuevoPais" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Button ID="btnAgregarDireccion" runat="server" Text="Agregar" OnClick="BtnAgregarDireccion_Click" /></td>
                    </tr>
                </table>
            </div>
        </div>

        <!-- Botón para actualizar información -->
        <div class="button-container">
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar información" OnClick="BtnActualizar_Click" CssClass="button" />
            <asp:Button ID="btnLogOut" runat="server" Text="Cerrar Sesión" CssClass="button" OnClick="BtnLogOut" />
            <asp:Button ID="btnDeleteUser" runat="server" Text="Borrar Cuenta" CssClass="button" OnClick="BtnDeleteUser" />
        </div>

        <!-- Mensaje -->
        <div class="item">
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
