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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Aquí llamamos a un método para obtener la lista de productos
                List<ENProducto> listaProductos = ObtenerProductos();
                List<ENProducto> Novedades = new List<ENProducto>();
                for (int i = 0; i < 4; i++)
                {
                    Novedades.Add(listaProductos[i]);
                }
                // Asignamos la lista de productos al repeater
                reapeterProduct.DataSource = listaProductos;
                reapeterProduct.DataBind();

                reapeterNov.DataSource = Novedades;
                reapeterNov.DataBind();
            }
        }

        // Método para obtener la lista de productos (puedes obtenerla de tu base de datos o de donde sea)
        private List<ENProducto> ObtenerProductos()
        {
            List<ENProducto> productos = new List<ENProducto>();
            for (int i = 1; i < 9; i++)
            {
                ENProducto prod = new ENProducto();
                prod.Id = i;
                prod.Read();
                productos.Add(prod);
            }

            return productos;
        }
    }
}