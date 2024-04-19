// @author:     ; DNI:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class CADUsuario
    {
        private string constring;

        public CADUsuario()
        {
            //constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
        }

        public bool Register() 
        { 
            return false; 
        }

        public bool LogIn()
        {
            return false;
        }

        public bool LogOut()
        {
            return false;
        }

        public bool UpdateUserData()
        {
            return true;
        }

        public bool DeleteUser() 
        {
            return true;
        }
    }
}
