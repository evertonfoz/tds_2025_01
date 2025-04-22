using System;
using Microsoft.EntityFrameworkCore;
using MonolitoBackend.Core.Entities;

namespace MonolitoBackend.Infrastructure.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
}
