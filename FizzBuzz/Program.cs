using System.Diagnostics.CodeAnalysis;
using FizzBuzz.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FizzBuzz
{
    [ExcludeFromCodeCoverage]
    static class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

            var fizzBuzzConfig = GetFizzBuzzConfig(configuration);
            
            var provider = new ServiceCollection()
                .AddSingleton<IOutput, ConsoleOutput>()
                .AddSingleton<Processor>()
                .AddSingleton(new Domain.FizzBuzz(fizzBuzzConfig.Fizz, fizzBuzzConfig.Buzz))
                .BuildServiceProvider();
            
            var processor = provider.GetService<Processor>();

            processor.Run(fizzBuzzConfig.Start, fizzBuzzConfig.End);
        }

        private static Configuration GetFizzBuzzConfig(IConfiguration config)
        {
            // Assuming config is correct for now. If not, it will
            // fail fast and loud but won't give much info as to why.
            var section = config.GetSection("FizzBuzz");
            return new Configuration
            {
                Start = int.Parse(section["Start"]),
                End = int.Parse(section["End"]),
                Fizz = new Input(int.Parse(section["Fizz:Divisor"]), section["Fizz:Display"]),
                Buzz = new Input(int.Parse(section["Buzz:Divisor"]), section["Buzz:Display"])
            };
        }
    }
}