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
                    CargarDatosUsuario();
                    CargarDirecciones();
                }
            }
        }

        private void CargarDatosUsuario()
        {
            lblNombreActual.Text = user.Name;
            lblCorreoActual.Text = user.Email;
            lblTelefonoActual.Text = user.PhoneNumber;
        }

        private void CargarDirecciones()
        {
            user = Session["user"] as ENUsuario;
            user.Direcciones = user.ObtenerDirecciones();
            if (user.Direcciones.Count > 0)
            {
                repeaterDirecciones.DataSource = user.Direcciones;
                repeaterDirecciones.DataBind();
            }
        }

        protected void BtnAgregarDireccion_Click(object sender, EventArgs e)
        {

            user = Session["user"] as ENUsuario;

            ENDireccion nuevaDireccion = new ENDireccion
            {
                Direccion = txtNuevaDireccion.Text,
                CodPostal = txtNuevoCodPostal.Text,
                Ciudad = txtNuevaCiudad.Text,
                Pais = txtNuevoPais.Text
            };

            if (nuevaDireccion.Create())
            {
                ENTieneDireccion tieneDir = new ENTieneDireccion(user.Id, nuevaDireccion.ID);
                if (tieneDir.Create())
                {
                    lblMensaje.Text = "Dirección agregada correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Hubo un error al vincular la nueva dirección.";
                }
            }
            else
            {
                lblMensaje.Text = "Hubo un error al agregar la nueva dirección.";
            }

            // Recargar direcciones
            CargarDirecciones();
        }

        protected void BtnEliminarDireccion_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int direccionId = int.Parse(btnEliminar.CommandArgument);
            ENDireccion direcc = new ENDireccion { ID = direccionId };

            if (direcc.Delete())
            {
                lblMensaje.Text = "Dirección eliminada correctamente.";
            }
            else
            {
                lblMensaje.Text = "Hubo un error al eliminar la dirección.";
            }

            CargarDirecciones();
        }

        protected void BtnEditarDireccion_Click(object sender, EventArgs e)
        {
            Button btnEditar = (Button)sender;
            int direccionId = int.Parse(btnEditar.CommandArgument);
            RepeaterItem item = (RepeaterItem)btnEditar.NamingContainer;

            TextBox txtDireccion = (TextBox)item.FindControl("txtDireccion");
            TextBox txtCodPostal = (TextBox)item.FindControl("txtCodPostal");
            TextBox txtCiudad = (TextBox)item.FindControl("txtCiudad");
            TextBox txtPais = (TextBox)item.FindControl("txtPais");

            txtDireccion.Visible = true;
            txtCodPostal.Visible = true;
            txtCiudad.Visible = true;
            txtPais.Visible = true;

            item.FindControl("btnEditarDireccion").Visible = false;
            item.FindControl("btnConfirmarEdicion").Visible = true;
        }

        protected void BtnConfirmarEdicion_Click(object sender, EventArgs e)
        {
            Button btnConfirmar = (Button)sender;
            int direccionId = int.Parse(btnConfirmar.CommandArgument);
            RepeaterItem item = (RepeaterItem)btnConfirmar.NamingContainer;

            TextBox txtDireccion = (TextBox)item.FindControl("txtDireccion");
            TextBox txtCodPostal = (TextBox)item.FindControl("txtCodPostal");
            TextBox txtCiudad = (TextBox)item.FindControl("txtCiudad");
            TextBox txtPais = (TextBox)item.FindControl("txtPais");

            ENDireccion direccionAEditar = new ENDireccion { ID = direccionId };
            if (direccionAEditar != null)
            {
                direccionAEditar.Direccion = txtDireccion.Text;
                direccionAEditar.CodPostal = txtCodPostal.Text;
                direccionAEditar.Ciudad = txtCiudad.Text;
                direccionAEditar.Pais = txtPais.Text;

                if (direccionAEditar.Update())
                {
                    lblMensaje.Text = "Dirección actualizada correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Hubo un error al actualizar la dirección.";
                }

                // Recargar direcciones
                CargarDirecciones();
            }
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
