// @author: Aitana Cantó Rico;  DNI: DNI000001
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
        public ENTienePaquete(int idPaquete, int idProducto)
        {
            IdPaquete = idPaquete;
            IdProducto = idProducto;
        }
    }

}

