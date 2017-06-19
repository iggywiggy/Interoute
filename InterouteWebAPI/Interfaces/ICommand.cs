namespace InterouteWebAPI.Interfaces
{
    public interface ICommand
    {
        void Execute(object[] args);
    }
}