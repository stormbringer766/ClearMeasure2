using System;
using FizzBuzz.Domain;
using Xunit;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";

        private Domain.FizzBuzz _sut;

        public FizzBuzzTests()
        {
            var fizz = new Input(3, Fizz);
            var buzz = new Input(5, Buzz);

            _sut = new Domain.FizzBuzz(fizz, buzz);
        }

        [Fact]
        public void Process_3_ReturnsFizz()
        {
            //Arrange
            //Act
            var actual = _sut.Process(3);
            
            //Assert
            Assert.Equal(Fizz, actual);
        }
        
        [Fact]
        public void Process_5_ReturnsBuzz()
        {
            //Arrange
            //Act
            var actual = _sut.Process(5);

            //Assert
            Assert.Equal(Buzz, actual);
        }

        [Fact]
        public void Process_15_ReturnsFizzBuzz()
        {
            //Arrange
            //Act
            var actual = _sut.Process(15);

            //Assert
            Assert.Equal(Fizz + Buzz, actual);
        }

        [Fact]
        public void Constructor_NullFizz_Throws()
        {
            //Arrange
            //Act
            //Assert
            Assert.Equal("fizz",
                Assert.Throws<ArgumentNullException>(() => new Domain.FizzBuzz(null, new Input(1, "Display")))
                    .ParamName);
        }

        [Fact]
        public void Constructor_NullBuzz_Throws()
        {
            //Arrange
            //Act
            //Assert
            Assert.Equal("buzz",
                Assert.Throws<ArgumentNullException>(() => new Domain.FizzBuzz(new Input(1, "Display"),null ))
                    .ParamName);
        }
    }
}
