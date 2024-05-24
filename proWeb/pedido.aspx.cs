using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace proWeb
{
    public partial class pedido : Page
    {
        ENCarrito cesta;
        ENPedido ped = new ENPedido();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            cesta = Session["Carrito"] as ENCarrito;
            ped.Id_usuario = cesta.id_usuario;
            ped.Cod_carrito = cesta.id;
            ped.Direccion_envio = txtAddress.Text + " " + txtPostalCode.Text + " " + txtCity + ", " + txtCountry;
            ped.Precio = cesta.CalcularPvp();
            ped.Estado = "En Proceso";
            ped.Date = DateTime.Today;
            ped.crearPedido();
            cesta.deleteCarrito();
            Response.Redirect("confirmarPedido.aspx");
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
                List<ENLinCarrito> listaCarrito = new List<ENLinCarrito>();
                listaCarrito = cesta.ObtenerProductosEnCarrito();
                if (reapeterCarrito != null)
                {
                    reapeterCarrito.DataSource = listaCarrito;
                    reapeterCarrito.DataBind();
                    total_lineas.Text = cesta.ContarProductosEnCarrito().ToString();
                    total_pvp.Text = String.Format("{0:0.00}", cesta.CalcularPvp()) + " €";

                    ped.Id_usuario = cesta.id_usuario;
                    ped.Cod_carrito = cesta.id;
                    ped.Direccion_envio = txtAddress.Text + " " + txtPostalCode.Text + " " + txtCity + ", " + txtCountry;
                    ped.Precio = cesta.CalcularPvp();
                    ped.Estado = "En Proceso";
            }
        }
    }
}