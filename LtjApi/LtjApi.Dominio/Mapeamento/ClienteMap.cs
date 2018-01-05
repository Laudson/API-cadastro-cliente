using Dapper.FluentMap.Dommel.Mapping;
using LtjApi.Dominio.Entidades;

namespace LtjAgro.Dominio.Mapeamento
{
    public class ClienteMap : DommelEntityMap<Cliente>
    {
        public ClienteMap()
        {
            ToTable("cad_cliente");
            Map(x => x.Codigo).IsKey().IsIdentity();
            Map(x => x.Nome);
            Map(x => x.DataCadastro);
            Map(x => x.Ativo);
        }
    }
}
