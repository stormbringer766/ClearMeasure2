using System;
using FizzBuzz.Domain;
using Xunit;

namespace FizzBuzz.Tests
{
    public class InputTests
    {
        private readonly Input _expected;

        public InputTests()
        {
            _expected = new Input(2, "Display");
        }
        
        [Fact]
        public void Constructor_Zero_Throws()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Input(0, "display"));
        }

        [Fact]
        public void Constructor_EmptyDisplay_Throws()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new Input(1, ""));
        }

        [Fact]
        public void Equals_Equal_ReturnsTrue()
        {
            //Arrange
            var actual = new Input(_expected.Divisor, _expected.Display);

            //Act
            //Assert
            Assert.Equal(_expected, actual);
        }

        [Fact]
        public void IsMatch_Matches_ReturnsTrue()
        {
            //Arrange
            //Act
            var actual = _expected.IsMatch(4);
            
            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void IsMatch_NoMatch_ReturnsFalse()
        {
            //Arrange
            //Act
            var actual = _expected.IsMatch(3);
            
            //Assert
            Assert.False(actual);
        }
    }
}
