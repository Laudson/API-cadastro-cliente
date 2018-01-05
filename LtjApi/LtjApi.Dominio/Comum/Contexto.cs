using System;
using System.Data;

namespace LtjApi.Dominio
{
    public class ContextoData
    {
		public IDbConnection Conexao { get; set; }
		public IDbTransaction Transacao { get; set; }
    }

    public class Contexto
    {

        public static ContextoData Inicializar(int codigoEmpresa, int codigoUsuario, IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            _instancia = new ContextoData();
			_instancia.Conexao = new MySql.Data.MySqlClient.MySqlConnection(Config.CN);
            _instancia.Conexao.Open(); 

            if (isolationLevel != IsolationLevel.Unspecified)
                _instancia.Transacao = _instancia.Conexao.BeginTransaction(isolationLevel);

            return _instancia;
        }

        public static void Encerrar(ContextoData instancia, bool ocorreuErro)
		{
			try
			{
				if (instancia.Conexao != null && instancia.Conexao.State != ConnectionState.Closed)
				{
					if (instancia.Transacao != null)
					{
						if (ocorreuErro)
							instancia.Transacao.Rollback();
						else
							instancia.Transacao.Commit();
					}
					instancia.Conexao.Close();
				}
			}
			finally
			{
				instancia = null;
			}
		}

        public static void Encerrar(bool ocorreuErro)
        {
            Encerrar(_instancia, ocorreuErro);
        }

        [ThreadStatic]
        private static ContextoData _instancia;

		public static ContextoData Instancia
        {
            get
            {
                return _instancia;
            }
		}
  
		public static IDbConnection Conexao
		{
			get
			{
				return _instancia.Conexao;
			}
		}

		public static IDbTransaction Transacao
		{
			get
			{
				return _instancia.Transacao;
			}
		}

        public static void SalvarErro(Exception ex)
        {
            
        }
    }
}
