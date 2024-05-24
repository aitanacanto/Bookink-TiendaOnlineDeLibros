// @author: Darío Pastor Fuentes    ; DNI: DNI000004
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ENLinPedido
    {
        private int id_pedido;
        public int Id_Pedido
        {
            get { return id_pedido; }
            set { id_pedido = value; }
        }

        private int id_producto;
        public int Id_Producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }

        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public ENLinPedido()
        {

        }

        public ENLinPedido(int id_pedido, int producto_id,int cant)
        {
            Id_Pedido = id_pedido;
            Id_Producto = producto_id;
            cantidad = cant;
        }

        public ENLinPedido(ENLinPedido en)
        {

        }

        public bool create()
        {
            CADLinPedido c = new CADLinPedido();

            return c.create(this);
        }

        public bool update()
        {
            CADLinPedido c = new CADLinPedido();

            return c.update(this);
        }

        public bool read()
        {
            CADLinPedido c = new CADLinPedido();

            return c.read(this);
        }

        public List<ENLinPedido> readALL()
        {
            CADLinPedido c = new CADLinPedido();

            return c.readALL(this);
        }

        public bool delete()
        {
            CADLinPedido c = new CADLinPedido();

            return c.delete(this);
        }


    }

}
