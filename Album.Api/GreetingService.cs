namespace Album.Api
{
    public class GreetingService
    {
        public GreetingService() { }
        }
        public string Greet(string name)
        {
            if (name == "" || name == " " || name == null)
            {
                return "Hello World!";
            }
            else
            {
                return $"Hello {name}!";
            }
        }
    }
}