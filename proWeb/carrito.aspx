<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="proWeb.carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

		<div class="contenedor">
			<div class="cuadro-blanco" style="max-width:1300px;width:1300px">
				<div class="contenido" style="text-align:left;padding:50px;">

					<h1>MI CESTA</h1>
					<div style="display:inline-block;"><p style="display:inline-block;">Total de artículos:</p><asp:Label style="display:inline-block;" runat="server" ID="labelNLibros">0</asp:Label></div>
					<br />
					<br />
					<asp:Literal runat="server" ID="literalLibros" ></asp:Literal>
					<br />
					<br />
					<asp:Button ID="buy" runat="server" Text="Comprar"/>

				</div>
			</div>
		</div>


</asp:Content>