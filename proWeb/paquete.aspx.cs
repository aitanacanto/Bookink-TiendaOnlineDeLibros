using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class paquete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idPaquete;
                if (int.TryParse(Request.QueryString["id"], out idPaquete))
                {
                    CargarPaquete(idPaquete);
                }
                else
                {
                    // Manejar el caso cuando no se proporciona un ID válido
                    Response.Redirect("catalogo.aspx");
                }
            }
        }

        private void CargarPaquete(int idPaquete)
        {
            ENPaquete enPaquete = new ENPaquete { IdPaquete = idPaquete };
            bool leido = enPaquete.leerPaquete();

            if (leido)
            {
                // Mostrar detalles del paquete
                imageProduct.ImageUrl = enPaquete.Img_paquete;
                ProductName.InnerText = enPaquete.Nombre;
                ProductDescription.InnerText = ""; // Agregar descripción si existe en ENPaquete
                ProductPrice.InnerText = $"Precio: {enPaquete.Precio:0.00} €";

                // Cargar los libros del paquete
                List<ENProducto> listaProductos = enPaquete.Productos;
                reapeterProduct.DataSource = listaProductos;
                reapeterProduct.DataBind();
            }
            else
            {
                Response.Redirect("catalogo.aspx");
            }
        }
    }
}