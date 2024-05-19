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
            // Método para cargar los paquetes
            ENPaquete paquete = new ENPaquete();
            List<ENPaquete> listaPaquetes = paquete.ObtenerTodosLosPaquetes();

            repeaterPaquetes.DataSource = listaPaquetes;
            repeaterPaquetes.DataBind();
        }

        protected void Anyadir_Click(object sender, EventArgs e)
        {
            // Lógica para añadir al carrito (si es necesario)
            Response.Redirect("carrito.aspx");
        }
    }
}