using System;
using System.Collections.Generic;

namespace FizzBuzz.Domain
{
    public class Input: ValueObject<Input>
    {
        public Input(int divisor, string display)
        {
            if (divisor == 0)
                throw new ArgumentOutOfRangeException(nameof(divisor));
            if (string.IsNullOrWhiteSpace(display))
                throw new ArgumentNullException(nameof(display));

            Divisor = divisor;
            Display = display;
        }

        public bool IsMatch(int number)
        {
            return number%Divisor == 0;
        }

        public int Divisor { get; }

        public string Display { get; }
    
        protected override List<object> GetValues()
        {
            return new List<object>
            {
                Divisor,
                Display
            };
        }
    }
}