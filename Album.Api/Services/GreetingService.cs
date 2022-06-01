using System;

namespace Album.Api.Services
{
    public static class GreetingService
    {
        public static string Greet(string name)
        {
            if (name == "" || name == " " || name == null)
                return "Hello World!";
            else
                return $"Hello {name}!";
        }
    }
}