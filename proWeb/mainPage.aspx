<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mainPage.aspx.cs" Inherits="proWeb.mainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ul id="secciones" class="py-2" style="list-style:none";>
        <li>
            <h1>Catálogo Libros</h1>
            <div class="row">
                <asp:Repeater ID="reapeterProduct" runat="server">
                    <ItemTemplate>
                        <div class="card" onclick="" style="cursor:pointer"></div>
                    </ItemTemplate>
                </asp:Repeater>

        </div>

        </li>
    </ul>
</asp:Content>
