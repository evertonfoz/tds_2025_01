using System;
using MonolitoBackend.Core.Entities;

namespace MonolitoBackend.Core.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> AddAsync(Category category);
}
