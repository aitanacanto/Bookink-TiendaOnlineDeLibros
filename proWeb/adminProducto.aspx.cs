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
                listaProductos.Add(new ENProducto(1, "Producto 1", 10, 50.0f, 45.0f, 1, DateTime.Now, "content/producto.jpg", "a", "b", "Javier Castillo"));
                listaProductos.Add(new ENProducto(2, "Producto 2", 15, 60.0f, 55.0f, 2, DateTime.Now, "content/producto.jpg", "a", "b", "Javier Castillo"));
                listaProductos.Add(new ENProducto(3, "Producto 3", 20, 70.0f, 65.0f, 1, DateTime.Now, "content/producto.jpg", "a", "b", "Javier Castillo"));
                listaProductos.Add(new ENProducto(4, "Producto 4", 25, 80.0f, 75.0f, 2, DateTime.Now, "content/producto.jpg", "a", "b", "Javier Castillo"));
                listaProductos.Add(new ENProducto(5, "Producto 5", 30, 90.0f, 85.0f, 1, DateTime.Now, "content/producto.jpg", "a", "b", "Javier Castillo"));
                listaProductos.Add(new ENProducto(6, "Producto 6", 35, 100.0f, 95.0f, 2, DateTime.Now, "content/producto.jpg", "a", "b", "Javier Castillo"));

                return listaProductos;
            }
     };
}