using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class adminCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();  // Llamar al método para poblar el GridView al cargar la página
            }
        }
        protected void BindGrid()
        {
            // Aquí iría el código para obtener los datos de las categorías y vincularlos al GridView
            
        }
        protected void ButtonAddCategoria_Click(object sender, EventArgs e)
        {

            BindGrid();  // Actualizar la lista después de añadir
        }

        protected void ButtonDeleteCategoria_Click(object sender, EventArgs e)
        {

            BindGrid();  // Actualizar la lista después de eliminar
        }
    } 
}