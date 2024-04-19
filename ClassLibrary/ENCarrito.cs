// @author:  Bruno Vilella Martínez; DNI: DNI000003
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class ENCarrito
    {
        /// <summary>
        /// Almacena el nombre del que compra
        /// </summary>
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// Almacena el identificador del Libro
        /// </summary>
        private int id_Book;

        public int Id_Book
        {
            get { return id_Book; }
            set { id_Book = value; }
        }

        /// <summary>
        /// Almacena las unidades que quiere comprar el usuario
        /// </summary>
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        /// <summary>
        /// Almacena la fecha de creacion
        /// </summary>
        private DateTime fecha;

        public DateTime fechaCreacion
        {
            get { return fecha; }
            set { fecha = value; }
        }

        /// <summary>
        /// Almacena el importe total
        /// </summary>
        private float importe;

        public float importeTotal
        {
            get { return importe; }
            set { importe = value; }
        }


        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ENCarrito()
        {
            UserName = "";
            Id_Book = -1;
            Cantidad = 0;
            fechaCreacion = DateTime.Now;
            importeTotal = 0;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ENCarrito(string nameUser, int book_id, int unidades, int a, int m, int d, DateTime fecha, float precio)
        {
            UserName = nameUser;
            Id_Book = book_id ;
            Cantidad = unidades;
            fechaCreacion = fecha;
            importeTotal = precio;
        }
        /// <summary>
        /// Constructor de copia.
        /// </summary>
        public ENCarrito(ENCarrito carrito)
        {
            UserName = carrito.UserName;
            Id_Book = carrito.Id_Book;
            Cantidad = carrito.Cantidad;
            fechaCreacion = carrito.fechaCreacion;
            importeTotal = carrito.importeTotal;
        }
        /// <summary>
        /// Crea un carrito, introduciendolo a la BBDD
        /// </summary>
        /// <returns>Devuelve true si se ha podido introducir</returns>
        public bool createCarrito()
        {
            bool creado = false;

            return creado;
        }
        public bool readCarrito()
        {
            bool creado = false;

            return creado;
        }
        public bool updateCarrito()
        {
            bool creado = false;

            return creado;
        }
        public bool deleteCarrito()
        {
            bool creado = false;

            return creado;
        }
    }
    
}
