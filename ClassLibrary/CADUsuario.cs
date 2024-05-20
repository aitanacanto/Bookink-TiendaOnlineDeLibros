// @author: Manuel José Tornero Fuster    ; DNI: DNI000006
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CADUsuario
    {
        private string constring;

        //Devuelve true si existe el producto en la base de datos
        private bool Exists(SqlConnection c, ENUsuario en)
        {
            //declaración querry auxiliar
            string querryAux = "Select email from USUARIO where email = @email";
            SqlCommand comAux = new SqlCommand(querryAux, c);

            //asignación parámetros
            comAux.Parameters.AddWithValue("@email", en.Email);

            SqlDataReader dr = comAux.ExecuteReader();

            bool existe = dr.Read();
            dr.Close();
            return existe;
        }

        public CADUsuario() 
        {
            constring = ConfigurationManager.ConnectionStrings["database"].ToString();
        }

        public bool Register(ENUsuario en) 
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                // Crear una sentencia parametricada
                string query = "INSERT INTO USUARIO (nombre, apellidos, contrasenya, dni, email, telefono, puntos, admin) " +
                               "OUTPUT INSERTED.ID " +
                               "VALUES (@name, @surname, @contrasenya, @dni, @email, @telefono, 0, 0)";
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@name", en.Name);
                com.Parameters.AddWithValue("@surname", en.Surname);
                com.Parameters.AddWithValue("@contrasenya", en.Password);
                com.Parameters.AddWithValue("@dni", en.DNI);
                com.Parameters.AddWithValue("@email", en.Email);
                com.Parameters.AddWithValue("@telefono", en.PhoneNumber);

                en.Id = Convert.ToInt32(com.ExecuteScalar());

                //com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido añadir el usuario, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool LogIn(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                if (!Exists(c, en)) { throw new ArgumentException("No existe el usuario con email: " + en.Email.ToString());}

                string inputPass;
                // Crear una sentencia parametricada
                string query = "SELECT id, nombre, apellidos, contrasenya, dni, email, telefono, admin FROM USUARIO WHERE email = @email";
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@email", en.Email);

                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    inputPass = (string)reader["contrasenya"];
                    if (inputPass == en.Password)
                    {
                        en.Id = (int)reader["id"];
                        en.Name = (string)reader["nombre"];
                        en.Surname = (string)reader["apellidos"];
                        en.DNI = (string)reader["dni"];
                        en.PhoneNumber = (string)reader["telefono"];
                        en.Admin = (bool)reader["admin"];
                        return true;
                    }
                    else
                    {
                        throw new ArgumentException("Contraseña: " + en.Password + "no válida.");
                    }
                }
                else
                {
                    throw new ArgumentException("No se ha podido leer los datos al iniciar sesión.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido iniciar sesión, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool UpdateUserData(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                // Crear una sentencia parametricada
                string query = "UPDATE USUARIO SET nombre = @name, apellidos = @surname, contrasenya = @contrasenya, " +
                                "dni = @dni, telefono = @telefono " +
                                "WHERE email = @email";

                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@name", en.Name);
                com.Parameters.AddWithValue("@surname", en.Surname);
                com.Parameters.AddWithValue("@contrasenya", en.Password);
                com.Parameters.AddWithValue("@dni", en.DNI);
                com.Parameters.AddWithValue("@email", en.Email);
                com.Parameters.AddWithValue("@telefono", en.PhoneNumber);

                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido modificar el usuario, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool DeleteUser(ENUsuario en) 
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                //necesito una funcion de tiene_direccion para borrar las relaciones y luego poder todas las direcciones
                c.Open();

                // Crear una sentencia parametricada
                string query = "DELETE FROM USUARIO WHERE email = @email";

                //TODO: posible mejora - Hacer una funcion que compruebe si el usuario y la contraseña son iguales para eliminar e implementarla en login
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@email", en.Email);

                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ha podido eliminar el usuario, ERROR: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }

        }

        public bool AddAddress(ENUsuario user, ENDireccion dir)
        {
            user.Direcciones.Add(dir);
            return true;
        }
    }
}
