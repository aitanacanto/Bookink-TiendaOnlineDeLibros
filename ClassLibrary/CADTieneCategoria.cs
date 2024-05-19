//@author: Alberto Boronat López DNI000005

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibrary
{
    class CADTieneCategoria
    {
        private string connectionString;

        public CADTieneCategoria()
        {
            connectionString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        }

        public void AddRelation(ENTieneCategoria tiene)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO TIENE_CATEGORIA (id_categoria, id_producto) VALUES (@idCategoria, @idProducto)", connection);
                cmd.Parameters.AddWithValue("@idCategoria", tiene.IdCategoria);
                cmd.Parameters.AddWithValue("@idProducto", tiene.IdProducto);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminateRelation(ENTieneCategoria tiene)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM TIENE_CATEGORIA WHERE id_categoria = @idCategoria AND id_producto = @idProducto", connection);
                cmd.Parameters.AddWithValue("@idCategoria", tiene.IdCategoria);
                cmd.Parameters.AddWithValue("@idProducto", tiene.IdProducto);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ENTieneCategoria RelationById(int idCategoria, int idProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM TIENE_CATEGORIA WHERE id_categoria = @idCategoria AND id_producto = @idProducto", connection);
                cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new ENTieneCategoria
                    {
                        IdCategoria = Convert.ToInt32(reader["id_categoria"]),
                        IdProducto = Convert.ToInt32(reader["id_producto"])
                    };
                }
                return null;
            }
        }

        public List<ENTieneCategoria> RelationByProduct(int idProducto)
        {
            List<ENTieneCategoria> relations = new List<ENTieneCategoria>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM TIENE_CATEGORIA WHERE id_producto = @idProducto", connection);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    relations.Add(new ENTieneCategoria
                    {
                        IdCategoria = Convert.ToInt32(reader["id_categoria"]),
                        IdProducto = Convert.ToInt32(reader["id_producto"])
                    });
                }
                return relations;
            }
        }

        public void UpdateRelation(ENTieneCategoria tiene, int newIdCategoria)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE TIENE_CATEGORIA SET id_categoria = @newIdCategoria WHERE id_categoria = @idCategoria AND id_producto = @idProducto", connection);
                cmd.Parameters.AddWithValue("@newIdCategoria", newIdCategoria);
                cmd.Parameters.AddWithValue("@idCategoria", tiene.IdCategoria);
                cmd.Parameters.AddWithValue("@idProducto", tiene.IdProducto);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
