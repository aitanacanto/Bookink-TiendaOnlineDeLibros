<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="proWeb.admin" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="admin-title">Panel de Administración</h1>

        <!-- Menú de administración centrado -->
        <div class="menu-center"> <!-- Centrar el menú -->
            <asp:Menu 
                ID="AdminMenu" 
                runat="server" 
                Orientation="Horizontal" 
                CssClass="admin-menu"
                StaticMenuItemStyle-CssClass="menu-item" 
                StaticHoverStyle-CssClass="hovered-menu-item"
                StaticSelectedStyle-CssClass="selected-menu-item">
                <Items>
                    <asp:MenuItem Text="Paquetes" NavigateUrl="adminPaquete.aspx" />
                    <asp:MenuItem Text="Usuarios" NavigateUrl="adminUsuario.aspx" />
                    <asp:MenuItem Text="Productos" NavigateUrl="adminProducto.aspx" />
                </Items>
            </asp:Menu>
        </div>

        <!-- Contenedor para el mensaje de bienvenida -->
        <div class="content-box">
            <div class="admin-content">
                <p>Bienvenido al panel de administración. Utiliza el menú para navegar entre las diferentes secciones.</p>
            </div>
        </div>
    </div>
</asp:Content>
