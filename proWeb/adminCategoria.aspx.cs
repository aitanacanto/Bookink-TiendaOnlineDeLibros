using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace proWeb
{
    public partial class adminCategoria : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            GridView1.DataSource = ENCategoria.GetAllCategories();
            GridView1.DataBind();
        }

        protected void ButtonAddCategoria_Click(object sender, EventArgs e)
        {
            string nombreCategoria = ((TextBox)GridView1.FooterRow.FindControl("TextBoxNewCategory")).Text;
            ENCategoria nuevaCategoria = new ENCategoria { Nombre = nombreCategoria };
            if (nuevaCategoria.Add())
            {
                BindGrid();
            }
            else
            {
                // Mostrar mensaje de error
            }
        }

        protected void ButtonDeleteCategoria_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int categoriaId = Convert.ToInt32(btn.CommandArgument);
            ENCategoria categoria = new ENCategoria { Id = categoriaId };
            if (categoria.Delete())
            {
                BindGrid();
            }
            else
            {
                // Mostrar mensaje de error
            }
        }
    }
}
