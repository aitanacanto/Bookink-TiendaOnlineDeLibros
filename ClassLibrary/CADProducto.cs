// @author: Darío Pastor Fuentes    ; DNI: DNI000004
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Reflection.Emit;

namespace ClassLibrary
{
    class CADProducto
    {
        private string constring;
        private bool Exists(SqlConnection c, ENProducto en)
        {
            string querryAux = "Select * from Products where id = @id";
            SqlCommand comAux = new SqlCommand(querryAux, c);
            comAux.Parameters.AddWithValue("@id", en.Id);
            SqlDataReader dr = comAux.ExecuteReader();
            bool existe = dr.Read();
            dr.Close();
            return existe;
        }

        public CADProducto()
        {
            constring = ConfigurationManager.ConnectionStrings["database"].ToString();
        }

        public bool Create(ENProducto en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                string query = "INSERT INTO Products (nombre, cant_stock, precio, precio_oferta, img_producto, sinopsis, Autor, Cod_Ofer, Editorial, Anyo_Publicacion, Num_Pags) VALUES (@Name, @Stock, @Price, @SalePrice, @ImagePath, @Sinopsis, @Autor, @CodOfer, @Editorial, @AnyoPubli, @NumPags)";
                SqlCommand com = new SqlCommand(query, c);

                com.Parameters.AddWithValue("@Name", en.Name);
                com.Parameters.AddWithValue("@Stock", en.Stock);
                com.Parameters.AddWithValue("@Price", en.Price);
                com.Parameters.AddWithValue("@SalePrice", en.SalePrice);
                com.Parameters.AddWithValue("@ImagePath", en.ImagePath);
                com.Parameters.AddWithValue("@Sinopsis", en.Sinopsis);
                com.Parameters.AddWithValue("@Autor", en.Autor);
                com.Parameters.AddWithValue("@CodOfer", en.CodOfer);
                com.Parameters.AddWithValue("@Editorial", en.Editorial);
                com.Parameters.AddWithValue("@AnyoPubli", en.AnyoPubli);
                com.Parameters.AddWithValue("@NumPags", en.NumPags);

                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido añadir el producto, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool Update(ENProducto en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                string query = "UPDATE Products set Name = @name, Stock = @Stock, Price = @Price, SalePrice = @SalePrice, Category = @Category, CreationDate = @CreationDate, Sinopsis = @Sinopsis, Autor = @Autor";
                SqlCommand com = new SqlCommand(query, c);

                com.Parameters.AddWithValue("@Name", en.Name);
                com.Parameters.AddWithValue("@Stock", en.Stock);
                com.Parameters.AddWithValue("@Price", en.Price);
                com.Parameters.AddWithValue("@SalePrice", en.SalePrice);
                com.Parameters.AddWithValue("@Category", en.Category);
                com.Parameters.AddWithValue("@CreationDate", en.CreationDate);
                com.Parameters.AddWithValue("@Sinopsis", en.Sinopsis);
                com.Parameters.AddWithValue("@Autor", en.Autor);

                com.ExecuteNonQuery();
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido actualizar el producto, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool Delete(ENProducto en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                if (!this.Exists(c, en)){throw new ArgumentException("El producto no existe"); }
                string query = "Delete from Products where Id = @Id";
                SqlCommand com = new SqlCommand(query, c);
                com.Parameters.AddWithValue("@Id", en.Id);

                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido borrar el producto, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool Read(ENProducto en)
        {
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                string query = "Select * from Products where Id = @Id";
                SqlCommand com = new SqlCommand(query, c);
                com.Parameters.AddWithValue("@Id", en.Id);

                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                en.Name = dr["Name"].ToString();
                en.Price = float.Parse(dr["Price"].ToString());
                en.Stock = int.Parse(dr["Stock"].ToString());
                en.SalePrice = float.Parse(dr["SalePrice"].ToString());
                en.Category = Convert.ToInt32(dr["Category"]);
                en.CreationDate = DateTime.Parse(dr["CreationDate"].ToString());
                en.Sinopsis = dr["Sinopsis"].ToString();
                en.Autor = dr["Autor"].ToString();

                dr.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido leer el producto, ERROR: {0}", ex.Message);
                throw;
            }
            finally
            {
                c.Close();
            }
        }


    }
}
