// @author: Jorge Paredes Soler; DNI: DNI000007
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class CADTieneDireccion
    {
        private string constring;

        public CADTieneDireccion()
        {
            constring = ConfigurationManager.ConnectionStrings["database"].ToString();

        }

        public bool AgregarRelacion(ENTieneDireccion tiene)
        {
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido añadir la relación, ERROR: {0}", ex.Message);
                return false;
            }
        }
    }
}
