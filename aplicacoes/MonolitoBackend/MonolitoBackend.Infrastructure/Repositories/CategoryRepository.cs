using Microsoft.EntityFrameworkCore; 
using MonolitoBackend.Core.Entities; 
using MonolitoBackend.Core.Repositories; 
using MonolitoBackend.Infrastructure.Data; 

namespace MonolitoBackend.Infrastructure.Repositories; 
public class CategoryRepository(AppDbContext context) : ICategoryRepository { 
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Category>> GetAllAsync() { 
        return await _context.Categories.ToListAsync(); 
    } 
    public async Task<Category?> GetByIdAsync(Guid id) { 
        return await _context.Categories.FindAsync(id); 
    } 
    public async Task AddAsync(Category category) { 
        await _context.Categories.AddAsync(category); 
        await _context.SaveChangesAsync(); 
    } 
    public async Task UpdateAsync(Category category) { 
        _context.Categories.Update(category); 
        await _context.SaveChangesAsync(); 
    } 
    public async Task DeleteAsync(Guid id) { 
        var category = await _context.Categories.FindAsync(id); 
        if (category != null) { 
            _context.Categories.Remove(category); 
            await _context.SaveChangesAsync(); 
        } 
    } 
} 
