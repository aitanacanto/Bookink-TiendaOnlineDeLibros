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
        ENUsuario user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Session["user"] as ENUsuario;
            if (user == null) //si el usuario no está logeado se redirige a la página de logeo
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                lblNombreActual.Text = user.Name;
                lblCorreoActual.Text = user.Email;
                lblTelefonoActual.Text = user.PhoneNumber;
                lblDireccionActual.Text = "direccion provisional";
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
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
        protected void BtnLogOut(object sender, EventArgs e)
        {
            Session.Remove("User");
            user = new ENUsuario();
            Response.Redirect("mainPage.aspx");
        }
        protected void BtnDeleteUser(object sender, EventArgs e)
        {
            if (!user.DeleteUser())
            {
                lblMensaje.Text = "Hubo un error al borrar el usuario.";
            }
            else
            {
                Session.Remove("User");
                user = new ENUsuario();
                Response.Redirect("mainPage.aspx");
            }
        }
    }
}