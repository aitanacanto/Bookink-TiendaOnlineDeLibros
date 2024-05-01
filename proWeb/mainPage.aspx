<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mainPage.aspx.cs" Inherits="proWeb.mainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Enlace al archivo CSS -->
    <link rel="stylesheet" href="styles.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="py-2">
        <h1>Catálogo Libros</h1>
        <ul id="secciones" class="list-unstyled">
            <li>
                <div class="row">
                    <asp:Repeater ID="reapeterProduct" runat="server">
                        <ItemTemplate>
                            <div class="col-12 col-sm-6 col-md-4 py-3">
                                <div class="card" onclick="window.location.href='mainPage.aspx';" >
                                    <asp:Image ID="imgProduct" runat="server" class="card-img-top" ImageUrl='<%# Eval("ImagePath") %>' AlternateText="Producto" />
                                    <a href="producto.aspx">
                                    <p>
                                        <h5 class="card-text"><%# Eval("Name") %></h5>
                                    </p>
                                </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
