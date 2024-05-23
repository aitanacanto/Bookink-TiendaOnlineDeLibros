<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="metricas.aspx.cs" Inherits="proWeb.metricas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Pedidos por Mes/Año</h2>
    <canvas id="pedidosChart" width="400" height="200"></canvas>
    <asp:Literal ID="litScript" runat="server"></asp:Literal>
</asp:Content>
