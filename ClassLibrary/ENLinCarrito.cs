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
        private int _id_producto;
        private int _cantidad;
        private float _pvp;

        public int id_carrito
        {
            get { return _id_carrito; }
            set { _id_carrito = value; }
        }

        public int id_producto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
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

        public ENLinCarrito()
        {
            this.id_carrito = 0;
            this.id_producto = 0;
            this.cantidad = 0;
            this.pvp = 0;
        }

        public ENLinCarrito(int id_carrito, int id_producto, int cantidad, float pvp)
        {
            this.id_carrito = id_carrito;
            this.id_producto = id_producto;
            this.cantidad = cantidad;
            this.pvp = pvp;
        }
        public void incrementarCantidad()
        {
            this.cantidad++;
        }
        public bool creacionLineaCarrito()
        {
            CADLinCarrito linca = new CADLinCarrito();
            ENCarrito c = new ENCarrito();
            c.id = this.id_carrito;

            if (linca.readLinCarrito(this) != true && c.readCarrito())
            {
                return linca.creacionLinCarrito(this);
            }

            return false;
        }

        public bool readLinCarrito()
        {
            CADLinCarrito linca = new CADLinCarrito();
            return linca.readLinCarrito(this);
        }

        public DataSet actualizacionLinCarrito(int lin)
        {
            CADLinCarrito c = new CADLinCarrito();
            DataSet dat = new DataSet();
            ENLinCarrito linca = new ENLinCarrito();

            linca.id_producto = this.id_producto;
            linca.cantidad = this.cantidad;
            linca.pvp = this.pvp;

            if (c.readLinCarrito(this) == true)
            {
                this.id_producto = linca.id_producto;
                this.cantidad = linca.cantidad;
                this.pvp = linca.pvp;
                dat = c.actualizacionLinCarrito(this, lin);
            }

            return dat;
        }


        public bool eliminacionLinCarrito()
        {
            CADLinCarrito linca = new CADLinCarrito();

            if (linca.readLinCarrito(this))
            {
                return linca.eliminacionLinCarrito(this);
            }

            return false;
        }

        

        public DataSet ensenyarLinCarritoByCarrito(ENCarrito c)
        {
            CADLinCarrito linca = new CADLinCarrito();
            DataSet dat = new DataSet();

            if (c.readCarrito() == true)
            {
                dat = linca.ensenyarLinCarritoByCarrito(c);
            }

            return dat;
        }
    }
}