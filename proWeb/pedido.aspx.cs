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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Logic for initial page load, if needed
                CargarCarrito();
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            /*if (ValidateForm())
            {
                
            Response.Redirect("confirmarPedido.aspx");
            }

            Console.WriteLine(ValidateForm());
            */
            Response.Redirect("confirmarPedido.aspx");
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProvince.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCardNumber.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtExpirationDate.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCVV.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCardholderName.Text))
            {
                return false;
            }

            return true;
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
                reapeterCarrito.DataSource = listaCarrito;
                reapeterCarrito.DataBind();
                total_lineas.Text = cesta.ContarProductosEnCarrito().ToString();
                total_pvp.Text = String.Format("{0:0.00}", cesta.CalcularPvp()) + " €";
        }
    }
}