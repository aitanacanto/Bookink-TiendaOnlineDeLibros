<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mispedidos.aspx.cs" Inherits="proWeb.mispedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1> Mis Pedidos </h1>
    
        <div class="accordion" id="accordionPanelsStayOpenExample">
          <div class="accordion-item">
            <h2 class="accordion-header">
              <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseOne" aria-expanded="true" aria-controls="panelsStayOpen-collapseOne">
               Pedido 1
              </button>
            </h2>
            <div id="panelsStayOpen-collapseOne" class="accordion-collapse collapse show">
              <div class="accordion-body">
                <div>
                    <span><strong>Num.Pedido:</strong></span>
                    <span style="font-size: 15px;"> 555666777 </span>
                </div>
                <ul>
                    <li style="margin-right: 100px;">
                        <img src="https://m.media-amazon.com/images/I/41JR-l6I5bL._SY445_SX342_.jpg" alt="Nombre del Producto 1" style="max-width: 100px; height: auto;" />
                        <div style="display: inline-block;">
                            <div>
                                <span>El honor de un escocés</span>
                            </div>
                            <div>
                                <span>Jana Westwood</span>
                            </div>
                            <div>
                                <span>17,67€</span>
                            </div>
                        </div>
                    </li>
                    <li style="margin-right: 100px;">
                        <img src="https://m.media-amazon.com/images/I/41L0RDdI+1L._SY445_SX342_.jpg" alt="Nombre del Producto 2" style="max-width: 100px; height: auto;" />
                        <div style="display: inline-block;">
                            <div>
                                <span>El destino de Caillen</span>
                            </div>
                            <div>
                                <span>Jana Westwood</span>
                            </div>
                            <div>
                                <span>17,67€</span>
                            </div>
                        </div>
                    </li>
                </ul>
                <div>
                    <span><strong>Precio Total:</strong></span>
                    <span style="font-size: 15px;"> 35,34€ </span>
                </div>
              </div>
            </div>
          </div>
          <div class="accordion-item">
            <h2 class="accordion-header">
              <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseTwo" aria-expanded="false" aria-controls="panelsStayOpen-collapseTwo">
                Pedido 2
              </button>
            </h2>
            <div id="panelsStayOpen-collapseTwo" class="accordion-collapse collapse">
              <div class="accordion-body">
                <div>
                    <span><strong>Num.Pedido:</strong></span>
                    <span style="font-size: 15px;"> 987654321 </span>
                </div>
                <ul>
                    <li style="margin-right: 100px;">
                        <img src="https://m.media-amazon.com/images/I/41JR-l6I5bL._SY445_SX342_.jpg" alt="Nombre del Producto 1" style="max-width: 100px; height: auto;" />
                        <div style="display: inline-block;">
                            <div>
                                <span>El honor de un escocés</span>
                            </div>
                            <div>
                                <span>Jana Westwood</span>
                            </div>
                            <div>
                                <span>17,67€</span>
                            </div>
                        </div>
                    </li>
                    <li style="margin-right: 100px;">
                        <img src="https://m.media-amazon.com/images/I/41L0RDdI+1L._SY445_SX342_.jpg" alt="Nombre del Producto 2" style="max-width: 100px; height: auto;" />
                        <div style="display: inline-block;">
                            <div>
                                <span>El destino de Caillen</span>
                            </div>
                            <div>
                                <span>Jana Westwood</span>
                            </div>
                            <div>
                                <span>17,67€</span>
                            </div>
                        </div>
                    </li>
                </ul>
                <div>
                    <span><strong>Precio Total:</strong></span>
                    <span style="font-size: 15px;"> 35,34€ </span>
                </div>
              </div>
            </div>
          </div>
          <div class="accordion-item">
            <h2 class="accordion-header">
              <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseThree" aria-expanded="false" aria-controls="panelsStayOpen-collapseThree">
                Pedido 3
              </button>
            </h2>
            <div id="panelsStayOpen-collapseThree" class="accordion-collapse collapse">
              <div class="accordion-body">
                <div>
                    <span><strong>Num.Pedido:</strong></span>
                    <span style="font-size: 15px;">123456789</span>
                </div>
                <ul>
                    <li style="margin-right: 100px;">
                        <img src="https://m.media-amazon.com/images/I/41JR-l6I5bL._SY445_SX342_.jpg" alt="Nombre del Producto 1" style="max-width: 100px; height: auto;" />
                        <div style="display: inline-block;">
                            <div>
                                <span>El honor de un escocés</span>
                            </div>
                            <div>
                                <span>Jana Westwood</span>
                            </div>
                            <div>
                                <span>17,67€</span>
                            </div>
                        </div>
                    </li>
                    <li style="margin-right: 100px;">
                        <img src="https://m.media-amazon.com/images/I/41L0RDdI+1L._SY445_SX342_.jpg" alt="Nombre del Producto 2" style="max-width: 100px; height: auto;" />
                        <div style="display: inline-block;">
                            <div>
                                <span>El destino de Caillen</span>
                            </div>
                            <div>
                                <span>Jana Westwood</span>
                            </div>
                            <div>
                                <span>17,67€</span>
                            </div>
                        </div>
                    </li>
                </ul>
                <div>
                    <span><strong>Precio Total:</strong></span>
                    <span style="font-size: 15px;"> 35,34€ </span>
                </div>
              </div>
            </div>
          </div>
        </div>
    </div>
</asp:Content>
