using System;
using Xunit;
using Album.Api;
using System.Net;

namespace Album.Api.Tests
{
    public class GreetingServiceUnitTest
    {
        [Fact]
        public void Greet_With_Correct_Name_Should_Greet_Name()
        {
            // Given
            string name = "Arjan";
            var hostname = Dns.GetHostName();
            // When
            var greetingService = new GreetingService();
            string greeting = greetingService.Greet(name);

            // Then
            Assert.Equal("Hello {name} from {hostname} v2!", greeting);
        }

        [Fact]
        public void Greet_With_Null_Empty_Or_WhiteSpace_Should_Return_Hello_World()
        {
            // Given
            string nameEmpty = "";
            string nameWhitespace = " ";
            string nameNull = null;

            // When
            var greetingService = new GreetingService();
            string greetingEmpty = greetingService.Greet(nameEmpty);
            string greetingWhitespace = greetingService.Greet(nameWhitespace);
            string greetingNull = greetingService.Greet(nameNull);

            // Then 
            Assert.Equal("Hello World!", greetingEmpty);
            Assert.Equal("Hello World!", greetingWhitespace);
            Assert.Equal("Hello World!", greetingNull);
        }
    }
}

