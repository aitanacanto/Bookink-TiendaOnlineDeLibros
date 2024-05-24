using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class mainPage : System.Web.UI.Page
    {
        private int MaxListaProductos = 20; //Número máximo de elementos a mostrar en la lista principal
        private int MaxNovedades = 4; //Número máximo de elementos a mostrar en las novedades
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Aquí llamamos a un método para obtener la lista de productos
                List<ENProducto> listaProductos = ObtenerProductos();
                int prodCount = listaProductos.Count();
                // Aquí hacemos la lista de novedades
                List<ENProducto> Novedades = new List<ENProducto>();
                Novedades = listaProductos.GetRange(prodCount - MaxNovedades, MaxNovedades);
                //Limitamos la lista de productos al minimo entre maxlistaproductos y la cantidad de productos
                if (listaProductos.Count() > MaxListaProductos)
                    listaProductos = listaProductos.GetRange(0, MaxListaProductos);
                // Asignamos la lista de productos al repeater
                reapeterProduct.DataSource = listaProductos;
                reapeterProduct.DataBind();
                // Asignamos la lista de novedades al repeater
                reapeterNov.DataSource = Novedades;
                reapeterNov.DataBind();

                if (Session["Carrito"] == null) Session["Carrito"] = new ENCarrito();
                if (Session["Usuario"] == null) Session["Usuario"] = new ENUsuario();

            }

        }

        // Método para obtener la lista de productos (puedes obtenerla de tu base de datos o de donde sea)
        private List<ENProducto> ObtenerProductos()
        {

            List<ENProducto> listaProductos = new List<ENProducto>();

            ENProducto en = new ENProducto();
            listaProductos = en.ObtenerTodosLosProductos();
            return listaProductos;

        }
        protected void Add_Click(object sender, EventArgs e)
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

        protected void btnVerMas_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string categoria = btn.CommandArgument;

            // Redirigir a una página que muestre los productos filtrados por la categoría seleccionada.
            Response.Redirect($"catalogo.aspx?categoria={categoria}");
        }




    }
}