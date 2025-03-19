using MonolitoBackend.Core.Entities; 
using MonolitoBackend.Core.Repositories; 
namespace MonolitoBackend.Core.Services; 
public class GenreService(IGenreRepository genreRepository)
{ 
    private readonly IGenreRepository _genreRepository = genreRepository;

    public async Task<IEnumerable<Genre>> GetAllGenresAsync() { 
        return await _genreRepository.GetAllAsync(); 
    } 
    public async Task<Genre?> GetGenreByIdAsync(Guid id) { 
        return await _genreRepository.GetByIdAsync(id); 
    } 
    public async Task AddGenreAsync(Genre genre) { 
        await _genreRepository.AddAsync(genre); 
    } 
    public async Task UpdateGenreAsync(Genre genre) { 
        await _genreRepository.UpdateAsync(genre); 
    } 
    public async Task DeleteGenreAsync(Guid id) { 
        await _genreRepository.DeleteAsync(id); 
    } 
} 