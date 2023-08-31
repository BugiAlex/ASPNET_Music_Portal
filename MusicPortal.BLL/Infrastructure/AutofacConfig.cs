using Autofac;
using MusicPotal.DAL.Interfaces;
using MusicPotal.DAL.Repositories;


namespace MusicPortal.BLL.Infrastructure
{
    public class AutofacConfig
    {
        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter("connectionString", "MusicPortal");
        }
    }
}
