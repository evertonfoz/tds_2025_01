using MonolitoBackend.Core.Entities; 
using MonolitoBackend.Core.Repositories; 
namespace MonolitoBackend.Core.Services; 
public class CategoryService(ICategoryRepository categoryRepository)
{ 
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync() { 
        return await _categoryRepository.GetAllAsync(); 
    } 
    public async Task<Category?> GetCategoryByIdAsync(Guid id) { 
        return await _categoryRepository.GetByIdAsync(id); 
    } 
    public async Task AddCategoryAsync(Category category) { 
        await _categoryRepository.AddAsync(category); 
    } 
    public async Task UpdateCategoryAsync(Category category) { 
        await _categoryRepository.UpdateAsync(category); 
    } 
    public async Task DeleteCategoryAsync(Guid id) { 
        await _categoryRepository.DeleteAsync(id); 
    } 
} 