using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace proWeb
{
    public partial class carrito : Page
    {
        ENCarrito cesta;
        ENUsuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Logic for initial page load, if needed
                CargarCarrito();
            }
        }

        // Método para eliminar un elemento del carrito
        protected void Remove_Click(object sender, EventArgs e)
        {
            cesta = Session["Carrito"] as ENCarrito;
            Button button = (Button)sender;
            string[] valores = button.CommandArgument.Split('_');

            int id_producto = int.Parse(valores[0]);
            int row = int.Parse(valores[1]);
            cesta.eliminarProductoCarrito(id_producto);
            ENLinCarrito linea = cesta.obtenerLineaProducto(id_producto);
            if(linea != null) {
                Label lblPvp = (Label)reapeterProduct.Items[row].FindControl("pvp");
                lblPvp.Text = String.Format("{0:0.00}", linea.pvp);
                Label lblcantidad = (Label)reapeterProduct.Items[row].FindControl("cantidad");
                lblcantidad.Text = linea.cantidad.ToString();
            }
            CargarCarrito();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            cesta = Session["Carrito"] as ENCarrito;
            if(cesta != null) { 
                cesta.deleteCarrito();
                Response.Redirect("carrito.aspx");
            }
        }
        
        // Método para añadir más elementos al carrito
        protected void Add_Click(object sender, EventArgs e)
        {
            cesta = Session["Carrito"] as ENCarrito;
            Button button = (Button)sender;
            string[] valores = button.CommandArgument.Split('_');
            
            int id_producto = int.Parse(valores[0]);
            int row = int.Parse(valores[1]);
            cesta.anyadirProductoCarrito(id_producto);
            ENLinCarrito linea = cesta.obtenerLineaProducto(id_producto);
            Label lblPvp = (Label)reapeterProduct.Items[row].FindControl("pvp");
            lblPvp.Text = String.Format("{0:0.00}", linea.pvp);
            Label lblcantidad = (Label)reapeterProduct.Items[row].FindControl("cantidad");
            lblcantidad.Text = linea.cantidad.ToString();
            CargarCarrito();
        }

        // Método para comprar productos y redirigir a otra página
        protected void Buy_Click(object sender, EventArgs e)
        {
            cesta = Session["Carrito"] as ENCarrito;
            usuario = Session["user"] as ENUsuario;
            if (cesta.CalcularPvp() != 0) {
                if (usuario != null)
                {
                    Response.Redirect("pedido.aspx");
                }
                else {
                    Response.Redirect("LogIn.aspx");
                }
            }
            else
            {
                Response.Redirect("mainPage.aspx");
            }
        }
        private void CargarCarrito()
        {
            cesta = Session["Carrito"] as ENCarrito;
            if (cesta == null)
            {
                cesta = new ENCarrito();
                Session["Carrito"] = cesta;
            }
            
            ENProducto en = new ENProducto();
            List<ENLinCarrito> listaProductos = new List<ENLinCarrito>();
            listaProductos = cesta.ObtenerProductosEnCarrito();
            reapeterProduct.DataSource = listaProductos;
            reapeterProduct.DataBind();
            total_lineas.Text = cesta.ContarProductosEnCarrito().ToString();
            total_pvp.Text = String.Format("{0:0.00}", cesta.CalcularPvp()) + " €";

        }

    }
}
