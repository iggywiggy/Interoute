using System;
using InterouteWebAPI.Classes.Commands;
using InterouteWebAPI.Classes.Processor;
using InterouteWebAPI.Infastructure;
using InterouteWebAPI.Interfaces;
using log4net.Config;
using Ninject;

namespace InterouteWebAPI
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            AddBindings(container);
        }

        private static void AddBindings(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            ConfigureLog4Net(container);
            ConfigureCommands(container);
            ConfigureProcessors(container);
        }

        private static void ConfigureCommands(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            container.Bind<ICommandFactory>().To<CommandFactory>();
            container.Bind<ICommandWithResult<long>>().To<AddCommand>().Named("AddCommand");
            container.Bind<ICommandWithResult<string>>().To<ReadLogFileCommand>().Named("ReadFileCommand");
        }

        private static void ConfigureProcessors(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            container.Bind<IAddProcessor>().To<AddProcessor>();
            container.Bind<IReadFileProcessor>().To<ReadFileProcessor>();
        }

        private static void ConfigureLog4Net(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            XmlConfigurator.Configure();

            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }
    }
}