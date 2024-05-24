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
        .table-container {
            margin-top: 20px;
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
    <div class="container table-container">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>ID Producto</th>
                    <th>Titulo</th>
                    <th>Precio (€)</th>
                    <th>Número de Ventas</th>
                    
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="repeaterTopProducts" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Id") %></td>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("Price") %></td>
                            <td><%# Eval("Stock") %></td>
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
