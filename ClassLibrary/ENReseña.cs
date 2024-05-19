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
    public class ENReseña
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
            UserID = 0;
            ProductID = 0;
            Rating = 0;
            Comment = string.Empty;
            Date = DateTime.MinValue;
        }

        public ENReseña(int userID, int productID, int rating, string comment, DateTime date)
        {
            UserID = userID;
            ProductID = productID;
            Rating = rating;
            Comment = comment;
            Date = date;
        }
        public bool Create()
        {
            CADReseña cad = new CADReseña();

            return cad.Create(this);
        }

        public bool Update() 
        {
            CADReseña cad = new CADReseña();

            return cad.Update(this);
        }

        public bool Delete()
        {
            CADReseña cad = new CADReseña();

            return cad.Delete(this);
        }
    }
}
