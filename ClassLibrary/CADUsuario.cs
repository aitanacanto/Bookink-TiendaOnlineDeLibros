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
    class CADUsuario
    {
        private string constring;


        //Devuelve true si existe el producto en la base de datos
        private bool Exists(SqlConnection c, ENUsuario en)
        {
            //declaración querry auxiliar
            string querryAux = "Select * from Products where code = @code";
            SqlCommand comAux = new SqlCommand(querryAux, c);

            //asignación parámetros
            comAux.Parameters.AddWithValue("@code", en.Code);

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
                string query = "INSERT INTO USUARIO (nombre, apellidos, nif, mail, teléfono) VALUES (@name, @surname, @nif, @mail, @telefono)";
                SqlCommand com = new SqlCommand(query, c);

                // Añadir los parametros a la sentencia
                com.Parameters.AddWithValue("@name", en.Name);
                com.Parameters.AddWithValue("@surname", en.Surname);
                com.Parameters.AddWithValue("@nif", en.NIF);
                com.Parameters.AddWithValue("@mail", en.Email);
                com.Parameters.AddWithValue("@telefono", en.PhoneNumber);

                com.ExecuteNonQuery();
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

        public bool LogIn(ENUsuario usuario)
        {
            return false;
        }

        public bool LogOut(ENUsuario usuario)
        {
            return false;
        }

        public bool UpdateUserData(ENUsuario usuario)
        {
            return true;
        }

        public bool DeleteUser(ENUsuario usuario) 
        {
            return true;
        }
    }
}
