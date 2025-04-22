using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using MonolitoBackend.Core.Repositories;
using MonolitoBackend.Core.Services;
using MonolitoBackend.Infrastructure.Data;
using MonolitoBackend.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("PostgreSql");
builder.Services.AddDbContext<AppDbContext>(
     options => options.UseNpgsql(connectionString)
    );
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
// app.UseHttpsRedirection();

app.MapControllers();
app.Run();
