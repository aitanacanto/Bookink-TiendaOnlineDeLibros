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
                CargarLibros();
                CargarPaquetes();
            }
        }

        private void CargarLibros()
        {
            ENProducto en = new ENProducto();
            List<ENProducto> listaProductos = new List<ENProducto>();
            listaProductos = en.ObtenerTodosLosProductos();
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
            ddlCategoria.Items.Add(new ListItem("Ficción", "Ficcion"));
            ddlCategoria.Items.Add(new ListItem("No Ficción", "NoFiccion"));
        }

        private void PoblarEditoriales()
        {
            ddlEditorial.Items.Add(new ListItem("Editorial A", "EditorialA"));
            ddlEditorial.Items.Add(new ListItem("Editorial B", "EditorialB"));
        }

        private void PoblarAutores()
        {
            ddlAutor.Items.Add(new ListItem("Autor A", "AutorA"));
            ddlAutor.Items.Add(new ListItem("Autor B", "AutorB"));
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarLibros();
            CargarPaquetes();
        }

    }
}