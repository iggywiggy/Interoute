using System;
using InterouteWebAPI.Interfaces;
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
        }

        public ICommandFactory ResolveCommandFactory()
        {
            return Container.Resolve<ICommandFactory>();
        }
    }
}