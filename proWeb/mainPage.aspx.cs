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
            // Aquí deberías escribir el código para obtener tus datos
            // Simplemente devuelve una lista de productos como ejemplo

            List<ENProducto> listaProductos = new List<ENProducto>();
            
            // Añade algunos productos de ejemplo (debes obtenerlos de tu fuente de datos real)
            listaProductos.Add(new ENProducto(1, "Producto 1", 10, 50.0f, 45.0f, 1, DateTime.Now, "content/producto.jpg"));
            listaProductos.Add(new ENProducto(2, "Producto 2", 15, 60.0f, 55.0f, 2, DateTime.Now, "content/producto.jpg"));
            listaProductos.Add(new ENProducto(3, "Producto 3", 20, 70.0f, 65.0f, 1, DateTime.Now, "content/producto.jpg"));
            listaProductos.Add(new ENProducto(4, "Producto 4", 25, 80.0f, 75.0f, 2, DateTime.Now, "content/producto.jpg"));
            listaProductos.Add(new ENProducto(5, "Producto 5", 30, 90.0f, 85.0f, 1, DateTime.Now, "content/producto.jpg"));
            listaProductos.Add(new ENProducto(6, "Producto 6", 35, 100.0f, 95.0f, 2, DateTime.Now, "content/producto.jpg"));
            listaProductos.Add(new ENProducto(5, "Producto 7", 12, 21.0f, 11.0f, 1, DateTime.Now, "content/producto.jpg"));
            listaProductos.Add(new ENProducto(6, "Producto 8", 35, 14.23f, 10.0f, 2, DateTime.Now, "content/producto.jpg"));

            return listaProductos;
        }
    }
}