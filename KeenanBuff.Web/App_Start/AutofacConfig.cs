using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using KeenanBuff.Common.Logger;
using KeenanBuff.Common.Logger.Interfaces;
using KeenanBuff.Entities.Context;
using KeenanBuff.Entities.Context.Interfaces;

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

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}