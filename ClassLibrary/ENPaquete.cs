// @author: Aitana Cantó Rico;  DNI: DNI000001
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ENPaquete
    {
        public int IdPaquete { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public List<ENProducto> Productos { get; set; } // Lista de productos en el paquete

        // Constructor
        public ENPaquete()
        {
            this.Productos = new List<ENProducto>();
            this.Nombre = "";
            this.Precio = 0;

        }

        public ENPaquete(int idPaquete, string nombre, float precio, List<ENProducto> productos)
        {
            IdPaquete = idPaquete;
            Nombre = nombre;
            Precio = precio;
            Productos = new List<ENProducto>(productos);
        }

        public bool anyadirPaquete()
        {
            CADPaquete cad = new CADPaquete();
            return cad.anyadirPaquete(this);
        }

        public void eliminarPaquete()
        {

        }

        public ENPaquete ObtenerPaquetePorId(ENPaquete paquete)
        {
            return paquete;
        }


        public bool GuardarPaquete(int idPaquete, string nombre, float precio)
        {
            return false;
        }


        public bool ActualizarPaquete(ENPaquete paquete)
        {
            return false;
        }


        public bool EliminarPaquete(ENPaquete paquete)
        {
            return false;
        }


        public bool AgregarProductoAlPaquete(ENPaquete paquete)
        {
            return false;
        }


        public bool EliminarProductoDelPaquete(int idPaquete, int idProducto)
        {
            return false;
        }
    }
}
