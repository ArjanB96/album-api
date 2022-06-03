using System;
using Xunit;
using Album.Api;

namespace Album.Api.Tests
{
    public class GreetingServiceUnitTest
    {
        [Fact]
        public void Greet_With_Correct_Name_Should_Greet_Name()
        {
            // Given
            string name = "Arjan";
            var = Dns.GetHostName();
            // When
            string greeting = GreetingService.Greet(name);

            // Then
            Assert.Equal("Hello {name} from {Dns.GetHostName()}!", greeting);
        }

        [Fact]
        public void Greet_With_Null_Empty_Or_WhiteSpace_Should_Return_Hello_World()
        {
            // Given
            string nameEmpty = "";
            string nameWhitespace = " ";
            string nameNull = null;

            // When
            string greetingEmpty = GreetingService.Greet(nameEmpty);
            string greetingWhitespace = GreetingService.Greet(nameWhitespace);
            string greetingNull = GreetingService.Greet(nameNull);

            // Then 
            Assert.Equal("Hello World!", greetingEmpty);
            Assert.Equal("Hello World!", greetingWhitespace);
            Assert.Equal("Hello World!", greetingNull);
        }
    }
}

