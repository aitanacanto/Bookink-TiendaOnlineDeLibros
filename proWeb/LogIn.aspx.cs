using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Register_Click(object sender, EventArgs e)
        {
            // Redirigir a la página de registro
            Response.Redirect("register.aspx");
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            // Código para manejar el inicio de sesión
            CADUsuario cad = new CADUsuario();
            ENUsuario en = new ENUsuario(exampleInputEmail1.Text, exampleInputPassword1.Text);
            bool logged = cad.LogIn(en);
            if (logged)
            {
                // Usuario logeado
                Response.Redirect("mainpage.aspx");
            }
            else
            {
                // ERROR al hacer login
            }
        }
    }
}