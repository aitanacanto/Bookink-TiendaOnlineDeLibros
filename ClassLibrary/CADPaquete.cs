// @author: Aitana Cantó Rico;  DNI: DNI000001
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CADPaquete
    {
        private string constring;

        // Método para obtener un paquete por su ID desde la base de datos
        public ENPaquete ObtenerPaquetePorId(int idPaquete)
        {
            ENPaquete p = new ENPaquete();
            return p;
        }

        // Método para guardar un nuevo paquete en la base de datos
        public bool GuardarPaquete(ENPaquete paquete)
        {
            return false;
        }

        // Método para actualizar un paquete existente en la base de datos
        public bool ActualizarPaquete(ENPaquete paquete)
        {
            return false;
        }

        // Método para eliminar un paquete de la base de datos por su ID
        public bool EliminarPaquete(int idPaquete)
        {
            return false;
        }

        // Método para agregar un producto al paquete en la base de datos
        public bool AgregarProductoAlPaquete(int idPaquete, int idProducto)
        {
            return false;
        }

        // Método para eliminar un producto del paquete en la base de datos
        public bool EliminarProductoDelPaquete(int idPaquete, int idProducto)
        {
            return false;
        }
    }
}
