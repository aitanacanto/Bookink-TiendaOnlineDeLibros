<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="metricas.aspx.cs" Inherits="proWeb.metricas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <style>
        .chart-container {
            width: 100%;
            margin: 0 auto;
        }
        canvas {
            max-width: 100%;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center;">Evolución de Ventas</h2>
    <div class="chart-container">
        <canvas id="pedidosChart" width="400" height="200"></canvas>
    </div>
    <asp:Literal ID="litScript" runat="server"></asp:Literal>

    <h2 style="text-align: center;">Top 10 Productos Más Vendidos</h2>
    <div class="container">
        <div class="row">
            <asp:Repeater ID="repeaterTopProducts" runat="server">
                <ItemTemplate>
                    <div class="col-md-3 mb-4 col-lg-3 d-flex mb-4 align-items-stretch">
                        <div class="product-card card d-flex flex-column flex-grow-1">
                            <a href='<%# "producto.aspx?id=" + Eval("Id") %>' class="text-decoration-none d-flex flex-column flex-grow-1">
                                <div class="text-center">
                                    <asp:Image ID="imgTopProduct" runat="server" class="card-img-top img-fluid max-width mb-3 mt-3" ImageUrl='<%# Eval("ImagePath") %>' AlternateText="Producto" />
                                </div>
                                <div class="card-body d-flex flex-column flex-grow-1">
                                    <h5 class="card-title font-weight-bold text-dark mb-0" style="font-weight: bold; text-align: left;"><%# Eval("Nombre") %></h5>
                                    <p class="autor mb-1"><%# Eval("Autor") %></p>
                                    <div class="d-flex">
                                        <p class="card-text text-dark" style="margin-left: 10px;"><%# String.Format("{0:0.00}", Eval("Precio")) %> €</p>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
