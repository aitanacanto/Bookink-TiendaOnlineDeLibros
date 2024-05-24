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
    public partial class adminPaquete : System.Web.UI.Page
    {
        private static List<ENPaquete> listaPaquetes = new List<ENPaquete>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaPaquetes = CargarPaquetes();
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            repeaterPackage.DataSource = listaPaquetes;
            repeaterPackage.DataBind();
        }

        // Método para cargar la lista de paquetes
        private List<ENPaquete> CargarPaquetes()
        {
            ENPaquete en = new ENPaquete();
            listaPaquetes = en.ObtenerTodosLosPaquetes();

            return listaPaquetes;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtName.Text) ||
                    string.IsNullOrWhiteSpace(TextBox1.Text) ||
                    string.IsNullOrWhiteSpace(TextBox2.Text) ||
                    FileUpload1.PostedFile == null ||
                    FileUpload1.PostedFile.FileName == "")
                {
                    lblError.Text = "Todos los campos son obligatorios.";
                    lblError.Visible = true;
                    return;
                }

                string name = TxtName.Text;
                float price = float.Parse(TextBox1.Text, CultureInfo.InvariantCulture);
                string descripcion = TextBox2.Text;
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string filePath = "/content/products/" + name + DateTime.Now.ToString("dd-MM-yy-HH-mm-ss") + extension;

                ENPaquete newPa = new ENPaquete(name, price, descripcion, filePath, null);
                newPa.CrearPaquete();
                FileUpload1.SaveAs(Server.MapPath(filePath));
                listaPaquetes = CargarPaquetes();
                BindRepeater();

            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido añadir el paquete, ERROR: {0}", ex.Message);
                return;

            }
        }


        protected void btnAdd_Click1(object sender, EventArgs e){}

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btnEdit = (LinkButton)sender;
            int idPaquete = Convert.ToInt32(btnEdit.CommandArgument);
            ENPaquete pa = new ENPaquete();
            pa.IdPaquete = idPaquete;
            

            if (pa.leerPaquete())
            {
                ids.Text = pa.IdPaquete.ToString();
                TextBox3.Text = pa.Nombre;
                TextBox4.Text = pa.Precio.ToString("0.00", CultureInfo.InvariantCulture);
                TextBox5.Text = pa.Descripcion;
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
                if (string.IsNullOrWhiteSpace(TextBox3.Text) ||
                    string.IsNullOrWhiteSpace(TextBox4.Text) ||
                    string.IsNullOrWhiteSpace(TextBox5.Text) )
                {
                    lblError.Text = "Todos los campos son obligatorios.";
                    lblError.Visible = true;
                    return;
                }
                ENPaquete pa = new ENPaquete();
                pa.IdPaquete = int.Parse(ids.Text);
                pa.leerPaquete();
                pa.Nombre = TextBox3.Text;
                pa.Precio = float.Parse(TextBox4.Text, CultureInfo.InvariantCulture);
                pa.Descripcion = TextBox5.Text;

                string fileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                

                if (fileName != "")
                {
                    string filePath = "/content/products/" + fileName;
                    FileUpload2.SaveAs(Server.MapPath(filePath));
                    pa.Img_paquete = filePath;
                }

                pa.ActualizarPaquete();
                listaPaquetes = CargarPaquetes();
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
            int idPaquete = Convert.ToInt32(btnEdit.CommandArgument);
            ENPaquete pa = new ENPaquete();
            pa.IdPaquete = idPaquete;
            Session["idvalue"] = pa.IdPaquete;

            if (pa.leerPaquete())
            {
                idel.Text = "¿Quieres eliminar el paquete con ID: " + pa.IdPaquete.ToString() + "?\n";


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
                ENPaquete pa = new ENPaquete();
                pa.IdPaquete = id;
                pa.leerPaquete();


                pa.EliminarPaquete();
                listaPaquetes = CargarPaquetes();
                BindRepeater();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido borrar el paquete, ERROR: {0}", ex.Message);
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

    }
}