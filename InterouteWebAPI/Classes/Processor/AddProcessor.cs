using InterouteWebAPI.Interfaces;

namespace InterouteWebAPI.Classes.Processor
{
    public class AddProcessor : IAddProcessor
    {
        public long Add(long integerOne, long integerTwo)
        {
            return integerOne + integerTwo;
        }
    }
}