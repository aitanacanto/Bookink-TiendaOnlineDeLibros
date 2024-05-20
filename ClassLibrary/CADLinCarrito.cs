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

        public bool creacionLinCarrito(ENLinCarrito enli)
        {
            bool validar = false;
            DataSet dat = new DataSet();
            SqlConnection cone = new SqlConnection(constring);

            try
            {
                SqlDataAdapter adap = new SqlDataAdapter("Select * From LINCARRITO", cone);
                adap.Fill(dat, "LINCARRITO");
                DataTable tabla = new DataTable();
                tabla = dat.Tables["LINCARRITO"];
                DataRow fila = tabla.NewRow();
                fila[0] = enli.id_carrito;
                fila[2] = enli.producto.Id;
                fila[3] = enli.cantidad;
                fila[4] = enli.pvp;
                tabla.Rows.Add(fila);

                SqlCommandBuilder builder = new SqlCommandBuilder(adap);
                adap.Update(dat, "LINCARRITO");
                validar = true;
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

            return validar;
        }

        public bool readLinCarrito(ENLinCarrito enli)
        {
            bool validar = false;
            SqlConnection cone = null;

            try
            {
                cone = new SqlConnection(constring);
                cone.Open();
                SqlCommand coma = new SqlCommand("Select * from LINCARRITO", cone);
                SqlDataReader lee = coma.ExecuteReader();
                while (lee.Read())
                {
                    if (lee["id_carrito"].ToString() == enli.id_carrito.ToString())
                    {
                        validar = true;
                        ENProducto producto = new ENProducto(int.Parse(lee["id_producto"].ToString()));
                        producto.Read();
                        enli.producto = producto;
                        enli.cantidad = int.Parse(lee["cantidad"].ToString());
                        enli.pvp = float.Parse(lee["pvp"].ToString());
                    }
                }
            }
            catch (SqlException e)
            {
                validar = false;
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                validar = false;
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            }
            finally
            {
                if (cone != null) cone.Close();
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

        public DataSet actualizacionLinCarrito(ENLinCarrito enli, int mi)
        {
            DataSet dat = new DataSet();
            SqlConnection cone = new SqlConnection(constring);

            try
            {
                String linea = "Select * From LINCARRITO";
                SqlDataAdapter adap = new SqlDataAdapter(linea, cone);
                adap.Fill(dat, "LINCARRITO");
                DataTable tabla = new DataTable();
                tabla = dat.Tables["LINCARRITO"];
                tabla.Rows[mi]["id_producto"] = enli.producto.Id;
                tabla.Rows[mi]["cantidad"] = enli.cantidad;
                tabla.Rows[mi]["pvp"] = enli.pvp;
                SqlCommandBuilder builder = new SqlCommandBuilder(adap);
                adap.Update(dat, "LINCARRITO");
                return dat;
            }
            catch (SqlException e)
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                return dat;
            }
            catch (Exception e)
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                return dat;
            }
            finally
            {
                if (cone != null) cone.Close();
            }
        }
        public bool eliminacionLinCarrito(ENLinCarrito enli)
        {
            bool validar = false;
            SqlConnection cone = null;
            String linea = "Delete From LINCARRITO where id_carrito=" + enli.id_carrito + " and id_producto" + enli.producto.Id;

            try
            {
                cone = new SqlConnection(constring);
                cone.Open();
                SqlCommand coma = new SqlCommand(linea, cone);
                coma.ExecuteNonQuery();
                validar = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                validar = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                validar = false;
            }
            finally
            {
                if (cone != null) cone.Close();
            }

            return validar;
        }

        public DataSet ensenyarLinCarritoByCarrito(ENCarrito car)
        {
            DataSet dat = new DataSet();
            SqlConnection cone = new SqlConnection(constring);

            try
            {
                String linea = "Select * from LINCARRITO where id_carrito=" + car.id;
                SqlDataAdapter adap = new SqlDataAdapter(linea, cone);
                adap.Fill(dat, "LINCARRITO");
                return dat;
            }
            catch (SqlException e)
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                return dat;
            }
            catch (Exception e)
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                return dat;
            }
            finally
            {
                if (cone != null) cone.Close();
            }
        }
    }
}