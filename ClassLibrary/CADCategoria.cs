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
    class CADCategoria
    {
        private string conString; //String para conectarse a la bbdd
        public CADCategoria()
        {
            conString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        }

        public List<ENCategoria> ObtenerCategoria()
        {
            List<ENCategoria> CategoryList = new List<ENCategoria>();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT id, nombre FROM CATEGORIA", connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ENCategoria categoria = new ENCategoria
                    {
                        Id = Convert.ToInt32(reader["id"]), //String to Int
                        Nombre = reader["name"].ToString()

                    };
                    CategoryList.Add(categoria);
                }
                reader.Close();
            }
            return CategoryList;
         }

        public bool AddCategory(ENCategoria categoria)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO CATEGORIA (nombre) VALUES (@nombre)", connection);
                cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al añadir categoría: " + ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateCategory(ENCategoria Categoria)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE CATEGORIA SET nombre = @nombre WHERE id = @id", connection);
                cmd.Parameters.AddWithValue("@id", Categoria.Id);
                cmd.Parameters.AddWithValue("@nombre", Categoria.Nombre);

                try
                {
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar categoría: " + ex.Message);
                    return false;
                }
            }
        }
        public bool DeleteCategory(ENCategoria Categoria)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM CATEGORIA WHERE id = @id", connection);
                cmd.Parameters.AddWithValue("@id", Categoria.Id);

                try
                {
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar categoría: " + ex.Message);
                    return false;
                }
            }
        }



    }

}
