using Album.Api.Models;
using System;
using System.Linq;

namespace Album.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AlbumContext context)
        {
            context.Database.EnsureCreated();

            // Look for any albums.
            if (context.Albums.Any())
            {
                return;   // DB has been seeded
            }

            var albums = new Models.Album[]
            {
            new Models.Album{Id=1,Name="Alexander", Artist="Snoop Dogg", ImageUrl="www.google.com/test"},
            new Models.Album{Id=2,Name="Frenkie", Artist="Eminem", ImageUrl="www.google.com/test"},
            new Models.Album{Id=3,Name="Karel", Artist="50 Cent", ImageUrl="www.google.com/test"},
            new Models.Album{Id=4,Name="Pietje", Artist="Lil Wayne", ImageUrl="www.google.com/test"}
            };
            foreach (Models.Album a in albums)
            {
                context.Albums.Add(a);
            }
            context.SaveChanges();
        }
    }
}