using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class LogIn : System.Web.UI.Page
    {
        ENUsuario usuario;
        
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
            usuario = new ENUsuario(loginForm.UserName, loginForm.Password);
            bool logged = usuario.LogIn();
            if (logged)
            {
                // Usuario logeado
                //Response.Redirect("mainpage.aspx");
                Session["User"] = usuario;
                LabelOculta.Text = "Autenticación exitosa. " + usuario.Name;
                LabelOculta.Visible = true;
                ENCarrito cesta = Session["Carrito"] as ENCarrito;
                if (cesta != null)
                {
                    // carrito en memoria
                    cesta.id_usuario = usuario.Id;
                    cesta.insertarCarrito();
                    cesta.readCarrito();

                }
                else
                {
                    // no tengo carrito en memoria y tengo carrito en base de datos
                    cesta = new ENCarrito(usuario.Id);
                   
                }
                Session["Carrito"] = cesta;
                Response.Redirect("Login.aspx");
            }
            else
            {
                // ERROR al hacer login
                LabelOculta.Text = "Credenciales inválidas.";
                LabelOculta.Visible = true;
            }
        }
    }
}