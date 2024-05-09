using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Aquí es donde normalmente accederías a tu base de datos para obtener la información del cliente.
                // Como este es solo un ejemplo, voy a usar algunos datos de cliente ficticios.

                string nombreCliente = "Juan Pérez";
                string correoCliente = "juan.perez@example.com";
                string telefonoCliente = "123-456-7890";
                string direccionCliente = "Calle Ficticia 123, Ciudad Ficticia";

                // Ahora, vamos a cargar esta información en los controles de la página.

                lblNombreActual.Text = nombreCliente;
                lblCorreoActual.Text = correoCliente;
                lblTelefonoActual.Text = telefonoCliente;
                lblDireccionActual.Text = direccionCliente;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}