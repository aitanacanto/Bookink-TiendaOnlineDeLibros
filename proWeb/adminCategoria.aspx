<%@ Page Title="Administración de Categorías" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminCategoria.aspx.cs" Inherits="proWeb.adminCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Listar Categorías -->
    <div>
        <h2>Listar Categorías</h2>
        <asp:GridView ID="GridViewCategorias" runat="server" AutoGenerateColumns="False" CssClass="grid">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" />
            </Columns>
        </asp:GridView>
    </div>

    <!-- Añadir Categorías -->
    <div>
        <h2>Añadir Categoría</h2>
        <asp:TextBox ID="TextBoxNuevaCategoria" runat="server" CssClass="text-input"></asp:TextBox>
        <asp:Button ID="ButtonAddCategoria" runat="server" Text="Añadir" OnClick="ButtonAddCategoria_Click" CssClass="button" />
    </div>

    <!-- Eliminar Categorías -->
    <div>
        <h2>Eliminar Categoría</h2>
        <asp:DropDownList ID="DropDownListCategorias" runat="server" CssClass="dropdown">
        </asp:DropDownList>
        <asp:Button ID="ButtonDeleteCategoria" runat="server" Text="Eliminar" OnClick="ButtonDeleteCategoria_Click" CssClass="button" />
    </div>
</asp:Content>
