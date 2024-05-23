using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibrary
{
    class CADLinCarrito
    {

        private string constring;

        public CADLinCarrito()
        {
            this.constring = ConfigurationManager.ConnectionStrings["database"].ToString();
        }




        public bool existeEnCarrito(ENLinCarrito linea)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                string querryAux = "Select * from LINCARRITO where id_carrito = @id_carrito and id_producto = @id_producto";
                SqlCommand comAux = new SqlCommand(querryAux, c);
                comAux.Parameters.AddWithValue("@id_carrito", linea.id_carrito);
                comAux.Parameters.AddWithValue("@id_producto", linea.producto.Id);
                SqlDataReader dr = comAux.ExecuteReader();
                bool existe = dr.Read();
                dr.Close();

                return existe;
            }
            catch (SqlException e)
            {

                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                return false;
            }
            catch (Exception e)
            {

                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                if (c != null) c.Close();
            }
        }
        public bool eliminarLinea(ENLinCarrito linea)
        {
            SqlConnection c = new SqlConnection(constring);


            try
            {
                c.Open();


                string query = "DELETE FROM LINCARRITO where id_carrito =" + linea.id_carrito + "and id_producto =" + linea.producto.Id;


                SqlCommand com = new SqlCommand(query, c);


                com.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {

                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                return false;
            }
            catch (Exception e)
            {

                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                if (c != null) c.Close();
            }
        }

        public bool actualizarLinea(ENLinCarrito linea)
        {
            bool validar = false;
            DataSet dat = new DataSet();
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                // Crear una sentencia parametricada
                string query = "UPDATE LINCARRITO SET cantidad = @cantidad, pvp = @pvp where id_carrito = @id_carrito and id_producto = @id_producto";
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@cantidad", linea.cantidad);
                com.Parameters.AddWithValue("@pvp", linea.pvp);
                com.Parameters.AddWithValue("@id_carrito", linea.id_carrito);
                com.Parameters.AddWithValue("@id_producto", linea.producto.Id);

                com.ExecuteNonQuery();

                validar = true;
            }
            catch (SqlException er)
            {
                validar = false;
                Console.WriteLine("User operation has failed. Error: {0}", er.Message);
            }
            catch (Exception er)
            {
                validar = false;
                Console.WriteLine("User operation has failed. Error: {0}", er.Message);
            }
            finally
            {
                if (c != null) c.Close();
            }
            return validar;
        }

        public bool actualizarCantidadLinea(ENLinCarrito linea)
        {
            bool validar = false;
            DataSet dat = new DataSet();
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                // Crear una sentencia parametricada
                string query = "UPDATE LINCARRITO SET cantidad = @cantidad + cantidad, pvp = @pvp where id_carrito = @id_carrito and id_producto = @id_producto";
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@cantidad", linea.cantidad);
                com.Parameters.AddWithValue("@pvp", linea.pvp);
                com.Parameters.AddWithValue("@id_carrito", linea.id_carrito);
                com.Parameters.AddWithValue("@id_producto", linea.producto.Id);

                com.ExecuteNonQuery();

                validar = true;
            }
            catch (SqlException er)
            {
                validar = false;
                Console.WriteLine("User operation has failed. Error: {0}", er.Message);
            }
            catch (Exception er)
            {
                validar = false;
                Console.WriteLine("User operation has failed. Error: {0}", er.Message);
            }
            finally
            {
                if (c != null) c.Close();
            }
            return validar;
        }

        public List<ENLinCarrito> cargarLineasCarrito(int id)
        {
            List<ENLinCarrito> lista = new List<ENLinCarrito>();
            SqlConnection cone = null;

            try
            {
                cone = new SqlConnection(constring);
                cone.Open();
                SqlCommand coma = new SqlCommand("Select * from LINCARRITO where id_carrito=" + id, cone);
                SqlDataReader lee = coma.ExecuteReader();
                while (lee.Read())
                {
                    ENProducto producto = new ENProducto(int.Parse(lee["id_producto"].ToString()));
                    producto.Read();
                    int cantidad = int.Parse(lee["cantidad"].ToString());
                    ENLinCarrito linea = new ENLinCarrito(id, producto, cantidad);
                    lista.Add(linea);
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

        public bool insertarLinea(ENLinCarrito linea)
        {
            bool validar = false;
            DataSet dat = new DataSet();
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                // Crear una sentencia parametricada
                string query = "INSERT INTO LINCARRITO (id_carrito, id_producto, cantidad, pvp) " +
                               "VALUES (@id_carrito, @id_producto, @cantidad, @pvp)";
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@id_carrito", linea.id_carrito);
                com.Parameters.AddWithValue("@id_producto", linea.producto.Id);
                com.Parameters.AddWithValue("@cantidad", linea.cantidad);
                com.Parameters.AddWithValue("@pvp", linea.pvp);

                com.ExecuteNonQuery();

                validar = true;
            }
            catch (SqlException er)
            {
                validar = false;
                Console.WriteLine("User operation has failed. Error: {0}", er.Message);
            }
            catch (Exception er)
            {
                validar = false;
                Console.WriteLine("User operation has failed. Error: {0}", er.Message);
            }
            finally
            {
                if (c != null) c.Close();
            }
            return validar;
        }
    }
}