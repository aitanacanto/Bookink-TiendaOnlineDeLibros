<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminPaquete.aspx.cs" Inherits="proWeb.adminPaquete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Administrar Paquetes</title>
</asp:Content>
        
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <!-- Listado de paquetes -->
        <h2>Paquetes disponibles</h2>
        <asp:GridView ID="gvPaquetes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPaquetes_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkMostrarPaquete" runat="server" Text="Mostrar" CommandName="Mostrar" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                        <asp:LinkButton ID="lnkBorrarPaquete" runat="server" Text="Borrar" CommandName="Borrar" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />

        <!-- Formulario para agregar un nuevo paquete -->
        <asp:Panel ID="pnlAgregarPaquete" runat="server" Visible="false">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombrePaquete" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPrecio" runat="server" Text="Precio:"></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Paquete" OnClick="btnAgregar_Click" />
        </asp:Panel>

        <!-- Listado de productos del paquete seleccionado -->
        <asp:Panel ID="pnlProductosPaquete" runat="server" Visible="false">
            <h2>Productos del Paquete</h2>
            <asp:Label ID="lblNombrePaquete" runat="server" Text="Nombre del paquete: "></asp:Label>
            <br />
            <asp:GridView ID="gvProductosPaquete" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvProductosPaquete_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Stock" HeaderText="Stock" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" />
        <asp:BoundField DataField="PrecioVenta" HeaderText="Precio de Venta" />
        <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
        <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" />
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:LinkButton ID="lnkEliminarProducto" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

            <br />
            <!-- Formulario para agregar un nuevo producto al paquete -->
            <asp:Panel ID="pnlAgregarProducto" runat="server" Visible="false">
                <h3>Agregar Nuevo Producto al Paquete</h3>
                <asp:Label ID="lblNombreProducto" runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="txtNombreProducto" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblStockProducto" runat="server" Text="Stock:"></asp:Label>
                <asp:TextBox ID="txtStockProducto" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblPrecioProducto" runat="server" Text="Precio:"></asp:Label>
                <asp:TextBox ID="txtPrecioProducto" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblPrecioVentaProducto" runat="server" Text="Precio de Venta:"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblFechaCreacion" runat="server" Text="Fecha de Creación:"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" OnClick="btnAgregarProducto_Click" />
            </asp:Panel>
        </asp:Panel>

    </div>
</asp:Content>
