using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class ENLinCarrito_pa
    {
       /* private int _id_carrito;
        private ENPaquete _id_paquete;
        private int _cantidad;
        private float _pvp;
        private float _price;

        public int id_carrito
        {
            get { return _id_carrito; }
            set { _id_carrito = value; }
        }

        public ENPaquete id_paquete
        {
            get { return _id_paquete; }
            set { _id_paquete = value; }
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

        public ENLinCarrito_pa()
        {
            this.id_carrito = 0;
            this.id_paquete = null;
            this.cantidad = 0;
            this.pvp = 0;
        }

        public ENLinCarrito_pa(int id_carrito, ENPaquete id_paquete, int cantidad)
        {
            this.id_carrito = id_carrito;
            this.id_paquete = id_paquete;
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
            if (cantidad < producto.Stock)
            {
                this.cantidad++;
                this.pvp = price * cantidad;
            }
        }
        public bool decrementarCantidad()
        {
            if (cantidad != 1)
            {
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
        }*/

    }
}
