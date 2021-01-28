using System.Diagnostics.CodeAnalysis;

namespace FizzBuzz.Domain
{
    public interface IOutput
    {
        void WriteLine(string value);
    }

    [ExcludeFromCodeCoverage]
    public class ConsoleOutput : IOutput
    {
        public void WriteLine(string value)
        {
            System.Console.WriteLine(value);
        }
    }
}
