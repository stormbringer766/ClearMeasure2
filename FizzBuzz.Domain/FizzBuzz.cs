using System;

namespace FizzBuzz.Domain
{
    public class FizzBuzz
    {
        private readonly Input _fizz;
        private readonly Input _buzz;
        private readonly Input _fizzBuzz;

        public FizzBuzz(Input fizz, Input buzz)
        {
            _fizz = fizz ?? throw new ArgumentNullException(nameof(fizz));
            _buzz = buzz ?? throw new ArgumentNullException(nameof(buzz));
            _fizzBuzz = new Input(fizz.Divisor * buzz.Divisor, $"{_fizz.Display}{_buzz.Display}"); 
        }

        public string Process(int number)
        {
            var answer = number.ToString();

            if (_fizzBuzz.IsMatch(number))
            {
                answer = _fizzBuzz.Display;
            }
            else if (_fizz.IsMatch(number))
            {
                answer = _fizz.Display;
            }
            else if (_buzz.IsMatch(number))
            {
                answer = _buzz.Display;
            }
            return answer;
        }
    }
}
