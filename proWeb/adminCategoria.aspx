<%@ Page Title="Administración de Categorías" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminCategoria.aspx.cs" Inherits="proWeb.adminCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/styles.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="admin-products">
        <div class="header">
            <h1 class="title">Administración de Categorías</h1>
            <div style="margin-left: auto;">
                <asp:TextBox ID="TextBoxNewCategory" runat="server" CssClass="text-input" Placeholder="Ingrese el nombre de la categoría"/>
                <asp:Button ID="btnAddCategory" runat="server" CssClass="btn btn-primary" Text="Añadir Categoría" OnClick="btnAddCategory_Click" />
            </div>
        </div>

        <asp:Repeater ID="repeaterCategory" runat="server" OnItemCommand="repeaterCategory_ItemCommand">
            <ItemTemplate>
                <div class="product-item">
                    <div class="product-info">
                        <asp:TextBox ID="TextBoxEditCategory" runat="server" Text='<%# Eval("Nombre") %>' CssClass="text-input" Visible="false" />
                        <h2 class="product-title"><%# Eval("Nombre") %></h2>
                    </div>
                    <div class="product-actions">
                        <asp:Button ID="btnEdit" runat="server" Text="Editar" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-warning" />
                        <asp:Button ID="btnSave" runat="server" Text="Guardar" CommandName="Save" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-success" Visible="false" />
                        <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
