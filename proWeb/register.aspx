<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="proWeb.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Enlace al archivo CSS -->
    <link rel="stylesheet" href="styles.css" />
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

    <div class="container login-form">
            <h1>REGISTRO</h1>
            <div class="mb-3">
                <label for="Nombre">Nombre</label>
                <asp:TextBox ID="Nombre" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Apellidos">Apellidos</label>
                <asp:TextBox ID="Apellidos" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Email">Email</label>
                <asp:TextBox ID="Email" runat="server" TextMode="Email" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Contraseña">Contraseña</label>
                <asp:TextBox ID="Contraseña" runat="server" TextMode="Password" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Confirmar_Contraseña">Confirmar contraseña</label>
                <asp:TextBox ID="ConfirmarContra" runat="server" TextMode="Password" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="mb-3">Teléfono</label>
                <asp:TextBox ID="Telefono" runat="server" TextMode="Number" CssClass="form-control" onkeyup="telefono(this)"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="NIF">DNI</label>
                <asp:TextBox ID="NIF" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="mb-3 related-products">
                <div class="mb-3 flex-item">
                    <label for="cop_postal">Código postal</label>
                    <asp:TextBox ID="cod_postal" runat="server" TextMode="Number" CssClass="form-control" Required="true" onkeyup="codigoPostal(this)"></asp:TextBox>
                </div>
                <div class="mb-3 flex-item">
                    <label for="calle">Calle</label>
                    <asp:TextBox ID="calle" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
                </div>
                <div class="mb-3 flex-item">
                    <label for="Ciudad">Ciudad</label>
                    <asp:TextBox ID="ciudad" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
                </div>
                <div class="mb-3 flex-item">
                    <label for="Pais">País</label>
                    <asp:TextBox ID="pais" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Label ID="LabelOculta" runat="server" Visible="false">fdsafjdasklfjdas</asp:Label>          
            </div>
            <div class="button-container" style="text-align: center; margin-top: 20px;"> 
              <!-- Botón para Registrarse -->
              <asp:Button 
                  ID="btnRegister" 
                  runat="server" 
                  Text="Registrarse" 
                  CssClass="button" 
                  OnClick="Register_Click" 
              />
            </div>

      </div>
</asp:Content>