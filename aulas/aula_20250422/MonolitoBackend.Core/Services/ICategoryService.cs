using System;
using MonolitoBackend.Core.Entities;

namespace MonolitoBackend.Core.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> AddAsync(Category category);

}
