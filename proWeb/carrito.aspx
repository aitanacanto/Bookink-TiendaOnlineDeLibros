<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="proWeb.carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>@ViewData["Title"]</title>

</head>
<body>
    <div class="container">
        <h1>Carrito</h1>
        <div class="item">
            <p>Nombre del Producto 1</p>
            <p>Precio: $10.00</p>
        </div>
        <div class="item">
            <p>Nombre del Producto 2</p>
            <p>Precio: $15.00</p>
        </div>
        <div class="item">
            <p>Nombre del Producto 3</p>
            <p>Precio: $20.00</p>
        </div>
        <div class="total">
            Total de artículos: 3
        </div>
        <button class="btn-buy">Comprar</button>
    </div>

</body>

</asp:Content>
