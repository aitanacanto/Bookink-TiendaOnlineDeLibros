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
        const int MaxRelacionados = 4;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(Id))
            {
                productId = int.Parse(Id);
            }
            if (!IsPostBack)
            {
                if (productId != -1) CargarProducto(productId);
                List<ENProducto> listaProductos = ObtenerProductos();

                List<ENProducto> Relacionado = new List<ENProducto>();
                Random rnd = new Random();
                List<ENProducto> productosAleatorios = listaProductos.OrderBy(x => rnd.Next()).ToList();
                Relacionado = productosAleatorios.GetRange(0,MaxRelacionados);

                List<ENReseña> listaReseñas = ENReseña.GetReseñas(productId); //TODO: que solo muestre 5 reseñas
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

                ENUsuario user = Session["user"] as ENUsuario;
                if (user == null || !user.HaPedido(productId))
                {
                    InputRating.Enabled = false;
                    InputComment.Enabled = false;
                    AddResenyaButton.Enabled = false;
                }
                else
                {
                    InputRating.Enabled = true;
                    InputComment.Enabled = true;
                    AddResenyaButton.Enabled = true;
                }
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

        protected void AddResenyaButton_Click(object sender, EventArgs e)
        {
            ENUsuario user = Session["user"] as ENUsuario;
            float valoracion = float.Parse(InputRating.Text) / 100 * 5; // para tener un número entre 0 y 5
            ENReseña nuevaRes = new ENReseña(user.Id,productId, valoracion, InputComment.Text, DateTime.Now);

            if (nuevaRes.Exists()) nuevaRes.Update();
            else nuevaRes.Create();
            
            Response.Redirect("mainPage.aspx");
        }
    }
}