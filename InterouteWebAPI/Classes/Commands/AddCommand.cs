using System;
using InterouteWebAPI.Interfaces;

namespace InterouteWebAPI.Classes.Commands
{
    public class AddCommand : ICommandWithResult<long>
    {
        private readonly IAddProcessor _addProcessor;

        public AddCommand(IAddProcessor addProcessor)
        {
            _addProcessor = addProcessor ?? throw new ArgumentNullException(nameof(addProcessor));
        }

        public long Result { get; private set; }

        public void Execute(object[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var result = _addProcessor.Add((long) args[0], (long) args[1]);
            Result = result;
        }
    }
}