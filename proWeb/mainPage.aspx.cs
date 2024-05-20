using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class mainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Aquí llamamos a un método para obtener la lista de productos
                List<ENProducto> listaProductos = ObtenerProductos();
                List<ENProducto> Novedades = new List<ENProducto>();
                for (int i = 0; i < 4; i++)
                {
                    Novedades.Add(listaProductos[i]);
                }
                // Asignamos la lista de productos al repeater
                reapeterProduct.DataSource = listaProductos;
                reapeterProduct.DataBind();

                reapeterNov.DataSource = Novedades;
                reapeterNov.DataBind();
                Session["Carrito"] = new ENCarrito();
                if (Session["Usuario"] ==  null) Session["Usuario"] = new ENUsuario();
            }
            /*ENUsuario user = (ENUsuario)Session["Usuario"];
            if (user.Id != 0)
            {
                LabelOculta.Text = "Bienvenido " + user.Name + " con id " + user.Id;
                LabelOculta.Visible = true;
            }*/
        }

        // Método para obtener la lista de productos (puedes obtenerla de tu base de datos o de donde sea)
        private List<ENProducto> ObtenerProductos()
        {

            List<ENProducto> listaProductos = new List<ENProducto>();

            ENProducto en = new ENProducto();
            listaProductos = en.ObtenerTodosLosProductos();
            return listaProductos;

        }
        protected void Add_Click(object sender, EventArgs e)
        {
            ENCarrito carrito = Session["Carrito"] as ENCarrito;
            if (carrito == null)
            {
                carrito = new ENCarrito();
                Session["Carrito"] = carrito;
            }
            Button button = (Button)sender;
            int id_producto = int.Parse(button.CommandArgument);
            carrito.anyadirProductoCarrito(id_producto);
        }
    }
}