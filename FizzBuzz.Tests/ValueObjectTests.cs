using System.Collections.Generic;
using FizzBuzz.Domain;
using Xunit;

namespace FizzBuzz.Tests
{
    public class ValueObjectTests
    {
        private readonly TestValueObject _sut;

        public ValueObjectTests()
        {
            _sut = new TestValueObject("customerSet", "US");
        }

        [Fact]
        public void Equals_ValuesEqual_ReturnsTrue()
        {
            //Arrange
            var actual = new TestValueObject(_sut.CustomerSet, _sut.Country);

            //Act
            //Assert
            Assert.Equal(_sut, actual);
        }

        [Fact]
        public void Equals_CustomerSetDifferent_ReturnsFalse()
        {
            //Arrange
            var actual = new TestValueObject(_sut.CustomerSet + "x", _sut.Country);

            //Act
            //Assert
            Assert.NotEqual(_sut, actual);
        }

        [Fact]
        public void Equals_CountryDifferent_ReturnsFalse()
        {
            //Arrange
            var actual = new TestValueObject(_sut.CustomerSet, _sut.Country + "x");

            //Act
            //Assert
            Assert.NotEqual(_sut, actual);
        }

        [Fact]
        public void Equals_ReferenceEquals_ReturnsTrue()
        {
            //Arrange
            //Act
            //Assert
            Assert.Equal(_sut, _sut);
        }

        [Fact]
        public void Equals_OtherNull_ReturnsFalse()
        {
            //Arrange
            //Act
            //Assert
            Assert.False(_sut.Equals(null));
        }

        [Fact]
        public void GetHasCode_ValuesEqual_ReturnsSameHashCode()
        {
            //Arrange
            var actual = new TestValueObject(_sut.CustomerSet, _sut.Country);

            //Act
            //Assert
            Assert.Equal(_sut.GetHashCode(), actual.GetHashCode());
        }

        [Fact]
        public void GetHasCode_CustomerSetDifferent_ReturnsDifferentHashCode()
        {
            //Arrange
            var actual = new TestValueObject(_sut.CustomerSet + "x", _sut.Country);

            //Act
            //Assert
            Assert.NotEqual(_sut.GetHashCode(), actual.GetHashCode());
        }

        [Fact]
        public void GetHasCode_CountryDifferent_ReturnsDifferentHashCode()
        {
            //Arrange
            var actual = new TestValueObject(_sut.CustomerSet, _sut.Country + "x");

            //Act
            //Assert
            Assert.NotEqual(_sut.GetHashCode(), actual.GetHashCode());
        }

        [Fact]
        public void GetHashCode_SingleValue_ReturnsHashOfValue()
        {
            //Arrange
            var value = new SingleValueValueObject("value");

            //Act
            var actual = value.GetHashCode();

            //Assert
            Assert.Equal("value".GetHashCode(), actual);
        }

        [Fact]
        public void ToString__ReturnsExpectedResult()
        {
            //Arrange
            //Act
            var actual = _sut.ToString();

            //Assert
            Assert.Equal("customerSet,US", actual);
        }
    }

    public class TestValueObject : ValueObject<TestValueObject>
    {
        public TestValueObject(string customerSet, string country)
        {
            CustomerSet = customerSet;
            Country = country;
        }

        public string CustomerSet { get; }
        public string Country { get; }

        protected override List<object> GetValues()
        {
            return new List<object>
            {
                CustomerSet,
                Country
            };
        }
    }

    public class SingleValueValueObject : ValueObject<SingleValueValueObject>
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public string Value { get; }

        public SingleValueValueObject(string value)
        {
            Value = value;
        }

        protected override List<object> GetValues()
        {
            return new List<object>
            {
                Value
            };
        }
    }
}
