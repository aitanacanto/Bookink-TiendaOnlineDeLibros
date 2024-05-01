<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pedido.aspx.cs" Inherits="proWeb.pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> MisPedidos </h1>
    <asp:GridView ID="colPedidos" runat="server" AutoGenerateColumns="False" Width="1285px">
        <Columns>
            <asp:BoundField DataField="Producto" HeaderText="Producto" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="FechaPedido" HeaderText="Fecha del Pedido" />
            <asp:BoundField DataField="PrecioPedido" HeaderText="Precio Total" />
        </Columns>
    </asp:GridView>
</asp:Content>
