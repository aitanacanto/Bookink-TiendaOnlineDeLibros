// @author: Jorge Paredes Soler; DNI: DNI000007
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ENTieneDireccion
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

        public bool Create()
        {
            CADTieneDireccion cadTieneDireccion = new CADTieneDireccion();
            return cadTieneDireccion.AgregarRelacion(this);
        }
       
        public bool Delete()
        {
            CADTieneDireccion cadTieneDireccion = new CADTieneDireccion();
            return cadTieneDireccion.EliminarRelacion(this);
        }

    }
}
