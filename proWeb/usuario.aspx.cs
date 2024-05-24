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
            if (!IsPostBack)
            {
                user = Session["user"] as ENUsuario;
                if (user == null)
                {
                    Response.Redirect("LogIn.aspx");
                }
                else
                {
                    lblNombreActual.Text = user.Name;
                    lblCorreoActual.Text = user.Email;
                    lblTelefonoActual.Text = user.PhoneNumber;

                    // Cargar y mostrar la primera dirección del usuario
                    user.Direcciones = user.ObtenerDirecciones();
                    if (user.Direcciones.Count > 0)
                    {
                        ActualizarCamposDireccion(user.Direcciones[0]);
                    }

                    // Cargar las direcciones adicionales en el Repeater
                    repeaterDirecciones.DataSource = user.Direcciones.Skip(1); // Omitir la primera dirección
                    repeaterDirecciones.DataBind();
                }
            }
        }

        private void ActualizarCamposDireccion(ENDireccion direccion)
        {
            lblDireccionActual.Text = direccion.Direccion;
            lblCodPostalActual.Text = direccion.CodPostal;
            lblCiudadActual.Text = direccion.Ciudad;
            lblPaisActual.Text = direccion.Pais;
        }

        protected void BtnAgregarDireccion_Click(object sender, EventArgs e)
        {
            ENDireccion nuevaDireccion = new ENDireccion
            {
                Direccion = txtDireccionNueva.Text,
                CodPostal = txtCodPostalNuevo.Text,
                Ciudad = txtCiudadNueva.Text,
                Pais = txtPaisNuevo.Text
            };

            if (nuevaDireccion.Create())
            {
                user.AddAddress(nuevaDireccion);
                lblMensaje.Text = "Dirección agregada correctamente.";
            }
            else
            {
                lblMensaje.Text = "Hubo un error al agregar la nueva dirección.";
            }

            // Recargar direcciones
            user.Direcciones = user.ObtenerDirecciones();
            repeaterDirecciones.DataSource = user.Direcciones.Skip(1); // Omitir la primera dirección
            repeaterDirecciones.DataBind();
        }

        protected void BtnEliminarDireccion_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int direccionId = int.Parse(btnEliminar.CommandArgument);
            ENDireccion direccionAEliminar = user.Direcciones.Find(d => d.ID == direccionId);

            if (direccionAEliminar != null && direccionAEliminar.Delete())
            {
                user.Direcciones.Remove(direccionAEliminar);
                lblMensaje.Text = "Dirección eliminada correctamente.";
            }
            else
            {
                lblMensaje.Text = "Hubo un error al eliminar la dirección.";
            }

            // Recargar direcciones
            user.Direcciones = user.ObtenerDirecciones();
            repeaterDirecciones.DataSource = user.Direcciones.Skip(1); // Omitir la primera dirección
            repeaterDirecciones.DataBind();
        }

        protected void BtnEditarDireccion_Click(object sender, EventArgs e)
        {
            // Implementar lógica de edición de direcciones
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
                //Importante cifrar la contraseña
                user.Password = ENUsuario.ComputeSha256Hash(txtContraseñaNueva.Text);
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
