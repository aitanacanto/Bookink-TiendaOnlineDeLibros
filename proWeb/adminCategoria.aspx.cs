using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using System.Linq;

namespace proWeb
{
    public partial class adminCategoria : Page
    {
        private static List<ENCategoria> listaCategorias = new List<ENCategoria>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaCategorias = ObtenerCategorias();
                BindRepeater();
            }
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreCategoria = TextBoxNewCategory.Text.Trim();
                if (!string.IsNullOrEmpty(nombreCategoria))
                {
                    ENCategoria nuevaCategoria = new ENCategoria { Nombre = nombreCategoria };
                    if (nuevaCategoria.Add())
                    {
                        listaCategorias.Add(nuevaCategoria);
                        TextBoxNewCategory.Text = string.Empty; // Clear the input
                        BindRepeater();
                    }
                    else
                    {
                        // Manejar error
                        Response.Write("<script>alert('Error al añadir categoría');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido añadir la categoría, ERROR: {0}", ex.Message);
            }
        }

        protected void repeaterCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int categoriaId = Convert.ToInt32(e.CommandArgument);
            var item = (RepeaterItem)e.Item;
            TextBox textBoxEditCategory = (TextBox)item.FindControl("TextBoxEditCategory");
            Button btnSave = (Button)item.FindControl("btnSave");
            Button btnEdit = (Button)item.FindControl("btnEdit");
            Button btnDelete = (Button)item.FindControl("btnDelete");

            if (e.CommandName == "Delete")
            {
                ENCategoria categoria = new ENCategoria { Id = categoriaId };
                if (categoria.Delete())
                {
                    listaCategorias.RemoveAll(c => c.Id == categoriaId);
                    BindRepeater();
                }
                else
                {
                    // Manejar error
                    Response.Write("<script>alert('Error al eliminar categoría');</script>");
                }
            }
            else if (e.CommandName == "Edit")
            {
                textBoxEditCategory.Visible = true;
                btnSave.Visible = true;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
            else if (e.CommandName == "Save")
            {
                string nuevoNombre = textBoxEditCategory.Text.Trim();
                ENCategoria categoria = new ENCategoria { Id = categoriaId, Nombre = nuevoNombre };
                if (categoria.Update())
                {
                    // Actualiza la lista de categorías con el nuevo nombre
                    var cat = listaCategorias.FirstOrDefault(c => c.Id == categoriaId);
                    if (cat != null)
                    {
                        cat.Nombre = nuevoNombre;
                    }
                    BindRepeater();
                }
                else
                {
                    // Manejar error
                    Response.Write("<script>alert('Error al actualizar categoría');</script>");
                }
            }
        }

        private void BindRepeater()
        {
            repeaterCategory.DataSource = listaCategorias;
            repeaterCategory.DataBind();
        }

        private List<ENCategoria> ObtenerCategorias()
        {
            // Este método debe retornar la lista de categorías desde la base de datos.
            return ENCategoria.GetAllCategories();
        }
    }
}
