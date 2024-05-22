<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminUsuario.aspx.cs" Inherits="proWeb.adminUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Administrar Usuarios y Trabajadores</title>
    <link rel="stylesheet" href="styles.css" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js" integrity="sha384-xO2eOqG9E1z4Oz+fa6sbXhfuLjYuxs5vjs3G9vb9CiHRUq3RivZtr4jXb8LBO+7p" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-b4gt1jrGC7Jh4AgTPSdUtOBvfO8shCk+5KVp5mwoqb0sFZgJGz4TO7vg6G9ckxs0" crossorigin="anonymous"></script>
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
                        <div class="d-flex justify-content-center" style="width: 150px; height: 150px; border-radius: 8px; ">
                            <asp:Image class="mb-2 mt-2" ImageUrl="content/fotocliente.png" runat="server"  />
                        </div>
                        <div>
                            <h2 class="title"><%# Eval("Name") %> <%# Eval("Surname") %></h2>
                            <p class="email">Correo Electrónico: <%# Eval("Email") %></p>
                        </div>
                        <div class="mod-buttons">
                            <button type="button" class="mostrar" data-bs-toggle="collapse" data-bs-target="#collapse<%# Eval("Id") %>" aria-expanded="false" aria-controls="collapse<%# Eval("Id") %>">
                                Mostrar Más
                            </button>
                            <asp:Button runat="server" ID="btnMakeAdmin" OnClick="btnMakeAdmin" CssClass="make-admin" CommandArgument='<%# Eval("Email") %>' Text="Hacer Admin"/>
                        </div>
                    </div>
                    <div class="collapse" id="collapse<%# Eval("Id") %>">
                        <div class="card card-body">
                            <p>NIF: <%# Eval("DNI") %></p>
                            <p>Número de Teléfono: <%# Eval("PhoneNumber") %></p>
                            <p>Correo Electrónico: <%# Eval("Email") %></p>
                            <p>Nombre: <%# Eval("Name") %></p>
                            <p>Apellidos: <%# Eval("Surname") %></p>
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
                        <div class="d-flex justify-content-center" style="width: 150px; height: 150px; border-radius: 8px; ">
                            <asp:Image class="mb-2 mt-2" ImageUrl="content/fototrabajador.jpg" runat="server"  />
                        </div>
                        <div>
                            <h2 class="title"><%# Eval("Name") %> <%# Eval("Surname") %></h2>
                            <p class="email">Correo Electrónico: <%# Eval("Email") %></p>
                        </div>
                        <div class="mod-buttons">
                            <button type="button" class="mostrar" data-bs-toggle="collapse" data-bs-target="#collapseTrabajador<%# Eval("Id") %>" aria-expanded="false" aria-controls="collapseTrabajador<%# Eval("Id") %>">
                                Mostrar Más
                            </button>
                            <asp:LinkButton runat="server" class="delete" OnClick="btnDel_Click" CommandArgument='<%# Eval("Email")%>'>
                                    <i class="fa-solid fa-trash"></i>
                                    Eliminar
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="collapse" id="collapseTrabajador<%# Eval("Id") %>">
                        <div class="card card-body">
                            <p>NIF: <%# Eval("DNI") %></p>
                            <p>Número de Teléfono: <%# Eval("PhoneNumber") %></p>
                            <p>Correo Electrónico: <%# Eval("Email") %></p>
                            <p>Nombre: <%# Eval("Name") %></p>
                            <p>Apellidos: <%# Eval("Surname") %></p>
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

    <div class="modal fade" id="deleteModal" tabindex="-1" aria-labelledby="deleteModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="deleteModalLabel">Eliminar Producto</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:Label id="idel" Text="ID" runat="server" />

                    <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:button id="btnDel" runat="server" type="button" class="btn btn-danger" OnClick="delete_click" Text="Eliminar"></asp:button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            setTimeout(function () {
                $("#<%= lblMensaje.ClientID %>").fadeOut(1); // 1000 milisegundos = 1 segundo
            }, 1); // 3000 milisegundos = 3 segundos
        });
    </script>



</asp:Content>
