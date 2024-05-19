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
                // Método para cargar los libros
                CargarLibros();

                // Método para cargar los paquetes
                //CargarPaquetes();
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
            // Aquí deberías escribir el código para obtener tus datos
            // Simplemente devuelve una lista de productos como ejemplo

            List<ENProducto> listaProductos = new List<ENProducto>();
            // Método para cargar los paquetes
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
    }
}