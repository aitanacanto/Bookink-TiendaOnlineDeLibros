using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ClassLibrary;
using System.Web.UI.WebControls;
using System.Globalization;

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
                int stock = int.Parse(txt_stock.Text);
                float price = float.Parse(TxtPrice.Text, CultureInfo.InvariantCulture);
                float saleprice = float.Parse(TxtSalePrice.Text, CultureInfo.InvariantCulture);
                string sinopsis = Txt_sinopsis.Text;
                string autor = txt_Autor.Text;
                string codOfer = "OF001";
                string editorial = txt_editorial.Text;
                int anyo = int.Parse(txt_anyo.Text);
                int numpag = int.Parse(TxtNumPag.Text);

                ENProducto newProduct = new ENProducto(name, stock, price, saleprice, "", sinopsis, autor, codOfer, editorial, anyo, numpag);
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
            for (int i = 1; i < 10; i++)
            {
                ENProducto prod = new ENProducto();
                prod.Id = i;
                prod.Read();
                productos.Add(prod);
            }
            
            return productos;
        }

            
     };
}