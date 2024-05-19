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
                <div class="row align-items-center border-bottom pb-2 mb-2">
                    <div class="col-2">
                        <asp:Image ID="imgProduct" runat="server" class="small-image rounded" ImageUrl='<%# Eval("producto.ImagePath") %>' AlternateText="Producto" />
                    </div>
                    <div class="col-7 text-center">
                        <h3 class="card-title font-weight-bold text-dark mb-0" style="font-weight: bold;"><%# Eval("producto.name") %></h3>
                        <p class="card-text"><%# String.Format("{0:0.00}", Eval("price")) %> €</p>
                    </div>
                    <div class="col-3 text-right">
                        <div class="btn-group">
                            <asp:Button
                                ID="Button1"
                                runat="server"
                                Text="-"
                                CssClass="btn btn-danger"
                                CommandArgument='<%# Eval("producto.Id") + "_" +  Container.ItemIndex %>'
                                OnClick="Remove_Click" />
                            <asp:Label ID="cantidad" runat ="server" class="mx-2" Text='<%# Eval("cantidad") %>'></asp:Label>
                            <asp:Button
                                ID="Button2"
                                runat="server"
                                Text="+"
                                CssClass="btn btn-success"
                                CommandArgument='<%# Eval("producto.Id") + "_" +  Container.ItemIndex %>'
                                OnClick="Add_Click" />
                        </div>
                        <div class="col-4 text-right">
                            <asp:Label ID = "pvp" runat="server" class="card-text" Text= '<%# String.Format("{0:0.00}", Eval("pvp")) %>'></asp:Label>
                            <span> € </span>
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>

        <!-- Seccion de debajo de los productos -->
        <div class="row align-items-center text-left">
            <!-- Alinea el contenido a la izquierda -->
            <div class="col-8">
                <!-- alinea los totales -->
                <h3>Total de artículos: 3</h3>
                <!-- Total productos -->
                <h3>Precio total: $40.00</h3>
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
                <!-- boton de "Comprar" -->
            </div>
        </div>
    </div>
</asp:Content>
