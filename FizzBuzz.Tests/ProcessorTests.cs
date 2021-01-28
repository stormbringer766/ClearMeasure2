using System;
using FizzBuzz.Domain;
using FizzBuzz.Tests.Fixtures;
using Moq;
using Xunit;

namespace FizzBuzz.Tests
{
    public class ProcessorTests
    {
        private readonly Mock<IOutput> _output;
        private readonly Processor _sut;

        public ProcessorTests()
        {
            _output = new Mock<IOutput>();
            _sut = new Processor(FizzBuzzFixture.Setup(), _output.Object);
        }

        [Fact]
        public void Ctor_NullFizzBuzz_Throws()
        {
            //Arrange
            //Act
            //Assert
            Assert.Equal("fizzBuzz",
                Assert.Throws<ArgumentNullException>(() => new Processor(null, _output.Object)).ParamName);
        }

        [Fact]
        public void Ctor_NullOutput_Throws()
        {
            //Arrange
            //Act
            //Assert
            Assert.Equal("output",
                Assert.Throws<ArgumentNullException>(() => new Processor(FizzBuzzFixture.Setup(), null)).ParamName);
        }

        [Fact]
        public void Run_EndGreaterThanStart_Throws()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Run(5, 1));
        }

        [Fact]
        public void Run_Valid_RunsValues()
        {
            //Arrange
            //Act
            _sut.Run(1, 2);
            
            //Assert
            _output.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
