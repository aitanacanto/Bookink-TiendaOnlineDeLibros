// @author: Manuel José Tornero Fuster    ; DNI: DNI000006
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

        public CADUsuario(ENUsuario usuario)
        {
            //constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
        }

        public bool Register(ENUsuario usuario) 
        { 
            return false; 
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
