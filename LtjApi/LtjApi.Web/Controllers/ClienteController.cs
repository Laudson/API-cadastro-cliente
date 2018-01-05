using LtjApi.Comum.Contratos;
using LtjApi.Dominio;
using LtjApi.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LtjApi.Web.Controllers
{
    [Route("api/admin/[controller]")]
	public class ClienteController : Controller
	{
		[HttpGet("{codigo}")]
        public ClienteDTO Obter(int codigo)
		{
            return Cliente.Obter<ClienteDTO>(codigo);
		}

        [HttpGet("")]
        public List<ClienteDTO> Listar(string nome)
        {
            return Config.Mapper.Map<List<Cliente>, List<ClienteDTO>>(Cliente.Listar(nome));
        }

        [HttpPost("{codigo}")]
		public int Salvar([FromBody]ClienteDTO dto)
		{
            var entidade = Cliente.Salvar(dto);
			return entidade.Codigo;
		}

        [HttpDelete("{codigo}")]
        public void Excluir(int codigo)
		{
            Cliente.Excluir(codigo);
		}
	}
}
