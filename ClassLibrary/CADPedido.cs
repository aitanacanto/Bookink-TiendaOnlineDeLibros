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
                ENCarrito c = new ENCarrito(); 
                c.id = pedido.Cod_carrito;

                if (c.readCarrito())
                {
                    conex.Open();

                    string comandoSQL = $"INSERT INTO PEDIDO (numped, id_usuario, cod_carrito, dirección_envío, precio, estado) VALUES (@numped, @id_usuario, @cod_carrito, @dirección_envío, @precio, @estado)";

                    SqlCommand cmd = new SqlCommand(comandoSQL, conex);
                    cmd.Parameters.AddWithValue("@id_usuario", c.id_usuario);
                    cmd.Parameters.AddWithValue("@cod_carrito", pedido.Cod_carrito);
                    cmd.Parameters.AddWithValue("@dirección_envío", pedido.Direccion_envio);
                    cmd.Parameters.AddWithValue("@precio", c.importe_total);
                    cmd.Parameters.AddWithValue("@estado", pedido.Estado);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                else
                {
                    return false;
                }
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

        public DataSet verPedidos(ENPedido pedido)
        {
            DataSet dat = new DataSet();
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();
                string comandoSQL = $"SELECT numped, id_usuario, cod_carrito, dirección_envío, precio, estado FROM pedido WHERE id_usuario =" + pedido.Id_usuario;
                SqlDataAdapter adap = new SqlDataAdapter(comandoSQL, conex);

                adap.Fill(dat, "PEDIDOS");
                return dat;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", e.Message);
                return dat;
            }
            catch (Exception e)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", e.Message);
                return dat;
            }
            finally
            {
                if (conex != null)
                {
                    conex.Close();
                }
            }
        }
    }
}
