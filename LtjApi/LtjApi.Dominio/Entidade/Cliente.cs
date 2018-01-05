using LtjApi.Comum.Contratos;
using LtjApi.Dominio.Repositorios;
using System.Collections.Generic;

namespace LtjApi.Dominio.Entidades
{
    public class Cliente : EntidadeBase<Cliente, ClienteRepositorio>
    {
        public string Nome { get; set; }

        public static Cliente Salvar(ClienteDTO dto)
        {
            Cliente obj = null;
            if (dto.Codigo.HasValue)
                obj = Cliente.ObterAtivo(dto.Codigo.Value);

            if (obj == null)
                obj = new Cliente();

            obj.Nome = dto.Nome;
            obj.DataCadastro = Config.Agora;
            obj.Ativo = true;
            obj.Salvar();

            return obj;
        }

        public static List<Cliente> Listar(string titulo = null, int? qtdeResultados = null)
        {
            return Repositorio.ListarCliente(titulo, qtdeResultados);
        }
    }
}
