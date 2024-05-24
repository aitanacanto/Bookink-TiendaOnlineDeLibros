<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="paquete.aspx.cs" Inherits="proWeb.paquete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    <link rel="stylesheet" href="styles.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            text-align: justify;
            background-color: #f5f5f5;
        }
    </style>

    <div class="product-container">
        <div class="informacion">
            <!-- Sección de Detalles del Producto -->
            <div class="product-image">
                <div style="width: 400px; height: 400px; background-color: #eee; border-radius: 8px;">
                    <asp:Image ImageUrl="content/products/book_1.jpg" runat="server" ID="imageProduct" Style="max-height: 400px; object-fit: contain; max-width: 100%;" />
                </div>
            </div>
            <div class="product-details">
                <h1 id="ProductName" runat="server" style="text-align: left">Nombre paquete</h1>
                <p id="ProductDescription" runat="server" class="description">Descripcion</p>
                <div class="d-flex">
                    <p id="ProductPrice" runat="server" style="margin-left: 10px" class="price">Precio: 19.99 €</p>
                </div>
                <asp:Button ID="Id_Producto" runat="server" Class="btn btn-primary btn-lg" Text="Añadir al Carrito" CommandArgument='<%# Eval("id") %>' OnClick="Add_Click" />
            </div>
        </div>
        <div style="clear: both;"></div>
        <!-- Limpiar el float -->

        <!-- Sección de Productos del Paquete -->
        <div data-aos="fade-in">
            <h1 class="text-center">Libros que contiene:</h1>
            <div class="row">
                <asp:Repeater ID="reapeterProduct" runat="server">
                    <ItemTemplate>
                        <div class="col-md-3 mb-4 col-lg-3 d-flex mb-4 align-items-stretch">
                            <div class="product-card card">
                                <a href='<%# "producto.aspx?Id=" + Eval("Id") %>' class="text-decoration-none d-flex flex-column flex-grow-1">
                                    <div class="text-center">
                                        <asp:Image ID="imgProduct" runat="server" class="card-img-top img-fluid max-width mb-3 mt-3" ImageUrl='<%# Eval("ImagePath") %>' AlternateText="Producto" />
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title font-weight-bold text-dark mb-0" style="font-weight: bold;"><%# Eval("name") %></h5>
                                        <p class="autor mb-1"><%# Eval("autor") %></p>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
