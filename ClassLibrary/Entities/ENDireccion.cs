// @author: Jorge Paredes Soler
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ENDireccion
    {
        private int id;
        private string cod_postal;
        private string direccion;
        private string ciudad;
        private string pais;

        public int ID { get { return id; } set { id = value; } }
        public string CodPostal { get { return cod_postal; } set { cod_postal = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public string Ciudad { get { return ciudad; } set { ciudad = value; } }
        public string Pais { get { return pais; } set { pais = value; } }

        public ENDireccion()
        {

        }

        public ENDireccion(int id, string cod_postal, string direccion, string ciudad, string pais)
        {
            this.id = id;
            this.cod_postal = cod_postal;
            this.direccion = direccion;
            this.ciudad = ciudad;
            this.pais = pais;
        }

        public ENDireccion(string cod_postal, string direccion, string ciudad, string pais)
        {
            this.id = 0;
            this.cod_postal = cod_postal;
            this.direccion = direccion;
            this.ciudad = ciudad;
            this.pais = pais;
        }

        public bool Create()
        {
            CADDireccion cadDireccion = new CADDireccion();
            return cadDireccion.AñadirDireccion(this);
        }

        public bool Read()
        {
            CADDireccion cadDireccion = new CADDireccion();
            return cadDireccion.LeerDireccion(this);
        }

        public bool Update()
        {
            CADDireccion cadDireccion = new CADDireccion();
            return cadDireccion.ModificarDireccion(this);
        }

        public bool Delete()
        {
            CADDireccion cadDireccion = new CADDireccion();
            return cadDireccion.EliminarDireccion(this);
        }

        public List<ENCategoria> GetAllCategories()
        {
            CADCategoria cad = new CADCategoria();
            return cad.GetAllCategories();
        }
    }
}