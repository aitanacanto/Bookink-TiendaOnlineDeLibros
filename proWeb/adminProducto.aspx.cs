using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ClassLibrary;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class adminProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ENProducto> listaProductos = ObtenerProductos();

                reapeterProduct.DataSource = listaProductos;
                reapeterProduct.DataBind();
            }
            }

            private List<ENProducto> ObtenerProductos()
            {

                List<ENProducto> listaProductos = new List<ENProducto>();
            listaProductos.Add(new ENProducto("Producto 1", 10, 50.0f, 45.0f, "content/producto.jpg", "Sinopsis 1", "Descripcion 1", "Javier Castillo", "CodOfer1", "Editorial1", 2023, 100));
            listaProductos.Add(new ENProducto("Producto 2", 15, 60.0f, 55.0f, "content/producto.jpg", "Sinopsis 2", "Descripcion 2", "Javier Castillo", "CodOfer2", "Editorial2", 2023, 200));
            listaProductos.Add(new ENProducto("Producto 3", 20, 70.0f, 65.0f, "content/producto.jpg", "Sinopsis 3", "Descripcion 3", "Javier Castillo", "CodOfer3", "Editorial3", 2023, 300));
            listaProductos.Add(new ENProducto("Producto 4", 25, 80.0f, 75.0f, "content/producto.jpg", "Sinopsis 4", "Descripcion 4", "Javier Castillo", "CodOfer4", "Editorial4", 2023, 400));
            listaProductos.Add(new ENProducto("Producto 5", 30, 90.0f, 85.0f, "content/producto.jpg", "Sinopsis 5", "Descripcion 5", "Javier Castillo", "CodOfer5", "Editorial5", 2023, 500));
            listaProductos.Add(new ENProducto("Producto 6", 35, 100.0f, 95.0f, "content/producto.jpg", "Sinopsis 6", "Descripcion 6", "Javier Castillo", "CodOfer6", "Editorial6", 2023, 600));

            return listaProductos;
            }
     };
}