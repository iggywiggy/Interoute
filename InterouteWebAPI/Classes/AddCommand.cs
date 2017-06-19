using InterouteWebAPI.Interfaces;
using InterouteWebAPI.Processors;

namespace InterouteWebAPI.Classes
{
    public class AddCommand : ICommandWithResult<long>
    {
        private readonly IAddProcessor _addProcessor;

        public AddCommand(IAddProcessor addProcessor)
        {
            _addProcessor = addProcessor;
        }

        public long Result { get; private set; }

        public void Execute(object[] args)
        {
            var result = _addProcessor.Add((long) args[0], (long) args[1]);
            Result = result;
        }
    }
}