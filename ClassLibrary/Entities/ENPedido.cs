// @author:RAFAEL CARBALLO LORENZO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClassLibrary
{
    public class ENPedido
    {
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

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
            this.Precio = 0;
            this.Estado = " ";
        }

        public ENPedido(int numped, int id_usuario, int cod_carrito, string direccion_envio, float precio, string estado, DateTime date)
        {
            this.Numped = numped;
            this.Id_usuario = id_usuario;
            this.Cod_carrito = cod_carrito;
            this.Direccion_envio = direccion_envio;
            this.Precio = precio;
            this.Estado = estado;
            this.Date = date;
        }

        public bool crearPedido()
        {
            CADPedido cad = new CADPedido();
            return cad.crearPedido(this);
        }

        public bool cambiarEstado()
        {
            CADPedido cad = new CADPedido();
            return cad.cambiarEstado(this);
        }

        public List<ENPedido> verPedidos()
        {
            CADPedido cad = new CADPedido();
            return cad.verPedidos(this);
        }

        public StringBuilder graficaMetrica()
        {
            CADPedido cad = new CADPedido();
            return cad.graficaMetrica(this);
        }
    }
}
