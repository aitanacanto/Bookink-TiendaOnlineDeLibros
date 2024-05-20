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
                listaProductos = ObtenerProductos();
                BindRepeater();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
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
                string filePath = "/content/products/" + fileName;
                ImagenSubida.SaveAs(Server.MapPath(filePath));

                ENProducto newProduct = new ENProducto(name, stock, price, saleprice, filePath, sinopsis, autor, codOfer, editorial, anyo, numpag);
                newProduct.Create();
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

                ENProducto prod = new ENProducto();
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