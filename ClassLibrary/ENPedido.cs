// @author:RAFAEL CARBALLO LORENZO; DNI:DNI000002
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class ENPedido
    {
        private int numped;
        public int Numped
        {
            get { return numped; }
            set { numped = value; }
        }

        private int id_usuario;
        public int Id_usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        private int cod_carrito;
        public int Cod_carrito
        {
            get { return cod_carrito; }
            set { cod_carrito = value; }
        }

        private string direccion_envio;
        public string Direccion_envio
        {
            get { return direccion_envio; }
            set { direccion_envio = value; }
        }

        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private float precio;
        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public ENPedido()
        {
            this.Numped = 0;
            this.Id_usuario = 0;
            this.Cod_carrito = 0;
            this.Direccion_envio = " ";
            this.Cantidad = 0;
            this.Precio = 0;
            this.Estado = " ";
        }

        public ENPedido(int numped, int id_usuario, int cod_carrito, string direccion_envio, int cantidad, float precio, string estado)
        {
            this.Numped = numped;
            this.Id_usuario = id_usuario;
            this.Cod_carrito = cod_carrito;
            this.Direccion_envio = direccion_envio;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Estado = estado;
        }

        public bool crearPedido()
        {
            CADPedido cad = new CADPedido();
            return cad.crearPedido();
        }
    }
}
