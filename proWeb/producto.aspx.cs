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
    public partial class producto : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(Id))
                {
                    CargarProducto(Id);
                }
            }
        }

        private void CargarProducto(string Id)
        {
            ENProducto prod = new ENProducto();
            prod.Id = int.Parse(Id);
            if (prod.Read())
            {
                ProductName.InnerText = prod.Name;
                ProductAutor.InnerText = prod.Autor;
                ProductPrice.InnerText = String.Format("{0:0.00} €", prod.Price);
                ProductOfer.InnerText = String.Format("{0:0.00} €", prod.SalePrice);
                imageProduct.ImageUrl = prod.ImagePath;
                ProductSinopsis.InnerText = prod.Sinopsis;
                anyo.InnerText = prod.AnyoPubli.ToString();
                editorial.InnerText = prod.Editorial;
                numpag.InnerText = prod.NumPags.ToString();
            }
        }

        protected void Anyadir_Click(object sender, EventArgs e)
        {
            ENCarrito carrito = Session["Carrito"] as ENCarrito;
            if (carrito == null)
            {
                carrito = new ENCarrito();
                Session["Carrito"] = carrito;
            }
            string Id = Request.QueryString["id"];
            ENProducto prod = new ENProducto();
            prod.Id = int.Parse(Id);
            if (!string.IsNullOrEmpty(Id))
            {
                carrito.anyadirProductoCarrito(prod.Id);
            }
            
        }
    }
}