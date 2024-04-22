// @author:  Bruno Vilella Martínez; DNI: DNI000003
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class ENLinCarrito
    {
        private int id_carrito;

        public int Id_Carrito
        {
            get { return id_carrito; }
            set { id_carrito = value; }
        }

        /// <summary>
        /// Almacena las unidades que quiere comprar el usuario
        /// </summary>
        private int id_producto;

        public int Id_Producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ENLinCarrito()
        {
            Id_Carrito = -1;
            Id_Producto = -1;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ENLinCarrito(int carrito_id, int producto_id)
        {
            Id_Carrito = carrito_id;
            Id_Producto = producto_id;
        }
        /// <summary>
        /// Constructor de copia.
        /// </summary>
        public ENLinCarrito(ENLinCarrito lincarrito)
        {
            Id_Carrito = lincarrito.id_carrito;
            Id_Producto = lincarrito.id_producto;
        }

        public bool createLinCarrito()
        {
            bool creado = false;

            return creado;
        }
        public bool readLinCarrito()
        {
            bool creado = false;

            return creado;
        }
        public bool updateLinCarrito()
        {
            bool creado = false;

            return creado;
        }
        public bool deleteLinCarrito()
        {
            bool creado = false;

            return creado;
        }
    }
}
