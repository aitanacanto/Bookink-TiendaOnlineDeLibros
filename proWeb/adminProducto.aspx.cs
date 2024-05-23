using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ClassLibrary;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;
namespace proWeb
{
    public partial class adminProducto : System.Web.UI.Page
    {
        private static List<ENProducto> listaProductos = new List<ENProducto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listar_cat();
                listaProductos = ObtenerProductos();
                BindRepeater();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtName.Text) ||
                string.IsNullOrWhiteSpace(txt_stock.Text) ||
                string.IsNullOrWhiteSpace(TxtPrice.Text) ||
                string.IsNullOrWhiteSpace(TxtSalePrice.Text) ||
                string.IsNullOrWhiteSpace(Txt_sinopsis.Text) ||
                string.IsNullOrWhiteSpace(txt_Autor.Text) ||
                string.IsNullOrWhiteSpace(txt_editorial.Text) ||
                string.IsNullOrWhiteSpace(txt_anyo.Text) ||
                string.IsNullOrWhiteSpace(TxtNumPag.Text) ||
                ImagenSubida.PostedFile == null ||
                ImagenSubida.PostedFile.FileName == "" ||
                string.IsNullOrWhiteSpace(listacat.SelectedValue))
                {
                    lblError.Text = "Todos los campos son obligatorios.";
                    lblError.Visible = true;
                    return;
                }

                string name = TxtName.Text;
                int stock = int.Parse(txt_stock.Text);
                float price = float.Parse(TxtPrice.Text, CultureInfo.InvariantCulture);
                float saleprice = float.Parse(TxtSalePrice.Text, CultureInfo.InvariantCulture);
                string sinopsis = Txt_sinopsis.Text;
                string autor = txt_Autor.Text;
                string codOfer = "OF001";
                string editorial = txt_editorial.Text;
                int anyo = int.Parse(txt_anyo.Text);
                int numpag = int.Parse(TxtNumPag.Text);
                string fileName = Path.GetFileName(ImagenSubida.PostedFile.FileName);
                
                string extension = Path.GetExtension(ImagenSubida.PostedFile.FileName);
                string filePath = "/content/products/" + name+DateTime.Now.ToString("dd-MM-yy-HH-mm-ss") +extension;
                

                ENProducto newProduct = new ENProducto(name, stock, price, saleprice, filePath, sinopsis, autor, codOfer, editorial, anyo, numpag);
                newProduct.Create();
                ImagenSubida.SaveAs(Server.MapPath(filePath));

                int categoriaId = int.Parse(listacat.SelectedValue);
                ENTieneCategoria cat = new ENTieneCategoria(categoriaId, newProduct.Id);
                cat.AddRelation();


                listaProductos = ObtenerProductos();
                BindRepeater();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido añadir el producto, ERROR: {0}", ex.Message);
                return;

            }
            
        }
        private void BindRepeater()
        {
            reapeterProduct.DataSource = listaProductos;
            reapeterProduct.DataBind();
        }
        private List<ENProducto> ObtenerProductos()
            {
            ENProducto en = new ENProducto();
            List<ENProducto> listaProductos = new List<ENProducto>();
            listaProductos = en.ObtenerTodosLosProductos();
            reapeterProduct.DataSource = listaProductos;
            reapeterProduct.DataBind();

            return listaProductos;
        }

        protected void btnAdd_Click1(object sender, EventArgs e)
        {

            
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btnEdit = (LinkButton)sender;
            int id = Convert.ToInt32(btnEdit.CommandArgument);
            ENProducto prod = new ENProducto();
            prod.Id = id;
            

            if (prod.Read())
            {
                Name.Text = prod.Name;
                NumPags.Text = prod.NumPags.ToString();
                Cantidad.Text = prod.Stock.ToString();
                Autor.Text = prod.Autor;
                Precio.Text = prod.Price.ToString("0.00", CultureInfo.InvariantCulture);
                Oferta.Text = prod.SalePrice.ToString("0.00", CultureInfo.InvariantCulture);
                Editorial.Text = prod.Editorial;
                Publi.Text = prod.AnyoPubli.ToString();
                Sinopsis.Text = prod.Sinopsis;
                ids.Text = prod.Id.ToString();
                List<ENTieneCategoria> relaciones = ENTieneCategoria.GetRelationsByProduct(prod.Id);
                if (relaciones.Count > 0)
                {
                    int categoriaId = relaciones[0].IdCategoria;
                    listacat2.SelectedValue = categoriaId.ToString();
                }
                else
                {
                    listacat2.SelectedValue = "0";
                }

            }


            string script = @"<script type='text/javascript'>
                        $(document).ready(function () {
                            $('#editmodal').modal('toggle');
                        });
                      </script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowModal", script);

        }

        protected void btnEdit_Click1(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(Name.Text) ||
                string.IsNullOrWhiteSpace(Cantidad.Text) ||
                string.IsNullOrWhiteSpace(Precio.Text) ||
                string.IsNullOrWhiteSpace(Oferta.Text) ||
                string.IsNullOrWhiteSpace(Sinopsis.Text) ||
                string.IsNullOrWhiteSpace(Autor.Text) ||
                string.IsNullOrWhiteSpace(Editorial.Text) ||
                string.IsNullOrWhiteSpace(Publi.Text) ||
                string.IsNullOrWhiteSpace(NumPags.Text) || 
                string.IsNullOrWhiteSpace(listacat2.SelectedValue))

                {
                    lblError.Text = "Todos los campos son obligatorios.";
                    lblError.Visible = true;
                    return;
                }
                ENProducto prod = new ENProducto();
                int categoriaId = 0;
                List<ENTieneCategoria> relaciones = ENTieneCategoria.GetRelationsByProduct(int.Parse(ids.Text));
                if (relaciones.Count > 0)
                {
                    categoriaId = relaciones[0].IdCategoria;
                }
                
                prod.Id = int.Parse(ids.Text);
                prod.Read();
                prod.Name = Name.Text;
                prod.NumPags = int.Parse(NumPags.Text);
                prod.Stock = int.Parse(Cantidad.Text);
                prod.Price = float.Parse(Precio.Text, CultureInfo.InvariantCulture);
                prod.SalePrice = float.Parse(Oferta.Text, CultureInfo.InvariantCulture);
                prod.Sinopsis = Sinopsis.Text;
                prod.Autor = Autor.Text;
                prod.Editorial = Editorial.Text;
                prod.AnyoPubli = int.Parse(Publi.Text);
                string fileName = Path.GetFileName(Imagen.PostedFile.FileName);


                if (fileName != "")
                {
                    string filePath = "/content/products/" + fileName;
                    Imagen.SaveAs(Server.MapPath(filePath));
                    prod.ImagePath = filePath;
                }
                int caId = int.Parse(listacat2.SelectedValue);
                if (categoriaId != 0)
                {
                    ENTieneCategoria cat = new ENTieneCategoria(categoriaId, prod.Id);


                    

                    cat.UpdateRelation(caId);
                }
                else
                {
                    ENTieneCategoria cat = new ENTieneCategoria(caId, prod.Id);
                    cat.AddRelation();
                }
                

                prod.Update();
                listaProductos = ObtenerProductos();
                BindRepeater();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido editar el producto, ERROR: {0}", ex.Message);
                return;

            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            LinkButton btnEdit = (LinkButton)sender;
            int id = Convert.ToInt32(btnEdit.CommandArgument);
            ENProducto prod = new ENProducto();
            prod.Id = id;
            Session["idvalue"] = prod.Id;

            if (prod.Read())
            {
                idel.Text = "¿Quieres eliminar el producto con ID: " +  prod.Id.ToString() + "?\n" ;


            }


            string script = @"<script type='text/javascript'>
                        $(document).ready(function () {
                            $('#deleteModal').modal('toggle');
                        });
                      </script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowModal", script);
        }

        protected void listar_cat()
        {
            listacat.Items.Clear();
            listacat.Items.Add(new ListItem("Selecciona una categoría", "0"));
            listacat2.Items.Clear();
            listacat2.Items.Add(new ListItem("Selecciona una categoría", "0"));
            ENCategoria enCat = new ENCategoria();
            List<ENCategoria> categories = enCat.GetAllCategories();

            foreach (ENCategoria categoria in categories)
            {
                listacat.Items.Add(new ListItem(categoria.Nombre, categoria.Id.ToString()));
                listacat2.Items.Add(new ListItem(categoria.Nombre, categoria.Id.ToString()));
            }
        }

        protected void delete_click(object sender, EventArgs e)
        {
            try
            {

                int id = (int)Session["idvalue"];
                ENProducto prod = new ENProducto();
                prod.Id = id;
                prod.Read();


                prod.Delete();
                listaProductos = ObtenerProductos();
                BindRepeater();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido borrar el producto, ERROR: {0}", ex.Message);
                return;

            }
        }
        protected string TruncateText(string text, int length)
        {
            if (text.Length <= length)
            {
                return text;
            }
            else
            {
                return text.Substring(0, length) + "...";
            }
        }
    };

}