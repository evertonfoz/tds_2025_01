using System;
using Microsoft.EntityFrameworkCore;
using MonolitoDemo.Api.Model;

namespace MonolitoDemo.Api.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
}
