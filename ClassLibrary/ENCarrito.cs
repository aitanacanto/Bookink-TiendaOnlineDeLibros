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
        private List<ENLinCarrito> _listLinCar;
        public int id
        {
            get { return _id; }
            set { _id = value; }
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
            this._listLinCar = new List<ENLinCarrito>();
        }

        public ENCarrito(int id, int id_usuario, float importe_total)
        {
            this.id = id;
            this.id_usuario = id_usuario;
            this.importe_total = importe_total;
            this._listLinCar = new List<ENLinCarrito>();
        }

        public bool creacionCarrito()
        {
            CADCarrito carr = new CADCarrito();
            ENUsuario user = new ENUsuario();

            if (carr.readCarrito(this) != true)
            {
                return carr.creacionCarrito(this);
            }

            return false;
        }

        public DataSet ensenyarCarrito()
        {
            CADCarrito carr = new CADCarrito();
            DataSet dat = carr.ensenyarCarrito(this);
            return dat;
        }


        public bool actualizacionCarrito()
        {
            CADCarrito carr = new CADCarrito();

            if (carr.readCarrito(this))
            {
                return carr.actualizacionCarrito(this);
            }

            return false;
        }
        private ENLinCarrito existeProducto(ENProducto pro)
        {
            foreach ( ENLinCarrito lincar in _listLinCar )
            {
                if (lincar.id_producto == pro.Id)
                {
                    return lincar;
                }
            }

            return null;

        }

        public void anyadirProductoCarrito(int id_pro)
        {
            ENProducto pro;
            ENLinCarrito linca = existeProducto(pro);
            if (linca == null)
            {
                linca = new ENLinCarrito(this.id, pro.Id, 1, pro.Price);
                _listLinCar.Add(linca);
            }
            else
            {
                linca.incrementarCantidad();
            }
        }
        public bool readCarrito()
        {
            CADCarrito carr = new CADCarrito();
            return carr.readCarrito(this);
        }

        public bool readCarritoUsuario(ENUsuario user)
        {
            CADCarrito carr = new CADCarrito();
            return carr.readCarritoUsuario(this, user);
        }


        public DataSet eliminacionCarrito(int id)

        {
            CADCarrito carr = new CADCarrito();
            DataSet dat = carr.eliminacionCarrito(this, id);

            if (carr.readCarrito(this))
            {
                dat = carr.eliminacionCarrito(this, id);
            }

            return dat;
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
    }
}
