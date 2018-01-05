using AutoMapper;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using LtjAgro.Dominio.Mapeamento;
using LtjApi.Comum.Contratos;
using LtjApi.Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LtjApi.Dominio
{
    public static class Startup
    {

        public static void ConfigureServices(IServiceCollection service)
        {
            //Repositorios
            service.AddSingleton<Repositorios.RepositorioBase>();
            service.AddSingleton<Repositorios.ClienteRepositorio>();

            Config.ServiceProvider = service.BuildServiceProvider();
        }

        public static void Configure(IConfigurationRoot config)
        {
            // Conexão
            Config.CN = config.GetConnectionString("Default");

            ConfigureDatabaseMap();
            ConfigureObjectMap();
        }

        public static void ConfigureObjectMap()
        {
            // Mapeamento objetos
            Config.Mapper = new MapperConfiguration((configMap) =>
            {
                configMap.CreateMap<Cliente, ClienteDTO>();

            }).CreateMapper();
        }

        public static void ConfigureDatabaseMap()
        {
            // Mapeamentos bancos
            FluentMapper.Initialize(configFluent =>
                {
                    configFluent.AddMap(new ClienteMap());
                    configFluent.ForDommel();
                });
        }
    }
}