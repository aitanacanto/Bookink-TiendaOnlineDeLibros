
﻿<%@ Page Title="Administración de Categorías" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminCategoria.aspx.cs" Inherits="proWeb.adminCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="styles.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Listar Categorías -->
    <div class="admin-products">
        <div class="header">
            <h1 class="title">Administración de Categorías</h1>
            <div style="margin-left: auto;">
                <button class="create">Añadir Categoría</button>
            </div>
        </div>
        <div class="Productos">
            <div class="Producto">
                <div style="width: 150px; height: 150px; background-color: #FFFFE0; border-radius: 8px;"></div>
                <div>
                    <h2 class="title">Categoría 1</h2>
                </div>
                <div class="mod-buttons">
                    <button class="edit">
                        <i class="fa-solid fa-pen-to-square"></i>
                        Editar
                    </button>
                    <button class="delete">
                        <i class="fa-solid fa-trash"></i>
                        Eliminar
                    </button>
                </div>
            </div>

            <!-- Aquí se repetirían las categorías restantes -->

        </div>
    </div>

    
    
</asp:Content>
