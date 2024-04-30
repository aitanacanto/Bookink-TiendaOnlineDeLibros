<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminProducto.aspx.cs" Inherits="proWeb.adminProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body{
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            text-align: justify;
            background-color: #f5f5f5;
        }

        .admin-products{
            max-width: 80%;
            margin: 20px auto;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            overflow: hidden;
        }

        .title{
            margin-left:20px;
        }
        .create {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 8px 12px;
            border-radius: 5px;
            cursor: pointer;    
            font-size: 20px;
            transition: background-color 0.3s;
            
        }

        .header{
            display: flex;
            flex-direction: row; 
            align-items: center; 
            margin-right: 20px;
        }

        .Productos{
            display: flex;
            flex-direction: column;
        }

        .Producto{
            display: flex;
            border-top: 1px solid #ccc;
        }

        .price{
            margin-left: 25px;
            font-weight: bold;
            color: #007bff;
        }
        .id{
            margin-left: 25px;
            font-style: italic;
            color: #666;    
        }

    </style>
        

    <div class="admin-products">
        <div class="header">
            <h1 class="title">Productos
                </h1>
                <div style="margin-left: auto;">
                     <button class="create">
                    Crear Producto
                </button>
                </div>
        </div>
        <div class="Productos">
            <div class="Producto">
                <div style="width: 150px; height: 150px; background-color: #eee; border-radius: 8px;"></div>
                <div>
                     <h2 class="title">Producto 1</h2>
                    <p class="price">Precio: 19,99 €</p>
                    <p class="id">ID: #1234</p>
                </div>
            </div>
               

            </div>

        </div>

</asp:Content>
