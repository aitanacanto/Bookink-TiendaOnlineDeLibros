using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace proWeb
{
    public partial class carrito : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Logic for initial page load, if needed
            }
        }

        // Método para eliminar un elemento del carrito
        protected void Remove_Click(object sender, EventArgs e)
        {
            
        }

        // Método para añadir más elementos al carrito
        protected void Add_Click(object sender, EventArgs e)
        {
            
        }

        // Método para comprar productos y redirigir a otra página
        protected void Buy_Click(object sender, EventArgs e)
        {
            Response.Redirect("pedido.aspx"); // Redirigir a la página de pedido
        }
    }
}
