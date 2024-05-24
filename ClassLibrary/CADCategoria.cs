// @author:  Alberto Boronat Lopez   ; DNI: DNI000005
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ClassLibrary
{
    public class CADCategoria
    {
        private string conString;
        public CADCategoria()
        {
            conString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
            if (conString == null)
            {
                throw new InvalidOperationException("La cadena de conexión 'database' no está definida en el archivo de configuración.");
            }
        }

        public List<ENCategoria> GetAllCategories()
        {
            List<ENCategoria> categories = new List<ENCategoria>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT id, nombre FROM CATEGORIA", connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        categories.Add(new ENCategoria
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre = reader["nombre"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener todas las categorías: " + ex.Message);
            }
            return categories;
        }

        public List<ENProducto> topVentasPorCategoria(int? id_cat)
        {
            List<ENProducto> productos = new List<ENProducto>();
            SqlConnection connection = null;
            try
            {
                    connection = new SqlConnection(conString);
                
                    SqlCommand cmd = new SqlCommand("SELECT top 8 prod.id FROM LINPEDIDO Lin inner join PRODUCTO prod on Lin.id_producto = prod.Id inner join TIENE_CATEGORIA tc on tc.id_producto = prod.id where tc.id_categoria =" + id_cat + " Group by prod.id order by Sum(lin.cantidad) Desc", connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ENProducto producto = new ENProducto(int.Parse(reader["Id"].ToString()));
                        producto.Read();
                        productos.Add(producto);
                    }
                
            }
            catch (SqlException e)
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            }
            finally
            {
                if (connection != null) connection.Close();
            }


            return productos;
        }

        public bool AddCategory(string nombre)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO CATEGORIA (nombre) VALUES (@nombre)", connection);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al añadir categoría: " + ex.Message);
                return false;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM CATEGORIA WHERE id = @id", connection);
                    cmd.Parameters.AddWithValue("@id", categoryId);
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar categoría: " + ex.Message);
                return false;
            }
        }

        public bool UpdateCategory(int categoryId, string newNombre)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE CATEGORIA SET nombre = @nombre WHERE id = @id", connection);
                    cmd.Parameters.AddWithValue("@nombre", newNombre);
                    cmd.Parameters.AddWithValue("@id", categoryId);
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar categoría: " + ex.Message);
                return false;
            }
        }
    }
}
