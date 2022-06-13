using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Album.Api.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace Album.Api
{
    public interface IAlbumService
    {
        public Task<ActionResult<IEnumerable<Models.Album>>> GetAlbums();
        public Task<ActionResult<Models.Album>> GetAlbum(int id);
        public Task<IActionResult> PutAlbum(int id, Models.Album album);
        public Task<ActionResult<Models.Album>> PostAlbum(Models.Album album);
        public Task<IActionResult> DeleteAlbum(int id);
        public bool AlbumExists(int id);
    }
    public class AlbumService : IAlbumService
    {
        public readonly AlbumContext _context;

        public AlbumService(AlbumContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Models.Album>>> GetAlbums()
        {
            await _context.Albums.ToListAsync();
        }

        public async Task<ActionResult<Models.Album>> GetAlbum(int id)
        {
            Models.Album album = await _context.Albums.FindAsync(id);

            if (album == null)
                return NotFound();

            return album;
        }

        public async Task<IActionResult> PutAlbum(int id, Models.Album album)
        {
            if (id != album.Id)
                return BadRequest();

            _context.Entry(album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
                    return NotFound();
                else 
                    throw;
            }

            return NoContent();
        }

        public bool AlbumExists(int id)
        {
            _context.Albums.Any(e => e.Id == id);
        }  
    }
}


