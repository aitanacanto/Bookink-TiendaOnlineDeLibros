// @author: Aitana Cantó Rico
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ENTienePaquete
    {
        public int IdPaquete { get; set; }
        public int IdProducto { get; set; }

        // Constructor
        public ENTienePaquete()
        {
        }

        public ENTienePaquete(int idPaquete, int idProducto)
        {
            IdPaquete = idPaquete;
            IdProducto = idProducto;
        }

        public bool AgregarProductoAlPaquete(int idPaquete, int idProducto)
        {
            CADTienePaquete cad = new CADTienePaquete();
            return cad.AgregarProductoAlPaquete(idPaquete, idProducto);
        }

        public bool EliminarProductoDelPaquete(int idPaquete, int idProducto)
        {
            CADTienePaquete cad = new CADTienePaquete();
            return cad.EliminarProductoDelPaquete(idPaquete, idProducto);
        }
    }

}

