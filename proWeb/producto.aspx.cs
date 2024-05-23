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
        int productId = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(Id))
                {
                    productId = int.Parse(Id);
                    CargarProducto(productId);
                }
                List<ENProducto> listaProductos = ObtenerProductos();
                List<ENProducto> Relacionado = new List<ENProducto>();
                Random rnd = new Random();
                List<ENProducto> productosAleatorios = listaProductos.OrderBy(x => rnd.Next()).ToList();
                for (int i = 0; i < 4; i++)
                {
                    Relacionado.Add(productosAleatorios[i]);
                }
                List<ENReseña> listaReseñas = ENReseña.GetReseñas(productId);
                // Asignamos la lista de productos al repeater
                reapeterProduct.DataSource = Relacionado;
                reapeterProduct.DataBind();
                // Asignamos la lista de reseñas al repeater
                ReviewRepeater.DataSource = listaReseñas;
                ReviewRepeater.DataBind();
                if (listaReseñas.Count() == 0)
                    LabelResenya.Visible = true;
                else
                    LabelResenya.Visible = false;
                this.DataBind(); // para el primer generar estrellas
            }
        }

        private void CargarProducto(int productId)
        {
            ENProducto prod = new ENProducto
            {
                Id = productId
            };
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
            //string Id = Request.QueryString["id"];
            ENProducto prod = new ENProducto
            {
                Id = productId
            };
            if (productId != -1) //es un producto concreto
            {
                carrito.anyadirProductoCarrito(prod.Id);
            }

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            ENCarrito carrito = Session["Carrito"] as ENCarrito;
            if (carrito == null)
            {
                carrito = new ENCarrito();
                Session["Carrito"] = carrito;
            }
            Button button = (Button)sender;
            carrito.anyadirProductoCarrito(productId);
        }

        private List<ENProducto> ObtenerProductos()
        {

            List<ENProducto> listaProductos = new List<ENProducto>();

            ENProducto en = new ENProducto();
            listaProductos = en.ObtenerTodosLosProductos();
            return listaProductos;

        }
        public string GenerarEstrellas(float valoracion)
        {
            int estrellasLlenas = (int)valoracion;
            bool mediaEstrella = (valoracion - estrellasLlenas) >= 0.5;
            int estrellasVacias = 5 - estrellasLlenas - (mediaEstrella ? 1 : 0);

            string estrellasHtml = "";

            for (int i = 0; i < estrellasLlenas; i++)
            {
                estrellasHtml += "<span class=\"star on\"></span>";
            }

            if (mediaEstrella)
            {
                estrellasHtml += "<span class=\"star half\"></span>";
            }

            for (int i = 0; i < estrellasVacias; i++)
            {
                estrellasHtml += "<span class=\"star\"></span>";
            }

            return estrellasHtml;
        }

        public float ValoracionMedia()
        {
            return ENReseña.ValoracionMedia(productId); 
        }
    }
}