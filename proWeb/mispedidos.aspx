<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mispedidos.aspx.cs" Inherits="proWeb.mispedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Mis Pedidos </h1>

        <asp:Repeater ID="repeaterPedidos" runat="server" OnItemDataBound="ItemBound">
            <ItemTemplate>
                <div class="accordion" id="accordionPanelsStayOpenExample">
                    <div class="accordion-item">
                        <h2 class="accordion-header">
                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target='<%# "#collapse" + Eval("Numped") %>' aria-expanded="false" aria-controls='<%# "collapse" + Eval("Numped") %>'>
                                Pedido - Num.pedido: <%# Eval("Numped") %>
                            </button>
                        </h2>
                        <div id='<%# "collapse" + Eval("Numped") %>' class="accordion-collapse collapse">
                            <div class="accordion-body">
                                    <asp:Repeater ID="repeaterLinped" runat="server">
                                        <ItemTemplate>
                                            <li style="margin-right: 100px;">
                                                <img src='<%# Eval("ImagePath") %>' alt='<%# Eval("Name") %>' style="max-width: 100px; height: auto;" />
                                                <div style="display: inline-block;">
                                                    <div>
                                                        <span><%# Eval("Name") %></span>
                                                    </div>
                                                    <div>
                                                        <span><%# Eval("Autor") %></span>
                                                    </div>
                                                    <div>
                                                        <span><%# String.Format("{0:0.00}€", Eval("Price")) %></span>
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <div>
                                    <span> <%# Eval("Direccion_envio") %> </span>
                                    </div>
                                    <div>
                                        <span>Total:  <%# Eval("Precio") %> </span>
                                    </div>
                                    <div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>

        </asp:Repeater>
    </div>
</asp:Content>

