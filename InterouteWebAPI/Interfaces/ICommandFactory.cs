using InterouteWebAPI.Enums;

namespace InterouteWebAPI.Interfaces
{
    internal interface ICommandFactory
    {
        ICommand Resolve(CommandEnum commandEnum, object[] args);
    }
}