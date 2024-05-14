<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminUsuario.aspx.cs" Inherits="proWeb.adminUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Administrar Usuarios y Trabajadores</title>
    <link rel="stylesheet" href="styles.css" />
</asp:Content>
        
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="admin-users">
            <!--Aquí puedo poner un <div class="header"> pero tengo que ver si hacerlo o no (2?) -->
            <div class="header">
                <h1 class="title">
                    Usuarios Registrados 
                </h1>
            </div>
            <asp:Repeater ID="rptUsuarios" runat="server">
                <ItemTemplate>
                    <div class="user">
                        <div style="width: 150px; height: 150px; background-color: #FFFFE0; border-radius: 8px;"></div>
                        <div>
                            <h2 class="title"><%# Eval("Name") %> <%# Eval("Surnames") %></h2>
                            <p class="email">Correo Electrónico: <%# Eval("Email") %></p>
                        </div>
                        <div class="mod-buttons">
                            <button type="button" class="mostrar"
                                data-bs-toggle="popover"
                                data-bs-custom-class="custom-popover"
                                data-bs-title="Información del usuario"
                                data-bs-content='<%# "NIF: " + Eval("NIF") 
                                    + "\nNúmero de Teléfono: " + Eval("PhoneNumber") %>'>
                                Mostrar Más
                            </button>
                        </div> 
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            </div>
        
            <!-- Y aqui el listado de trabajadores -->
            <div class="admin-users">
                <div class="header">
                    <h1 class="title">
                        Trabajadores
                    </h1>
                </div>   
            
            <asp:Repeater ID="rptTrabajadores" runat="server">
                <ItemTemplate>
                    <div class="user">
                        <div style="width: 150px; height: 150px; background-color: #FFFFE0; border-radius: 8px;"></div>
                        <div>
                            <h2 class="title"><%# Eval("Name") %> <%# Eval("Surnames") %></h2>
                            <p class="email">Correo Electrónico: <%# Eval("Email") %></p>
                        </div>
                        <div class="mod-buttons">
                            <button type="button" class="mostrar"
                                data-bs-toggle="popover"
                                data-bs-custom-class="custom-popover"
                                data-bs-title="Información del usuario"
                                data-bs-content='<%# "NIF: " + Eval("NIF") %>'>
                                Mostrar Más
                            </button>
                            <button class="deleteUser">
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

              <form class="dropdown-menu p-4 dropdown-form" position="relative">
                <div class="mb-3">
                  <label for="Nombre" class="form-label">Nombre</label>
                  <input type="email" class="form-control" id="nombreTrabajador">
                </div>
                <div class="mb-3">
                  <label for="Apellidos" class="form-label">Apellidos</label>
                  <input type="email" class="form-control" id="ApellidosTrabajador">
                </div>
                <div class="mb-3">
                  <label for="email" class="form-label">Correo Electrónico</label>
                  <input type="email" class="form-control" id="emailTrabajador" placeholder="email@example.com">
                </div>
                <div class="mb-3">
                  <label for="teléfono" class="form-label">Número de Teléfono</label>
                  <input type="email" class="form-control" id="telfTrabajdor">
                </div>
                <div class="mb-3">
                  <label for="nif" class="form-label">NIF/DNI</label>
                  <input type="email" class="form-control" id="NIFTrabajador">
                </div>
                <button type="submit" class="btn btn-primary">Añadir</button>
              </form>
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
