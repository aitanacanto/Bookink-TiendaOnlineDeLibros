using System;
using System.Web.UI;

namespace proWeb
{
    public partial class pedido : Page
    {
        protected void btnSeguir_Click(object sender, EventArgs e)
        {
            Response.Redirect("catalogo.aspx");
        }
    }
}
