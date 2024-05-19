// @author: Jorge Paredes Soler; DNI: DNI000007
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ClassLibrary
{
    class CADDireccion
    {
        private string constring;

        public CADDireccion()
        {
            constring = ConfigurationManager.ConnectionStrings["database"].ToString();
        }

        public bool AñadirDireccion(ENDireccion direccion)
        {
            using (SqlConnection c = new SqlConnection(constring))
            {
                try
                {
                    c.Open();
                    //te he quitado el id porque se pone solo en la base de datos al introducir una fila
                    using (SqlCommand com = new SqlCommand(
                            "INSERT INTO DIRECCION (cod_postal, dirección, ciudad, pais) " +
                            "OUTPUT INSERTED.ID " +
                            "VALUES (@cod_postal, @direccion, @ciudad, @pais);", c))
                    {
                        com.Parameters.AddWithValue("@cod_postal", direccion.CodPostal);
                        com.Parameters.AddWithValue("@direccion", direccion.Direccion);
                        com.Parameters.AddWithValue("@ciudad", direccion.Ciudad);
                        com.Parameters.AddWithValue("@pais", direccion.Pais);

                        // saca de la base de datos el id generado
                        direccion.ID = Convert.ToInt32(com.ExecuteScalar());
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se ha podido añadir la dirección, ERROR: {0}", ex.Message);
                    return false;
                }
                finally
                {
                    c.Close();
                }
            }   
                
        }


        public bool LeerDireccion(ENDireccion direccion)
        {
            using (SqlConnection c = new SqlConnection(constring))
            {
                try
                {
                    c.Open();
                    using (SqlCommand com = new SqlCommand("SELECT * FROM DIRECCION WHERE id = @id", c))
                    {
                        com.Parameters.AddWithValue("@id", direccion.ID);

                        using (SqlDataReader dr = com.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                direccion.CodPostal = dr["cod_postal"].ToString();
                                direccion.Direccion = dr["direccion"].ToString();
                                direccion.Ciudad = dr["ciudad"].ToString();
                                direccion.Pais = dr["pais"].ToString();
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se ha podido leer la dirección, ERROR: {0}", ex.Message);
                    return false;
                }
                finally
                {
                    c.Close();
                }
            }
        }

        public bool ModificarDireccion(ENDireccion direccion)
        {
            using (SqlConnection c = new SqlConnection(constring))
            {
                try
                {

                    c.Open();
                    using (SqlCommand com = new SqlCommand("UPDATE DIRECCION SET cod_postal = @cod_postal, direccion = @direccion, ciudad = @ciudad, pais = @pais WHERE id = @id", c))
                    {
                        com.Parameters.AddWithValue("@id", direccion.ID);
                        com.Parameters.AddWithValue("@cod_postal", direccion.CodPostal);
                        com.Parameters.AddWithValue("@direccion", direccion.Direccion);
                        com.Parameters.AddWithValue("@ciudad", direccion.Ciudad);
                        com.Parameters.AddWithValue("@pais", direccion.Pais);


                        com.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se ha podido modificar la dirección, ERROR: {0}", ex.Message);
                    return false;
                }
                finally
                {
                    c.Close();
                }
            }
        }
    }
}