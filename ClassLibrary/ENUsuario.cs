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
        private string _surname;
        private string _email;
        private string _password;
        private string _phoneNumber;
        private string _NIF;
        private string _address; //deberia ser una referencia
        private int _id;

        public string Name { get { return _name; } set { _name = value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }
        public string NIF { get { return _NIF; } set { _NIF = value; } }
        public int Id { get { return _id; } set { _id = value; } }
        
        public ENUsuario() 
        {
            Id = 0;
            this.Name = "";
            _surname = "";
            _NIF = "";
            _password = "";
            _email = "";
            _phoneNumber = "";

        }

        public ENUsuario(string name, string surname, string password, string nif, string email, string phone)
        {
            _name = name;
            _surname = surname;
            _NIF = nif;
            _password = password;
            _email = email;
            _phoneNumber = phone;
        }

        public ENUsuario(string email, string password)
        {
            _email = email;
            // cifrar 
            _password = password;
        }

        public bool Register()
        {
            CADUsuario cad = new CADUsuario();
            return cad.Register(this);
        }

        public bool LogIn()
        {
            CADUsuario cad = new CADUsuario();
            return cad.LogIn(this);
        }

        public bool LogOut()
        {
            CADUsuario cad = new CADUsuario();
            return cad.LogOut(this);
        }

        public bool UpdateUserData()
        {
            CADUsuario cad = new CADUsuario();
            return cad.UpdateUserData(this);
        }  

        public bool DeleteUser()
        {
            CADUsuario cad = new CADUsuario();
            return cad.DeleteUser(this);
        }
    }
}
