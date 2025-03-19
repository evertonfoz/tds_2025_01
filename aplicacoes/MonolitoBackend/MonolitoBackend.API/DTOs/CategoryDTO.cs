using System.ComponentModel.DataAnnotations;

namespace MonolitoBackend.API.DTOs;

public class CategoryDTO
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}