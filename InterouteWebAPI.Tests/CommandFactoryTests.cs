using System;
using InterouteWebAPI.Enums;
using InterouteWebAPI.Interfaces;
using NUnit.Framework;

namespace InterouteWebAPI.Tests
{
    [TestFixture]
    public class CommandFactoryTests
    {
        private ICommandFactory _commandFactory;

        [TestCase(CommandEnum.Add, new object[] { }, ExpectedResult = typeof(IAddCommandProcessor))]
        public Type ResolveCommand_Command_Enum_CorrectCommand_Returned(CommandEnum commandEnum, object[] args)
        {
            return _commandFactory.Resolve(commandEnum, args).GetType();
        }

        [Test]
        public void ResolveCommand_Args_Parameter_Null_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _commandFactory.Resolve(CommandEnum.Add, null));
        }
    }
}