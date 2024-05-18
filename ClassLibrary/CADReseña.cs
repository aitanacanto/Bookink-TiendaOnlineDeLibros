// @author: Manuel José Tornero Fuster    ; DNI: DNI000006
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
                com.Parameters.AddWithValue("@rating", en.Rating);

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

        public bool Update(ENReseña reseña)
        {
            return true;
        }

        public bool Delete(ENReseña reseña)
        {
            return true;
        }
    }
}
