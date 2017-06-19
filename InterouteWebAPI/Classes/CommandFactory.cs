using System;
using System.Collections.Generic;
using InterouteWebAPI.Enums;
using InterouteWebAPI.Interfaces;
using Microsoft.Practices.Unity;

namespace InterouteWebAPI.Classes
{
    public class CommandFactory : ICommandFactory
    {
        private IDictionary<CommandEnum, Type> _commandsDictionary;

        public CommandFactory()
        {
            RegisterCommands();
        }

        public ICommand Resolve(CommandEnum commandEnum, object[] args)
        {
            var commandType = _commandsDictionary[commandEnum];

            return DiContainer.Instance.Container.Resolve<ICommand>(commandType.Name);
        }

        private void RegisterCommands()
        {
            _commandsDictionary = new Dictionary<CommandEnum, Type>
            {
                {
                    CommandEnum.Add, typeof(AddCommand)
                }
            };
        }
    }
}