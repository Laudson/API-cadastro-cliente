using LtjApi.Comum.Contratos;
using LtjApi.Dominio;
using LtjApi.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Inicializa
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultado = Config.Mapper.Map<List<Cliente>, List<ClienteDTO>>(Cliente.Listar("isso"));
            Console.WriteLine("{0} - {1} - {2} ", "Código", "Nome do Contato");
            foreach (dynamic cliente in resultado)
            {
                Console.WriteLine("{0} - {1} - {2} ", cliente.CustomerID, cliente.ContactName, cliente.Address);
            }
        }
    }
}
