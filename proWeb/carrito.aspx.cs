using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Script.Serialization;
using ClassLibrary;
namespace proWeb
{
    public partial class carrito : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buy_Click(object sender, EventArgs e)
        {
            Response.Redirect("pedido.aspx");
        }

        private string GenerarHtmlLibros(List<string> tituloproduct)
        {
            // Generar el HTML para los títulos de los productos
            string htmlLibros = "";

            foreach (string tituloLibro in tituloproduct)
            {
            }

            return htmlLibros;
        }

        protected void EliminarLibro(/*ENProducto product*/)
        {

        }
    }
}