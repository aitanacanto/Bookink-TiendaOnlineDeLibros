<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="producto.aspx.cs" Inherits="proWeb.producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <style>
        /* Estilos CSS */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            text-align: justify;
            background-color: #f5f5f5;
        }

        .product-container {
            max-width: 80%;
            margin: 20px auto;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            overflow: hidden;
        }

        .product-image {
            width: 50%;
            float: left;
            padding: 20px;
        }

        .product-image img {
            display: block;
            width: 100%;
            border-radius: 10px;
            background-color: #eee;
        }

        .product-details {
            width: 40%;
            float: left;
            padding: 20px;
            margin-left: 10%;
        }

        .product-details h1 {
            font-size: 24px;
            margin: 0 0 10px;
        }

        .product-details p {
            margin: 0 0 10px;
        }

        .price {
            font-weight: bold;
            color: #007bff;
        }

        .author {
            font-style: italic;
            color: #666;
        }

        .add-to-cart {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            transition: background-color 0.3s;
        }

        .add-to-cart:hover {
            background-color: #0056b3;
        }

        /* Estilos para la sección adicional */
        .additional-section {
            clear: both;
            margin-top: 30px;
            padding: 20px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .additional-section h2 {
            font-size: 20px;
            margin-bottom: 20px;
        }

        .additional-section .separator {
            margin-bottom: 20px;
            border-bottom: 1px solid #ddd;
        }

        /* Estilos para la ficha técnica */
        .tech-specs {
            margin-bottom: 20px;
        }

        .tech-specs table {
            width: 100%;
            border-collapse: collapse;
        }

        .tech-specs th,
        .tech-specs td {
            padding: 8px;
            border-bottom: 1px solid #ddd;
            text-align: left;
        }

        /* Estilos para la sección de reseñas */
        .reviews {
            margin-left: 20px;
            margin-bottom: 20px;
            margin-right: 20px;
        }

        .reviews h2 {
            font-size: 20px;
            margin-bottom: 10px;
        }

        .review {
            border-bottom: 1px solid #ddd;
            padding-bottom: 20px;
            margin-bottom: 20px;
        }

        .review .author {
            font-weight: bold;
            margin-bottom: 5px;
        }

        .review .date {
            color: #666;
        }

        .review .content {
            color: #333;
        }

        /* Estilos para la media de valoraciones */
        .rating {
            display: flex;
            align-items: center;
            margin-bottom: 10px;
        }

        .rating span {
            margin-right: 5px;
        }

        .stars {
            color: #f4d03f;
        }

        /* Estilos para la sección de productos relacionados */
        .related-products {
            margin-top: 30px;
            display: flex;
            justify-content: space-between;
            align-items: center;
            flex-wrap: wrap;
        }

        .related-products .product {
            width: 30%;
            margin-bottom: 20px;
            padding: 10px;
            background-color: #f9f9f9;
            border-radius: 8px;
        }

        .informacion{
            display: flex;
            flex-direction: row;

        }
    </style>

    <div class="product-container">
        <div class="informacion">
        <!-- Sección de Detalles del Producto -->
        <div class="product-image">
            <div style="width: 300px; height: 300px; background-color: #eee; border-radius: 8px;"></div>
        </div>
        <div class="product-details">
            <h1>Un animal salvaje</h1>
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

