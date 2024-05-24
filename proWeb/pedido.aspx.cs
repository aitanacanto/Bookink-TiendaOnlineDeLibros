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
        List<ENLinPedido> linped = new List<ENLinPedido>();
        List<ENLinCarrito> listaCarrito = new List<ENLinCarrito>();
        ENCarrito cesta;
        ENPedido ped = new ENPedido();
        ENUsuario user;
        bool loaded = false;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user = Session["user"] as ENUsuario;
                if (user == null)
                {
                    //Response.Redirect("LogIn.aspx");
                }
                else
                {
                    //if (!loaded)  CargarDatosUsuario();
                    CargarCarrito();
                }
            }
        }

        private void CargarDatosUsuario()
        {
            txtFirstName.Text = user.Name;
            txtLastName.Text = user.Surname;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.PhoneNumber;
            loaded = true;
        }
        protected void btnPagar_Click(object sender, EventArgs e)
        {
            cesta = Session["Carrito"] as ENCarrito;
            ped.Id_usuario = cesta.id_usuario;
            ped.Cod_carrito = cesta.id;
            ped.Direccion_envio = txtAddress.Text + " " + txtPostalCode.Text + ", " + txtCity.Text + ", " + txtCountry.Text;
            ped.Precio = cesta.CalcularPvp();
            ped.Estado = "En Proceso";
            ped.Date = DateTime.Today;
            ped.crearPedido();

            listaCarrito = cesta.ObtenerProductosEnCarrito();

            foreach (ENLinCarrito item in listaCarrito)
            {
                ENLinPedido nuevoItem = new ENLinPedido(ped.Numped, item.producto.Id, item.cantidad);
                linped.Add(nuevoItem);
            }

            cesta.deleteCarrito();

            foreach (ENLinPedido item in linped)
            {
                ENProducto producto = new ENProducto();
                producto.Id = item.Id_Producto;
                producto.Read();
                producto.Stock -= item.Cantidad;
                producto.Update();
                item.create();
            }

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