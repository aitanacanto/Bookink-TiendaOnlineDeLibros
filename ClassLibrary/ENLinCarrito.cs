using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Configuration;


namespace ClassLibrary
{
    public class ENLinCarrito
    {

        private int _id_carrito;
        private ENProducto _producto;
        private int _cantidad;
        private float _pvp;
        private float _price;

        public int id_carrito
        {
            get { return _id_carrito; }
            set { _id_carrito = value; }
        }

        public ENProducto producto
        {
            get { return _producto; }
            set { _producto = value; }
        }

        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public float pvp
        {
            get { return _pvp; }
            set { _pvp = value; }
        }
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        public ENLinCarrito()
        {
            this.id_carrito = 0;
            this.producto = null;
            this.cantidad = 0;
            this.pvp = 0;
        }

        public ENLinCarrito(int id_carrito, ENProducto producto, int cantidad)
        {
            this.id_carrito = id_carrito;
            this.producto = producto;
            this.cantidad = cantidad;
            float price;
            if (producto.SalePrice != 0)
            {
                price = producto.SalePrice;
            }
            else
            {
                price = producto.Price;
            }
            this.price = price;
            this.pvp = price * cantidad;
        }

        public List<ENLinCarrito> cargarLineasCarrito(int id)
        {
            
            CADLinCarrito linca = new CADLinCarrito();
            return linca.cargarLineasCarrito(id);

        }

        public void incrementarCantidad()
        {
            if (cantidad < producto.Stock) { 
                this.cantidad++;
                this.pvp = price * cantidad;
            }
        }
        public bool decrementarCantidad()
        {
            if (cantidad != 1) { 
                this.cantidad--;
                this.pvp = price * cantidad;
                return false;
            }
            else
            {
                return true;
            }
            
        }
        public bool insertarLinea()
        {
            CADLinCarrito linea = new CADLinCarrito();
            if (linea.existeEnCarrito(this))
            {
                return linea.actualizarCantidadLinea(this);
                
            }
            else
            {
                return linea.insertarLinea(this);
            }
            
        }
        public bool actualizarLinea()
        {
            CADLinCarrito linea = new CADLinCarrito();
            return linea.actualizarLinea(this);
        }

        public bool eliminarLinea()
        {
            CADLinCarrito linea = new CADLinCarrito();
            return linea.eliminarLinea(this);
        }

    }
}