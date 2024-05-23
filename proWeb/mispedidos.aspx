<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mispedidos.aspx.cs" Inherits="proWeb.mispedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1> Mis Pedidos </h1>
        
        <asp:Repeater ID="repeaterPedidos" runat="server">
            <ItemTemplate>
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target='<%# "#collapse" + Eval("ped.Numped") %>' aria-expanded="false" aria-controls='<%# "collapse" + Eval("ped.Numped") %>'>
                            Pedido <%# Eval("ped.Numped") %>
                        </button>
                    </h2>
                    <div id='<%# "collapse" + Eval("ped.Numped") %>' class="accordion-collapse collapse">
                        <div class="accordion-body">
                            <div>
                                <span><strong>Num.Pedido:</strong></span>
                                <span style="font-size: 15px;"><%# Eval("ped.Numped") %></span>
                            </div>
                            <ul>
                                <asp:Repeater ID="repeaterProductos" runat="server" DataSource='<%# Eval("Productos") %>'>
                                    <ItemTemplate>
                                        <li style="margin-right: 100px;">
                                            <img src='<%# Eval("ImagenUrl") %>' alt='<%# Eval("Nombre") %>' style="max-width: 100px; height: auto;" />
                                            <div style="display: inline-block;">
                                                <div>
                                                    <span><%# Eval("Nombre") %></span>
                                                </div>
                                                <div>
                                                    <span><%# Eval("Autor") %></span>
                                                </div>
                                                <div>
                                                    <span><%# String.Format("{0:0.00}€", Eval("Precio")) %></span>
                                                </div>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div>
                                <span><strong>Precio Total:</strong></span>
                                <span style="font-size: 15px;"><%# String.Format("{0:0.00}€", Eval("PrecioTotal")) %></span>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

