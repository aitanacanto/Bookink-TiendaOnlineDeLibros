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
            }
        }

        // Método para obtener la lista de productos (puedes obtenerla de tu base de datos o de donde sea)
        private List<ENProducto> ObtenerProductos()
        {
            // Aquí deberías escribir el código para obtener tus datos
            // Simplemente devuelve una lista de productos como ejemplo

            List<ENProducto> listaProductos = new List<ENProducto>();

            // Añade algunos productos de ejemplo (debes obtenerlos de tu fuente de datos real)
            listaProductos.Add(new ENProducto("Producto 1", 10, 50.0f, 45.0f, "content/producto.jpg", "Sinopsis 1", "Javier Castillo", "CodOfer1", "Editorial1", 2023, 100));
            listaProductos.Add(new ENProducto("Producto 2", 15, 60.0f, 55.0f, "content/producto.jpg", "Sinopsis 2", "Javier Castillo", "CodOfer2", "Editorial2", 2023, 200));
            listaProductos.Add(new ENProducto("Producto 3", 20, 70.0f, 65.0f, "content/producto.jpg", "Sinopsis 3", "Javier Castillo", "CodOfer3", "Editorial3", 2023, 300));
            listaProductos.Add(new ENProducto("Producto 4", 25, 80.0f, 75.0f, "content/producto.jpg", "Sinopsis 4", "Javier Castillo", "CodOfer4", "Editorial4", 2023, 400));
            listaProductos.Add(new ENProducto("Producto 5", 30, 90.0f, 85.0f, "content/producto.jpg", "Sinopsis 5", "Javier Castillo", "CodOfer5", "Editorial5", 2023, 500));
            listaProductos.Add(new ENProducto("Producto 6", 35, 100.0f, 95.0f, "content/producto.jpg", "Sinopsis 6", "Javier Castillo", "CodOfer6", "Editorial6", 2023, 600));
            listaProductos.Add(new ENProducto("Producto 7", 12, 21.0f, 11.0f, "content/producto.jpg", "Sinopsis 7", "Javier Castillo", "CodOfer7", "Editorial7", 2023, 700));
            listaProductos.Add(new ENProducto("Producto 8", 35, 14.23f, 10.0f, "content/producto.jpg", "Sinopsis 8", "Javier Castillo", "CodOfer8", "Editorial8", 2023, 800));

            return listaProductos;
        }
    }
}