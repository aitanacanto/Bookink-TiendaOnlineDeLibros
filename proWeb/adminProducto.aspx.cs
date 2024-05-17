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
        private static List<ENProducto> listaProductos = new List<ENProducto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaProductos = ObtenerProductos();


                BindRepeater();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = TxtName.Text;
                int stock = int.Parse(TxtNumPag.Text);
                float price = float.Parse(TxtPrice.Text);
                float saleprice = float.Parse(TxtSalePrice.Text);
                ENProducto newProduct = new ENProducto(name, stock, price, saleprice, "", "", "", "", "", 1000, 1000);
                newProduct.Create();
                listaProductos.Add(newProduct);
                BindRepeater();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido añadir el producto, ERROR: {0}", ex.Message);
                return;

            }
            
        }
        private void BindRepeater()
        {
            reapeterProduct.DataSource = listaProductos;
            reapeterProduct.DataBind();
        }
        private List<ENProducto> ObtenerProductos()
            {
            List<ENProducto> productos = new List<ENProducto>();

            productos.Add(new ENProducto("Producto 1", 10, 50.0f, 45.0f, "content/producto.jpg", "Sinopsis 1", "Javier Castillo", "CodOfer1", "Editorial1", 2023, 100));
            productos.Add(new ENProducto("Producto 2", 15, 60.0f, 55.0f, "content/producto.jpg", "Sinopsis 2", "Javier Castillo", "CodOfer2", "Editorial2", 2023, 200));
            productos.Add(new ENProducto("Producto 3", 20, 70.0f, 65.0f, "content/producto.jpg", "Sinopsis 3", "Javier Castillo", "CodOfer3", "Editorial3", 2023, 300));
            productos.Add(new ENProducto("Producto 4", 25, 80.0f, 75.0f, "content/producto.jpg", "Sinopsis 4", "Javier Castillo", "CodOfer4", "Editorial4", 2023, 400));
            productos.Add(new ENProducto("Producto 5", 30, 90.0f, 85.0f, "content/producto.jpg", "Sinopsis 5", "Javier Castillo", "CodOfer5", "Editorial5", 2023, 500));
            productos.Add(new ENProducto("Producto 6", 35, 100.0f, 95.0f, "content/producto.jpg", "Sinopsis 6", "Javier Castillo", "CodOfer6", "Editorial6", 2023, 600));

            return productos;
            }

            
     };
}