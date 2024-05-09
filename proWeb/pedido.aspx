<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pedido.aspx.cs" Inherits="proWeb.pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>  
      .container {
        display: flex; 
        height: 100%;
        width: 100%; 
      }

      .right-section, .left-section {
        width: 50%; 
        padding: 20px; 
        box-sizing: border-box; 
      }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
      <div class="left-section">
         <div style="margin-bottom: 5px;"> <span style="font-size: 20px;"> <strong>  Contacto  </strong> </span> </div>

        <div class="col-sm", style="margin-bottom: 5px;">
            <input type="text" class="form-control" placeholder="Correo electrónico" aria-label="Correo electrónico">
        </div>

        <div class="form-check", style="margin-bottom: 20px;">
          <input class="form-check-input" type="checkbox" value="" id="EnviarOfer">
          <label class="form-check-label" for="EnviarOfer">
            Enviarme novedades y ofertas por correo electrónico
          </label>
        </div>

        <div style="margin-bottom: 5px;"> <span style="font-size: 20px;"> <strong>  Entrega </strong> </span> </div>

        <div class="col-sm", style="margin-bottom: 5px;">
            <input type="text" class="form-control" placeholder="País / Región" aria-label="País / Región">
        </div>

        <div class="row g-3", style="margin-bottom: 5px;">
          <div class="col-sm">
            <input type="text" class="form-control" placeholder="Nombre" aria-label="Nombre">
          </div>
          <div class="col-sm-7">
            <input type="text" class="form-control" placeholder="Apellidos" aria-label="Apellidos">
          </div>
        </div>

        <div class="col-sm", style="margin-bottom: 5px;">
            <input type="text" class="form-control" placeholder="Dirección" aria-label="Dirección">
        </div>

        <div class="row g-3", style="margin-bottom: 5px;">
          <div class="col-sm">
            <input type="text" class="form-control" placeholder="Código Postal" aria-label="Código Postal">
          </div>
          <div class="col-sm">
            <input type="text" class="form-control" placeholder="Ciudad" aria-label="Ciudad">
          </div>
          <div class="col-sm">
            <input type="text" class="form-control" placeholder="Provincia" aria-label="Provincia">
          </div>
        </div>

        <div class="col-sm", style="margin-bottom: 5px;">
            <input type="text" class="form-control" placeholder="Teléfono" aria-label="Teléfono">
        </div>

        <div class="form-check", style="margin-bottom: 20px;">
          <input class="form-check-input" type="checkbox" value="" id="GuardarDir">
          <label class="form-check-label" for="GuardarDir">
            Guardar dirección para próximas compras
          </label>
        </div>


        <div style="margin-bottom: 5px;"> <span style="font-size: 20px;"> <strong>  Pago  </strong> </span> </div>

        <div class="col-sm", style="margin-bottom: 5px;">
            <input type="text" class="form-control" placeholder="Num.Tarjeta" aria-label="Num.Tarjeta">
        </div>
        <div class="row g-3", style="margin-bottom: 5px;">
          <div class="col-sm">
            <input type="text" class="form-control" placeholder="Fecha de vencimiento (MM/AA)" aria-label="Fecha de vencimiento (MM/AA)">
          </div>
          <div class="col-sm">
            <input type="text" class="form-control" placeholder="cvv" aria-label="cvv">
          </div>
        </div>
        <div class="col-sm">
            <input type="text" class="form-control" placeholder="Nombre del titular" aria-label="Nombre del titular">
        </div>
        
        <div class="d-grid gap-2", style="margin-top: 15px">
          <button class="btn-buy">Pagar</button>
        </div>
      </div>

      <div class="right-section">
         <div class="item">
            <p>Nombre del Producto 1</p>
            <p>Precio: $10.00</p>
        </div>
        <div class="item">
            <p>Nombre del Producto 2</p>
            <p>Precio: $15.00</p>
        </div>
        <div class="item">
            <p>Nombre del Producto 3</p>
            <p>Precio: $20.00</p>
        </div>
        <div class="total">
            Total de artículos: 3
        </div>
      </div>
    </div>

</asp:Content>
