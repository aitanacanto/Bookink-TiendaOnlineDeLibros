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
            <div style="width: 400px; height: 400px; background-color: #eee; border-radius: 8px;">
                <asp:Image ImageUrl="content/products/book_1.jpg" runat="server" ID="imageProduct" style="max-height: 400px;object-fit: contain; max-width: 100%;"/>
            </div>
        </div>
        <div class="product-details">
            <h1 id="ProductName" runat="server" style="text-align:left">Titulo Libro</h1>
            <p  ID="ProductAutor" runat="server" class="author">Autor</p>
            <div class="mb-2">
                                            <i class="fa-solid fa-star color-estre"></i>
                                            <i class="fa-solid fa-star color-estre"></i>
                                            <i class="fa-solid fa-star color-estre"></i>
                                            <i class="fa-solid fa-star color-estre"></i>
                                            <i class="fa-regular fa-star no-estre"></i>
                                        </div>
             <div class="d-flex">
            <p ID="ProductPrice" runat="server" class="card-text text-danger" style="text-decoration:line-through; margin-right: 10px">Precio Oferta</p>
            <p ID="ProductOfer" runat="server"  class="price">Precio: 19.99 €</p>
                 </div>
            <asp:Button ID="Id_Producto" runat="server" CssClass = "btn btn-primary btn-lg" Text="Añadir al Carrito" OnClick="Anyadir_Click"  />
        </div>
       </div>
        <div style="clear: both;"></div> <!-- Limpiar el float -->
        <!-- Descripción Extendida y Ficha Técnica -->
        <div class="additional-section">
            <h2>Sinopsis</h2>
            <div class="separator"></div>
            <p runat="server" id="ProductSinopsis">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed hendrerit odio id ligula fermentum, a congue quam varius. Integer eget urna vitae purus placerat consectetur. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Quisque nec ipsum quis nulla ultrices varius et a lectus. Proin vehicula ultricies ante, id iaculis enim fermentum et. Duis vestibulum vulputate augue eget accumsan. In nec bibendum nunc. Duis nec tincidunt metus. In nec tincidunt metus. In hac habitasse platea dictumst. Vestibulum in justo id leo egestas posuere. Nullam laoreet, dolor in pharetra tempor, elit nunc consequat metus, in facilisis metus libero ut sapien.</p>
            <!-- Ficha Técnica -->
            <div class="tech-specs">
                <h2>Ficha Técnica</h2>
                <table>
                    <tr>
                        <th>Año de Publicación</th>
                        <td id="anyo" runat="server">2022</td>
                    </tr>
                    <tr>
                        <th>Número de Páginas</th>
                        <td id="numpag" runat="server">250</td>
                    </tr>
                    <tr>
                        <th>Editorial</th>
                        <td id="editorial" runat="server">Editorial ABC</td>
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
            <div class="container">
            <div class="row " >
            <asp:Repeater ID="reapeterProduct" runat="server">
                    <ItemTemplate>
                        <div class="col-md-3 mb-4 col-lg-3 d-flex mb-4 align-items-stretch" data-aos="fade-in">
                            <div class="product-card card d-flex flex-column">
                                 <a href='<%# "producto.aspx?Id=" + Eval("Id") %>' class="text-decoration-none d-flex flex-column flex-grow-1">
                                    <div class="text-center">
                                        <asp:Image ID="imgProduct" runat="server" class="card-img-top img-fluid max-width mb-3 mt-3" ImageUrl='<%# Eval("ImagePath") %>' AlternateText="Producto" />
                                    </div>
                                    <div class="card-body d-flex flex-column flex-grow-1">
                                        <h5 class="card-title font-weight-bold text-dark mb-0" style="font-weight: bold;text-align:left;"><%# Eval("name") %></h5>
                                        <p class="autor mb-1"><%# Eval("Autor") %></p>
                                        <div class="mb-2">
                                            <i class="fa-solid fa-star color-estre"></i>
                                            <i class="fa-solid fa-star color-estre"></i>
                                            <i class="fa-solid fa-star color-estre"></i>
                                            <i class="fa-solid fa-star color-estre"></i>
                                            <i class="fa-regular fa-star no-estre"></i>
                                        </div>
                                        <div class="d-flex">
                                            <p class="card-text text-danger" style="text-decoration:line-through"><%# String.Format("{0:0.00}", Eval("price")) %> €</p>
                                            <p class="card-text text-dark" style="margin-left:10px;"><%# String.Format("{0:0.00}", Eval("salePrice")) %> €</p>
                                        </div>
                                            
                                        <div class="text-center mt-auto">
                                            <asp:Button ID="Id_Producto" runat="server" Class = "btn btn-primary btn-lg" Text="Añadir al Carrito" CommandArgument='<%# Eval("id") %>' OnClick="Add_Click"  />
                                            </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                </div>
                </div>
        </div>
    </div>
</asp:Content>

