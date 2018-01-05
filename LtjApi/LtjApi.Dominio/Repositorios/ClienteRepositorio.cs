using Dapper;
using LtjApi.Dominio.Entidades;
using System.Collections.Generic;

namespace LtjApi.Dominio.Repositorios
{
    public class ClienteRepositorio : RepositorioBase
    {
        public List<Cliente> ListarCliente(string nome = null, int? qtdeResultados = null)
        {
            var sql = @"SELECT *
                    FROM cad_cliente 
                    WHERE Ativo = 1 
					ORDER BY 1 DESC";

            if (!string.IsNullOrEmpty(nome))
            {
                sql += " and Nome like @nome";
                nome = string.Format("%{0}%", nome);
            }

            if (qtdeResultados.HasValue)
                sql = string.Concat(sql, " LIMIT ", qtdeResultados);

            return Contexto.Conexao.Query<Cliente>(sql, new { Nome = nome }, Contexto.Transacao).AsList();
        }

    }
}
