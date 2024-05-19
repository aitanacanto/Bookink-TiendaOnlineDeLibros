// @author: Aitana Cantó Rico;  DNI: DNI000001
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CADTienePaquete
    {
        private string constring;

        public CADTienePaquete()
        {
            constring = ConfigurationManager.ConnectionStrings["database"].ToString();
        }

        public bool AgregarProductoAlPaquete(int idPaquete, int idProducto)
        {
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();
                string comandoSQL = "INSERT INTO TIENE_PAQUETE (id_paquete, id_producto) VALUES (@id_paquete, @id_producto)";
                SqlCommand cmd = new System.Data.SqlClient.SqlCommand(comandoSQL, conex);
                cmd.Parameters.AddWithValue("@id_paquete", idPaquete);
                cmd.Parameters.AddWithValue("@id_producto", idProducto);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Insert product operation has failed. Error: {0}", e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Insert product operation has failed. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                conex.Close();
            }
        }

        public bool EliminarProductoDelPaquete(int idPaquete, int idProducto)
        {
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();
                string comandoSQL = "DELETE FROM TIENE_PAQUETE WHERE id_paquete = @id_paquete AND id_producto = @id_producto";
                SqlCommand cmd = new SqlCommand(comandoSQL, conex);
                cmd.Parameters.AddWithValue("@id_paquete", idPaquete);
                cmd.Parameters.AddWithValue("@id_producto", idProducto);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Delete product operation has failed. Error: {0}", e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete product operation has failed. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                conex.Close();
            }
        }
    }

}
