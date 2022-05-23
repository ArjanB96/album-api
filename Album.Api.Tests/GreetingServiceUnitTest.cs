using System;
using Xunit;
using Album.Api;

namespace Album.Api.Tests
{
    public class GreetingServiceUnitTest
    {
        Api.GreetingService.GreetingService greetingservice;

        var test = new Api.GreetingService.GreetingService().Greet("test");

        [Fact]
        public void Greet_With_Correct_Name_Should_Greet_Name()
        {
            //Arrange
            string name = "Arjan";

            //Act
            bool isValid = Greet(name);
            string greeting = new GreetingService().Greet(name);

            //Assert
            Assert.True(isValid, $"The name {name} is not valid");
        }
    }
}

