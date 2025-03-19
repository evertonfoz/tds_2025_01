using Microsoft.EntityFrameworkCore; 
using MonolitoBackend.Core.Entities; 
using MonolitoBackend.Core.Repositories; 
using MonolitoBackend.Infrastructure.Data; 
namespace MonolitoBackend.Infrastructure.Repositories; 
public class GenreRepository(AppDbContext context) : IGenreRepository { 
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Genre>> GetAllAsync() { 
        return await _context.Genres.Include(g => g.Categories).ToListAsync(); 
    } 
    public async Task<Genre?> GetByIdAsync(Guid id) { 
        return await _context.Genres.Include(g => g.Categories).FirstOrDefaultAsync(g => g.Id == id); 
    } 
    public async Task AddAsync(Genre genre) { 
        await _context.Genres.AddAsync(genre); 
        await _context.SaveChangesAsync(); 
    } 
    public async Task UpdateAsync(Genre genre) { 
        _context.Genres.Update(genre); 
        await _context.SaveChangesAsync(); 
    } 
    public async Task DeleteAsync(Guid id) { 
        var genre = await _context.Genres.FindAsync(id); 
        if (genre != null) { 
            _context.Genres.Remove(genre); 
            await _context.SaveChangesAsync(); 
        } 
    } 
} 