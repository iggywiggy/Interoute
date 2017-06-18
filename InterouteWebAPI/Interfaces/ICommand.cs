namespace InterouteWebAPI.Interfaces
{
    internal interface ICommand
    {
        void Execute(object[] args);
    }
}