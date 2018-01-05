using System;

namespace LtjApi.Dominio.Entidades
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {
            this.DataCadastro = Config.Agora;
            this.Ativo = true;
        }
        public int Codigo { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

    }
}
