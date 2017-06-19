using InterouteWebAPI.Processors;

namespace InterouteWebAPI.Classes
{
    public class AddProcessor : IAddProcessor
    {
        public long Add(long integerOne, long integerTwo)
        {
            return integerOne + integerTwo;
        }
    }
}