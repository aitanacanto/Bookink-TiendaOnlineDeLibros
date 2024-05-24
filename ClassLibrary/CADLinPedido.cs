// @author: Darío Pastor Fuentes    ; DNI: DNI000004
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ClassLibrary
{
    class CADLinPedido
    {
        private string constring;


        public CADLinPedido()
        {
            constring = ConfigurationManager.ConnectionStrings["database"].ToString();
        }
        private bool Exists(SqlConnection c, ENLinPedido en)
        {
            string querryAux = "Select * from LINPEDIDO where id_pedido = @idpedido and id_producto = @id_producto";
            SqlCommand comAux = new SqlCommand(querryAux, c);
            comAux.Parameters.AddWithValue("@idpedido", en.Id_Pedido);
            comAux.Parameters.AddWithValue("@id_producto", en.Id_Producto);
            SqlDataReader dr = comAux.ExecuteReader();
            bool existe = dr.Read();
            dr.Close();
            return existe;
        }
        public bool create(ENLinPedido en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                string query = "INSERT INTO LINPEDIDO (id_pedido, id_producto, cantidad) VALUES (@Pedido, @Producto, @Cantidad)";
                SqlCommand com = new SqlCommand(query, c);

                com.Parameters.AddWithValue("@Pedido", en.Id_Pedido);
                com.Parameters.AddWithValue("@Producto", en.Id_Producto);
                com.Parameters.AddWithValue("@Cantidad", en.Cantidad);
                com.ExecuteNonQuery();
                return true;
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

        public bool update(ENLinPedido en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                string query = "UPDATE LINPEDIDO set id_pedido = @Pedido, id_producto = @Producto, cantidad = @Cantidad)";
                SqlCommand com = new SqlCommand(query, c);

                com.Parameters.AddWithValue("@Pedido", en.Id_Pedido);
                com.Parameters.AddWithValue("@Producto", en.Id_Producto);
                com.Parameters.AddWithValue("@Cantidad", en.Cantidad);
                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido actualizar la relación, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool read(ENLinPedido en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                string query = "Select * from LINPEDIDO where  id_pedido = @idpedido and id_producto = @id_producto";
                SqlCommand com = new SqlCommand(query, c);
                com.Parameters.AddWithValue("@idpedido", en.Id_Pedido);
                com.Parameters.AddWithValue("@id_producto", en.Id_Producto);

                SqlDataReader dr = com.ExecuteReader();
                while(dr.Read());
                en.Id_Pedido = int.Parse(dr["id_pedido"].ToString());
                en.Id_Producto = int.Parse(dr["id_producto"].ToString());
                en.Cantidad = int.Parse(dr["cantidad"].ToString());

                dr.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido leer la relación, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public List<ENLinPedido> readALL(ENLinPedido en)
        {
            List<ENLinPedido> lista = new List<ENLinPedido>();
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                string query = "Select * from LINPEDIDO where  id_pedido = @idpedido";
                SqlCommand com = new SqlCommand(query, c);
                com.Parameters.AddWithValue("@idpedido", en.Id_Pedido);

                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    ENLinPedido newLp = new ENLinPedido();
                    newLp.Id_Pedido = int.Parse(dr["id_pedido"].ToString());
                    newLp.Id_Producto = int.Parse(dr["id_producto"].ToString());
                    newLp.Cantidad = int.Parse(dr["cantidad"].ToString());

                    lista.Add(en);
                }

                dr.Close();
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido leer la relación, ERROR: {0}", ex.Message);
                return lista;
            }
            finally
            {
                c.Close();
            }
        }

        public bool delete(ENLinPedido en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                if (!this.Exists(c, en)) { throw new ArgumentException("El producto no existe"); }
                string query = "Delete from LINPEDIDO where id_pedido = @idpedido and id_producto = @id_producto";
                SqlCommand com = new SqlCommand(query, c);
                com.Parameters.AddWithValue("@idpedido", en.Id_Pedido);
                com.Parameters.AddWithValue("@id_producto", en.Id_Producto);

                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido borrar la relación, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }
    }
}
