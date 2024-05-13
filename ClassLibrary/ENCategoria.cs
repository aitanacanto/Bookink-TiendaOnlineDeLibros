// @author:   ALBERTO BORONAT lOPEZ  ; DNI: DNI000005
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ENCategoria
    {
        // Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ENCategoria()
        {
        }

        public ENCategoria(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }


        // Agregar una nueva categoría
        public bool Add()
        {
            CADCategoria cad = new CADCategoria();
            return cad.AddCategory(this);
        }

        // Actualizar una categoría existente
        public bool Update()
        {
            CADCategoria cad = new CADCategoria();
            return cad.UpdateCategory(this);
        }

        // Eliminar una categoría
        public bool Delete()
        {
            CADCategoria cad = new CADCategoria();
            return cad.DeleteCategory(this);
        }

    }
}
