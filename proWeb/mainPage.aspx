<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mainPage.aspx.cs" Inherits="proWeb.mainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Enlace al archivo CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    <link rel="stylesheet" href="content/styles.css" />
    <link rel="stylesheet" href="https://unpkg.com/aos@next/dist/aos.css" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="py-2">
           <div id="carouselExampleIndicators" class="mb-5 carousel slide mx-auto" data-ride="carousel" style="max-width: 1000px;">
               <div class="carousel-inner">
            <div class="carousel-item active">
              <img src="content/slider/1.png" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
              <img src="content/slider/2.png" class="d-block w-100" alt="...">
            </div>
          </div>
          <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
          </a>
          <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
          </a>
            </div>
        <div>
        <h1 class="text-center">Últimas Novedades</h1>
        <div class="container">
            <div class="row">
                <asp:Repeater ID="reapeterNov" runat="server">
                    <ItemTemplate>
                        <div class="col-md-3 mb-4 col-lg-3 d-flex mb-4 align-items-stretch">
                            <div class="product-card card d-flex flex-column flex-grow-1">
                                <a href='<%# "producto.aspx?id=" + Eval("Id") %>' class="text-decoration-none d-flex flex-column flex-grow-1">
                                    <div class="text-center">
                                        <asp:Image ID="imgProduct" runat="server" class="card-img-top img-fluid max-width mb-3 mt-3" ImageUrl='<%# Eval("ImagePath") %>' AlternateText="Producto" />
                                    </div>
                                    <div class="card-body d-flex flex-column flex-grow-1">
                                        <h5 class="card-title font-weight-bold text-dark mb-0" style="font-weight: bold; text-align:left;"><%# Eval("name") %></h5>
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
                                        <asp:Button ID="Id_Producto" runat="server" CssClass = "btn btn-primary btn-lg" Text="Añadir al Carrito" CommandArgument='<%# Eval("id") %>' OnClick="Add_Click"  />
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


        <div class="mb-5 mt-5" data-aos="fade-in">
            <h1>Categorías Destacadas</h1>
            <div class="container">
              <div class="row justify-content-center">
                <div class="col-sm">
                  <div class="card mx-auto product-card" style="width: 18rem;">
                      <img class="card-img-top" src="https://i.imgur.com/Q5glcWU.png" alt="Card image cap">
                      <div class="card-body">
                        <h5 class="card-title">Ficción</h5>
                        <p class="card-text">Explora mundos imaginarios y emociones humanas.</p>
                        <a href="#" class="btn btn-primary">Ver Más</a>
                      </div>
                    </div>
                </div>
                <div class="col-sm">
                 <div class="card mx-auto product-card" style="width: 18rem;">
                      <img class="card-img-top" src="https://i.imgur.com/zU8cXVz.png" alt="Card image cap">
                      <div class="card-body">
                        <h5 class="card-title">Juvenil</h5>
                        <p class="card-text">Aventuras y lecciones para jóvenes lectores.</p>
                        <a href="#" class="btn btn-primary">Ver Más</a>
                      </div>
                    </div>
                </div>
                <div class="col-sm">
                  <div class="card mx-auto product-card" style="width: 18rem;">
                      <img class="card-img-top" src="https://i.imgur.com/awqdnuz.png" alt="Card image cap">
                      <div class="card-body">
                        <h5 class="card-title">No Ficción</h5>
                        <p class="card-text">Descubre conocimiento del mundo real y fascinante.</p>
                        <a href="#" class="btn btn-primary">Ver Más</a>
                      </div>
                    </div>
                </div>
              </div>
            </div>
        </div>
        </div>

    <div data-aos="fade-in">
         <h1 class="text-center">Catálogo Libros</h1>
        <div class="container">
            <div class="row">
                <asp:Repeater ID="reapeterProduct" runat="server">
                    <ItemTemplate>
                        <div class="col-md-3 mb-4 col-lg-3 d-flex mb-4 align-items-stretch">
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
      <script src="https://unpkg.com/aos@next/dist/aos.js"></script>
  <script>
      AOS.init({ once: true });
  </script>
</asp:Content>

