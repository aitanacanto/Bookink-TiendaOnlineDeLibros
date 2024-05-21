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
            if (user == null) // Si el usuario no está logeado, se redirige a la página de login
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                lblNombreActual.Text = user.Name;
                lblCorreoActual.Text = user.Email;
                lblTelefonoActual.Text = user.PhoneNumber;
                lblDireccionActual.Text = ObtenerDireccion(user.Id); // Obtiene y muestra la dirección del usuario
            }
        }

        protected string ObtenerDireccion(int userId)
        {
            /*CADTieneDireccion cadTieneDireccion = new CADTieneDireccion();
            ENTieneDireccion tieneDireccion = new ENTieneDireccion(userId);

            if (tieneDireccion != null)
            {
                ENDireccion direccion = new ENDireccion();
                direccion.ID = tieneDireccion.IdDireccion;
                if (direccion.Read())
                {
                    return $"{direccion.Direccion}, {direccion.CodPostal}, {direccion.Ciudad}, {direccion.Pais}";
                }
            }
            return "Dirección no disponible.";*/

            return "Dirección no disponible.";


        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            // Actualizar información de usuario
            if (!string.IsNullOrEmpty(txtCorreoNuevo.Text))
            {
                user.Email = txtCorreoNuevo.Text;
            }
            if (!string.IsNullOrEmpty(txtContraseñaNueva.Text))
            {
                user.Password = txtContraseñaNueva.Text;
            }
            if (!string.IsNullOrEmpty(txtTelefonoNuevo.Text))
            {
                user.PhoneNumber = txtTelefonoNuevo.Text;
            }

            if (user.UpdateUserData())
            {
                lblMensaje.Text = "Información del usuario actualizada correctamente.";
            }
            else
            {
                lblMensaje.Text = "Hubo un error al actualizar la información del usuario.";
            }

            // Actualizar dirección
            ENDireccion direccion = new ENDireccion
            {
                ID = Int32.Parse(txtDireccionNueva.Text), // Asegúrate de que el ID es un número entero
                CodPostal = txtCodPostalNuevo.Text,
                Direccion = txtDireccionNueva.Text,
                Ciudad = txtCiudadNueva.Text,
                Pais = txtPaisNuevo.Text
            };

            if (direccion.Update())
            {
                lblMensaje.Text += " Dirección actualizada correctamente.";
            }
            else
            {
                lblMensaje.Text += " Hubo un error al actualizar la dirección.";
            }
        }

        protected void BtnLogOut(object sender, EventArgs e)
        {
            Session.Remove("User");
            user = new ENUsuario();
            ENCarrito cesta;
            cesta = Session["Carrito"] as ENCarrito;
            Session.Remove("Carrito");
            cesta = new ENCarrito();
            Response.Redirect("mainPage.aspx");
        }

        protected void BtnDeleteUser(object sender, EventArgs e)
        {
            try
            {
                ENUsuario usuarioAEliminar = new ENUsuario();
                usuarioAEliminar.Id = user.Id;

                if (usuarioAEliminar.DeleteUser())
                {
                    Session.Remove("user");
                    Response.Redirect("mainPage.aspx");
                }
                else
                {
                    lblMensaje.Text = "Hubo un error al borrar el usuario.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Hubo un error al borrar el usuario. ERROR: " + ex.Message;
            }
        }
    }
}
