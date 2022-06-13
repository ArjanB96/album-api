using System;
using Xunit;
using Album.Api;
using System.Net;
using Album.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Album.Api.Tests
{
    public class AlbumControllerUnitTest
    {   
        [Fact]
        public void Test1()
        {
            // mock the database
            var options = new DbContextOptionsBuilder<AlbumContext>()
                .UseInMemoryDatabase(databaseName: "postgres")
                .Options;
            
            using (var context = new AlbumContext(options))
            {
                context.Albums.Add(new Album.Api.Models.Album { Id = 1, Name = "Unlimited Love", Artist = "Red Hot Chili Peppers", ImageUrl = "http://www.google.com" });
                context.Albums.Add(new Album.Api.Models.Album { Id = 2, Name = "Master of Puppets", Artist = "Metallica", ImageUrl = "http://www.google.com" });

                context.SaveChanges();

                var controller = new Album.Api.Controllers.AlbumsController(context);
                var albums = controller.GetAlbums();
                Assert.Equal(2, context.Albums.Count());
            }
        }
    }
}

        

//string connectionString =  "Host=cnsd-db-1965795.cd4msfhbkrhs.us-east-1.rds.amazonaws.com;Database=albumdatabase;Username=postgres;Password=postgres";
