using InterouteWebAPI.Classes.Processor;
using InterouteWebAPI.Interfaces;
using NUnit.Framework;

namespace InterouteWebAPI.Tests.Processors
{
    [TestFixture]
    public class AddProcessorTests
    {
        private IAddProcessor _addProcessor;

        [OneTimeSetUp]
        public void Setup()
        {
            _addProcessor = new AddProcessor();
        }

        [TestCase(1, 1, ExpectedResult = 2)]
        [TestCase(10, 10, ExpectedResult = 20)]
        [TestCase(200, 200, ExpectedResult = 400)]
        [TestCase(long.MaxValue, long.MaxValue, ExpectedResult = -2)]
        [TestCase(long.MinValue, long.MinValue, ExpectedResult = 0)]
        public long AddTwoIntegers(long integerOne, long integerTwo)
        {
            return _addProcessor.Add(integerOne, integerTwo);
        }
    }
}