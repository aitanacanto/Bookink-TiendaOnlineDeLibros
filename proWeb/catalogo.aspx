<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="catalogo.aspx.cs" Inherits="proWeb.catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div data-aos="fade-in">
        <h1 class="text-center">Catálogo Libros</h1>
        <div class="container">
            <div class="row">
                <asp:Repeater ID="reapeterProduct" runat="server">
                    <ItemTemplate>
                        <div class="col-md-3 mb-4">
                            <div class="product-card card">
                                <a href="producto.aspx" class="text-decoration-none">
                                    <div class="text-center">
                                        <asp:Image ID="imgProduct" runat="server" class="card-img-top img-fluid max-width mb-3 mt-3" ImageUrl='<%# Eval("ImagePath") %>' AlternateText="Producto" />
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title font-weight-bold text-dark mb-0" style="font-weight: bold;"><%# Eval("name") %></h5>
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
                                        <div class="text-center mt-3">
                                          <asp:Button ID="Id_Producto" runat="server" CssClass = "btn btn-primary btn-lg" Text="Añadir al Carrito" CommandArgument='<%# Eval("id") %>' OnClick="Anyadir_Click"  />
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

    <div data-aos="fade-in">
        <h1 class="text-center">Catálogo Paquetes</h1>
        <div class="container">
            <div class="row">
                <asp:Repeater ID="repeaterPaquetes" runat="server">
                    <ItemTemplate>
                        <div class="col-md-3 mb-4">
                            <div class="package-card card">
                                <a href="paquete.aspx" class="text-decoration-none">
                                    <div class="text-center">
                                        <asp:Image ID="imgPaquete" runat="server" class="card-img-top img-fluid max-width mb-3 mt-3" ImageUrl='<%# Eval("Img_paquete") %>' AlternateText="Paquete" />
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title font-weight-bold text-dark mb-0"><%# Eval("Nombre") %></h5>
                                        <p class="card-text text-dark">Precio: <%# String.Format("{0:0.00}", Eval("Precio")) %> €</p>
                                        <!-- Aquí puedes agregar más detalles del paquete si lo deseas -->
                                        <div class="text-center mt-3">
                                            <asp:Button ID="btnAddToCart" runat="server" CssClass="btn btn-primary btn-lg" Text="Añadir al Carrito" OnClick="Anyadir_Click" />
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
</asp:Content>
