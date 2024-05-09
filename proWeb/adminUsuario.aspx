<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminUsuario.aspx.cs" Inherits="proWeb.adminUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Administrar Usuarios y Trabajadores</title>
    <link rel="stylesheet" href="styless.css" />
</asp:Content>
        
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body{
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            text-align: justify;
            background-color: #f5f5f5;
        }

        .admin-users{
            max-width: 100%;
            margin: 20px auto;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            overflow: hidden;
        }

        .title{
            margin-left:20px;
        }
        .create {
            background-color: #393185;
            color: #fff;
            border: none;
            padding: 8px 12px;
            border-radius: 5px;
            cursor: pointer;    
            font-size: 20px;
            transition: background-color 0.3s;
            
        }

        .header{
            display: flex;
            flex-direction: row; 
            align-items: center; 
            margin-right: 20px;
        }

        .Productos{
            display: flex;
            flex-direction: column;
        }

        .user{
            display: flex;
            border-top: 1px solid #ccc;
        }

        .nif{
            margin-left: 25px;
            font-weight: bold;
            color: #007bff;
        }
        .gmail{
            margin-left: 25px;
            font-style: italic;
            color: #666;    
        }

        .edit{
            background-color: #137e93;
            color: #fff;
            border: none;
            padding: 8px 12px;
            border-radius: 5px;
            cursor: pointer;    
            font-size: 16px;
            transition: background-color 0.3s;
            margin: 10px;
            width: 150px;
        }

        .delete{
            background-color: #b12d44;
            color: #fff;
            border: none;
            padding: 8px 12px;
            border-radius: 5px;
            cursor: pointer;    
            font-size: 16px;
            transition: background-color 0.3s;
            margin: 10px;
             width: 150px;
        }

        .mod-buttons{
            margin-top: auto;
            margin-bottom: auto;
            display: flex;
            flex-direction: column; 
            align-items: center; 
            margin-right: 20px;
            margin-left: auto;
        }

        .dropdown-toggle.btn-primary {
        background-color: #393185; /* Cambia el color de fondo del botón dropdown */
        }

    </style>

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
                            <p class="nif">Correo Electrónico: <%# Eval("Email") %></p>
                        </div>
                        <div class="mod-buttons">
                            <button type="button" class="edit"
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
                            <p class="nif">Correo Electrónico: <%# Eval("Email") %></p>
                        </div>
                        <div class="mod-buttons">
                            <button type="button" class="edit"
                                data-bs-toggle="popover"
                                data-bs-custom-class="custom-popover"
                                data-bs-title="Información del usuario"
                                data-bs-content='<%# "NIF: " + Eval("NIF") %>'>
                                Mostrar Más
                            </button>
                            <button class="delete">
                                <i class="fa-solid fa-trash"></i>
                                Eliminar
                            </button>
                        </div>     
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            
        
            <div class="dropdown">
              <button type="button" class="btn btn-primary dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false" data-bs-auto-close="outside">
                Dropdown form
              </button>

              <form class="dropdown-menu p-4">
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
