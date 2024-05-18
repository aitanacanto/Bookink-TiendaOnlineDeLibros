using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario(Nombre.Text, Apellidos.Text, Contraseña.Text, NIF.Text, Email.Text, Telefono.Text);
            bool registro = en.Register();
            if (registro)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                LabelOculta.Text = "fallo gordo";
            }
        }
    }
}