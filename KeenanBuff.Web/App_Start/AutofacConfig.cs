using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Extras.NLog;
using Autofac.Integration.Mvc;
using KeenanBuff.Common.Logger;
using KeenanBuff.Common.Logger.Interfaces;
using KeenanBuff.Common.SteamAPI;
using KeenanBuff.Entities.Context;
using KeenanBuff.Entities.Context.Interfaces;
using KeenanBuff.Common.Queries;
using KeenanBuff.Common.Queries.Interfaces;
using KeenanBuff.Entities.SteamAPI.Interfaces;
using KeenanBuff.Common.SteamAPI.Interfaces;

namespace KeenanBuff.Web
{
    public class AutofacConfig
    {
        public static void RegisterMvc()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterType<KeenanBuffContext>()
                .As<IKeenanBuffContext>()
                .InstancePerRequest();

            builder.RegisterType<FileLogger>()
                .As<IFileLogger>()
                .InstancePerRequest();

            builder.RegisterType<Queries>()
                .As<IQueries>()
                .InstancePerRequest();

            builder.RegisterType<SeedDatabase>()
                .As<ISeedDatabase>()
                .InstancePerRequest();

            builder.RegisterType<ApiCalls>()
                .As<IApiCalls>()
                .InstancePerRequest();

            builder.RegisterType<KeenanBuffRestClient>()
                .As<IKeenanBuffRestClient>()
                .InstancePerRequest();

            builder.RegisterModule<NLogModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}