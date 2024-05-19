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
            ENUsuario user = new ENUsuario(Nombre.Text, Apellidos.Text, Contraseña.Text, NIF.Text, Email.Text, Telefono.Text);
            bool registro = user.Register();
            if (registro)
            {
                ENDireccion direccion = new ENDireccion(cod_postal.Text,calle.Text,ciudad.Text,pais.Text);
                if (!direccion.Create())
                {
                    LabelOculta.Text = "Error al crear la direccion.";
                    LabelOculta.Visible = true;
                    return;
                }
                ENTieneDireccion tieneDir = new ENTieneDireccion(user.Id,direccion.ID);
                if (!tieneDir.Create())
                {
                    LabelOculta.Text = "Error al vincular la direccion.";
                    LabelOculta.Visible = true;
                    return;
                }
                Response.Redirect("login.aspx");
            }
            else
            {
                LabelOculta.Text = "Error al registrar al usuario.";
                LabelOculta.Visible = true;
            }
        }
    }
}