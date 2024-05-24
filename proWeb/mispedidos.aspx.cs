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
        List<List<ENProducto>> listap = new List<List<ENProducto>>();
        List<ENPedido> listaPedidos = new List<ENPedido>();
        int i = 0;
        ENCarrito cesta;
        protected void Page_Load(object sender, EventArgs e)
        {
            ensenyarPedidos();
        }

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater repeaterLinped = (Repeater)args.Item.FindControl("repeaterLinped");
                List<ENProducto> productos = listap[i];
                i++;

                if (repeaterLinped != null)
                {
                    // Enlaza los productos al Repeater hijo
                    repeaterLinped.DataSource = productos;
                    repeaterLinped.DataBind();
                }
            }
        }

        protected void ensenyarPedidos()
        {
            cesta = Session["Carrito"] as ENCarrito;
            ped.Id_usuario = cesta.id_usuario;
            listaPedidos = ped.verPedidos();

            foreach (ENPedido pedido in listaPedidos)
            {
                List<ENLinPedido> lp = new List<ENLinPedido>();
                List<ENProducto> lpro = new List<ENProducto>();
                ENLinPedido linped = new ENLinPedido();
                linped.Id_Pedido = pedido.Numped;
                lp = linped.readALL();

                foreach (ENLinPedido ped in lp)
                {
                    ENProducto producto = new ENProducto();
                    producto.Id = ped.Id_Producto;
                    producto.Read();
                    lpro.Add(producto);
                }

                listap.Add(lpro);
            }

            repeaterPedidos.DataSource = listaPedidos;
            repeaterPedidos.DataBind();
        }
    }
}