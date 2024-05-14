// @author:  Bruno Vilella Martínez; DNI: DNI000003
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ENCarrito
    {
        private int id;
        private int id_usuario;
        private int id_lincarrito;
        private double precio;

        public int idcarrito
        {
            get { return id; }
            set { id = value; }
        }
        public int user
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        public int lincarrito
        {
            get { return id_lincarrito; }
            set { id_lincarrito = value; }
        }
        public double preciocarrito
        {
            get { return precio; }
            set { precio = value; }
        }
        public ENCarrito()
        {
            CADCarrito carrito = new CADCarrito();
            idcarrito = carrito.ObtenerId();
            lincarrito = 0;
            id_usuario = 0;
            precio = 0.0;
        }
        public ENCarrito(int id, int usuario, int lincarrito, double precio)
        {
            this.id = id;
            this.id_usuario = usuario;
            this.id_lincarrito = lincarrito;
            this.precio = precio;
        }
        public bool CrearCarrito()
        {
            bool creado;
            CADCarrito carrito = new CADCarrito();
            if (carrito.readCarrito(this) == false)
            {
                creado = carrito.createCarrito(this);
            }
            else
            {
                creado = false;
            }
            return creado;
        }
        public bool BorrarCarrito()
        {
            bool borrar = false;
            CADCarrito carrito = new CADCarrito();
            if (carrito.readCarrito(this) == true)
            {
                borrar = carrito.deleteCarrito(this);
            }
            return borrar;
        }
        public bool LeerCarrito()
        {
            CADCarrito carrito = new CADCarrito();
            bool read = carrito.readCarrito(this);
            return read;
        }
        public bool actualizarCompra()
        {
            bool update = false;
            CADCarrito compra = new CADCarrito();
            ENCarrito aux = new ENCarrito();
            aux.id_usuario = this.id_usuario;
            aux.id_lincarrito = this.id_lincarrito;
            aux.precio = this.precio;
            if (compra.readCarrito(this) == true)
            {
                this.id_lincarrito = aux.id_lincarrito;
                this.id_usuario = aux.id_usuario;
                this.precio = aux.precio;
            }
            return update;
        }
    }
}
