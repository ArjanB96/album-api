using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using Album.Api;
using Microsoft.Extensions.Configuration;

namespace Album.Api.Models
{
    public class AlbumContext : DbContext   
    {
        public DbSet<Album> Albums { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           //=> optionsBuilder.UseNpgsql("Host=cnsd-db-1965795.cd4msfhbkrhs.us-east-1.rds.amazonaws.com;Database=albumdatabase;Username=postgres;Password=postgres");

        public AlbumContext(DbContextOptions<AlbumContext> options) : base(options) { }
    }


    public class Album
    {
        ///<summary>
        /// The id of the album
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the album
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The name of the artist
        /// </summary>
        public string Artist { get; set; }
        /// <summary>
        /// The url to an image of the album cover
        /// </summary>
        public string ImageUrl { get; set; }    

    }
}
