// @author:RAFAEL CARBALLO LORENZO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class ENLinPedido_pa
    {
        private int id_paquete;
        public int Id_Paquete
        {
            get { return id_paquete; }
            set { id_paquete = value; }
        }

        private int id_pedido;
        public int Id_Pedido
        {
            get { return id_pedido; }
            set { id_pedido = value; }
        }

        public ENLinPedido_pa()
        {
            this.Id_Paquete = 0;
            this.Id_Pedido = 0;
        }

        public ENLinPedido_pa(int id_paquete, int id_pedido)
        {
            this.Id_Paquete = id_paquete;
            this.Id_Pedido = id_pedido;
        }

        public bool create()
        {
            CADLinPedido_pa cad = new CADLinPedido_pa();
            return cad.create(this);
        }

        public bool update()
        {
            CADLinPedido_pa cad = new CADLinPedido_pa();
            return cad.update(this);
        }

        public bool read()
        {
            CADLinPedido_pa cad = new CADLinPedido_pa();
            return cad.read(this);
        }

        public bool delete()
        {
            CADLinPedido_pa cad = new CADLinPedido_pa();
            return cad.delete(this);
        }
    }
}
