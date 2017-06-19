using InterouteWebAPI.Enums;

namespace InterouteWebAPI.Interfaces
{
    public interface ICommandFactory
    {
        ICommand Resolve(CommandEnum commandEnum, object[] args);
    }
}