using FizzBuzz.Domain;

namespace FizzBuzz.Tests.Fixtures
{
    public static class FizzBuzzFixture
    {
        public static Domain.FizzBuzz Setup()
        {
            return new Domain.FizzBuzz(
                new Input(3, "Fizz"),
                new Input(5, "Buzz"));
        }
    }
}
