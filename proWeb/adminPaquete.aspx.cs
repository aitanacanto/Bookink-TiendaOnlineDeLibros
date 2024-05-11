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
            List<ENPaquete> listaPaquetes = new List<ENPaquete>();

            listaPaquetes.Add(new ENPaquete(1, "Paquete 1", "Descripción del paquete 1", 100));
            listaPaquetes.Add(new ENPaquete(2, "Paquete 2", "Descripción del paquete 2", 150));
            listaPaquetes.Add(new ENPaquete(3, "Paquete 3", "Descripción del paquete 3", 200));
            listaPaquetes.Add(new ENPaquete(4, "Paquete 4", "Descripción del paquete 1", 100));
            listaPaquetes.Add(new ENPaquete(5, "Paquete 5", "Descripción del paquete 2", 150));
            listaPaquetes.Add(new ENPaquete(6, "Paquete 6", "Descripción del paquete 3", 200));

            return listaPaquetes;
        }
    }
}