using DOMINIO.ENTIDADES;
using DOMINIO.QUERYS;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using SqlKata.Execution;

namespace DATOS.QUERYS
{
    public class QueryComentario : IQueryComentario
    {
        private readonly IDbConnection conexion;
        private readonly Compiler SqlKataCompiler;

        public QueryComentario(IDbConnection conexion, Compiler SqlKataCompiler)
        {
            this.conexion = conexion;
            this.SqlKataCompiler = SqlKataCompiler;
        }
        public Comentario GetComentarioID(int comentarioID)
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            var comentario = db.Query("Comentarios").
               Select("Comentarios", "Fecha").
               Where("ID", "=", comentarioID).
               FirstOrDefault<Comentario>();

            return comentario;

        }

        public List<Comentario> GetComentario()
        {
            var db = new QueryFactory(conexion, SqlKataCompiler);
            var comentario = db.Query("Comentarios").
               Select("Comentarios", "Fecha").Get<Comentario>().ToList();

            return comentario;
        }
    }
}
