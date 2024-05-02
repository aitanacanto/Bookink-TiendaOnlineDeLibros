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
                <h1 class="align-left">Carrito</h1> <!-- Alinea el titulo a la izquierda -->
            </div>
        </div>

        <!-- Productos -->
        <div class="row align-items-center border-bottom pb-2 mb-2">
            <div class="col-2"> 
                <img src="/content/mistborn.jpg" alt="Mistborn 1" class="small-image rounded" />
            </div>
            <div class="col-7 text-center">
                <h3>Mistborn 1</h3>
                <p>Precio: $10.00</p>
            </div>
            <div class="col-3 text-right">
                <div class="btn-group">
                    <asp:Button 
                        ID="btnRemove1" 
                        runat="server" 
                        Text="-" 
                        CssClass="btn btn-danger" 
                        OnClick="Remove_Click" 
                    />
                    <span class="mx-2">1</span>
                    <asp:Button 
                        ID="btnAdd1" 
                        runat="server" 
                        Text="+" 
                        CssClass="btn btn-success" 
                        OnClick="Add_Click" 
                    />
                </div>
            </div>
        </div>

        <!-- Productos -->
        <div class="row align-items-center border-bottom pb-2 mb-2">
            <div class="col-2"> 
                <img src="/content/mistborn.jpg" alt="Mistborn 2" class="small-image rounded" />
            </div>
            <div class="col-7 text-center">
                <h3>Mistborn 2</h3>
                <p>Precio: $15.00</h3>
            </div>
            <div class="col-3 text-right">
                <div class="btn-group">
                    <asp:Button 
                        ID="btnRemove2" 
                        runat="server" 
                        Text="-" 
                        CssClass="btn btn-danger" 
                        OnClick="Remove_Click" 
                    />
                    <span class="mx-2">2</span>
                    <asp:Button 
                        ID="btnAdd2" 
                        runat="server" 
                        Text="+" 
                        CssClass="btn btn-success" 
                        OnClick="Add_Click" 
                    />
                </div>
            </div>
        </div>

        <!-- Seccion de debajo de los productos -->
        <div class="row align-items-center text-left"> <!-- Alinea el contenido a la izquierda -->
            <div class="col-8"> <!-- alinea los totales -->
                <h3>Total de artículos: 3</h3> <!-- Total productos -->
                <h3>Precio total: $40.00</h3> <!-- Total precio -->
            </div>
            <div class="col-4 text-right"> <!-- Alinea el boton de "Comprar" a la derecha -->
                <asp:Button 
                    ID="btnComprar" 
                    runat="server" 
                    Text="Comprar" 
                    CssClass="btn btn-primary btn-lg" 
                    OnClick="Buy_Click" 
                /> <!-- boton de "Comprar" -->
            </div>
        </div>
    </div>
</asp:Content>
