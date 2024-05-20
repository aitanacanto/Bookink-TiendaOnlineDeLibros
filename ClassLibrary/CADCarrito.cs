using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;



namespace ClassLibrary
{
    public class CADCarrito
    {
        private string constring;

        public CADCarrito()
        {
            this.constring = ConfigurationManager.ConnectionStrings["database"].ToString();
        }

        public bool creacionCarrito(ENCarrito carr)
        {
            bool validar = false;
            DataSet dat = new DataSet();
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                // Crear una sentencia parametricada
                string query = "INSERT INTO CARRITO (id_usuario, pvp_total) " +
                               "VALUES (@id_usuario, @importe_total)";
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@id_usuario", carr.id_usuario);
                com.Parameters.AddWithValue("@importe_total", carr.importe_total);
                
                com.ExecuteNonQuery();
                int id_carrito = buscarIdCarrito(carr.id_usuario);
                carr.id = id_carrito;
                

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

        public void cargarCarrito(ENCarrito carr)
        {
            SqlConnection c = new SqlConnection(constring);
            DataSet dat = new DataSet();
            
            try
            {
                SqlDataAdapter adap = new SqlDataAdapter("select * from CARRITO where id='" + carr.id + "'", c);
                adap.Fill(dat, "CARRITO");
                DataTable tabla = new DataTable();
                tabla = dat.Tables["CARRITO"];
                if (tabla.Rows.Count > 0)
                {
                    carr.id_usuario = int.Parse(tabla.Rows[0]["id_usuario"].ToString());
                    carr.importe_total = float.Parse(tabla.Rows[0]["pvp_total"].ToString());
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
                if (c != null) c.Close();
            }
            
        }

        public int buscarIdCarrito(int id_usuario)
        {
            SqlConnection c = new SqlConnection(constring);
            DataSet dat = new DataSet();
            int id_carrito = 0;
            try
            {
                SqlDataAdapter adap = new SqlDataAdapter("select * from CARRITO where id_usuario='" + id_usuario + "'" , c);
                adap.Fill(dat, "CARRITO");
                DataTable tabla = new DataTable();
                tabla = dat.Tables["CARRITO"];
                if (tabla.Rows.Count > 0)
                {
                    id_carrito = int.Parse(tabla.Rows[0]["id"].ToString());
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
                if (c != null) c.Close();
            }
            return id_carrito;
        }
        public bool readCarritoUsuario(ENCarrito carr, ENUsuario user)
        {
            bool validar = false;
            DataSet dat = new DataSet();
            SqlConnection cone = new SqlConnection(constring);

            try
            {
                SqlDataAdapter adap = new SqlDataAdapter("select * from CARRITO", cone);
                adap.Fill(dat, "CARRITO");
                DataTable tabla = new DataTable();
                tabla = dat.Tables["CARRITO"];

                for (int j = 0; j < tabla.Rows.Count; j++)
                {
                    DataRow fila = tabla.Rows[j];

                    if (user.Id == int.Parse(fila[1].ToString()))
                    {
                        validar = true;
                        carr.id = int.Parse(fila[0].ToString());
                        carr.importe_total = float.Parse(fila[2].ToString());
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

        public bool actualizacionCarrito(ENCarrito carr)
        {
            bool validar = false;
            SqlConnection cone = new SqlConnection(constring);

            try
            {
                cone.Open();
                String linea = "Update CARRITO set importe_total=" + carr.importe_total + " where id_usuario='" + carr.id_usuario + "'";
                SqlCommand coma = new SqlCommand(linea, cone);
                coma.ExecuteNonQuery();
                validar = true;
                return validar;
            }
            catch (SqlException e)
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                return validar;
            }
            catch (Exception e)
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                return validar;
            }
            finally
            {
                if (cone != null) cone.Close();
            }
        }
        
        public bool readCarrito(ENCarrito carr)
        {
            bool validar = false;
            DataSet dat = new DataSet();
            SqlConnection cone = new SqlConnection(constring);

            try
            {
                SqlDataAdapter adap = new SqlDataAdapter("select * from CARRITO where id='" + carr.id + "'", cone);
                adap.Fill(dat, "CARRITO");
                DataTable tabla = new DataTable();
                tabla = dat.Tables["CARRITO"];
                if (tabla.Rows.Count > 0) {
                    DataRow fila = tabla.Rows[0];
                    validar = true;
                    carr.id_usuario = int.Parse(fila[1].ToString());
                    carr.importe_total = float.Parse(fila[2].ToString());
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
        public bool vaciarCarrito(ENCarrito car)
        {
            bool validar = false;
            SqlConnection cone = null;
            string linea;

            linea = "Delete From LINCARRITO where id_carrito=" + car.id;

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

        public DataSet eliminacionCarrito(ENCarrito carr, int id)
        {
            DataSet dat = new DataSet();
            SqlConnection cone = new SqlConnection(constring);

            try
            {
                String linea = "Select * From CARRITO";
                SqlDataAdapter adap = new SqlDataAdapter(linea, cone);
                adap.Fill(dat, "CARRITO");
                DataTable tabla = new DataTable();
                tabla = dat.Tables["CARRITO"];
                tabla.Rows[id].Delete();
                SqlCommandBuilder builder = new SqlCommandBuilder(adap);
                adap.Update(dat, "CARRITO");
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
        public DataSet listandoCarritos()
        {
            DataSet dat = new DataSet();
            SqlConnection cone = new SqlConnection(constring);

            try
            {
                String linea = "Select * From CARRITO";
                SqlDataAdapter adap = new SqlDataAdapter(linea, cone);
                adap.Fill(dat, "CARRITO");

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
                if (cone != null)
                {
                    cone.Close();
                }
            }
        }
        public DataSet ensenyarCarrito(ENCarrito carr)
        {
            DataSet dat = new DataSet();
            SqlConnection cone = new SqlConnection(constring);

            try
            {
                String linea = "Select * FROM CARRITO WHERE id =" + carr.id;
                SqlDataAdapter adap = new SqlDataAdapter(linea, cone);
                adap.Fill(dat, "CARRITO");

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