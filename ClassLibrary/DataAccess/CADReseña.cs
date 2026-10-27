// @author: Manuel José Tornero Fuster
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CADReseña
    {
        private string constring;
        public CADReseña()
        {
            constring = ConfigurationManager.ConnectionStrings["database"].ToString();
        }
        public bool Create(ENReseña en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                // Crear una sentencia parametricada
                string query = "INSERT INTO RESENA (id_usuario, id_producto, comentario, fecha, valoracion) VALUES (@user, @product, @comment, @date, @rating)";
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@user", en.UserID);
                com.Parameters.AddWithValue("@product", en.ProductID);
                com.Parameters.AddWithValue("@comment", en.Comment);
                com.Parameters.AddWithValue("@date", en.Date);
                com.Parameters.AddWithValue("@rating", (Decimal)en.Rating);

                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido añadir la reseña, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool Update(ENReseña en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                // Crear una sentencia parametricada
                string query = "UPDATE RESENA SET comentario = @comment, fecha = @date, valoracion = @rating " +
                                "WHERE id_usuario = @user AND id_producto = @product";
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@user", en.UserID);
                com.Parameters.AddWithValue("@product", en.ProductID);
                com.Parameters.AddWithValue("@comment", en.Comment);
                com.Parameters.AddWithValue("@date", en.Date);
                com.Parameters.AddWithValue("@rating", (Decimal)en.Rating);

                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido modificar la reseña, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool Delete(ENReseña en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                // Crear una sentencia parametricada
                string query = "DELETE FROM RESENA WHERE id_usuario = @user AND id_producto = @product";
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@user", en.UserID);
                com.Parameters.AddWithValue("@product", en.ProductID);

                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido eliminar la reseña, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool Exists(ENReseña en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                // Crear una sentencia parametricada
                string query = "SELECT * FROM RESENA WHERE id_usuario = @user AND id_producto = @product";
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@user", en.UserID);
                com.Parameters.AddWithValue("@product", en.ProductID);

                SqlDataReader reader = com.ExecuteReader();

                return reader.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido eliminar la reseña, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }
        public List<ENReseña> GetReseñas(int inProductId)
        {
            SqlConnection c = new SqlConnection(constring);
                List<ENReseña> listaProductos = new List<ENReseña>();
            try
            {
                c.Open();

                // Crear una sentencia parametricada
                string query = "SELECT RESENA.*, nombre, apellidos FROM RESENA " +
                                "JOIN USUARIO on(id_usuario = id)" + //para sacar los nombres y apellidos de los usuarios de las reseñas
                                "WHERE id_producto = @product";
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@product", inProductId);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int userId = (int)reader["id_usuario"];
                    int productId = (int)reader["id_producto"];
                    float rating = (float)(decimal)reader["valoracion"];
                    string comment = (string)reader["comentario"];
                    DateTime date = (DateTime)reader["fecha"];
                    string userName = (string)reader["nombre"];
                    string userSurname = (string)reader["apellidos"];

                    ENReseña newRes = new ENReseña(userId, productId, rating, comment, date)
                    {
                        UserName = userName + " " + userSurname,
                    };
                    listaProductos.Add(newRes);
                }

                return listaProductos;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido modificar la reseña, ERROR: {0}", ex.Message);
                return listaProductos;
            }
            finally
            {
                c.Close();
            }
        }
        public float ValoracionMedia(int inProductId)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                // Crear una sentencia parametricada
                string query = "SELECT avg(valoracion) AS Media " +
                                "FROM RESENA " +
                                "WHERE id_producto = @product";
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@product", inProductId);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToSingle(reader["Media"]);
                }
                return 2.5f; //no se han encontrado reseñas de ese producto
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido modificar la reseña, ERROR: {0}", ex.Message);
                return 2.5f;
            }
            finally
            {
                c.Close();
            }
        }
    }
}
