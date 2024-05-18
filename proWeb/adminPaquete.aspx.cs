using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ClassLibrary;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class adminPaquete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<ENPaquete> listaPaquetes = CargarPaquetes();


                repeaterPackage.DataSource = listaPaquetes;
                repeaterPackage.DataBind();
            }
        }

        // Método para cargar la lista de paquetes
        private List<ENPaquete> CargarPaquetes()
        {
            ENPaquete en = new ENPaquete();
            List<ENPaquete> listaPaquetes = en.ObtenerTodosLosPaquetes();

            return listaPaquetes;
        }
    }
}