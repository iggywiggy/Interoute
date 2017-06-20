using System;
using InterouteWebAPI.Classes.Commands;
using InterouteWebAPI.Interfaces;
using Moq;
using NUnit.Framework;

namespace InterouteWebAPI.Tests.Commands
{
    [TestFixture]
    public class AddCommandTests
    {
        private ICommandWithResult<long> _addCommandWithResult;
        private Mock<IAddProcessor> _mockAddProcessor;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockAddProcessor = new Mock<IAddProcessor>();
            _addCommandWithResult = new AddCommand(_mockAddProcessor.Object);
        }

        [TestCase(1, 1, 2, ExpectedResult = 2)]
        [TestCase(10, 10, 20, ExpectedResult = 20)]
        [TestCase(-1, -1, 1, ExpectedResult = 1)]
        public long Execute_Returns_Correct_Result(int integerOne, int integerTwo, int integerThree)
        {
            _mockAddProcessor.Setup(mock => mock.Add(integerOne, integerTwo)).Returns(integerThree);

            return _mockAddProcessor.Object.Add(integerOne, integerTwo);
        }

        [Test]
        public void Constructor_Null_AddProcessor_Parameter_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AddCommand(null));
        }

        [Test]
        public void Execute_Null_args_Parameter_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _addCommandWithResult.Execute(null));
        }
    }
}