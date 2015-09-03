using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Rikrop.Core.Framework.Logging;
using Rikrop.Core.Framework.Unity.Factories;
using Rikrop.Core.Wcf.Unity.ServerRegistration;
using System.Linq;
using System.Reflection;
using Rikrop.Core.Logging.NLog;

namespace WcfFileService
{
    public static class UnityServerRegistrator
    {
        public static void RegisterServerDependencies(this IUnityContainer container)
        {
            const string ip = "localhost";
            const int port = 5070;

            container
                .RegisterWcfHosting(ip, port)
                .RegisterFactories()
                .RegisterLogger("WcfFileService");
        }

        private static IUnityContainer RegisterWcfHosting(this IUnityContainer container, string serviceIp, int servicePort)
        {
            container
                .RegisterServerWcf(
                    o => o.RegisterServiceConnection(reg => reg.NetTcp(serviceIp, servicePort))
                          .RegisterServiceHostFactory(reg => reg.WithBehaviors().AddDependencyInjectionBehavior()));

            return container;
        }

        private static IUnityContainer RegisterFactories(this IUnityContainer container)
        {
            new[] { Assembly.GetExecutingAssembly(), typeof(FileTransferService).Assembly }
                .SelectMany(assembly => assembly.DefinedTypes.Where(type => type.Name == "ICtor"))
                .Where(type => !container.IsRegistered(type))
                .ForEach(container.RegisterFactory);

            return container;
        }

        private static IUnityContainer RegisterLogger(this IUnityContainer container, string logerName)
        {
            container.RegisterType<ILogger>(new ContainerControlledLifetimeManager(),
                new InjectionFactory(f =>
                {
                    try
                    {
                        return NLogger.CreateEventLogTarget(source: "Server", logName: logerName);
                    }
                    catch (Exception)
                    {
                        return NLogger.CreateEventLogTarget();
                    }
                }));

            return container;
        }
    }
}