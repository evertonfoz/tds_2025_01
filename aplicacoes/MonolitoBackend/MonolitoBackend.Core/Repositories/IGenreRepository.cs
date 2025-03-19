using MonolitoBackend.Core.Entities; 

namespace MonolitoBackend.Core.Repositories; 
public interface IGenreRepository { 
    Task<IEnumerable<Genre>> GetAllAsync(); 
    Task<Genre?> GetByIdAsync(Guid id); 
    Task AddAsync(Genre genre); 
    Task UpdateAsync(Genre genre); 
    Task DeleteAsync(Guid id); 
} 