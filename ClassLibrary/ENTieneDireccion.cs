// @author: Jorge Paredes Soler; DNI: DNI000007
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class ENTieneDireccion
    {
        private int idUsuario;
        private int idDireccion;

        public int IdUsuario { get { return idUsuario; } set { idUsuario = value; } }
        public int IdDireccion { get { return idDireccion; } set { idDireccion = value; } }

        public ENTieneDireccion()
        {

        }

        public ENTieneDireccion(int idUsuario, int idDireccion)
        {
            this.idUsuario = idUsuario;
            this.idDireccion = idDireccion;
        }
    }
}
