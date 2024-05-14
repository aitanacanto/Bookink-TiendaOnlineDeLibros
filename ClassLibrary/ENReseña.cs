// @author: Manuel José Tornero Fuster    ; DNI: DNI000006
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClassLibrary
{
    class ENReseña
    {
        private int _userID; //Identificar el usuario(NIF, email, id,...)
        private int _productID;
        private int _rating;
        private string _comment;
        private DateTime _date;

        public int UserID { get { return _userID; } set { _userID = value; } }
        public int ProductID { get { return _productID; } set { _productID = value; } }
        public int Rating { get { return _rating; } set { _rating = value; } }
        public string Comment { get { return _comment; } set { _comment = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }

        public ENReseña()
        {

        }

        public ENReseña(int userID, int productID, int rating, string comment, DateTime date)
        {
            _userID = userID;
            _productID = productID;
            _rating = rating;
            _comment = comment;
            _date = date;
        }
        public bool Create()
        {
            CADReseña cad = new CADReseña();

            return cad.Create(this);
        }

        public bool Update() 
        { 
            return true;
        }

        public bool Delete()
        {
            return true;
        }
    }
}
