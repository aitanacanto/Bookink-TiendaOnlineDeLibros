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
using System.Reflection.Emit;

namespace ClassLibrary
{
    class CADProducto
    {
        private string constring;
        public CADProducto()
        {
            constring = ConfigurationManager.ConnectionStrings["database"].ToString();
        }
        private bool Exists(SqlConnection c, ENProducto en)
        {
            string querryAux = "Select * from Producto where id = @id";
            SqlCommand comAux = new SqlCommand(querryAux, c);
            comAux.Parameters.AddWithValue("@id", en.Id);
            SqlDataReader dr = comAux.ExecuteReader();
            bool existe = dr.Read();
            dr.Close();
            return existe;
        }

        

        public bool Create(ENProducto en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                string query = "INSERT INTO PRODUCTO (nombre, cant_stock, precio, precio_oferta, img_producto, sinopsis, autor, cod_oferta, editorial, anyo_publicacion, num_pag) OUTPUT INSERTED.ID  VALUES (@Name, @Stock, @Price, @SalePrice, @ImagePath, @Sinopsis, @Autor, @CodOfer, @Editorial, @AnyoPubli, @NumPags) ";
                SqlCommand com = new SqlCommand(query, c);

                com.Parameters.AddWithValue("@Name", en.Name);
                com.Parameters.AddWithValue("@Stock", en.Stock);
                com.Parameters.AddWithValue("@Price", en.Price);
                com.Parameters.AddWithValue("@SalePrice", en.SalePrice);
                com.Parameters.AddWithValue("@ImagePath", en.ImagePath);
                com.Parameters.AddWithValue("@Sinopsis", en.Sinopsis);
                com.Parameters.AddWithValue("@Autor", en.Autor);
                com.Parameters.AddWithValue("@CodOfer", en.CodOfer);
                com.Parameters.AddWithValue("@Editorial", en.Editorial);
                com.Parameters.AddWithValue("@AnyoPubli", en.AnyoPubli);
                com.Parameters.AddWithValue("@NumPags", en.NumPags);

                en.Id = Convert.ToInt32(com.ExecuteScalar());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido añadir el producto, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool Update(ENProducto en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                string query = @"UPDATE PRODUCTO set nombre = @Name, cant_stock = @Stock, precio = @Price, precio_oferta = @SalePrice, img_producto = @ImagePath, sinopsis = @Sinopsis, autor = @Autor, cod_oferta = @CodOfer, editorial = @Editorial, anyo_publicacion = @AnyoPubli, num_pag = @NumPags WHERE id = @Id";
                SqlCommand com = new SqlCommand(query, c);

                com.Parameters.AddWithValue("@Name", en.Name);
                com.Parameters.AddWithValue("@Stock", en.Stock);
                com.Parameters.AddWithValue("@Price", en.Price);
                com.Parameters.AddWithValue("@SalePrice", en.SalePrice);
                com.Parameters.AddWithValue("@ImagePath", en.ImagePath);
                com.Parameters.AddWithValue("@Sinopsis", en.Sinopsis);
                com.Parameters.AddWithValue("@Autor", en.Autor);
                com.Parameters.AddWithValue("@CodOfer", en.CodOfer);
                com.Parameters.AddWithValue("@Editorial", en.Editorial);
                com.Parameters.AddWithValue("@AnyoPubli", en.AnyoPubli);
                com.Parameters.AddWithValue("@NumPags", en.NumPags);
                com.Parameters.AddWithValue("@Id", en.Id);

                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido actualizar el producto, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool Delete(ENProducto en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                if (!this.Exists(c, en)){throw new ArgumentException("El producto no existe"); }
                string query = "Delete from PRODUCTO where Id = @Id";
                SqlCommand com = new SqlCommand(query, c);
                com.Parameters.AddWithValue("@Id", en.Id);

                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido borrar el producto, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool Read(ENProducto en)
        {
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                string query = "Select * from PRODUCTO where Id = @Id";
                SqlCommand com = new SqlCommand(query, c);
                com.Parameters.AddWithValue("@Id", en.Id);

                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                en.Id = int.Parse(dr["id"].ToString());
                en.Name = dr["nombre"].ToString();
                en.Price = float.Parse(dr["precio"].ToString());
                en.Stock = int.Parse(dr["cant_stock"].ToString());
                en.SalePrice = dr["precio_oferta"].ToString() == "" ? 0 : float.Parse(dr["precio_oferta"].ToString());
                en.Sinopsis = dr["sinopsis"].ToString();
                en.Autor = dr["autor"].ToString();
                en.ImagePath = dr["img_producto"].ToString();
                en.Editorial = dr["editorial"].ToString();
                en.AnyoPubli = int.Parse(dr["anyo_publicacion"].ToString());
                en.NumPags = int.Parse(dr["num_pag"].ToString());
                en.CodOfer = dr["cod_oferta"].ToString();

                dr.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido leer el producto, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public List<ENProducto> ObtenerTodosLosProductos()
        {
            List<ENProducto> productos = new List<ENProducto>();
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();

                string comandoPaquetesSQL = "SELECT * FROM PRODUCTO";
                SqlCommand cmdPaquetes = new SqlCommand(comandoPaquetesSQL, conex);

                using (SqlDataReader dr = cmdPaquetes.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        try
                        {
                            ENProducto en = new ENProducto();
                            en.Id = int.Parse(dr["id"].ToString());
                            en.Name = dr["nombre"].ToString();
                            en.Price = float.Parse(dr["precio"].ToString());
                            en.Stock = int.Parse(dr["cant_stock"].ToString());
                            en.SalePrice = dr["precio_oferta"].ToString() == "" ? 0: float.Parse(dr["precio_oferta"].ToString());
                            en.Sinopsis = dr["sinopsis"].ToString();
                            en.Autor = dr["autor"].ToString();
                            en.ImagePath = dr["img_producto"].ToString();
                            en.Editorial = dr["editorial"].ToString();
                            en.AnyoPubli = int.Parse(dr["anyo_publicacion"].ToString());
                            en.NumPags = int.Parse(dr["num_pag"].ToString());

                            productos.Add(en);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al leer producto con ID {0}. Error: {1}", dr["id"], ex.Message);
                        }
                    }
                }

                return productos;
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

        public List<String> ObtenerTodosLosAutores()
        {
            List<string> autores = new List<string>();
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();

                string comandoAutoresSQL = "SELECT DISTINCT autor FROM PRODUCTO";
                SqlCommand cmdAutores = new SqlCommand(comandoAutoresSQL, conex);

                using (SqlDataReader dr = cmdAutores.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        autores.Add(dr["autor"].ToString());
                    }
                }

                return autores;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Operación fallida. Error de SQL: {0}", e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Operación fallida. Error: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Cerrando la conexión.");
                conex.Close();
            }
        }

        public List<String> ObtenerTodasLasEditoriales()
        {
            List<string> editoriales = new List<string>();
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();

                string comandoEditorialesSQL = "SELECT DISTINCT editorial FROM PRODUCTO";
                SqlCommand cmdEditoriales = new SqlCommand(comandoEditorialesSQL, conex);

                using (SqlDataReader dr = cmdEditoriales.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        editoriales.Add(dr["editorial"].ToString());
                    }
                }

                return editoriales;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Operación fallida. Error de SQL: {0}", e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Operación fallida. Error: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Cerrando la conexión.");
                conex.Close();
            }
        }



        public List<ENProducto> BuscarProductosPorNombre(string nombre)
        {
            List<ENProducto> productos = new List<ENProducto>();
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();
                string comandoBuscarSQL = "SELECT * FROM PRODUCTO WHERE nombre LIKE '%" + nombre + "%'";
                SqlCommand cmdBuscar = new SqlCommand(comandoBuscarSQL, conex);

                using (SqlDataReader dr = cmdBuscar.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        try
                        {
                            ENProducto en = new ENProducto();
                            en.Id = int.Parse(dr["id"].ToString());
                            en.Name = dr["nombre"].ToString();
                            en.Price = float.Parse(dr["precio"].ToString());
                            en.Stock = int.Parse(dr["cant_stock"].ToString());
                            en.SalePrice = dr["precio_oferta"].ToString() == "" ? 0 : float.Parse(dr["precio_oferta"].ToString());
                            en.Sinopsis = dr["sinopsis"].ToString();
                            en.Autor = dr["autor"].ToString();
                            en.ImagePath = dr["img_producto"].ToString();
                            en.Editorial = dr["editorial"].ToString();
                            en.AnyoPubli = int.Parse(dr["anyo_publicacion"].ToString());
                            en.NumPags = int.Parse(dr["num_pag"].ToString());
                            en.CodOfer = dr["cod_oferta"].ToString();

                            productos.Add(en);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al leer producto con ID {0}. Error: {1}", dr["id"], ex.Message);
                        }
                    }
                }

                return productos;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Operación fallida. Error de SQL: {0}", e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Operación fallida. Error: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Cerrando la conexión.");
                conex.Close();
            }
        }

        public List<ENProducto> BuscarProductosPorFiltros(int? categoria, string editorial, string autor, float? precioMinimo, float? precioMaximo)
        {
            List<ENProducto> productos = new List<ENProducto>();
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();

                List<string> conditions = new List<string>();
                if (categoria.HasValue) {  conditions.Add("c.id = @Categoria");    }
                if (!string.IsNullOrEmpty(editorial)){  conditions.Add("p.editorial = @Editorial"); }
                if (!string.IsNullOrEmpty(autor)){      conditions.Add("p.autor = @Autor");         }
                if (precioMinimo.HasValue){             conditions.Add("p.precio >= @PrecioMinimo");}
                if (precioMaximo.HasValue){             conditions.Add("p.precio <= @PrecioMaximo");}

                string query = @"
                                SELECT p.*
                                FROM PRODUCTO p
                                JOIN TIENE_CATEGORIA tc ON p.id = tc.id_producto
                                JOIN CATEGORIA c ON c.id = tc.id_categoria";

                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                SqlCommand cmd = new SqlCommand(query, conex);

                if (categoria.HasValue) {  cmd.Parameters.AddWithValue("@Categoria", categoria);   }
                if (!string.IsNullOrEmpty(editorial)){  cmd.Parameters.AddWithValue("@Editorial", editorial);   }
                if (!string.IsNullOrEmpty(autor)){      cmd.Parameters.AddWithValue("@Autor", autor);           }
                if (precioMinimo.HasValue){             cmd.Parameters.AddWithValue("@PrecioMinimo", precioMinimo.Value); }
                if (precioMaximo.HasValue){             cmd.Parameters.AddWithValue("@PrecioMaximo", precioMaximo.Value); }


                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ENProducto en = new ENProducto();
                        en.Id = int.Parse(dr["id"].ToString());
                        en.Name = dr["nombre"].ToString();
                        en.Stock = int.Parse(dr["cant_stock"].ToString());
                        en.Price = float.Parse(dr["precio"].ToString());
                        en.SalePrice = dr["precio_oferta"].ToString() == "" ? 0 : float.Parse(dr["precio_oferta"].ToString());
                        en.ImagePath = dr["img_producto"].ToString();
                        en.Sinopsis = dr["sinopsis"].ToString();
                        en.Autor = dr["autor"].ToString();
                        en.CodOfer = dr["cod_oferta"].ToString();
                        en.Editorial = dr["editorial"].ToString();
                        en.AnyoPubli = int.Parse(dr["anyo_publicacion"].ToString());
                        en.NumPags = int.Parse(dr["num_pag"].ToString());

                        productos.Add(en);
                    }
                }

                return productos;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Operación fallida. Error: {0}", ex.Message);
                return null;
            }
            finally
            {
                conex.Close();
            }
        }
        public List<ENProducto> ObtenerTopProductosVendidosMetricas()
        {
            List<ENProducto> productos = new List<ENProducto>();
            SqlConnection conex = new SqlConnection(constring);

            try
            {
                conex.Open();
                string comandoSQL = @"
            SELECT TOP 10 
                p.id, 
                p.nombre, 
                p.precio, 
                SUM(lp.cantidad) AS TotalVendido,
                SUM(lp.cantidad * p.precio) AS ImporteTotal
            FROM PRODUCTO p
            JOIN LINPEDIDO lp ON p.id = lp.id_producto
            GROUP BY p.id, p.nombre, p.precio
            ORDER BY TotalVendido DESC";

                SqlCommand cmd = new SqlCommand(comandoSQL, conex);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ENProducto en = new ENProducto();
                        ENLinPedido lin = new ENLinPedido();
                        en.Id = int.Parse(dr["id"].ToString());
                        en.Name = dr["nombre"].ToString();
                        en.Price = float.Parse(dr["precio"].ToString());
                        en.Stock = int.Parse(dr["TotalVendido"].ToString());
                        productos.Add(en);

                    }
                }


    }
}
