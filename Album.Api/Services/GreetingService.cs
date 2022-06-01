using System;

namespace Album.Api.Services
{
    public class GreetingService
    {
        public string Greet(string name)
        {
            if (name == "" || name == " " || name == null)
                return "Hello World!";
            else
                return $"Hello {name}!";
        }
    }
}