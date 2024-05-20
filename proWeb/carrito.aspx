<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="proWeb.carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        .small-image {
            width: 70px;
            height: auto;
        }

        .align-left {
            text-align: left;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <!-- Titulo -->
        <div class="row">
            <div class="col-12">
                <h1 class="align-left">Carrito</h1>
                <!-- Alinea el titulo a la izquierda -->
            </div>
        </div>
        <asp:Repeater ID="reapeterProduct" runat="server">
            <ItemTemplate>
                <div class="row align-items-center">
                    <div class="col-2">
                        <asp:Image ID="imgProduct" runat="server" class="small-image rounded" ImageUrl='<%# Eval("producto.ImagePath") %>' AlternateText="Producto" />
                    </div>
                    <div class="col-6 text-center">
                        <h3 class="card-title font-weight-bold text-dark mb-0" style="font-weight: bold;"><%# Eval("producto.name") %></h3>
                        <h3 class="card-text"><%# String.Format("{0:0.00}", Eval("price")) %> €</h3>
                    </div>
                    <div class="col-4 text-right">
                        <div class="btn-group">
                            <asp:Button
                                ID="Button1"
                                runat="server"
                                Text="-"
                                CssClass="btn btn-danger"
                                CommandArgument='<%# Eval("producto.Id") + "_" +  Container.ItemIndex %>'
                                OnClick="Remove_Click" />
                            <asp:Label ID="cantidad" runat="server" class="mx-2" Text='<%# Eval("cantidad") %>'></asp:Label>
                            <asp:Button
                                ID="Button2"
                                runat="server"
                                Text="+"
                                CssClass="btn btn-success"
                                CommandArgument='<%# Eval("producto.Id") + "_" +  Container.ItemIndex %>'
                                OnClick="Add_Click" />
                        </div>
                        <div class="text-right">
                            <h3>
                                <asp:Label ID="pvp" runat="server" class="card-text" Text='<%# String.Format("{0:0.00}", Eval("pvp")) %>'></asp:Label>
                                <span>€ </span>
                            </h3>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>


        <!-- Seccion de debajo de los productos -->
        <div class="row align-items-center text-left">
            <!-- Alinea el contenido a la izquierda -->
            <div class="col-8">
                <!-- alinea los totales -->
                <h3>Total Productos:
                <asp:Label ID="total_lineas" runat="server" class="mx-2"></asp:Label>
                </h3>
                <!-- Total productos -->
                <h3>Precio Total:
                    <asp:Label ID="total_pvp" runat="server" class="mx-2"></asp:Label>
                </h3>
                <!-- Total precio -->
            </div>
            <div class="col-4 text-right">
                <!-- Alinea el boton de "Comprar" a la derecha -->
                <asp:Button
                    ID="btnComprar"
                    runat="server"
                    Text="Comprar"
                    CssClass="btn btn-primary btn-lg"
                    OnClick="Buy_Click" />
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Delete_Click">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                          <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0z"/>
                          <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4zM2.5 3h11V2h-11z"/>
                        </svg>
                </asp:LinkButton>






                <!-- boton de "Comprar" -->
            </div>
        </div>
    </div>
</asp:Content>
