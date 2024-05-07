<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminProducto.aspx.cs" Inherits="proWeb.adminProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
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
            margin-top: 20px;
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

        .edit{
            background-color: #FFBF00;
            color: #fff;
            border: none;
            padding: 8px 12px;
            border-radius: 5px;
            cursor: pointer;    
            font-size: 16px;
            transition: background-color 0.3s;
            margin: 10px;
            width: 150px;
        }

        .delete{
            background-color: #FF0000;
            color: #fff;
            border: none;
            padding: 8px 12px;
            border-radius: 5px;
            cursor: pointer;    
            font-size: 16px;
            transition: background-color 0.3s;
            margin: 10px;
             width: 150px;
        }

        .mod-buttons{
            margin-top: auto;
            margin-bottom: auto;
            display: flex;
            flex-direction: column; 
            align-items: center; 
            margin-right: 20px;
            margin-left: auto;
        }
        .iden{
            display: flex;
            flex-direction: row;
        }

    </style>
       
    <div class="admin-products">
        <div class="header">
            <h1 class="title">Productos
                </h1>
                <div style="margin-left: auto;">
                     <asp:button class="create" data-bs-toggle="modal" data-bs-target="#exampleModal" runat="server" text="Crear Producto" OnClientClick="return false;" />
                    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                  <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                      <div class="modal-header">
                        <h1 class="modal-title fs-5" id="exampleModalLabel">Nuevo Producto</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div class="modal-body">
                          <div class="row align-items-start">
                              <div class="mb-3 col">
                          <label class="form-label">ID</label>
                          <input type="number" name="id" value="123" class="form-control"/>
                        </div>
                              <div class="mb-3 col">
                          <label class="form-label">Cantidad</label>
                          <input type="number" name="stock" class="form-control"/>
                        </div>
                          
                          </div>
                          <div class="mb-3 col">
                          <label class="form-label">Nombre</label>
                          <input type="text" name="name" class="form-control"/>
                        </div>

                          <div class="row align-items-start">
                          <div class="mb-3 col">
                         <label class="form-label">Precio</label>
                          <input type="number"  step="0.01" name="price" class="form-control"/> 
                        </div>
                          <div class="mb-3 col">
                         <label class="form-label">Precio Oferta</label>
                          <input type="number"  step="0.01" name="price-offer" class="form-control"/> 
                        </div>
                              </div>
                        <div class="mb-3">
                         <label class="form-label">Categoría</label>
                            <select class="form-select">
                                <option value="cat1">Cat1</option>
                                <option value="cat2">Cat2</option>
                                <option value="cat3">Cat3</option>
                                <option value="cat4">Cat4</option>
                            </select>
                        </div>
                          
                          
                      </div>
                      <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button>
                      </div>
                    </div>
                  </div>
                </div>
                </div>
        </div>
        <div class="Productos">
            <div class="Producto">
                <div style="width: 150px; height: 150px; background-color: #FFFFE0; border-radius: 8px;"></div>
                <div>
                     <h2 class="title">Producto 1</h2>
                    <p class="price">Precio: 19,99 €</p>
                    <p class="id">ID: #1234</p>
                    
                </div>
                <div class="mod-buttons">
                    <button class="edit">
                        <i class="fa-solid fa-pen-to-square"></i>
                        Editar
                    </button>

                    <button class="delete">
                        <i class="fa-solid fa-trash"></i>
                        Eliminar
                    </button>
                </div>
            </div>

            <div class="Producto">
                <div style="width: 150px; height: 150px; background-color: #FFB6C1; border-radius: 8px;"></div>
                <div>
                     <h2 class="title">Producto 2</h2>
                    <p class="price">Precio: 9,99 €</p>
                    <p class="id">ID: #1244</p>
                    
                </div>
                <div class="mod-buttons">
                    <button class="edit">
                        <i class="fa-solid fa-pen-to-square"></i>
                        Editar
                    </button>

                    <button class="delete">
                        <i class="fa-solid fa-trash"></i>
                        Eliminar
                    </button>
                </div>
            </div>
            <div class="Producto">
                <div style="width: 150px; height: 150px; background-color: #90EE90; border-radius: 8px;"></div>
                <div>
                     <h2 class="title">Producto 3</h2>
                    <p class="price">Precio: 17,35 €</p>
                    <p class="id">ID: #4924</p>
                    
                </div>
                <div class="mod-buttons">
                    <button class="edit">
                        <i class="fa-solid fa-pen-to-square"></i>
                        Editar
                    </button>

                    <button class="delete">
                        <i class="fa-solid fa-trash"></i>
                        Eliminar
                    </button>
                </div>
            </div>
               <div class="Producto">
                <div style="width: 150px; height: 150px; background-color: #ADD8E6; border-radius: 8px;"></div>
                <div>
                     <h2 class="title">Producto 4</h2>
                    <p class="price">Precio: 11,99 €</p>
                    <p class="id">ID: #2365</p>
                    
                </div>
                <div class="mod-buttons">
                    <button class="edit">
                        <i class="fa-solid fa-pen-to-square"></i>
                        Editar
                    </button>

                    <button class="delete">
                        <i class="fa-solid fa-trash"></i>
                        Eliminar
                    </button>
                </div>
            </div>

            </div>

        </div>

</asp:Content>
