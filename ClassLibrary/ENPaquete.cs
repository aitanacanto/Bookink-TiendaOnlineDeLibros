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
        public string Img_paquete { get; set; }
        public List<ENProducto> Productos { get; set; } // Lista de productos en el paquete


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

        public bool CrearPaquete()
        {
            CADPaquete cad = new CADPaquete();
            return cad.CrearPaquete(this);
        }

        public bool leerPaquete()
        {
            CADPaquete cad = new CADPaquete();
            return cad.leerPaquete(this);
        }

        public bool ActualizarPaquete()
        {
            CADPaquete cad = new CADPaquete();
            return cad.ActualizarPaquete(this);
        }


        public bool EliminarPaquete()
        {
            CADPaquete cad = new CADPaquete();
            return cad.EliminarPaquete(this);
        }

        public List<ENPaquete> ObtenerTodosLosPaquetes()
        {
            CADPaquete cad = new CADPaquete();
            return cad.ObtenerTodosLosPaquetes();
        }
    }
}
