using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace proWeb
{
    public partial class catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PoblarFiltros();
                string searchQuery = Request.QueryString["search"];
                CargarLibros(searchQuery);
                CargarPaquetes();
            }
        }

        private void CargarLibros(string searchQuery = "")
        {
            ENProducto en = new ENProducto();
            List<ENProducto> listaProductos = new List<ENProducto>();
            if (string.IsNullOrEmpty(searchQuery))
            {
                listaProductos = en.ObtenerTodosLosProductos();
            }
            else
            {
                listaProductos = en.BuscarProductosPorNombre(searchQuery);
            }
            reapeterProduct.DataSource = listaProductos;
            reapeterProduct.DataBind();
        }

        private void CargarPaquetes()
        {
            List<ENProducto> listaProductos = new List<ENProducto>();
            ENPaquete paquete = new ENPaquete();
            List<ENPaquete> listaPaquetes = paquete.ObtenerTodosLosPaquetes();

            repeaterPaquetes.DataSource = listaPaquetes;
            repeaterPaquetes.DataBind();
        }

        protected void Anyadir_Click(object sender, EventArgs e)
        {
            ENCarrito carrito = Session["Carrito"] as ENCarrito;
            if (carrito == null)
            {
                carrito = new ENCarrito();
                Session["Carrito"] = carrito;
            }
            Button button = (Button)sender;
            int id_producto = int.Parse(button.CommandArgument);
            carrito.anyadirProductoCarrito(id_producto);
        }

        private void PoblarFiltros()
        {
            PoblarCategorias();
            PoblarEditoriales();
            PoblarAutores();
        }

        private void PoblarCategorias()
        {
            ddlCategoria.Items.Clear();
            ddlCategoria.Items.Add(new ListItem("Selecciona una categoría", ""));

            ENCategoria enCat = new ENCategoria();
            List<ENCategoria> categories = enCat.GetAllCategories();

            foreach (ENCategoria categoria in categories)
            {
                ddlCategoria.Items.Add(new ListItem(categoria.Nombre, categoria.Id.ToString()));
            }
        }

        private void PoblarEditoriales()
        {
            ddlEditorial.Items.Clear();
            ddlEditorial.Items.Add(new ListItem("Selecciona una editorial", ""));

            ENProducto enProd = new ENProducto();
            List<string> editoriales = enProd.ObtenerTodasLasEditoriales();

            foreach (string editorial in editoriales)
            {
                ddlEditorial.Items.Add(new ListItem(editorial, editorial));
            }
        }

        private void PoblarAutores()
        {
            ddlAutor.Items.Clear();
            ddlAutor.Items.Add(new ListItem("Selecciona un autor", ""));

            ENProducto enProd = new ENProducto();
            List<string> autores = enProd.ObtenerTodosLosAutores();

            foreach (string autor in autores)
            {
                ddlAutor.Items.Add(new ListItem(autor, autor));
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string searchQuery = Request.QueryString["search"];
            CargarLibros(searchQuery);
            CargarPaquetes();
        }

    }
}