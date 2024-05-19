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
    public int Id { get; set; }
    public string Nombre { get; set; }

    public bool Add()
    {
        CADCategoria cad = new CADCategoria();
        return cad.AddCategory(this.Nombre);
    }

    public bool Delete()
    {
        CADCategoria cad = new CADCategoria();
        return cad.DeleteCategory(this.Id);
    }

    public List<ENCategoria> GetAllCategories()
    {
        CADCategoria cad = new CADCategoria();
        return cad.GetAllCategories();
    }
}
}