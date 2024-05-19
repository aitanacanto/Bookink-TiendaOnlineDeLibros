// @author: Alberto Boronat Lopez    ; DNI: DNI000005
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
        public class ENTieneCategoria
        {
            public int IdCategoria { get; set; }
            public int IdProducto { get; set; }

            public ENTieneCategoria(int idCategoria, int idProducto)
            {
                IdCategoria = idCategoria;
                IdProducto = idProducto;
            }

            public ENTieneCategoria()
            {
            }

            // Método para agregar una nueva relación
            public bool AddRelation()
            {
                CADTieneCategoria cad = new CADTieneCategoria();
                try
                {
                    cad.AddRelation(this);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al añadir relación: " + ex.Message);
                    return false;
                }
            }

            // Método para eliminar una relación
            public bool EliminateRelation()
            {
                CADTieneCategoria cad = new CADTieneCategoria();
                try
                {
                    cad.EliminateRelation(this);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar relación: " + ex.Message);
                    return false;
                }
            }

            // Método para obtener una relación por IDs
            public static ENTieneCategoria GetRelationById(int idCategoria, int idProducto)
            {
                CADTieneCategoria cad = new CADTieneCategoria();
                return cad.RelationById(idCategoria, idProducto);
            }

            // Método para obtener todas las relaciones de un producto
            public static List<ENTieneCategoria> GetRelationsByProduct(int idProducto)
            {
                CADTieneCategoria cad = new CADTieneCategoria();
                return cad.RelationByProduct(idProducto);
            }

            // Método para actualizar una relación
            public bool UpdateRelation(int newIdCategoria)
            {
                CADTieneCategoria cad = new CADTieneCategoria();
                try
                {
                    cad.UpdateRelation(this, newIdCategoria);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar relación: " + ex.Message);
                    return false;
                }
            }
        }
    }

