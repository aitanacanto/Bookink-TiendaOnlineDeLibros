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
            List<ENUsuario> listaUsuarios = new List<ENUsuario>();
            CADUsuario cadUsuario = new CADUsuario();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ToString());
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM USUARIO WHERE admin = 0", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            ENUsuario usuario = new ENUsuario();
                            usuario.Id = Convert.ToInt32(reader["id"]);
                            usuario.Name = reader["nombre"].ToString();
                            usuario.Surname = reader["apellidos"].ToString();
                            usuario.Email = reader["email"].ToString();
                            usuario.PhoneNumber = reader["telefono"].ToString();
                            usuario.DNI = reader["dni"].ToString();
                            listaUsuarios.Add(usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los usuarios: " + ex.Message);
            }
            return listaUsuarios;
        }

        private List<ENUsuario> ObtenerTrabajadores()
        {
            List<ENUsuario> listaTrabajadores = new List<ENUsuario>();
            CADUsuario cadUsuario = new CADUsuario();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ToString());
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM USUARIO WHERE admin = 1", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            ENUsuario trabajador = new ENUsuario();
                            trabajador.Id = Convert.ToInt32(reader["id"]);
                            trabajador.Name = reader["nombre"].ToString();
                            trabajador.Surname = reader["apellidos"].ToString();
                            trabajador.Email = reader["email"].ToString();
                            trabajador.PhoneNumber = reader["telefono"].ToString();
                            trabajador.DNI = reader["dni"].ToString();
                            listaTrabajadores.Add(trabajador);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los trabajadores: " + ex.Message);
            }
            return listaTrabajadores;
        }

        protected void btnBorrarTrabajador_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idTrabajador = Convert.ToInt32(btn.CommandArgument);
            ENUsuario trabajador = new ENUsuario();
            trabajador.Id = idTrabajador;

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
