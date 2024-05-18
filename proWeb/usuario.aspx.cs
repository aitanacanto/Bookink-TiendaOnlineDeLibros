using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

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
            // Crear una nueva instancia de ENDireccion
            ENDireccion direccion = new ENDireccion();

            // Establecer las propiedades de la dirección con los valores de los campos de texto
            direccion.ID = Int32.Parse(txtDireccionNueva.Text); // Asegúrate de que el ID es un número entero
            direccion.CodPostal = txtCodPostalNuevo.Text; // Asume que tienes un campo de texto para el código postal
            direccion.Direccion = txtDireccionNueva.Text;
            direccion.Ciudad = txtCiudadNueva.Text; // Asume que tienes un campo de texto para la ciudad
            direccion.Pais = txtPaisNuevo.Text; // Asume que tienes un campo de texto para el país

            // Llamar al método Update para actualizar la dirección en la base de datos
            bool resultado = direccion.Update();

            if (resultado)
            {
                // La dirección se actualizó correctamente
                lblMensaje.Text = "La dirección se actualizó correctamente.";
            }
            else
            {
                // Hubo un error al actualizar la dirección
                lblMensaje.Text = "Hubo un error al actualizar la dirección.";
            }
        }

    }
}