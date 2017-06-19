namespace InterouteWebAPI.Interfaces
{
    public interface ICommandWithResult<T> : ICommand
    {
        T Result { get; }
    }
}