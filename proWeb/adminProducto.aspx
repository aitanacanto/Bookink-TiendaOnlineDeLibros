<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminProducto.aspx.cs" Inherits="proWeb.adminProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    <link rel="stylesheet" href="styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

       
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
                          <div class="mb-3 col">
                          <label class="form-label">Nombre</label>
                          <input type="text" name="name" class="form-control"/>
                        </div>
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
                          
                           <div class="mb-3">
                          <label class="form-label">Autor</label>
                          <input type="text" name="author" class="form-control"/>
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
                          
                       <div class="mb-3">
                          <label class="form-label">Nombre</label>
                          <input type="text" name="name" class="form-control"/>
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
     <asp:Repeater ID="reapeterProduct" runat="server">
                    <ItemTemplate>
                        <div class="Producto">
                            <div style="width: 150px; height: 150px; background-color: #FFFFE0; border-radius: 8px;"></div>
                            <div>
                                <h2 class="title"><%# Eval("Name") %></h2>
                                <p class="price">Precio: <%# Eval("Price") %> €</p>
                                <p class="id">ID: <%# Eval("Id") %></p>
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
                    </ItemTemplate>
                </asp:Repeater>

        </div>

</asp:Content>
