using LtjApi.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LtjApi.Dominio.Entidades
{
    public class EntidadeBase<T> : EntidadeBase where T : EntidadeBase
    {
        protected static RepositorioBase Repositorio
        {
            get
            {
                return Config.ServiceProvider.GetService(typeof(RepositorioBase)) as RepositorioBase;
            }
        }

        public static TDTO Obter<TDTO>(int codigo) where TDTO : class
        {
            var entidade = Repositorio.Obter<T>(codigo);
            return entidade != null ? Config.Mapper.Map<TDTO>(entidade) : null;
        }

        public static TDTO ObterAtivo<TDTO>(int codigo) where TDTO : class
        {
            return Obter<TDTO>(i => i.Codigo == codigo && i.Ativo);
        }

        public static TDTO Obter<TDTO>(Expression<Func<T, bool>> filtro) where TDTO : class
        {
            var entidades = Repositorio.Listar<T>(filtro);
            return entidades != null ? Config.Mapper.Map<TDTO>(entidades.FirstOrDefault()) : null;
        }

        public static List<TDTO> ListarAtivos<TDTO>() where TDTO : class
        {
            return EntidadeBase<T>.Listar<TDTO>(i => i.Ativo);
        }

        public static List<TDTO> Listar<TDTO>(Expression<Func<T, bool>> filtro) where TDTO : class
        {
            var entidades = Repositorio.Listar<T>(filtro);
            return entidades != null ? Config.Mapper.Map<List<TDTO>>(entidades) : null;
        }

        public static int Contar(Expression<Func<T, bool>> filtro)
        {
            return Repositorio.Contar<T>(filtro);
        }

        public static T Obter(int codigo)
        {
            return Repositorio.Obter<T>(codigo);
        }

        public static T Obter(Expression<Func<T, bool>> filtro)
        {
            var entidades = Repositorio.Listar<T>(filtro);
            return entidades != null ? entidades.FirstOrDefault() : null;
        }

        public static T ObterAtivo(int codigo)
        {
            return Obter(i => i.Codigo == codigo && i.Ativo);
        }

        public static List<T> ListarAtivos()
        {
            return Listar(i => i.Ativo);
        }

        public static List<T> Listar(Expression<Func<T, bool>> filtro)
        {
            return Repositorio.Listar<T>(filtro);
        }

        public static void Excluir(int codigo)
        {
            Repositorio.Excluir<T>(codigo);
        }

        public static void Excluir(T entidade)
        {
            Repositorio.Excluir<T>(entidade);
        }

        public static void Excluir(Expression<Func<T, bool>> filtro)
        {
            Repositorio.Excluir<T>(filtro);
        }

        public void Salvar()
        {
            if (this.Codigo == 0)
                Repositorio.Inserir<T>(this as T);
            else
                Repositorio.Atualizar<T>(this as T);
        }

        public void Excluir()
        {
            this.Ativo = false;
            if (this.Codigo > 0)
                this.Salvar();
        }
    }
}
