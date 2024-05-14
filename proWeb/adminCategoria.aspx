<%@ Page Title="Administración de Categorías" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminCategoria.aspx.cs" Inherits="proWeb.adminCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="styles.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Listar Categorías -->
    <div class="admin-products">
        <div class="header">
            <h1 class="title">Administración de Categorías</h1>
            <asp:Button ID="btnAddCategory" runat="server" CssClass="create" Text="Añadir Categoría" OnClick="ButtonAddCategoria_Click" />
            <asp:TextBox ID="TextBoxNewCategory" runat="server" CssClass="category-input" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="Productos" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Categoría" />
                <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" ButtonType="Button">
                    <ItemStyle CssClass="delete" />
                </asp:CommandField>
                <asp:CommandField ShowEditButton="True" EditText="Editar" ButtonType="Button">
                    <ItemStyle CssClass="edit" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
