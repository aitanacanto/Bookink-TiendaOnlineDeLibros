// @author:RAFAEL CARBALLO LORENZO; DNI:DNI000002
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ClassLibrary
{
    class CADPedido
    {
        private string constring;

        public CADPedido()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
        }

        public bool crearPedido(ENPedido pedido)
        {
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                    conex.Open();

                    string comandoSQL = $"INSERT INTO PEDIDO (id_usuario, cod_carrito, dirección_envío, precio, estado) VALUES (@id_usuario, @cod_carrito, @dirección_envío, @precio, @estado)";

                    SqlCommand cmd = new SqlCommand(comandoSQL, conex);
                    cmd.Parameters.AddWithValue("@id_usuario", pedido.Id_usuario);
                    cmd.Parameters.AddWithValue("@cod_carrito", pedido.Cod_carrito);
                    cmd.Parameters.AddWithValue("@dirección_envío", pedido.Direccion_envio);
                    cmd.Parameters.AddWithValue("@precio", pedido.Precio);
                    cmd.Parameters.AddWithValue("@estado", pedido.Estado);

                    cmd.ExecuteNonQuery();

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

        public bool cambiarEstado(ENPedido pedido)
        {
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();

                string comandoSQL = $"UPDATE PEDIDO set estado = @estado WHERE numped = @numped";

                SqlCommand cmd = new SqlCommand(comandoSQL, conex);
                cmd.Parameters.AddWithValue("@numped", pedido.Numped);
                cmd.Parameters.AddWithValue("@estado", pedido.Estado);

                cmd.ExecuteNonQuery();

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

        public List<ENPedido> verPedidos(ENPedido pedido)
        {
            List<ENPedido> lista = new List<ENPedido>();
            SqlConnection cone = null;

            try
            {
                cone = new SqlConnection(constring);
                cone.Open();
                SqlCommand coma = new SqlCommand("Select * from PEDIDO where id_usuario=" + pedido.Id_usuario, cone);
                SqlDataReader leer = coma.ExecuteReader();
                while (leer.Read())
                {
                    ENPedido newped = new ENPedido(int.Parse(leer["numped"].ToString()), int.Parse(leer["id_usuario"].ToString()), int.Parse(leer["cod_carrito"].ToString()), leer["dirección_envío"].ToString(), float.Parse(leer["precio"].ToString()), leer["estado"].ToString());
                    lista.Add(newped);
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
                if (cone != null) cone.Close();
            }
            return lista;
        }
    }
}
