using Microsoft.AspNetCore.Mvc;
using MonolitoBackend.API.DTOs;
using MonolitoBackend.Core.Entities; 
using MonolitoBackend.Core.Services; 

namespace MonolitoBackend.API.Controllers; 

[ApiController] 
[Route("api/categories")] 
public class CategoryController(CategoryService categoryService) : ControllerBase { 
    private readonly CategoryService _categoryService = categoryService;

    [HttpGet] 
    public async Task<ActionResult<IEnumerable<Category>>> GetAll() { 
        var categories = await _categoryService.GetAllCategoriesAsync(); 
        return Ok(categories); 
    } 

    [HttpGet("{id:guid}")] 
    public async Task<ActionResult<Category>> GetById(Guid id) { 
        var category = await _categoryService.GetCategoryByIdAsync(id); 

        if (category == null) 
            return NotFound(); 

        return Ok(category); 
    } 

    [HttpPost] 
    public async Task<ActionResult> Create([FromBody] CategoryDTO categoryDTO) { 
        if (!ModelState.IsValid) return BadRequest(ModelState);
    
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = categoryDTO.Name,
            Description = categoryDTO.Description ?? "",
            IsActive = categoryDTO.IsActive
        };
        
        await _categoryService.AddCategoryAsync(category);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    } 

    [HttpPut("{id:guid}")] 
    public async Task<ActionResult>  Update(Guid id, [FromBody] Category category) { 
        if (category == null || id != category.Id) 
            return BadRequest("Invalid category data."); 

        var existingCategory = await _categoryService.GetCategoryByIdAsync(id); 
        if (existingCategory == null) 
            return NotFound(); 

        await _categoryService.UpdateCategoryAsync(category); 

        return NoContent(); 
    } 
    [HttpDelete("{id:guid}")] 
    public async Task<ActionResult> Delete(Guid id) { 
        var category = await _categoryService.GetCategoryByIdAsync(id); 
        if (category == null) 
            return NotFound(); 

        await _categoryService.DeleteCategoryAsync(id); 

        return NoContent(); 
    } 
} 