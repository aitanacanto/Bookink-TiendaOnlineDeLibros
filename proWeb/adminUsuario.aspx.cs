using System;
using System.Collections.Generic;
using System.Web.UI;
using ClassLibrary;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace proWeb
{
    public partial class adminUsuario : System.Web.UI.Page
    {
        private static List<ENUsuario> listaUsuarios = new List<ENUsuario>();
        private static List<ENUsuario> listaTrabajadores = new List<ENUsuario>();
        ENUsuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaUsuarios = ObtenerUsuarios();
                listaTrabajadores = ObtenerTrabajadores();
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            rptUsuarios.DataSource = listaUsuarios;
            rptUsuarios.DataBind();
            rptTrabajadores.DataSource = listaTrabajadores;
            rptTrabajadores.DataBind();
        }

        private List<ENUsuario> ObtenerUsuarios()
        {
            return ENUsuario.ObtenerUsuarios();
        }

        private List<ENUsuario> ObtenerTrabajadores()
        {
            return ENUsuario.ObtenerTrabajadores();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            LinkButton btnDelete = (LinkButton)sender;
            string email = btnDelete.CommandArgument; // Recuperar el email del argumento del comando
            Session["emailvalue"] = email; // Guardar el email en la sesión

            idel.Text = "¿Seguro que quieres dar de baja al trabajador con email " + email + "?\n";

            string script = @"<script type='text/javascript'>
                    $(document).ready(function () {
                        $('#deleteModal').modal('toggle');
                    });
                  </script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowModal", script);
        }

        protected void delete_click(object sender, EventArgs e)
        {
            try
            {
                string email = Session["emailvalue"].ToString();
                ENUsuario trabajador = new ENUsuario { Email = email };

                if (trabajador.DeleteUser())
                {
                    lblMensaje.Text = "Trabajador eliminado correctamente.";
                    lblMensaje.Visible = true;
                    listaTrabajadores = ObtenerTrabajadores();
                    BindRepeater();
                }
                else
                {
                    lblMensaje.Text = "Error al eliminar el trabajador.";
                    lblMensaje.Visible = true;
                }
            }
            catch (SqlException sqlEx)
            {
                lblMensaje.Text = "No se ha podido eliminar el usuario, ERROR SQL: " + sqlEx.Message;
                lblMensaje.Visible = true;
                Console.WriteLine("SQL ERROR: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "No se ha podido eliminar el trabajador, ERROR: " + ex.Message;
                lblMensaje.Visible = true;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreTrabajador.Text;
                string apellidos = txtApellidosTrabajador.Text;
                string email = txtEmailTrabajador.Text;
                string telefono = txtTelefonoTrabajador.Text;
                string nif = txtNIFTrabajador.Text;
                string password = "password"; // Deberías solicitar la contraseña también

                ENUsuario nuevoTrabajador = new ENUsuario(nombre, apellidos, password, nif, email, telefono);

                if (nuevoTrabajador.Register(true))
                {
                    lblMensaje.Text = "Trabajador agregado correctamente.";
                    lblMensaje.Visible = true;
                    listaTrabajadores = ObtenerTrabajadores();
                    BindRepeater();
                }
                else
                {
                    lblMensaje.Text = "Error al agregar el trabajador.";
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "No se ha podido añadir el trabajador, ERROR: " + ex.Message;
                lblMensaje.Visible = true;
                return;
            }
        }

        protected void btnMakeAdmin(object sender, EventArgs e)
        {
            try
            {
                usuario = Session["user"] as ENUsuario;
                // Obtén el botón que generó el evento
                Button btn = (Button)sender;

                // Obtén el valor del CommandArgument
                string email = btn.CommandArgument;
                usuario.MakeAdmin(email);
                Response.Redirect("adminusuario.aspx");

            } catch (Exception ex)
            {

            }
        }
    }
}
