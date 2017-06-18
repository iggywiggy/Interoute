namespace InterouteWebAPI.Commands
{
    public interface ICommandFactory
    {
        void Resolve(CommandEnum commandEnum, object[] args);
    }
}