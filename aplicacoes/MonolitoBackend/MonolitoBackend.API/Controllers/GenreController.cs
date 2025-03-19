using Microsoft.AspNetCore.Mvc; 
using MonolitoBackend.Core.Entities; 
using MonolitoBackend.Core.Services; 

namespace MonolitoBackend.API.Controllers;  
[ApiController] 
[Route("api/genres")] 
public class GenreController(GenreService genreService) : ControllerBase { 
    private readonly GenreService _genreService = genreService;

    [HttpGet] 
    public async Task<ActionResult<IEnumerable<Genre>>> GetAll() { 
        var genres = await _genreService.GetAllGenresAsync(); 
        return Ok(genres); 
    } 
    [HttpGet("{id:guid}")] 
    public async Task<ActionResult<Category>> GetById(Guid id) { 
        var genre = await _genreService.GetGenreByIdAsync(id); 
        if (genre == null) 
            return NotFound(); 
        return Ok(genre); 
    } 
    [HttpPost] 
    public async Task<ActionResult> Create([FromBody] Genre genre) { 
        if (genre == null) 
            return BadRequest("Invalid genre data."); 
        await _genreService.AddGenreAsync(genre); 
        return CreatedAtAction(nameof(GetById), new { id = genre.Id }, genre); 
    } 
    [HttpPut("{id:guid}")] 
    public async Task<ActionResult> Update(Guid id, [FromBody] Genre genre) { 
        if (genre == null || id != genre.Id) 
            return BadRequest("Invalid genre data."); 
        var existingGenre = await _genreService.GetGenreByIdAsync(id); 
        if (existingGenre == null) 
            return NotFound(); 
        await _genreService.UpdateGenreAsync(genre); 
        return NoContent(); 
    } 
    [HttpDelete("{id:guid}")] 
    public async Task<ActionResult> Delete(Guid id) { 
        var genre = await _genreService.GetGenreByIdAsync(id); 
        if (genre == null) 
            return NotFound(); 
        await _genreService.DeleteGenreAsync(id); 
        return NoContent(); 
    } 
} 