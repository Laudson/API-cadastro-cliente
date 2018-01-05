using System;

namespace LtjApi.Dominio
{
    public class Config
    {
		public static string CN { get; set; }
        public static AutoMapper.IMapper Mapper { get; set; }
        public static DateTime Agora { get { return DateTime.Now; } }
		public static DateTime Hoje { get { return DateTime.Today; } }

        public static IServiceProvider ServiceProvider { get; set; }
    }
}
