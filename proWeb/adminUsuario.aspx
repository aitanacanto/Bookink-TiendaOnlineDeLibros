<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminUsuario.aspx.cs" Inherits="proWeb.adminUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Administrar Usuarios y Trabajadores</title>
</asp:Content>
        
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <!-- Aquí ponemos el listado de usuarios clientes registrados -->
        <h2>Usuarios Registrados</h2>
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                <asp:BoundField DataField="NIF" HeaderText="NIF" />
                <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" />
            </Columns>
        </asp:GridView>
        <br />
        <!-- Y aqui el listado de trabajadores -->
        <h2>Trabajadores</h2>
        <asp:GridView ID="gvTrabajadores" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                <asp:BoundField DataField="NIF" HeaderText="NIF" />
                <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" />
                <asp:BoundField DataField="NumTelf" HeaderText="Número de Teléfono" />
            </Columns>
        </asp:GridView>
        <br />

        <!-- Aquí buscamos mediante un dni o correo a un trabajador, para que se nos muestre información sobre él o si queremos añadirlo o borrarlo-->
        <asp:TextBox ID="txtBusqueda" runat="server" placeholder="Buscar..." />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        
        <!-- Este botón se podrá utilizar en caso de que no exista aún el trabajador -->
        <asp:Button ID="btnMostrarTrabajador" runat="server" Text="Mostrar Trabajador" OnClick="btnMostrarFormulario_Click" />

        <!-- Este botón se puede utilizar una vez se ha buscado un trabajador y se ha seleccionado para borrar -->
        <asp:Button ID="btnBorrarTrabajador" runat="server" Text="Borrar Trabajador" OnClick="btnBorrarTrabajador_Click" />
        <br />

        <!-- Formulario para agregar un nuevo trabajador -->
        <asp:Panel ID="pnlAgregarTrabajador" runat="server" Visible="false">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombreTrabajador" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblNIF" runat="server" Text="NIF:"></asp:Label>
            <asp:TextBox ID="txtNIFTrabajador" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblCorreoElectronico" runat="server" Text="Correo Electrónico:"></asp:Label>
            <asp:TextBox ID="txtCargoTrabajador" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblNumTelf" runat="server" Text="Número de Teléfono:"></asp:Label>
            <asp:TextBox ID="txtNumTelf" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Trabajador" OnClick="btnAgregar_Click" />
        </asp:Panel>

        </div>
</asp:Content>
