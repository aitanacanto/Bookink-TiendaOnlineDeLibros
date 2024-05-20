<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="confirmarPedido.aspx.cs" Inherits="proWeb.pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .confirmacion {
            font-size: 40px;
            font-weight: bold;
            text-align: center;
            margin-top: 50px;
        }
        .gracias {
            font-size: 20px;
            text-align: center;
            margin-top: 5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="confirmacion">
        <strong>SU PEDIDO HA SIDO REALIZADO</strong>
    </div>
    <div class="gracias">
        ¡Muchas gracias por su compra!
    </div>
</asp:Content>
