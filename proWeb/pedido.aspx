<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pedido.aspx.cs" Inherits="proWeb.pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            display: flex;
            height: 100%;
            width: 100%;
        }

        .right-section,
        .left-section {
            width: 50%;
            padding: 20px;
            box-sizing: border-box;
        }
    </style>
    <script>
        function telefono(input) {
            input.value = input.value.replace(/\D/g, '').substring(0, 9);
            input.value = input.value.replace(/(\d{3})(\d{3})(\d{3})/, '$1 $2 $3').trim();

            var label = input.previousElementSibling;
            if (input.value.trim() === "" || input.value.trim().length !== 11) {
                input.style.color = "red";
            } else {
                input.style.color = "";
            }
        }

        function codigoPostal(input) {
            input.value = input.value.replace(/\D/g, '').substring(0, 5);

            var label = input.previousElementSibling;
            if (input.value.trim() === "" || input.value.trim().length !== 5) {
                input.style.color = "red";
            } else {
                input.style.color = "";
            }
        }

        function numTarjeta(input) {
            input.value = input.value.replace(/\D/g, '').substring(0, 16);
            input.value = input.value.replace(/(\d{4})(\d{4})(\d{4})(\d{4})/, '$1 $2 $3 $4').trim();

            var label = input.previousElementSibling;
            if (input.value.trim() === "" || input.value.trim().length !== 19) {
                input.style.color = "red";
            } else {
                input.style.color = "";
            }
        }

        function fechaVencimiento(input) {
            input.value = input.value.replace(/\D/g, '').substring(0, 4);
            if (input.value.length > 2) {
                input.value = input.value.replace(/(\d{2})(\d{2})/, '$1/$2');
            }

            var label = input.previousElementSibling;
            if (input.value.trim() === "" || input.value.trim().length !== 5) {
                input.style.color = "red";
            } else {
                input.style.color = "";
            }
        }
            
        function CVV(input) {
            input.value = input.value.replace(/\D/g, '').substring(0, 3);

            var label = input.previousElementSibling;
            if (input.value.trim() === "" || input.value.trim().length !== 3) {
                input.style.color = "red";
            } else {
                input.style.color = "";
            }
        }

        function setErrorStyle(input) {
            var label = input.previousElementSibling;
            if (input.value.trim() === "") {
                label.style.color = "red";
                return false;
            } else {
                label.style.color = "";
                return true;
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="left-section">
            <div style="margin-bottom: 5px;">
                <span style="font-size: 20px;">
                    <strong>Contacto</strong>
                </span>
            </div>

            <div class="col-sm" style="margin-bottom: 5px;">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Correo electrónico" Required="true"></asp:TextBox>
            </div>

            <div class="form-check" style="margin-bottom: 20px;">
                <input class="form-check-input" type="checkbox" value="" id="EnviarOfer">
                <label class="form-check-label" for="EnviarOfer">Enviarme novedades y ofertas por correo electrónico</label>
            </div>

            <div style="margin-bottom: 5px;">
                <span style="font-size: 20px;">
                    <strong>Entrega</strong>
                </span>
            </div>

            <div class="col-sm" style="margin-bottom: 5px;">
                <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" Placeholder="País / Región" Required="true"></asp:TextBox>
            </div>

            <div class="row g-3" style="margin-bottom: 5px;">
                <div class="col-sm">
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Placeholder="Nombre" Required="true"></asp:TextBox>
                </div>
                <div class="col-sm-7">
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" Placeholder="Apellidos" Required="true"></asp:TextBox>
                </div>
            </div>

            <div class="col-sm" style="margin-bottom: 5px;">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Placeholder="Dirección" Required="true"></asp:TextBox>
            </div>

            <div class="row g-3" style="margin-bottom: 5px;">
                <div class="col-sm">
                    <asp:TextBox ID="txtPostalCode" runat="server" CssClass="form-control" Placeholder="Código Postal" onkeyup="codigoPostal(this)" Required="true"></asp:TextBox>
                </div>
                <div class="col-sm">
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" Placeholder="Ciudad" Required="true"></asp:TextBox>
                </div>
                <div class="col-sm">
                    <asp:TextBox ID="txtProvince" runat="server" CssClass="form-control" Placeholder="Provincia" Required="true"></asp:TextBox>
                </div>
            </div>

            <div class="col-sm" style="margin-bottom: 5px;">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Placeholder="Teléfono" onkeyup="telefono(this)" Required="true"></asp:TextBox>
            </div>

            <div class="form-check" style="margin-bottom: 20px;">
                <input class="form-check-input" type="checkbox" value="" id="GuardarDir">
                <label class="form-check-label" for="GuardarDir">Guardar dirección para próximas compras</label>
            </div>

            <div style="margin-bottom: 5px;">
                <span style="font-size: 20px;">
                    <strong>Pago</strong>
                </span>
            </div>

            <div class="col-sm" style="margin-bottom: 5px;">
                <asp:TextBox ID="txtCardNumber" runat="server" CssClass="form-control" Placeholder="Num.Tarjeta" onkeyup="numTarjeta(this)" Required="true"></asp:TextBox>
            </div>
            <div class="row g-3" style="margin-bottom: 5px;">
                <div class="col-sm">
                    <asp:TextBox ID="txtExpirationDate" runat="server" CssClass="form-control" Placeholder="Fecha de vencimiento (MM/AA)" onkeyup="fechaVencimiento(this)" Required="true"></asp:TextBox>
                </div>
                <div class="col-sm">
                    <asp:TextBox ID="txtCVV" runat="server" CssClass="form-control" Placeholder="CVV" onkeyup="CVV(this)" Required="true"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm">
                <asp:TextBox ID="txtCardholderName" runat="server" CssClass="form-control" Placeholder="Nombre del titular" Required="true"></asp:TextBox>
            </div>

            <div class="d-grid gap-2" style="margin-top: 15px;">
                <asp:Button ID="btnPagar" runat="server" CssClass="btn-buy" Text="Pagar" OnClick="btnPagar_Click" />
            </div>
        </div>

        <div class="right-section">
        </div>
    </div>
</asp:Content>
