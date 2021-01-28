using System;

namespace FizzBuzz.Domain
{
    public class Processor
    {
        private readonly FizzBuzz _fizzBuzz;
        private readonly IOutput _output;

        public Processor(FizzBuzz fizzBuzz, IOutput output)
        {
            _fizzBuzz = fizzBuzz ?? throw new ArgumentNullException(nameof(fizzBuzz));
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }
        
        public void Run(int start, int end)
        {
            if (end < start)
                throw new ArgumentOutOfRangeException(nameof(end));

            for (int i = start; i <= end; i++)
            {
                _output.WriteLine(_fizzBuzz.Process(i));
            }
        }
    }
}
