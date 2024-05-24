using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.UI;
using ClassLibrary;
using System.Linq;

namespace proWeb
{
    public partial class metricas : System.Web.UI.Page
    {
        private string constring;

        protected void Page_Load(object sender, EventArgs e)
        {
            constring = ConfigurationManager.ConnectionStrings["database"].ToString();
            if (!IsPostBack)
            {
                graficaVentas();
                CargarTopProductosVendidos();
            }
        }

        private void graficaVentas()
        {
            ENPedido pedido = new ENPedido();
            litScript.Text = pedido.graficaMetrica().ToString(); ;
        }
        
        private void CargarTopProductosVendidos()
        {
            ENProducto producto = new ENProducto();
            List<ENProducto> productosVendidos = producto.ObtenerTopProductosVendidosMetricas();

            if (productosVendidos != null && productosVendidos.Count > 0)
            {
                repeaterTopProducts.DataSource = productosVendidos;
                repeaterTopProducts.DataBind();
            }
        }
    }
}
