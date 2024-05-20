using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace proWeb
{
    public partial class admin : System.Web.UI.Page
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
                if (!user.Admin) Response.Redirect("LogIn.aspx");
            }
        }
    }
}