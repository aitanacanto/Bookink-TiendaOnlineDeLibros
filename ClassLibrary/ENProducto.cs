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
        public string ImagePath { get; set; }
        public string Sinopsis { get; set; }
        public string Descripcion { get; set; }
        public string Autor { get; set; }

        public ENProducto()
        {

        }

        public ENProducto(int id, string name, int stock, float price, float salePrice, int category, DateTime creationDate, string imagePath, string sinopsis, string descripcion, string autor)
        {
            Id = id;
            Name = name;
            Stock = stock;
            Price = price;
            SalePrice = salePrice;
            Category = category;
            CreationDate = creationDate;
            ImagePath = imagePath;
            Sinopsis = sinopsis;
            Descripcion = descripcion;
            Autor = autor;
        }

        public bool Create()
        {
            CADProducto c = new CADProducto();

            return c.Create(this);
        }

        public bool Update()
        {
            CADProducto c = new CADProducto();
            return c.Update(this);
        }

        public bool Delete()
        {
            CADProducto c = new CADProducto();
            return c.Delete(this);
        }

        public bool Read()
        {
            CADProducto c = new CADProducto();
            return c.Read(this);
        }

    }
}
