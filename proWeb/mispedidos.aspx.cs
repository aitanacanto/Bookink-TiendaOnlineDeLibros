using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace proWeb
{
    public partial class mispedidos : Page
    {
        ENPedido ped = new ENPedido();
        protected void Page_Load(object sender, EventArgs e)
        {
            ensenyarPedidos();
        }

        protected void ensenyarPedidos()
        {
            List<ENPedido> listaPedidos = new List<ENPedido>();
            listaPedidos = ped.verPedidos();
            if (repeaterPedidos != null)
            {
                repeaterPedidos.DataSource = listaPedidos;
                repeaterPedidos.DataBind();
            }
        }
    }
}