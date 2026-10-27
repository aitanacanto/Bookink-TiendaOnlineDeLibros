// @author:RAFAEL CARBALLO LORENZO
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
            constring = ConfigurationManager.ConnectionStrings["database"].ToString(); ;
        }

        public bool crearPedido(ENPedido pedido)
        {
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                    conex.Open();

                    string comandoSQL = $"INSERT INTO PEDIDO (id_usuario, cod_carrito, dirección_envío, precio, estado, fecha) OUTPUT INSERTED.numped VALUES (@id_usuario, @cod_carrito, @dirección_envío, @precio, @estado, @fecha)";

                    SqlCommand cmd = new SqlCommand(comandoSQL, conex);
                    cmd.Parameters.AddWithValue("@id_usuario", pedido.Id_usuario);
                    cmd.Parameters.AddWithValue("@cod_carrito", pedido.Cod_carrito);
                    cmd.Parameters.AddWithValue("@dirección_envío", pedido.Direccion_envio);
                    cmd.Parameters.AddWithValue("@precio", pedido.Precio);
                    cmd.Parameters.AddWithValue("@estado", pedido.Estado);
                    cmd.Parameters.AddWithValue("@fecha", pedido.Date);
                    pedido.Numped = Convert.ToInt32(cmd.ExecuteScalar());

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
            SqlConnection conex = new SqlConnection(constring); ;

            try
            {
                conex.Open();
                SqlCommand cmd = new SqlCommand("Select * from PEDIDO where id_usuario=" + pedido.Id_usuario, conex);
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    ENPedido newped = new ENPedido(int.Parse(leer["numped"].ToString()), int.Parse(leer["id_usuario"].ToString()), int.Parse(leer["cod_carrito"].ToString()), leer["dirección_envío"].ToString(), float.Parse(leer["precio"].ToString()), leer["estado"].ToString(), DateTime.Parse(leer["fecha"].ToString()));
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
                if (conex != null) conex.Close();
            }
            return lista;
        }

        public StringBuilder graficaMetrica(ENPedido pedido)
        {
            var labels = new List<string>();
            var data = new List<int>();
            SqlConnection conex = new SqlConnection(constring); ;

            try
            {
                conex.Open();

                string query = "SELECT FORMAT(Fecha, 'MM/yy') AS Mes, COUNT(*) AS Cantidad " +
                               "FROM PEDIDO " +
                               "GROUP BY FORMAT(Fecha, 'MM/yy') " +
                               "ORDER BY MIN(Fecha)";
                SqlCommand cmd = new SqlCommand(query, conex);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    labels.Add(reader["Mes"].ToString());
                    data.Add(Convert.ToInt32(reader["Cantidad"]));
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
                if (conex != null) conex.Close();
            }

            StringBuilder script = new StringBuilder();
            script.Append("<script>");
            script.Append("window.onload = function() {");
            script.Append("var ctx = document.getElementById('pedidosChart').getContext('2d');");
            script.Append("var pedidosChart = new Chart(ctx, {");
            script.Append("type: 'bar',");
            script.Append("data: {");
            script.Append("labels: [" + string.Join(",", labels.ConvertAll(l => "'" + l + "'")) + "],");
            script.Append("datasets: [{");
            script.Append("label: 'Cantidad de Pedidos',");
            script.Append("data: [" + string.Join(",", data) + "],");
            script.Append("backgroundColor: 'rgba(54, 162, 235, 0.2)',");
            script.Append("borderColor: 'rgba(54, 162, 235, 1)',");
            script.Append("borderWidth: 1");
            script.Append("}]");
            script.Append("},");
            script.Append("options: {");
            script.Append("scales: {");
            script.Append("y: {");
            script.Append("beginAtZero: true,");
            script.Append("max: " + (data.Max() + 10));
            script.Append("}");
            script.Append("}");
            script.Append("}");
            script.Append("});");
            script.Append("}");
            script.Append("</script>");

            return script;
        }
    }
}
