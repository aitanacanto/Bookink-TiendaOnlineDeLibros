// @author: Manuel José Tornero Fuster    ; DNI: DNI000006
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ENUsuario
    {

        private string _name;
        private string _surnames;
        private string _email;
        private string _password;
        private int _phoneNumber;
        private string _NIF;
        private string _address; //deberia ser una referencia
        private int _id;

        public string Name { get { return _name; } set { _name = value; } }
        public string Surnames { get { return _surnames; } set { _surnames = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public int PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }
        public string NIF { get { return _NIF; } set { _NIF = value; } }
        public int Id { get { return _id; } set { _id = value; } }
        public ENUsuario() 
        {
        }

        public ENUsuario(int id, string name, string surnames, string nif, string email)
        {
            Id = id;
            Name = name;
            Surnames = surnames;
            NIF = nif;
            Email = email;
        }

        public bool Register()
        {
            return false;
        }

        public bool LogIn()
        {
            return true;
        }

        public bool LogOut()
        {
            return false;
        }

        public bool UpdateUserData()
        {
            return false;
        }  

        public bool DeleteUser()
        {
            return false;
        }
    }
}
