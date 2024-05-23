// @author: Manuel José Tornero Fuster    ; DNI: DNI000006
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
        private string _DNI;
        private int _id;
        private List<ENDireccion> _direcciones;
        private bool _admin;
         
        public string Name { get { return _name; } set { _name = value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }
        public string DNI
        {
            get { return _DNI; }
            set
            {
                if (IsValidDNI(value))
                {
                    _DNI = value;
                }
                else
                {
                    throw new ArgumentException("El DNI proporcionado no es válido.");
                }
            }
        }
        public int Id { get { return _id; } set { _id = value; } }
        public List<ENDireccion> Direcciones
        {
            get
            {
                // Se crea una copia de la lista privada
                List<ENDireccion> direccionesCopia = new List<ENDireccion>(_direcciones);
                return direccionesCopia;
            }
            set
            {
                // Se actualiza la lista interna con la nueva lista
                _direcciones = value;
            }
        }
        public bool Admin { get { return _admin; } set { _admin = value; } }

        // Método para validar el DNI
        private bool IsValidDNI(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                return false;
            }

            // Expresión regular para validar el formato del DNI
            Regex dniRegex = new Regex(@"^\d{8}[A-HJ-NP-TV-Z]$");
            if (!dniRegex.IsMatch(dni))
            {
                return false;
            }

            // Extraer los números y la letra del DNI
            string numberPart = dni.Substring(0, 8);
            char letterPart = dni[8];

            // Calcular la letra correcta
            string validLetters = "TRWAGMYFPDXBNJZSQVHLCKE";
            int number = int.Parse(numberPart);
            char correctLetter = validLetters[number % 23];

            // Comprobar si la letra del DNI es correcta
            return correctLetter == letterPart;
        }

        public static string ComputeSha256Hash(string rawData)
        {
            // Crear un objeto SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computar el hash del string en bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convertir los bytes a un string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public ENUsuario() 
        {
            Id = 0;
            Name = string.Empty;
            Surname = string.Empty;
            Email = string.Empty;
            _DNI = string.Empty;
            Password = string.Empty;
            PhoneNumber = string.Empty;
            Direcciones = new List<ENDireccion>();
            _admin = false;
        }

        public ENUsuario(string name, string surname, string password, string dni, string email, string phone)
        {
            Name = name;
            Surname = surname;
            DNI = dni;
            Password = ComputeSha256Hash(password);
            Email = email;
            PhoneNumber = phone;
            _admin = false;
        }

        public ENUsuario(string email, string password)
        {
            Email = email;
            Password = ComputeSha256Hash(password);
        }

        public bool Register(bool admin)
        {
            CADUsuario cad = new CADUsuario();
            return cad.Register(this, admin);
        }

        public bool LogIn()
        {
            CADUsuario cad = new CADUsuario();
            return cad.LogIn(this);
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

        public bool AddAddress(ENDireccion dir)
        {
            CADUsuario cad = new CADUsuario();
            return cad.AddAddress(this,dir);
        }

        public bool MakeAdmin(string email)
        {
            CADUsuario cad = new CADUsuario();
            return cad.MakeAdmin(email);
        }
        
        public static List<ENUsuario> ObtenerUsuarios()
        {
            CADUsuario cad = new CADUsuario();
            return cad.ObtenerUsuarios(false);
        }

        public static List<ENUsuario> ObtenerTrabajadores()
        {
            CADUsuario cad = new CADUsuario();
            return cad.ObtenerUsuarios(true);
        }

    }
}
