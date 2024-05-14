using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class CADCarrito
    {
        private string constring;

        public CADCarrito()
        {
            constring = ConfigurationManager.ConnectionStrings["database"].ToString();
        }
        public bool createCarrito(ENCarrito carrito)
        {
            bool creado = false;
            try
            {
                SqlConnection conec = new SqlConnection(constring);
                conec.Open();
                SqlCommand comando = new SqlCommand("insert into [dbo].[CARRITO] (id, id_usuario, lincarrito, cantidad) VALUES(@id, @id_usuario, @lincarrito, @cantidad)", conec);
                comando.Parameters.Add("@id", SqlDbType.Int).Value = carrito.idcarrito;
                comando.Parameters.Add("@id_usuario", SqlDbType.Int).Value = carrito.user;
                comando.Parameters.Add("@lincarrito", SqlDbType.Int).Value = carrito.lincarrito;
                comando.Parameters.Add("@cantidad", SqlDbType.Float).Value = carrito.preciocarrito;
                comando.ExecuteNonQuery();
                creado = true;
                conec.Close();
            }
            catch (SqlException excS)
            {
                Console.WriteLine("User operation has failed. Error: {0}", excS.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine("User operation has failed. Error: {0}", exc.Message);
            }

            return creado;
        }
        public int ObtenerId()
        {
            int i = 1;
            try
            {
                SqlConnection conec = new SqlConnection(constring);
                conec.Open();
                SqlCommand comando = new SqlCommand("Select MAX(id) maximo FROM [dbo].[CARRITO]", conec);
                SqlDataReader encontrar = comando.ExecuteReader();
                encontrar.Read();
                if (encontrar.HasRows)
                {
                    i = int.Parse(encontrar["maximo"].ToString()) + 1;
                }
                encontrar.Close();
                conec.Close();
            }
            catch (SqlException excS)
            {
                Console.WriteLine("User operation has failed. Error: {0}", excS.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine("User operation has failed. Error: {0}", exc.Message);
            }

            return i;
        }
        public bool readCarrito(ENCarrito carrito)
        {
            bool leido = false;

            try
            {
                SqlConnection conec = new SqlConnection(constring);
                conec.Open();
                SqlCommand comando = new SqlCommand("Select * FROM [dbo].[CARRITO] WHERE id_usuario =" + carrito.user + "AND lincarrito =" + carrito.lincarrito, conec);
                SqlDataReader encontrar = comando.ExecuteReader();
                encontrar.Read();

                if (encontrar["lincarrito"].ToString() == carrito.lincarrito.ToString() && encontrar["id_usuario"].ToString() == carrito.user.ToString())
                {
                    carrito.user = int.Parse(encontrar["id_usuario"].ToString());
                    carrito.lincarrito = int.Parse(encontrar["lincarrito"].ToString());
                    carrito.preciocarrito = double.Parse(encontrar["cantidad"].ToString());

                    leido = true;
                }
                encontrar.Close();
                conec.Close();

                return leido;
            }
            catch (SqlException excS)
            {
                Console.WriteLine("User operation has failed. Error: {0}", excS.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine("User operation has failed. Error: {0}", exc.Message);
            }
            return leido;
        }

        public bool updateCarrito(ENCarrito carrito)
        {
            bool leido = false;

            try
            {
                SqlConnection conec = new SqlConnection(constring);
                conec.Open();
                SqlCommand comando = new SqlCommand("Select * FROM [dbo].[CARRITO] WHERE id_usuario =" + carrito.user + "AND lincarrito =" + carrito.lincarrito, conec);
                SqlDataReader encontrar = comando.ExecuteReader();
                encontrar.Read();

                if (encontrar["lincarrito"].ToString() == carrito.lincarrito.ToString() && encontrar["id_usuario"].ToString() == carrito.user.ToString())
                {
                    carrito.user = int.Parse(encontrar["id_usuario"].ToString());
                    carrito.lincarrito = int.Parse(encontrar["lincarrito"].ToString());
                    carrito.preciocarrito = double.Parse(encontrar["cantidad"].ToString());
                    leido = true;
                }
                encontrar.Close();
                conec.Close();
                return leido;
            }
            catch (SqlException excS)
            {
                Console.WriteLine("User operation has failed. Error: {0}", excS.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine("User operation has failed. Error: {0}", exc.Message);
            }

            return leido;
        }

        public bool deleteCarrito(ENCarrito carrito)
        {
            bool borrado = false;

            try
            {
                SqlConnection conec = new SqlConnection(constring);
                conec.Open();
                SqlCommand comando = new SqlCommand("Delete FROM [dbo].[CARRITO] WHERE id_usuario = '" + carrito.user + "and lincarrito ='" + carrito.lincarrito + "'", conec);
                comando.ExecuteNonQuery();
                borrado = true;
                conec.Close();
            }
            catch (SqlException excS)
            {
                Console.WriteLine("User operation has failed. Error: {0}", excS.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine("User operation has failed. Error: {0}", exc.Message);
            }

            return borrado;
        }


    }
}