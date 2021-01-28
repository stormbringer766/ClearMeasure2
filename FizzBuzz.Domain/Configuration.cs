using System.Diagnostics.CodeAnalysis;

namespace FizzBuzz.Domain
{
    [ExcludeFromCodeCoverage]
    public class Configuration
    {
        public int Start { get; set; }
        public int End { get; set; }
        public Input Fizz { get; set; }
        public Input Buzz { get; set; }
    }
}
