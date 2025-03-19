using Moq;
using MonolitoBackend.Core.Entities;
using MonolitoBackend.Core.Repositories;
using MonolitoBackend.Core.Services;

namespace MonolitoBackend.Tests.Services;

public class CategoryServiceTests
{
    private readonly CategoryService _categoryService;
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock;

    public CategoryServiceTests()
    {
        _categoryRepositoryMock = new Mock<ICategoryRepository>();
        _categoryService = new CategoryService(_categoryRepositoryMock.Object); 
    }

    [Fact]
    public async Task GetAllCategoriesAsync_ShouldReturnCategories()
    {
        // Arrange
        var categories = new List<Category>
        {
            new() { Id = Guid.NewGuid(), Name = "Movies" },
            new() { Id = Guid.NewGuid(), Name = "Series" }
        };

        _categoryRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(categories);

        // Act
        var result = await _categoryService.GetAllCategoriesAsync();

        // Assert
        Assert.Equal(2, result.Count());
    }
}