<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminUsuario.aspx.cs" Inherits="proWeb.adminUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Administrar Usuarios y Trabajadores</title>
    <link rel="stylesheet" href="styles.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-info" Visible="false"></asp:Label>
        <div class="admin-users">
            <div class="header">
                <h1 class="title">Usuarios Registrados</h1>
            </div>
            <asp:Repeater ID="rptUsuarios" runat="server">
                <ItemTemplate>
                    <div class="user">
                        <div style="width: 150px; height: 150px; background-color: #FFFFE0; border-radius: 8px;"></div>
                        <div>
                            <h2 class="title"><%# Eval("Name") %> <%# Eval("Surname") %></h2>
                            <p class="email">Correo Electrónico: <%# Eval("Email") %></p>
                        </div>
                        <div class="mod-buttons">
                            <button type="button" class="mostrar"
                                data-bs-toggle="popover"
                                data-bs-html="true"
                                data-bs-custom-class="custom-popover"
                                data-bs-title="Información del usuario"
                                data-bs-content='<%# 
                                    "NIF: " + Server.HtmlEncode(Eval("DNI").ToString()) + "<br />" +
                                    "Número de Teléfono: " + Server.HtmlEncode(Eval("PhoneNumber").ToString()) + "<br />" +
                                    "Correo Electrónico: " + Server.HtmlEncode(Eval("Email").ToString()) + "<br />" +
                                    "Nombre: " + Server.HtmlEncode(Eval("Name").ToString()) + "<br />" +
                                    "Apellidos: " + Server.HtmlEncode(Eval("Surname").ToString())
                                %>'>
                                Mostrar Más
                            </button>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="admin-users">
            <div class="header">
                <h1 class="title">Trabajadores</h1>
            </div>
            <asp:Repeater ID="rptTrabajadores" runat="server">
                <ItemTemplate>
                    <div class="user">
                        <div style="width: 150px; height: 150px; background-color: #FFFFE0; border-radius: 8px;"></div>
                        <div>
                            <h2 class="title"><%# Eval("Name") %> <%# Eval("Surname") %></h2>
                            <p class="email">Correo Electrónico: <%# Eval("Email") %></p>
                        </div>
                        <div class="mod-buttons">
                            <button type="button" class="mostrar"
                                data-bs-toggle="popover"
                                data-bs-html="true"
                                data-bs-custom-class="custom-popover"
                                data-bs-title="Información del usuario"
                                data-bs-content='<%# 
                                    "NIF: " + Server.HtmlEncode(Eval("DNI").ToString()) + "<br />" +
                                    "Número de Teléfono: " + Server.HtmlEncode(Eval("PhoneNumber").ToString()) + "<br />" +
                                    "Correo Electrónico: " + Server.HtmlEncode(Eval("Email").ToString()) + "<br />" +
                                    "Nombre: " + Server.HtmlEncode(Eval("Name").ToString()) + "<br />" +
                                    "Apellidos: " + Server.HtmlEncode(Eval("Surname").ToString()) + "<br />"
                                %>'>
                                Mostrar Más
                            </button>
                            <button class="deleteUser" OnClick="btnBorrarTrabajador_Click" CommandArgument='<%# Eval("Id") %>'>
                                <i class="fa-solid fa-trash"></i>
                                Eliminar
                            </button>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div class="dropdown">
              <button type="button" class="btn btn-primary dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false" data-bs-auto-close="outside">
                Añadir trabajador
              </button>

              <div class="dropdown-menu p-4 dropdown-form">
                <div class="mb-3">
                  <label for="Nombre" class="form-label">Nombre</label>
                  <asp:TextBox ID="txtNombreTrabajador" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                  <label for="Apellidos" class="form-label">Apellidos</label>
                  <asp:TextBox ID="txtApellidosTrabajador" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                  <label for="email" class="form-label">Correo Electrónico</label>
                  <asp:TextBox ID="txtEmailTrabajador" runat="server" CssClass="form-control" placeholder="email@example.com"></asp:TextBox>
                </div>
                <div class="mb-3">
                  <label for="teléfono" class="form-label">Número de Teléfono</label>
                  <asp:TextBox ID="txtTelefonoTrabajador" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                  <label for="nif" class="form-label">NIF/DNI</label>
                  <asp:TextBox ID="txtNIFTrabajador" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnAgregarTrabajador" runat="server" Text="Añadir" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
              </div>
            </div>
        </div>
    </div>

    <script>
        // Inicializar todos los popovers
        var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
        var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
            return new bootstrap.Popover(popoverTriggerEl)
        });
    </script>
</asp:Content>
