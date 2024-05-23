using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ClassLibrary;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ENUsuario user = Session["user"] as ENUsuario;
                MenuItem midatos = UserMenu.FindItem("Mis Datos");
                MenuItem soyadmin = UserMenu.FindItem("Administración");
                MenuItem iniciar = UserMenu.FindItem("Iniciar Sesión");
                MenuItem registrar = UserMenu.FindItem("Registrarse");
                MenuItem pedidos = UserMenu.FindItem("Mis Pedidos");
                if (user == null)
                {

                    UserMenu.Items.Remove(midatos);
                    UserMenu.Items.Remove(pedidos);
                    UserMenu.Items.Remove(soyadmin);
                    LabelInicio.Visible = false;
                }
                else
                {
                    LabelInicio.Text = "¡Bienvenido, " + user.Name + "!";
                    LabelInicio.Visible = true;
                    UserMenu.Items.Remove(iniciar);
                    UserMenu.Items.Remove(registrar);
                    if (!user.Admin) UserMenu.Items.Remove(soyadmin);
                }
            }
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string query = txtBuscar.Text;
            Response.Redirect($"catalogo.aspx?search={query}");
        }

    }
}