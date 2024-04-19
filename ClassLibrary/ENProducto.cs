// @author: Darío Pastor Fuentes    ; DNI: DNI000004
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ENProducto
    {
        private string _name;
        private int _id;
        private int _stock;
        private float _price;
        private float _salePrice;
        private int _category;
        private DateTime _creationDate;

        public string Name { get { return _name; } set { _name = value; } }
        public int Id { get { return _id; } set { _id = value; } }
        public int Stock { get { return _stock; } set { _stock = value; } }
        public float Price { get { return _price; } set { _price = value; } }
        public float SalePrice { get { return _salePrice; } set { _salePrice = value; } }
        public int Category { get { return _category; } set { _category = value; } }
        public DateTime CreationDate { get { return _creationDate; } set { _creationDate = value; } }
        

        public ENProducto()
        {

        }

        public ENProducto(int id, string name, int stock, float price, float salePrice, int category, DateTime creationDate)
        {

        }

        public bool Create()
        {
            return false;
        }

        public bool Update()
        {
            return false;
        }

        public bool Delete()
        {
            return false;
        }

        public bool Read()
        {
            return false;
        }

    }
}
