<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="catalogo.aspx.cs" Inherits="proWeb.catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-3">
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select mb-2">
                    <asp:ListItem Text="Selecciona una categoría" Value="" />
                </asp:DropDownList>
                <asp:DropDownList ID="ddlEditorial" runat="server" CssClass="form-select mb-2">
                    <asp:ListItem Text="Selecciona una editorial" Value="" />
                </asp:DropDownList>
                <asp:DropDownList ID="ddlAutor" runat="server" CssClass="form-select mb-2">
                    <asp:ListItem Text="Selecciona un autor" Value="" />
                </asp:DropDownList>
                <asp:TextBox ID="txtPrecioMin" runat="server" CssClass="form-control mb-2" Placeholder="Precio Mín" TextMode="Number" />
                <asp:TextBox ID="txtPrecioMax" runat="server" CssClass="form-control mb-2" Placeholder="Precio Máx" TextMode="Number" />
                <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-outline-primary" Text="Filtrar" OnClick="btnFiltrar_Click" />
            </div>
            <div class="col-md-9">
                <div data-aos="fade-in">
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
                                                        <h5 class="card-title font-weight-bold text-dark mb-0" style="font-weight: bold; text-align: left;"><%# Eval("name") %></h5>
                                                        <p class="autor mb-1"><%# Eval("Autor") %></p>
                                                        <div class="mb-2">
                                                            <i class="fa-solid fa-star color-estre"></i>
                                                            <i class="fa-solid fa-star color-estre"></i>
                                                            <i class="fa-solid fa-star color-estre"></i>
                                                            <i class="fa-solid fa-star color-estre"></i>
                                                            <i class="fa-regular fa-star no-estre"></i>
                                                        </div>
                                                        <div class="d-flex">
                                                            <p class="card-text text-danger" style="text-decoration: line-through"><%# String.Format("{0:0.00}", Eval("price")) %> €</p>
                                                            <p class="card-text text-dark" style="margin-left: 10px;"><%# String.Format("{0:0.00}", Eval("salePrice")) %> €</p>
                                                        </div>

                                                        <div class="text-center mt-auto">
                                                            <asp:Button ID="Id_Producto" runat="server" Class="btn btn-primary btn-lg" Text="Añadir al Carrito" CommandArgument='<%# Eval("id") %>' OnClick="Add_Click" />
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
                        <div class="row">
                            <asp:Repeater ID="repeaterPaquetes" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-3 mb-4 col-lg-3 d-flex mb-4 align-items-stretch">
                                        <div class="package-card card d-flex flex-column flex-grow-1">
                                            <a href='<%# "paquete.aspx?id=" + Eval("IdPaquete") %>'  class="text-decoration-none d-flex flex-column flex-grow-1">
                                                <div class="text-center">
                                                    <asp:Image ID="imgPaquete" runat="server" class="card-img-top img-fluid max-width mb-3 mt-3" ImageUrl='<%# Eval("Img_paquete") %>' AlternateText="Paquete" />
                                                </div>
                                                <div class="card-body d-flex flex-column flex-grow-1">
                                                    <h5 class="card-title font-weight-bold text-dark mb-0"><%# Eval("Nombre") %></h5>
                                                    <p class="card-text text-dark">Precio: <%# String.Format("{0:0.00}", Eval("Precio")) %> €</p>
                                                    <div class="text-center mt-auto">
                                                        <asp:Button ID="btnAddToCart" runat="server" Class="btn btn-primary btn-lg" Text="Añadir al Carrito" OnClick="Anyadir_Click" />
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
        </div>
</asp:Content>
