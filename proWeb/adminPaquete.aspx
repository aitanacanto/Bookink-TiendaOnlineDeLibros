<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminPaquete.aspx.cs" Inherits="proWeb.adminPaquete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    <link rel="stylesheet" href="styles.css" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js" integrity="sha384-xO2eOqG9E1z4Oz+fa6sbXhfuLjYuxs5vjs3G9vb9CiHRUq3RivZtr4jXb8LBO+7p" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-b4gt1jrGC7Jh4AgTPSdUtOBvfO8shCk+5KVp5mwoqb0sFZgJGz4TO7vg6G9ckxs0" crossorigin="anonymous"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="admin-products">
        <div class="header">
            <h1 runat="server" id="Pruebas">Paquetes</h1>
            <div style="margin-left: auto;">
                <asp:Button class="create" data-bs-toggle="modal" data-bs-target="#exampleModal" runat="server" Text="Crear Paquete" OnClientClick="return false;" />
            </div>
        </div>

        <!-- Modal para Crear Paquete -->
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="exampleModalLabel">Nuevo Paquete</h1>
                        <asp:Button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" runat="server"></asp:Button>
                    </div>
                    <div class="modal-body">
                        <div class="mb-3 col">
                            <asp:Label runat="server" class="form-label">Nombre</asp:Label>
                            <asp:TextBox runat="server" type="text" name="name" ID="TxtName" class="form-control" />
                        </div>
                        <div class="row align-items-start">
                            <div class="mb-3 col">
                                <asp:Label runat="server" class="form-label">Precio</asp:Label>
                                <asp:TextBox runat="server" type="number" ID="TextBox1" step="0.01" name="price" class="form-control" />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Imagen</label>
                                <asp:FileUpload runat="server" class="form-control" type="file" ID="FileUpload1" />
                            </div>
                        </div>
                        <div class="row align-items-start">
                            <div class="mb-3">
                                <asp:Label runat="server" class="form-label">Descripción</asp:Label>
                                <asp:TextBox TextMode="MultiLine" runat="server" type="text" name="sinopsis" class="form-control" ID="TextBox2"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" OnClick="btnAdd_Click" Text="Guardar Cambios" AutoPostback="False"></asp:Button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal para Editar Paquete -->
        <div class="modal fade" id="editmodal" tabindex="-1" aria-labelledby="editmodallabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="editmodallabel">Editar Producto</h1>
                        <asp:Button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" runat="server"></asp:Button>
                    </div>
                    <div class="modal-body">
                        <div class="mb-3 col">
                            <asp:Label runat="server" class="form-label">Nombre</asp:Label>
                            <asp:TextBox runat="server" type="text" name="name" ID="TextBox3" class="form-control" />
                        </div>
                        <div class="row align-items-start">
                            <div class="mb-3 col">
                                <asp:Label runat="server" class="form-label">Precio</asp:Label>
                                <asp:TextBox runat="server" type="number" ID="TextBox4" step="0.01" name="price" class="form-control" />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Imagen</label>
                                <asp:FileUpload runat="server" class="form-control" type="file" ID="FileUpload2" />
                            </div>
                        </div>
                        <div class="row align-items-start">
                            <div class="mb-3">
                                <asp:Label runat="server" class="form-label">Descripción</asp:Label>
                                <asp:TextBox TextMode="MultiLine" runat="server" type="text" name="sinopsis" class="form-control" ID="TextBox5"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row align-items-start">
                            <div class="mb-3 col">
                                <asp:Label runat="server" class="form-label">Id</asp:Label>
                                <asp:TextBox runat="server" type="number" name="id" disabled="true" class="form-control" ID="ids" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnEdit" runat="server" type="button" class="btn btn-primary" Text="Guardar Cambios" OnClick="btnEdit_Click1"></asp:Button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal para Eliminar Paquete -->
        <div class="modal fade" id="deleteModal" tabindex="-1" aria-labelledby="deleteModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="deleteModalLabel">Eliminar Paquete</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="idel" Text="ID" runat="server" />

                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                            <asp:Button ID="btnDel" runat="server" type="button" class="btn btn-danger" OnClick="delete_click" Text="Eliminar"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Repeater para listar los paquetes -->
        <asp:Repeater ID="repeaterPackage" runat="server">
            <ItemTemplate>
                <div class="Producto">
                    <div class="d-flex justify-content-center" style="width: 150px; height: 150px; border-radius: 8px;">
                        <asp:Image class="mb-2 mt-2" ImageUrl='<%# Eval("Img_paquete") %>' runat="server" />
                    </div>
                    <div>
                        <h2 runat="server" class="title"><%# TruncateText(Eval("Nombre").ToString(),35) %></h2>
                        <div class="d-flex">
                            <p class="price">Precio: <%# String.Format("{0:0.00}", Eval("Precio")) %> €</p>
                        </div>
                        <div class="d-flex">
                            <p class="id">ID: <%# Eval("IdPaquete") %></p>
                        </div>
                    </div>
                    <div class="mod-buttons">
                        <asp:LinkButton runat="server" class="edit" OnClick="btnEdit_Click" CommandArgument='<%# Eval("IdPaquete")%>'>
                            <i class="fa-solid fa-pen-to-square"></i> Editar
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" class="delete" OnClick="btnDel_Click" CommandArgument='<%# Eval("IdPaquete")%>'>
                            <i class="fa-solid fa-trash"></i> Eliminar
                        </asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
