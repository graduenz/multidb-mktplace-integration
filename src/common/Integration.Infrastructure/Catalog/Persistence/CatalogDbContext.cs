using System.Reflection;
using Integration.Domain.Catalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Integration.Infrastructure.Catalog.Persistence;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions options)
        : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}