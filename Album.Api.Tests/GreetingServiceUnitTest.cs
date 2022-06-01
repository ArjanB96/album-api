using System;
using Xunit;
using Album.Api.Services;

namespace Album.Api.Tests
{
    public class GreetingServiceUnitTest
    {
        [Fact]
        public void Greet_With_Correct_Name_Should_Greet_Name()
        {
            //Arrange
            string name = "Arjan";

            //Act
            string greeting = GreetingService.Greet(name);

            //Assert
            Assert.Equal("Arjan", greeting, $"The name {name} is not valid");
        }
    }
}

