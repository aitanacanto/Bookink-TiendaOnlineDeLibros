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

                string comandoSQL = "INSERT INTO PAQUETE (nombre, precio, img_paquete) VALUES (@nombre, @precio, @img_paquete);";
                SqlCommand cmd = new SqlCommand(comandoSQL, conex);
                cmd.Parameters.AddWithValue("@nombre", en.Nombre);
                cmd.Parameters.AddWithValue("@precio", en.Precio);
                cmd.Parameters.AddWithValue("@img_paquete", en.Img_paquete);

                en.IdPaquete = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (ENProducto producto in en.Productos)
                {
                    ENTienePaquete tiene = new ENTienePaquete { IdPaquete = en.IdPaquete, IdProducto = producto.Id };
                    tiene.AgregarProductoAlPaquete(tiene.IdPaquete, tiene.IdProducto);
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

        public bool leerPaquete(ENPaquete en)
        {
            if (en == null)
            {
                throw new ArgumentNullException(nameof(en), "El parámetro en no puede ser null");
            }

            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                string query = "SELECT * FROM PAQUETE WHERE Id = @Id";
                SqlCommand com = new SqlCommand(query, c);
                com.Parameters.AddWithValue("@Id", en.IdPaquete);

                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.IdPaquete = int.Parse(dr["id"].ToString());
                    en.Nombre = dr["nombre"].ToString();
                    en.Precio = float.Parse(dr["precio"].ToString());
                    en.Img_paquete = dr["img_paquete"].ToString();
                }
                dr.Close();

                en.Productos = new List<ENProducto>();
                string comandoProductosSQL = "SELECT p.id FROM PRODUCTO p JOIN TIENE_PAQUETE tp ON p.id = tp.id_producto WHERE tp.id_paquete = @id_paquete";
                SqlCommand cmdProductos = new SqlCommand(comandoProductosSQL, c);
                cmdProductos.Parameters.AddWithValue("@id_paquete", en.IdPaquete);

                using (SqlDataReader readerProductos = cmdProductos.ExecuteReader())
                {
                    while (readerProductos.Read())
                    {
                        ENProducto producto = new ENProducto
                        {
                            Id = int.Parse(readerProductos["id"].ToString())
                        };
                        bool leido = producto.Read();
                        if (leido)
                        {
                            en.Productos.Add(producto);
                        }
                    }
                }
                return true;

            }
            catch (SqlException e)
            {
                Console.WriteLine("Operation has failed. SQL Error: {0}", e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Operation has failed. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                c.Close();
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
                cmd.Parameters.AddWithValue("@img_paquete", en.Img_paquete);
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

        public List<ENPaquete> ObtenerTodosLosPaquetes()
        {
            List<ENPaquete> paquetes = new List<ENPaquete>();
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();
                string comandoPaquetesSQL = "SELECT id FROM PAQUETE";
                SqlCommand cmdPaquetes = new SqlCommand(comandoPaquetesSQL, conex);

                using (SqlDataReader readerPaquetes = cmdPaquetes.ExecuteReader())
                {
                    while (readerPaquetes.Read())
                    {
                        try
                        {
                            // Crear una instancia de ENPaquete con solo el IdPaquete
                            ENPaquete paquete = new ENPaquete
                            {
                                IdPaquete = int.Parse(readerPaquetes["id"].ToString())
                        };

                            // Llamar a leerPaquete para llenar los detalles completos del paquete
                            bool paqueteLeido = leerPaquete(paquete);
                            if (paqueteLeido)
                            {
                                paquetes.Add(paquete);
                            }
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
                conex.Close();
            }
        }


    }
}
