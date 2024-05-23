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
            string editorial = ddlEditorial.SelectedValue;
            string autor = ddlAutor.SelectedValue;
            int? idCategoria = string.IsNullOrEmpty(ddlCategoria.SelectedValue) ? (int?)null : int.Parse(ddlCategoria.SelectedValue);
            float? precioMinimo = string.IsNullOrEmpty(txtPrecioMin.Text) ? (float?)null : float.Parse(txtPrecioMin.Text);
            float? precioMaximo = string.IsNullOrEmpty(txtPrecioMax.Text) ? (float?)null : float.Parse(txtPrecioMax.Text);

            ENProducto enProd = new ENProducto();
            List<ENProducto> listaProductos = enProd.BuscarProductosPorFiltros(idCategoria, editorial, autor, precioMinimo, precioMaximo);

            // Enlaza la lista filtrada al repeater
            reapeterProduct.DataSource = listaProductos;
            reapeterProduct.DataBind();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            /*
            ENCarrito carrito = Session["Carrito"] as ENCarrito;
            if (carrito == null)
            {
                carrito = new ENCarrito();
                Session["Carrito"] = carrito;
            }
            Button button = (Button)sender;
            int id_producto = int.Parse(button.CommandArgument);
            carrito.anyadirProductoCarrito(id_producto);
            */
            Response.Redirect("mainPage.aspx");
        }
        protected void reapeterNov_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ENProducto producto = (ENProducto)e.Item.DataItem;
                producto.Read();

                var lblPrice = (Label)e.Item.FindControl("lblPrice");
                var lblSalePrice = (Label)e.Item.FindControl("lblSalePrice");

                if (producto.CodOfer == "OF001")
                {
                    lblPrice.Text = String.Format("{0:0.00} €", producto.Price);
                    lblSalePrice.Text = String.Format("{0:0.00} €", producto.SalePrice);
                }
                else if (producto.CodOfer == "OF000")
                {
                    lblSalePrice.Text = String.Format("{0:0.00} €", producto.Price);
                    lblPrice.Visible = false;
                }
            }

        }
    }
}