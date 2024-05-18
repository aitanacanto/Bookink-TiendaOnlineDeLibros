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
                fila[2] = enli.id_producto;
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
                        enli.id_producto = int.Parse(lee["id_producto"].ToString());
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
        public DataSet actualizacionLinCarrito(ENLinCarrito enli, int i)
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
                tabla.Rows[i]["id_producto"] = enli.id_producto;
                tabla.Rows[i]["cantidad"] = enli.cantidad;
                tabla.Rows[i]["pvp"] = enli.pvp;
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
            String linea = "Delete From LINCARRITO where id_carrito=" + enli.id_carrito + " and id_producto" + enli.id_producto;

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