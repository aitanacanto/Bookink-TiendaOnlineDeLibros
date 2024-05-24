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
        private List<ENCategoria> _listLinCategoria = new List<ENCategoria>();

        public string Name { get { return _name; } set { _name = value; } }
        public int Id { get { return _id; } set { _id = value; } }
        public int Stock { get { return _stock; } set { _stock = value; } }
        public float Price { get { return _price; } set { _price = value; } }
        public float SalePrice { get { return _salePrice; } set { _salePrice = value; } }
        public string ImagePath { get; set; }
        public string Sinopsis { get; set; }
        public string Autor { get; set; }
        public string CodOfer { get; set; }
        public string Editorial { get; set; }
        public int AnyoPubli { get; set; }
        public int NumPags { get; set; }

        public ENProducto()
        {

        }

        public ENProducto(string name, int stock, float price, float salePrice, string imagePath, string sinopsis, string autor, string codOfer, string editorial, int anyoPubli, int numPags)
        {
            Name = name;
            Stock = stock;
            Price = price;
            SalePrice = salePrice;
            ImagePath = imagePath;
            Sinopsis = sinopsis;
            Autor = autor;
            CodOfer = codOfer;
            Editorial = editorial;
            AnyoPubli = anyoPubli;
            NumPags = numPags;

        }
        public ENProducto(int id)
        {
            this.Id = id;
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

        public List<ENProducto> ObtenerTodosLosProductos()
        {
            CADProducto cad = new CADProducto();
            return cad.ObtenerTodosLosProductos();
        }
        public List<String> ObtenerTodosLosAutores()
        {
            CADProducto cad = new CADProducto();
            return cad.ObtenerTodosLosAutores();
        }

        public List<String> ObtenerTodasLasEditoriales()
        {
            CADProducto cad = new CADProducto();
            return cad.ObtenerTodasLasEditoriales();
        }

        public List<ENProducto> BuscarProductosPorNombre(string nombre)
        {
            CADProducto cad = new CADProducto();
            return cad.BuscarProductosPorNombre(nombre);
        }

        public List<ENProducto> BuscarProductosPorFiltros(int? categoria, string editorial, string autor, float? precioMinimo, float? precioMaximo)
        {
            CADProducto cad = new CADProducto();
            return cad.BuscarProductosPorFiltros(categoria, editorial, autor, precioMinimo, precioMaximo);
        }
        public  List<ENProducto> ObtenerTopProductosVendidos()
        {
            CADProducto cad = new CADProducto();
            return cad.ObtenerTopProductosVendidos();
        }

    }
}
