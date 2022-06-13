using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Album.Api.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Album.Api;


namespace Album.Api
{
    public class AlbumService : ControllerBase, IAlbumService
    {
        private readonly AlbumContext _context;

        public AlbumService(AlbumContext context) =>
            _context = context;

        // GET
        public async Task<ActionResult<IEnumerable<Models.Album>>> GetAlbums() =>
            await _context.Albums.ToListAsync();

        // GET specific
        public async Task<ActionResult<Models.Album>> GetAlbum(int id)
        {
            Models.Album album = await _context.Albums.FindAsync(id);

            if (album == null)
                return NotFound();

            return album;
        }

        // PUT
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

        // Post
        public async Task<ActionResult<Models.Album>> PostAlbum(Models.Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbum", new { id = album.Id }, album);
        }

        // Delete
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            Models.Album album = await _context.Albums.FindAsync(id);

            if (album == null)
                return NotFound();

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public bool AlbumExists(int id) =>
            _context.Albums.Any(e => e.Id == id);

        
    }

    public interface IAlbumService
    {
        public Task<ActionResult<IEnumerable<Models.Album>>> GetAlbums();
        public Task<ActionResult<Models.Album>> GetAlbum(int id);
        public Task<IActionResult> PutAlbum(int id, Models.Album album);
        public Task<ActionResult<Models.Album>> PostAlbum(Models.Album album);
        public Task<IActionResult> DeleteAlbum(int id);
        public bool AlbumExists(int id);
    }
}