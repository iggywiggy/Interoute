using System;
using InterouteWebAPI.Processors;
using NUnit.Framework;

namespace InterouteWebAPI.Tests
{
    [TestFixture]
    public class CalculatorProcessorTests
    {
        private ICalculatorProcessor _calculationProcessor;

        [TestCase(1, 1, ExpectedResult = 2)]
        [TestCase(10, 10, ExpectedResult = 20)]
        [TestCase(200, 200, ExpectedResult = 400)]
        public long AddTwoIntegers(long integerOne, long integerTwo)
        {
            return _calculationProcessor.AddTwoIntegers(integerOne, integerTwo);
        }


        [Test]
        public void AddIntegers_return_value_throws_overflowexception()
        {
            Assert.Throws<OverflowException>(() => _calculationProcessor.AddTwoIntegers(long.MaxValue, 1));
        }
    }
}