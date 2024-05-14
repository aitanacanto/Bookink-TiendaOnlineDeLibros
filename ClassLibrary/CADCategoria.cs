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
    
}
public class CADCategoria
{
    private string conString = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;

    public List<ENCategoria> GetAllCategories()
    {
        List<ENCategoria> categories = new List<ENCategoria>();
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
        return categories;
    }

    public bool AddCategory(string nombre)
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

    public bool DeleteCategory(int categoryId)
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
}
}




