using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;



namespace ClassLibrary
{
    public class ENCarrito
    {
        private int _id;
        private int _id_usuario;
        private float _importe_total;
        private List<ENLinCarrito> _listLinCar = new List<ENLinCarrito>();
        public int id
        {
            get { return _id; }
            set { actualizarIdCarritoLineas(value); }
        }


        public int id_usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }

        public float importe_total
        {
            get { return _importe_total; }
            set { _importe_total = value; }
        }


        public ENCarrito()
        {
            this.id = 0;
            this.id_usuario = 0;
            this.importe_total = 0;
        }

        public ENCarrito(int id_usuario)
        {
            this.id = 0;
            this.id_usuario = id_usuario;
            this.importe_total = 0;

            CADCarrito carr = new CADCarrito();
            int id_carrito = carr.buscarIdCarrito(this.id_usuario);
            if (id_carrito == 0)
            {
                carr.creacionCarrito(this);
            }
            else
            {
                id = id_carrito;
                carr.cargarCarrito(this);
                ENLinCarrito linca = new ENLinCarrito();
                this._listLinCar = linca.cargarLineasCarrito(id);
            }
        }

        private void actualizarIdCarritoLineas(int id_carrito)
        {
            _id = id_carrito;
            foreach (ENLinCarrito linea in _listLinCar)
            {
                linea.id_carrito = id_carrito;
            }
        }

        public bool insertarCarrito()
        {
            CADCarrito carr = new CADCarrito();

            int id_carrito = carr.buscarIdCarrito(this.id_usuario);
            if (id_carrito == 0)
            {
                if (carr.creacionCarrito(this))
                {

                    foreach (ENLinCarrito linea in _listLinCar)
                    {
                            linea.insertarLinea();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                id = id_carrito;
                foreach (ENLinCarrito linea in _listLinCar)
                {
                    linea.insertarLinea();
                }
                return true;
            }


        }


        private ENLinCarrito existeProducto(ENProducto pro)
        {
            foreach (ENLinCarrito lincar in _listLinCar)
            {
                if (lincar.producto.Id == pro.Id)
                {
                    return lincar;
                }
            }

            return null;

        }

        public void anyadirProductoCarrito(int id_pro)
        {

            ENProducto pro = new ENProducto(id_pro);
            pro.Read();
            ENLinCarrito linca = existeProducto(pro);
            if (linca == null)
            {
                linca = new ENLinCarrito(this.id, pro, 1);
                _listLinCar.Add(linca);
                if (this.id_usuario != 0)
                {
                    linca.insertarLinea();
                }
            }
            else
            {
                linca.incrementarCantidad();
                if (this.id_usuario != 0)
                {
                    linca.actualizarLinea();
                }
            }
        }
        public void eliminarProductoCarrito(int id_pro)
        {
            ENProducto pro = new ENProducto(id_pro);
            pro.Read();
            ENLinCarrito linca = existeProducto(pro);
            if (linca.decrementarCantidad())
            {
                linca.eliminarLinea();
                _listLinCar.Remove(linca);
            }
            else
            {
                if (this.id_usuario != 0)
                {
                    linca.actualizarLinea();
                }
            }
        }


        public bool readCarrito()
        {

            CADCarrito carr = new CADCarrito();
            if (carr.readCarrito(this))
            {
                ENLinCarrito linca = new ENLinCarrito();
                _listLinCar.Clear();
                _listLinCar = linca.cargarLineasCarrito(id);
                return true;
            }
            return false;
        }

        public bool readCarritoUsuario(ENUsuario user)
        {
            CADCarrito carr = new CADCarrito();
            return carr.readCarritoUsuario(this, user);
        }


        public bool deleteCarrito()

        {
            CADCarrito carr = new CADCarrito();
            _listLinCar.Clear();
            return carr.deleteCarrito(this);
        }
        public bool vaciarCarrito()
        {
            CADCarrito carr = new CADCarrito();

            if (carr.readCarrito(this))
            {
                return carr.vaciarCarrito(this);
            }

            return false;
        }
        /*
        public DataSet ensenyarCarritoUsuario(ENUsuario user)
        {
            
            DataSet dat = new DataSet();

            if (user.readUsuario() == true)
            {
                CADCarrito carr = new CADCarrito();
                dat = carr.ensenyarCarritoUsuario(user);
            }
            return dat;
            
        }
        */

        public DataSet listarCarritos()
        {
            CADCarrito carr = new CADCarrito();
            DataSet dat = carr.listandoCarritos();
            return dat;
        }

        public ENLinCarrito obtenerLineaProducto(int id_producto)
        {
            foreach (ENLinCarrito linea in _listLinCar)
            {
                if (linea.producto.Id == id_producto)
                {
                    return linea;
                }
            }
            return null;
        }

        public List<ENLinCarrito> ObtenerProductosEnCarrito()
        {
            return _listLinCar;
        }
        public int ContarProductosEnCarrito()
        {
            int total_productos = 0;
            foreach (ENLinCarrito linea in _listLinCar)
            {
                total_productos += linea.cantidad;
            }
            return total_productos;
        }
        public float CalcularPvp()
        {
            float total_pvp = 0;
            foreach (ENLinCarrito linea in _listLinCar)
            {
                total_pvp += linea.pvp;
            }
            return total_pvp;
        }
    }
}
