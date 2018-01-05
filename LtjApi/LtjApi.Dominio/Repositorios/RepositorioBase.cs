using Dapper;
using LtjApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Dommel.DommelMapper;

namespace LtjApi.Dominio.Repositorios
{
    public class RepositorioBase
    {
        public T Obter<T>(int codigo) where T : EntidadeBase
        {
            return Dommel.DommelMapper.Get<T>(Contexto.Conexao, codigo);
        }

        public void Excluir<T>(int codigo) where T : EntidadeBase
        {
            Dommel.DommelMapper.DeleteMultiple<T>(Contexto.Conexao, i => i.Codigo == codigo, Contexto.Transacao);
        }

        public void Excluir<T>(T entidade) where T : EntidadeBase
        {
            Dommel.DommelMapper.Delete<T>(Contexto.Conexao, entidade, Contexto.Transacao);
        }

        public void Excluir<T>(Expression<Func<T, bool>> filtro) where T : EntidadeBase
        {
            Dommel.DommelMapper.DeleteMultiple<T>(Contexto.Conexao, filtro, Contexto.Transacao);
        }

        public void Inserir<T>(T entidade) where T : EntidadeBase
        {
            var codigo = Dommel.DommelMapper.Insert<T>(Contexto.Conexao, entidade, Contexto.Transacao);
            entidade.Codigo = Convert.ToInt32(codigo);
        }
        public void Atualizar<T>(T entidade) where T : EntidadeBase
        {
            Dommel.DommelMapper.Update<T>(Contexto.Conexao, entidade, Contexto.Transacao);
        }

        public List<T> Listar<T>(Expression<Func<T, bool>> filtro) where T : EntidadeBase
        {
            return Dommel.DommelMapper.Select<T>(Contexto.Conexao, filtro).AsList<T>();
        }

        public int Contar<T>(Expression<Func<T, bool>> filtro) where T : EntidadeBase
        {
            var tableName = Resolvers.Table(typeof(T));

            var sql = $"SELECT COUNT(1) FROM {tableName} ";

            DynamicParameters parameters;
            sql += new SqlExpression<T>().Where(filtro).ToSql(out parameters);

            var result = Contexto.Conexao.ExecuteScalar(sql, parameters, Contexto.Transacao);

            return Convert.ToInt32(result);
        }
    }
}
