using LtjApi.Dominio.Repositorios;

namespace LtjApi.Dominio.Entidades
{
    public class EntidadeBase<T, R> : EntidadeBase<T> where T : EntidadeBase where R : RepositorioBase
    {
        protected static new R Repositorio
        {
            get
            {
                return Config.ServiceProvider.GetService(typeof(R)) as R;
            }
        }
    }
}