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
    public class CADPaquete
    {
        private string constring;

        public CADPaquete(){
            constring = ConfigurationManager.ConnectionStrings["miconstring"].ToString();
        }

        public bool CrearPaquete(ENPaquete en)
        {
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();

                string comandoSQL = $"INSERT INTO Paquete (nombre, precio) VALUES (@nombre, @precio)";

                SqlCommand cmd = new SqlCommand(comandoSQL, conex);
                cmd.Parameters.AddWithValue("@name", en.Nombre);
                cmd.Parameters.AddWithValue("@code", en.Precio);
                cmd.ExecuteNonQuery();

                for (int i = 1; i < en.Productos.Count; i++){

                }

                    return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", e.Message);
                return false;
            }
            finally
            {
                conex.Close();
            }
        }

        public bool AgregarProductoAlPaquete(ENPaquete paquete)
        {
            return false;
        }

        public ENPaquete ObtenerPaquetePorId(ENPaquete paquete)
        { 
            return paquete;
        }

        public bool anyadirPaquete(ENPaquete paquete)
        {
            return true;
        }

        public bool GuardarPaquete(ENPaquete paquete)
        {
            return false;
        }

        
        public bool ActualizarPaquete(ENPaquete paquete)
        {
            return false;
        }

      
        public bool EliminarPaquete(ENPaquete paquete)
        {
            return false;
        }

        
        public bool EliminarProductoDelPaquete(int idPaquete, int idProducto)
        {
            return false;
        }
    }
}
