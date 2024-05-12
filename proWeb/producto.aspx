<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="producto.aspx.cs" Inherits="proWeb.producto" %>

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
            <div style="width: 300px; height: 300px; background-color: #eee; border-radius: 8px;"></div>
        </div>
        <div class="product-details">
            <h1 style="text-align:left">Un animal salvaje</h1>
            <p class="author">Autor: Juan Villoro</p>
            <p class="price">Precio: 19.99 €</p>
            <p>Descripción corta del libro: Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
            <button class="add-to-cart">Agregar al carrito</button>
        </div>
       </div>
        <div style="clear: both;"></div> <!-- Limpiar el float -->
        <!-- Descripción Extendida y Ficha Técnica -->
        <div class="additional-section">
            <h2>Descripción Extendida</h2>
            <div class="separator"></div>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed hendrerit odio id ligula fermentum, a congue quam varius. Integer eget urna vitae purus placerat consectetur. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Quisque nec ipsum quis nulla ultrices varius et a lectus. Proin vehicula ultricies ante, id iaculis enim fermentum et. Duis vestibulum vulputate augue eget accumsan. In nec bibendum nunc. Duis nec tincidunt metus. In nec tincidunt metus. In hac habitasse platea dictumst. Vestibulum in justo id leo egestas posuere. Nullam laoreet, dolor in pharetra tempor, elit nunc consequat metus, in facilisis metus libero ut sapien.</p>
            <!-- Ficha Técnica -->
            <div class="tech-specs">
                <h2>Ficha Técnica</h2>
                <table>
                    <tr>
                        <th>Año de Publicación</th>
                        <td>2022</td>
                    </tr>
                    <tr>
                        <th>Número de Páginas</th>
                        <td>250</td>
                    </tr>
                    <tr>
                        <th>Editorial</th>
                        <td>Editorial ABC</td>
                    </tr>
                    <!-- Agrega más detalles según sea necesario -->
                </table>
            </div>
        </div>
        <!-- Sección de Reseñas -->
        <div class="reviews">
            <h2>Reseñas</h2>
            <div class="rating">
                <span>Valoración Media:</span>
                <span class="stars">&#9733;&#9733;&#9733;&#9733;&#9734;</span>
            </div>
            <div class="review">
                <p class="author">Usuario1</p>
                <p class="date">01/04/2024</p>
                <div class="rating">
                    <span>Puntuación:</span>
                    <span class="stars">&#9733;&#9733;&#9733;&#9733;&#9734;</span>
                </div>
                <p class="content">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed hendrerit odio id ligula fermentum, a congue quam varius.</p>
            </div>
            <div class="review">
                <p class="author">Usuario2</p>
                <p class="date">02/04/2024</p>
                <div class="rating">
                    <span>Puntuación:</span>
                    <span class="stars">&#9733;&#9733;&#9733;&#9734;&#9734;</span>
                </div>
                <p class="content">Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris ac aliquet metus.</p>
            </div>
            <!-- Agrega más reseñas según sea necesario -->
        </div>
        <!-- Sección de Productos Relacionados -->
        <div class="related-products">
            <div class="product">
                <h3>Producto Relacionado 1</h3>
                <p>Autor: Autor del Libro</p>
                <p>Precio: 14.99 €</p>
            </div>
            <div class="product">
                <h3>Producto Relacionado 2</h3>
                <p>Autor: Autor del Libro</p>
                <p>Precio: 17.99 €</p>
            </div>
            <div class="product">
                <h3>Producto Relacionado 3</h3>
                <p>Autor: Autor del Libro</p>
                <p>Precio: 21.99 €</p>
            </div>
        </div>
    </div>
</asp:Content>

