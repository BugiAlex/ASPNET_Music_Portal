using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MusicPortal.BLL.Services;
using MusicPortal.BLL.Interfaces;

namespace ASP_NET_HW2_MusicPortal.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);      
            builder.RegisterType<SongService>().As<ISongService>();
            builder.RegisterType<GenreService>().As<IGenreService>();
            builder.RegisterType<UserService>().As<IUserService>();
            MusicPortal.BLL.Infrastructure.AutofacConfig.ConfigureContainer(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}