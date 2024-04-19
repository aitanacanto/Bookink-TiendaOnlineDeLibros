// @author: Darío Pastor Fuentes    ; DNI: DNI000004
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class ENLinPedido
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

        public ENLinPedido()
        {

        }

        public ENLinPedido(int id_pedido, int producto_id)
        {

        }

        public ENLinPedido(ENLinPedido en)
        {

        }

        public bool create()
        {
            return false;
        }

        public bool update()
        {
            return false;
        }

        public bool read()
        {
            return false;
        }

        public bool delete()
        {
            return false;
        }


    }

}
