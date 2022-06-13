using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Album.Api.Models;
using Album.Api;

namespace Album.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly AlbumService _albumService;

        public AlbumsController(AlbumContext context)
        {
            _albumService = new AlbumService(context);
        }
        /// <summary>
        /// Retrieves all albums stored in the database
        /// </summary>
        /// <response code="200">Succes</response>

        // GET: api/Albums

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Models.Album>>> GetAlbums()
        {
            return await _albumService.GetAlbums();
        } 

        /// <summary>
        /// Retrieves the album with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Succes</response>
        /// <response code="400">If the id or album is null</response>
        /// <remarks>for example: id = 3</remarks>

        // GET: api/Albums/5

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult<Models.Album>> GetAlbum(int id)
        {
            return await _albumService.GetAlbum(id);
        }

        /// <summary>
        /// Adds an album to the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="album"></param>
        /// <response code="200">Succes</response>
        /// <response code="400">If the id or album is null</response>
        /// <remarks>for example: id = 3</remarks>

        // PUT: api/Albums/5

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<IActionResult> PutAlbum(int id, Models.Album album) 
        {
            return await _albumService.PutAlbum(id, album);
        }
            
        /// <summary>
        /// Adds an album to the database
        /// </summary>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // POST: api/Albums

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Models.Album>> PostAlbum(Models.Album album)
        {
            return await _albumService.PostAlbum(album);
        } 

        /// <summary>
        /// Deletes an album from the database
        /// </summary>
        /// <response code="400">If the id is null</response>
        /// <remarks>for example: id = 3</remarks>
        // DELETE: api/Albums/5

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteAlbum(int id)
        {
            return await _albumService.DeleteAlbum(id);
        } 

        /// <summary>
        /// Check if a given albumid is in the database. Returns true if it is, else false
        /// </summary>
        /// <remarks>for example: id = 3</remarks>
        /// <response code="400">If the id is null</response>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private bool AlbumExists(int id)
        {
            return _albumService.AlbumExists(id);
        }
            
    }
}
