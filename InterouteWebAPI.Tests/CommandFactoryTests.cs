using System;
using InterouteWebAPI.Classes;
using InterouteWebAPI.Enums;
using InterouteWebAPI.Interfaces;
using InterouteWebAPI.Processors;
using Moq;
using NUnit.Framework;

namespace InterouteWebAPI.Tests
{
    [TestFixture]
    public class CommandFactoryTests
    {
        private Mock<ICommandFactory> _mockCommandFactory;
        private Mock<IAddProcessor> _mockAddProcessor;
        private ICommandWithResult<long> _addcommand;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _mockCommandFactory = new Mock<ICommandFactory>();
            _mockAddProcessor = new Mock<IAddProcessor>();
            _addcommand = new AddCommand(_mockAddProcessor.Object);
            _mockCommandFactory.Setup(mock => mock.Resolve(CommandEnum.Add, new object[] {"1", "1"}))
                .Returns(_addcommand);
        }

        [TestCase(CommandEnum.Add, new object[] {"1", "1"}, ExpectedResult = typeof(AddCommand))]
        public Type ResolveCommand_Command_Enum_CorrectCommand_Returned(CommandEnum commandEnum, object[] args)
        {
            return _mockCommandFactory.Object.Resolve(commandEnum, args).GetType();
        }

        public void ResolveCommand_Args_Parameter_Null_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _mockCommandFactory.Object.Resolve(CommandEnum.Add, null));
        }

        [Test]
        public void ResolveCommand_Command_Enum_Returns_Type_Of_ICommand()
        {
            var command = _mockCommandFactory.Object.Resolve(CommandEnum.Add, new object[] {"1", "1"});

            Assert.IsInstanceOf(typeof(ICommand), command);
        }

        [Test]
        public void ResolveCommand_CommandEnum_OfType_Add_Returns_Type_Of_ICommandWithResult_Long()
        {
            var command = _mockCommandFactory.Object.Resolve(CommandEnum.Add, new object[] {"1", "1"});

            Assert.IsInstanceOf(typeof(ICommandWithResult<long>), command);
        }
    }
}