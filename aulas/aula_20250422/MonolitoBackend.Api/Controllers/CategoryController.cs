using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonolitoBackend.Core.Entities;
using MonolitoBackend.Core.Services;

namespace MonolitoBackend.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll() {
        var categories = await _categoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Category category) {
        if (category == null)
           return BadRequest("Invalid category data");

        await _categoryService.AddAsync(category);

        return Created(nameof(Create), category);
    }

}
