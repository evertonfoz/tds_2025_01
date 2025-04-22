using System;

namespace MonolitoBackend.Core.Entities;

// public class Category(string name, string description, Guid? categoryId = null,
//         bool isActive = false, DateTime? createAt = null, DateTime? updatedAt = null)
public class Category
{
    public Guid? CategoryId { get; set; }// = categoryId;
    public required string Name { get; set; }// = name;
    public required string Description { get; set; }// = description;
    public bool IsActive { get; set; }// = isActive;
    public DateTime? CreatedAt { get; set; }// = createAt;
    public DateTime? UpdatedAt { get; set; }// = updatedAt;

    public Category()
    {
        
    }
}
