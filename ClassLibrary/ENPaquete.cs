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
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public List<ENProducto> Productos { get; set; } // Lista de productos en el paquete

        // Constructor
        public ENPaquete()
        {
            Productos = new List<ENProducto>();
        }

        public ENPaquete(int idPaquete, string nombre, string descripcion, decimal precio)
        {
            IdPaquete = idPaquete;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Productos = new List<ENProducto>();
        }
    }
}
