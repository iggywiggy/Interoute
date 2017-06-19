using System;
using InterouteWebAPI.Infastructure;
using InterouteWebAPI.Interfaces;
using InterouteWebAPI.Processors;
using Microsoft.Practices.Unity;

namespace InterouteWebAPI.Classes
{
    public sealed class DiContainer : IDisposable
    {
        private static DiContainer _instance;

        public static DiContainer Instance = _instance ?? (_instance = new DiContainer());

        private DiContainer()
        {
            Container = new UnityContainer();
            RegisterTypes();
        }

        public IUnityContainer Container { get; }

        public void Dispose()
        {
            Container?.Dispose();
        }

        private void RegisterTypes()
        {
            Container.RegisterType<ICommandFactory, CommandFactory>();
            Container.RegisterType<ICommandWithResult<long>, AddCommand>("AddCommand");
            Container.RegisterType<IAddProcessor, AddProcessor>();
            ConfigureLog4Net();
        }

        private void ConfigureLog4Net()
        {
            var logManager = new LogManagerAdapter();
            Container.RegisterInstance<ILogManager>(logManager);
        }
    }
}