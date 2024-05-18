using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class CADPaquete
    {
        private string constring;

        public CADPaquete()
        {
            constring = ConfigurationManager.ConnectionStrings["database"].ToString();
        }

        public bool CrearPaquete(ENPaquete en)
        {
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();

                string comandoSQL = "INSERT INTO PAQUETE (nombre, precio) VALUES (@nombre, @precio); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(comandoSQL, conex);
                cmd.Parameters.AddWithValue("@nombre", en.Nombre);
                cmd.Parameters.AddWithValue("@precio", en.Precio);

                en.IdPaquete = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (ENProducto producto in en.Productos)
                {
                    AgregarProductoAlPaquete(en, producto.Id); 
                }
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                conex.Close();
            }
        }



        public ENPaquete leerPaquete(ENPaquete en)
        {
            if (en == null)
            {
                throw new ArgumentNullException(nameof(en), "El parámetro en no puede ser null");
            }

            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();
                string comandoSQL = "SELECT * FROM PAQUETE WHERE id = @id";
                SqlCommand cmd = new SqlCommand(comandoSQL, conex);
                cmd.Parameters.AddWithValue("@id", en.IdPaquete);

                SqlDataReader reader = cmd.ExecuteReader();
                ENPaquete paquete = null;

                if (reader.Read())
                {
                    paquete = new ENPaquete
                    {
                        IdPaquete = (int)reader["id"],
                        Nombre = (string)reader["nombre"],
                        Precio = (float)reader["precio"]
                    };
                }
                else
                {
                    reader.Close();
                    return null;
                }

                reader.Close();

                paquete.Productos = new List<ENProducto>();
                string comandoProductosSQL = "SELECT p.* FROM PRODUCTO p JOIN TIENE_PAQUETE tp ON p.id = tp.id_producto WHERE tp.id_paquete = @id_paquete";
                SqlCommand cmdProductos = new SqlCommand(comandoProductosSQL, conex);
                cmdProductos.Parameters.AddWithValue("@id_paquete", paquete.IdPaquete);
                bool leido = true;

                using (SqlDataReader readerProductos = cmdProductos.ExecuteReader())
                {
                    while (readerProductos.Read() && leido)
                    {
                        ENProducto producto = new ENProducto();
                        leido = producto.Read();
                        paquete.Productos.Add(producto);
                    }
                }

                return paquete;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Operation has failed. SQL Error: {0}", e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Operation has failed. Error: {0}", e.Message);
                return null;
            }
            finally
            {
                conex.Close();
            }
        }



        public bool ActualizarPaquete(ENPaquete en)
        {
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();

                string comandoSQL = "UPDATE PAQUETE SET nombre = @nombre, precio = @precio WHERE id = @id";
                SqlCommand cmd = new SqlCommand(comandoSQL, conex);
                cmd.Parameters.AddWithValue("@id", en.IdPaquete);
                cmd.Parameters.AddWithValue("@nombre", en.Nombre);
                cmd.Parameters.AddWithValue("@precio", en.Precio);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Update operation has failed. Error: {0}", e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Update operation has failed. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                conex.Close();
            }
        }

        public bool EliminarPaquete(ENPaquete en)
        {
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();

                string deleteProductosSQL = "DELETE FROM TIENE_PAQUETE WHERE id_paquete = @id_paquete";
                SqlCommand cmdDeleteProductos = new SqlCommand(deleteProductosSQL, conex);
                cmdDeleteProductos.Parameters.AddWithValue("@id_paquete", en.IdPaquete);
                cmdDeleteProductos.ExecuteNonQuery();

                string comandoSQL = "DELETE FROM PAQUETE WHERE id = @id";
                SqlCommand cmd = new SqlCommand(comandoSQL, conex);
                cmd.Parameters.AddWithValue("@id", en.IdPaquete);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Delete operation has failed. Error: {0}", e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete operation has failed. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                conex.Close();
            }
        }
        public bool EliminarProductoDelPaquete(ENPaquete en, int idProducto)
        {
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();
                string comandoSQL = "DELETE FROM TIENE_PAQUETE WHERE id_paquete = @id_paquete AND id_producto = @id_producto";
                SqlCommand cmd = new SqlCommand(comandoSQL, conex);
                cmd.Parameters.AddWithValue("@id_paquete", en.IdPaquete);
                cmd.Parameters.AddWithValue("@id_producto", idProducto);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Delete product operation has failed. Error: {0}", e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete product operation has failed. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                conex.Close();
            }
        }
        public bool AgregarProductoAlPaquete(ENPaquete en, int idProducto)
        {
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();
                string comandoSQL = "INSERT INTO TIENE_PAQUETE (id_paquete, id_producto) VALUES (@id_paquete, @id_producto)";
                SqlCommand cmd = new SqlCommand(comandoSQL, conex);
                cmd.Parameters.AddWithValue("@id_paquete", en.IdPaquete);
                cmd.Parameters.AddWithValue("@id_producto", idProducto);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Insert product operation has failed. Error: {0}", e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Insert product operation has failed. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                conex.Close();
            }
        }

        public List<ENPaquete> ObtenerTodosLosPaquetes()
        {
            List<ENPaquete> paquetes = new List<ENPaquete>();
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();

                string comandoPaquetesSQL = "SELECT id, nombre, precio FROM PAQUETE";
                SqlCommand cmdPaquetes = new SqlCommand(comandoPaquetesSQL, conex);

                using (SqlDataReader readerPaquetes = cmdPaquetes.ExecuteReader())
                {
                    while (readerPaquetes.Read())
                    {
                        try
                        {
                            ENPaquete paquete = new ENPaquete
                            {
                                IdPaquete = (int)readerPaquetes["id"],
                                Nombre = (string)readerPaquetes["nombre"],
                                Precio = Convert.ToSingle(readerPaquetes["precio"])
                            };

                            paquetes.Add(paquete);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al leer paquete con ID {0}. Error: {1}", readerPaquetes["id"], ex.Message);
                        }
                    }
                }

                return paquetes;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Operation has failed. SQL Error: {0}", e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Operation has failed. Error: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Cerrando la conexión.");
                conex.Close();
            }
        }
    }
}
