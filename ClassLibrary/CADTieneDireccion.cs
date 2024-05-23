using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CADTieneDireccion
    {
        private string constring;

        public CADTieneDireccion()
        {
            constring = ConfigurationManager.ConnectionStrings["database"].ToString();
        }

        public bool AgregarRelacion(ENTieneDireccion tiene)
        {
            using (SqlConnection c = new SqlConnection(constring))
            {
                try
                {
                    c.Open();
                    using (SqlCommand com = new SqlCommand("INSERT INTO TIENE_DIRECCION (id_usuario, id_direccion) VALUES (@id_usuario, @id_direccion)", c))
                    {
                        com.Parameters.AddWithValue("@id_usuario", tiene.IdUsuario);
                        com.Parameters.AddWithValue("@id_direccion", tiene.IdDireccion);

                        com.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se ha podido añadir la relación, ERROR: {0}", ex.Message);
                    return false;
                }
                finally
                {
                    c.Close();
                }
            }
        }

        public int ObtenerDireccionId(ENTieneDireccion tiene)
        {
            using (SqlConnection c = new SqlConnection(constring))
            {
                try
                {
                    c.Open();
                    using (SqlCommand com = new SqlCommand("SELECT id_direccion FROM TIENE_DIRECCION WHERE id_usuario = @id_usuario", c))
                    {
                        com.Parameters.AddWithValue("@id_usuario", tiene.IdUsuario);

                        SqlDataReader reader = com.ExecuteReader();
                        if (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                        return -1; // No se encontró la dirección
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se ha podido obtener el ID de la dirección, ERROR: {0}", ex.Message);
                    return -1;
                }
                finally
                {
                    c.Close();
                }
            }
        }
    }
}
